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
using HLP.Comum.View.ClassesBases;

namespace HLP.Entries.ViewModel.ViewModels
{
    public class UFViewModel : ModelBase
    {
        #region Icommands
        public ICommand commandSalvar { get; set; }
        public ICommand commandDeletar { get; set; }
        public ICommand commandNovo { get; set; }
        public ICommand commandAlterar { get; set; }
        public ICommand commandCancelar { get; set; }
        #endregion

        public OperacaoCadastro currentOp { get; set; }

        UFCommands objUFCommand;

        public UFViewModel()
        {
            this.currentOp = OperacaoCadastro.livre;
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
