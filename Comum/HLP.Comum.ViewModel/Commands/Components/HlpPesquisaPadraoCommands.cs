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

namespace HLP.Comum.ViewModel.Commands.Components
{
    public class HlpPesquisaPadraoCommands
    {

        private HlpPesquisaPadraoViewModel _objViewModel;

        private HlpPesquisaPadraoService.IservicePesquisaPadraoClient servicoPesquisaPadrao;

        public HlpPesquisaPadraoCommands(HlpPesquisaPadraoViewModel objViewModel)
        {

            _objViewModel = objViewModel;
            CarregaInformationTable(_objViewModel.sView);

            _objViewModel.commandPesquisar = new RelayCommand(execute: paramExec => WorkerPesquisa(_objViewModel.sView),
                canExecute: paramCanExec => CanPesquisar());
            _objViewModel.commandLimpar = new RelayCommand(execute: paramExec => ExecLimpar(),
                canExecute: paramCanExec => true);


        }

        void WorkerPesquisa(string param)
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(this.bw_DoWorkExecPesquisa);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bw_RunWorkerCompleted);
            if (param != null)
                if (param.ToString() != string.Empty)
                {
                    bw.RunWorkerAsync(argument: param);
                }
        }
        async void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            await Application.Current.Dispatcher.BeginInvoke(
                    DispatcherPriority.Background, new Action(() => this._objViewModel.Result = (DataTable)e.Result));
        }
        void bw_DoWorkExecPesquisa(object sender, DoWorkEventArgs e)
        {
            try
            {

                StringBuilder sql = new StringBuilder();
                sql.Append("SELECT * FROM " + e.Argument.ToString());
                List<string> sExpression = new List<string>();

                if (_objViewModel.lFilers.Where(C => C.COLUMN_NAME == "idEmpresa").Count() > 0)
                {
                    sExpression.Add("(idEmpresa = " + CompanyData.idEmpresa + ")");
                    sExpression.Add("AND");
                }
                // NUNCA IRÁ FILTRAR OS NÃO ATIVOS, VERIFICAR DEPOIS A REGRA!!
                if (_objViewModel.lFilers.Where(C => C.COLUMN_NAME == "Ativo").Count() > 0)
                {
                    sExpression.Add("(Ativo = 1)");
                    sExpression.Add("AND");
                }

                foreach (PesquisaPadraoModel filtro in _objViewModel.lFilers)
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

                if (sExpression.Count() > 0)
                {
                    sql.Append(" WHERE ");

                    if (sExpression[sExpression.Count() - 1] == "AND" || sExpression[sExpression.Count() - 1] == "OR")
                    {
                        sExpression.RemoveAt(sExpression.Count() - 1);
                    }
                    foreach (string s in sExpression)
                    {
                        sql.Append(s + " ");
                    }
                }
                if (servicoPesquisaPadrao == null)
                    servicoPesquisaPadrao = new HlpPesquisaPadraoService.IservicePesquisaPadraoClient();

                DataSet retorno = servicoPesquisaPadrao.GetData(sql.ToString(), false, "", true);
                e.Result = retorno.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        bool CanPesquisar()
        {
            bool bReturn = true;
            if (_objViewModel.lFilers != null)
            {
                if (_objViewModel.lFilers.Where(c => c.bEnablePesquisa == false).Count() == 0)
                    bReturn = true;
                else
                {
                    bReturn = false;
                }
            }
            return bReturn;

        }


        void ExecLimpar()
        {
            this.CarregaInformationTable(_objViewModel.sView);
            if (_objViewModel.Result != null)
            {
                _objViewModel.Result.Rows.Clear();
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
                if (servicoPesquisaPadrao == null)
                    servicoPesquisaPadrao = new HlpPesquisaPadraoService.IservicePesquisaPadraoClient();

                HlpPesquisaPadraoService.PesquisaPadraoModelContract[] lResult = servicoPesquisaPadrao.GetTableInformation(sViewName: e.Argument.ToString());

                e.Result = (from c in lResult
                             select new PesquisaPadraoModel
                             {
                                 DATA_TYPE = c.DATA_TYPE,
                                 COLUMN_NAME = c.COLUMN_NAME
                             }).ToList<PesquisaPadraoModel>();               

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }









    }
}
