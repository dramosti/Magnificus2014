﻿using HLP.Base.ClassesBases;
using HLP.Base.Static;
using HLP.Components.Model.Models;
using HLP.Comum.Model.Models;
using HLP.Entries.Model.Comercial;
using HLP.Entries.Model.Models.Gerais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HLP.Entries.Model.Models.Comercial
{
    public partial class ProdutoModel : modelComum
    {
        public ProdutoModel()
            : base(xTabela: "Produto")
        {
            this.lProdutos_Conversao = new ObservableCollectionBaseCadastros<ConversaoModel>();
            this.lProduto_Fornecedor_Homologado = new ObservableCollectionBaseCadastros<Produto_Fornecedor_HomologadoModel>();
            this.lProduto_Revisao = new ObservableCollectionBaseCadastros<Produto_RevisaoModel>();
            this.dCadastro = DateTime.Now;
            this.idFuncionario = UserData.idUser;

        }

        private int? _idProduto;

        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idProduto
        {
            get { return _idProduto; }
            set
            {
                _idProduto = value;
                base.NotifyPropertyChanged(propertyName: "idProduto");
            }
        }

        [ParameterOrder(Order = 2)]
        public string cAlternativo { get; set; }
        [ParameterOrder(Order = 3)]
        public string cEan { get; set; }

        private string _xPesquisa;
        [ParameterOrder(Order = 4)]
        public string xPesquisa
        {
            get { return _xPesquisa; }
            set
            {
                _xPesquisa = value;
                base.NotifyPropertyChanged(propertyName: "xPesquisa");
            }
        }

        [ParameterOrder(Order = 5)]
        public string xComercial { get; set; }
        [ParameterOrder(Order = 6)]
        public string xFiscal { get; set; }
        [ParameterOrder(Order = 7)]
        public string xIngles { get; set; }

        private int? _idUnidadeMedidaEstoque;
        [ParameterOrder(Order = 8)]
        public int? idUnidadeMedidaEstoque
        {
            get { return _idUnidadeMedidaEstoque; }
            set
            {
                _idUnidadeMedidaEstoque = value;
                base.NotifyPropertyChanged(propertyName: "idUnidadeMedidaEstoque");
            }
        }


        private Tipo_produtoModel _objTipoProduto;

        public Tipo_produtoModel objTipoProduto
        {
            get { return _objTipoProduto; }
            set
            {
                _objTipoProduto = value;

                if (value != null)
                    this.IsService = value.stServicos == (byte)1;

                base.NotifyPropertyChanged(propertyName: "objTipoProduto");
            }
        }

        private int _idTipoProduto;
        [ParameterOrder(Order = 9)]
        public int idTipoProduto
        {
            get { return _idTipoProduto; }
            set
            {
                _idTipoProduto = value;

                base.NotifyPropertyChanged(propertyName: "idTipoProduto");

            }
        }

        private Familia_produtoModel _objFamiliaProduto;

        public Familia_produtoModel objFamiliaProduto
        {
            get { return _objFamiliaProduto; }
            set
            {
                _objFamiliaProduto = value;
                base.NotifyPropertyChanged(propertyName: "objFamiliaProduto");
            }
        }

        [ParameterOrder(Order = 10)]
        public int idFamiliaProduto { get; set; }
        [ParameterOrder(Order = 11)]
        public int idFabricante { get; set; }
        [ParameterOrder(Order = 12)]
        public decimal nPesoBruto { get; set; }
        [ParameterOrder(Order = 13)]
        public decimal nPesoLiquido { get; set; }
        [ParameterOrder(Order = 14)]
        public int Cod_centro_custo { get; set; }
        [ParameterOrder(Order = 15)]
        public int? idProdutoLocalizacao { get; set; }


        private bool? _Ativo;
        [ParameterOrder(Order = 16)]
        public bool? Ativo
        {
            get { return _Ativo; }
            set
            {
                _Ativo = value;

                if (this.GetOperationModel() == Base.EnumsBases.OperationModel.updating
                    )
                {
                    if (value == false)
                        this.dBloqueio = DateTime.Now;
                    else
                        this.dBloqueio = null;
                }


                base.NotifyPropertyChanged(propertyName: "Ativo");
            }
        }

        private DateTime? _dBloqueio;
        [ParameterOrder(Order = 17)]
        public DateTime? dBloqueio
        {
            get { return _dBloqueio; }
            set
            {
                _dBloqueio = value;
                base.NotifyPropertyChanged(propertyName: "dBloqueio");
            }
        }

        [ParameterOrder(Order = 18)]
        public decimal nEstoqueMinimo { get; set; }
        [ParameterOrder(Order = 19)]
        public decimal nEstoqueMaximo { get; set; }
        [ParameterOrder(Order = 20)]
        public byte tpLote { get; set; }
        [ParameterOrder(Order = 21)]
        public string IniLote { get; set; }
        [ParameterOrder(Order = 22)]
        public int nPrazoValidade { get; set; }
        [ParameterOrder(Order = 23)]
        public string xFoto { get; set; }
        [ParameterOrder(Order = 24)]
        public string xObs { get; set; }
        [ParameterOrder(Order = 25)]
        public byte stCusto { get; set; }
        [ParameterOrder(Order = 26)]
        public byte stCustoMedio { get; set; }
        [ParameterOrder(Order = 27)]
        public decimal pInss { get; set; }
        [ParameterOrder(Order = 28)]
        public TimeSpan dleadTimeCotacao { get; set; }
        [ParameterOrder(Order = 29)]
        public TimeSpan dleadTimePedido { get; set; }
        [ParameterOrder(Order = 30)]
        public TimeSpan dleadTimeRecebimento { get; set; }
        [ParameterOrder(Order = 31)]
        public byte stLogisticaReversa { get; set; }
        [ParameterOrder(Order = 32)]
        public byte stFornecedorHomologado { get; set; }
        [ParameterOrder(Order = 33)]
        public int? idTipoServico { get; set; }
        [ParameterOrder(Order = 34)]
        public int? idEmpresa { get; set; }


        private DepositoModel _objDeposito;

        public DepositoModel objDeposito
        {
            get { return _objDeposito; }
            set
            {
                _objDeposito = value;

                if (value != null)
                    this.idSite = value.idSite;
                base.NotifyPropertyChanged(propertyName: "objDeposito");
            }
        }


        private int _idDeposito;
        [ParameterOrder(Order = 35)]
        public int idDeposito
        {
            get { return _idDeposito; }
            set
            {
                _idDeposito = value;

                base.NotifyPropertyChanged(propertyName: "idDeposito");
            }
        }



        private DateTime _dCadastro;
        [ParameterOrder(Order = 36)]
        public DateTime dCadastro
        {
            get { return _dCadastro; }
            set
            {
                _dCadastro = value;
                base.NotifyPropertyChanged(propertyName: "dCadastro");
            }
        }

        private int _idFuncionario;
        [ParameterOrder(Order = 37)]
        public int idFuncionario
        {
            get { return _idFuncionario; }
            set
            {
                _idFuncionario = value;
                base.NotifyPropertyChanged(propertyName: "idFuncionario");
            }
        }

        [ParameterOrder(Order = 38)]
        public byte stOrigemMercadoria { get; set; }
        [ParameterOrder(Order = 39)]
        public int? idCSTIcms { get; set; }
        [ParameterOrder(Order = 40)]
        public byte stInss { get; set; }
        [ParameterOrder(Order = 41)]
        public decimal pImportacao { get; set; }
        [ParameterOrder(Order = 42)]
        public int? idCodigoIcmsPaiVenda { get; set; }
        [ParameterOrder(Order = 43)]
        public int? idCSTIpiVenda { get; set; }
        [ParameterOrder(Order = 44)]
        public int? idCSTPisVenda { get; set; }
        [ParameterOrder(Order = 45)]
        public int? idCSTCofinsVenda { get; set; }
        [ParameterOrder(Order = 46)]
        public int? idClassificacaoFiscalVenda { get; set; }
        [ParameterOrder(Order = 47)]
        public int? idCodigoIcmsPaiCompra { get; set; }
        [ParameterOrder(Order = 48)]
        public int? idCSTIpiCompra { get; set; }
        [ParameterOrder(Order = 49)]
        public int? idCSTPisCompra { get; set; }
        [ParameterOrder(Order = 50)]
        public int? idCSTCofinsCompra { get; set; }
        [ParameterOrder(Order = 51)]
        public int? idClassificacaoFiscalCompra { get; set; }
        [ParameterOrder(Order = 52)]
        public decimal vVenda { get; set; }

        private int? _idUnidadeMedidaVendas;
        [ParameterOrder(Order = 53)]
        public int? idUnidadeMedidaVendas
        {
            get { return _idUnidadeMedidaVendas; }
            set
            {
                _idUnidadeMedidaVendas = value;
                base.NotifyPropertyChanged(propertyName: "idUnidadeMedidaVendas");
            }
        }

        [ParameterOrder(Order = 54)]
        public decimal vAquisicao { get; set; }

        private int? _idUnidadeMedidaCompras;
        [ParameterOrder(Order = 55)]
        public int? idUnidadeMedidaCompras
        {
            get { return _idUnidadeMedidaCompras; }
            set
            {
                _idUnidadeMedidaCompras = value;
                base.NotifyPropertyChanged(propertyName: "idUnidadeMedidaCompras");
            }
        }

        [ParameterOrder(Order = 56)]
        public decimal vProducao { get; set; }

        private int? _idUnidadeMedidaProducao;
        [ParameterOrder(Order = 57)]
        public int? idUnidadeMedidaProducao
        {
            get { return _idUnidadeMedidaProducao; }
            set
            {
                _idUnidadeMedidaProducao = value;
                base.NotifyPropertyChanged(propertyName: "idUnidadeMedidaProducao");
            }
        }

        [ParameterOrder(Order = 58)]
        public byte stFornecedorHomologadoProduto { get; set; }
        [ParameterOrder(Order = 59)]
        public decimal nLoteMinimoCompras { get; set; }
        [ParameterOrder(Order = 60)]
        public decimal nProfundidadeBruta { get; set; }
        [ParameterOrder(Order = 61)]
        public decimal nLarguraBruta { get; set; }
        [ParameterOrder(Order = 62)]
        public decimal nAlturaBruta { get; set; }
        [ParameterOrder(Order = 63)]
        public decimal pEntregaExcedenteCompra { get; set; }
        [ParameterOrder(Order = 64)]
        public decimal pEntregaInsuficienteCompra { get; set; }
        [ParameterOrder(Order = 65)]
        public decimal vPerdaConstante { get; set; }
        [ParameterOrder(Order = 66)]
        public decimal pPerdaVariavel { get; set; }
        [ParameterOrder(Order = 67)]
        public decimal pEntregaExcedenteVenda { get; set; }
        [ParameterOrder(Order = 68)]
        public DateTime dValorVenda { get; set; }
        [ParameterOrder(Order = 69)]
        public decimal pEntregaInsuficienteVenda { get; set; }
        [ParameterOrder(Order = 70)]
        public decimal vCompra { get; set; }
        [ParameterOrder(Order = 71)]
        public decimal pPerdaConstante { get; set; }

        private List<modelToComboBox> _lUnidades;

        public List<modelToComboBox> lUnidades
        {
            get { return _lUnidades; }
            set
            {
                _lUnidades = value;
                base.NotifyPropertyChanged(propertyName: "lUnidades");
            }
        }

        private ObservableCollectionBaseCadastros<Produto_Fornecedor_HomologadoModel> _lProduto_Fornecedor_Homologado;

        public ObservableCollectionBaseCadastros<Produto_Fornecedor_HomologadoModel> lProduto_Fornecedor_Homologado
        {
            get { return _lProduto_Fornecedor_Homologado; }
            set
            {
                _lProduto_Fornecedor_Homologado = value;
                base.NotifyPropertyChanged(propertyName: "lProduto_Fornecedor_Homologado");
            }
        }


        private ObservableCollectionBaseCadastros<Produto_RevisaoModel> _lProduto_Revisao;

        public ObservableCollectionBaseCadastros<Produto_RevisaoModel> lProduto_Revisao
        {
            get { return _lProduto_Revisao; }
            set
            {
                _lProduto_Revisao = value;
                base.NotifyPropertyChanged(propertyName: "lProduto_Revisao");
            }
        }

        private ObservableCollectionBaseCadastros<ConversaoModel> _lProdutos_Conversao;

        public ObservableCollectionBaseCadastros<ConversaoModel> lProdutos_Conversao
        {
            get { return _lProdutos_Conversao; }
            set
            {
                _lProdutos_Conversao = value;
                base.NotifyPropertyChanged(propertyName: "lProdutos_Conversao");
            }
        }

        #region Propriedades não mapeada


        private bool _IsService;

        public bool IsService
        {
            get { return _IsService; }
            set
            {
                _IsService = value;
                base.NotifyPropertyChanged(propertyName: "IsService");
            }
        }


        private int _idSite;

        public int idSite
        {
            get { return _idSite; }
            set
            {
                _idSite = value;
                base.NotifyPropertyChanged(propertyName: "idSite");
            }
        }

        #endregion

    }

    public partial class Produto_Fornecedor_HomologadoModel : modelComum
    {
        public Produto_Fornecedor_HomologadoModel()
            : base(xTabela: "Produto_Fornecedor_Homologado")
        {
        }

        private int? _idProdutoFornecedorHomologado;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idProdutoFornecedorHomologado
        {
            get { return _idProdutoFornecedorHomologado; }
            set
            {
                _idProdutoFornecedorHomologado = value;
                base.NotifyPropertyChanged(propertyName: "idProdutoFornecedorHomologado");
            }
        }
        private int _idEmpresa;
        [ParameterOrder(Order = 2)]
        public int idEmpresa
        {
            get { return _idEmpresa; }
            set
            {
                _idEmpresa = value;
                base.NotifyPropertyChanged(propertyName: "idEmpresa");
            }
        }
        private int _idProduto;
        [ParameterOrder(Order = 3)]
        public int idProduto
        {
            get { return _idProduto; }
            set
            {
                _idProduto = value;
                base.NotifyPropertyChanged(propertyName: "idProduto");
            }
        }
        private int _idClienteFornecedor;
        [ParameterOrder(Order = 4)]
        public int idClienteFornecedor
        {
            get { return _idClienteFornecedor; }
            set
            {
                _idClienteFornecedor = value;
                base.NotifyPropertyChanged(propertyName: "idClienteFornecedor");
            }
        }
        private decimal _nLeadTimeEntrega;
        [ParameterOrder(Order = 5)]
        public decimal nLeadTimeEntrega
        {
            get { return _nLeadTimeEntrega; }
            set
            {
                _nLeadTimeEntrega = value;
                base.NotifyPropertyChanged(propertyName: "nLeadTimeEntrega");
            }
        }
        private decimal _nLoteMinimoCompra;
        [ParameterOrder(Order = 6)]
        public decimal nLoteMinimoCompra
        {
            get { return _nLoteMinimoCompra; }
            set
            {
                _nLoteMinimoCompra = value;
                base.NotifyPropertyChanged(propertyName: "nLoteMinimoCompra");
            }
        }
    }

    public partial class Produto_RevisaoModel : modelComum
    {
        public Produto_RevisaoModel()
            : base(xTabela: "Produto_Revisao")
        {
        }
        private int? _idProdutoRevisao;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idProdutoRevisao
        {
            get { return _idProdutoRevisao; }
            set
            {
                _idProdutoRevisao = value;
                base.NotifyPropertyChanged(propertyName: "idProdutoRevisao");
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
        private DateTime _dInicial;
        [ParameterOrder(Order = 3)]
        public DateTime dInicial
        {
            get { return _dInicial; }
            set
            {
                _dInicial = value;
                base.NotifyPropertyChanged(propertyName: "dInicial");
            }
        }
        private string _xRevisao;
        [ParameterOrder(Order = 4)]
        public string xRevisao
        {
            get { return _xRevisao; }
            set
            {
                _xRevisao = value;
                base.NotifyPropertyChanged(propertyName: "xRevisao");
            }
        }
        private int _idFuncionario;
        [ParameterOrder(Order = 5)]
        public int idFuncionario
        {
            get { return _idFuncionario; }
            set
            {
                _idFuncionario = value;
                base.NotifyPropertyChanged(propertyName: "idFuncionario");
            }
        }
        private DateTime _dFinal;
        [ParameterOrder(Order = 6)]
        public DateTime dFinal
        {
            get { return _dFinal; }
            set
            {
                _dFinal = value;
                base.NotifyPropertyChanged(propertyName: "dFinal");
            }
        }
    }

    #region Validações

    public partial class ProdutoModel
    {
        public override string this[string columnName]
        {
            get
            {
                return base[columnName];
            }
        }
    }

    public partial class Produto_Fornecedor_HomologadoModel
    {
        public override string this[string columnName]
        {
            get
            {
                return base[columnName];
            }
        }
    }

    public partial class Produto_RevisaoModel
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
