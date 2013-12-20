using HLP.Comum.Infrastructure;
using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Resources.RecursosBases;

namespace HLP.Entries.Model.Models.Comercial
{
    public partial class Cliente_fornecedorModel : modelBase
    {
        public Cliente_fornecedorModel()
            : base(xTabela: "Cliente_fornecedor")
        {
            this.lCliente_fornecedor_arquivo = new ObservableCollectionBaseCadastros<Cliente_fornecedor_arquivoModel>();
            this.lCliente_fornecedor_contato = new ObservableCollectionBaseCadastros<Cliente_fornecedor_contatoModel>();
            this.lCliente_fornecedor_Endereco = new ObservableCollectionBaseCadastros<Cliente_fornecedor_EnderecoModel>();
            this.lCliente_Fornecedor_Observacao = new ObservableCollectionBaseCadastros<Cliente_Fornecedor_ObservacaoModel>();
            this.lCliente_fornecedor_produto = new ObservableCollectionBaseCadastros<Cliente_fornecedor_produtoModel>();
            this.lCliente_fornecedor_representante = new ObservableCollectionBaseCadastros<Cliente_fornecedor_representanteModel>();
            this.cliente_fornecedor_fiscal = new Cliente_fornecedor_fiscalModel();
            this.dCadastro = DateTime.Today;
        }

        private int? _idClienteFornecedor;

        [ParameterOrder(Order = 1)]
        public int? idClienteFornecedor
        {
            get { return _idClienteFornecedor; }
            set
            {
                _idClienteFornecedor = value;
                base.NotifyPropertyChanged(propertyName: "idClienteFornecedor");
            }
        }
        [ParameterOrder(Order = 2)]
        public int idEmpresa { get; set; }
        [ParameterOrder(Order = 3)]
        public string cAlternativo { get; set; }
        [ParameterOrder(Order = 4)]
        public byte stCatalogo { get; set; }
        [ParameterOrder(Order = 5)]
        public byte stPessoa { get; set; }
        [ParameterOrder(Order = 6)]
        public string xCnpj { get; set; }
        [ParameterOrder(Order = 7)]
        public string xIE { get; set; }
        [ParameterOrder(Order = 8)]
        public string xIm { get; set; }
        [ParameterOrder(Order = 9)]
        public string xNome { get; set; }
        [ParameterOrder(Order = 10)]
        public string xRg { get; set; }
        [ParameterOrder(Order = 11)]
        public string xFantasia { get; set; }
        [ParameterOrder(Order = 12)]
        public int idRamoAtividade { get; set; }
        [ParameterOrder(Order = 13)]
        public int idRota { get; set; }
        [ParameterOrder(Order = 14)]
        public DateTime dCadastro { get; set; }
        [ParameterOrder(Order = 15)]
        public string xTelefone1 { get; set; }
        [ParameterOrder(Order = 16)]
        public string xTelefone2 { get; set; }
        [ParameterOrder(Order = 17)]
        public string xFax { get; set; }
        [ParameterOrder(Order = 18)]
        public string xEmail { get; set; }
        [ParameterOrder(Order = 19)]
        public string xHttp { get; set; }
        private bool _Ativo = true;
        [ParameterOrder(Order = 20)]
        public bool Ativo
        {
            get { return _Ativo; }
            set { _Ativo = value; }
        }
        [ParameterOrder(Order = 21)]
        public string xMemorando { get; set; }
        [ParameterOrder(Order = 22)]
        public byte stCreditoAprovado { get; set; }
        [ParameterOrder(Order = 23)]
        public decimal vLimiteCredito { get; set; }
        [ParameterOrder(Order = 24)]
        public byte stLimiteCreditoObrigatorio { get; set; }
        [ParameterOrder(Order = 25)]
        public byte stFrete { get; set; }
        [ParameterOrder(Order = 26)]
        public int idCanalVenda { get; set; }
        [ParameterOrder(Order = 27)]
        public byte stExigeRelacaoProduto { get; set; }
        [ParameterOrder(Order = 28)]
        public int idListaPrecoPai { get; set; }
        [ParameterOrder(Order = 29)]
        public string xCpf { get; set; }
        [ParameterOrder(Order = 30)]
        public int idContaBancaria { get; set; }
        [ParameterOrder(Order = 31)]
        public int idMoeda { get; set; }
        [ParameterOrder(Order = 32)]
        public int idCondicaoPagamento { get; set; }
        [ParameterOrder(Order = 33)]
        public int? idFuncionario { get; set; }
        [ParameterOrder(Order = 34)]
        public byte stParado { get; set; }
        [ParameterOrder(Order = 35)]
        public int? nFuncionarios { get; set; }
        [ParameterOrder(Order = 36)]
        public byte stCategoria { get; set; }
        [ParameterOrder(Order = 37)]
        public string xSaudacao { get; set; }
        [ParameterOrder(Order = 38)]
        public string xApelido { get; set; }
        [ParameterOrder(Order = 39)]
        public byte? stEstadoCivil { get; set; }
        [ParameterOrder(Order = 40)]
        public DateTime? dDataNascimento { get; set; }
        [ParameterOrder(Order = 41)]
        public string xFilhos { get; set; }
        [ParameterOrder(Order = 42)]
        public string xConjugue { get; set; }
        [ParameterOrder(Order = 43)]
        public DateTime? dDataAdmissao { get; set; }
        [ParameterOrder(Order = 44)]
        public string xEmpresaTrabalha { get; set; }
        [ParameterOrder(Order = 45)]
        public string xTelefoneEmpresaTrabalha { get; set; }
        [ParameterOrder(Order = 46)]
        public string xLocalNascimento { get; set; }
        [ParameterOrder(Order = 47)]
        public string xUFNascimento { get; set; }
        [ParameterOrder(Order = 48)]
        public string xProfissao { get; set; }
        [ParameterOrder(Order = 49)]
        public string xNomePai { get; set; }
        [ParameterOrder(Order = 50)]
        public string xRGPai { get; set; }
        [ParameterOrder(Order = 51)]
        public string xCPFPai { get; set; }
        [ParameterOrder(Order = 52)]
        public string xNomeMae { get; set; }
        [ParameterOrder(Order = 53)]
        public string xRGMae { get; set; }
        [ParameterOrder(Order = 54)]
        public string xCPFMae { get; set; }
        [ParameterOrder(Order = 55)]
        public byte? stResidencia { get; set; }
        [ParameterOrder(Order = 56)]
        public string xPontoReferenciaResidencia { get; set; }
        [ParameterOrder(Order = 57)]
        public decimal? vSalario { get; set; }
        [ParameterOrder(Order = 58)]
        public string xCPFConjugue { get; set; }
        [ParameterOrder(Order = 59)]
        public string xRGConjugue { get; set; }
        [ParameterOrder(Order = 60)]
        public string xProfissaoConjugue { get; set; }
        [ParameterOrder(Order = 61)]
        public string xEmpresaConjugue { get; set; }
        [ParameterOrder(Order = 62)]
        public string xInformacaoComercialNome1 { get; set; }
        [ParameterOrder(Order = 63)]
        public string xInformacaoComercialNome2 { get; set; }
        [ParameterOrder(Order = 64)]
        public string xInformacaoComercialNome3 { get; set; }
        [ParameterOrder(Order = 65)]
        public string xInformacaoComercialTelefone1 { get; set; }
        [ParameterOrder(Order = 66)]
        public string xInformacaoComercialTelefone2 { get; set; }
        [ParameterOrder(Order = 67)]
        public string xInformacaoComercialTelefone3 { get; set; }
        [ParameterOrder(Order = 68)]
        public DateTime? dInformacaoComercialClienteDesde1 { get; set; }
        [ParameterOrder(Order = 69)]
        public DateTime? dInformacaoComercialClienteDesde2 { get; set; }
        [ParameterOrder(Order = 70)]
        public DateTime? dInformacaoComercialClienteDesde3 { get; set; }
        [ParameterOrder(Order = 71)]
        public decimal? vInformacaoComercialMaiorCompra1 { get; set; }
        [ParameterOrder(Order = 72)]
        public decimal? vInformacaoComercialMaiorCompra2 { get; set; }
        [ParameterOrder(Order = 73)]
        public decimal? vInformacaoComercialMaiorCompra3 { get; set; }
        [ParameterOrder(Order = 74)]
        public DateTime? dInformacaoComercialUltimaCompra1 { get; set; }
        [ParameterOrder(Order = 75)]
        public DateTime? dInformacaoComercialUltimaCompra2 { get; set; }
        [ParameterOrder(Order = 76)]
        public DateTime? dInformacaoComercialUltimaCompra3 { get; set; }
        [ParameterOrder(Order = 77)]
        public string xInformacaoComercialInformante1 { get; set; }
        [ParameterOrder(Order = 78)]
        public string xInformacaoComercialInformante2 { get; set; }
        [ParameterOrder(Order = 79)]
        public string xInformacaoComercialInformante3 { get; set; }
        [ParameterOrder(Order = 80)]
        public decimal? vSalarioConjugue { get; set; }
        [ParameterOrder(Order = 81)]
        public byte? stSexo { get; set; }
        [ParameterOrder(Order = 82)]
        public int idCondicaoEntrega { get; set; }
        [ParameterOrder(Order = 83)]
        public int? idModosEntrega { get; set; }
        [ParameterOrder(Order = 84)]
        public int? idCalendario { get; set; }
        [ParameterOrder(Order = 85)]
        public int? idTipoDocumento { get; set; }
        [ParameterOrder(Order = 86)]
        public int? idSite { get; set; }
        [ParameterOrder(Order = 87)]
        public int? idDeposito { get; set; }
        [ParameterOrder(Order = 88)]
        public int? idDescontos { get; set; }
        [ParameterOrder(Order = 89)]
        public int? idPlanoPagamento { get; set; }
        [ParameterOrder(Order = 90)]
        public int? idDiaPagamento { get; set; }
        [ParameterOrder(Order = 91)]
        public int? idJuros { get; set; }
        [ParameterOrder(Order = 92)]
        public byte stMostraProdutosRelacionado { get; set; }
        [ParameterOrder(Order = 93)]
        public int? idTransportador { get; set; }
        [ParameterOrder(Order = 94)]
        public byte? stSpc { get; set; }
        [ParameterOrder(Order = 95)]
        public byte? stSituacaoSci { get; set; }
        [ParameterOrder(Order = 96)]
        public byte? stAssociacaoComercial { get; set; }
        [ParameterOrder(Order = 97)]
        public int? idMultas { get; set; }
        [ParameterOrder(Order = 98)]
        public byte? stObrigaListaPreco { get; set; }


        
        private ObservableCollectionBaseCadastros<Cliente_Fornecedor_ObservacaoModel> _lCliente_Fornecedor_Observacao;

        public ObservableCollectionBaseCadastros<Cliente_Fornecedor_ObservacaoModel> lCliente_Fornecedor_Observacao
        {
            get { return _lCliente_Fornecedor_Observacao; }
            set
            {
                _lCliente_Fornecedor_Observacao = value;
                base.NotifyPropertyChanged(propertyName: "lCliente_Fornecedor_Observacao");
            }
        }


        
        private ObservableCollectionBaseCadastros<Cliente_fornecedor_representanteModel> _lCliente_fornecedor_representante;

        public ObservableCollectionBaseCadastros<Cliente_fornecedor_representanteModel> lCliente_fornecedor_representante
        {
            get { return _lCliente_fornecedor_representante; }
            set
            {
                _lCliente_fornecedor_representante = value;
                base.NotifyPropertyChanged(propertyName: "lCliente_fornecedor_representante");
            }
        }


        
        private ObservableCollectionBaseCadastros<Cliente_fornecedor_EnderecoModel> _lCliente_fornecedor_Endereco;

        public ObservableCollectionBaseCadastros<Cliente_fornecedor_EnderecoModel> lCliente_fornecedor_Endereco
        {
            get { return _lCliente_fornecedor_Endereco; }
            set
            {
                _lCliente_fornecedor_Endereco = value;
                base.NotifyPropertyChanged(propertyName: "lCliente_fornecedor_Endereco");
            }
        }

        
        private ObservableCollectionBaseCadastros<Cliente_fornecedor_contatoModel> _lCliente_fornecedor_contato;

        public ObservableCollectionBaseCadastros<Cliente_fornecedor_contatoModel> lCliente_fornecedor_contato
        {
            get { return _lCliente_fornecedor_contato; }
            set
            {
                _lCliente_fornecedor_contato = value;
                base.NotifyPropertyChanged(propertyName: "lCliente_fornecedor_contato");
            }
        }

        
        private ObservableCollectionBaseCadastros<Cliente_fornecedor_arquivoModel> _lCliente_fornecedor_arquivo;

        public ObservableCollectionBaseCadastros<Cliente_fornecedor_arquivoModel> lCliente_fornecedor_arquivo
        {
            get { return _lCliente_fornecedor_arquivo; }
            set
            {
                _lCliente_fornecedor_arquivo = value;
                base.NotifyPropertyChanged(propertyName: "lCliente_fornecedor_arquivo");
            }
        }

        
        private ObservableCollectionBaseCadastros<Cliente_fornecedor_produtoModel> _lCliente_fornecedor_produto;

        public ObservableCollectionBaseCadastros<Cliente_fornecedor_produtoModel> lCliente_fornecedor_produto
        {
            get { return _lCliente_fornecedor_produto; }
            set
            {
                _lCliente_fornecedor_produto = value;
                base.NotifyPropertyChanged(propertyName: "lCliente_fornecedor_produto");
            }
        }

        
        private Cliente_fornecedor_fiscalModel _cliente_fornecedor_fiscal;

        public Cliente_fornecedor_fiscalModel cliente_fornecedor_fiscal
        {
            get { return _cliente_fornecedor_fiscal; }
            set
            {
                _cliente_fornecedor_fiscal = value;
                base.NotifyPropertyChanged(propertyName: "cliente_fornecedor_fiscal");
            }
        }
        
    }

    public partial class Cliente_fornecedor_representanteModel : modelBase
    {
        public Cliente_fornecedor_representanteModel()
            : base(xTabela: "Cliente_fornecedor_representante")
        {
        }
        private int? _idClienteFornecedorRepresentante;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idClienteFornecedorRepresentante
        {
            get { return _idClienteFornecedorRepresentante; }
            set
            {
                _idClienteFornecedorRepresentante = value;
                base.NotifyPropertyChanged(propertyName: "idClienteFornecedorRepresentante");
            }
        }
        private decimal _pComissaoAvista;
        [ParameterOrder(Order = 2)]
        public decimal pComissaoAvista
        {
            get { return _pComissaoAvista; }
            set
            {
                _pComissaoAvista = value;
                base.NotifyPropertyChanged(propertyName: "pComissaoAvista");
            }
        }
        private decimal _pComissaoAprazo;
        [ParameterOrder(Order = 3)]
        public decimal pComissaoAprazo
        {
            get { return _pComissaoAprazo; }
            set
            {
                _pComissaoAprazo = value;
                base.NotifyPropertyChanged(propertyName: "pComissaoAprazo");
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
    }

    public partial class Cliente_fornecedor_produtoModel : modelBase
    {
        public Cliente_fornecedor_produtoModel()
            : base(xTabela: "Cliente_fornecedor_produto")
        {
        }
        private int? _idClienteFornecedorProduto;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idClienteFornecedorProduto
        {
            get { return _idClienteFornecedorProduto; }
            set
            {
                _idClienteFornecedorProduto = value;
                base.NotifyPropertyChanged(propertyName: "idClienteFornecedorProduto");
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
        private int _idListaPrecoPai;
        [ParameterOrder(Order = 3)]
        public int idListaPrecoPai
        {
            get { return _idListaPrecoPai; }
            set
            {
                _idListaPrecoPai = value;
                base.NotifyPropertyChanged(propertyName: "idListaPrecoPai");
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
        private byte _stObrigaListaPreco;
        [ParameterOrder(Order = 5)]
        public byte stObrigaListaPreco
        {
            get { return _stObrigaListaPreco; }
            set
            {
                _stObrigaListaPreco = value;
                base.NotifyPropertyChanged(propertyName: "stObrigaListaPreco");
            }
        }
    }

    public partial class Cliente_Fornecedor_ObservacaoModel : modelBase
    {
        public Cliente_Fornecedor_ObservacaoModel()
            : base(xTabela: "Cliente_Fornecedor_Observacao")
        {
        }
        private int? _idClienteFornecedorObservacao;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idClienteFornecedorObservacao
        {
            get { return _idClienteFornecedorObservacao; }
            set
            {
                _idClienteFornecedorObservacao = value;
                base.NotifyPropertyChanged(propertyName: "idClienteFornecedorObservacao");
            }
        }
        private string _xObservacao;
        [ParameterOrder(Order = 2)]
        public string xObservacao
        {
            get { return _xObservacao; }
            set
            {
                _xObservacao = value;
                base.NotifyPropertyChanged(propertyName: "xObservacao");
            }
        }
        private int? _idClienteFornecedor;
        [ParameterOrder(Order = 3)]
        public int? idClienteFornecedor
        {
            get { return _idClienteFornecedor; }
            set
            {
                _idClienteFornecedor = value;
                base.NotifyPropertyChanged(propertyName: "idClienteFornecedor");
            }
        }
    }

    public partial class Cliente_fornecedor_fiscalModel : modelBase
    {
        public Cliente_fornecedor_fiscalModel()
            : base(xTabela: "Cliente_fornecedor_fiscal")
        {
        }
        private int? _idClienteFornecedorFiscal;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idClienteFornecedorFiscal
        {
            get { return _idClienteFornecedorFiscal; }
            set
            {
                _idClienteFornecedorFiscal = value;
                base.NotifyPropertyChanged(propertyName: "idClienteFornecedorFiscal");
            }
        }
        private byte _stSimplesNacional;
        [ParameterOrder(Order = 2)]
        public byte stSimplesNacional
        {
            get { return _stSimplesNacional; }
            set
            {
                _stSimplesNacional = value;
                base.NotifyPropertyChanged(propertyName: "stSimplesNacional");
            }
        }
        private byte _stProdutorRural;
        [ParameterOrder(Order = 3)]
        public byte stProdutorRural
        {
            get { return _stProdutorRural; }
            set
            {
                _stProdutorRural = value;
                base.NotifyPropertyChanged(propertyName: "stProdutorRural");
            }
        }
        private byte _stExportador;
        [ParameterOrder(Order = 4)]
        public byte stExportador
        {
            get { return _stExportador; }
            set
            {
                _stExportador = value;
                base.NotifyPropertyChanged(propertyName: "stExportador");
            }
        }
        private byte _stCooperativaAgricola;
        [ParameterOrder(Order = 5)]
        public byte stCooperativaAgricola
        {
            get { return _stCooperativaAgricola; }
            set
            {
                _stCooperativaAgricola = value;
                base.NotifyPropertyChanged(propertyName: "stCooperativaAgricola");
            }
        }
        private byte _stDescontaIcmsSuframa;
        [ParameterOrder(Order = 6)]
        public byte stDescontaIcmsSuframa
        {
            get { return _stDescontaIcmsSuframa; }
            set
            {
                _stDescontaIcmsSuframa = value;
                base.NotifyPropertyChanged(propertyName: "stDescontaIcmsSuframa");
            }
        }
        private decimal _pDescontaIcmsSuframa;
        [ParameterOrder(Order = 7)]
        public decimal pDescontaIcmsSuframa
        {
            get { return _pDescontaIcmsSuframa; }
            set
            {
                _pDescontaIcmsSuframa = value;
                base.NotifyPropertyChanged(propertyName: "pDescontaIcmsSuframa");
            }
        }
        private byte _stDescontaPisCofinsSuframa;
        [ParameterOrder(Order = 8)]
        public byte stDescontaPisCofinsSuframa
        {
            get { return _stDescontaPisCofinsSuframa; }
            set
            {
                _stDescontaPisCofinsSuframa = value;
                base.NotifyPropertyChanged(propertyName: "stDescontaPisCofinsSuframa");
            }
        }
        private decimal _pDescontaPisSuframa;
        [ParameterOrder(Order = 9)]
        public decimal pDescontaPisSuframa
        {
            get { return _pDescontaPisSuframa; }
            set
            {
                _pDescontaPisSuframa = value;
                base.NotifyPropertyChanged(propertyName: "pDescontaPisSuframa");
            }
        }
        private decimal _pDescontaCofinsSuframa;
        [ParameterOrder(Order = 10)]
        public decimal pDescontaCofinsSuframa
        {
            get { return _pDescontaCofinsSuframa; }
            set
            {
                _pDescontaCofinsSuframa = value;
                base.NotifyPropertyChanged(propertyName: "pDescontaCofinsSuframa");
            }
        }
        private string _xCodigoSuframa;
        [ParameterOrder(Order = 11)]
        public string xCodigoSuframa
        {
            get { return _xCodigoSuframa; }
            set
            {
                _xCodigoSuframa = value;
                base.NotifyPropertyChanged(propertyName: "xCodigoSuframa");
            }
        }
        private byte _stCalculaFunrural;
        [ParameterOrder(Order = 12)]
        public byte stCalculaFunrural
        {
            get { return _stCalculaFunrural; }
            set
            {
                _stCalculaFunrural = value;
                base.NotifyPropertyChanged(propertyName: "stCalculaFunrural");
            }
        }
        private decimal _pFunrural;
        [ParameterOrder(Order = 13)]
        public decimal pFunrural
        {
            get { return _pFunrural; }
            set
            {
                _pFunrural = value;
                base.NotifyPropertyChanged(propertyName: "pFunrural");
            }
        }
        private string _xCodigoSuspensaoPisCofins;
        [ParameterOrder(Order = 14)]
        public string xCodigoSuspensaoPisCofins
        {
            get { return _xCodigoSuspensaoPisCofins; }
            set
            {
                _xCodigoSuspensaoPisCofins = value;
                base.NotifyPropertyChanged(propertyName: "xCodigoSuspensaoPisCofins");
            }
        }
        private byte _stRetemIss;
        [ParameterOrder(Order = 15)]
        public byte stRetemIss
        {
            get { return _stRetemIss; }
            set
            {
                _stRetemIss = value;
                base.NotifyPropertyChanged(propertyName: "stRetemIss");
            }
        }
        private byte _stRetemCsll;
        [ParameterOrder(Order = 16)]
        public byte stRetemCsll
        {
            get { return _stRetemCsll; }
            set
            {
                _stRetemCsll = value;
                base.NotifyPropertyChanged(propertyName: "stRetemCsll");
            }
        }
        private byte _stRetemInss;
        [ParameterOrder(Order = 17)]
        public byte stRetemInss
        {
            get { return _stRetemInss; }
            set
            {
                _stRetemInss = value;
                base.NotifyPropertyChanged(propertyName: "stRetemInss");
            }
        }
        private byte _stRetemPisCofins;
        [ParameterOrder(Order = 18)]
        public byte stRetemPisCofins
        {
            get { return _stRetemPisCofins; }
            set
            {
                _stRetemPisCofins = value;
                base.NotifyPropertyChanged(propertyName: "stRetemPisCofins");
            }
        }
        private byte _stRetemIrrf;
        [ParameterOrder(Order = 19)]
        public byte stRetemIrrf
        {
            get { return _stRetemIrrf; }
            set
            {
                _stRetemIrrf = value;
                base.NotifyPropertyChanged(propertyName: "stRetemIrrf");
            }
        }
        private byte _stConsumidorFinal;
        [ParameterOrder(Order = 20)]
        public byte stConsumidorFinal
        {
            get { return _stConsumidorFinal; }
            set
            {
                _stConsumidorFinal = value;
                base.NotifyPropertyChanged(propertyName: "stConsumidorFinal");
            }
        }
        private byte _stContribuienteIcms;
        [ParameterOrder(Order = 21)]
        public byte stContribuienteIcms
        {
            get { return _stContribuienteIcms; }
            set
            {
                _stContribuienteIcms = value;
                base.NotifyPropertyChanged(propertyName: "stContribuienteIcms");
            }
        }
        private byte _stSubsticaoTributariaIcmsDiferenciada;
        [ParameterOrder(Order = 22)]
        public byte stSubsticaoTributariaIcmsDiferenciada
        {
            get { return _stSubsticaoTributariaIcmsDiferenciada; }
            set
            {
                _stSubsticaoTributariaIcmsDiferenciada = value;
                base.NotifyPropertyChanged(propertyName: "stSubsticaoTributariaIcmsDiferenciada");
            }
        }
        private int _idClienteFornecedor;
        [ParameterOrder(Order = 23)]
        public int idClienteFornecedor
        {
            get { return _idClienteFornecedor; }
            set
            {
                _idClienteFornecedor = value;
                base.NotifyPropertyChanged(propertyName: "idClienteFornecedor");
            }
        }
        private byte _stCalculaIcms;
        [ParameterOrder(Order = 24)]
        public byte stCalculaIcms
        {
            get { return _stCalculaIcms; }
            set
            {
                _stCalculaIcms = value;
                base.NotifyPropertyChanged(propertyName: "stCalculaIcms");
            }
        }
        private byte _stCalculaIpi;
        [ParameterOrder(Order = 25)]
        public byte stCalculaIpi
        {
            get { return _stCalculaIpi; }
            set
            {
                _stCalculaIpi = value;
                base.NotifyPropertyChanged(propertyName: "stCalculaIpi");
            }
        }
        private byte? _stZeraIcms;
        [ParameterOrder(Order = 26)]
        public byte? stZeraIcms
        {
            get { return _stZeraIcms; }
            set
            {
                _stZeraIcms = value;
                base.NotifyPropertyChanged(propertyName: "stZeraIcms");
            }
        }
    }

    public partial class Cliente_fornecedor_EnderecoModel : modelBase
    {
        public Cliente_fornecedor_EnderecoModel()
            : base(xTabela: "Cliente_Fornecedor_Endereco")
        {
        }
        private int? _idEndereco;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idEndereco
        {
            get { return _idEndereco; }
            set
            {
                _idEndereco = value;
                base.NotifyPropertyChanged(propertyName: "idEndereco");
            }
        }
        private byte? _stPrincipal;
        [ParameterOrder(Order = 2)]
        public byte? stPrincipal
        {
            get { return _stPrincipal; }
            set
            {
                _stPrincipal = value;
                base.NotifyPropertyChanged(propertyName: "stPrincipal");
            }
        }
        private string _xNome;
        [ParameterOrder(Order = 3)]
        public string xNome
        {
            get { return _xNome; }
            set
            {
                _xNome = value;
                base.NotifyPropertyChanged(propertyName: "xNome");
            }
        }




        private TipoEndereco _enumTipoEndereco;
        public TipoEndereco enumTipoEndereco
        {
            get { return _enumTipoEndereco; }
            set
            {
                _enumTipoEndereco = value;
                _stTipoEndereco = (byte)value;
            }
        }

        private byte _stTipoEndereco;
        [ParameterOrder(Order = 4)]
        public byte stTipoEndereco
        {
            get { return _stTipoEndereco; }
            set
            {
                _stTipoEndereco = value;
                _enumTipoEndereco = (TipoEndereco)value;
            }
        }



        private string _xCEP;
        [ParameterOrder(Order = 5)]
        public string xCEP
        {
            get { return _xCEP; }
            set
            {
                _xCEP = value;
                base.NotifyPropertyChanged(propertyName: "xCEP");
            }
        }
        private TipoLogradouro _enumTipoLogradouro;
        public TipoLogradouro enumTipoLogradouro
        {
            get { return _enumTipoLogradouro; }
            set
            {
                _enumTipoLogradouro = value;
                _stLogradouro = (byte)value;
            }
        }

        private byte _stLogradouro;
        [ParameterOrder(Order = 6)]
        public byte stLogradouro
        {
            get { return _stLogradouro; }
            set
            {
                _stLogradouro = value;
                _enumTipoLogradouro = (TipoLogradouro)value;
            }
        }






        private string _xEndereco;
        [ParameterOrder(Order = 7)]
        public string xEndereco
        {
            get { return _xEndereco; }
            set
            {
                _xEndereco = value;
                base.NotifyPropertyChanged(propertyName: "xEndereco");
            }
        }
        private string _nNumero;
        [ParameterOrder(Order = 8)]
        public string nNumero
        {
            get { return _nNumero; }
            set
            {
                _nNumero = value;
                base.NotifyPropertyChanged(propertyName: "nNumero");
            }
        }
        private string _xComplemento;
        [ParameterOrder(Order = 9)]
        public string xComplemento
        {
            get { return _xComplemento; }
            set
            {
                _xComplemento = value;
                base.NotifyPropertyChanged(propertyName: "xComplemento");
            }
        }
        private string _xBairro;
        [ParameterOrder(Order = 10)]
        public string xBairro
        {
            get { return _xBairro; }
            set
            {
                _xBairro = value;
                base.NotifyPropertyChanged(propertyName: "xBairro");
            }
        }
        private string _xLatitude;
        [ParameterOrder(Order = 11)]
        public string xLatitude
        {
            get { return _xLatitude; }
            set
            {
                _xLatitude = value;
                base.NotifyPropertyChanged(propertyName: "xLatitude");
            }
        }
        private string _xLongitude;
        [ParameterOrder(Order = 12)]
        public string xLongitude
        {
            get { return _xLongitude; }
            set
            {
                _xLongitude = value;
                base.NotifyPropertyChanged(propertyName: "xLongitude");
            }
        }
        private string _xFusoHorario;
        [ParameterOrder(Order = 13)]
        public string xFusoHorario
        {
            get { return _xFusoHorario; }
            set
            {
                _xFusoHorario = value;
                base.NotifyPropertyChanged(propertyName: "xFusoHorario");
            }
        }
        private string _xCaixaPostal;
        [ParameterOrder(Order = 14)]
        public string xCaixaPostal
        {
            get { return _xCaixaPostal; }
            set
            {
                _xCaixaPostal = value;
                base.NotifyPropertyChanged(propertyName: "xCaixaPostal");
            }
        }
        private int _idClienteFornecedor;
        [ParameterOrder(Order = 15)]
        public int idClienteFornecedor
        {
            get { return _idClienteFornecedor; }
            set
            {
                _idClienteFornecedor = value;
                base.NotifyPropertyChanged(propertyName: "idClienteFornecedor");
            }
        }
        private int _idCidade;
        [ParameterOrder(Order = 16)]
        public int idCidade
        {
            get { return _idCidade; }
            set
            {
                _idCidade = value;
                base.NotifyPropertyChanged(propertyName: "idCidade");
            }
        }
    }

    public partial class Cliente_fornecedor_contatoModel : modelBase
    {
        public Cliente_fornecedor_contatoModel()
            : base(xTabela: "Cliente_fornecedor_contato")
        {
        }
        private int? _idClienteFornecedorContato;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idClienteFornecedorContato
        {
            get { return _idClienteFornecedorContato; }
            set
            {
                _idClienteFornecedorContato = value;
                base.NotifyPropertyChanged(propertyName: "idClienteFornecedorContato");
            }
        }
        private int _idContato;
        [ParameterOrder(Order = 2)]
        public int idContato
        {
            get { return _idContato; }
            set
            {
                _idContato = value;
                base.NotifyPropertyChanged(propertyName: "idContato");
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
                base.NotifyPropertyChanged(propertyName: "idClienteFornecedor");
            }
        }

    }

    public partial class Cliente_fornecedor_arquivoModel : modelBase
    {
        public Cliente_fornecedor_arquivoModel()
            : base(xTabela: "Cliente_Fornecedor_Arquivo")
        {
        }
        private int? _idClienteFornecedorArquivo;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idClienteFornecedorArquivo
        {
            get { return _idClienteFornecedorArquivo; }
            set
            {
                _idClienteFornecedorArquivo = value;
                base.NotifyPropertyChanged(propertyName: "idClienteFornecedorArquivo");
            }
        }
        private string _xArquivo;
        [ParameterOrder(Order = 2)]
        public string xArquivo
        {
            get { return _xArquivo; }
            set
            {
                _xArquivo = value;
                base.NotifyPropertyChanged(propertyName: "xArquivo");
            }
        }
        private string _xLinkArquivo;
        [ParameterOrder(Order = 3)]
        public string xLinkArquivo
        {
            get { return _xLinkArquivo; }
            set
            {
                _xLinkArquivo = value;
                base.NotifyPropertyChanged(propertyName: "xLinkArquivo");
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

    }

    #region Validações
    public partial class Cliente_fornecedorModel
    {
        public override string this[string columnName]
        {
            get
            {
                return base[columnName];
            }
        }
    }

    public partial class Cliente_fornecedor_representanteModel
    {
        public override string this[string columnName]
        {
            get
            {
                return base[columnName];
            }
        }
    }

    public partial class Cliente_fornecedor_produtoModel
    {
        public override string this[string columnName]
        {
            get
            {
                return base[columnName];
            }
        }
    }

    public partial class Cliente_Fornecedor_ObservacaoModel
    {
        public override string this[string columnName]
        {
            get
            {
                return base[columnName];
            }
        }
    }

    public partial class Cliente_fornecedor_fiscalModel
    {
        public override string this[string columnName]
        {
            get
            {
                return base[columnName];
            }
        }
    }

    public partial class Cliente_fornecedor_EnderecoModel
    {
        public override string this[string columnName]
        {
            get
            {
                return base[columnName];
            }
        }
    }

    public partial class Cliente_fornecedor_contatoModel
    {
        public override string this[string columnName]
        {
            get
            {
                return base[columnName];
            }
        }
    }

    public partial class Cliente_fornecedor_arquivoModel
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
