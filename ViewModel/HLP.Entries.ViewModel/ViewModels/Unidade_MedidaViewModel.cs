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


        #region Icommands
        public ICommand commandSalvar { get; set; }
        public ICommand commandDeletar { get; set; }
        public ICommand commandNovo { get; set; }
        public ICommand commandAlterar { get; set; }
        public ICommand commandCancelar { get; set; }
        public ICommand commandPesquisar { get; set; }
        public ICommand commandCopiar { get; set; }
        public ICommand navegarCommand { get; set; }
        #endregion

        Unidade_MedidaCommands objCommands;

        public Unidade_MedidaViewModel()
            : base(xTabela: "Unidade_medida")
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
