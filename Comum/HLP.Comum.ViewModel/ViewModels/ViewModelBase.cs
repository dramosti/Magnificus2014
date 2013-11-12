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


        public ICommand pesquisarBaseCommand { get; set; }
        public ICommand anteriorCommand { get; set; }
        public ICommand primeiroCommand { get; set; }
        public ICommand proximoCommand { get; set; }
        public ICommand ultimoCommand { get; set; }


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

        public ViewModelBase()
        {
            this.bIsEnabled = false;
            viewModelBaseCommands = new ViewModelBaseCommands(vViewModel: this);
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
