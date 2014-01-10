using HLP.Comum.Infrastructure;
using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Facade.Sales;
using HLP.Entries.Model.Fiscal;
using System.Collections.ObjectModel;

namespace HLP.Sales.Model.Models.Comercial
{
    public partial class Orcamento_ideModel : modelBase
    {
        public Orcamento_ideModel()
            : base("Orcamento_ide")
        {
            try
            {
                if (OrcamentoFacade.clienteServico == null)
                    OrcamentoFacade.clienteServico = new Comum.Facade.clienteService.IserviceClienteClient();

                if (OrcamentoFacade.contatoServico == null)
                    OrcamentoFacade.contatoServico = new Comum.Facade.contato_Service.IserviceContatoClient();

                if (OrcamentoFacade.ufService == null)
                    OrcamentoFacade.ufService = new Comum.Facade.ufService.IserviceUfClient();

                if (OrcamentoFacade.objCadastros == null)
                    OrcamentoFacade.objCadastros = new OrcamentoCadastros();

                if (OrcamentoFacade.cidadeService == null)
                    OrcamentoFacade.cidadeService = new Comum.Facade.cidadeService.IserviceCidadeClient();

                if (OrcamentoFacade.canal_VendaService == null)
                    OrcamentoFacade.canal_VendaService = new Comum.Facade.Canal_VendaService.IserviceCanal_VendaClient();

                if (OrcamentoFacade.produtoService == null)
                    OrcamentoFacade.produtoService = new Comum.Facade.produtoService.IserviceProdutoClient();

                if (OrcamentoFacade.lista_PrecoService == null)
                    OrcamentoFacade.lista_PrecoService = new Comum.Facade.Lista_PrecoService.IserviceLista_PrecoClient();

                if (OrcamentoFacade.familiaProdutoService == null)
                    OrcamentoFacade.familiaProdutoService = new Comum.Facade.Familia_ProdutoService.IserviceFamiliaProdutoClient();

                this.lOrcamento_Itens = new ObservableCollectionBaseCadastros<Orcamento_ItemModel>();
            }
            catch (Exception)
            {

                throw;
            }
        }

        #region Propriedades apenas para visualização na tela

        private string _xDepartamento;
        public string xDepartamento
        {
            get { return _xDepartamento; }
            set
            {
                if (value != null)
                    _xDepartamento = value;
                base.NotifyPropertyChanged(propertyName: "xDepartamento");
            }
        }


        private string _xCidade;

        public string xCidade
        {
            get { return _xCidade; }
            set
            {
                if (value != null)
                    _xCidade = value;
                base.NotifyPropertyChanged(propertyName: "xCidade");
            }
        }


        private string _xUf;

        public string xUf
        {
            get { return _xUf; }
            set
            {
                if (value != null)
                    _xUf = value;
                base.NotifyPropertyChanged(propertyName: "xUf");
            }
        }


        private string _xTelefone;

        public string xTelefone
        {
            get { return _xTelefone; }
            set
            {
                _xTelefone = value;
                base.NotifyPropertyChanged(propertyName: "xTelefone");
            }
        }


        private int _idRamoAtividade;

        public int idRamoAtividade
        {
            get { return _idRamoAtividade; }
            set
            {
                _idRamoAtividade = value;
                base.NotifyPropertyChanged(propertyName: "idRamoAtividade");
            }
        }


        private int _idCanalVenda;

        public int idCanalVenda
        {
            get { return _idCanalVenda; }
            set
            {
                _idCanalVenda = value;
                base.NotifyPropertyChanged(propertyName: "idCanalVenda");
            }
        }

        public bool bListaPrecoItemHabil
        {
            get
            {
                if (OrcamentoFacade.objCadastros != null)
                    if (OrcamentoFacade.objCadastros.objCliente != null)
                        return OrcamentoFacade.objCadastros.objCliente.stObrigaListaPreco == 0;

                return true;
            }
        }

        public int idListaPrecoPaiCliente
        {
            get
            {
                return OrcamentoFacade.objCadastros.objCliente.idListaPrecoPai;
            }
        }

        #endregion


        private int? _idOrcamento;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idOrcamento
        {
            get { return _idOrcamento; }
            set
            {
                _idOrcamento = value;
                base.NotifyPropertyChanged(propertyName: "idOrcamento");
            }
        }
        private DateTime _dDataHora;
        [ParameterOrder(Order = 2)]
        public DateTime dDataHora
        {
            get { return _dDataHora; }
            set
            {
                _dDataHora = value;
                base.NotifyPropertyChanged(propertyName: "dDataHora");
            }
        }
        private int _idClienteFornecedor;
        [ParameterOrder(Order = 3)]
        public int idClienteFornecedor
        {
            get { return _idClienteFornecedor; }
            set
            {
                _idClienteFornecedor = value;
                OrcamentoFacade.objCadastros.objCliente = OrcamentoFacade.clienteServico.getCliente(idCliente: value);
                if (OrcamentoFacade.objCadastros.objCliente != null)
                {
                    if (OrcamentoFacade.objCadastros.objCliente.cliente_fornecedor_fiscal != null)
                    {
                        this.stContribuinteIcms = OrcamentoFacade.objCadastros.objCliente.cliente_fornecedor_fiscal.stContribuienteIcms;
                    }
                    this.idRamoAtividade = OrcamentoFacade.objCadastros.objCliente.idRamoAtividade;
                    this.idFuncionarioRepresentante = OrcamentoFacade.objCadastros.objCliente.idFuncionario ?? 0;
                    this.idCondicaoPagamento = OrcamentoFacade.objCadastros.objCliente.idCondicaoPagamento;
                    this.idCanalVenda = OrcamentoFacade.objCadastros.objCliente.idCanalVenda;
                    OrcamentoFacade.objCadastros.objListaPreco = OrcamentoFacade.lista_PrecoService.getLista_Preco(idListaPrecoPai:
                    OrcamentoFacade.objCadastros.objCliente.idListaPrecoPai);

                    if (OrcamentoFacade.objCadastros.objCliente.lCliente_fornecedor_Endereco != null)
                    {
                        if (OrcamentoFacade.objCadastros.objCliente.lCliente_fornecedor_Endereco.Count() > 0)
                        {
                            if (OrcamentoFacade.objCadastros.objCliente.lCliente_fornecedor_Endereco.Count(i => i.stPrincipal == 1) > 0)
                            {
                                HLP.Comum.Facade.cidadeService.CidadeModel objCidade =
                                    OrcamentoFacade.cidadeService.getCidade(idCidade:
                                    OrcamentoFacade.objCadastros.objCliente.lCliente_fornecedor_Endereco.FirstOrDefault(i => i.stPrincipal == 1).idCidade);
                                this.xCidade = objCidade != null ? objCidade.xCidade : "";

                                this.xUf = OrcamentoFacade.ufService.getUf(idUf: objCidade.idUF).xSiglaUf;
                            }
                        }
                    }
                    if (!this.bListaPrecoItemHabil)
                    {
                        foreach (Orcamento_ItemModel it in this.lOrcamento_Itens)
                        {
                            it.idListaPrecoPai = this.idListaPrecoPaiCliente;
                            base.NotifyPropertyChanged(propertyName: "idListaPrecoPai");
                        }
                    }
                }
                base.NotifyPropertyChanged(propertyName: "idClienteFornecedor");
            }
        }
        private byte _stOrcamento;
        [ParameterOrder(Order = 4)]
        public byte stOrcamento
        {
            get { return _stOrcamento; }
            set
            {
                _stOrcamento = value;
                base.NotifyPropertyChanged(propertyName: "stOrcamento");
            }
        }
        private int _idTipoOrcamento;
        [ParameterOrder(Order = 5)]
        public int idTipoOrcamento
        {
            get { return _idTipoOrcamento; }
            set
            {
                _idTipoOrcamento = value;
                base.NotifyPropertyChanged(propertyName: "idTipoOrcamento");
            }
        }
        private DateTime? _dVencimento;
        [ParameterOrder(Order = 6)]
        public DateTime? dVencimento
        {
            get { return _dVencimento; }
            set
            {
                _dVencimento = value;
                base.NotifyPropertyChanged(propertyName: "dVencimento");
            }
        }
        private DateTime? _dAcompanhamento;
        [ParameterOrder(Order = 7)]
        public DateTime? dAcompanhamento
        {
            get { return _dAcompanhamento; }
            set
            {
                _dAcompanhamento = value;
                base.NotifyPropertyChanged(propertyName: "dAcompanhamento");
            }
        }
        private string _xCotacaoComprasCliente;
        [ParameterOrder(Order = 8)]
        public string xCotacaoComprasCliente
        {
            get { return _xCotacaoComprasCliente; }
            set
            {
                _xCotacaoComprasCliente = value;
                base.NotifyPropertyChanged(propertyName: "xCotacaoComprasCliente");
            }
        }
        private string _xPedidoCliente;
        [ParameterOrder(Order = 9)]
        public string xPedidoCliente
        {
            get { return _xPedidoCliente; }
            set
            {
                _xPedidoCliente = value;
                base.NotifyPropertyChanged(propertyName: "xPedidoCliente");
            }
        }
        private int _idDeposito;
        [ParameterOrder(Order = 10)]
        public int idDeposito
        {
            get { return _idDeposito; }
            set
            {
                _idDeposito = value;
                base.NotifyPropertyChanged(propertyName: "idDeposito");
            }
        }
        private string _xNomeEntrega;
        [ParameterOrder(Order = 11)]
        public string xNomeEntrega
        {
            get { return _xNomeEntrega; }
            set
            {
                _xNomeEntrega = value;
                base.NotifyPropertyChanged(propertyName: "xNomeEntrega");
            }
        }
        private int _idModosEntrega;
        [ParameterOrder(Order = 12)]
        public int idModosEntrega
        {
            get { return _idModosEntrega; }
            set
            {
                _idModosEntrega = value;
                base.NotifyPropertyChanged(propertyName: "idModosEntrega");
            }
        }
        private int _idCondicaoEntrega;
        [ParameterOrder(Order = 13)]
        public int idCondicaoEntrega
        {
            get { return _idCondicaoEntrega; }
            set
            {
                _idCondicaoEntrega = value;
                base.NotifyPropertyChanged(propertyName: "idCondicaoEntrega");
            }
        }
        private DateTime? _dDataRecebimentoSolicitado;
        [ParameterOrder(Order = 14)]
        public DateTime? dDataRecebimentoSolicitado
        {
            get { return _dDataRecebimentoSolicitado; }
            set
            {
                _dDataRecebimentoSolicitado = value;
                base.NotifyPropertyChanged(propertyName: "dDataRecebimentoSolicitado");
            }
        }
        private DateTime? _dDataRemessaSolicitada;
        [ParameterOrder(Order = 15)]
        public DateTime? dDataRemessaSolicitada
        {
            get { return _dDataRemessaSolicitada; }
            set
            {
                _dDataRemessaSolicitada = value;
                base.NotifyPropertyChanged(propertyName: "dDataRemessaSolicitada");
            }
        }
        private int _idCondicaoPagamento;
        [ParameterOrder(Order = 16)]
        public int idCondicaoPagamento
        {
            get { return _idCondicaoPagamento; }
            set
            {
                _idCondicaoPagamento = value;
                base.NotifyPropertyChanged(propertyName: "idCondicaoPagamento");
            }
        }
        private int? _idMotivo;
        [ParameterOrder(Order = 17)]
        public int? idMotivo
        {
            get { return _idMotivo; }
            set
            {
                _idMotivo = value;
                base.NotifyPropertyChanged(propertyName: "idMotivo");
            }
        }
        private DateTime? _dConfirmacao;
        [ParameterOrder(Order = 18)]
        public DateTime? dConfirmacao
        {
            get { return _dConfirmacao; }
            set
            {
                _dConfirmacao = value;
                base.NotifyPropertyChanged(propertyName: "dConfirmacao");
            }
        }
        private int _idUnidadeVenda;
        [ParameterOrder(Order = 19)]
        public int idUnidadeVenda
        {
            get { return _idUnidadeVenda; }
            set
            {
                _idUnidadeVenda = value;
                base.NotifyPropertyChanged(propertyName: "idUnidadeVenda");
            }
        }
        private int _idDescontos;
        [ParameterOrder(Order = 20)]
        public int idDescontos
        {
            get { return _idDescontos; }
            set
            {
                _idDescontos = value;
                base.NotifyPropertyChanged(propertyName: "idDescontos");
            }
        }
        private int _idJuros;
        [ParameterOrder(Order = 21)]
        public int idJuros
        {
            get { return _idJuros; }
            set
            {
                _idJuros = value;
                base.NotifyPropertyChanged(propertyName: "idJuros");
            }
        }
        private int _idMulta;
        [ParameterOrder(Order = 22)]
        public int idMulta
        {
            get { return _idMulta; }
            set
            {
                _idMulta = value;
                base.NotifyPropertyChanged(propertyName: "idMulta");
            }
        }
        private string _xObservacao;
        [ParameterOrder(Order = 23)]
        public string xObservacao
        {
            get { return _xObservacao; }
            set
            {
                _xObservacao = value;
                base.NotifyPropertyChanged(propertyName: "xObservacao");
            }
        }
        private byte? _stConsumidorFinal;
        [ParameterOrder(Order = 24)]
        public byte? stConsumidorFinal
        {
            get { return _stConsumidorFinal; }
            set
            {
                _stConsumidorFinal = value;
                base.NotifyPropertyChanged(propertyName: "stConsumidorFinal");
            }
        }
        private byte? _stSuframaOrcamento;
        [ParameterOrder(Order = 25)]
        public byte? stSuframaOrcamento
        {
            get { return _stSuframaOrcamento; }
            set
            {
                _stSuframaOrcamento = value;
                base.NotifyPropertyChanged(propertyName: "stSuframaOrcamento");
            }
        }
        private byte? _stDescPISCOFINSSuframa;
        [ParameterOrder(Order = 26)]
        public byte? stDescPISCOFINSSuframa
        {
            get { return _stDescPISCOFINSSuframa; }
            set
            {
                _stDescPISCOFINSSuframa = value;
                base.NotifyPropertyChanged(propertyName: "stDescPISCOFINSSuframa");
            }
        }
        private int _idMoeda;
        [ParameterOrder(Order = 27)]
        public int idMoeda
        {
            get { return _idMoeda; }
            set
            {
                _idMoeda = value;
                base.NotifyPropertyChanged(propertyName: "idMoeda");
            }
        }
        private int _idFuncionarioRepresentante;
        [ParameterOrder(Order = 28)]
        public int idFuncionarioRepresentante
        {
            get { return _idFuncionarioRepresentante; }
            set
            {
                _idFuncionarioRepresentante = value;
                base.NotifyPropertyChanged(propertyName: "idFuncionarioRepresentante");
            }
        }
        private string _cIdentificacao;
        [ParameterOrder(Order = 29)]
        public string cIdentificacao
        {
            get { return _cIdentificacao; }
            set
            {
                _cIdentificacao = value;
                base.NotifyPropertyChanged(propertyName: "cIdentificacao");
            }
        }
        private int _idContaContabil;
        [ParameterOrder(Order = 30)]
        public int idContaContabil
        {
            get { return _idContaContabil; }
            set
            {
                _idContaContabil = value;
                base.NotifyPropertyChanged(propertyName: "idContaContabil");
            }
        }
        private int _idTipoDocumento;
        [ParameterOrder(Order = 31)]
        public int idTipoDocumento
        {
            get { return _idTipoDocumento; }
            set
            {
                _idTipoDocumento = value;
                base.NotifyPropertyChanged(propertyName: "idTipoDocumento");
            }
        }
        private int _idEmpresa;
        [ParameterOrder(Order = 32)]
        public int idEmpresa
        {
            get { return _idEmpresa; }
            set
            {
                _idEmpresa = value;
                base.NotifyPropertyChanged(propertyName: "idEmpresa");
            }
        }
        private int? _idContato;
        [ParameterOrder(Order = 33)]
        public int? idContato
        {
            get { return _idContato; }
            set
            {
                _idContato = value;
                if (value != null)
                {
                    OrcamentoFacade.objCadastros.objContato = OrcamentoFacade.contatoServico.GetObject(idContato: (int)value);
                    if (OrcamentoFacade.objCadastros.objContato != null)
                    {
                        this.xDepartamento = OrcamentoFacade.objCadastros.objContato.xDepartamento;
                        this.xTelefone = OrcamentoFacade.objCadastros.objContato.xTelefoneComercial ??
                            OrcamentoFacade.objCadastros.objCliente.xTelefone1;
                    }
                }
                base.NotifyPropertyChanged(propertyName: "idContato");
            }
        }

        private string _nPedidoCliente;
        [ParameterOrder(Order = 34)]
        public string nPedidoCliente
        {
            get { return _nPedidoCliente; }
            set
            {
                _nPedidoCliente = value;
                base.NotifyPropertyChanged(propertyName: "nPedidoCliente");
            }
        }
        private byte _stContribuinteIcms;
        [ParameterOrder(Order = 35)]
        public byte stContribuinteIcms
        {
            get { return _stContribuinteIcms; }
            set
            {
                _stContribuinteIcms = value;
                base.NotifyPropertyChanged(propertyName: "stContribuinteIcms");
            }
        }
        private int? _idOrcamentoOrigem;
        [ParameterOrder(Order = 36)]
        public int? idOrcamentoOrigem
        {
            get { return _idOrcamentoOrigem; }
            set
            {
                _idOrcamentoOrigem = value;
                base.NotifyPropertyChanged(propertyName: "idOrcamentoOrigem");
            }
        }
        private string _xVersaoOrcamento;
        [ParameterOrder(Order = 37)]
        public string xVersaoOrcamento
        {
            get { return _xVersaoOrcamento; }
            set
            {
                _xVersaoOrcamento = value;
                base.NotifyPropertyChanged(propertyName: "xVersaoOrcamento");
            }
        }
        private int? _idSite;
        [ParameterOrder(Order = 38)]
        public int? idSite
        {
            get { return _idSite; }
            set
            {
                _idSite = value;
                base.NotifyPropertyChanged(propertyName: "idSite");
            }
        }
        private int? _idFuncionario;
        [ParameterOrder(Order = 39)]
        public int? idFuncionario
        {
            get { return _idFuncionario; }
            set
            {
                _idFuncionario = value;
                base.NotifyPropertyChanged(propertyName: "idFuncionario");
            }
        }
        private int? _idFuncionarioResponsavel;
        [ParameterOrder(Order = 40)]
        public int? idFuncionarioResponsavel
        {
            get { return _idFuncionarioResponsavel; }
            set
            {
                _idFuncionarioResponsavel = value;
                base.NotifyPropertyChanged(propertyName: "idFuncionarioResponsavel");
            }
        }
        private byte? _stWeb;
        [ParameterOrder(Order = 41)]
        public byte? stWeb
        {
            get { return _stWeb; }
            set
            {
                _stWeb = value;
                base.NotifyPropertyChanged(propertyName: "stWeb");
            }
        }
        private int? _idTransportador;
        [ParameterOrder(Order = 42)]
        public int? idTransportador
        {
            get { return _idTransportador; }
            set
            {
                _idTransportador = value;
                base.NotifyPropertyChanged(propertyName: "idTransportador");
            }
        }

        private ObservableCollectionBaseCadastros<Orcamento_ItemModel> _lOrcamento_Itens;

        public ObservableCollectionBaseCadastros<Orcamento_ItemModel> lOrcamento_Itens
        {
            get { return _lOrcamento_Itens; }
            set
            {
                _lOrcamento_Itens = value;
                base.NotifyPropertyChanged(propertyName: "lOrcamento_Itens");
            }
        }

        private Orcamento_Total_ImpostosModel _orcamento_Total_Impostos;

        public Orcamento_Total_ImpostosModel orcamento_Total_Impostos
        {
            get { return _orcamento_Total_Impostos; }
            set
            {
                _orcamento_Total_Impostos = value;
                base.NotifyPropertyChanged(propertyName: "orcamento_Total_Impostos");
            }
        }

        private Orcamento_retTranspModel _orcamento_retTransp;

        public Orcamento_retTranspModel orcamento_retTransp
        {
            get { return _orcamento_retTransp; }
            set
            {
                _orcamento_retTransp = value;
                base.NotifyPropertyChanged(propertyName: "orcamento_retTransp");
            }
        }
    }

    public partial class Orcamento_ItemModel : modelBase
    {
        public Orcamento_ItemModel()
            : base(xTabela: "Orcamento_Item")
        {
            if (OrcamentoFacade.objCadastros != null)
                if (OrcamentoFacade.objCadastros.objCliente != null)
                {
                    this.idListaPrecoPai = OrcamentoFacade.objCadastros.objCliente.idListaPrecoPai;
                    base.NotifyPropertyChanged(propertyName: "idListaPrecoPai");
                }
        }

        #region Propriedades não mapeadas


        private bool _bXComercialEnabled;

        public bool bXComercialEnabled
        {
            get { return _bXComercialEnabled; }
            set
            {
                _bXComercialEnabled = value;
                base.NotifyPropertyChanged(propertyName: "bXComercialEnabled");
            }
        }

        #endregion

        private int? _idOrcamentoItem;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idOrcamentoItem
        {
            get { return _idOrcamentoItem; }
            set
            {
                _idOrcamentoItem = value;
                base.NotifyPropertyChanged(propertyName: "idOrcamentoItem");
            }
        }
        private int _idOrcamento;
        [ParameterOrder(Order = 2)]
        public int idOrcamento
        {
            get { return _idOrcamento; }
            set
            {
                _idOrcamento = value;
                base.NotifyPropertyChanged(propertyName: "idOrcamento");
            }
        }
        private int _idSite;
        [ParameterOrder(Order = 3)]
        public int idSite
        {
            get { return _idSite; }
            set
            {
                _idSite = value;
                base.NotifyPropertyChanged(propertyName: "idSite");
            }
        }
        private int _idDeposito;
        [ParameterOrder(Order = 4)]
        public int idDeposito
        {
            get { return _idDeposito; }
            set
            {
                _idDeposito = value;
                base.NotifyPropertyChanged(propertyName: "idDeposito");
            }
        }
        private int _idProduto;
        [ParameterOrder(Order = 5)]
        public int idProduto
        {
            get { return _idProduto; }
            set
            {
                _idProduto = value;

                if (value != null)
                {
                    if (value != 0)
                    {
                        HLP.Comum.Facade.produtoService.ProdutoModel objProduto = OrcamentoFacade.produtoService.getProduto(idProduto: value);
                        this.xComercial = objProduto.xComercial;
                        if (objProduto.idFamiliaProduto != 0 && objProduto.idFamiliaProduto != null)
                        {
                            this.bXComercialEnabled = OrcamentoFacade.familiaProdutoService.GetObject(idFamiliaProduto: objProduto.idFamiliaProduto).stAlteraDescricaoComercialProdutoVenda
                                == 1;
                        }
                    }
                }
                base.NotifyPropertyChanged(propertyName: "idProduto");
            }
        }
        private int _idEmpresa;
        [ParameterOrder(Order = 6)]
        public int idEmpresa
        {
            get { return _idEmpresa; }
            set
            {
                _idEmpresa = value;
                base.NotifyPropertyChanged(propertyName: "idEmpresa");
            }
        }
        private int _idTipoOperacao;
        [ParameterOrder(Order = 7)]
        public int idTipoOperacao
        {
            get { return _idTipoOperacao; }
            set
            {
                _idTipoOperacao = value;
                OrcamentoFacade.objCadastros.idTipoOperacao = value;
                base.NotifyPropertyChanged(propertyName: "idTipoOperacao");
            }
        }
        private byte _stConsumidorFinal;
        [ParameterOrder(Order = 8)]
        public byte stConsumidorFinal
        {
            get { return _stConsumidorFinal; }
            set
            {
                _stConsumidorFinal = value;
                base.NotifyPropertyChanged(propertyName: "stConsumidorFinal");
            }
        }
        private string _xPedidoCliente;
        [ParameterOrder(Order = 9)]
        public string xPedidoCliente
        {
            get { return _xPedidoCliente; }
            set
            {
                _xPedidoCliente = value;
                base.NotifyPropertyChanged(propertyName: "xPedidoCliente");
            }
        }
        private decimal? _nItemCliente;
        [ParameterOrder(Order = 10)]
        public decimal? nItemCliente
        {
            get { return _nItemCliente; }
            set
            {
                _nItemCliente = value;
                base.NotifyPropertyChanged(propertyName: "nItemCliente");
            }
        }
        private string _xCodigoProdutoCliente;
        [ParameterOrder(Order = 11)]
        public string xCodigoProdutoCliente
        {
            get { return _xCodigoProdutoCliente; }
            set
            {
                _xCodigoProdutoCliente = value;
                base.NotifyPropertyChanged(propertyName: "xCodigoProdutoCliente");
            }
        }
        private string _xComercial;
        [ParameterOrder(Order = 12)]
        public string xComercial
        {
            get { return _xComercial; }
            set
            {
                if (value != null)
                    _xComercial = value;
                base.NotifyPropertyChanged(propertyName: "xComercial");
            }
        }
        private int _idUnidadeMedida;
        [ParameterOrder(Order = 13)]
        public int idUnidadeMedida
        {
            get { return _idUnidadeMedida; }
            set
            {
                _idUnidadeMedida = value;
                base.NotifyPropertyChanged(propertyName: "idUnidadeMedida");
            }
        }
        private int _idListaPrecoPai;
        [ParameterOrder(Order = 14)]
        public int idListaPrecoPai
        {
            get { return _idListaPrecoPai; }
            set
            {
                _idListaPrecoPai = value;
                base.NotifyPropertyChanged(propertyName: "idListaPrecoPai");
            }
        }
        private decimal _vVendaSemDesconto;
        [ParameterOrder(Order = 15)]
        public decimal vVendaSemDesconto
        {
            get { return _vVendaSemDesconto; }
            set
            {
                _vVendaSemDesconto = value;
                base.NotifyPropertyChanged(propertyName: "vVendaSemDesconto");
            }
        }
        private decimal _vVenda;
        [ParameterOrder(Order = 16)]
        public decimal vVenda
        {
            get { return _vVenda; }
            set
            {
                _vVenda = value;
                base.NotifyPropertyChanged(propertyName: "vVenda");
            }
        }
        private decimal _qProduto;
        [ParameterOrder(Order = 17)]
        public decimal qProduto
        {
            get { return _qProduto; }
            set
            {
                _qProduto = value;
                base.NotifyPropertyChanged(propertyName: "qProduto");
            }
        }
        private decimal _pDesconto;
        [ParameterOrder(Order = 18)]
        public decimal pDesconto
        {
            get { return _pDesconto; }
            set
            {
                _pDesconto = value;
                base.NotifyPropertyChanged(propertyName: "pDesconto");
            }
        }
        private decimal _vDesconto;
        [ParameterOrder(Order = 19)]
        public decimal vDesconto
        {
            get { return _vDesconto; }
            set
            {
                _vDesconto = value;
                base.NotifyPropertyChanged(propertyName: "vDesconto");
            }
        }
        private decimal _vTotalSemDescontoItem;
        [ParameterOrder(Order = 20)]
        public decimal vTotalSemDescontoItem
        {
            get { return _vTotalSemDescontoItem; }
            set
            {
                _vTotalSemDescontoItem = value;
                base.NotifyPropertyChanged(propertyName: "vTotalSemDescontoItem");
            }
        }
        private decimal _vTotalItem;
        [ParameterOrder(Order = 21)]
        public decimal vTotalItem
        {
            get { return _vTotalItem; }
            set
            {
                _vTotalItem = value;
                base.NotifyPropertyChanged(propertyName: "vTotalItem");
            }
        }
        private decimal _vFreteItem;
        [ParameterOrder(Order = 22)]
        public decimal vFreteItem
        {
            get { return _vFreteItem; }
            set
            {
                _vFreteItem = value;
                base.NotifyPropertyChanged(propertyName: "vFreteItem");
            }
        }
        private DateTime? _dPrevisaoEntrega;
        [ParameterOrder(Order = 23)]
        public DateTime? dPrevisaoEntrega
        {
            get { return _dPrevisaoEntrega; }
            set
            {
                _dPrevisaoEntrega = value;
                base.NotifyPropertyChanged(propertyName: "dPrevisaoEntrega");
            }
        }
        private decimal _nPesoBruto;
        [ParameterOrder(Order = 24)]
        public decimal nPesoBruto
        {
            get { return _nPesoBruto; }
            set
            {
                _nPesoBruto = value;
                base.NotifyPropertyChanged(propertyName: "nPesoBruto");
            }
        }
        private decimal _nPesoLiquido;
        [ParameterOrder(Order = 25)]
        public decimal nPesoLiquido
        {
            get { return _nPesoLiquido; }
            set
            {
                _nPesoLiquido = value;
                base.NotifyPropertyChanged(propertyName: "nPesoLiquido");
            }
        }
        private byte _stOrcamentoItem;
        [ParameterOrder(Order = 26)]
        public byte stOrcamentoItem
        {
            get { return _stOrcamentoItem; }
            set
            {
                _stOrcamentoItem = value;
                base.NotifyPropertyChanged(propertyName: "stOrcamentoItem");
            }
        }
        private string _nPedidoClienteItem;
        [ParameterOrder(Order = 27)]
        public string nPedidoClienteItem
        {
            get { return _nPedidoClienteItem; }
            set
            {
                _nPedidoClienteItem = value;
                base.NotifyPropertyChanged(propertyName: "nPedidoClienteItem");
            }
        }
        private DateTime? _dConfirmacaoItem;
        [ParameterOrder(Order = 28)]
        public DateTime? dConfirmacaoItem
        {
            get { return _dConfirmacaoItem; }
            set
            {
                _dConfirmacaoItem = value;
                base.NotifyPropertyChanged(propertyName: "dConfirmacaoItem");
            }
        }
        private int? _idMotivo;
        [ParameterOrder(Order = 29)]
        public int? idMotivo
        {
            get { return _idMotivo; }
            set
            {
                _idMotivo = value;
                base.NotifyPropertyChanged(propertyName: "idMotivo");
            }
        }
        private string _xObservacaoItem;
        [ParameterOrder(Order = 30)]
        public string xObservacaoItem
        {
            get { return _xObservacaoItem; }
            set
            {
                _xObservacaoItem = value;
                base.NotifyPropertyChanged(propertyName: "xObservacaoItem");
            }
        }
        private decimal _vSegurosItem;
        [ParameterOrder(Order = 31)]
        public decimal vSegurosItem
        {
            get { return _vSegurosItem; }
            set
            {
                _vSegurosItem = value;
                base.NotifyPropertyChanged(propertyName: "vSegurosItem");
            }
        }
        private decimal _vOutrasDespesasItem;
        [ParameterOrder(Order = 32)]
        public decimal vOutrasDespesasItem
        {
            get { return _vOutrasDespesasItem; }
            set
            {
                _vOutrasDespesasItem = value;
                base.NotifyPropertyChanged(propertyName: "vOutrasDespesasItem");
            }
        }
        private int? _idCfop;
        [ParameterOrder(Order = 33)]
        public int? idCfop
        {
            get { return _idCfop; }
            set
            {
                _idCfop = value;
                base.NotifyPropertyChanged(propertyName: "idCfop");
            }
        }
        private int? _idFuncionarioRepresentante;
        [ParameterOrder(Order = 34)]
        public int? idFuncionarioRepresentante
        {
            get { return _idFuncionarioRepresentante; }
            set
            {
                _idFuncionarioRepresentante = value;
                base.NotifyPropertyChanged(propertyName: "idFuncionarioRepresentante");
            }
        }
        private decimal? _pComissao;
        [ParameterOrder(Order = 35)]
        public decimal? pComissao
        {
            get { return _pComissao; }
            set
            {
                _pComissao = value;
                base.NotifyPropertyChanged(propertyName: "pComissao");
            }
        }
        private decimal? _vDescontoSuframa;
        [ParameterOrder(Order = 36)]
        public decimal? vDescontoSuframa
        {
            get { return _vDescontoSuframa; }
            set
            {
                _vDescontoSuframa = value;
                base.NotifyPropertyChanged(propertyName: "vDescontoSuframa");
            }
        }

        private Orcamento_Item_ImpostosModel _orcamento_Item_Impostos;

        public Orcamento_Item_ImpostosModel orcamento_Item_Impostos
        {
            get { return _orcamento_Item_Impostos; }
            set
            {
                _orcamento_Item_Impostos = value;
                base.NotifyPropertyChanged(propertyName: "orcamento_Item_Impostos");
            }
        }

    }

    public partial class Orcamento_Item_ImpostosModel : modelBase
    {
        public Orcamento_Item_ImpostosModel()
            : base(xTabela: "Orcamento_Item_Impostos")
        {
        }

        private int? _idOrcamentoTotalizadorImpostos;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idOrcamentoTotalizadorImpostos
        {
            get { return _idOrcamentoTotalizadorImpostos; }
            set
            {
                _idOrcamentoTotalizadorImpostos = value;
                base.NotifyPropertyChanged(propertyName: "idOrcamentoTotalizadorImpostos");
            }
        }
        private byte _ICMS_stOrigemMercadoria;
        [ParameterOrder(Order = 2)]
        public byte ICMS_stOrigemMercadoria
        {
            get { return _ICMS_stOrigemMercadoria; }
            set
            {
                _ICMS_stOrigemMercadoria = value;
                base.NotifyPropertyChanged(propertyName: "ICMS_stOrigemMercadoria");
            }
        }
        private decimal? _ICMS_vBaseCalculo;
        [ParameterOrder(Order = 3)]
        public decimal? ICMS_vBaseCalculo
        {
            get { return _ICMS_vBaseCalculo; }
            set
            {
                _ICMS_vBaseCalculo = value;
                base.NotifyPropertyChanged(propertyName: "ICMS_vBaseCalculo");
            }
        }
        private decimal? _ICMS_pReduzBase;
        [ParameterOrder(Order = 4)]
        public decimal? ICMS_pReduzBase
        {
            get { return _ICMS_pReduzBase; }
            set
            {
                _ICMS_pReduzBase = value;
                base.NotifyPropertyChanged(propertyName: "ICMS_pReduzBase");
            }
        }
        private decimal? _ICMS_pICMS;
        [ParameterOrder(Order = 5)]
        public decimal? ICMS_pICMS
        {
            get { return _ICMS_pICMS; }
            set
            {
                _ICMS_pICMS = value;
                base.NotifyPropertyChanged(propertyName: "ICMS_pICMS");
            }
        }
        private decimal? _ICMS_vICMS;
        [ParameterOrder(Order = 6)]
        public decimal? ICMS_vICMS
        {
            get { return _ICMS_vICMS; }
            set
            {
                _ICMS_vICMS = value;
                base.NotifyPropertyChanged(propertyName: "ICMS_vICMS");
            }
        }
        private decimal? _ICMS_pMvaSubstituicaoTributaria;
        [ParameterOrder(Order = 7)]
        public decimal? ICMS_pMvaSubstituicaoTributaria
        {
            get { return _ICMS_pMvaSubstituicaoTributaria; }
            set
            {
                _ICMS_pMvaSubstituicaoTributaria = value;
                base.NotifyPropertyChanged(propertyName: "ICMS_pMvaSubstituicaoTributaria");
            }
        }
        private decimal? _ICMS_pReduzBaseSubstituicaoTributaria;
        [ParameterOrder(Order = 8)]
        public decimal? ICMS_pReduzBaseSubstituicaoTributaria
        {
            get { return _ICMS_pReduzBaseSubstituicaoTributaria; }
            set
            {
                _ICMS_pReduzBaseSubstituicaoTributaria = value;
                base.NotifyPropertyChanged(propertyName: "ICMS_pReduzBaseSubstituicaoTributaria");
            }
        }
        private decimal? _ICMS_vBaseCalculoSubstituicaoTributaria;
        [ParameterOrder(Order = 9)]
        public decimal? ICMS_vBaseCalculoSubstituicaoTributaria
        {
            get { return _ICMS_vBaseCalculoSubstituicaoTributaria; }
            set
            {
                _ICMS_vBaseCalculoSubstituicaoTributaria = value;
                base.NotifyPropertyChanged(propertyName: "ICMS_vBaseCalculoSubstituicaoTributaria");
            }
        }
        private decimal? _ICMS_pSubstituicaoTributaria;
        [ParameterOrder(Order = 10)]
        public decimal? ICMS_pSubstituicaoTributaria
        {
            get { return _ICMS_pSubstituicaoTributaria; }
            set
            {
                _ICMS_pSubstituicaoTributaria = value;
                base.NotifyPropertyChanged(propertyName: "ICMS_pSubstituicaoTributaria");
            }
        }
        private decimal? _ICMS_vSubstituicaoTributaria;
        [ParameterOrder(Order = 11)]
        public decimal? ICMS_vSubstituicaoTributaria
        {
            get { return _ICMS_vSubstituicaoTributaria; }
            set
            {
                _ICMS_vSubstituicaoTributaria = value;
                base.NotifyPropertyChanged(propertyName: "ICMS_vSubstituicaoTributaria");
            }
        }
        private decimal? _ICMS_vBaseCalculoSubstituicaoTributariaRetido;
        [ParameterOrder(Order = 12)]
        public decimal? ICMS_vBaseCalculoSubstituicaoTributariaRetido
        {
            get { return _ICMS_vBaseCalculoSubstituicaoTributariaRetido; }
            set
            {
                _ICMS_vBaseCalculoSubstituicaoTributariaRetido = value;
                base.NotifyPropertyChanged(propertyName: "ICMS_vBaseCalculoSubstituicaoTributariaRetido");
            }
        }
        private decimal? _ICMS_vSubstituicaoTributariaRetido;
        [ParameterOrder(Order = 13)]
        public decimal? ICMS_vSubstituicaoTributariaRetido
        {
            get { return _ICMS_vSubstituicaoTributariaRetido; }
            set
            {
                _ICMS_vSubstituicaoTributariaRetido = value;
                base.NotifyPropertyChanged(propertyName: "ICMS_vSubstituicaoTributariaRetido");
            }
        }
        private byte _ICMS_stReduzBaseCalculo;
        [ParameterOrder(Order = 14)]
        public byte ICMS_stReduzBaseCalculo
        {
            get { return _ICMS_stReduzBaseCalculo; }
            set
            {
                _ICMS_stReduzBaseCalculo = value;
                base.NotifyPropertyChanged(propertyName: "ICMS_stReduzBaseCalculo");
            }
        }
        private byte _ICMS_stCalculaIcms;
        [ParameterOrder(Order = 15)]
        public byte ICMS_stCalculaIcms
        {
            get { return _ICMS_stCalculaIcms; }
            set
            {
                _ICMS_stCalculaIcms = value;
                base.NotifyPropertyChanged(propertyName: "ICMS_stCalculaIcms");
            }
        }
        private byte _ICMS_stCompoeBaseCalculo;
        [ParameterOrder(Order = 16)]
        public byte ICMS_stCompoeBaseCalculo
        {
            get { return _ICMS_stCompoeBaseCalculo; }
            set
            {
                _ICMS_stCompoeBaseCalculo = value;
                base.NotifyPropertyChanged(propertyName: "ICMS_stCompoeBaseCalculo");
            }
        }
        private byte _ICMS_stCompoeBaseCalculoSubstituicaoTributaria;
        [ParameterOrder(Order = 17)]
        public byte ICMS_stCompoeBaseCalculoSubstituicaoTributaria
        {
            get { return _ICMS_stCompoeBaseCalculoSubstituicaoTributaria; }
            set
            {
                _ICMS_stCompoeBaseCalculoSubstituicaoTributaria = value;
                base.NotifyPropertyChanged(propertyName: "ICMS_stCompoeBaseCalculoSubstituicaoTributaria");
            }
        }
        private decimal? _ICMS_vBaseCalculoIcmsProprio;
        [ParameterOrder(Order = 18)]
        public decimal? ICMS_vBaseCalculoIcmsProprio
        {
            get { return _ICMS_vBaseCalculoIcmsProprio; }
            set
            {
                _ICMS_vBaseCalculoIcmsProprio = value;
                base.NotifyPropertyChanged(propertyName: "ICMS_vBaseCalculoIcmsProprio");
            }
        }
        private decimal? _ICMS_vIcmsProprio;
        [ParameterOrder(Order = 19)]
        public decimal? ICMS_vIcmsProprio
        {
            get { return _ICMS_vIcmsProprio; }
            set
            {
                _ICMS_vIcmsProprio = value;
                base.NotifyPropertyChanged(propertyName: "ICMS_vIcmsProprio");
            }
        }
        private decimal? _ICMS_pIcmsInterno;
        [ParameterOrder(Order = 20)]
        public decimal? ICMS_pIcmsInterno
        {
            get { return _ICMS_pIcmsInterno; }
            set
            {
                _ICMS_pIcmsInterno = value;
                base.NotifyPropertyChanged(propertyName: "ICMS_pIcmsInterno");
            }
        }
        private byte _ICMS_stCalculaSubstituicaoTributaria;
        [ParameterOrder(Order = 21)]
        public byte ICMS_stCalculaSubstituicaoTributaria
        {
            get { return _ICMS_stCalculaSubstituicaoTributaria; }
            set
            {
                _ICMS_stCalculaSubstituicaoTributaria = value;
                base.NotifyPropertyChanged(propertyName: "ICMS_stCalculaSubstituicaoTributaria");
            }
        }
        private decimal? _ICMS_pCargaTributariaMedia;
        [ParameterOrder(Order = 22)]
        public decimal? ICMS_pCargaTributariaMedia
        {
            get { return _ICMS_pCargaTributariaMedia; }
            set
            {
                _ICMS_pCargaTributariaMedia = value;
                base.NotifyPropertyChanged(propertyName: "ICMS_pCargaTributariaMedia");
            }
        }
        private int _idOrcamentoItem;
        [ParameterOrder(Order = 23)]
        public int idOrcamentoItem
        {
            get { return _idOrcamentoItem; }
            set
            {
                _idOrcamentoItem = value;
                base.NotifyPropertyChanged(propertyName: "idOrcamentoItem");
            }
        }
        private int _idCodigoIcmsPai;
        [ParameterOrder(Order = 24)]
        public int idCodigoIcmsPai
        {
            get { return _idCodigoIcmsPai; }
            set
            {
                _idCodigoIcmsPai = value;
                base.NotifyPropertyChanged(propertyName: "idCodigoIcmsPai");
            }
        }
        private int _idCSTIcms;
        [ParameterOrder(Order = 25)]
        public int idCSTIcms
        {
            get { return _idCSTIcms; }
            set
            {
                _idCSTIcms = value;
                base.NotifyPropertyChanged(propertyName: "idCSTIcms");
            }
        }
        private decimal? _IPI_vBaseCalculo;
        [ParameterOrder(Order = 26)]
        public decimal? IPI_vBaseCalculo
        {
            get { return _IPI_vBaseCalculo; }
            set
            {
                _IPI_vBaseCalculo = value;
                base.NotifyPropertyChanged(propertyName: "IPI_vBaseCalculo");
            }
        }
        private decimal? _IPI_pIPI;
        [ParameterOrder(Order = 27)]
        public decimal? IPI_pIPI
        {
            get { return _IPI_pIPI; }
            set
            {
                _IPI_pIPI = value;
                base.NotifyPropertyChanged(propertyName: "IPI_pIPI");
            }
        }
        private decimal? _IPI_vIPI;
        [ParameterOrder(Order = 28)]
        public decimal? IPI_vIPI
        {
            get { return _IPI_vIPI; }
            set
            {
                _IPI_vIPI = value;
                base.NotifyPropertyChanged(propertyName: "IPI_vIPI");
            }
        }
        private byte _IPI_stCalculaIpi;
        [ParameterOrder(Order = 29)]
        public byte IPI_stCalculaIpi
        {
            get { return _IPI_stCalculaIpi; }
            set
            {
                _IPI_stCalculaIpi = value;
                base.NotifyPropertyChanged(propertyName: "IPI_stCalculaIpi");
            }
        }
        private byte _IPI_stCompoeBaseCalculo;
        [ParameterOrder(Order = 30)]
        public byte IPI_stCompoeBaseCalculo
        {
            get { return _IPI_stCompoeBaseCalculo; }
            set
            {
                _IPI_stCompoeBaseCalculo = value;
                base.NotifyPropertyChanged(propertyName: "IPI_stCompoeBaseCalculo");
            }
        }
        private int _idClassificacaoFiscal;
        [ParameterOrder(Order = 31)]
        public int idClassificacaoFiscal
        {
            get { return _idClassificacaoFiscal; }
            set
            {
                _idClassificacaoFiscal = value;
                base.NotifyPropertyChanged(propertyName: "idClassificacaoFiscal");
            }
        }
        private int _idCSTIpi;
        [ParameterOrder(Order = 32)]
        public int idCSTIpi
        {
            get { return _idCSTIpi; }
            set
            {
                _idCSTIpi = value;
                base.NotifyPropertyChanged(propertyName: "idCSTIpi");
            }
        }
        private decimal? _ISS_vBaseCalculo;
        [ParameterOrder(Order = 33)]
        public decimal? ISS_vBaseCalculo
        {
            get { return _ISS_vBaseCalculo; }
            set
            {
                _ISS_vBaseCalculo = value;
                base.NotifyPropertyChanged(propertyName: "ISS_vBaseCalculo");
            }
        }
        private decimal? _ISS_pIss;
        [ParameterOrder(Order = 34)]
        public decimal? ISS_pIss
        {
            get { return _ISS_pIss; }
            set
            {
                _ISS_pIss = value;
                base.NotifyPropertyChanged(propertyName: "ISS_pIss");
            }
        }
        private decimal? _ISS_vIss;
        [ParameterOrder(Order = 35)]
        public decimal? ISS_vIss
        {
            get { return _ISS_vIss; }
            set
            {
                _ISS_vIss = value;
                base.NotifyPropertyChanged(propertyName: "ISS_vIss");
            }
        }
        private byte _ISS_stCalculaIss;
        [ParameterOrder(Order = 36)]
        public byte ISS_stCalculaIss
        {
            get { return _ISS_stCalculaIss; }
            set
            {
                _ISS_stCalculaIss = value;
                base.NotifyPropertyChanged(propertyName: "ISS_stCalculaIss");
            }
        }
        private int? _idCSTIss;
        [ParameterOrder(Order = 37)]
        public int? idCSTIss
        {
            get { return _idCSTIss; }
            set
            {
                _idCSTIss = value;
                base.NotifyPropertyChanged(propertyName: "idCSTIss");
            }
        }
        private decimal? _PIS_vBaseCalculo;
        [ParameterOrder(Order = 38)]
        public decimal? PIS_vBaseCalculo
        {
            get { return _PIS_vBaseCalculo; }
            set
            {
                _PIS_vBaseCalculo = value;
                base.NotifyPropertyChanged(propertyName: "PIS_vBaseCalculo");
            }
        }
        private decimal? _PIS_pPIS;
        [ParameterOrder(Order = 39)]
        public decimal? PIS_pPIS
        {
            get { return _PIS_pPIS; }
            set
            {
                _PIS_pPIS = value;
                base.NotifyPropertyChanged(propertyName: "PIS_pPIS");
            }
        }
        private decimal? _PIS_vPIS;
        [ParameterOrder(Order = 40)]
        public decimal? PIS_vPIS
        {
            get { return _PIS_vPIS; }
            set
            {
                _PIS_vPIS = value;
                base.NotifyPropertyChanged(propertyName: "PIS_vPIS");
            }
        }
        private byte _stCalculaPisCofins;
        [ParameterOrder(Order = 41)]
        public byte stCalculaPisCofins
        {
            get { return _stCalculaPisCofins; }
            set
            {
                _stCalculaPisCofins = value;
                base.NotifyPropertyChanged(propertyName: "stCalculaPisCofins");
            }
        }
        private byte _stRegimeTributacaoPisCofins;
        [ParameterOrder(Order = 42)]
        public byte stRegimeTributacaoPisCofins
        {
            get { return _stRegimeTributacaoPisCofins; }
            set
            {
                _stRegimeTributacaoPisCofins = value;
                base.NotifyPropertyChanged(propertyName: "stRegimeTributacaoPisCofins");
            }
        }
        private decimal? _PIS_nCoeficienteSubstituicaoTributaria;
        [ParameterOrder(Order = 43)]
        public decimal? PIS_nCoeficienteSubstituicaoTributaria
        {
            get { return _PIS_nCoeficienteSubstituicaoTributaria; }
            set
            {
                _PIS_nCoeficienteSubstituicaoTributaria = value;
                base.NotifyPropertyChanged(propertyName: "PIS_nCoeficienteSubstituicaoTributaria");
            }
        }
        private byte _stCompoeBaseCalculoPisCofins;
        [ParameterOrder(Order = 44)]
        public byte stCompoeBaseCalculoPisCofins
        {
            get { return _stCompoeBaseCalculoPisCofins; }
            set
            {
                _stCompoeBaseCalculoPisCofins = value;
                base.NotifyPropertyChanged(propertyName: "stCompoeBaseCalculoPisCofins");
            }
        }
        private byte _PIS_stCompoeBaseCalculoSubstituicaoTributaria;
        [ParameterOrder(Order = 45)]
        public byte PIS_stCompoeBaseCalculoSubstituicaoTributaria
        {
            get { return _PIS_stCompoeBaseCalculoSubstituicaoTributaria; }
            set
            {
                _PIS_stCompoeBaseCalculoSubstituicaoTributaria = value;
                base.NotifyPropertyChanged(propertyName: "PIS_stCompoeBaseCalculoSubstituicaoTributaria");
            }
        }
        private int _idCSTPis;
        [ParameterOrder(Order = 46)]
        public int idCSTPis
        {
            get { return _idCSTPis; }
            set
            {
                _idCSTPis = value;
                base.NotifyPropertyChanged(propertyName: "idCSTPis");
            }
        }
        private decimal? _COFINS_vBaseCalculo;
        [ParameterOrder(Order = 47)]
        public decimal? COFINS_vBaseCalculo
        {
            get { return _COFINS_vBaseCalculo; }
            set
            {
                _COFINS_vBaseCalculo = value;
                base.NotifyPropertyChanged(propertyName: "COFINS_vBaseCalculo");
            }
        }
        private decimal? _COFINS_pCOFINS;
        [ParameterOrder(Order = 48)]
        public decimal? COFINS_pCOFINS
        {
            get { return _COFINS_pCOFINS; }
            set
            {
                _COFINS_pCOFINS = value;
                base.NotifyPropertyChanged(propertyName: "COFINS_pCOFINS");
            }
        }
        private decimal? _COFINS_vCOFINS;
        [ParameterOrder(Order = 49)]
        public decimal? COFINS_vCOFINS
        {
            get { return _COFINS_vCOFINS; }
            set
            {
                _COFINS_vCOFINS = value;
                base.NotifyPropertyChanged(propertyName: "COFINS_vCOFINS");
            }
        }
        private decimal? _COFINS_nCoeficienteSubstituicaoTributaria;
        [ParameterOrder(Order = 50)]
        public decimal? COFINS_nCoeficienteSubstituicaoTributaria
        {
            get { return _COFINS_nCoeficienteSubstituicaoTributaria; }
            set
            {
                _COFINS_nCoeficienteSubstituicaoTributaria = value;
                base.NotifyPropertyChanged(propertyName: "COFINS_nCoeficienteSubstituicaoTributaria");
            }
        }
        private byte? _COFINS_stCompoeBaseCalculoSubstituicaoTributaria;
        [ParameterOrder(Order = 51)]
        public byte? COFINS_stCompoeBaseCalculoSubstituicaoTributaria
        {
            get { return _COFINS_stCompoeBaseCalculoSubstituicaoTributaria; }
            set
            {
                _COFINS_stCompoeBaseCalculoSubstituicaoTributaria = value;
                base.NotifyPropertyChanged(propertyName: "COFINS_stCompoeBaseCalculoSubstituicaoTributaria");
            }
        }
        private int _idCSTCofins;
        [ParameterOrder(Order = 52)]
        public int idCSTCofins
        {
            get { return _idCSTCofins; }
            set
            {
                _idCSTCofins = value;
                base.NotifyPropertyChanged(propertyName: "idCSTCofins");
            }
        }
        private byte? _ICMS_stNaoReduzBase;
        [ParameterOrder(Order = 53)]
        public byte? ICMS_stNaoReduzBase
        {
            get { return _ICMS_stNaoReduzBase; }
            set
            {
                _ICMS_stNaoReduzBase = value;
                base.NotifyPropertyChanged(propertyName: "ICMS_stNaoReduzBase");
            }
        }
    }

    public partial class Orcamento_Total_ImpostosModel : modelBase
    {
        public Orcamento_Total_ImpostosModel()
            : base(xTabela: "Orcamento_Total_Impostos")
        {
        }

        private int? _idOrcamentoTotalImpostos;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idOrcamentoTotalImpostos
        {
            get { return _idOrcamentoTotalImpostos; }
            set
            {
                _idOrcamentoTotalImpostos = value;
                base.NotifyPropertyChanged(propertyName: "idOrcamentoTotalImpostos");
            }
        }
        private decimal _vBaseCalculoIcmsTotal;
        [ParameterOrder(Order = 2)]
        public decimal vBaseCalculoIcmsTotal
        {
            get { return _vBaseCalculoIcmsTotal; }
            set
            {
                _vBaseCalculoIcmsTotal = value;
                base.NotifyPropertyChanged(propertyName: "vBaseCalculoIcmsTotal");
            }
        }
        private decimal _vICMSTotal;
        [ParameterOrder(Order = 3)]
        public decimal vICMSTotal
        {
            get { return _vICMSTotal; }
            set
            {
                _vICMSTotal = value;
                base.NotifyPropertyChanged(propertyName: "vICMSTotal");
            }
        }
        private decimal _vBaseCalculoICmsSubstituicaoTributariaTotal;
        [ParameterOrder(Order = 4)]
        public decimal vBaseCalculoICmsSubstituicaoTributariaTotal
        {
            get { return _vBaseCalculoICmsSubstituicaoTributariaTotal; }
            set
            {
                _vBaseCalculoICmsSubstituicaoTributariaTotal = value;
                base.NotifyPropertyChanged(propertyName: "vBaseCalculoICmsSubstituicaoTributariaTotal");
            }
        }
        private decimal _vIcmsSubstituicaoTributariaTotal;
        [ParameterOrder(Order = 5)]
        public decimal vIcmsSubstituicaoTributariaTotal
        {
            get { return _vIcmsSubstituicaoTributariaTotal; }
            set
            {
                _vIcmsSubstituicaoTributariaTotal = value;
                base.NotifyPropertyChanged(propertyName: "vIcmsSubstituicaoTributariaTotal");
            }
        }
        private decimal _vProdutoTotal;
        [ParameterOrder(Order = 6)]
        public decimal vProdutoTotal
        {
            get { return _vProdutoTotal; }
            set
            {
                _vProdutoTotal = value;
                base.NotifyPropertyChanged(propertyName: "vProdutoTotal");
            }
        }
        private decimal _vFreteTotal;
        [ParameterOrder(Order = 7)]
        public decimal vFreteTotal
        {
            get { return _vFreteTotal; }
            set
            {
                _vFreteTotal = value;
                base.NotifyPropertyChanged(propertyName: "vFreteTotal");
            }
        }
        private decimal _vSeguroTotal;
        [ParameterOrder(Order = 8)]
        public decimal vSeguroTotal
        {
            get { return _vSeguroTotal; }
            set
            {
                _vSeguroTotal = value;
                base.NotifyPropertyChanged(propertyName: "vSeguroTotal");
            }
        }
        private decimal _vDescontoTotal;
        [ParameterOrder(Order = 9)]
        public decimal vDescontoTotal
        {
            get { return _vDescontoTotal; }
            set
            {
                _vDescontoTotal = value;
                base.NotifyPropertyChanged(propertyName: "vDescontoTotal");
            }
        }
        private decimal _vIITotal;
        [ParameterOrder(Order = 10)]
        public decimal vIITotal
        {
            get { return _vIITotal; }
            set
            {
                _vIITotal = value;
                base.NotifyPropertyChanged(propertyName: "vIITotal");
            }
        }
        private decimal _vIPITotal;
        [ParameterOrder(Order = 11)]
        public decimal vIPITotal
        {
            get { return _vIPITotal; }
            set
            {
                _vIPITotal = value;
                base.NotifyPropertyChanged(propertyName: "vIPITotal");
            }
        }
        private decimal _vPISTotal;
        [ParameterOrder(Order = 12)]
        public decimal vPISTotal
        {
            get { return _vPISTotal; }
            set
            {
                _vPISTotal = value;
                base.NotifyPropertyChanged(propertyName: "vPISTotal");
            }
        }
        private decimal _vCOFINSTotal;
        [ParameterOrder(Order = 13)]
        public decimal vCOFINSTotal
        {
            get { return _vCOFINSTotal; }
            set
            {
                _vCOFINSTotal = value;
                base.NotifyPropertyChanged(propertyName: "vCOFINSTotal");
            }
        }
        private decimal _vOutrasDespesasTotal;
        [ParameterOrder(Order = 14)]
        public decimal vOutrasDespesasTotal
        {
            get { return _vOutrasDespesasTotal; }
            set
            {
                _vOutrasDespesasTotal = value;
                base.NotifyPropertyChanged(propertyName: "vOutrasDespesasTotal");
            }
        }
        private decimal _vTotal;
        [ParameterOrder(Order = 15)]
        public decimal vTotal
        {
            get { return _vTotal; }
            set
            {
                _vTotal = value;
                base.NotifyPropertyChanged(propertyName: "vTotal");
            }
        }
        private decimal _pDescontoTotal;
        [ParameterOrder(Order = 16)]
        public decimal pDescontoTotal
        {
            get { return _pDescontoTotal; }
            set
            {
                _pDescontoTotal = value;
                base.NotifyPropertyChanged(propertyName: "pDescontoTotal");
            }
        }
        private decimal? _vDescontoSuframaTotal;
        [ParameterOrder(Order = 17)]
        public decimal? vDescontoSuframaTotal
        {
            get { return _vDescontoSuframaTotal; }
            set
            {
                _vDescontoSuframaTotal = value;
                base.NotifyPropertyChanged(propertyName: "vDescontoSuframaTotal");
            }
        }
        private byte _stFrete;
        [ParameterOrder(Order = 18)]
        public byte stFrete
        {
            get { return _stFrete; }
            set
            {
                _stFrete = value;
                base.NotifyPropertyChanged(propertyName: "stFrete");
            }
        }
        private byte _stRateioFrete;
        [ParameterOrder(Order = 19)]
        public byte stRateioFrete
        {
            get { return _stRateioFrete; }
            set
            {
                _stRateioFrete = value;
                base.NotifyPropertyChanged(propertyName: "stRateioFrete");
            }
        }
        private decimal _vBaseCalculoIcmsProprioTotal;
        [ParameterOrder(Order = 20)]
        public decimal vBaseCalculoIcmsProprioTotal
        {
            get { return _vBaseCalculoIcmsProprioTotal; }
            set
            {
                _vBaseCalculoIcmsProprioTotal = value;
                base.NotifyPropertyChanged(propertyName: "vBaseCalculoIcmsProprioTotal");
            }
        }
        private decimal _vIcmsProprioTotal;
        [ParameterOrder(Order = 21)]
        public decimal vIcmsProprioTotal
        {
            get { return _vIcmsProprioTotal; }
            set
            {
                _vIcmsProprioTotal = value;
                base.NotifyPropertyChanged(propertyName: "vIcmsProprioTotal");
            }
        }
        private decimal _vBaseCalculoIpiTotal;
        [ParameterOrder(Order = 22)]
        public decimal vBaseCalculoIpiTotal
        {
            get { return _vBaseCalculoIpiTotal; }
            set
            {
                _vBaseCalculoIpiTotal = value;
                base.NotifyPropertyChanged(propertyName: "vBaseCalculoIpiTotal");
            }
        }
        private decimal _vBaseCalculoPisTotal;
        [ParameterOrder(Order = 23)]
        public decimal vBaseCalculoPisTotal
        {
            get { return _vBaseCalculoPisTotal; }
            set
            {
                _vBaseCalculoPisTotal = value;
                base.NotifyPropertyChanged(propertyName: "vBaseCalculoPisTotal");
            }
        }
        private decimal _vBaseCalculoCofinsTotal;
        [ParameterOrder(Order = 24)]
        public decimal vBaseCalculoCofinsTotal
        {
            get { return _vBaseCalculoCofinsTotal; }
            set
            {
                _vBaseCalculoCofinsTotal = value;
                base.NotifyPropertyChanged(propertyName: "vBaseCalculoCofinsTotal");
            }
        }
        private decimal _vBaseCalculoIssTotal;
        [ParameterOrder(Order = 25)]
        public decimal vBaseCalculoIssTotal
        {
            get { return _vBaseCalculoIssTotal; }
            set
            {
                _vBaseCalculoIssTotal = value;
                base.NotifyPropertyChanged(propertyName: "vBaseCalculoIssTotal");
            }
        }
        private decimal _vIssTotal;
        [ParameterOrder(Order = 26)]
        public decimal vIssTotal
        {
            get { return _vIssTotal; }
            set
            {
                _vIssTotal = value;
                base.NotifyPropertyChanged(propertyName: "vIssTotal");
            }
        }
        private int _idOrcamento;
        [ParameterOrder(Order = 27)]
        public int idOrcamento
        {
            get { return _idOrcamento; }
            set
            {
                _idOrcamento = value;
                base.NotifyPropertyChanged(propertyName: "idOrcamento");
            }
        }
        private decimal? _vServicoTotal;
        [ParameterOrder(Order = 28)]
        public decimal? vServicoTotal
        {
            get { return _vServicoTotal; }
            set
            {
                _vServicoTotal = value;
                base.NotifyPropertyChanged(propertyName: "vServicoTotal");
            }
        }
    }

    public partial class Orcamento_retTranspModel : modelBase
    {
        public Orcamento_retTranspModel()
            : base("Orcamento_retTransp")
        {
        }
        private int? _idRetTransp;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idRetTransp
        {
            get { return _idRetTransp; }
            set
            {
                _idRetTransp = value;
                base.NotifyPropertyChanged(propertyName: "idRetTransp");
            }
        }
        private decimal _vServ;
        [ParameterOrder(Order = 2)]
        public decimal vServ
        {
            get { return _vServ; }
            set
            {
                _vServ = value;
                base.NotifyPropertyChanged(propertyName: "vServ");
            }
        }
        private decimal _vBCRet;
        [ParameterOrder(Order = 3)]
        public decimal vBCRet
        {
            get { return _vBCRet; }
            set
            {
                _vBCRet = value;
                base.NotifyPropertyChanged(propertyName: "vBCRet");
            }
        }
        private decimal _pICMSRet;
        [ParameterOrder(Order = 4)]
        public decimal pICMSRet
        {
            get { return _pICMSRet; }
            set
            {
                _pICMSRet = value;
                base.NotifyPropertyChanged(propertyName: "pICMSRet");
            }
        }
        private decimal _vICMSRet;
        [ParameterOrder(Order = 5)]
        public decimal vICMSRet
        {
            get { return _vICMSRet; }
            set
            {
                _vICMSRet = value;
                base.NotifyPropertyChanged(propertyName: "vICMSRet");
            }
        }
        private int _CFOP;
        [ParameterOrder(Order = 6)]
        public int CFOP
        {
            get { return _CFOP; }
            set
            {
                _CFOP = value;
                base.NotifyPropertyChanged(propertyName: "CFOP");
            }
        }
        private int _cMunFG;
        [ParameterOrder(Order = 7)]
        public int cMunFG
        {
            get { return _cMunFG; }
            set
            {
                _cMunFG = value;
                base.NotifyPropertyChanged(propertyName: "cMunFG");
            }
        }
        private int _idOrcamento;
        [ParameterOrder(Order = 8)]
        public int idOrcamento
        {
            get { return _idOrcamento; }
            set
            {
                _idOrcamento = value;
                base.NotifyPropertyChanged(propertyName: "idOrcamento");
            }
        }
        private int? _idTransportador;
        [ParameterOrder(Order = 9)]
        public int? idTransportador
        {
            get { return _idTransportador; }
            set
            {
                _idTransportador = value;
                base.NotifyPropertyChanged(propertyName: "idTransportador");
            }
        }
        private int? _idRedespacho;
        [ParameterOrder(Order = 10)]
        public int? idRedespacho
        {
            get { return _idRedespacho; }
            set
            {
                _idRedespacho = value;
                base.NotifyPropertyChanged(propertyName: "idRedespacho");
            }
        }
        private byte _stFrete;
        [ParameterOrder(Order = 11)]
        public byte stFrete
        {
            get { return _stFrete; }
            set
            {
                _stFrete = value;
                base.NotifyPropertyChanged(propertyName: "stFrete");
            }
        }
        private decimal? _vPesoLiquido;
        [ParameterOrder(Order = 12)]
        public decimal? vPesoLiquido
        {
            get { return _vPesoLiquido; }
            set
            {
                _vPesoLiquido = value;
                base.NotifyPropertyChanged(propertyName: "vPesoLiquido");
            }
        }
        private decimal? _vPesoBruto;
        [ParameterOrder(Order = 13)]
        public decimal? vPesoBruto
        {
            get { return _vPesoBruto; }
            set
            {
                _vPesoBruto = value;
                base.NotifyPropertyChanged(propertyName: "vPesoBruto");
            }
        }
        private decimal? _vVolume;
        [ParameterOrder(Order = 14)]
        public decimal? vVolume
        {
            get { return _vVolume; }
            set
            {
                _vVolume = value;
                base.NotifyPropertyChanged(propertyName: "vVolume");
            }
        }
        private string _xEspecieVolumeNf;
        [ParameterOrder(Order = 15)]
        public string xEspecieVolumeNf
        {
            get { return _xEspecieVolumeNf; }
            set
            {
                _xEspecieVolumeNf = value;
                base.NotifyPropertyChanged(propertyName: "xEspecieVolumeNf");
            }
        }
        private string _xMarcaVolumeNf;
        [ParameterOrder(Order = 16)]
        public string xMarcaVolumeNf
        {
            get { return _xMarcaVolumeNf; }
            set
            {
                _xMarcaVolumeNf = value;
                base.NotifyPropertyChanged(propertyName: "xMarcaVolumeNf");
            }
        }
        private byte _stTransporte;
        [ParameterOrder(Order = 17)]
        public byte stTransporte
        {
            get { return _stTransporte; }
            set
            {
                _stTransporte = value;
                base.NotifyPropertyChanged(propertyName: "stTransporte");
            }
        }
    }

    #region Validações
    public partial class Orcamento_ideModel
    {
        public override string this[string columnName]
        {
            get
            {
                return base[columnName];
            }
        }
    }

    public partial class Orcamento_ItemModel
    {
        public override string this[string columnName]
        {
            get
            {
                string valid = base[columnName];

                if (valid == null)
                {
                    if (columnName == "pDesconto")
                    {
                        if (OrcamentoFacade.objCadastros.objListaPreco.lLista_preco != null)
                        {
                            HLP.Comum.Facade.Lista_PrecoService.Lista_precoModel objListaPrecoItem
                                    = OrcamentoFacade.objCadastros.objListaPreco.lLista_preco.
                                    FirstOrDefault(i => i.idProduto == this.idProduto);
                            if (objListaPrecoItem != null)
                            {
                                if (this.pDesconto < 0)
                                {
                                    if (this.pDesconto > objListaPrecoItem.pDescontoMaximo)
                                        valid = "% de desconto informada maior que a permitida('" + objListaPrecoItem.pDescontoMaximo + "')";
                                }
                                else
                                {
                                    if (this.pDesconto > objListaPrecoItem.pAcrescimoMaximo)
                                        valid = "% de acréscimo informada maior que a permitida('" + objListaPrecoItem.pAcrescimoMaximo + "')";
                                }
                            }
                        }
                    }
                }

                return valid;

            }
        }
    }

    public partial class Orcamento_Item_ImpostosModel
    {
        public override string this[string columnName]
        {
            get
            {
                return base[columnName];
            }
        }
    }

    public partial class Orcamento_Total_ImpostosModel
    {
        public override string this[string columnName]
        {
            get
            {
                return base[columnName];
            }
        }
    }

    public partial class Orcamento_retTranspModel
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
