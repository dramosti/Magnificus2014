using HLP.Base.ClassesBases;
using HLP.Entries.Model.Models.RecursosHumanos;
using HLP.Entries.ViewModel.Commands.RecursosHumanos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HLP.Entries.ViewModel.ViewModels.RecursosHumanos
{
    public class SetorViewModel : ViewModelBase<SetorModel>
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

        
        public SetorViewModel()
        {
            SetorCommands comm = new SetorCommands(this);
        }
    }
}