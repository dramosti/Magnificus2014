using HLP.Comum.Resources.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Reflection;
using System.Windows.Threading;
using System.Threading;
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

namespace HLP.Entries.ViewModel.Commands.Gerais
{
    public class EspelhoPontoCommand
    {
        FuncionarioPontoService servicoFuncPonto;
        FuncionarioService servicoFuncionario;
        public EspelhoPontoViewModel objViewModel;
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

            this.objViewModel.commandImprimir = new RelayCommand(execute: paramExec => this.PrevirewReport(),
               canExecute: paramCan => this.CanCarregaFormulario());


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

            this.objViewModel.bWorkerPesquisa.DoWork += new DoWorkEventHandler(this.ExecutePesquisa);

        }


        public void CarragaFormulario() 
        {
            this.objViewModel.bWorkerPesquisa.RunWorkerAsync();
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

        public bool CanNavegar(object paramCanExec) 
        {
            if (this.objViewModel.bWorkerPesquisa.IsBusy)
                return false;

            return objViewModel.navegarBaseCommand.CanExecute(paramCanExec);

        }

        public void ExecPesquisa()
        {
            this.objViewModel.pesquisarBaseCommand.Execute(null);
            this.objViewModel.currentModel.idFuncionario = objViewModel.currentID;
            if (this.objViewModel.currentModel.idFuncionario != 0)
                this.CarragaFormulario();

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
        }

        private void Novo() { }

        public void Navegar(object ContentBotao)
        {
            try
            {
                objViewModel.navegarBaseCommand.Execute(ContentBotao);
                objViewModel.currentModel.idFuncionario = objViewModel.currentID;
                this.CarragaFormulario();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void PrevirewReport()
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
                objHeader.xNomeFuncionario = objFunc.xNome;
                objHeader.xCodigoAlternativo = objFunc.xCodigoAlternativo;
                objHeader.xCpf = objFunc.xCpf;
                objHeader.idCalendario = objFunc.idCalendario;
                objPrintPonto.lHeaderFuncionario.Add(objHeader);
            }



            List<KeyValuePair<int, string>> lHorariosPrincipais = new List<KeyValuePair<int, string>>();
            foreach (int item in objPrintPonto.lHeaderFuncionario.Select(c => c.idCalendario).Distinct())
            {

            }



            //1 - GetHorasTrabalhadasDia(int idFuncionario, DateTime dRelogioPonto) // trazer horarios do dia
            //1-1 - GetHorasTrabalhadasDia
            //1-2 - GetHorasAtrabalharDia


            Window winReport = GerenciadorModulo.Instancia.CarregaForm("WinPreviewReport", Base.InterfacesBases.TipoExibeForm.Modal);
            winReport.ShowDialog();
        }

    }
}
