using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HLP.Base.ClassesBases;
using HLP.Entries.Model.Fiscal;
using HLP.Entries.ViewModel.Commands.Fiscal;
using HLP.Comum.ViewModel.ViewModel;

namespace HLP.Entries.ViewModel.ViewModels.Fiscal
{
    public class Tipo_documentoViewModel : viewModelComum<Tipo_documentoModel>
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
        
        Tipo_documentoCommand objCommands;

        public Tipo_documentoViewModel()
        {
            this.objCommands = new Tipo_documentoCommand(this);
        }

    }
}
