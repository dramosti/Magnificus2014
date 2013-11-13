using HLP.Comum.Resources.RecursosBases;
using HLP.Comum.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Forms;
using HLP.Comum.Model.Models;

namespace HLP.Comum.ViewModel.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public ICommand salvarBaseCommand { get; set; }
        public ICommand deletarBaseCommand { get; set; }
        public ICommand novoBaseCommand { get; set; }
        public ICommand alterarBaseCommand { get; set; }
        public ICommand cancelarBaseCommand { get; set; }
        public ICommand copyBaseCommand { get; set; }

        public ICommand pesquisarBaseCommand { get; set; }
        public ICommand navegarBaseCommand { get; set; }

        camposBaseDadosService.IcamposBaseDadosServiceClient servico = new camposBaseDadosService.IcamposBaseDadosServiceClient();
        public campoSqlModel[] lCampos;

        private string _sText = "0 de 0";
        public string sText
        {
            get { return _sText; }
            set { _sText = value; this.NotifyPropertyChanged("sText"); }

        }

        private MyObservableCollection<int> _navigatePesquisa;

        public MyObservableCollection<int> navigatePesquisa
        {
            get { return _navigatePesquisa; }
            set { _navigatePesquisa = value; this.NotifyPropertyChanged("navigatePesquisa"); }
        }


        private Visibility _visibilityNavegacao = Visibility.Collapsed;

        public Visibility visibilityNavegacao
        {
            get { return _visibilityNavegacao; }
            set { _visibilityNavegacao = value; this.NotifyPropertyChanged("visibilityNavegacao"); }
        }

        private int _currentID;
        public int currentID
        {
            get { return _currentID; }
            set
            {
                if ((value != _currentID) && (value != 0))
                {
                    _currentID = value;
                    //pesquisarBaseCommand.Execute(null);
                }
            }
        }

        private bool _bIsEnabled;
        public bool bIsEnabled
        {
            get
            {
                return this._bIsEnabled;
            }
            set
            {
                this._bIsEnabled = value;
                this.NotifyPropertyChanged(propertyName: "bIsEnabled");
            }
        }

        private string _NameView = string.Empty;

        public string NameView
        {
            get { return _NameView; }
            set { _NameView = value; }
        }


        public ViewModelBaseCommands viewModelBaseCommands;

        public ViewModelBase(string xTabela = "")
        {
            this.bIsEnabled = false;
            viewModelBaseCommands = new ViewModelBaseCommands(vViewModel: this);
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += bw_DoWork;

            if (xTabela != "")
                bw.RunWorkerAsync(argument: xTabela);

        }

        async void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                this.lCampos = await this.servico.getCamposNotNullAsync(xTabela: e.Argument.ToString());
            }
            catch (Exception)
            {
                throw;
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

        #region Validação
        public bool IsValid(DependencyObject obj)
        {
            // The dependency object is valid if it has no errors, 
            //and all of its children (that are dependency objects) are error-free.
            return !Validation.GetHasError(obj) &&
                LogicalTreeHelper.GetChildren(obj)
                .OfType<DependencyObject>()
                .All(child => IsValid(child));
        }
        #endregion
    }
}
