using HLP.Comum.Model.Models;
using HLP.Comum.ViewModel.ViewModels;
using HLP.Sales.Model.Models.Comercial;
using HLP.Sales.ViewModel.Commands.Comercio;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace HLP.Sales.ViewModel.ViewModel.Comercio
{
    public class OrcamentoViewModel : ViewModelBase<Orcamento_ideModel>
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
            this.Botoes = new StackPanel();
        }

        public bool bListaPrecoHabilitado
        {
            get
            {
                if (currentModel != null)
                    return !this.currentModel.bListaPrecoItemHabil;
                return false;
            }
        }

        private Orcamento_ItemModel _currentItem;

        public Orcamento_ItemModel currentItem
        {
            get { return _currentItem; }
            set
            {
                if (value != null)
                    _currentItem = value;
                base.NotifyPropertyChanged(propertyName: "currentItem");
            }
        }

        #region Métodos Públicos
        public void AtualizarTotais()
        {
            if (currentModel != null)
                this.currentModel.orcamento_Total_Impostos.CalcularTotais();
        }

        #endregion
    }
}
