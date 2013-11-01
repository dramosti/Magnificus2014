using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HLP.Comum.Model.Models;
using HLP.Entries.Model.Models;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.ViewModel.Commands;
using HLP.Comum.ViewModel.ViewModels;

namespace HLP.Entries.ViewModel.ViewModels
{
    public class UFViewModel : ViewModelBase
    {
        #region Icommands
        public ICommand commandSalvar { get; set; }
        public ICommand commandDeletar { get; set; }
        public ICommand commandNovo { get; set; }
        public ICommand commandAlterar { get; set; }
        public ICommand commandCancelar { get; set; }
        public ICommand commandPesquisar { get; set; }
        #endregion


        #region IcommandsBase
        public ICommand commandSalvarBase
        {
            get
            {
                return base.salvarBase;
            }
        }

        public ICommand commandDeletarBase
        {
            get
            {
                return base.deletarBase;
            }
        }
        public ICommand commandNovoBase
        {
            get
            {
                return base.novoBase;
            }
        }
        public ICommand commandAlterarBase
        {
            get
            {
                return base.alterarBase;
            }
        }
        public ICommand commandCancelarBase
        {
            get
            {
                return base.cancelarBase;
            }
        }

        public ICommand commandPesquisarBase
        {
            get
            {
                return base.pesquisarBase;
            }
        }
        #endregion


        //public bool bIsEnable { get { return base.bIsEnabled; } }
        UFCommands objUFCommand;

        public UFViewModel()
            : base()
        {
            objUFCommand = new UFCommands(objViewModel: this);
        }

        private UFModel _currentUF;

        public UFModel currentUF
        {
            get
            {
                return this._currentUF;
            }
            set
            {
                this._currentUF = value;
                base.NotifyPropertyChanged("currentUF");
            }
        }




    }
}
