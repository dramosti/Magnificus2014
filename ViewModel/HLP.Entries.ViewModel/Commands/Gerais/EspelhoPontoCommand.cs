﻿using HLP.Comum.Resources.Util;
using HLP.Entries.ViewModel.Services.Gerais;
using HLP.Entries.ViewModel.ViewModels.Gerais;
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

namespace HLP.Entries.ViewModel.Commands.Gerais
{
    public class EspelhoPontoCommand
    {
        FuncionarioPontoService servico;
        public EspelhoPontoViewModel objViewModel;


        public EspelhoPontoCommand(EspelhoPontoViewModel objViewModel)
        {
            this.objViewModel = objViewModel;
            servico = new FuncionarioPontoService();

            this.objViewModel.commandNovo = new RelayCommand(execute: paramExec => this.Novo(),
                  canExecute: paramCanExec => false);

            this.objViewModel.commandSalvar = new RelayCommand(execute: paramExec => this.Novo(),
                       canExecute: paramCanExec => false);

            this.objViewModel.commandCopiar = new RelayCommand(execute: paramExec => this.Novo(),
                       canExecute: paramCanExec => false);

            this.objViewModel.commandDeletar = new RelayCommand(execute: paramExec => this.Novo(),
                       canExecute: paramCanExec => false);

            this.objViewModel.commandCancelar = new RelayCommand(execute: paramExec => this.objViewModel.cancelarBaseCommand.Execute(null),
                       canExecute: paramCanExec => !this.objViewModel.commandAlterar.CanExecute(null));

            this.objViewModel.commandAlterar = new RelayCommand(execute: paramExec => this.objViewModel.alterarBaseCommand.Execute(parameter: paramExec),
                   canExecute: paramCanExec => false);

            this.objViewModel.commandPesquisar = new RelayCommand(execute: paramExec => this.ExecPesquisa(),
                       canExecute: paramCanExec => true);

            this.objViewModel.navegarCommand = new RelayCommand(execute: paramExec => this.Navegar(ContentBotao: paramExec),
                canExecute: paramCanExec => objViewModel.navegarBaseCommand.CanExecute(paramCanExec));


            this.objViewModel.carregarCommand = new RelayCommand(execute: paramExec => this.CarragaFormulario(),
                canExecute: paramCan => this.CanCarregaFormulario());

            this.objViewModel.commandFecharMes = new RelayCommand(execute: paramExec => this.SaveBancoHoras(),
                canExecute: paramCan => this.CanSaveBancoHoras());

            this.objViewModel.commandReabrirMes = new RelayCommand(execute: paramExec => this.ReabrirMes(),
              canExecute: paramCan => this.CanReabrirMes());

            this.objViewModel.commandNavegaData = new RelayCommand(execute: paramExec => this.NavegaData(param: paramExec),
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
        }

        public void CarragaFormulario()
        {
            try
            {
                this.objViewModel.tsBancoHorasFechado = servico.GetTotalBancoHorasMesAtual(objViewModel.currentModel.idFuncionario,
                 objViewModel.currentModel.data);

                this.objViewModel.currentModel.tsHorasTrabalhadas = new TimeSpan();
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
                            controle.SetPropertyValue("bMesFechado", (objViewModel.tsBancoHorasFechado == null ? false : true));
                            Type tipo = controle.GetType();
                            MethodInfo met = tipo.GetMethod(name: "CarregaDados");
                            met.Invoke(controle, null);
                            controle.Visibility = System.Windows.Visibility.Visible;
                            this.objViewModel.currentModel.tsHorasTrabalhadas = this.objViewModel.currentModel.tsHorasTrabalhadas + ((TimeSpan)controle.GetPropertyValue("totalHoras"));
                        }
                    }));
                objViewModel.currentModel.iDiasTrabalhados = servico.GetTotalDiasTrabalhadosMes(objViewModel.currentModel.idFuncionario, objViewModel.currentModel.data);
                objViewModel.currentModel.tsHorasAtrabalhar = servico.GetHorasATrabalharMes(objViewModel.currentModel.idFuncionario, objViewModel.currentModel.data);
                objViewModel.currentModel.tsHorasAcumuladasNoPeriodo = objViewModel.currentModel.tsHorasTrabalhadas.Subtract(objViewModel.currentModel.tsHorasAtrabalhar);
                objViewModel.currentModel.tsSaldoBancoHoras = servico.GetTotalBancoHoras(objViewModel.currentModel.idFuncionario, objViewModel.currentModel.data);
                objViewModel.currentModel.tsSaldoAteMomento = objViewModel.currentModel.tsSaldoBancoHoras.Add(objViewModel.currentModel.tsHorasAcumuladasNoPeriodo);


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

        public void ExecPesquisa()
        {
            this.objViewModel.pesquisarBaseCommand.Execute(null);
            this.objViewModel.currentModel.idFuncionario = objViewModel.currentID;
            this.CarragaFormulario();

        }

        private void SaveBancoHoras()
        {
            try
            {
                Model.Models.Gerais.Funcionario_BancoHorasModel funcBancoHoras = new Model.Models.Gerais.Funcionario_BancoHorasModel();
                funcBancoHoras.idFuncionario = objViewModel.currentModel.idFuncionario;
                funcBancoHoras.tBancoHoras = objViewModel.currentModel.tsSaldoAteMomento.ToStringHoras();
                funcBancoHoras.xMesAno = objViewModel.currentModel.data.ToString("MMyyyy").PadLeft(6, '0');
                servico.SaveBancoHoras(funcBancoHoras);
                this.CarragaFormulario();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        bool CanSaveBancoHoras()
        {
            if (objViewModel.tsBancoHorasFechado == null && objViewModel.currentModel != null)
            {
                return true;
            }
            return false;
        }

        private void ReabrirMes()
        {
            try
            {
                servico.DeleteBancoHorasMes(objViewModel.currentModel.idFuncionario,
                        objViewModel.currentModel.data);
                this.CarragaFormulario();
            }
            catch (Exception)
            {
                throw;
            }
        }
        private bool CanReabrirMes()
        {
            if (objViewModel.tsBancoHorasFechado != null)
            {
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
            this.CarragaFormulario();
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

    }
}
