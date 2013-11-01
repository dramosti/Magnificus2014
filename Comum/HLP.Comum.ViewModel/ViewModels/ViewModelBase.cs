using HLP.Comum.Resources.RecursosBases;
using HLP.Comum.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HLP.Comum.ViewModel.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public ICommand salvarBase { get; set; }
        public ICommand deletarBase { get; set; }
        public ICommand novoBase { get; set; }
        public ICommand alterarBase { get; set; }
        public ICommand cancelarBase { get; set; }
        public ICommand pesquisarBase { get; set; }

        private bool _bIsEnabled;
        public bool bIsEnabled
        {
            get
            {
                return this._bIsEnabled;
            }
            set{
                this._bIsEnabled = value;
                this.NotifyPropertyChanged(propertyName: "bIsEnabled");
            }
        }

        public ViewModelBase()
        {
            this.bIsEnabled = false;
            ViewModelBaseCommands viewModel = new ViewModelBaseCommands(vViewModel: this);
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
