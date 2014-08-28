using HLP.Base.ClassesBases;
using HLP.Base.Static;
using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HLP.Entries.Model.Models.Comercial
{
    public partial class Lista_Preco_PaiModel : modelComum
    {

        public Lista_Preco_PaiModel()
            : base(xTabela: "Lista_Preco_Pai")
        {
            this.lLista_preco = new ObservableCollectionBaseCadastros<Lista_precoModel>();
            this.lLista_preco.CollectionChanged += this.lLista_preco_CollectionChanged;

        }

        public void lLista_preco_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    {
                        foreach (Lista_precoModel it in e.NewItems)
                        {
                            it.stMarkupLista = this.stMarkup;
                        }
                    }
                    break;
            }
        }

        private int _idEmpresa;
        [ParameterOrder(Order = 1)]
        public int idEmpresa
        {
            get { return _idEmpresa; }
            set
            {
                _idEmpresa = value;
                base.NotifyPropertyChanged(propertyName: "idEmpresa");
            }
        }
        private int? _idListaPrecoPai;
        [ParameterOrder(Order = 2), PrimaryKey(isPrimary = true)]        
        public int? idListaPrecoPai
        {
            get { return _idListaPrecoPai; }
            set
            {
                _idListaPrecoPai = value;
                base.NotifyPropertyChanged(propertyName: "idListaPrecoPai");
            }
        }
        private string _xLista;
        [ParameterOrder(Order = 3)]
        public string xLista
        {
            get { return _xLista; }
            set
            {
                _xLista = value;
                base.NotifyPropertyChanged(propertyName: "xLista");
            }
        }
        private byte _stContrato;
        [ParameterOrder(Order = 4)]
        public byte stContrato
        {
            get { return _stContrato; }
            set
            {
                _stContrato = value;
                base.NotifyPropertyChanged(propertyName: "stContrato");
            }
        }
        private string _xNrContrato;
        [ParameterOrder(Order = 5)]
        public string xNrContrato
        {
            get { return _xNrContrato; }
            set
            {
                _xNrContrato = value;
                base.NotifyPropertyChanged(propertyName: "xNrContrato");
            }
        }
        private DateTime? _dValidadeContrato;
        [ParameterOrder(Order = 6)]
        public DateTime? dValidadeContrato
        {
            get { return _dValidadeContrato; }
            set
            {
                _dValidadeContrato = value;
                base.NotifyPropertyChanged(propertyName: "dValidadeContrato");
            }
        }
        private bool _Ativo;
        [ParameterOrder(Order = 7)]
        public bool Ativo
        {
            get { return _Ativo; }
            set
            {
                _Ativo = value;
                base.NotifyPropertyChanged(propertyName: "Ativo");
            }
        }
        private DateTime _dListaPreco;
        [ParameterOrder(Order = 8)]
        public DateTime dListaPreco
        {
            get { return _dListaPreco; }
            set
            {
                _dListaPreco = value;
                base.NotifyPropertyChanged(propertyName: "dListaPreco");
            }
        }
        private byte _stAtualizacao;
        [ParameterOrder(Order = 9)]
        public byte stAtualizacao
        {
            get { return _stAtualizacao; }
            set
            {
                _stAtualizacao = value;

                this.idListaPrecoOrigem = this.idListaPrecoOrigem;

                base.NotifyPropertyChanged(propertyName: "stAtualizacao");
            }
        }
        private decimal? _nDiasSemAtualicao;
        [ParameterOrder(Order = 10)]
        public decimal? nDiasSemAtualicao
        {
            get { return _nDiasSemAtualicao; }
            set
            {
                _nDiasSemAtualicao = value;
                base.NotifyPropertyChanged(propertyName: "nDiasSemAtualicao");
            }
        }
        private decimal? _pDescontoMaximo;
        [ParameterOrder(Order = 11)]
        public decimal? pDescontoMaximo
        {
            get { return _pDescontoMaximo; }
            set
            {
                _pDescontoMaximo = value;
                base.NotifyPropertyChanged(propertyName: "pDescontoMaximo");
            }
        }
        private decimal? _pAcressimoMaximo;
        [ParameterOrder(Order = 12)]
        public decimal? pAcressimoMaximo
        {
            get { return _pAcressimoMaximo; }
            set
            {
                _pAcressimoMaximo = value;
                base.NotifyPropertyChanged(propertyName: "pAcressimoMaximo");
            }
        }
        private string _xCodigoListaPreco;
        [ParameterOrder(Order = 13)]
        public string xCodigoListaPreco
        {
            get { return _xCodigoListaPreco; }
            set
            {
                _xCodigoListaPreco = value;
                base.NotifyPropertyChanged(propertyName: "xCodigoListaPreco");
            }
        }
        private decimal? _pPercentual;
        [ParameterOrder(Order = 14)]
        public decimal? pPercentual
        {
            get { return _pPercentual; }
            set
            {
                _pPercentual = value;
                base.NotifyPropertyChanged(propertyName: "pPercentual");
            }
        }
        private int? _idListaPrecoOrigem;
        [ParameterOrder(Order = 15)]
        public int? idListaPrecoOrigem
        {
            get { return _idListaPrecoOrigem; }
            set
            {
                _idListaPrecoOrigem = value;
                base.NotifyPropertyChanged(propertyName: "idListaPrecoOrigem");
            }
        }
        private bool _stPreferencial;
        [ParameterOrder(Order = 16)]
        public bool stPreferencial
        {
            get { return _stPreferencial; }
            set
            {
                _stPreferencial = value;
                base.NotifyPropertyChanged(propertyName: "stPreferencial");
            }
        }

        private byte? _stMarkup;
        [ParameterOrder(Order = 17)]
        public byte? stMarkup
        {
            get { return _stMarkup; }
            set
            {
                _stMarkup = value;

                base.NotifyPropertyChanged(propertyName: "stMarkup");

                if (this.lLista_preco != null)
                    foreach (Lista_precoModel it in this.lLista_preco)
                    {
                        it.stMarkupLista = value;
                    }
            }
        }

        private ObservableCollectionBaseCadastros<Lista_precoModel> _lLista_preco;

        public ObservableCollectionBaseCadastros<Lista_precoModel> lLista_preco
        {
            get { return _lLista_preco; }
            set
            {
                _lLista_preco = value;
                base.NotifyPropertyChanged(propertyName: "lLista_preco");
            }
        }
    }

    public partial class Lista_precoModel : modelComum
    {
        private ProdutoModel _objProduto;

        public ProdutoModel objProduto
        {
            get { return _objProduto; }
            set
            {
                _objProduto = value;

                if (value != null)
                {
                    this.selectedIdUnidadeVenda = value.idUnidadeMedidaVendas;
                    this.selectedIdFamiliaProduto = value.idFamiliaProduto;
                }
            }
        }


        public Lista_precoModel()
            : base(xTabela: "Lista_preco")
        {

        }

        public void CalculaMarkup(Lista_precoModel objItemLista)
        {
            decimal vCustoTotal = objItemLista._vCustoProduto + (objItemLista._vVenda * ((objItemLista._pComissao / 100) ?? 0))
                    + (objItemLista._vVenda * ((objItemLista._pOutros / 100) ?? 0));
            switch (this.stMarkupLista)
            {
                case 0://Margem Bruta
                    {
                        if (objItemLista._vVenda > 0)
                            objItemLista.pMarkup = (objItemLista._vVenda - vCustoTotal) / objItemLista._vVenda;
                    } break;
                case 1://Markup
                    {
                        if (vCustoTotal > 0)
                            objItemLista.pMarkup = objItemLista._vVenda / vCustoTotal;
                    } break;
            }
            base.NotifyPropertyChanged(propertyName: "pMarkup");
        }

        #region Propriedades não mapeadas na DataGrid


        private int? _selectedIdUnidadeVenda;

        public int? selectedIdUnidadeVenda
        {
            get { return _selectedIdUnidadeVenda; }
            set
            {
                _selectedIdUnidadeVenda = value;
                base.NotifyPropertyChanged(propertyName: "selectedIdUnidadeVenda");
            }
        }

        private int? _selectedIdFamiliaProduto;

        public int? selectedIdFamiliaProduto
        {
            get { return _selectedIdFamiliaProduto; }
            set
            {
                _selectedIdFamiliaProduto = value;
                base.NotifyPropertyChanged(propertyName: "selectedIdFamiliaProduto");
            }
        }

        #endregion

        private int? _idListaPreco;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idListaPreco
        {
            get { return _idListaPreco; }
            set
            {
                _idListaPreco = value;
                base.NotifyPropertyChanged(propertyName: "idListaPreco");

            }
        }
        private int _idProduto;
        [ParameterOrder(Order = 2)]
        public int idProduto
        {
            get { return _idProduto; }
            set
            {
                _idProduto = value;
                base.NotifyPropertyChanged(propertyName: "idProduto");
            }
        }
        private decimal _vCustoProduto;
        [ParameterOrder(Order = 3)]
        public decimal vCustoProduto
        {
            get { return _vCustoProduto; }
            set
            {
                _vCustoProduto = value;

                if (this._vCustoProduto > 0)
                    this._pLucro = ((this._vVenda - this._vCustoProduto) / this._vCustoProduto) * 100;
                else if (this._vCustoProduto == 0 && this._vVenda > 0)
                    this._pLucro = 100;
                this.CalculaMarkup(objItemLista: this);
                base.NotifyPropertyChanged(propertyName: "pLucro");
                base.NotifyPropertyChanged(propertyName: "vCustoProduto");
                this.CalculaMarkup(objItemLista: this);
            }
        }
        private decimal _pLucro;
        [ParameterOrder(Order = 4)]
        public decimal pLucro
        {
            get { return _pLucro; }
            set
            {
                _pLucro = value;
                this._vVenda = (1 + (this._pLucro / 100)) * this._vCustoProduto;
                base.NotifyPropertyChanged(propertyName: "pLucro");
                base.NotifyPropertyChanged(propertyName: "vVenda");
                this.CalculaMarkup(objItemLista: this);
            }
        }
        private decimal _vVenda;
        [ParameterOrder(Order = 5)]
        public decimal vVenda
        {
            get { return _vVenda; }
            set
            {
                _vVenda = value;
                if (this._vCustoProduto > 0)
                    this._pLucro = ((this._vVenda - this._vCustoProduto) / this._vCustoProduto) * 100;
                else if (this._vCustoProduto == 0 && this._vVenda > 0)
                    this._pLucro = 100;

                this.CalculaMarkup(objItemLista: this);
                base.NotifyPropertyChanged(propertyName: "vVenda");
                base.NotifyPropertyChanged(propertyName: "pLucro");
            }
        }
        private decimal? _pDescontoMaximo;
        [ParameterOrder(Order = 6)]
        public decimal? pDescontoMaximo
        {
            get { return _pDescontoMaximo; }
            set
            {
                _pDescontoMaximo = value;
                base.NotifyPropertyChanged(propertyName: "pDescontoMaximo");
            }
        }
        private decimal? _pAcrescimoMaximo;
        [ParameterOrder(Order = 7)]
        public decimal? pAcrescimoMaximo
        {
            get { return _pAcrescimoMaximo; }
            set
            {
                _pAcrescimoMaximo = value;
                base.NotifyPropertyChanged(propertyName: "pAcrescimoMaximo");
            }
        }
        private decimal? _pComissaoAvista;
        [ParameterOrder(Order = 8)]
        public decimal? pComissaoAvista
        {
            get { return _pComissaoAvista; }
            set
            {
                _pComissaoAvista = value;
                base.NotifyPropertyChanged(propertyName: "pComissaoAvista");
            }
        }
        private decimal? _pComissaoAprazo;
        [ParameterOrder(Order = 9)]
        public decimal? pComissaoAprazo
        {
            get { return _pComissaoAprazo; }
            set
            {
                _pComissaoAprazo = value;
                base.NotifyPropertyChanged(propertyName: "pComissaoAprazo");
            }
        }
        private int? _idListaPrecoPai;
        [ParameterOrder(Order = 10), SkipValidation(skip: true)]
        public int? idListaPrecoPai
        {
            get { return _idListaPrecoPai; }
            set
            {
                _idListaPrecoPai = value;
                base.NotifyPropertyChanged(propertyName: "idListaPrecoPai");
            }
        }
        private decimal? _pDesconto;
        [ParameterOrder(Order = 11)]
        public decimal? pDesconto
        {
            get { return _pDesconto; }
            set
            {
                _pDesconto = value;
                base.NotifyPropertyChanged(propertyName: "pDesconto");
            }
        }
        private decimal? _pComissao;
        [ParameterOrder(Order = 12)]
        public decimal? pComissao
        {
            get { return _pComissao; }
            set
            {
                _pComissao = value;
                base.NotifyPropertyChanged(propertyName: "pComissao");
                this.CalculaMarkup(objItemLista: this);
            }
        }
        private decimal? _pOutros;
        [ParameterOrder(Order = 13)]
        public decimal? pOutros
        {
            get { return _pOutros; }
            set
            {
                _pOutros = value;
                base.NotifyPropertyChanged(propertyName: "pOutros");
                this.CalculaMarkup(objItemLista: this);
            }
        }
        private DateTime _dAlteracaoCusto;
        [ParameterOrder(Order = 14)]
        public DateTime dAlteracaoCusto
        {
            get { return _dAlteracaoCusto; }
            set
            {
                _dAlteracaoCusto = value;
                base.NotifyPropertyChanged(propertyName: "dAlteracaoCusto");
            }
        }
        private int _idUnidadeMedida;
        [ParameterOrder(Order = 15)]
        public int idUnidadeMedida
        {
            get { return _idUnidadeMedida; }
            set
            {
                _idUnidadeMedida = value;
                base.NotifyPropertyChanged(propertyName: "idUnidadeMedida");
            }
        }
        private decimal? _pMarkup;
        [ParameterOrder(Order = 16)]
        public decimal? pMarkup
        {
            get
            {
                return _pMarkup;
            }
            set
            {
                _pMarkup = value;
                base.NotifyPropertyChanged(propertyName: "pMarkup");
            }
        }

        #region Propriedades não mapeadas de Produtos

        #endregion

        #region Propriedades não mapeadas

        private byte? _stMarkupLista;

        public byte? stMarkupLista
        {
            get { return _stMarkupLista; }
            set
            {
                _stMarkupLista = value;
                this.CalculaMarkup(objItemLista: this);
            }
        }


        private decimal _vlrEsperado;

        public decimal vlrEsperado
        {
            get { return _vlrEsperado; }
            set
            {
                _vlrEsperado = value;
                base.NotifyPropertyChanged(propertyName: "vlrEsperado");
            }
        }


        private bool _bChecked;

        public bool bChecked
        {
            get { return _bChecked; }
            set
            {
                _bChecked = value;
                base.NotifyPropertyChanged(propertyName: "bChecked");
            }
        }

        #endregion
    }

    #region Validações
    public partial class Lista_Preco_PaiModel
    {
        public override string this[string columnName]
        {
            get
            {
                string retorno = base[columnName];

                if (retorno == "" || retorno == null)
                {
                    if (columnName == "idListaPrecoOrigem")
                        if (this.stAtualizacao == 0 && (this.idListaPrecoOrigem == 0 || this.idListaPrecoOrigem == null))
                            retorno = "Listas automáticas devem possuir uma lista origem!";
                }
                return retorno;
            }
        }
    }

    public partial class Lista_precoModel
    {
        public override string this[string columnName]
        {
            get
            {
                return base[columnName];
            }
        }
    }
    #endregion
}
