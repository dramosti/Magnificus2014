using HLP.Comum.Infrastructure;
using HLP.Comum.Infrastructure.Static;
using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.Comercial
{
    public partial class Lista_Preco_PaiModel : modelBase
    {
        public Lista_Preco_PaiModel()
            : base(xTabela: "Lista_Preco_Pai")
        {
            this.lLista_preco = new ObservableCollectionBaseCadastros<Lista_precoModel>();
        }

        [ParameterOrder(Order = 1)]
        public int idEmpresa { get; set; }
        private int? _idListaPrecoPai;

        [ParameterOrder(Order = 2)]
        public int? idListaPrecoPai
        {
            get { return _idListaPrecoPai; }
            set
            {
                _idListaPrecoPai = value;
                base.NotifyPropertyChanged(propertyName: "idListaPrecoPai");
            }
        }

        [ParameterOrder(Order = 3)]
        public string xLista { get; set; }
        [ParameterOrder(Order = 4)]
        public byte stContrato { get; set; }
        [ParameterOrder(Order = 5)]
        public string xNrContrato { get; set; }
        [ParameterOrder(Order = 6)]
        public DateTime? dValidadeContrato { get; set; }
        [ParameterOrder(Order = 7)]
        public bool Ativo { get; set; }
        [ParameterOrder(Order = 8)]
        public DateTime dListaPreco { get; set; }
        [ParameterOrder(Order = 9)]
        public byte stAtualizacao { get; set; }
        [ParameterOrder(Order = 10)]
        public decimal? nDiasSemAtualicao { get; set; }
        [ParameterOrder(Order = 11)]
        public decimal? pDescontoMaximo { get; set; }
        [ParameterOrder(Order = 12)]
        public decimal? pAcressimoMaximo { get; set; }
        [ParameterOrder(Order = 13)]
        public string xCodigoListaPreco { get; set; }

        private decimal? _pPercentual;

        [ParameterOrder(Order = 14)]
        public decimal? pPercentual
        {
            get { return _pPercentual; }
            set
            {
                decimal d;

                if (value == null)
                {
                    d = decimal.Zero;
                }

                if (!decimal.TryParse(s: value.ToString(), result: out d))
                {
                    d = decimal.Zero;
                }

                foreach (Lista_precoModel it in this.lLista_preco)
                {
                    it.vVenda /= 1 + ((this._pPercentual ?? 0) / 100);
                    it.vVenda *= (1 + (d / 100));
                    this.NotifyPropertyChanged(propertyName: "vVenda");
                }
                _pPercentual = value;
            }
        }

        [ParameterOrder(Order = 15)]
        public int? idListaPrecoOrigem { get; set; }


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

    public partial class Lista_precoModel : modelBase
    {
        public Lista_precoModel()
            : base(xTabela: "Lista_preco")
        {
        }

        private void CalculaPrecoVenda()
        {
            if (CompanyData.parametros_CustoEmpresa == null)
                return;

            byte stMarkup = (byte)CompanyData.parametros_CustoEmpresa.GetType().GetProperty("st_Markup").GetValue(CompanyData.parametros_CustoEmpresa);
            switch (stMarkup)
            {
                case 0://Por preço de custo
                    {
                        this._vVenda = (decimal)(_vCustoProduto * this.pMarkup);
                    } break;
                case 1://Por preço de venda
                    {
                        this._vVenda = (decimal)(_vCustoProduto / this.pMarkup);
                    } break;
            }

            base.NotifyPropertyChanged(propertyName: "vVenda");
            base.NotifyPropertyChanged(propertyName: "pMarkup");
        }

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
                base.NotifyPropertyChanged(propertyName: "vCustoProduto");
                this.CalculaPrecoVenda();
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
                base.NotifyPropertyChanged(propertyName: "pLucro");
                this.CalculaPrecoVenda();
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
                this._pLucro = ((this._vVenda - this._vCustoProduto) / this._vCustoProduto) * 100;
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
        [ParameterOrder(Order = 10)]
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
                this.CalculaPrecoVenda();
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
                this.CalculaPrecoVenda();
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
                this.CalculaPrecoVenda();
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
                int stMarkup = 0;

                switch (stMarkup)
                {
                    case 0://Por preço de custo
                        {
                            _pMarkup = (1 + (((this._pComissao ?? (decimal)0) + (this._pLucro) +
                                (this._pOutros ?? (decimal)0) - (this._pDesconto ?? 0)) / 100));
                        } break;
                    case 1://Por preço de venda
                        {
                            _pMarkup = (1 - (((this._pComissao ?? (decimal)0) + (this._pLucro) +
                                (this._pOutros ?? (decimal)0) - (this._pDesconto ?? 0)) / 100));
                        } break;
                }
                return _pMarkup;
            }
            set
            {
                _pMarkup = value;
                base.NotifyPropertyChanged(propertyName: "pMarkup");
            }
        }
    }

    #region Validações
    public partial class Lista_Preco_PaiModel
    {
        public override string this[string columnName]
        {
            get
            {
                return base[columnName];
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
