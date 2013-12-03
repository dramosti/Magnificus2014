using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HLP.Comum.ViewModel.ViewModels;
using HLP.Entries.Model.Fiscal;
using HLP.Entries.ViewModel.Commands.Fiscal;

namespace HLP.Entries.ViewModel.ViewModels.Fiscal
{
    public class Tipo_documentoViewModel : ViewModelBase
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

        
        private Tipo_documentoModel _currentModel;

        public Tipo_documentoModel currentModel
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
