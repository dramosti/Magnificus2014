using HLP.Comum.ViewModel.ViewModels;
using HLP.Entries.Model.Models.Financeiro;
using HLP.Entries.ViewModel.Commands.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HLP.Entries.ViewModel.ViewModels.Financeiro
{
    public class Conta_BancariaViewModel : ViewModelBase
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


        public Conta_BancariaViewModel()
        {
            Conta_BancariaCommands comm = new Conta_BancariaCommands(objViewModel: this);
        }


        private Conta_bancariaModel _currentModel;

        public Conta_bancariaModel currentModel
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
