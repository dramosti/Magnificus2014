using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using HLP.Comum.Infrastructure.Static;
using HLP.Comum.Model.Components;
using HLP.Comum.Model.Repository.Interfaces.Components;
//using HLP.Comum.ViewModel.HlpPesquisaPadraoService;
using HLP.Comum.ViewModel.ViewModels.Components;
using HLP.Dependencies;
using HLP.Comum.ViewModel.Services.Service;
using Ninject;
using System.Reflection;
using HLP.Comum.Modules;
using System.Windows.Controls;
using System.Windows.Input;

namespace HLP.Comum.ViewModel.Commands.Components
{
    public class HlpPesquisaPadraoCommands
    {

        private HlpPesquisaPadraoViewModel _objViewModel;

        public HlpPesqPadraoService service { get; set; }

        public HlpPesquisaPadraoCommands(HlpPesquisaPadraoViewModel objViewModel)
        {
            service = new HlpPesqPadraoService();
            _objViewModel = objViewModel;
            CarregaInformationTable(_objViewModel.sView);
            _objViewModel.commandPesquisar = new RelayCommand(execute: paramExec => WorkerPesquisa(paramExec),
                canExecute: paramCanExec => CanPesquisar());
            _objViewModel.commandLimpar = new RelayCommand(execute: paramExec => ExecLimpar(),
                canExecute: paramCanExec => true);
            _objViewModel.commandAdd = new RelayCommand(execute: parameExec => CriarExecute(parameExec),
                canExecute: paramCanExec => this.CriarCanExecute(paramCanExec));
            _objViewModel.commandPesquisaFiltrada = new RelayCommand(execute: paramExec => this.PesquisaFiltradaExecute(
                gdvResult: paramExec));
        }

        void CriarExecute(object nameWindow)
        {
            if (nameWindow != null)
            {
                object form = GerenciadorModulo.Instancia.CarregaForm(nome: nameWindow.ToString(),
                exibeForm: Modules.Interface.TipoExibeForm.Modal);

                Type t = form.GetType();
                ConstructorInfo constr = t.GetConstructor(Type.EmptyTypes);
                object inst = constr.Invoke(new object[] { });


                Window w = GerenciadorModulo.Instancia.CarregaForm(nome: "HlpPesquisaInsert",
                exibeForm: Modules.Interface.TipoExibeForm.Modal);

                (w.FindName(name: "ctrContent") as ContentControl).DataContext = (inst as Window).DataContext;
                (w.FindName(name: "ctrContent") as ContentControl).Content = (inst as Window).Content;

                Type tVm = (w.FindName(name: "ctrContent") as ContentControl).DataContext.GetType();
                object instVm = (w.FindName(name: "ctrContent") as ContentControl).DataContext;
                MethodInfo met = tVm.GetMethod(name: "get_commandNovo");
                ICommand comm = met.Invoke(instVm, new object[] { }) as ICommand;
                comm.Execute(parameter: (w.FindName(name: "ctrContent") as ContentControl).Content);
                if (w.ShowDialog() == true)
                {
                    this.bw_DoWorkExecPesquisa(sender: this, e: null);
                }
            }
        }

        bool CriarCanExecute(object nameWindow)
        {
            if (nameWindow == null)
                return false;

            return nameWindow.ToString() != "";
        }

        void PesquisaFiltradaExecute(object gdvResult)
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(this.bw_DoWorkExecPesquisa);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bw_RunWorkerCompleted);
            bw.RunWorkerAsync(gdvResult);
        }

        void WorkerPesquisa(object gdvResult)
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(this.bw_DoWorkExecPesquisa);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bw_RunWorkerCompleted);
            this._objViewModel.lFiltroAtivo = this._objViewModel.lFilers.ToList();
            bw.RunWorkerAsync(gdvResult);
        }
        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _objViewModel.bIniciaFocusFirstRow = true;
        }

        async void bw_DoWorkExecPesquisa(object sender, DoWorkEventArgs e)
        {

            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("SELECT * FROM " + _objViewModel.sView);
                List<string> sExpression = new List<string>();

                if (_objViewModel.lFiltroAtivo.Where(C => C.COLUMN_NAME == "idEmpresa").Count() > 0)
                {
                    sExpression.Add("(idEmpresa = " + CompanyData.idEmpresa + ")");
                    //sExpression.Add("AND");
                }
                // NUNCA IRÁ FILTRAR OS NÃO ATIVOS, VERIFICAR DEPOIS A REGRA!!
                //if (_objViewModel.lFilers.Where(C => C.COLUMN_NAME == "Ativo").Count() > 0)
                //{
                //    sExpression.Add("(Ativo = 1)");
                //    sExpression.Add("AND");
                //}

                foreach (PesquisaPadraoModel filtro in _objViewModel.lFiltroAtivo)
                {
                    if (filtro.Valor != null)
                    {
                        if (filtro.Valor != "")
                        {
                            string inner = filtro.EOU;
                            if (sExpression.Count() > 0)
                                sExpression.Add(inner == "E" ? "AND" : "OR");

                            string sTipo = filtro.DATA_TYPE;
                            string sCampo = filtro.COLUMN_NAME;
                            string sValor = filtro.Valor;
                            string sOperador = filtro.Operador;
                            sExpression.Add("(" + sCampo + " " + filtro.GetFilter() + ")");
                        }
                    }
                }

                if (this._objViewModel.campoSelecionado != ""
                    && this._objViewModel.campoSelecionado != null
                    )
                {
                    sExpression.Add(item:
                        string.Format(format: " ORDER BY {0} {1} ", arg0: this._objViewModel.campoSelecionado, arg1: this._objViewModel.stOrdenacao == (int)0 ?
                        "ASC" : "DESC"));
                }

                if (sExpression.Count() > 0)
                {
                    sql.Append(" WHERE ");

                    if (sExpression.Count == 1 && sExpression.FirstOrDefault().Contains(value: "ORDER BY"))
                        sql = sql.Replace(oldValue: " WHERE ", newValue: "");

                    if (sExpression[sExpression.Count() - 1] == "AND" || sExpression[sExpression.Count() - 1] == "OR")
                    {
                        sExpression.RemoveAt(sExpression.Count() - 1);
                    }
                    foreach (string s in sExpression)
                    {
                        sql.Append(s + " ");
                    }
                }


                DataSet retorno = service.GetData(sql.ToString(), false, "", true);
                await Application.Current.Dispatcher.BeginInvoke(
                     DispatcherPriority.Background, new Action(() => this._objViewModel.Result = retorno.Tables[0]));

                if (e != null)
                {
                    if (e.Argument != null)
                    {
                        Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, (Action)(() =>
                        {
                            System.Windows.Input.Keyboard.ClearFocus();
                            System.Windows.Input.Keyboard.Focus((e.Argument as System.Windows.Controls.DataGrid));
                        }));
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        bool CanPesquisar()
        {
            bool bReturn = false;
            if (_objViewModel.sView != null)
                if (_objViewModel.sView != "")
                    if (_objViewModel.lFilers != null)
                        if (_objViewModel.lFilers.Where(c => c.bEnablePesquisa == false).Count() == 0)
                            bReturn = true;
            return bReturn;
        }


        void ExecLimpar()
        {
            this.CarregaInformationTable(_objViewModel.sView);
            if (_objViewModel.Result != null)
            {
                _objViewModel.Result.Rows.Clear();
                _objViewModel.sTotalRegistro = "0";
            }
        }

        private void CarregaInformationTable(object param)
        {
            BackgroundWorker bwCarregaInfTable = new BackgroundWorker();
            bwCarregaInfTable.DoWork += new DoWorkEventHandler(this.GetTableInformation_Background);
            bwCarregaInfTable.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bwCarregaInfTable_RunWorkerCompleted);
            if (param != null)
                if (param.ToString() != string.Empty)
                    bwCarregaInfTable.RunWorkerAsync(argument: param);
        }

        async void bwCarregaInfTable_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            await Application.Current.Dispatcher.BeginInvoke(
                    DispatcherPriority.Background, new Action(() => this._objViewModel.lFilers = new ObservableCollection<PesquisaPadraoModel>(e.Result as List<PesquisaPadraoModel>)));
        }
        void GetTableInformation_Background(object sender, DoWorkEventArgs e)
        {
            try
            {

                //HlpPesquisaPadraoService.PesquisaPadraoModelContract[] lResult = servicoPesquisaPadrao.GetTableInformation(sViewName: e.Argument.ToString());

                //e.Result = (from c in lResult
                //            select new PesquisaPadraoModel
                //            {
                //                DATA_TYPE = c.DATA_TYPE,
                //                COLUMN_NAME = c.COLUMN_NAME
                //            }).ToList<PesquisaPadraoModel>();
                e.Result = service.GetTableInformation(sViewName: e.Argument.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }









    }
}
