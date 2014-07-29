using HLP.Comum.ViewModel.ViewModel;
using HLP.Entries.Model.Models.GestaoDeMateriais;
using HLP.Entries.ViewModel.Commands.GestaoDeMateriais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HLP.Entries.ViewModel.ViewModels.GestaoDeMateriais
{
    public class LocalizacaoViewModel : viewModelComum<LocalizacaoModel>
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

        LocalizacaoCommands comm;
        public LocalizacaoViewModel()
        {
            this.comm = new LocalizacaoCommands(objViewModel: this);
        }
    }
}
