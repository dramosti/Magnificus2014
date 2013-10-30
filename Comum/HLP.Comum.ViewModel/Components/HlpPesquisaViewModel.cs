using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Infrastructure;
using HLP.Comum.Infrastructure.Static;
using HLP.Comum.Model.Components;
using HLP.Dependencies;
//using HLP.Dependencies;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;

namespace HLP.Comum.ViewModel.Components
{
    public class HlpPesquisaViewModel : INotifyPropertyChanged
    {
        public HlpPesquisaViewModel(string _FieldPesquisa, string _TableView, IList _Items)
        {
            this.FieldPesquisa = _FieldPesquisa;
            this.TableView = _TableView;
            this.Items = _Items;
        }

        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }
        DataAccessor<PesquisaRapida> regAcessor = null;

        private IKernel kernel = null;

        private PesquisaRapida _pesquisaRapida;
        public PesquisaRapida pesquisaRapida
        {
            get { return _pesquisaRapida; }
            set { _pesquisaRapida = value; this.NotifyPropertyChanged("pesquisaRapida"); }
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
                    this.NotifyPropertyChanged("iValorPesquisa");
                    this.GetValorDisplay();
                }
            }
        }

        private string _FieldPesquisa = "";

        public string FieldPesquisa
        {
            get { return _FieldPesquisa; }
            set { _FieldPesquisa = value; }
        }

        private string _TableView = "";
        public string TableView
        {
            get { return _TableView; }
            set { _TableView = value; }
        }

        private IList _Items = new List<string>();
        public IList Items
        {
            get { return _Items; }
            set { _Items = value; }
        }




        private void GetValorDisplay()
        {
            try
            {
                if (kernel == null)
                {
                    kernel = new StandardKernel(new MagnificusDependenciesModule());
                    kernel.Settings.ActivationCacheDisabled = false;
                    kernel.Inject(this);
                }

                if (UndTrabalho.TableExistis(this.TableView))
                {

                    if (regAcessor == null)
                    {
                        string sDisplay = string.Empty;
                        foreach (string col in (this.Items as List<string>))
                        {
                            if (UndTrabalho.ColunaExistis(this.TableView, col.ToString()))
                            {
                                if (sDisplay == string.Empty)
                                    sDisplay += string.Format("CAST({0} as varchar)", col);
                                else
                                    sDisplay += " + ' - '," + string.Format("CAST({0} as varchar)", col);
                            }
                        }

                        if (sDisplay == string.Empty)
                            throw new Exception("Nenhuma coluna válida foi encontrada!");

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
                    throw new Exception("Tabela/View não existente na base de dados!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region NotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion


    }
}
