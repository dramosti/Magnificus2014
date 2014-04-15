using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Resources.RecursosBases;
using HLP.Base.ClassesBases;
using HLP.Base.Static;
using System.Windows;
using System.Reflection;
using System.Windows.Threading;
using HLP.Entries.Model.Models.Gerais;

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
            this.enabledFieldsCondPagamento = true;
        }

        #region Propriedades não mapiadas

        private bool _enabledFieldsCondPagamento;
        public bool enabledFieldsCondPagamento
        {
            get { return _enabledFieldsCondPagamento; }
            set
            {
                _enabledFieldsCondPagamento = value;
                base.NotifyPropertyChanged(propertyName: "enabledFieldsCondPagamento");
            }
        }

        #endregion

        private int? _idClienteFornecedor;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idClienteFornecedor
        {
            get { return _idClienteFornecedor; }
            set
            {
                _idClienteFornecedor = value;
                base.NotifyPropertyChanged(propertyName: "idClienteFornecedor");
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
        private string _cAlternativo;
        [ParameterOrder(Order = 3)]
        public string cAlternativo
        {
            get { return _cAlternativo; }
            set
            {
                _cAlternativo = value;
                base.NotifyPropertyChanged(propertyName: "cAlternativo");
            }
        }
        private byte _stCatalogo;
        [ParameterOrder(Order = 4)]
        public byte stCatalogo
        {
            get { return _stCatalogo; }
            set
            {
                _stCatalogo = value;
                base.NotifyPropertyChanged(propertyName: "stCatalogo");
            }
        }
        private byte _stPessoa;
        [ParameterOrder(Order = 5)]
        public byte stPessoa
        {
            get { return _stPessoa; }
            set
            {
                _stPessoa = value;
                base.NotifyPropertyChanged(propertyName: "stPessoa");
            }
        }
        private string _xCnpj;
        [ParameterOrder(Order = 6)]
        public string xCnpj
        {
            get { return _xCnpj; }
            set
            {
                _xCnpj = value;
                base.NotifyPropertyChanged(propertyName: "xCnpj");
            }
        }
        private string _xIE;
        [ParameterOrder(Order = 7)]
        public string xIE
        {
            get { return _xIE; }
            set
            {
                _xIE = value;
                base.NotifyPropertyChanged(propertyName: "xIE");
            }
        }
        private string _xIm;
        [ParameterOrder(Order = 8)]
        public string xIm
        {
            get { return _xIm; }
            set
            {
                _xIm = value;
                base.NotifyPropertyChanged(propertyName: "xIm");
            }
        }
        private string _xNome;
        [ParameterOrder(Order = 9)]
        public string xNome
        {
            get { return _xNome; }
            set
            {
                _xNome = value;
                base.NotifyPropertyChanged(propertyName: "xNome");
            }
        }
        private string _xRg;
        [ParameterOrder(Order = 10)]
        public string xRg
        {
            get { return _xRg; }
            set
            {
                _xRg = value;
                base.NotifyPropertyChanged(propertyName: "xRg");
            }
        }
        private string _xFantasia;
        [ParameterOrder(Order = 11)]
        public string xFantasia
        {
            get { return _xFantasia; }
            set
            {
                _xFantasia = value;
                base.NotifyPropertyChanged(propertyName: "xFantasia");
            }
        }
        private int _idRamoAtividade;
        [ParameterOrder(Order = 12)]
        public int idRamoAtividade
        {
            get { return _idRamoAtividade; }
            set
            {
                _idRamoAtividade = value;
                base.NotifyPropertyChanged(propertyName: "idRamoAtividade");
            }
        }
        private int? _idRota;
        [ParameterOrder(Order = 13)]
        public int? idRota
        {
            get { return _idRota; }
            set
            {
                _idRota = value;
                base.NotifyPropertyChanged(propertyName: "idRota");
            }
        }
        private DateTime _dCadastro;
        [ParameterOrder(Order = 14)]
        public DateTime dCadastro
        {
            get { return _dCadastro; }
            set
            {
                _dCadastro = value;
                base.NotifyPropertyChanged(propertyName: "dCadastro");
            }
        }
        private string _xTelefone1;
        [ParameterOrder(Order = 15)]
        public string xTelefone1
        {
            get { return _xTelefone1; }
            set
            {
                _xTelefone1 = value;
                base.NotifyPropertyChanged(propertyName: "xTelefone1");
            }
        }
        private string _xTelefone2;
        [ParameterOrder(Order = 16)]
        public string xTelefone2
        {
            get { return _xTelefone2; }
            set
            {
                _xTelefone2 = value;
                base.NotifyPropertyChanged(propertyName: "xTelefone2");
            }
        }
        private string _xFax;
        [ParameterOrder(Order = 17)]
        public string xFax
        {
            get { return _xFax; }
            set
            {
                _xFax = value;
                base.NotifyPropertyChanged(propertyName: "xFax");
            }
        }
        private string _xEmail;
        [ParameterOrder(Order = 18)]
        public string xEmail
        {
            get { return _xEmail; }
            set
            {
                _xEmail = value;
                base.NotifyPropertyChanged(propertyName: "xEmail");
            }
        }
        private string _xHttp;
        [ParameterOrder(Order = 19)]
        public string xHttp
        {
            get { return _xHttp; }
            set
            {
                _xHttp = value;
                base.NotifyPropertyChanged(propertyName: "xHttp");
            }
        }
        private bool _Ativo;
        [ParameterOrder(Order = 20)]
        public bool Ativo
        {
            get { return _Ativo; }
            set
            {
                _Ativo = value;
                base.NotifyPropertyChanged(propertyName: "Ativo");
            }
        }
        private string _xMemorando;
        [ParameterOrder(Order = 21)]
        public string xMemorando
        {
            get { return _xMemorando; }
            set
            {
                _xMemorando = value;
                base.NotifyPropertyChanged(propertyName: "xMemorando");
            }
        }
        private byte _stCreditoAprovado;
        [ParameterOrder(Order = 22)]
        public byte stCreditoAprovado
        {
            get { return _stCreditoAprovado; }
            set
            {
                _stCreditoAprovado = value;
                base.NotifyPropertyChanged(propertyName: "stCreditoAprovado");
            }
        }
        private decimal _vLimiteCredito;
        [ParameterOrder(Order = 23)]
        public decimal vLimiteCredito
        {
            get { return _vLimiteCredito; }
            set
            {
                _vLimiteCredito = value;
                base.NotifyPropertyChanged(propertyName: "vLimiteCredito");
            }
        }
        private byte _stLimiteCreditoObrigatorio;
        [ParameterOrder(Order = 24)]
        public byte stLimiteCreditoObrigatorio
        {
            get { return _stLimiteCreditoObrigatorio; }
            set
            {
                _stLimiteCreditoObrigatorio = value;
                base.NotifyPropertyChanged(propertyName: "stLimiteCreditoObrigatorio");
            }
        }
        private byte _stFrete;
        [ParameterOrder(Order = 25)]
        public byte stFrete
        {
            get { return _stFrete; }
            set
            {
                _stFrete = value;
                base.NotifyPropertyChanged(propertyName: "stFrete");
            }
        }
        private int _idCanalVenda;
        [ParameterOrder(Order = 26)]
        public int idCanalVenda
        {
            get { return _idCanalVenda; }
            set
            {
                _idCanalVenda = value;
                base.NotifyPropertyChanged(propertyName: "idCanalVenda");
            }
        }
        private byte _stExigeRelacaoProduto;
        [ParameterOrder(Order = 27)]
        public byte stExigeRelacaoProduto
        {
            get { return _stExigeRelacaoProduto; }
            set
            {
                _stExigeRelacaoProduto = value;
                base.NotifyPropertyChanged(propertyName: "stExigeRelacaoProduto");
            }
        }
        private int _idListaPrecoPai;
        [ParameterOrder(Order = 28)]
        public int idListaPrecoPai
        {
            get { return _idListaPrecoPai; }
            set
            {
                _idListaPrecoPai = value;
                base.NotifyPropertyChanged(propertyName: "idListaPrecoPai");
            }
        }
        private string _xCpf;
        [ParameterOrder(Order = 29)]
        public string xCpf
        {
            get { return _xCpf; }
            set
            {
                _xCpf = value;
                base.NotifyPropertyChanged(propertyName: "xCpf");
            }
        }
        private int _idContaBancaria;
        [ParameterOrder(Order = 30)]
        public int idContaBancaria
        {
            get { return _idContaBancaria; }
            set
            {
                _idContaBancaria = value;
                base.NotifyPropertyChanged(propertyName: "idContaBancaria");
            }
        }
        private int _idMoeda;
        [ParameterOrder(Order = 31)]
        public int idMoeda
        {
            get { return _idMoeda; }
            set
            {
                _idMoeda = value;
                base.NotifyPropertyChanged(propertyName: "idMoeda");
            }
        }
        private int _idCondicaoPagamento;
        [ParameterOrder(Order = 32)]
        public int idCondicaoPagamento
        {
            get { return _idCondicaoPagamento; }
            set
            {
                _idCondicaoPagamento = value;
                base.NotifyPropertyChanged(propertyName: "idCondicaoPagamento");

                Window w = Sistema.GetOpenWindow(xName: "WinCliente");
                Application.Current.Dispatcher.BeginInvoke((Action)(() =>
                {
                    object o = w.DataContext;

                    MethodInfo mi = o.GetType().GetMethod(name: "getCondicaoPagamentoByCliente");

                    object objCondicao = mi.Invoke(obj: w.DataContext, parameters: new object[] { value });

                    if (objCondicao != null)
                    {
                        this.idPlanoPagamento = ((Condicao_pagamentoModel)objCondicao).idPlanoPagamento;
                        this.idDiaPagamento = ((Condicao_pagamentoModel)objCondicao).idDiaPagamento;

                        if (((Condicao_pagamentoModel)objCondicao).idDiaPagamento != null && ((Condicao_pagamentoModel)objCondicao).idDiaPagamento != 0
                            && ((Condicao_pagamentoModel)objCondicao).idPlanoPagamento != null && ((Condicao_pagamentoModel)objCondicao).idPlanoPagamento != 0)
                            this.enabledFieldsCondPagamento = false;
                        else
                        {
                            this.enabledFieldsCondPagamento = true;
                        }
                    }
                    else
                    {
                        this.enabledFieldsCondPagamento = true;
                        this.idPlanoPagamento = null;
                        this.idDiaPagamento = null;
                    }
                }));
            }
        }
        private int? _idFuncionario;
        [ParameterOrder(Order = 33)]
        public int? idFuncionario
        {
            get { return _idFuncionario; }
            set
            {
                _idFuncionario = value;
                base.NotifyPropertyChanged(propertyName: "idFuncionario");
            }
        }
        private byte _stParado;
        [ParameterOrder(Order = 34)]
        public byte stParado
        {
            get { return _stParado; }
            set
            {
                _stParado = value;
                base.NotifyPropertyChanged(propertyName: "stParado");
            }
        }
        private int? _nFuncionarios;
        [ParameterOrder(Order = 35)]
        public int? nFuncionarios
        {
            get { return _nFuncionarios; }
            set
            {
                _nFuncionarios = value;
                base.NotifyPropertyChanged(propertyName: "nFuncionarios");
            }
        }
        private byte _stCategoria;
        [ParameterOrder(Order = 36)]
        public byte stCategoria
        {
            get { return _stCategoria; }
            set
            {
                _stCategoria = value;
                base.NotifyPropertyChanged(propertyName: "stCategoria");
            }
        }
        private string _xSaudacao;
        [ParameterOrder(Order = 37)]
        public string xSaudacao
        {
            get { return _xSaudacao; }
            set
            {
                _xSaudacao = value;
                base.NotifyPropertyChanged(propertyName: "xSaudacao");
            }
        }
        private string _xApelido;
        [ParameterOrder(Order = 38)]
        public string xApelido
        {
            get { return _xApelido; }
            set
            {
                _xApelido = value;
                base.NotifyPropertyChanged(propertyName: "xApelido");
            }
        }
        private byte? _stEstadoCivil;
        [ParameterOrder(Order = 39)]
        public byte? stEstadoCivil
        {
            get { return _stEstadoCivil; }
            set
            {
                _stEstadoCivil = value;
                base.NotifyPropertyChanged(propertyName: "stEstadoCivil");
            }
        }
        private DateTime? _dDataNascimento;
        [ParameterOrder(Order = 40)]
        public DateTime? dDataNascimento
        {
            get { return _dDataNascimento; }
            set
            {
                _dDataNascimento = value;
                base.NotifyPropertyChanged(propertyName: "dDataNascimento");
            }
        }
        private string _xFilhos;
        [ParameterOrder(Order = 41)]
        public string xFilhos
        {
            get { return _xFilhos; }
            set
            {
                _xFilhos = value;
                base.NotifyPropertyChanged(propertyName: "xFilhos");
            }
        }
        private string _xConjugue;
        [ParameterOrder(Order = 42)]
        public string xConjugue
        {
            get { return _xConjugue; }
            set
            {
                _xConjugue = value;
                base.NotifyPropertyChanged(propertyName: "xConjugue");
            }
        }
        private DateTime? _dDataAdmissao;
        [ParameterOrder(Order = 43)]
        public DateTime? dDataAdmissao
        {
            get { return _dDataAdmissao; }
            set
            {
                _dDataAdmissao = value;
                base.NotifyPropertyChanged(propertyName: "dDataAdmissao");
            }
        }
        private string _xEmpresaTrabalha;
        [ParameterOrder(Order = 44)]
        public string xEmpresaTrabalha
        {
            get { return _xEmpresaTrabalha; }
            set
            {
                _xEmpresaTrabalha = value;
                base.NotifyPropertyChanged(propertyName: "xEmpresaTrabalha");
            }
        }
        private string _xTelefoneEmpresaTrabalha;
        [ParameterOrder(Order = 45)]
        public string xTelefoneEmpresaTrabalha
        {
            get { return _xTelefoneEmpresaTrabalha; }
            set
            {
                _xTelefoneEmpresaTrabalha = value;
                base.NotifyPropertyChanged(propertyName: "xTelefoneEmpresaTrabalha");
            }
        }
        private string _xProfissao;
        [ParameterOrder(Order = 46)]
        public string xProfissao
        {
            get { return _xProfissao; }
            set
            {
                _xProfissao = value;
                base.NotifyPropertyChanged(propertyName: "xProfissao");
            }
        }
        private string _xNomePai;
        [ParameterOrder(Order = 47)]
        public string xNomePai
        {
            get { return _xNomePai; }
            set
            {
                _xNomePai = value;
                base.NotifyPropertyChanged(propertyName: "xNomePai");
            }
        }
        private string _xRGPai;
        [ParameterOrder(Order = 48)]
        public string xRGPai
        {
            get { return _xRGPai; }
            set
            {
                _xRGPai = value;
                base.NotifyPropertyChanged(propertyName: "xRGPai");
            }
        }
        private string _xCPFPai;
        [ParameterOrder(Order = 49)]
        public string xCPFPai
        {
            get { return _xCPFPai; }
            set
            {
                _xCPFPai = value;
                base.NotifyPropertyChanged(propertyName: "xCPFPai");
            }
        }
        private string _xNomeMae;
        [ParameterOrder(Order = 50)]
        public string xNomeMae
        {
            get { return _xNomeMae; }
            set
            {
                _xNomeMae = value;
                base.NotifyPropertyChanged(propertyName: "xNomeMae");
            }
        }
        private string _xRGMae;
        [ParameterOrder(Order = 51)]
        public string xRGMae
        {
            get { return _xRGMae; }
            set
            {
                _xRGMae = value;
                base.NotifyPropertyChanged(propertyName: "xRGMae");
            }
        }
        private string _xCPFMae;
        [ParameterOrder(Order = 52)]
        public string xCPFMae
        {
            get { return _xCPFMae; }
            set
            {
                _xCPFMae = value;
                base.NotifyPropertyChanged(propertyName: "xCPFMae");
            }
        }
        private byte? _stResidencia;
        [ParameterOrder(Order = 53)]
        public byte? stResidencia
        {
            get { return _stResidencia; }
            set
            {
                _stResidencia = value;
                base.NotifyPropertyChanged(propertyName: "stResidencia");
            }
        }
        private string _xPontoReferenciaResidencia;
        [ParameterOrder(Order = 54)]
        public string xPontoReferenciaResidencia
        {
            get { return _xPontoReferenciaResidencia; }
            set
            {
                _xPontoReferenciaResidencia = value;
                base.NotifyPropertyChanged(propertyName: "xPontoReferenciaResidencia");
            }
        }
        private decimal? _vSalario;
        [ParameterOrder(Order = 55)]
        public decimal? vSalario
        {
            get { return _vSalario; }
            set
            {
                _vSalario = value;
                base.NotifyPropertyChanged(propertyName: "vSalario");
            }
        }
        private string _xCPFConjugue;
        [ParameterOrder(Order = 56)]
        public string xCPFConjugue
        {
            get { return _xCPFConjugue; }
            set
            {
                _xCPFConjugue = value;
                base.NotifyPropertyChanged(propertyName: "xCPFConjugue");
            }
        }
        private string _xRGConjugue;
        [ParameterOrder(Order = 57)]
        public string xRGConjugue
        {
            get { return _xRGConjugue; }
            set
            {
                _xRGConjugue = value;
                base.NotifyPropertyChanged(propertyName: "xRGConjugue");
            }
        }
        private string _xProfissaoConjugue;
        [ParameterOrder(Order = 58)]
        public string xProfissaoConjugue
        {
            get { return _xProfissaoConjugue; }
            set
            {
                _xProfissaoConjugue = value;
                base.NotifyPropertyChanged(propertyName: "xProfissaoConjugue");
            }
        }
        private string _xEmpresaConjugue;
        [ParameterOrder(Order = 59)]
        public string xEmpresaConjugue
        {
            get { return _xEmpresaConjugue; }
            set
            {
                _xEmpresaConjugue = value;
                base.NotifyPropertyChanged(propertyName: "xEmpresaConjugue");
            }
        }
        private string _xInformacaoComercialNome1;
        [ParameterOrder(Order = 60)]
        public string xInformacaoComercialNome1
        {
            get { return _xInformacaoComercialNome1; }
            set
            {
                _xInformacaoComercialNome1 = value;
                base.NotifyPropertyChanged(propertyName: "xInformacaoComercialNome1");
            }
        }
        private string _xInformacaoComercialNome2;
        [ParameterOrder(Order = 61)]
        public string xInformacaoComercialNome2
        {
            get { return _xInformacaoComercialNome2; }
            set
            {
                _xInformacaoComercialNome2 = value;
                base.NotifyPropertyChanged(propertyName: "xInformacaoComercialNome2");
            }
        }
        private string _xInformacaoComercialNome3;
        [ParameterOrder(Order = 62)]
        public string xInformacaoComercialNome3
        {
            get { return _xInformacaoComercialNome3; }
            set
            {
                _xInformacaoComercialNome3 = value;
                base.NotifyPropertyChanged(propertyName: "xInformacaoComercialNome3");
            }
        }
        private string _xInformacaoComercialTelefone1;
        [ParameterOrder(Order = 63)]
        public string xInformacaoComercialTelefone1
        {
            get { return _xInformacaoComercialTelefone1; }
            set
            {
                _xInformacaoComercialTelefone1 = value;
                base.NotifyPropertyChanged(propertyName: "xInformacaoComercialTelefone1");
            }
        }
        private string _xInformacaoComercialTelefone2;
        [ParameterOrder(Order = 64)]
        public string xInformacaoComercialTelefone2
        {
            get { return _xInformacaoComercialTelefone2; }
            set
            {
                _xInformacaoComercialTelefone2 = value;
                base.NotifyPropertyChanged(propertyName: "xInformacaoComercialTelefone2");
            }
        }
        private string _xInformacaoComercialTelefone3;
        [ParameterOrder(Order = 65)]
        public string xInformacaoComercialTelefone3
        {
            get { return _xInformacaoComercialTelefone3; }
            set
            {
                _xInformacaoComercialTelefone3 = value;
                base.NotifyPropertyChanged(propertyName: "xInformacaoComercialTelefone3");
            }
        }
        private DateTime? _dInformacaoComercialClienteDesde1;
        [ParameterOrder(Order = 66)]
        public DateTime? dInformacaoComercialClienteDesde1
        {
            get { return _dInformacaoComercialClienteDesde1; }
            set
            {
                _dInformacaoComercialClienteDesde1 = value;
                base.NotifyPropertyChanged(propertyName: "dInformacaoComercialClienteDesde1");
            }
        }
        private DateTime? _dInformacaoComercialClienteDesde2;
        [ParameterOrder(Order = 67)]
        public DateTime? dInformacaoComercialClienteDesde2
        {
            get { return _dInformacaoComercialClienteDesde2; }
            set
            {
                _dInformacaoComercialClienteDesde2 = value;
                base.NotifyPropertyChanged(propertyName: "dInformacaoComercialClienteDesde2");
            }
        }
        private DateTime? _dInformacaoComercialClienteDesde3;
        [ParameterOrder(Order = 68)]
        public DateTime? dInformacaoComercialClienteDesde3
        {
            get { return _dInformacaoComercialClienteDesde3; }
            set
            {
                _dInformacaoComercialClienteDesde3 = value;
                base.NotifyPropertyChanged(propertyName: "dInformacaoComercialClienteDesde3");
            }
        }
        private decimal? _vInformacaoComercialMaiorCompra1;
        [ParameterOrder(Order = 69)]
        public decimal? vInformacaoComercialMaiorCompra1
        {
            get { return _vInformacaoComercialMaiorCompra1; }
            set
            {
                _vInformacaoComercialMaiorCompra1 = value;
                base.NotifyPropertyChanged(propertyName: "vInformacaoComercialMaiorCompra1");
            }
        }
        private decimal? _vInformacaoComercialMaiorCompra2;
        [ParameterOrder(Order = 70)]
        public decimal? vInformacaoComercialMaiorCompra2
        {
            get { return _vInformacaoComercialMaiorCompra2; }
            set
            {
                _vInformacaoComercialMaiorCompra2 = value;
                base.NotifyPropertyChanged(propertyName: "vInformacaoComercialMaiorCompra2");
            }
        }
        private decimal? _vInformacaoComercialMaiorCompra3;
        [ParameterOrder(Order = 71)]
        public decimal? vInformacaoComercialMaiorCompra3
        {
            get { return _vInformacaoComercialMaiorCompra3; }
            set
            {
                _vInformacaoComercialMaiorCompra3 = value;
                base.NotifyPropertyChanged(propertyName: "vInformacaoComercialMaiorCompra3");
            }
        }
        private DateTime? _dInformacaoComercialUltimaCompra1;
        [ParameterOrder(Order = 72)]
        public DateTime? dInformacaoComercialUltimaCompra1
        {
            get { return _dInformacaoComercialUltimaCompra1; }
            set
            {
                _dInformacaoComercialUltimaCompra1 = value;
                base.NotifyPropertyChanged(propertyName: "dInformacaoComercialUltimaCompra1");
            }
        }
        private DateTime? _dInformacaoComercialUltimaCompra2;
        [ParameterOrder(Order = 73)]
        public DateTime? dInformacaoComercialUltimaCompra2
        {
            get { return _dInformacaoComercialUltimaCompra2; }
            set
            {
                _dInformacaoComercialUltimaCompra2 = value;
                base.NotifyPropertyChanged(propertyName: "dInformacaoComercialUltimaCompra2");
            }
        }
        private DateTime? _dInformacaoComercialUltimaCompra3;
        [ParameterOrder(Order = 74)]
        public DateTime? dInformacaoComercialUltimaCompra3
        {
            get { return _dInformacaoComercialUltimaCompra3; }
            set
            {
                _dInformacaoComercialUltimaCompra3 = value;
                base.NotifyPropertyChanged(propertyName: "dInformacaoComercialUltimaCompra3");
            }
        }
        private string _xInformacaoComercialInformante1;
        [ParameterOrder(Order = 75)]
        public string xInformacaoComercialInformante1
        {
            get { return _xInformacaoComercialInformante1; }
            set
            {
                _xInformacaoComercialInformante1 = value;
                base.NotifyPropertyChanged(propertyName: "xInformacaoComercialInformante1");
            }
        }
        private string _xInformacaoComercialInformante2;
        [ParameterOrder(Order = 76)]
        public string xInformacaoComercialInformante2
        {
            get { return _xInformacaoComercialInformante2; }
            set
            {
                _xInformacaoComercialInformante2 = value;
                base.NotifyPropertyChanged(propertyName: "xInformacaoComercialInformante2");
            }
        }
        private string _xInformacaoComercialInformante3;
        [ParameterOrder(Order = 77)]
        public string xInformacaoComercialInformante3
        {
            get { return _xInformacaoComercialInformante3; }
            set
            {
                _xInformacaoComercialInformante3 = value;
                base.NotifyPropertyChanged(propertyName: "xInformacaoComercialInformante3");
            }
        }
        private decimal? _vSalarioConjugue;
        [ParameterOrder(Order = 78)]
        public decimal? vSalarioConjugue
        {
            get { return _vSalarioConjugue; }
            set
            {
                _vSalarioConjugue = value;
                base.NotifyPropertyChanged(propertyName: "vSalarioConjugue");
            }
        }
        private byte? _stSexo;
        [ParameterOrder(Order = 79)]
        public byte? stSexo
        {
            get { return _stSexo; }
            set
            {
                _stSexo = value;
                base.NotifyPropertyChanged(propertyName: "stSexo");
            }
        }
        private int _idCondicaoEntrega;
        [ParameterOrder(Order = 80)]
        public int idCondicaoEntrega
        {
            get { return _idCondicaoEntrega; }
            set
            {
                _idCondicaoEntrega = value;
                base.NotifyPropertyChanged(propertyName: "idCondicaoEntrega");
            }
        }
        private int? _idModosEntrega;
        [ParameterOrder(Order = 81)]
        public int? idModosEntrega
        {
            get { return _idModosEntrega; }
            set
            {
                _idModosEntrega = value;
                base.NotifyPropertyChanged(propertyName: "idModosEntrega");
            }
        }
        private int? _idCalendario;
        [ParameterOrder(Order = 82)]
        public int? idCalendario
        {
            get { return _idCalendario; }
            set
            {
                _idCalendario = value;
                base.NotifyPropertyChanged(propertyName: "idCalendario");
            }
        }
        private int? _idTipoDocumento;
        [ParameterOrder(Order = 83)]
        public int? idTipoDocumento
        {
            get { return _idTipoDocumento; }
            set
            {
                _idTipoDocumento = value;
                base.NotifyPropertyChanged(propertyName: "idTipoDocumento");
            }
        }
        private int? _idSite;
        [ParameterOrder(Order = 84)]
        public int? idSite
        {
            get { return _idSite; }
            set
            {
                _idSite = value;
                base.NotifyPropertyChanged(propertyName: "idSite");
            }
        }
        private int? _idDeposito;
        [ParameterOrder(Order = 85)]
        public int? idDeposito
        {
            get { return _idDeposito; }
            set
            {
                _idDeposito = value;
                base.NotifyPropertyChanged(propertyName: "idDeposito");
                Window w = Sistema.GetOpenWindow(xName: "WinCliente");
                Application.Current.Dispatcher.BeginInvoke((Action)(() =>
                {
                    object o = w.DataContext;
                    object arg1 = value;

                    MethodInfo mi = o.GetType().GetMethod(name: "GetIdSiteByDeposito");

                    this.idSite = (int)mi.Invoke(obj: w.DataContext, parameters: new object[] { arg1 });
                }));
            }
        }
        private int? _idDescontos;
        [ParameterOrder(Order = 86)]
        public int? idDescontos
        {
            get { return _idDescontos; }
            set
            {
                _idDescontos = value;
                base.NotifyPropertyChanged(propertyName: "idDescontos");
            }
        }
        private int? _idPlanoPagamento;
        [ParameterOrder(Order = 87)]
        public int? idPlanoPagamento
        {
            get { return _idPlanoPagamento; }
            set
            {
                _idPlanoPagamento = value;
                base.NotifyPropertyChanged(propertyName: "idPlanoPagamento");
            }
        }
        private int? _idDiaPagamento;
        [ParameterOrder(Order = 88)]
        public int? idDiaPagamento
        {
            get { return _idDiaPagamento; }
            set
            {
                _idDiaPagamento = value;
                base.NotifyPropertyChanged(propertyName: "idDiaPagamento");
            }
        }
        private int? _idJuros;
        [ParameterOrder(Order = 89)]
        public int? idJuros
        {
            get { return _idJuros; }
            set
            {
                _idJuros = value;
                base.NotifyPropertyChanged(propertyName: "idJuros");
            }
        }
        private byte _stMostraProdutosRelacionado;
        [ParameterOrder(Order = 90)]
        public byte stMostraProdutosRelacionado
        {
            get { return _stMostraProdutosRelacionado; }
            set
            {
                _stMostraProdutosRelacionado = value;
                base.NotifyPropertyChanged(propertyName: "stMostraProdutosRelacionado");
            }
        }
        private int? _idTransportador;
        [ParameterOrder(Order = 91)]
        public int? idTransportador
        {
            get { return _idTransportador; }
            set
            {
                _idTransportador = value;
                base.NotifyPropertyChanged(propertyName: "idTransportador");
            }
        }
        private byte? _stSpc;
        [ParameterOrder(Order = 92)]
        public byte? stSpc
        {
            get { return _stSpc; }
            set
            {
                _stSpc = value;
                base.NotifyPropertyChanged(propertyName: "stSpc");
            }
        }
        private byte? _stSituacaoSci;
        [ParameterOrder(Order = 93)]
        public byte? stSituacaoSci
        {
            get { return _stSituacaoSci; }
            set
            {
                _stSituacaoSci = value;
                base.NotifyPropertyChanged(propertyName: "stSituacaoSci");
            }
        }
        private byte? _stAssociacaoComercial;
        [ParameterOrder(Order = 94)]
        public byte? stAssociacaoComercial
        {
            get { return _stAssociacaoComercial; }
            set
            {
                _stAssociacaoComercial = value;
                base.NotifyPropertyChanged(propertyName: "stAssociacaoComercial");
            }
        }
        private int? _idMultas;
        [ParameterOrder(Order = 95)]
        public int? idMultas
        {
            get { return _idMultas; }
            set
            {
                _idMultas = value;
                base.NotifyPropertyChanged(propertyName: "idMultas");
            }
        }
        private byte? _stObrigaListaPreco;
        [ParameterOrder(Order = 96)]
        public byte? stObrigaListaPreco
        {
            get { return _stObrigaListaPreco; }
            set
            {
                _stObrigaListaPreco = value;
                base.NotifyPropertyChanged(propertyName: "stObrigaListaPreco");
            }
        }
        private int? _idCidadeNascimento;
        [ParameterOrder(Order = 97)]
        public int? idCidadeNascimento
        {
            get { return _idCidadeNascimento; }
            set
            {
                _idCidadeNascimento = value;
                base.NotifyPropertyChanged(propertyName: "idCidadeNascimento");
            }
        }


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
        private byte? _stSuspensaoPISCOFINS;
        [ParameterOrder(Order = 27)]
        public byte? stSuspensaoPISCOFINS
        {
            get { return _stSuspensaoPISCOFINS; }
            set
            {
                _stSuspensaoPISCOFINS = value;
                base.NotifyPropertyChanged(propertyName: "stSuspensaoPISCOFINS");
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
