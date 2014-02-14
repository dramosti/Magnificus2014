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

        public void CalculaTotais(byte iStatus)
        {
            if (this.currentModel == null)
                return;

            if (iStatus == 5)
            {
                this.currentModel.orcamento_Total_Impostos.pDescontoTotal = this.currentModel.lOrcamento_Itens.Sum(i => i.pDesconto);
                this.currentModel.orcamento_Total_Impostos.vBaseCalculoCofinsTotal = this.currentModel.lOrcamento_Item_Impostos.Sum(i => i.COFINS_vBaseCalculo ?? 0);
                this.currentModel.orcamento_Total_Impostos.vBaseCalculoIcmsProprioTotal = this.currentModel.lOrcamento_Item_Impostos.Sum(i => i.ICMS_vBaseCalculoIcmsProprio ?? 0);
                this.currentModel.orcamento_Total_Impostos.vBaseCalculoICmsSubstituicaoTributariaTotal = this.currentModel.lOrcamento_Item_Impostos.Sum(i => i.ICMS_vBaseCalculoSubstituicaoTributaria ?? 0);
                this.currentModel.orcamento_Total_Impostos.vBaseCalculoIcmsTotal = this.currentModel.lOrcamento_Item_Impostos.Sum(i => i.ICMS_vBaseCalculo ?? 0);
                this.currentModel.orcamento_Total_Impostos.vBaseCalculoIpiTotal = this.currentModel.lOrcamento_Item_Impostos.Sum(i => i.IPI_vBaseCalculo ?? 0);
                this.currentModel.orcamento_Total_Impostos.vBaseCalculoIssTotal = this.currentModel.lOrcamento_Item_Impostos.Sum(i => i.ISS_vBaseCalculo ?? 0);
                this.currentModel.orcamento_Total_Impostos.vBaseCalculoPisTotal = this.currentModel.lOrcamento_Item_Impostos.Sum(i => i.PIS_vBaseCalculo ?? 0);
                this.currentModel.orcamento_Total_Impostos.vCOFINSTotal = this.currentModel.lOrcamento_Item_Impostos.Sum(i => i.COFINS_vCOFINS ?? 0);
                this.currentModel.orcamento_Total_Impostos.vDescontoSuframaTotal = this.currentModel.lOrcamento_Itens.Sum(i => i.vDescontoSuframa ?? 0);
                this.currentModel.orcamento_Total_Impostos.vDescontoTotal = this.currentModel.lOrcamento_Itens.Sum(i => i.vDesconto);
                this.currentModel.orcamento_Total_Impostos.vFreteTotal = this.currentModel.lOrcamento_Itens.Sum(i => i.vFreteItem);
                this.currentModel.orcamento_Total_Impostos.vIcmsProprioTotal = this.currentModel.lOrcamento_Item_Impostos.Sum(i => i.ICMS_vIcmsProprio ?? 0);
                this.currentModel.orcamento_Total_Impostos.vIcmsSubstituicaoTributariaTotal = this.currentModel.lOrcamento_Item_Impostos.Sum(i => i.ICMS_vSubstituicaoTributaria ?? 0);
                this.currentModel.orcamento_Total_Impostos.vICMSTotal = this.currentModel.lOrcamento_Item_Impostos.Sum(i => i.ICMS_vICMS ?? 0);
                this.currentModel.orcamento_Total_Impostos.vIITotal = this.currentModel.lOrcamento_Item_Impostos.Sum(i => i.ISS_vIss ?? 0);
                this.currentModel.orcamento_Total_Impostos.vIPITotal = this.currentModel.lOrcamento_Item_Impostos.Sum(i => i.IPI_vIPI ?? 0);
                this.currentModel.orcamento_Total_Impostos.vIssTotal = this.currentModel.lOrcamento_Item_Impostos.Sum(i => i.ISS_vIss ?? 0);
                this.currentModel.orcamento_Total_Impostos.vOutrasDespesasTotal = this.currentModel.lOrcamento_Itens.Sum(i => i.vOutrasDespesasItem);
                this.currentModel.orcamento_Total_Impostos.vPISTotal = this.currentModel.lOrcamento_Item_Impostos.Sum(i => i.PIS_vPIS ?? 0);
                this.currentModel.orcamento_Total_Impostos.vProdutoTotal = this.currentModel.lOrcamento_Itens.Where(i => !i.stServico).Sum(i => i.vTotalItem);
                this.currentModel.orcamento_Total_Impostos.vSeguroTotal = this.currentModel.lOrcamento_Itens.Where(i => i.stServico).Sum(i => i.vSegurosItem);
                this.currentModel.orcamento_Total_Impostos.vServicoTotal = this.currentModel.lOrcamento_Itens.Sum(i => i.vTotalItem);
                this.currentModel.orcamento_Total_Impostos.vTotal = this.currentModel.lOrcamento_Itens.Sum(i => i.vTotalItem);
            }
            else
            {
                this.currentModel.orcamento_Total_Impostos.pDescontoTotal =
                    this.currentModel.lOrcamento_Itens.Where(i => i.stOrcamentoItem == iStatus).Sum(i => i.pDesconto);
                this.currentModel.orcamento_Total_Impostos.vBaseCalculoCofinsTotal =
                    this.currentModel.lOrcamento_Item_Impostos.Where(i => i.stOrcamentoImpostos == iStatus).Sum(i => i.COFINS_vBaseCalculo ?? 0);
                this.currentModel.orcamento_Total_Impostos.vBaseCalculoIcmsProprioTotal =
                    this.currentModel.lOrcamento_Item_Impostos.Where(i => i.stOrcamentoImpostos == iStatus).Sum(i => i.ICMS_vBaseCalculoIcmsProprio ?? 0);
                this.currentModel.orcamento_Total_Impostos.vBaseCalculoICmsSubstituicaoTributariaTotal =
                    this.currentModel.lOrcamento_Item_Impostos.Where(i => i.stOrcamentoImpostos == iStatus).Sum(i => i.ICMS_vBaseCalculoSubstituicaoTributaria ?? 0);
                this.currentModel.orcamento_Total_Impostos.vBaseCalculoIcmsTotal =
                    this.currentModel.lOrcamento_Item_Impostos.Where(i => i.stOrcamentoImpostos == iStatus).Sum(i => i.ICMS_vBaseCalculo ?? 0);
                this.currentModel.orcamento_Total_Impostos.vBaseCalculoIpiTotal =
                    this.currentModel.lOrcamento_Item_Impostos.Where(i => i.stOrcamentoImpostos == iStatus).Sum(i => i.IPI_vBaseCalculo ?? 0);
                this.currentModel.orcamento_Total_Impostos.vBaseCalculoIssTotal =
                    this.currentModel.lOrcamento_Item_Impostos.Where(i => i.stOrcamentoImpostos == iStatus).Sum(i => i.ISS_vBaseCalculo ?? 0);
                this.currentModel.orcamento_Total_Impostos.vBaseCalculoPisTotal =
                    this.currentModel.lOrcamento_Item_Impostos.Where(i => i.stOrcamentoImpostos == iStatus).Sum(i => i.PIS_vBaseCalculo ?? 0);
                this.currentModel.orcamento_Total_Impostos.vCOFINSTotal =
                    this.currentModel.lOrcamento_Item_Impostos.Where(i => i.stOrcamentoImpostos == iStatus).Sum(i => i.COFINS_vCOFINS ?? 0);
                this.currentModel.orcamento_Total_Impostos.vDescontoSuframaTotal =
                    this.currentModel.lOrcamento_Itens.Where(i => i.stOrcamentoItem == iStatus).Sum(i => i.vDescontoSuframa ?? 0);
                this.currentModel.orcamento_Total_Impostos.vDescontoTotal =
                    this.currentModel.lOrcamento_Itens.Where(i => i.stOrcamentoItem == iStatus).Sum(i => i.vDesconto);
                this.currentModel.orcamento_Total_Impostos.vFreteTotal =
                    this.currentModel.lOrcamento_Itens.Where(i => i.stOrcamentoItem == iStatus).Sum(i => i.vFreteItem);
                this.currentModel.orcamento_Total_Impostos.vIcmsProprioTotal =
                    this.currentModel.lOrcamento_Item_Impostos.Where(i => i.stOrcamentoImpostos == iStatus).Sum(i => i.ICMS_vIcmsProprio ?? 0);
                this.currentModel.orcamento_Total_Impostos.vIcmsSubstituicaoTributariaTotal =
                    this.currentModel.lOrcamento_Item_Impostos.Where(i => i.stOrcamentoImpostos == iStatus).Sum(i => i.ICMS_vSubstituicaoTributaria ?? 0);
                this.currentModel.orcamento_Total_Impostos.vICMSTotal =
                    this.currentModel.lOrcamento_Item_Impostos.Where(i => i.stOrcamentoImpostos == iStatus).Sum(i => i.ICMS_vICMS ?? 0);
                this.currentModel.orcamento_Total_Impostos.vIITotal =
                    this.currentModel.lOrcamento_Item_Impostos.Where(i => i.stOrcamentoImpostos == iStatus).Sum(i => i.ISS_vIss ?? 0);
                this.currentModel.orcamento_Total_Impostos.vIPITotal =
                    this.currentModel.lOrcamento_Item_Impostos.Where(i => i.stOrcamentoImpostos == iStatus).Sum(i => i.IPI_vIPI ?? 0);
                this.currentModel.orcamento_Total_Impostos.vIssTotal =
                    this.currentModel.lOrcamento_Item_Impostos.Where(i => i.stOrcamentoImpostos == iStatus).Sum(i => i.ISS_vIss ?? 0);
                this.currentModel.orcamento_Total_Impostos.vOutrasDespesasTotal =
                    this.currentModel.lOrcamento_Itens.Where(i => i.stOrcamentoItem == iStatus).Sum(i => i.vOutrasDespesasItem);
                this.currentModel.orcamento_Total_Impostos.vPISTotal =
                    this.currentModel.lOrcamento_Item_Impostos.Where(i => i.stOrcamentoImpostos == iStatus).Sum(i => i.PIS_vPIS ?? 0);
                this.currentModel.orcamento_Total_Impostos.vProdutoTotal =
                    this.currentModel.lOrcamento_Itens.Where(i => i.stOrcamentoItem == iStatus).Where(i => !i.stServico).Sum(i => i.vTotalItem);
                this.currentModel.orcamento_Total_Impostos.vSeguroTotal =
                    this.currentModel.lOrcamento_Itens.Where(i => i.stOrcamentoItem == iStatus).Where(i => i.stServico).Sum(i => i.vSegurosItem);
                this.currentModel.orcamento_Total_Impostos.vServicoTotal =
                    this.currentModel.lOrcamento_Itens.Where(i => i.stOrcamentoItem == iStatus).Sum(i => i.vTotalItem);
                this.currentModel.orcamento_Total_Impostos.vTotal =
                    this.currentModel.lOrcamento_Itens.Where(i => i.stOrcamentoItem == iStatus).Sum(i => i.vTotalItem);
            }
        }

        public void ItensOrcamentoFilter(object sender, FilterEventArgs e)
        {
            if (e.Item.GetType() == typeof(Orcamento_ItemModel))
            {
                Orcamento_ItemModel i = e.Item as Orcamento_ItemModel;

                if (i != null)
                {
                    if (i.stOrcamentoItem == this.currentModel.iStatus || this.currentModel.iStatus == 5)
                    {
                        e.Accepted = true;
                    }
                    else
                    {
                        e.Accepted = false;
                    }
                }
            }
            else if (e.Item.GetType() == typeof(Orcamento_Item_ImpostosModel))
            {
                Orcamento_Item_ImpostosModel i = e.Item as Orcamento_Item_ImpostosModel;

                if (i != null)
                {
                    if (i.stOrcamentoImpostos == this.currentModel.iStatus || this.currentModel.iStatus == 5)
                    {
                        e.Accepted = true;
                    }
                    else
                    {
                        e.Accepted = false;
                    }
                }
            }
        }
    }
}
