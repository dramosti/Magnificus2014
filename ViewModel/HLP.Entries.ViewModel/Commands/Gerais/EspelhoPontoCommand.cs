using HLP.Comum.Resources.Util;
using HLP.Comum.ViewModel.Commands;
using HLP.Entries.ViewModel.Services.Gerais;
using HLP.Entries.ViewModel.ViewModels.Gerais;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using HLP.Comum.Infrastructure.Static;
using System.Reflection;
using System.Windows.Threading;
using System.Threading;
using System.Windows;

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
            this.objViewModel.commandPesquisar = new RelayCommand(execute: paramExec => this.ExecPesquisa(),
                       canExecute: paramCanExec => this.objViewModel.pesquisarBaseCommand.CanExecute(parameter: null));

            this.objViewModel.carregarCommand = new RelayCommand(execute: paramExec => this.CarragaFormulario(),
                canExecute: paramCan => this.CanCarregaFormulario());

            this.objViewModel.commandAlterar = new RelayCommand(execute: paramExec => this.Alterar(_panel: paramExec),
                    canExecute: paramCanExec => this.objViewModel.alterarBaseCommand.CanExecute(parameter: null));
        }


        public void CarragaFormulario()
        {
            try
            {
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
                                case 1: objViewModel.PrimeiroDia= dtSet.ToString("dddddd").ToUpper();
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
                            Type tipo = controle.GetType();
                            MethodInfo met = tipo.GetMethod(name: "CarregaDados");
                            met.Invoke(controle, null);
                            controle.Visibility = System.Windows.Visibility.Visible;
                        }
                    }));
                objViewModel.currentModel.iDiasTrabalhados = servico.GetTotalDiasTrabalhadosMes(objViewModel.currentModel.idFuncionario, objViewModel.currentModel.data);


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

        private void Alterar(object _panel)
        {
            this.objViewModel.alterarBaseCommand.Execute(parameter: _panel);
        }
        public void ExecPesquisa()
        {
            this.objViewModel.pesquisarBaseCommand.Execute(null);
            this.objViewModel.currentModel.idFuncionario = objViewModel.currentID;
        }
    }
}
