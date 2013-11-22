using HLP.Comum.ViewModel.ViewModels;
using HLP.Entries.Model.Models.Transportes;
using HLP.Entries.ViewModel.Commands.Transportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HLP.Entries.ViewModel.ViewModels.Transportes
{
    public class Condicao_entregaViewModel : ViewModelBase
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


        public Condicao_entregaViewModel()
        {
            Condicao_entregaCommands comm = new Condicao_entregaCommands(
            objViewModel: this);
        }

        private Condicoes_entregaModel _currentModel;

        public Condicoes_entregaModel currentModel
        {
            get { return _currentModel; }
            set
            {
                _currentModel = value;
                base.NotifyPropertyChanged(propertyName: "currentModel");
            }
        }

    }

}
