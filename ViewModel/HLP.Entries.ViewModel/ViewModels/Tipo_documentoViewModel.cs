using HLP.Comum.ViewModel.ViewModels;
using HLP.Entries.Model.Fiscal;
using HLP.Entries.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HLP.Entries.ViewModel.ViewModels
{
    public class Tipo_documentoViewModel : ViewModelBase
    {

        #region IcommandsBase
        public ICommand commandSalvarBase
        {
            get
            {
                return base.salvarBaseCommand;
            }
        }

        public ICommand commandDeletarBase
        {
            get
            {
                return base.deletarBaseCommand;
            }
        }
        public ICommand commandNovoBase
        {
            get
            {
                return base.novoBaseCommand;
            }
        }
        public ICommand commandAlterarBase
        {
            get
            {
                return base.alterarBaseCommand;
            }
        }
        public ICommand commandCancelarBase
        {
            get
            {
                return base.cancelarBaseCommand;
            }
        }

        public ICommand commandPesquisarBase
        {
            get
            {
                return base.pesquisarBaseCommand;
            }
        }
        #endregion

        #region Icommands
        public ICommand commandSalvar { get; set; }
        public ICommand commandDeletar { get; set; }
        public ICommand commandNovo { get; set; }
        public ICommand commandAlterar { get; set; }
        public ICommand commandCancelar { get; set; }
        public ICommand commandPesquisar { get; set; }
        #endregion

        Tipo_documentoCommands objCommands;

        public Tipo_documentoViewModel()
        {
            this.objCommands = new Tipo_documentoCommands(vViewModel: this);
        }

        private Tipo_documentoModel _currentTipo_documento;

        public Tipo_documentoModel currentTipo_documento
        {
            get { return _currentTipo_documento; }
            set
            {
                _currentTipo_documento = value;
                base.NotifyPropertyChanged(propertyName: "currentTipo_documento");
            }
        }
    }
}
