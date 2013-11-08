using HLP.Comum.ViewModel.ViewModels;
using HLP.Entries.Model.Models.Crm;
using HLP.Entries.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HLP.Entries.ViewModel.ViewModels
{
    public class DecisaoViewModel : ViewModelBase
    {
        #region Icommands
        public ICommand commandSalvar { get; set; }
        public ICommand commandDeletar { get; set; }
        public ICommand commandNovo { get; set; }
        public ICommand commandAlterar { get; set; }
        public ICommand commandCancelar { get; set; }
        public ICommand commandPesquisar { get; set; }
        #endregion
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

        DecisaoCommands objCommands;

        public DecisaoViewModel()
            : base()
        {
            objCommands = new DecisaoCommands(vViewModel: this);
        }

        private DecisaoModel _currentDecisao;

        public DecisaoModel currentDecisao
        {
            get { return _currentDecisao; }
            set
            {
                _currentDecisao = value;
                base.NotifyPropertyChanged(propertyName: "currentDecisao");
            }
        }
    }
}
