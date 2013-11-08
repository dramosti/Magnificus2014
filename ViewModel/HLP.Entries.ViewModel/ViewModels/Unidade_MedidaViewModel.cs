using HLP.Comum.ViewModel.ViewModels;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HLP.Entries.ViewModel.ViewModels
{
    public class Unidade_MedidaViewModel : ViewModelBase
    {

        #region IcommandsBase
        public ICommand commandSalvarBase
        {
            get
            {
                return base.salvarBase;
            }
        }

        public ICommand commandDeletarBase
        {
            get
            {
                return base.deletarBase;
            }
        }
        public ICommand commandNovoBase
        {
            get
            {
                return base.novoBase;
            }
        }
        public ICommand commandAlterarBase
        {
            get
            {
                return base.alterarBase;
            }
        }
        public ICommand commandCancelarBase
        {
            get
            {
                return base.cancelarBase;
            }
        }

        public ICommand commandPesquisarBase
        {
            get
            {
                return base.pesquisarBase;
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

        Unidade_MedidaCommands objCommands;

        public Unidade_MedidaViewModel()
        {
            objCommands = new Unidade_MedidaCommands(this);
        }

        private Unidade_medidaModel _currentModel;

        public Unidade_medidaModel currentModel
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
