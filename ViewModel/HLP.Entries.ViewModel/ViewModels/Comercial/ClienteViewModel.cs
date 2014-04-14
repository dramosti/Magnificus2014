using HLP.Base.ClassesBases;
using HLP.Entries.Model.Models.Comercial;
using HLP.Entries.ViewModel.Commands.Comercial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HLP.Entries.ViewModel.ViewModels.Comercial
{
    public class ClienteViewModel : ViewModelBase<Cliente_fornecedorModel>
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
        ClienteCommands comm;
        public ClienteViewModel()
        {
            comm = new ClienteCommands(
                objViewModel: this);
        }

        public bool RotaPossuiListaPrecoPai(int idRota)
        {
            return this.comm.RotaPossuiListaPrecoPai(idRota: idRota);
        }

    }
}
