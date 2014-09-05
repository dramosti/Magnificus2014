using HLP.Base.ClassesBases;
using HLP.Entries.Model.Models.Comercial;
using HLP.Entries.ViewModel.Commands.Comercial;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using HLP.Components.Model.Models;
using HLP.Comum.ViewModel.ViewModel;

namespace HLP.Entries.ViewModel.ViewModels.Comercial
{
    public class Lista_PrecoViewModel : viewModelComum<Lista_Preco_PaiModel>
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
        public ICommand gerarListaCommand { get; set; }
        public ICommand AtribuicaoColetivaCommand { get; set; }
        public ICommand CarregarProdutosCommand { get; set; }
        public ICommand AtribuirPercentualCommand { get; set; }
        public ICommand AumVlrVendaCustoCommand { get; set; }
        public ICommand ConfAumVlrVendaCommand { get; set; }
        public ICommand CancAumVlrVendaCommand { get; set; }
        #endregion

        #region function

        private Func<int, bool, object> _getProduto;

        public Func<int, bool, object> getProduto
        {
            get { return _getProduto; }
            set
            {
                _getProduto = value;
                base.NotifyPropertyChanged(propertyName: "getProduto");
            }
        }

        private Func<int, bool, object> _getUnidadeMedida;

        public Func<int, bool, object> getUnidadeMedida
        {
            get { return _getUnidadeMedida; }
            set
            {
                _getUnidadeMedida = value;
                base.NotifyPropertyChanged(propertyName: "getUnidadeMedida");
            }
        }

        #endregion

        public BackgroundWorker bwHierarquia;
        public bool bTreeCarregada = true;
        Lista_PrecoCommands comm;

        public Lista_PrecoViewModel()
        {
            comm = new Lista_PrecoCommands(
                objViewModel: this);

            this.visAumentoVlr = Visibility.Collapsed;
            Button btnAtribuicaoColetiva = new Button();
            btnAtribuicaoColetiva.Content = "Atribuição Coletiva";
            btnAtribuicaoColetiva.Command = this.AtribuicaoColetivaCommand;
            btnAtribuicaoColetiva.CommandParameter = "WinAtribuicaoColetivaListaPreco";

            Button btnAumVlr = new Button();
            btnAumVlr.Content = "Reaj. Vlr. Vend/Cust";
            btnAumVlr.Command = this.AumVlrVendaCustoCommand;

            this.Botoes.Children.Add(element: btnAtribuicaoColetiva);
            this.Botoes.Children.Add(element: btnAumVlr);

            this.bCompGeral = this.bCompListaAut = this.bCompListaManual = false;

            this.getProduto = this.comm.GetProduto;
            this.getUnidadeMedida = this.comm.GetUnidadeMedida;
        }

        public bool PrecoCustoManual(int idProduto)
        {
            return comm.PrecoCustoManual(idProduto: idProduto);
        }

        public decimal GetPrecoCustoProduto(int idProduto)
        {
            return comm.GetPrecoCustoProduto(idProduto: idProduto);
        }

        #region Propriedades utilizadas na View

        private bool _bCompGeral;

        public bool bCompGeral
        {
            get { return _bCompGeral; }
            set
            {
                _bCompGeral = value;
                base.NotifyPropertyChanged(propertyName: "bCompGeral");
            }
        }

        private bool _bCompListaAut;

        public bool bCompListaAut
        {
            get { return _bCompListaAut; }
            set
            {
                _bCompListaAut = value;
                base.NotifyPropertyChanged(propertyName: "bCompListaAut");
            }
        }

        private bool _bCompListaManual;

        public bool bCompListaManual
        {
            get { return _bCompListaManual; }
            set
            {
                _bCompListaManual = value;
                base.NotifyPropertyChanged(propertyName: "bCompListaManual");
            }
        }

        private Visibility _visAumentoVlr;

        public Visibility visAumentoVlr
        {
            get { return _visAumentoVlr; }
            set
            {
                _visAumentoVlr = value;
                base.NotifyPropertyChanged(propertyName: "visAumentoVlr");
            }
        }

        private byte _byteIndex;

        public byte byteIndex
        {
            get { return _byteIndex; }
            set
            {
                _byteIndex = value;
                base.NotifyPropertyChanged(propertyName: "byteIndex");
            }
        }


        private decimal _dPorcAumento;

        public decimal dPorcAumento
        {
            get { return _dPorcAumento; }
            set
            {
                _dPorcAumento = value;

                foreach (Lista_precoModel item in this.currentModel.lLista_preco)
                {
                    if (this.byteIndex == 0)
                        item.vlrEsperado = item.vVenda * (1 + (value / 100));
                    else if (this.byteIndex == 1)
                        item.vlrEsperado = item.vCustoProduto * (1 + (value / 100));
                }

                base.NotifyPropertyChanged(propertyName: "dPorcAumento");
            }
        }


        private bool _bCheckAll;

        public bool bCheckAll
        {
            get { return _bCheckAll; }
            set
            {
                _bCheckAll = value;
                foreach (Lista_precoModel item in this.currentModel.lLista_preco)
                {
                    item.bChecked = value;
                }
                base.NotifyPropertyChanged(propertyName: "bCheckAll");
            }
        }


        private List<HlpButtonHierarquiaStruct> _lIdsHierarquia;

        public List<HlpButtonHierarquiaStruct> lIdsHierarquia
        {
            get { return _lIdsHierarquia; }
            set
            {
                _lIdsHierarquia = value;
                base.NotifyPropertyChanged(propertyName: "lIdsHierarquia");
            }
        }

        private object _hierarquiaListaPreco;

        public object hierarquiaListaPreco
        {
            get { return _hierarquiaListaPreco; }
            set
            {
                _hierarquiaListaPreco = value;
                base.NotifyPropertyChanged(propertyName: "hierarquiaListaPreco");
            }
        }

        private modelToTreeView _lObjHierarquia;

        public modelToTreeView lObjHierarquia
        {
            get { return _lObjHierarquia; }
            set { _lObjHierarquia = value; }
        }

        #endregion

        #region Métodos utilizados na View

        public bool ProdutoJaInserido(int idProduto)
        {
            if (this.currentModel == null)
                return false;

            if (this.currentModel.lLista_preco == null)
                return false;

            return this.currentModel.lLista_preco.Count(i => i.idProduto == idProduto) > 1;
        }

        public void MontaTreeView()
        {
            if (!bTreeCarregada)
            {
                this.comm.MontraTreeView();
            }
        }

        #endregion
    }
}
