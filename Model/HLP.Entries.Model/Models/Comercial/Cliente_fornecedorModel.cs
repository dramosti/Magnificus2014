using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Base.ClassesBases;
using HLP.Base.Static;
using System.Windows;
using System.Reflection;
using System.Windows.Threading;
using HLP.Entries.Model.Models.Gerais;
using HLP.Components.Model.Models;
using HLP.Comum.Model.Models;

namespace HLP.Entries.Model.Models.Comercial
{
    public partial class Cliente_fornecedorModel : modelComum
    {
        private static Type tClienteFornecedorViewModel = null;

        public static object ExecuteMethodViewModelByReflection(string xNameMethod, object[] arguments)
        {
            Window w = Sistema.GetOpenWindow(xName: "WinCliente");

            if (w != null)
            {
                if (tClienteFornecedorViewModel == null)
                    tClienteFornecedorViewModel = w.DataContext.GetType();

                MethodInfo mi = tClienteFornecedorViewModel.GetMethod(name: xNameMethod);

                if (mi != null)
                {
                    return mi.Invoke(obj: w.DataContext, parameters: arguments);
                }
            }

            return null;
        }


        public Cliente_fornecedorModel()
            : base(xTabela: "Cliente_fornecedor")
        {
            this.lCliente_fornecedor_arquivo = new ObservableCollectionBaseCadastros<Cliente_fornecedor_arquivoModel>();
            this.lCliente_fornecedor_contato = new ObservableCollectionBaseCadastros<ContatoModel>();
            this.lCliente_fornecedor_Endereco = new ObservableCollectionBaseCadastros<EnderecoModel>();
            this.lCliente_Fornecedor_Observacao = new ObservableCollectionBaseCadastros<Cliente_Fornecedor_ObservacaoModel>();
            this.lCliente_fornecedor_produto = new ObservableCollectionBaseCadastros<Cliente_fornecedor_produtoModel>();
            this.lCliente_fornecedor_representante = new ObservableCollectionBaseCadastros<Cliente_fornecedor_representanteModel>();
            this.cliente_fornecedor_fiscal = new Cliente_fornecedor_fiscalModel();
            this.dCadastro = DateTime.Today;
            this.enabledFieldsCondPagamento = this.bEnabledListaPreco = true;
        }

        #region Propriedades não mapeadas


        private bool _bEnabledListaPreco;

        public bool bEnabledListaPreco
        {
            get { return _bEnabledListaPreco; }
            set
            {
                _bEnabledListaPreco = value;
                base.NotifyPropertyChanged(propertyName: "bEnabledListaPreco");
            }
        }


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
        private string _xCpfCnpj;
        [ParameterOrder(Order = 6)]
        public string xCpfCnpj
        {
            get { return _xCpfCnpj; }
            set
            {
                _xCpfCnpj = value;
                base.NotifyPropertyChanged(propertyName: "xCpfCnpj");
            }
        }
        private string _xIm;
        [ParameterOrder(Order = 7)]
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
        [ParameterOrder(Order = 8)]
        public string xNome
        {
            get { return _xNome; }
            set
            {
                _xNome = value;
                base.NotifyPropertyChanged(propertyName: "xNome");
            }
        }
        private string _xRgIe;
        [ParameterOrder(Order = 9)]
        public string xRgIe
        {
            get { return _xRgIe; }
            set
            {
                _xRgIe = value;
                base.NotifyPropertyChanged(propertyName: "xRgIe");
            }
        }
        private string _xFantasia;
        [ParameterOrder(Order = 10)]
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
        [ParameterOrder(Order = 11)]
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
        [ParameterOrder(Order = 12)]
        public int? idRota
        {
            get { return _idRota; }
            set
            {
                this.bEnabledListaPreco = true;
                if (this.GetOperationModel() == Base.EnumsBases.OperationModel.updating)
                {
                    int? idListaPrecoRota = ExecuteMethodViewModelByReflection(xNameMethod: "GetIdListaPrecoPaiRota",
                        arguments: new object[] { value }) as int?;

                    if (idListaPrecoRota != null)
                    {
                        if (MessageHlp.Show(stMessage: StMessage.stYesNo, xMessageToUser: "Esta Rota já possui uma lista de preço definida, a referencia da lista de preço " +
                            "do cliente será perdida. Deseja continuar?") == MessageBoxResult.No)
                        {
                            return;
                        }
                        else
                        {
                            this.idListaPrecoPai = idListaPrecoRota ?? 0;
                            this.bEnabledListaPreco = false;
                        }
                    }
                }
                _idRota = value;

                base.NotifyPropertyChanged(propertyName: "idRota");
            }
        }
        private DateTime _dCadastro;
        [ParameterOrder(Order = 13)]
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
        [ParameterOrder(Order = 14)]
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
        [ParameterOrder(Order = 15)]
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
        [ParameterOrder(Order = 16)]
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
        [ParameterOrder(Order = 17)]
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
        [ParameterOrder(Order = 18)]
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
        [ParameterOrder(Order = 19)]
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
        [ParameterOrder(Order = 20)]
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
        [ParameterOrder(Order = 21)]
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
        [ParameterOrder(Order = 22)]
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
        [ParameterOrder(Order = 23)]
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
        [ParameterOrder(Order = 24)]
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
        [ParameterOrder(Order = 25)]
        public int idCanalVenda
        {
            get { return _idCanalVenda; }
            set
            {
                _idCanalVenda = value;
                base.NotifyPropertyChanged(propertyName: "idCanalVenda");
            }
        }
        private int _idListaPrecoPai;
        [ParameterOrder(Order = 26)]
        public int idListaPrecoPai
        {
            get { return _idListaPrecoPai; }
            set
            {
                _idListaPrecoPai = value;
                base.NotifyPropertyChanged(propertyName: "idListaPrecoPai");
            }
        }
        private int _idContaBancaria;
        [ParameterOrder(Order = 27)]
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
        [ParameterOrder(Order = 28)]
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
        [ParameterOrder(Order = 29)]
        public int idCondicaoPagamento
        {
            get { return _idCondicaoPagamento; }
            set
            {
                _idCondicaoPagamento = value;
                base.NotifyPropertyChanged(propertyName: "idCondicaoPagamento");

                Window w = Sistema.GetOpenWindow(xName: "WinCliente");
                if (w != null)
                {
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
        }

        private int? _idFuncionario;
        [ParameterOrder(Order = 30)]
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
        [ParameterOrder(Order = 31)]
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
        [ParameterOrder(Order = 32)]
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
        [ParameterOrder(Order = 33)]
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
        [ParameterOrder(Order = 34)]
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
        [ParameterOrder(Order = 35)]
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
        [ParameterOrder(Order = 36)]
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
        [ParameterOrder(Order = 37)]
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
        [ParameterOrder(Order = 38)]
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
        [ParameterOrder(Order = 39)]
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
        [ParameterOrder(Order = 40)]
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
        [ParameterOrder(Order = 41)]
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
        [ParameterOrder(Order = 42)]
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
        [ParameterOrder(Order = 43)]
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
        [ParameterOrder(Order = 44)]
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
        [ParameterOrder(Order = 45)]
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
        [ParameterOrder(Order = 46)]
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
        [ParameterOrder(Order = 47)]
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
        [ParameterOrder(Order = 48)]
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
        [ParameterOrder(Order = 49)]
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
        [ParameterOrder(Order = 50)]
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
        [ParameterOrder(Order = 51)]
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
        [ParameterOrder(Order = 52)]
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
        [ParameterOrder(Order = 53)]
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
        [ParameterOrder(Order = 54)]
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
        [ParameterOrder(Order = 55)]
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
        [ParameterOrder(Order = 56)]
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
        [ParameterOrder(Order = 57)]
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
        [ParameterOrder(Order = 58)]
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
        [ParameterOrder(Order = 59)]
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
        [ParameterOrder(Order = 60)]
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
        [ParameterOrder(Order = 61)]
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
        [ParameterOrder(Order = 62)]
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
        [ParameterOrder(Order = 63)]
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
        [ParameterOrder(Order = 64)]
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
        [ParameterOrder(Order = 65)]
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
        [ParameterOrder(Order = 66)]
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
        [ParameterOrder(Order = 67)]
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
        [ParameterOrder(Order = 68)]
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
        [ParameterOrder(Order = 69)]
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
        [ParameterOrder(Order = 70)]
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
        [ParameterOrder(Order = 71)]
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
        [ParameterOrder(Order = 72)]
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
        [ParameterOrder(Order = 73)]
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
        [ParameterOrder(Order = 74)]
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
        [ParameterOrder(Order = 75)]
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
        [ParameterOrder(Order = 76)]
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
        [ParameterOrder(Order = 77)]
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
        [ParameterOrder(Order = 78)]
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
        [ParameterOrder(Order = 79)]
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
        [ParameterOrder(Order = 80)]
        public int? idTipoDocumento
        {
            get { return _idTipoDocumento; }
            set
            {
                _idTipoDocumento = value;
                base.NotifyPropertyChanged(propertyName: "idTipoDocumento");
            }
        }
        private int? _idDeposito;
        [ParameterOrder(Order = 81)]
        public int? idDeposito
        {
            get { return _idDeposito; }
            set
            {
                _idDeposito = value;
                base.NotifyPropertyChanged(propertyName: "idDeposito");
                Window w = Sistema.GetOpenWindow(xName: "WinCliente");
                if (w != null)
                {
                    Application.Current.Dispatcher.BeginInvoke((Action)(() =>
                    {
                        object o = w.DataContext;
                        object arg1 = value;

                        MethodInfo mi = o.GetType().GetMethod(name: "GetIdSiteByDeposito");

                        if (this.status != Base.EnumsBases.statusModel.nenhum)
                            this.idSite = (int)mi.Invoke(obj: w.DataContext, parameters: new object[] { arg1 });
                    }));
                }
            }
        }
        private int? _idDescontos;
        [ParameterOrder(Order = 82)]
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
        [ParameterOrder(Order = 83)]
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
        [ParameterOrder(Order = 84)]
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
        [ParameterOrder(Order = 85)]
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
        [ParameterOrder(Order = 86)]
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
        [ParameterOrder(Order = 87)]
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
        [ParameterOrder(Order = 88)]
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
        [ParameterOrder(Order = 89)]
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
        [ParameterOrder(Order = 90)]
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
        [ParameterOrder(Order = 91)]
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
        [ParameterOrder(Order = 92)]
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
        [ParameterOrder(Order = 93)]
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



        private ObservableCollectionBaseCadastros<EnderecoModel> _lCliente_fornecedor_Endereco;

        public ObservableCollectionBaseCadastros<EnderecoModel> lCliente_fornecedor_Endereco
        {
            get { return _lCliente_fornecedor_Endereco; }
            set
            {
                _lCliente_fornecedor_Endereco = value;
                base.NotifyPropertyChanged(propertyName: "lCliente_fornecedor_Endereco");
            }
        }


        private ObservableCollectionBaseCadastros<ContatoModel> _lCliente_fornecedor_contato;

        public ObservableCollectionBaseCadastros<ContatoModel> lCliente_fornecedor_contato
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

    public partial class Cliente_fornecedor_representanteModel : modelComum
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

    public partial class Cliente_fornecedor_produtoModel : modelComum
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

    public partial class Cliente_Fornecedor_ObservacaoModel : modelComum
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

    public partial class Cliente_fornecedor_fiscalModel : modelComum
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

    public partial class Cliente_fornecedor_contatoModel : modelComum
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

    public partial class Cliente_fornecedor_arquivoModel : modelComum
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
                string xErro = base[columnName];

                if (xErro == "" || xErro == null)
                {
                    if (columnName == "dDataAdmissao")
                    {
                        if (this._dDataAdmissao > this._dCadastro)
                            xErro = "Data de Admissão não pode ser maior que data de cadastro";
                        else if (this._dDataNascimento > this._dDataAdmissao)
                            xErro = "Data de Nascimento não pode ser menor que data de Admissão";
                    }
                    else if (columnName == "dDataNascimento")
                    {
                        if (this._dDataNascimento > this._dDataAdmissao)
                            xErro = "Data de Nascimento não pode ser menor que data de Admissão";

                        this.dInformacaoComercialUltimaCompra1 = this._dInformacaoComercialUltimaCompra1;
                        this.dInformacaoComercialUltimaCompra2 = this._dInformacaoComercialUltimaCompra2;
                        this.dInformacaoComercialUltimaCompra3 = this._dInformacaoComercialUltimaCompra3;
                    }
                    else if (columnName == "dInformacaoComercialUltimaCompra1")
                    {
                        if (this._dInformacaoComercialUltimaCompra1 > this._dCadastro)
                        {
                            xErro = "Data última compra não pode ser maior que data de hoje.";
                        }
                        else if (this._dInformacaoComercialUltimaCompra1 < this._dDataNascimento)
                        {
                            xErro = "Data de última compra não pode ser menor que data de nascimento.";
                        }
                    }
                    else if (columnName == "dInformacaoComercialUltimaCompra2")
                    {
                        if (this._dInformacaoComercialUltimaCompra2 > this._dCadastro)
                        {
                            xErro = "Data última compra não pode ser maior que data de hoje.";
                        }
                        else if (this._dInformacaoComercialUltimaCompra2 < this._dDataNascimento)
                        {
                            xErro = "Data de última compra não pode ser menor que data de nascimento.";
                        }
                    }
                    else if (columnName == "dInformacaoComercialUltimaCompra3")
                    {
                        if (this._dInformacaoComercialUltimaCompra3 > this._dCadastro)
                        {
                            xErro = "Data última compra não pode ser maior que data de hoje.";
                        }
                        else if (this._dInformacaoComercialUltimaCompra3 < this._dDataNascimento)
                        {
                            xErro = "Data de última compra não pode ser menor que data de nascimento.";
                        }
                    }
                }

                return xErro;
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
