using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;
using System.Reflection;
using System.Windows.Threading;
using System.Windows;
using HLP.Base.ClassesBases;
using HLP.Base.Static;
using HLP.Entries.Services.RecursosHumanos;
using HLP.Base.Modules;
using HLP.Entries.ViewModel.ViewModels.Gerais;
using HLP.Entries.Model.Models.RecursosHumanos;
using HLP.Entries.Model.Models.Gerais;
using HLP.Components.Model.Models;
using HLP.Entries.Services.Gerais;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;

namespace HLP.Entries.ViewModel.Commands.Gerais
{
    public class EspelhoPontoCommand
    {
        FuncionarioPontoService servicoFuncPonto;
        FuncionarioService servicoFuncionario;
        public EspelhoPontoViewModel objViewModel;
        CalendarioService serviceCalendario;
        private bool bCanNavega { get; set; }

        public EspelhoPontoCommand(EspelhoPontoViewModel objViewModel)
        {

            this.objViewModel = objViewModel;
            servicoFuncPonto = new FuncionarioPontoService();

            this.objViewModel.commandNovo = new RelayCommand(execute: paramExec => this.Novo(),
                  canExecute: paramCanExec => false);

            this.objViewModel.commandSalvar = new RelayCommand(execute: paramExec => this.Novo(),
                       canExecute: paramCanExec => false);

            this.objViewModel.commandCopiar = new RelayCommand(execute: paramExec => this.Novo(),
                       canExecute: paramCanExec => false);

            this.objViewModel.commandDeletar = new RelayCommand(execute: paramExec => this.Novo(),
                       canExecute: paramCanExec => false);

            this.objViewModel.commandCancelar = new RelayCommand(execute: paramExec => this.objViewModel.cancelarBaseCommand.Execute(null),
                       canExecute: paramCanExec => false);

            this.objViewModel.commandAlterar = new RelayCommand(execute: paramExec => this.objViewModel.alterarBaseCommand.Execute(parameter: paramExec),
                   canExecute: paramCanExec => false);

            this.objViewModel.commandPesquisar = new RelayCommand(execute: paramExec => this.ExecPesquisa(),
                       canExecute: paramCanExec => true);

            this.objViewModel.navegarCommand = new RelayCommand(execute: paramExec => this.Navegar(ContentBotao: paramExec),
                canExecute: paramCanExec => this.CanNavegar(paramCanExec));


            this.objViewModel.carregarCommand = new RelayCommand(execute: paramExec => this.CarragaFormulario(),
                canExecute: paramCan => this.CanCarregaFormulario());

            this.objViewModel.commandFecharMes = new RelayCommand(execute: paramExec => this.SaveBancoHoras(),
                canExecute: paramCan => this.CanSaveBancoHoras());

            this.objViewModel.commandReabrirMes = new RelayCommand(execute: paramExec => this.ReabrirMes(),
              canExecute: paramCan => this.CanReabrirMes());

            this.objViewModel.commandNavegaData = new RelayCommand(execute: paramExec => this.NavegaData(param: paramExec),
                canExecute: paramCan => this.CanCarregaFormulario());

            this.objViewModel.commandImprimir = new RelayCommand(execute: paramExec => this.PreviewReport(),
               canExecute: paramCan => this.PreviewReportCanExec());

            this.objViewModel.CorrigirSaidaCommand = new RelayCommand(execute: paramExec => this.CorrigirSaida(),
              canExecute: paramCan => this.CanCarregaFormulario());

            //


            foreach (Control ctr in objViewModel.lControlsPonto)
            {
                try
                {
                    Type tipo = ctr.GetType();
                    MethodInfo met = tipo.GetMethod(name: "RefreshWindowPrincipal");
                    met.Invoke(ctr, new object[] { (Action)this.CarragaFormulario });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            this.objViewModel.bWorkerPesquisa.WorkerSupportsCancellation = true;
            this.objViewModel.bWorkerPesquisa.DoWork += new DoWorkEventHandler(this.ExecutePesquisa);
            this.objViewModel.bWorkerPesquisa.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.ExecutePesquisaCompleted);
            this.objViewModel.bWorkerPrint.DoWork += bWorkerPrint_DoWork;
            this.objViewModel.bWorkerPrint.RunWorkerCompleted += bWorkerPrint_RunWorkerCompleted;

        }

        private void CorrigirSaida()
        {
            object win = Sistema.ExecuteMethodByReflection
                      (xNamespace: "HLP.Entries.View.WPF",
                      xType: "WinCorrigirUltimoPonto",
                      xMethod: "ShowWindow",
                      parameters: new object[] { this.objViewModel.currentModel.data, this.objViewModel.currentModel.idFuncionario });

            Type tipo = win.GetType();
            MethodInfo met = tipo.GetMethod(name: "RefreshWindowPrincipal");
            met.Invoke(win, new object[] { (Action)this.CarragaFormulario });
        }






        void bWorkerPrint_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Window winReport = GerenciadorModulo.Instancia.CarregaForm("WinPreviewReport", Base.InterfacesBases.TipoExibeForm.Modal);
            DataSet dsTemp = null;
            string xPath = Pastas.Path_Report("rptEspelhoPonto.rpt");
            if (xPath != "")
            {
                ReportDocument rpt = new ReportDocument();
                rpt.Load(xPath);
                dsTemp = new DataSet();
                dsTemp.ReadXml(e.Result.ToString());
                rpt.SetDataSource(dsTemp);
                //DataSet img = Sistema.dsImagemToReport;                                
                //rpt.Database.Tables["Imagens"].SetDataSource(img.Tables[0]);
                winReport.SetPropertyValue("rpt", rpt);
                rpt.Refresh();
                winReport.WindowState = WindowState.Maximized;
                winReport.ShowDialog();

            }
            else
            {
                MessageHlp.Show(StMessage.stAlert, "Relatório nao encontrado.");
            }
        }

        void bWorkerPrint_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                EspelhoPontoPrintModel objPrintPonto = new EspelhoPontoPrintModel();
                EmpresaModel objEmpresa = CompanyData.objEmpresaModel as EmpresaModel;
                EnderecoModel objEnderEmpresa = null;
                if (objEmpresa.lEmpresa_endereco.Count() > 0)
                    if (objEmpresa.lEmpresa_endereco.Where(c => ((byte)c.stPrincipal) == 0).Count() > 0)
                        objEnderEmpresa = objEmpresa.lEmpresa_endereco.FirstOrDefault((c => ((byte)c.stPrincipal) == 0));
                    else
                        objEnderEmpresa = objEmpresa.lEmpresa_endereco.FirstOrDefault();
                objPrintPonto.xEmpresa = objEmpresa.xNome;
                if (objEnderEmpresa != null)
                {
                    objPrintPonto.xEndereco = string.Format("{0}, Nº{1}, BAIRRO: {2}",
                        objEnderEmpresa.xEndereco.ToUpper(),
                        objEnderEmpresa.nNumero.ToUpper(),
                        objEnderEmpresa.xBairro.ToUpper());
                }
                objPrintPonto.xCnpj = objEmpresa.xCNPJ.Replace(",", ".");
                objPrintPonto.idEmpresa = CompanyData.idEmpresa;
                objPrintPonto.xMesAno = string.Format("PONTO ASSOCIADO AO MÊS DE {0} DE {1}",
                    this.objViewModel.currentModel.data.ToString("MMMMMMMMM").ToUpper(),
                    this.objViewModel.currentModel.data.Year);

                if (servicoFuncionario == null)
                    servicoFuncionario = new FuncionarioService();
                HeaderEspelhoPontoPrintModel objHeader;
                foreach (int item in this.objViewModel.navigatePesquisa)
                {
                    FuncionarioModel objFunc = servicoFuncionario.GetObject(item, false);// corrigir service
                    objHeader = new HeaderEspelhoPontoPrintModel();
                    objHeader.idFuncionario = item;
                    objHeader.xNomeFuncionario = objFunc.xNome;
                    objHeader.xCodigoAlternativo = objFunc.xCodigoAlternativo;
                    objHeader.xCpf = objFunc.xCpf;
                    objHeader.idCalendario = objFunc.idCalendario;
                    objHeader.dtMes = this.objViewModel.currentModel.data.ToShortDateString();
                    objPrintPonto.lHeaderFuncionario.Add(objHeader);
                }

                List<KeyValuePair<int, string>> lHorariosPrincipais = new List<KeyValuePair<int, string>>();

                if (serviceCalendario == null)
                    serviceCalendario = new CalendarioService();

                // Calendarios
                foreach (int idCalendario in objPrintPonto.lHeaderFuncionario.Where(c => c.idCalendario != null).Select(c => c.idCalendario).Distinct())
                {
                    CalendarioModel objCalendarioModel = serviceCalendario.GetObject(idCalendario, false);

                    string xIntervalo = "";
                    foreach (var intervalo in serviceCalendario.GetIntervalos(idCalendario))
                    {
                        xIntervalo = xIntervalo + string.Format("{0}{1}-{2} :{3}", (xIntervalo == "" ? "" : " | "), intervalo.tInicio.ToStringHoras(), intervalo.tFinal.ToStringHoras(), intervalo.getTipoIntervalo());
                    }

                    foreach (var header in objPrintPonto.lHeaderFuncionario.Where(c => c.idCalendario == idCalendario))
                    {
                        header.xHoraSeqQuinta = objCalendarioModel.tHoraInicialSegQui.ToStringHoras() + " - " + objCalendarioModel.tHoraFinalSegQui.ToStringHoras();
                        header.xHoraSexta = objCalendarioModel.tHoraInicialSex.ToStringHoras() + " - " + objCalendarioModel.tHoraFinalSex.ToStringHoras();
                        header.xIntervalos = xIntervalo;
                    }
                }
                // banco de horas
                Funcionario_BancoHorasModel banco;
                foreach (var header in objPrintPonto.lHeaderFuncionario)
                {
                    banco = servicoFuncPonto.GetTotalBancoHorasMesAtual(header.idFuncionario, header.dtMes.ToDateTime());
                    if (banco != null)
                    {
                        header.iTotalDiasTrabalhados = banco.iDiasTrabalhados;
                        header.xHorasTrabalhadas = banco.tHorastrabalhadas.ToString();
                        header.xHorasAtrabalhar = banco.tHorasAtrabalhar.ToString();
                        header.xSaldoMes = (header.xHorasTrabalhadas.ToTimeSpan().Subtract(header.xHorasAtrabalhar.ToTimeSpan())).ToStringHoras();
                        header.xBancoHoras = banco.tBancoHoras.ToString();
                    }
                    header.idEmpresa = CompanyData.idEmpresa;
                    int iDaysMonth = System.DateTime.DaysInMonth(header.dtMes.ToDateTime().Year, header.dtMes.ToDateTime().Month);
                    ItemsPontoModel objPonto = null;
                    DateTime dtDia;
                    for (int i = 1; i <= iDaysMonth; i++)
                    {
                        dtDia = new DateTime(header.dtMes.ToDateTime().Year, header.dtMes.ToDateTime().Month, i);
                        List<EspelhoPontoModel> lPontos = servicoFuncPonto.GetHorasTrabalhadasDia(header.idFuncionario, dtDia);
                        objPonto = new ItemsPontoModel();
                        TimeSpan tTotalHorasTrabalhadas = new TimeSpan();
                        foreach (var ponto in lPontos)
                        {
                            objPonto.hRegistrado += string.Format("{0}-{1}{2}",
                                ponto.tEntrada.ToStringHoras(),
                                ponto.tSaida.ToStringHoras(),
                                Environment.NewLine);
                            tTotalHorasTrabalhadas = tTotalHorasTrabalhadas.Add(ponto.tTotal);
                        }
                        if (objPonto.hRegistrado == null)
                            objPonto.hRegistrado = " - - - ";
                        objPonto.idFuncionario = header.idFuncionario;
                        objPonto.data = dtDia.ToShortDateString() + " - " + dtDia.ToString("dddddddddd").ToUpper();
                        objPonto.hTrabalhada = (tTotalHorasTrabalhadas != new TimeSpan(0, 0, 0) ? tTotalHorasTrabalhadas.ToStringHoras() : " - - - ");
                        if (lPontos.Count() > 0)
                            objPonto.xOcorrencia = servicoFuncPonto.GetJustificativaPontoDia(header.idFuncionario, dtDia);
                        if (objPonto.xOcorrencia == "")
                            if (dtDia.ToString("dddddddddd").ToUpper().Contains("SABADO") || dtDia.ToString("dddddddddd").ToUpper().Contains("DOMINGO"))
                                objPonto.xOcorrencia = " DSR ";
                            else
                                objPonto.xOcorrencia = " - - - ";

                        header.itemsPonto.Add(objPonto);
                    }

                }

                string sFilePath = Pastas.Path_TempReport + "EspelhoPontoToPDF_user_{0}.xml";
                sFilePath = string.Format(sFilePath, UserData.idUser);

                try
                {
                    if (File.Exists(sFilePath))
                        File.Delete(sFilePath);
                    SerializeClassToXml.SerializeClasse<EspelhoPontoPrintModel>(objPrintPonto, sFilePath);
                    e.Result = sFilePath;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool PreviewReportCanExec()
        {
            return this.CanCarregaFormulario() && !this.objViewModel.bWorkerPrint.IsBusy;
        }

        public void PreviewReport()
        {
            this.objViewModel.bWorkerPrint.RunWorkerAsync();
        }


        public void CarragaFormulario()
        {
            if (this.objViewModel.bWorkerPesquisa.IsBusy == false)
                this.objViewModel.bWorkerPesquisa.RunWorkerAsync();
        }

        public bool CanCarregaFormulario()
        {
            bool bReturn = false;
            if (objViewModel.currentModel != null)
            {
                if (objViewModel.currentModel.idFuncionario != 0 && objViewModel.currentModel.data != null)
                {
                    bReturn = true;
                }
            }
            return bReturn;
        }
        public void ExecutePesquisa(object sender, DoWorkEventArgs e)
        {
            try
            {
                this.objViewModel.currentModel.objFuncBancoHoras = servicoFuncPonto.GetTotalBancoHorasMesAtual(objViewModel.currentModel.idFuncionario,
                 objViewModel.currentModel.data);

                // IGUAL A NULL É PORQUE MES AINDA NÃO FOI FECHADO.

                TimeSpan tsTotalHorasTrabalhadas = new TimeSpan();
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, (Action)(() =>
                    {
                        this.objViewModel.btnCarregar.Tag = "2";
                        DateTime data = (DateTime)objViewModel.currentModel.data;
                        int iDaysMonth = System.DateTime.DaysInMonth(data.Year, data.Month);

                        foreach (Control ctr in objViewModel.lControlsPonto)
                        {
                            ctr.Visibility = System.Windows.Visibility.Hidden;
                        }
                        DateTime dtSet;
                        for (int i = 1; i <= iDaysMonth; i++)
                        {
                            dtSet = new DateTime(data.Year, data.Month, i);

                            switch (i)
                            {
                                case 1: objViewModel.PrimeiroDia = dtSet.ToString("dddddd").ToUpper();
                                    break;
                                case 2: objViewModel.SegundoDia = dtSet.ToString("dddddd").ToUpper();
                                    break;
                                case 3: objViewModel.TerceiroDia = dtSet.ToString("dddddd").ToUpper();
                                    break;
                                case 4: objViewModel.QuartoDia = dtSet.ToString("dddddd").ToUpper();
                                    break;
                                case 5: objViewModel.QuintoDia = dtSet.ToString("dddddd").ToUpper();
                                    break;
                                case 6: objViewModel.SextoDia = dtSet.ToString("dddddd").ToUpper();
                                    break;
                                case 7: objViewModel.SetimoDia = dtSet.ToString("dddddd").ToUpper();
                                    break;
                            }

                            Control controle = objViewModel.lControlsPonto.FirstOrDefault(c => c.Name == ("d" + i.ToString()));
                            controle.SetPropertyValue("idFuncionario", objViewModel.currentModel.idFuncionario);
                            controle.SetPropertyValue("dtPonto", dtSet.ToShortDateString());
                            //controle.SetPropertyValue("bMesFechado", (objViewModel.tsBancoHorasFechado == null ? false : true));
                            controle.SetPropertyValue("bMesFechado", (this.objViewModel.currentModel.objFuncBancoHoras == null ? false : true));
                            Type tipo = controle.GetType();
                            MethodInfo met = tipo.GetMethod(name: "CarregaDados");
                            met.Invoke(controle, null);
                            controle.Visibility = System.Windows.Visibility.Visible;
                            tsTotalHorasTrabalhadas = tsTotalHorasTrabalhadas + ((TimeSpan)controle.GetPropertyValue("totalHoras"));
                        }
                    }));

                if (this.objViewModel.currentModel.objFuncBancoHoras == null)
                {
                    this.objViewModel.currentModel.objFuncBancoHoras = new Model.Models.Gerais.Funcionario_BancoHorasModel();
                    this.objViewModel.currentModel.objFuncBancoHoras.xMesAno = objViewModel.currentModel.data.ToString("MMyyyy").PadLeft(6, '0');
                    this.objViewModel.currentModel.objFuncBancoHoras.idFuncionario = objViewModel.currentModel.idFuncionario;
                    this.objViewModel.currentModel.objFuncBancoHoras.iDiasTrabalhados = servicoFuncPonto.GetTotalDiasTrabalhadosMes(objViewModel.currentModel.idFuncionario, objViewModel.currentModel.data);
                    this.objViewModel.currentModel.objFuncBancoHoras.tHorastrabalhadas = tsTotalHorasTrabalhadas.ToStringHoras();
                    this.objViewModel.currentModel.objFuncBancoHoras.tHorasAtrabalhar = servicoFuncPonto.GetHorasATrabalharMes(objViewModel.currentModel.idFuncionario, objViewModel.currentModel.data).ToStringHoras();
                    this.objViewModel.currentModel.objFuncBancoHoras.tSaldoTotalAnterior = servicoFuncPonto.GetTotalBancoHoras(objViewModel.currentModel.idFuncionario, objViewModel.currentModel.data).ToStringHoras();
                }
                this.objViewModel.currentModel.objFuncBancoHoras.tBancoHoras =
                       (
                           objViewModel.currentModel.objFuncBancoHoras.tHorastrabalhadas.ToTimeSpan()
                           .Subtract(
                               objViewModel.currentModel.objFuncBancoHoras.tHorasAtrabalhar.ToTimeSpan()
                                    )
                       ).ToStringHoras();
                this.objViewModel.currentModel.objFuncBancoHoras.tsSaldoAteMomento = objViewModel.currentModel.objFuncBancoHoras.tSaldoTotalAnterior.ToTimeSpan().Add(objViewModel.currentModel.objFuncBancoHoras.tBancoHoras.ToTimeSpan());

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public void ExecutePesquisaCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.objViewModel.viewModelComumCommands.SetFocusFirstControl();
        }
        public void ExecPesquisa()
        {
            this.objViewModel.pesquisarBaseCommand.Execute(null);
            this.objViewModel.currentModel.idFuncionario = objViewModel.currentID;
            //if (this.objViewModel.currentModel.idFuncionario != 0)
            //    this.CarragaFormulario();
            this.CleanRegistro();
        }

        private void SaveBancoHoras()
        {
            try
            {
                //Model.Models.Gerais.Funcionario_BancoHorasModel funcBancoHoras = new Model.Models.Gerais.Funcionario_BancoHorasModel();
                //funcBancoHoras.idFuncionario = objViewModel.currentModel.idFuncionario;

                //funcBancoHoras.xMesAno = objViewModel.currentModel.data.ToString("MMyyyy").PadLeft(6, '0');
                servicoFuncPonto.SaveBancoHoras(objViewModel.currentModel.objFuncBancoHoras);
                this.CarragaFormulario();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        bool CanSaveBancoHoras()
        {
            if (objViewModel.currentModel.objFuncBancoHoras != null && objViewModel.currentModel != null)
            {
                if (objViewModel.currentModel.objFuncBancoHoras.idFuncionarioBancoHoras == null)
                    return true;
            }
            return false;
        }

        private void ReabrirMes()
        {
            try
            {
                if (MessageBox.Show(messageBoxText: "Deseja reabrir o calendário?" + Environment.NewLine +
                    "Isso poderá mudar os valores do painél e os dados já salvos referente as totalizações no banco de dados serão perdidos.",
                    caption: "Reabrir?", button: MessageBoxButton.YesNo, icon: MessageBoxImage.Question)
                    == MessageBoxResult.Yes)
                {
                    servicoFuncPonto.DeleteBancoHorasMes(objViewModel.currentModel.idFuncionario,
                            objViewModel.currentModel.data);
                    this.CarragaFormulario();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private bool CanReabrirMes()
        {
            if (objViewModel.currentModel.objFuncBancoHoras != null && objViewModel.currentModel != null)
            {
                if (objViewModel.currentModel.objFuncBancoHoras.idFuncionarioBancoHoras != null)
                    return true;
            }
            return false;
        }

        public void NavegaData(object param)
        {

            if (param.ToString().ToUpper().Equals("NEXT"))
            {
                this.objViewModel.currentModel.data = this.objViewModel.currentModel.data.AddMonths(1);
            }
            else
            {
                this.objViewModel.currentModel.data = this.objViewModel.currentModel.data.AddMonths(-1);
            }
            //this.CarragaFormulario();
            CleanRegistro();

        }

        private void CleanRegistro()
        {
            this.objViewModel.currentModel.objFuncBancoHoras = new Funcionario_BancoHorasModel();
            Dispatcher.CurrentDispatcher.Invoke((Action)(() => { this.objViewModel.btnCarregar.Tag = "1"; })); // significa que o botão irá ficar vermelho, para alertar que precisa ser clicado.           
            int iDaysMonth = System.DateTime.DaysInMonth(this.objViewModel.currentModel.data.Year, this.objViewModel.currentModel.data.Month);
            for (int i = 1; i <= iDaysMonth; i++)
            {
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, (Action)(() =>
                {
                    Control controle = objViewModel.lControlsPonto.FirstOrDefault(c => c.Name == ("d" + i.ToString()));
                    controle.SetPropertyValue("idFuncionario", 0);
                    Type tipo = controle.GetType();
                    MethodInfo met = tipo.GetMethod(name: "CarregaDados");
                    met.Invoke(controle, null);
                }));
            }
        }
        private void Novo() { }

        public void Navegar(object ContentBotao)
        {
            try
            {
                if (this.objViewModel.bWorkerPesquisa.IsBusy == false)
                {
                    objViewModel.navegarBaseCommand.Execute(ContentBotao);
                    objViewModel.currentModel.idFuncionario = objViewModel.currentID;
                    //   this.CarragaFormulario();                                     
                    CleanRegistro();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool CanNavegar(object paramCanExec)
        {
            return objViewModel.navegarBaseCommand.CanExecute(paramCanExec);
        }




    }
}
