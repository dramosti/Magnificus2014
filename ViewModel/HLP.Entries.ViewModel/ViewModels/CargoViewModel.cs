using HLP.Comum.ViewModel.ViewModels;
using HLP.Entries.Model.Models.RecursosHumanos;
using HLP.Entries.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HLP.Entries.ViewModel.ViewModels
{
    public class CargoViewModel : ViewModelBase
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
        #endregion

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

        CargoModel _currentModel;

        public CargoModel currentModel
        {
            get { return _currentModel; }
            set
            {
                _currentModel = value;
                base.NotifyPropertyChanged(propertyName: "currentModel");

            }
        }

        public CargoViewModel()
            : base(xTabela: "Cargo")
        {
            CargoCommands comm = new CargoCommands(objViewModel: this);
        }
    }
}
