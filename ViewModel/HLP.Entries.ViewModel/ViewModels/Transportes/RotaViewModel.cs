using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HLP.Comum.ViewModel.ViewModels;
using HLP.Entries.Model.Models.Transportes;
using HLP.Entries.ViewModel.Commands.Transportes;

namespace HLP.Entries.ViewModel.ViewModels.Transportes
{
    public class RotaViewModel : ViewModelBase<RotaModel>
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

        public RotaViewModel()
        {
            commands = new RotaCommand(objViewModel: this);
        }

        RotaCommand commands;


    }
}
