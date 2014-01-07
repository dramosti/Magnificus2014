using HLP.Comum.ViewModel.ViewModels;
using HLP.Sales.Model.Models.Comercial;
using HLP.Sales.ViewModel.Commands.Comercio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HLP.Sales.ViewModel.ViewModel.Comercio
{
    public class OrcamentoViewModel : ViewModelBase
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

        public OrcamentoViewModel()
        {
            OrcamentoCommands comm = new OrcamentoCommands(objViewModel: this);
        }


        private Orcamento_ideModel _currentModel;

        public Orcamento_ideModel currentModel
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
