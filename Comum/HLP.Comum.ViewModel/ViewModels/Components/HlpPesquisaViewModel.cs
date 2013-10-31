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
using HLP.Comum.Model.Repository.Interfaces.Components;
using HLP.Dependencies;
//using HLP.Dependencies;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;

namespace HLP.Comum.ViewModel.ViewModels.Components
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
        public IHlpPesquisaRapidaRepository iHlpPesquisaRapidaRepository { get; set; }
        private IKernel kernel = null;


        private PesquisaRapidaModel _pesquisaRapida;
        public PesquisaRapidaModel pesquisaRapida
        {
            get { return _pesquisaRapida; }
            set { _pesquisaRapida = value; this.NotifyPropertyChanged("pesquisaRapida"); }
        }

        private string _iValorPesquisa;

        public string iValorPesquisa
        {
            get { return _iValorPesquisa; }
            set
            {
                if (value.Equals(""))
                {
                    this.pesquisaRapida = new PesquisaRapidaModel();
                    _iValorPesquisa = value;
                    this.NotifyPropertyChanged("iValorPesquisa");
                }

                int iValida;
                if (int.TryParse(value, out iValida))
                {
                    if (value != _iValorPesquisa)
                    {


                        if (kernel == null)
                        {
                            kernel = new StandardKernel(new MagnificusDependenciesModule());
                            kernel.Settings.ActivationCacheDisabled = false;
                            kernel.Inject(this);
                        }
                        PesquisaRapidaModel objRet = iHlpPesquisaRapidaRepository.GetValorDisplay
                            (
                            _TableView: this.TableView,
                            _Items: this.Items,
                            _FieldPesquisa: this.FieldPesquisa,
                            _iValorPesquisa: Convert.ToInt32(value)
                            );

                        if (objRet != null)
                        {
                            this.pesquisaRapida = objRet;
                            _iValorPesquisa = value;
                            this.NotifyPropertyChanged("iValorPesquisa");
                        }

                    }
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
