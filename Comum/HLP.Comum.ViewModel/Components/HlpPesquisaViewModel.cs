using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Infrastructure;
using HLP.Comum.Infrastructure.Static;
using HLP.Comum.Model.Models;
using HLP.Comum.Model.Models.Components;
using HLP.Dependencies;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;

namespace HLP.Comum.ViewModel.Components
{
    public class HlpPesquisaViewModel : ModelBase
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }
        DataAccessor<PesquisaRapida> regAcessor = null;


        private PesquisaRapida _pesquisaRapida;
        public PesquisaRapida pesquisaRapida
        {
            get { return _pesquisaRapida; }
            set { _pesquisaRapida = value; base.NotifyPropertyChanged("pesquisaRapida"); }
        }

        private int? _iValorPesquisa;

        public int? iValorPesquisa
        {
            get { return _iValorPesquisa; }
            set
            {
                if (value != _iValorPesquisa)
                {
                    _iValorPesquisa = value;
                    base.NotifyPropertyChanged("iValorPesquisa");
                    this.GetValorDisplay();
                }
            }
        }

        private string FieldPesquisa { get; set; }
        private string TableView { get; set; }
        private IList Items { get; set; }

        public HlpPesquisaViewModel(string _TableView, string _FieldPesquisa, IList _Items)
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);

            pesquisaRapida = new PesquisaRapida();
            this.FieldPesquisa = _FieldPesquisa;
            this.TableView = _TableView;
            this.Items = _Items;
        }


        private void GetValorDisplay()
        {
            try
            {

                if (UndTrabalho.TableExistis(this.TableView))
                {
                    string sDisplay = string.Empty;
                    foreach (string col in (this.Items as List<string>))
                    {
                        if (UndTrabalho.ColunaExistis(this.TableView, col.ToString()))
                        {
                            if (sDisplay == string.Empty)
                                sDisplay += col;
                            else
                                sDisplay += " + ' - '," + col;
                        }
                    }

                    if (sDisplay != "")
                    {
                        if (regAcessor == null)
                        {
                            StringBuilder sQuery = new StringBuilder();
                            sQuery.Append("SELECT ");
                            sQuery.Append(this.iValorPesquisa + " as Valor ,");
                            sQuery.Append("CONCAT(" + sDisplay + ") as Display ");
                            sQuery.Append("FROM " + this.TableView);
                            sQuery.Append(" WHERE ");
                            sQuery.Append(this.FieldPesquisa + " = @FieldPesquisa ");
                            if (UndTrabalho.ColunaExistis(this.TableView, "idEmpresa"))
                                sQuery.Append(" AND idEmpresa = '" + CompanyData.idEmpresa + "' ");
                            if (UndTrabalho.ColunaExistis(this.TableView, "Ativo"))
                                sQuery.Append(" AND Ativo = 'S'");

                            regAcessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor(sQuery.ToString(),
                                new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("FieldPesquisa"),
                                MapBuilder<PesquisaRapida>.MapAllProperties().Build());
                        }

                        pesquisaRapida = regAcessor.Execute(this.iValorPesquisa).FirstOrDefault();
                    }
                    else
                    {
                        throw new Exception("Nenhuma coluna válida foi encontrada!");
                    }

                }
                else
                {
                    throw new Exception("Tabela/View não existente na base de dados!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
