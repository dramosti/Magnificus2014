using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Entries.Model.Models;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.ViewModel.Commands;
using HLP.Base.ClassesBases;
using System.Windows.Input;

namespace HLP.Entries.ViewModel.ViewModels
{
    public class UFViewModel : ViewModelBase<UFModel>
    {

        #region Icommands
        public ICommand commandSalvar { get; set; }
        public ICommand commandDeletar { get; set; }
        public ICommand commandNovo { get; set; }
        public ICommand commandAlterar { get; set; }
        public ICommand commandCancelar { get; set; }
        public ICommand commandCopiar { get; set; }
        public ICommand commandPesquisar { get; set; }
        public ICommand navegarCommand { get; set; }
        #endregion



        //public bool bIsEnable { get { return base.bIsEnabled; } }
        UFCommands objUFCommands;

        public UFViewModel()
            : base()
        {            
            objUFCommands = new UFCommands(objViewModel: this);
        }     

    }
}
