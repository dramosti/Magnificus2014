using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            bw.DoWork += new DoWorkEventHandler(this.ExecPesquisa);
            if (param != null)
                if (param.ToString() != string.Empty)
                    bw.RunWorkerAsync(argument: param);
        }

        async void ExecPesquisa(object sender, DoWorkEventArgs e)
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

                DataSet retorno = await servicoPesquisaPadrao.GetDataAsync(sql.ToString(), false, "", true);
                _objViewModel.Result = retorno.Tables[0];
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
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(this.GetTableInformation_Background);
            if (param != null)
                if (param.ToString() != string.Empty)
                    bw.RunWorkerAsync(argument: param);
        }

        async void GetTableInformation_Background(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (servicoPesquisaPadrao == null)
                    servicoPesquisaPadrao = new HlpPesquisaPadraoService.IservicePesquisaPadraoClient();

                PesquisaPadraoModelContract[] lResult = await servicoPesquisaPadrao.GetTableInformationAsync(sViewName: e.Argument.ToString());

                var dados = (from c in lResult
                             select new PesquisaPadraoModel
                             {
                                 DATA_TYPE = c.DATA_TYPE,
                                 COLUMN_NAME = c.COLUMN_NAME
                             }).ToList<PesquisaPadraoModel>();

                _objViewModel.lFilers = new System.Collections.ObjectModel.ObservableCollection<PesquisaPadraoModel>(dados);
                              
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }









    }
}
