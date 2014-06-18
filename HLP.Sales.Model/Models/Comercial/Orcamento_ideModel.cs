using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Entries.Model.Fiscal;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using HLP.Entries.Model.Models.Parametros;
using System.Windows;
using System.Windows.Data;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows.Media;
using HLP.Base.ClassesBases;
using HLP.Base.Static;
using HLP.Base.EnumsBases;
using HLP.Components.Model.Models;
using HLP.Entries.Model.Models.Comercial;
using System.Reflection;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.Model.Models.Financeiro;
using HLP.Entries.Model.Models.Fiscal;
using HLP.Entries.Model.Models.Transportes;
using System.Threading;

namespace HLP.Sales.Model.Models.Comercial
{
    public partial class Orcamento_ideModel : modelBase
    {
        private static Window winOrcamento = null;

        private static object _objDataContext;

        public static async Task<object> GetDataContextWindow()
        {
            if (winOrcamento == null)
                winOrcamento = Sistema.GetOpenWindow(xName: "WinOrcamento");

            if (_objDataContext == null)
                await Application.Current.Dispatcher.BeginInvoke((Action)(() =>
                {
                    _objDataContext = winOrcamento.DataContext;
                }));

            return _objDataContext;
        }

        private static List<MethodInfo> lMethods;

        public static object GetMethodDataContextWindowValue(string xname, object[] _parameters)
        {
            MethodInfo mi = null;
            object o = GetDataContextWindow().Result;

            mi = lMethods.FirstOrDefault(i =>
                i.Name == xname);

            if (mi == null)
            {
                mi = o.GetType().GetMethod(name: xname);
                lMethods.Add(item: mi);
            }

            bool bProcessed = false;
            object _value = null;

            if (mi != null)
                _value = mi.Invoke(obj: o,
                        parameters: _parameters);

            return _value;
        }

        private static Orcamento_ideModel _currentModel;

        public static Orcamento_ideModel currentModel
        {
            get { return _currentModel; }
            set { _currentModel = value; }
        }


        public Orcamento_ideModel()
            : base("Orcamento_ide")
        {
            try
            {
                currentModel = this;

                lMethods = new List<MethodInfo>();

                this.orcamento_Total_Impostos = new Orcamento_Total_ImpostosModel();
                this.orcamento_retTransp = new Orcamento_retTranspModel();
                //this.bTodos = true;
                this.lOrcamento_Itens = new ObservableCollectionBaseCadastros<Orcamento_ItemModel>();
                this.idFuncionario = UserData.idUser;
                this.dDataHora = DateTime.Now;

                object retorno = GetMethodDataContextWindowValue(xname: "GetFuncionario", _parameters: new object[] { this.idFuncionario });

                if (retorno != null)
                    this.objFuncionario = retorno as FuncionarioModel;

                if (this.objFuncionario != null)
                {
                    this.idFuncionarioRepresentante = this.objFuncionario.idResponsavel ?? 0;
                }



                EnderecoModel objEnderecoEmpresa = null;
                this.objEmpresa = GetMethodDataContextWindowValue(xname: "GetEmpresa", _parameters: new object[] { CompanyData.idEmpresa }) as EmpresaModel;

                objEnderecoEmpresa = this.objEmpresa.lEmpresa_endereco.FirstOrDefault(i => i.stPrincipal == ((byte)1));

                if (objEnderecoEmpresa == null)
                    objEnderecoEmpresa = this.objEmpresa.lEmpresa_endereco.FirstOrDefault();

                CidadeModel objCidade = null;

                if (objEnderecoEmpresa != null)
                {
                    objCidade =
                        GetMethodDataContextWindowValue(xname: "GetCidade",
                        _parameters: new object[] { objEnderecoEmpresa.idCidade }) as CidadeModel;

                    if (objCidade != null)
                        idUfEnderecoEmpresa = objCidade.idUF;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        #region Propriedades para Regras de Negócio

        public int idUfEnderecoCliente { get; set; }

        public int idUfEnderecoEmpresa { get; set; }

        #endregion

        #region Propriedades apenas para visualização na tela

        private bool _bCriado;

        public bool bCriado
        {
            get { return _bCriado; }
            set
            {
                _bCriado = value;
                if (!value)
                {
                    this._bTodos = false;
                    base.NotifyPropertyChanged(propertyName: "bTodos");
                }
                this.FiltrarItems();
                this.orcamento_Total_Impostos.CalcularTotais();
                base.NotifyPropertyChanged(propertyName: "bCriado");
            }
        }

        private bool _bEnviado;

        public bool bEnviado
        {
            get { return _bEnviado; }
            set
            {
                _bEnviado = value;
                if (!value)
                {
                    this._bTodos = false;
                    base.NotifyPropertyChanged(propertyName: "bTodos");
                }
                this.FiltrarItems();
                this.orcamento_Total_Impostos.CalcularTotais();
                base.NotifyPropertyChanged(propertyName: "bEnviado");
            }
        }

        private bool _bConfirmado;

        public bool bConfirmado
        {
            get { return _bConfirmado; }
            set
            {
                _bConfirmado = value;
                if (!value)
                {
                    this._bTodos = false;
                    base.NotifyPropertyChanged(propertyName: "bTodos");
                }
                this.FiltrarItems();
                this.orcamento_Total_Impostos.CalcularTotais();
                base.NotifyPropertyChanged(propertyName: "bConfirmado");
            }
        }

        private bool _bPerdido;

        public bool bPerdido
        {
            get { return _bPerdido; }
            set
            {
                _bPerdido = value;
                if (!value)
                {
                    this._bTodos = false;
                    base.NotifyPropertyChanged(propertyName: "bTodos");
                }
                this.FiltrarItems();
                this.orcamento_Total_Impostos.CalcularTotais();
                base.NotifyPropertyChanged(propertyName: "bPerdido");
            }
        }

        private bool _bCancelado;

        public bool bCancelado
        {
            get { return _bCancelado; }
            set
            {
                _bCancelado = value;
                if (!value)
                {
                    this._bTodos = false;
                    base.NotifyPropertyChanged(propertyName: "bTodos");
                }
                this.FiltrarItems();
                this.orcamento_Total_Impostos.CalcularTotais();
                base.NotifyPropertyChanged(propertyName: "bCancelado");
            }
        }

        private bool _bTodos;

        public bool bTodos
        {
            get { return _bTodos; }
            set
            {
                _bTodos = this._bCriado = this._bEnviado = this._bConfirmado = this._bPerdido = this._bCancelado = value;
                this.FiltrarItems();
                if (orcamento_Total_Impostos != null)
                    this.orcamento_Total_Impostos.CalcularTotais();
                this.NotifyPropertyChanged(propertyName: "bCriado");
                this.NotifyPropertyChanged(propertyName: "bEnviado");
                this.NotifyPropertyChanged(propertyName: "bConfirmado");
                this.NotifyPropertyChanged(propertyName: "bPerdido");
                this.NotifyPropertyChanged(propertyName: "bCancelado");
                this.NotifyPropertyChanged(propertyName: "bTodos");
            }
        }

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


        private int? _idRamoAtividade;

        public int? idRamoAtividade
        {
            get { return _idRamoAtividade; }
            set
            {
                _idRamoAtividade = value;

                if (this.lOrcamento_Itens != null)
                {
                    foreach (Orcamento_ItemModel item in this.lOrcamento_Itens)
                    {
                        item.objImposto.CalculateVlrIcmsSubstTributaria();
                    }
                }

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


        private bool _bIsEnabledClListaPreco;

        public bool bIsEnabledClListaPreco
        {
            get { return _bIsEnabledClListaPreco; }
            set
            {
                _bIsEnabledClListaPreco = value;
                base.NotifyPropertyChanged(propertyName: "bIsEnabledClListaPreco");
            }
        }



        #endregion

        #region Models Relacionadas a Orçamento

        private EmpresaModel _objEmpresa;

        public EmpresaModel objEmpresa
        {
            get { return _objEmpresa; }
            set { _objEmpresa = value; }
        }


        private Cliente_fornecedorModel _objCliente;

        public Cliente_fornecedorModel objCliente
        {
            get { return _objCliente; }
            set
            {
                _objCliente = value;
                if (this.lOrcamento_Itens != null)
                {
                    foreach (Orcamento_ItemModel item in this.lOrcamento_Itens)
                    {
                        item.objImposto.CalculateTotalIpi();
                        item.objImposto.CalculatePorcIcms();
                        item.objImposto.CalculateBaseIcms();
                        item.objImposto.CalculateVlrIcmsSubstTributaria();
                    }
                }
            }
        }

        private FuncionarioModel _objFuncionario;

        public FuncionarioModel objFuncionario
        {
            get { return _objFuncionario; }
            set { _objFuncionario = value; }
        }

        private FuncionarioModel _objFuncionarioRepresentante;

        public FuncionarioModel objFuncionarioRepresentante
        {
            get { return _objFuncionarioRepresentante; }
            set { _objFuncionarioRepresentante = value; }
        }

        private Lista_Preco_PaiModel _objListaPreco;

        public Lista_Preco_PaiModel objListaPreco
        {
            get { return _objListaPreco; }
            set { _objListaPreco = value; }
        }

        private Descontos_AvistaModel _objDesconto;

        public Descontos_AvistaModel objDesconto
        {
            get { return _objDesconto; }
            set { _objDesconto = value; }
        }

        private Condicao_pagamentoModel _objCondicaoPagamento;

        public Condicao_pagamentoModel objCondicaoPagamento
        {
            get { return _objCondicaoPagamento; }
            set { _objCondicaoPagamento = value; }
        }

        private Tipo_documentoModel _objTipoDocumento;

        public Tipo_documentoModel objTipoDocumento
        {
            get { return _objTipoDocumento; }
            set { _objTipoDocumento = value; }
        }

        #endregion

        private void FiltrarItems()
        {
            Window w = Sistema.GetOpenWindow(xName: "WinOrcamento");
            if (w != null)
            {
                DataGrid dg = w.FindName(name: "dgItens") as DataGrid;

                if (dg != null)
                {
                    dg.CommitEdit(editingUnit: DataGridEditingUnit.Row, exitEditingMode: true);
                }

                CollectionViewSource cvs = w.FindResource(resourceKey: "cvsItens") as CollectionViewSource;
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, (Action)(() =>
                {
                    cvs.Filter += new FilterEventHandler(this.ItensOrcamentoFilter);
                }));

                CollectionViewSource cvsImpostos = w.FindResource(resourceKey: "cvsImpostos") as CollectionViewSource;
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, (Action)(() =>
                {
                    cvsImpostos.Filter += new FilterEventHandler(this.ItensOrcamentoFilter);
                }));
            }
        }

        public void ItensOrcamentoFilter(object sender, FilterEventArgs e)
        {
            if (e.Item.GetType() == typeof(Orcamento_ItemModel))
            {
                Orcamento_ItemModel i = e.Item as Orcamento_ItemModel;

                if (i != null)
                {
                    bool valido = false;
                    switch (i.stOrcamentoItem)
                    {
                        case 0:
                            {
                                if (this._bCriado)
                                    valido = true;
                            } break;
                        case 1:
                            {
                                if (this._bEnviado)
                                    valido = true;
                            } break;
                        case 2:
                            {
                                if (this._bConfirmado)
                                    valido = true;
                            } break;
                        case 3:
                            {
                                if (this._bPerdido)
                                    valido = true;
                            } break;
                        case 4:
                            {
                                if (this._bCancelado)
                                    valido = true;
                            } break;
                        case 5:
                            {
                                valido = true;
                            } break;
                    }
                    e.Accepted = valido;
                }
            }
        }

        public void LoadListTipoDocumento()
        {
            object retorno = GetMethodDataContextWindowValue(xname: "GetOperacoesValidas",
                _parameters: new object[] { this._idTipoDocumento });

            if (retorno != null)
            {
                foreach (Orcamento_ItemModel item in this.lOrcamento_Itens)
                {
                    item.lTipoOperacao = new ObservableCollection<modelToComboBox>
                    (list: retorno as List<modelToComboBox>);
                    if (item.lTipoOperacao.Count > 0)
                        item.idTipoOperacao = item.lTipoOperacao.FirstOrDefault().id;
                }
            }
        }

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

                if (this.objCliente == null)
                    this.objCliente = new Cliente_fornecedorModel();

                object retorno = GetMethodDataContextWindowValue(xname: "GetCliente",
                   _parameters: new object[] { value });

                if (retorno != null)
                    this.objCliente = retorno as Cliente_fornecedorModel;

                if (objCliente != null)
                {
                    this.bIsEnabledClListaPreco = this.objCliente.stObrigaListaPreco != (byte)1;

                    this.objListaPreco = GetMethodDataContextWindowValue(xname: "GetListaPreco",
                        _parameters: new object[] { objCliente.idListaPrecoPai }) as Lista_Preco_PaiModel;


                    this.objDesconto = GetMethodDataContextWindowValue(xname: "GetDesconto", _parameters:
                        new object[] { objCliente.idDescontos }) as Descontos_AvistaModel;

                    //Criei esta validação para facilitar em todas as partes do código que precise ser validado se é venda no estado ou não. Valor será setado na variável 'this.VendaNoEstado'
                    #region Venda no Estado?
                    CidadeModel objCidade = null;
                    EnderecoModel objEnderecoCliente = this.objCliente.lCliente_fornecedor_Endereco.FirstOrDefault(i => i.stPrincipal == ((byte)1));


                    if (objEnderecoCliente == null)
                        objEnderecoCliente = this.objCliente.lCliente_fornecedor_Endereco.FirstOrDefault();

                    if (objEnderecoCliente != null)
                        objCidade =
                            GetMethodDataContextWindowValue(xname: "GetCidade", _parameters: new object[] { objEnderecoCliente.idCidade }) as CidadeModel;

                    if (objCidade != null)
                    {
                        idUfEnderecoCliente = objCidade.idUF;

                        if (this.lOrcamento_Itens != null)
                        {
                            foreach (Orcamento_ItemModel item in this.lOrcamento_Itens)
                            {
                                item.objImposto.CalculateVlrIcmsSubstTributaria();
                            }
                        }
                    }
                }

                    #endregion

                if (this.GetOperationModel() == OperationModel.updating)
                {

                    if (this.objCliente != null)
                    {
                        this.idCondicaoPagamento = this.objCliente.idCondicaoPagamento;
                        this.idRamoAtividade = this.objCliente.idRamoAtividade;
                        this.idCanalVenda = this.objCliente.idCanalVenda;
                        this.idDescontos = this.objCliente.idDescontos ?? 0;
                        if (objCliente.cliente_fornecedor_fiscal != null)
                            this.stContribuinteIcms = objCliente.cliente_fornecedor_fiscal.stContribuienteIcms;
                    }

                    if (this.objListaPreco != null)
                    {
                        foreach (var item in this.lOrcamento_Itens)
                        {
                            item.idListaPrecoPai = objListaPreco.idListaPrecoPai ?? 0;
                            item.CalculateVlrDescontoSuframa();
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

                if (this.lOrcamento_Itens != null)
                    foreach (Orcamento_ItemModel item in this.lOrcamento_Itens)
                    {
                        item.xPedidoCliente = value;

                        if (!(string.IsNullOrEmpty(value: value)))
                            item.bPedidoClienteEnabled = false;
                        else
                        {
                            item.bPedidoClienteEnabled = true;
                        }
                    }

                base.NotifyPropertyChanged(propertyName: "xPedidoCliente");
            }
        }
        private string _xNomeEntrega;
        [ParameterOrder(Order = 10)]
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
        [ParameterOrder(Order = 11)]
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
        [ParameterOrder(Order = 12)]
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
        [ParameterOrder(Order = 13)]
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
        [ParameterOrder(Order = 14)]
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
        [ParameterOrder(Order = 15)]
        public int idCondicaoPagamento
        {
            get { return _idCondicaoPagamento; }
            set
            {
                _idCondicaoPagamento = value;

                object retorno = GetMethodDataContextWindowValue(xname: "GetCondicaoPagamento",
                        _parameters: new object[] { value });

                this.objCondicaoPagamento = retorno as Condicao_pagamentoModel;

                base.NotifyPropertyChanged(propertyName: "idCondicaoPagamento");
            }
        }
        private int? _idMotivo;
        [ParameterOrder(Order = 16)]
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
        [ParameterOrder(Order = 17)]
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
        [ParameterOrder(Order = 18)]
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
        [ParameterOrder(Order = 19)]
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
        [ParameterOrder(Order = 20)]
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
        [ParameterOrder(Order = 21)]
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
        [ParameterOrder(Order = 22)]
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
        [ParameterOrder(Order = 23)]
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
        [ParameterOrder(Order = 24)]
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
        [ParameterOrder(Order = 25)]
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
        [ParameterOrder(Order = 26)]
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
        [ParameterOrder(Order = 27)]
        public int idFuncionarioRepresentante
        {
            get { return _idFuncionarioRepresentante; }
            set
            {
                _idFuncionarioRepresentante = value;

                this.objFuncionarioRepresentante = GetMethodDataContextWindowValue(
                        xname: "GetFuncionario", _parameters: new object[] { value }) as FuncionarioModel;

                base.NotifyPropertyChanged(propertyName: "idFuncionarioRepresentante");
            }
        }
        private string _cIdentificacao;
        [ParameterOrder(Order = 28)]
        public string cIdentificacao
        {
            get { return _cIdentificacao; }
            set
            {
                _cIdentificacao = value;
                base.NotifyPropertyChanged(propertyName: "cIdentificacao");
            }
        }
        private int? _idContaContabil;
        [ParameterOrder(Order = 29)]
        public int? idContaContabil
        {
            get { return _idContaContabil; }
            set
            {
                _idContaContabil = value;
                base.NotifyPropertyChanged(propertyName: "idContaContabil");
            }
        }
        private int _idTipoDocumento;
        [ParameterOrder(Order = 30)]
        public int idTipoDocumento
        {
            get { return _idTipoDocumento; }
            set
            {
                if (this.lOrcamento_Itens.Count > 0 && this.GetOperationModel() == OperationModel.updating)
                {
                    if (MessageHlp.Show(stMessage: StMessage.stYesNo, xMessageToUser: "Esta alteração mudará operações válidas dos itens, deseja continuar?")
                         == MessageBoxResult.Yes)
                    {
                        _idTipoDocumento = value;

                        this.objTipoDocumento = GetMethodDataContextWindowValue(
                                    xname: "GetTipoDocumento", _parameters: new object[] { value }) as Tipo_documentoModel;

                        if (objTipoDocumento != null)
                            if (this.orcamento_retTransp != null)
                                this.orcamento_retTransp.xMarcaVolumeNf = this.objTipoDocumento.xMarcaVolumeNf;

                        base.NotifyPropertyChanged(propertyName: "idTipoDocumento");
                    }
                }
                else
                {
                    _idTipoDocumento = value;
                    base.NotifyPropertyChanged(propertyName: "idTipoDocumento");
                }

                this.LoadListTipoDocumento();
            }
        }

        private int _idEmpresa;
        [ParameterOrder(Order = 31)]
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
        [ParameterOrder(Order = 32)]
        public int? idContato
        {
            get { return _idContato; }
            set
            {
                _idContato = value;
                base.NotifyPropertyChanged(propertyName: "idContato");
            }
        }
        private string _nPedidoCliente;
        [ParameterOrder(Order = 33)]
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
        [ParameterOrder(Order = 34)]
        public byte stContribuinteIcms
        {
            get { return _stContribuinteIcms; }
            set
            {
                _stContribuinteIcms = value;

                if (this.lOrcamento_Itens != null)
                    foreach (Orcamento_ItemModel item in this.lOrcamento_Itens)
                    {
                        if (item.objImposto != null)
                            item.objImposto.CalculateBaseIcmsSubstTributaria();
                    }
                base.NotifyPropertyChanged(propertyName: "stContribuinteIcms");
            }
        }
        private int? _idOrcamentoOrigem;
        [ParameterOrder(Order = 35)]
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
        [ParameterOrder(Order = 36)]
        public string xVersaoOrcamento
        {
            get { return _xVersaoOrcamento; }
            set
            {
                _xVersaoOrcamento = value;
                base.NotifyPropertyChanged(propertyName: "xVersaoOrcamento");
            }
        }
        private int? _idFuncionario;
        [ParameterOrder(Order = 37)]
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
        [ParameterOrder(Order = 38)]
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
        [ParameterOrder(Order = 39)]
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
        [ParameterOrder(Order = 40)]
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
            get
            {
                return _lOrcamento_Itens;
            }
            set
            {
                _lOrcamento_Itens = value;
                base.NotifyPropertyChanged(propertyName: "lOrcamento_Itens");
            }
        }

        private Orcamento_Total_ImpostosModel _orcamento_Total_Impostos;

        public Orcamento_Total_ImpostosModel orcamento_Total_Impostos
        {
            get
            {
                return _orcamento_Total_Impostos;
            }
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

    public partial class Orcamento_ItemModel : modelBase, ICloneable
    {
        Familia_produtoModel objFamiliaProduto;
        public ProdutoModel objProduto;

        private object _objDataContext;

        private object GetDataContextWindow()
        {
            //Window w = Sistema.GetOpenWindow(xName: "WinOrcamento");

            //if (_objDataContext == null)
            //    await Application.Current.Dispatcher.BeginInvoke((Action)(() =>
            //    {
            //        _objDataContext = w.DataContext;
            //    }));

            return Orcamento_ideModel.GetDataContextWindow().Result;
        }

        private object GetMethodDataContextWindowValue(string xname, object[] _parameters)
        {
            return Orcamento_ideModel.GetMethodDataContextWindowValue(xname: xname,
                _parameters: _parameters);
        }

        public Orcamento_ItemModel()
            : base(xTabela: "Orcamento_Item")
        {

            this.objImposto = new Orcamento_Item_ImpostosModel();
            objFamiliaProduto = new Familia_produtoModel();
            objProduto = new ProdutoModel();


            if (Orcamento_ideModel.currentModel.GetOperationModel() == OperationModel.updating)
            {
                ObservableCollectionBaseCadastros<Orcamento_Item_RepresentantesModel> lRepresentantes = new ObservableCollectionBaseCadastros<Orcamento_Item_RepresentantesModel>()
                {
                    new Orcamento_Item_RepresentantesModel
                    {  idRepresentante = Orcamento_ideModel.currentModel.idFuncionarioRepresentante }
                };
                this.lOrcamentoItemsRepresentantes = lRepresentantes;
            }

            object objDataContext = null;

            this.bXComercialEnabled = false;

            objDataContext = this.GetDataContextWindow();

            if (objDataContext != null)
            {
                Orcamento_ideModel currentModel = Orcamento_ideModel.currentModel;

                if (currentModel != null)
                {
                    if ((currentModel as modelBase).GetOperationModel() == OperationModel.updating)
                    {
                        this.stOrcamentoItem = (byte)0;

                        if (!(string.IsNullOrEmpty(value: currentModel.xPedidoCliente)))
                        {
                            this.xPedidoCliente = currentModel.xPedidoCliente;
                            this.bPedidoClienteEnabled = false;
                        }
                        else
                        {
                            this.bPedidoClienteEnabled = true;
                        }

                        if ((currentModel as Orcamento_ideModel).lOrcamento_Itens.Count
                            > 0)
                            this.nItem = (currentModel as Orcamento_ideModel).lOrcamento_Itens.Max(i => i.nItem).Value + 1;
                        else
                            this.nItem = 1;

                        if ((currentModel as Orcamento_ideModel).objListaPreco != null)
                            this.idListaPrecoPai = (currentModel as Orcamento_ideModel).objListaPreco.idListaPrecoPai ?? 0;


                        if ((currentModel as Orcamento_ideModel).objDesconto != null)
                            this.pDesconto = (currentModel as Orcamento_ideModel).objDesconto.pDesconto ?? 0;

                        this.idFuncionarioRepresentante = (currentModel as Orcamento_ideModel).idFuncionarioRepresentante;
                    }

                    object retorno = this.GetMethodDataContextWindowValue(xname: "GetOperacoesValidas",
                        _parameters: new object[] { (currentModel as Orcamento_ideModel).idTipoDocumento });

                    if (retorno != null)
                    {
                        this.lTipoOperacao = new ObservableCollection<modelToComboBox>(
                            list: retorno as List<modelToComboBox>);

                        if (lTipoOperacao.Count > 0)
                            this.idTipoOperacao = lTipoOperacao.FirstOrDefault().id;
                    }
                }
            }


        }

        #region Métodos de Cálculos

        public void setxRepresentante()
        {
            if (this.lOrcamentoItemsRepresentantes == null)
            {
                this.xRepresentanteItem = string.Empty;
            }
            else if (this.lOrcamentoItemsRepresentantes.Count() > 1)
            {
                this.xRepresentanteItem = "Vários";
            }
            else if (this.lOrcamentoItemsRepresentantes.Count() == 0)
            {
                this.xRepresentanteItem = string.Empty;
            }
            else
            {
                FuncionarioModel f = (this.GetMethodDataContextWindowValue(
                            xname: "GetFuncionario", _parameters: new object[] { 
                                this.lOrcamentoItemsRepresentantes.FirstOrDefault().idRepresentante }) as FuncionarioModel);

                this.xRepresentanteItem = f.idFuncionario.ToString() + " - " + f.xNome;
            }
        }

        public void DescValidated(decimal p, bool bShowWdSupervisor = true)
        {
            object objDataContext = this.GetDataContextWindow();

            if (objDataContext != null)
            {
                object currentModel = Orcamento_ideModel.currentModel;

                if (currentModel != null)
                {
                    if ((currentModel as modelBase).GetOperationModel() == OperationModel.updating)
                    {
                        this.bPermitePorcentagem = false;
                        Lista_precoModel objItemListaPreco = null;
                        if ((currentModel as Orcamento_ideModel).objListaPreco != null)
                        {
                            if (p < 0) //Desconto
                            {
                                decimal pDescontoMaximo = 100;

                                if ((currentModel as Orcamento_ideModel).objListaPreco.pDescontoMaximo != null)
                                {
                                    pDescontoMaximo = (decimal)(currentModel as Orcamento_ideModel).objListaPreco.pDescontoMaximo;
                                }
                                else
                                {
                                    if ((currentModel as Orcamento_ideModel).objListaPreco.lLista_preco != null)
                                    {
                                        objItemListaPreco = (currentModel as Lista_Preco_PaiModel).lLista_preco.FirstOrDefault(
                                            i => i.idProduto == this.idProduto);

                                        pDescontoMaximo = objItemListaPreco.pDescontoMaximo ?? 0;
                                    }
                                }

                                if (Math.Abs(value: p) > Math.Abs(value: pDescontoMaximo))
                                {
                                    if (bShowWdSupervisor)
                                    {
                                        this.bPermitePorcentagem = (bool)Sistema.ExecuteMethodByReflection(xNamespace: "HLP.Comum.View.WPF",
                                            xType: "wdSenhaSupervisor", xMethod: "WindowShowDialog", parameters: new object[] { });
                                    }
                                    else
                                        this.bPermitePorcentagem = false;
                                }
                                else
                                    this.bPermitePorcentagem = true;
                            }
                            else //Acréscimo
                            {
                                decimal pAcrescimoMaximo = 100;

                                if ((currentModel as Orcamento_ideModel).objListaPreco.pAcressimoMaximo != null)
                                {
                                    pAcrescimoMaximo = (decimal)(currentModel as Orcamento_ideModel).objListaPreco.pAcressimoMaximo;
                                }
                                else
                                {
                                    if ((currentModel as Orcamento_ideModel).objListaPreco.lLista_preco != null)
                                    {
                                        objItemListaPreco = (currentModel as Orcamento_ideModel).objListaPreco.lLista_preco.FirstOrDefault(
                                            i => i.idProduto == this.idProduto);

                                        pAcrescimoMaximo = objItemListaPreco.pAcrescimoMaximo ?? 0;
                                    }
                                }

                                if (p > pAcrescimoMaximo)
                                {
                                    if (bShowWdSupervisor)
                                    {
                                        this.bPermitePorcentagem = (bool)Sistema.ExecuteMethodByReflection(xNamespace: "HLP.Comum.View.WPF",
                                            xType: "wdSenhaSupervisor", xMethod: "WindowShowDialog", parameters: new object[] { });
                                    }
                                    else
                                        this.bPermitePorcentagem = false;
                                }
                                else
                                    this.bPermitePorcentagem = true;
                            }
                        }
                    }
                    else
                        this.bPermitePorcentagem = true;
                }
                else this.bPermitePorcentagem = true;
            }
        }

        public void SetTotalItem()
        {
            try
            {
                object objDataContext = this.GetDataContextWindow();

                if (objDataContext != null)
                {
                    object currentModel = Orcamento_ideModel.currentModel;

                    if (currentModel != null)
                    {
                        if ((currentModel as modelBase).GetOperationModel() == OperationModel.updating)
                        {
                            this.vTotalSemDescontoItem = (this._qProduto * this._vVendaSemDesconto);

                            this.vTotalItem = (this._vVenda + this._vDesconto) * this._qProduto;

                            this.objImposto.CalculateBaseIpi();

                            base.NotifyPropertyChanged(propertyName: "vTotalSemDescontoItem");
                            base.NotifyPropertyChanged(propertyName: "vTotalItem");
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void CalculateVlrDescontoSuframa()
        {
            if (this.GetOrcamentoIde().GetOperationModel()
                    == OperationModel.updating)
            {
                if (this.GetOrcamentoIde().objCliente != null)
                    if (this.GetOrcamentoIde().objCliente.cliente_fornecedor_fiscal != null)
                        if (this.GetOrcamentoIde().objCliente.cliente_fornecedor_fiscal.stDescontaIcmsSuframa ==
                            (byte)1 && !(string.IsNullOrEmpty(value: this.GetOrcamentoIde().objCliente.cliente_fornecedor_fiscal.xCodigoSuframa)))
                        {
                            this.vDescontoSuframa = (1 + (this.GetOrcamentoIde().objCliente.cliente_fornecedor_fiscal.pDescontaIcmsSuframa / 100))
                                * this.vTotalItem;
                        }
            }
        }

        #endregion

        #region Métodos de busca


        #endregion

        #region Propriedades não mapeadas

        public bool stServico { get; set; }

        public bool bPermitePorcentagem { get; set; }

        private ObservableCollection<modelToComboBox> _lUnMedida;

        public ObservableCollection<modelToComboBox> lUnMedida
        {
            get { return _lUnMedida; }
            set
            {
                _lUnMedida = value;
                base.NotifyPropertyChanged(propertyName: "lUnMedida");
            }
        }

        private ObservableCollection<modelToComboBox> _lTipoOperacao;

        public ObservableCollection<modelToComboBox> lTipoOperacao
        {
            get { return _lTipoOperacao; }
            set
            {
                _lTipoOperacao = value;
                base.NotifyPropertyChanged(propertyName: "lTipoOperacao");
            }
        }

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

        private Orcamento_Item_ImpostosModel _objImposto;

        public Orcamento_Item_ImpostosModel objImposto
        {
            get { return _objImposto; }
            set { _objImposto = value; }
        }


        private bool _bPedidoClienteEnabled;

        public bool bPedidoClienteEnabled
        {
            get { return _bPedidoClienteEnabled; }
            set
            {
                _bPedidoClienteEnabled = value;
                base.NotifyPropertyChanged(propertyName: "bPedidoClienteEnabled");
            }
        }


        private string _xUnidadeMedida;

        public string xUnidadeMedida
        {
            get { return _xUnidadeMedida; }
            set
            {
                _xUnidadeMedida = value;
                base.NotifyPropertyChanged(propertyName: "xUnidadeMedida");
            }
        }


        private string _xRepresentanteItem;

        public string xRepresentanteItem
        {
            get { return _xRepresentanteItem; }
            set
            {
                _xRepresentanteItem = value;
                base.NotifyPropertyChanged(propertyName: "xRepresentanteItem");
            }
        }


        #endregion

        private Orcamento_ideModel GetOrcamentoIde()
        {
            Orcamento_ideModel objOrcamento_ide = Orcamento_ideModel.currentModel;
            return objOrcamento_ide ?? new Orcamento_ideModel();
        }

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


                this.objProduto = this.GetMethodDataContextWindowValue(xname: "GetProduto",
                        _parameters: new object[] { value }) as ProdutoModel;

                if (objProduto != null)
                {
                    this.objFamiliaProduto = this.GetMethodDataContextWindowValue(
                            xname: "GetFamiliaProduto", _parameters: new object[] { this.objProduto.idFamiliaProduto })
                            as Familia_produtoModel;

                    if (objFamiliaProduto != null)
                    {
                        if (objFamiliaProduto.stAlteraDescricaoComercialProdutoVenda
                            == 0)
                            this.bXComercialEnabled = false;
                        else
                            this.bXComercialEnabled = true;
                    }

                    this.lUnMedida = new ObservableCollection<modelToComboBox>(collection:
                            this.GetMethodDataContextWindowValue(xname: "GetListUnidadeMedida", _parameters: new object[] { this.objProduto.idProduto }) as List<modelToComboBox>);

                    object currentModel = this.GetOrcamentoIde();

                    if (currentModel != null)
                    {
                        if ((currentModel as modelBase).GetOperationModel() == OperationModel.updating)
                        {
                            this.xComercial = this.objProduto.xComercial;
                            this.objImposto.ICMS_stOrigemMercadoria = objProduto.stOrigemMercadoria;
                            this.nPesoBruto = objProduto.nPesoBruto;
                            this.nPesoLiquido = objProduto.nPesoLiquido;

                            if ((currentModel as Orcamento_ideModel).objListaPreco != null)
                            {
                                Lista_precoModel objListaItem = (currentModel as Orcamento_ideModel).objListaPreco.lLista_preco
                                    .FirstOrDefault(i => i.idProduto == value);

                                if (objListaItem != null)
                                {
                                    this.vVendaSemDesconto = this.vVenda = objListaItem.vVenda;
                                }
                            }
                        }
                    }

                    base.NotifyPropertyChanged(propertyName: "idProduto");
                }
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

                Orcamento_ideModel currentModel = this.GetOrcamentoIde() as Orcamento_ideModel;

                this.objImposto.objTipoOperacao =
                        this.GetMethodDataContextWindowValue(xname: "GetTipoOperacao",
                        _parameters: new object[] { value }) as Tipo_operacaoModel;

                if (currentModel != null)
                {
                    if ((currentModel as modelBase).GetOperationModel() == OperationModel.updating)
                    {
                        //Dúvida: Este Campo, idCfop, poderá ser modificado?
                        this.idCfop = currentModel.idUfEnderecoCliente == currentModel.idUfEnderecoEmpresa ? this.objImposto.objTipoOperacao.cCfopNaUf : this.objImposto.objTipoOperacao.cCfopOutraUf;
                        this.objImposto.idClassificacaoFiscal = this.objImposto.objTipoOperacao.idClassificacaoFiscal != 0 ?
                            this.objImposto.objTipoOperacao.idClassificacaoFiscal : this.objProduto.idClassificacaoFiscalVenda ?? 0;

                        #region IPI

                        this.objImposto.idCSTIpi = this.objImposto.objTipoOperacao.idCSTIpi;
                        if (this.objImposto.objClassificacaoFiscal != null)
                            this.objImposto.IPI_pIPI = this.objImposto.objClassificacaoFiscal.pIPI;
                        else
                            this.objImposto.IPI_pIPI = this.objImposto.objTipoOperacao.pIpi;
                        this.objImposto.IPI_stCompoeBaseCalculo = this.objImposto.objTipoOperacao.stCompoeBaseIpi;
                        this.objImposto.idCSTIpi = this.objImposto.objTipoOperacao.idCSTIpi;

                        #endregion IPI

                        #region ICMS

                        this.objImposto.ICMS_stCalculaIcms = this.objImposto.objTipoOperacao.stCalculaIcms;

                        if (currentModel.objCliente != null)
                            if (currentModel.objCliente.cliente_fornecedor_fiscal != null)
                                if (currentModel.objCliente.cliente_fornecedor_fiscal.stCalculaIcms == (byte)0)
                                    this.objImposto.ICMS_stCalculaIcms = (byte)0;

                        this.objImposto.idCodigoIcmsPai = this.objImposto.objTipoOperacao.idCodigoIcmsPai != 0 ?
                            this.objImposto.objTipoOperacao.idCodigoIcmsPai : this.objProduto.idCodigoIcmsPaiVenda ?? 0;

                        this.objImposto.ICMS_stCompoeBaseCalculo = this.objImposto.objTipoOperacao.stCompoeBaseIcms;

                        this.objImposto.ICMS_stReduzBaseCalculo = this.objImposto.objTipoOperacao.stReduzBase;

                        this.objImposto.ICMS_stNaoReduzBase = this.objImposto.objTipoOperacao.stNaoReduzBase;

                        this.objImposto.idCSTIcms = this.objImposto.objTipoOperacao.idCSTIcms != 0 ?
                            this.objImposto.objTipoOperacao.idCSTIcms : this.objProduto.idCSTIcms ?? 0;

                        #endregion

                        #region ICMS Substituição Tributária

                        this.objImposto.ICMS_stCalculaSubstituicaoTributaria = this.objImposto.objTipoOperacao.stCalculaIcmsSubstituicaoTributaria;
                        this.objImposto.ICMS_stCompoeBaseCalculoSubstituicaoTributaria = this.objImposto.objTipoOperacao.stCalculaIcmsSubstituicaoTributaria;

                        #endregion

                        #region PIS COFINS
                        this.objImposto.stRegimeTributacaoPisCofins = this.objImposto.objTipoOperacao.stRegimeTributacaoPisCofins;

                        this.objImposto.idCSTPis = this.objImposto.objTipoOperacao.idCSTPis;
                        this.objImposto.PIS_pPIS = this.objImposto.objTipoOperacao.pPis;
                        this.objImposto.PIS_nCoeficienteSubstituicaoTributaria = this.objImposto.objTipoOperacao.nCoeficienteSubstituicaoTributariaPis;
                        this.objImposto.PIS_stCompoeBaseCalculoSubstituicaoTributaria = this.objImposto.objTipoOperacao.stCompoeBaseSubtTribPis;

                        this.objImposto.idCSTCofins = this.objImposto.objTipoOperacao.idCSTCofins;
                        this.objImposto.COFINS_nCoeficienteSubstituicaoTributaria = this.objImposto.objTipoOperacao.nCoeficienteSubstituicaoTributariaCofins;
                        this.objImposto.COFINS_stCompoeBaseCalculoSubstituicaoTributaria = this.objImposto.objTipoOperacao.stCompoeBaseSubtTribCofins;
                        this.objImposto.COFINS_pCOFINS = this.objImposto.objTipoOperacao.pCofins;

                        this.objImposto.stCompoeBaseCalculoPisCofins = this.objImposto.objTipoOperacao.stCompoeBaseNormalPiscofins;
                        this.objImposto.stCalculaPisCofins = this.objImposto.objTipoOperacao.stCalculaPisCofins;
                        #endregion

                        #region ISS

                        this.objImposto.ISS_pIss = this.objImposto.objTipoOperacao.pIss;

                        #endregion
                    }
                }

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
                this.objImposto.CalculateBaseIcmsSubstTributaria();
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

                if (this.GetOrcamentoIde().GetOperationModel() == OperationModel.updating)
                {
                    Unidade_medidaModel objUnidadeMedida = null;
                    objUnidadeMedida = this.GetMethodDataContextWindowValue(xname: "GetUnidadeMedida",
                            _parameters: new object[] { value }) as Unidade_medidaModel;
                    if (objUnidadeMedida != null)
                        this.xUnidadeMedida = objUnidadeMedida.xUnidadeMedida;
                }
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

                this.pDesconto = this._pDesconto;

                this.SetTotalItem();
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
                this.SetTotalItem();
            }
        }
        private decimal _pDesconto;
        [ParameterOrder(Order = 18)]
        public decimal pDesconto
        {
            get { return _pDesconto; }
            set
            {
                this.DescValidated(p: value);
                _pDesconto = value;
                this._vDesconto = (this._vVenda * (this._pDesconto / 100));
                this.SetTotalItem();

                base.NotifyPropertyChanged(propertyName: "pDesconto");
                base.NotifyPropertyChanged(propertyName: "vDesconto");
            }
        }
        private decimal _vDesconto;
        [ParameterOrder(Order = 19)]
        public decimal vDesconto
        {
            get { return _vDesconto; }
            set
            {
                decimal pDesconto = decimal.Zero;

                if (this._vVenda > 0)
                    pDesconto = (value / this._vVenda) * 100;

                this.DescValidated(p: pDesconto);
                _vDesconto = value;
                this._pDesconto = pDesconto;
                this.SetTotalItem();
                base.NotifyPropertyChanged(propertyName: "vDesconto");
                base.NotifyPropertyChanged(propertyName: "pDesconto");
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
                this.objImposto.CalculateBaseIpi();
                this.objImposto.CalculateBaseIcms();
                this.objImposto.CalculateBaseIcmsProprio();
                this.objImposto.CalculateBaseIcmsSubstTributaria();
                this.objImposto.CalculateBasePis();
                this.objImposto.CalculateBaseCofins();
                this.CalculateVlrDescontoSuframa();
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
                this.objImposto.CalculateBaseIpi();
                this.objImposto.CalculateBaseIcms();
                this.objImposto.CalculateBaseIcmsProprio();
                this.objImposto.CalculateBaseIcmsSubstTributaria();
                this.objImposto.CalculateBasePis();
                this.objImposto.CalculateBaseCofins();
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

                this.GetOrcamentoIde().orcamento_retTransp.vPesoBruto = decimal.Zero;
                if (this.GetOrcamentoIde().GetOperationModel() == OperationModel.updating)
                {
                    foreach (Orcamento_ItemModel item in this.GetOrcamentoIde().lOrcamento_Itens)
                    {
                        this.GetOrcamentoIde().orcamento_retTransp.vPesoBruto += item.nPesoBruto;
                    }
                }
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

                this.GetOrcamentoIde().orcamento_retTransp.vPesoLiquido = decimal.Zero;
                if (this.GetOrcamentoIde().GetOperationModel() == OperationModel.updating)
                {
                    foreach (Orcamento_ItemModel item in this.GetOrcamentoIde().lOrcamento_Itens)
                    {
                        this.GetOrcamentoIde().orcamento_retTransp.vPesoLiquido += item.nPesoLiquido;
                    }
                }
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

                Orcamento_ideModel objOrcamento_ide = Orcamento_ideModel.currentModel;

                if (objOrcamento_ide != null)
                {
                    if (objOrcamento_ide.lOrcamento_Itens != null)
                    {
                        if (objOrcamento_ide.GetOperationModel() == OperationModel.updating)
                        {
                            List<int> lCountStatus = new List<int>();

                            lCountStatus.Add(item: objOrcamento_ide.lOrcamento_Itens.Count(i => i.stOrcamentoItem == 0));
                            lCountStatus.Add(item: objOrcamento_ide.lOrcamento_Itens.Count(i => i.stOrcamentoItem == 1));
                            lCountStatus.Add(item: objOrcamento_ide.lOrcamento_Itens.Count(i => i.stOrcamentoItem == 2));
                            lCountStatus.Add(item: objOrcamento_ide.lOrcamento_Itens.Count(i => i.stOrcamentoItem == 3));
                            lCountStatus.Add(item: objOrcamento_ide.lOrcamento_Itens.Count(i => i.stOrcamentoItem == 4));

                            byte vStOrcamentoItem = 0;

                            byte.TryParse(s: lCountStatus.IndexOf(item: lCountStatus.FirstOrDefault(
                                i => i == lCountStatus.Max())).ToString(), result: out vStOrcamentoItem);

                            Orcamento_ideModel.currentModel.stOrcamento = vStOrcamentoItem;
                        }
                    }
                }

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
                this.objImposto.CalculateBaseIpi();
                this.objImposto.CalculateBaseIcms();
                this.objImposto.CalculateBaseIcmsProprio();
                this.objImposto.CalculateBaseIcmsSubstTributaria();
                this.objImposto.CalculateBasePis();
                this.objImposto.CalculateBaseCofins();
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
                this.objImposto.CalculateBaseIpi();
                this.objImposto.CalculateBaseIcms();
                this.objImposto.CalculateBaseIcmsProprio();
                this.objImposto.CalculateBaseIcmsSubstTributaria();
                this.objImposto.CalculateBasePis();
                this.objImposto.CalculateBaseCofins();
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

        private int? _nItem;
        [ParameterOrder(Order = 37)]
        public int? nItem
        {
            get { return _nItem; }
            set
            {
                _nItem = value;
                base.NotifyPropertyChanged(propertyName: "nItem");
            }
        }


        private ObservableCollectionBaseCadastros<Orcamento_Item_RepresentantesModel> _lOrcamentoItemsRepresentantes;

        public ObservableCollectionBaseCadastros<Orcamento_Item_RepresentantesModel> lOrcamentoItemsRepresentantes
        {
            get { return _lOrcamentoItemsRepresentantes; }
            set
            {
                _lOrcamentoItemsRepresentantes = value;
                this.setxRepresentante();
                base.NotifyPropertyChanged(propertyName: "lOrcamentoItemsRepresentantes");
            }
        }


        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    public partial class Orcamento_Item_ImpostosModel : modelBase, ICloneable
    {
        private object _objDataContext;

        private object GetDataContextWindow()
        {
            //Window w = Sistema.GetOpenWindow(xName: "WinOrcamento");

            //if (_objDataContext == null)
            //    await Application.Current.Dispatcher.BeginInvoke((Action)(() =>
            //    {
            //        _objDataContext = w.DataContext;
            //    }));

            return Orcamento_ideModel.GetDataContextWindow().Result;
        }

        private object GetMethodDataContextWindowValue(string xname, object[] _parameters)
        {
            return Orcamento_ideModel.GetMethodDataContextWindowValue(xname: xname,
                _parameters: _parameters);
        }

        private Orcamento_ideModel GetOrcamentoIde()
        {
            Orcamento_ideModel objOrcamento_ide = null;

            objOrcamento_ide = Orcamento_ideModel.currentModel;
            return objOrcamento_ide ?? new Orcamento_ideModel();
        }

        public Orcamento_Item_ImpostosModel()
            : base(xTabela: "Orcamento_Item_Impostos")
        {
        }

        #region Objetos Relacionados com FK's

        private Classificacao_fiscalModel _objClassificacaoFiscal;

        public Classificacao_fiscalModel objClassificacaoFiscal
        {
            get { return _objClassificacaoFiscal; }
            set { _objClassificacaoFiscal = value; }
        }


        private Tipo_operacaoModel _objTipoOperacao;

        public Tipo_operacaoModel objTipoOperacao
        {
            get { return _objTipoOperacao; }
            set
            {
                _objTipoOperacao = value;
                this.CalculateTotalIpi();
            }
        }

        #endregion

        #region Métodos de Cálculos

        public void CalculateBaseIpi()
        {
            if (this.GetOrcamentoIde().GetOperationModel()
                    == OperationModel.updating)
            {
                Orcamento_ItemModel objItem = null;

                if (this.GetOrcamentoIde().lOrcamento_Itens != null)
                {
                    objItem = this.GetOrcamentoIde().lOrcamento_Itens.FirstOrDefault(i => i.objImposto == this);
                }

                if (objItem != null)
                {
                    switch (this._IPI_stCompoeBaseCalculo)
                    {
                        case 0:
                            {
                                this.IPI_vBaseCalculo = objItem.vTotalItem;
                            } break;
                        case 1:
                            {
                                this.IPI_vBaseCalculo = objItem.vTotalItem + objItem.vFreteItem;
                            } break;
                        case 2:
                            {
                                this.IPI_vBaseCalculo = objItem.vTotalItem + objItem.vFreteItem + objItem.vSegurosItem + objItem.vOutrasDespesasItem;
                            } break;
                        case 3:
                            {
                                this.IPI_vBaseCalculo = decimal.Zero;
                            } break;
                    }
                }
            }
        }

        public void CalculateTotalIpi()
        {
            if (this.GetOrcamentoIde().GetOperationModel()
                    == OperationModel.updating)
            {
                Orcamento_ItemModel objItem = null;

                if (this.GetOrcamentoIde().lOrcamento_Itens != null)
                {
                    objItem = this.GetOrcamentoIde().lOrcamento_Itens.FirstOrDefault(i => i.objImposto == this);
                }

                if (objItem != null)
                {
                    if (this.GetOrcamentoIde().objCliente.cliente_fornecedor_fiscal.stCalculaIpi == (byte)1)
                    {
                        if (this.IPI_stCalculaIpi == (byte)1)
                        {
                            this.IPI_vIPI = this.IPI_vBaseCalculo * (this.IPI_pIPI / 100);
                        }
                        else
                            this.IPI_vIPI = decimal.Zero;
                    }
                }
            }
        }

        public void CalculatePorcIcms()
        {
            if (this.GetOrcamentoIde().GetOperationModel()
                    == OperationModel.updating)
            {
                Codigo_IcmsModel objCodigoIcms =
                this.GetMethodDataContextWindowValue(xname: "GetCodigoIcmsByUf",
                    _parameters: new object[] { this.idCodigoIcmsPai,
                                        this.GetOrcamentoIde().idUfEnderecoCliente}) as Codigo_IcmsModel;

                if (objCodigoIcms != null)
                    this.ICMS_pICMS = objCodigoIcms.pIcmsEstado;
            }
        }

        public void CalculateBaseIcms()
        {
            if (this.GetOrcamentoIde().GetOperationModel()
                    == OperationModel.updating)
            {
                if (this.ICMS_stCalculaSubstituicaoTributaria == (byte)0)
                {
                    Orcamento_ItemModel objItem = null;

                    if (this.GetOrcamentoIde().lOrcamento_Itens != null)
                    {
                        objItem = this.GetOrcamentoIde().lOrcamento_Itens.FirstOrDefault(i => i.objImposto == this);
                    }

                    if (objItem != null)
                    {
                        switch (this.ICMS_stCompoeBaseCalculo)
                        {
                            case 0:
                                {
                                    this.ICMS_vBaseCalculo = objItem.vTotalItem;
                                } break;
                            case 1:
                                {
                                    this.ICMS_vBaseCalculo = objItem.vTotalItem + this.IPI_vIPI;
                                } break;
                            case 2:
                                {
                                    this.ICMS_vBaseCalculo = objItem.vTotalItem + this.IPI_vIPI + objItem.vFreteItem;
                                } break;
                            case 3:
                                {
                                    this.ICMS_vBaseCalculo = objItem.vTotalItem + this.IPI_vIPI
                                        + objItem.vFreteItem + objItem.vOutrasDespesasItem + objItem.vSegurosItem;
                                } break;
                            case 4:
                                {
                                    this.ICMS_vBaseCalculo = decimal.Zero;
                                } break;
                        }

                        if (this.GetOrcamentoIde().objCliente != null)
                            if (this.GetOrcamentoIde().objCliente.cliente_fornecedor_fiscal != null)
                            {
                                if (this.GetOrcamentoIde().objCliente.cliente_fornecedor_fiscal.stZeraIcms == (byte)1 ||
                                    this.GetOrcamentoIde().objCliente.cliente_fornecedor_fiscal.stCalculaIcms == (byte)0)
                                    this.ICMS_vBaseCalculo = decimal.Zero;
                            }

                        if ((this.ICMS_stReduzBaseCalculo == (byte)1 ||
                            this.ICMS_stReduzBaseCalculo == (byte)2) && this.ICMS_stCompoeBaseCalculo != (byte)4)
                        {
                            this.ICMS_vBaseCalculo -= (this.ICMS_vBaseCalculo * (this.ICMS_pReduzBase / 100));
                        }
                    }
                }
            }
        }

        public void CalculateVlrIcms()
        {
            if (this.GetOrcamentoIde().GetOperationModel()
                    == OperationModel.updating && this._ICMS_stCalculaSubstituicaoTributaria == (byte)0)
            {
                this.ICMS_vICMS = this._ICMS_vBaseCalculo * (this._ICMS_pICMS / 100);
            }
        }

        public void CalculatePorcReducaoBaseIcmsIcmsSt()
        {
            if (this.GetOrcamentoIde().GetOperationModel()
                    == OperationModel.updating)
            {
                if (this.ICMS_stNaoReduzBase == (byte)0)
                {
                    this.ICMS_pReduzBase = this.ICMS_pReduzBaseSubstituicaoTributaria = decimal.Zero;
                }
                else
                {
                    switch (this.ICMS_stReduzBaseCalculo)
                    {
                        case 0:
                            {
                                this.ICMS_pReduzBase = this.ICMS_pReduzBaseSubstituicaoTributaria = decimal.Zero;
                            } break;
                        case 1:
                            {
                                Operacao_reducao_baseModel objOperacaoReducaoBase = this.objTipoOperacao.lOperacaoReducaoBase
                                    .FirstOrDefault(i => i.idUf == this.GetOrcamentoIde().idUfEnderecoCliente);

                                if (objOperacaoReducaoBase != null)
                                {
                                    this.ICMS_pReduzBase = objOperacaoReducaoBase.pReducaoIcms;
                                    this.ICMS_pReduzBaseSubstituicaoTributaria = objOperacaoReducaoBase.pReducaoIcmsSubstTributaria;
                                }
                            } break;
                        case 2:
                            {
                                Operacao_reducao_baseModel objOperacaoReducaoBase = this.objTipoOperacao.lOperacaoReducaoBase
                                    .FirstOrDefault(i => i.idUf == this.GetOrcamentoIde().idUfEnderecoCliente);

                                if (objOperacaoReducaoBase != null)
                                {
                                    this.ICMS_pReduzBase = objOperacaoReducaoBase.pReducaoIcms;
                                }
                            } break;
                        case 3:
                            {
                                Operacao_reducao_baseModel objOperacaoReducaoBase = this.objTipoOperacao.lOperacaoReducaoBase
                                    .FirstOrDefault(i => i.idUf == this.GetOrcamentoIde().idUfEnderecoCliente);

                                if (objOperacaoReducaoBase != null)
                                {
                                    this.ICMS_pReduzBaseSubstituicaoTributaria = objOperacaoReducaoBase.pReducaoIcmsSubstTributaria;
                                }
                            } break;
                    }

                    Orcamento_ItemModel objItem = null;

                    if (this.GetOrcamentoIde().lOrcamento_Itens != null)
                    {
                        objItem = this.GetOrcamentoIde().lOrcamento_Itens.FirstOrDefault(i => i.objImposto == this);
                    }

                    if (objItem != null)
                    {
                        if (objItem.stConsumidorFinal == (byte)1)
                            this.ICMS_pReduzBase = decimal.Zero;
                    }
                }

                this.CalculateBaseIcms();
                this.CalculateBaseIcmsProprio();
            }
        }

        public void CalculatePorcMvaSubstTributaria()
        {
            if (this.GetOrcamentoIde().GetOperationModel()
                    == OperationModel.updating)
            {
                Codigo_IcmsModel objCodigoIcms =
                    this.GetMethodDataContextWindowValue(xname: "GetCodigoIcmsByUf", _parameters:
                        new object[] { this.idCodigoIcmsPai,
                                        this.GetOrcamentoIde().idUfEnderecoCliente}) as Codigo_IcmsModel;
                if (objCodigoIcms != null)
                    if (this.ICMS_stCalculaSubstituicaoTributaria == (byte)1)
                    {
                        this.ICMS_pMvaSubstituicaoTributaria = objCodigoIcms.pMvaSubstituicaoTributaria;
                    }
                    else
                        this.ICMS_pMvaSubstituicaoTributaria = decimal.Zero;
            }
        }

        public void CalculateBaseIcmsSubstTributaria()
        {
            if (this.GetOrcamentoIde().GetOperationModel()
                    == OperationModel.updating)
            {
                Orcamento_ItemModel objItem = null;

                if (this.GetOrcamentoIde().lOrcamento_Itens != null)
                {
                    objItem = this.GetOrcamentoIde().lOrcamento_Itens.FirstOrDefault(i => i.objImposto == this);
                }

                if (objItem != null)
                {
                    if (this.ICMS_stCalculaSubstituicaoTributaria == (byte)1 && objItem.stConsumidorFinal == (byte)0)
                    {
                        if (objItem.stConsumidorFinal == (byte)1 &&
                            this.GetOrcamentoIde().stContribuinteIcms == (byte)0)
                            this._ICMS_stCompoeBaseCalculoSubstituicaoTributaria = (byte)6;

                        switch (this.ICMS_stCompoeBaseCalculoSubstituicaoTributaria)
                        {
                            case 0:
                                {
                                    this.ICMS_vBaseCalculoSubstituicaoTributaria =
                                        (objItem.vTotalItem * (this.ICMS_pMvaSubstituicaoTributaria / 100)) + objItem.vTotalItem;
                                } break;
                            case 1:
                                {
                                    this.ICMS_vBaseCalculoSubstituicaoTributaria =
                                        ((objItem.vTotalItem + this.IPI_vIPI)
                                        * (this.ICMS_pMvaSubstituicaoTributaria / 100)) + objItem.vTotalItem;
                                } break;
                            case 2:
                                {
                                    this.ICMS_vBaseCalculoSubstituicaoTributaria =
                                        ((objItem.vTotalItem + this.IPI_vIPI + objItem.vFreteItem)
                                        * (this.ICMS_pMvaSubstituicaoTributaria / 100)) + objItem.vTotalItem;
                                } break;
                            case 3:
                                {
                                    this.ICMS_vBaseCalculoSubstituicaoTributaria =
                                        ((objItem.vTotalItem + this.IPI_vIPI + objItem.vFreteItem + objItem.vSegurosItem + objItem.vOutrasDespesasItem)
                                        * (this.ICMS_pMvaSubstituicaoTributaria / 100)) + objItem.vTotalItem;
                                } break;
                            case 4:
                                {
                                    //TODO: CÁLCULO ESTÁ ESTRANHO, VERIFICAR COM PAULO
                                    //TODO: MOTIVO: ESTÁ SENDO SOMADO ICMS PRÓPRIO COM VALOR DE SUBSTITUIÇÃO TRIBUTÁRIA, MAS O VALOR DA SUBSTITUIÇÃO TRIBUTÁRIA FINAL NÃO DEPENDE DA BASE DE CÁLCULO QUE ESTÁ SENDO CALCULADA AQUI?
                                    if (this.ICMS_pIcmsInterno != 0)
                                        this.ICMS_vBaseCalculoSubstituicaoTributaria = (this.ICMS_vIcmsProprio + this.ICMS_vSubstituicaoTributaria)
                                            / this.ICMS_pIcmsInterno;
                                    else
                                        this.ICMS_vBaseCalculoSubstituicaoTributaria = decimal.Zero;
                                } break;
                            case 5:
                                {
                                    this.ICMS_vBaseCalculoSubstituicaoTributaria = decimal.Zero;
                                } break;
                        }

                        if ((this.ICMS_stReduzBaseCalculo == (byte)1 || this.ICMS_stReduzBaseCalculo == (byte)3)
                            && this.ICMS_stCompoeBaseCalculo != (byte)4)
                        {
                            //TODO: CÁLCULO ESTÁ ESTRANHO, VERIFICAR COM PAULO
                            //(((“Orcamento_Item.vTotalItem” – (“Orcamento_Item.vTotalItem” X “pReduzBaseSubstituicaoTributaria” / 100) + 
                            //    “Orçamento_Item_Impostos.IPI_vIPI” + “Orcamento_Item.vFreteItem” + campo “Orcamento_Item.vSegurosItem” + 
                            //        “Orcamento_Item.vOutrasDespesasItem”) X “Orçamento_Item_Impostos.ICMS_pMvaSubstituicaoTributaria” / 100) + 
                            //            “Orcamento_Item.vTotalItem”);

                            this.ICMS_vBaseCalculoSubstituicaoTributaria -= (((this.ICMS_vBaseCalculoSubstituicaoTributaria *
                                (this.ICMS_pReduzBaseSubstituicaoTributaria / 100)) +
                                this.IPI_vIPI + objItem.vFreteItem + objItem.vSegurosItem + objItem.vOutrasDespesasItem)
                                * (this.ICMS_pMvaSubstituicaoTributaria / 100)) + objItem.vTotalItem;
                        }
                    }
                }
            }
        }

        public void CalculateVlrIcmsSubstTributaria()
        {
            if (this.GetOrcamentoIde().GetOperationModel()
                    == OperationModel.updating)
            {
                Orcamento_ItemModel objItem = null;

                if (this.GetOrcamentoIde().lOrcamento_Itens != null)
                {
                    objItem = this.GetOrcamentoIde().lOrcamento_Itens.FirstOrDefault(i => i.objImposto == this);
                }

                if (objItem != null)
                {
                    if (this.GetOrcamentoIde().GetOperationModel()
                    == OperationModel.updating)
                    {
                        Ramo_atividadeModel objRamoAtividade = this.GetMethodDataContextWindowValue(
                                xname: "GetRamoAtividade", _parameters:
                                new object[] { this.GetOrcamentoIde().idRamoAtividade }) as Ramo_atividadeModel;

                        UFModel objUf = this.GetMethodDataContextWindowValue(xname: "GetUf",
                            _parameters: new object[] { this.GetOrcamentoIde().idUfEnderecoCliente }) as UFModel;


                        Parametro_FiscalModel objParametroFiscal = null;

                        Cliente_fornecedorModel objCliente = GetOrcamentoIde().objCliente;

                        if ((CompanyData.objEmpresaModel as EmpresaModel).empresaParametros != null)
                            objParametroFiscal = (CompanyData.objEmpresaModel as EmpresaModel).empresaParametros.ObjParametro_FiscalModel;

                        if (this.ICMS_stCalculaSubstituicaoTributaria == (byte)0)
                        {
                            this._ICMS_vBaseCalculoSubstituicaoTributaria = this.ICMS_vSubstituicaoTributaria = decimal.Zero;
                            base.NotifyPropertyChanged(propertyName: "ICMS_vBaseCalculoSubstituicaoTributaria");
                        }
                        else
                        {
                            if (this.ICMS_stCalculaSubstituicaoTributaria == (byte)1
                            && objItem.stConsumidorFinal == (byte)0
                                && this.GetOrcamentoIde().stContribuinteIcms == (byte)1
                                && (objCliente != null ? objCliente.cliente_fornecedor_fiscal.stSubsticaoTributariaIcmsDiferenciada : (byte)1) != (byte)0)
                            {
                                this.ICMS_vSubstituicaoTributaria =
                                    (this.ICMS_vBaseCalculoSubstituicaoTributaria * this.ICMS_pIcmsInterno / 100) - (this.ICMS_vICMS * this.ICMS_pIcmsInterno);
                            }
                            else if (this.ICMS_stCalculaSubstituicaoTributaria == (byte)1
                                && objItem.stConsumidorFinal == (byte)1
                                && this.GetOrcamentoIde().stContribuinteIcms == (byte)1
                                && (objRamoAtividade != null ? objRamoAtividade.xRamo : "").ToUpper() == "1-COMERCIO"
                                && this.GetOrcamentoIde().idUfEnderecoCliente != this.GetOrcamentoIde().idUfEnderecoEmpresa
                                )
                            {
                                this.ICMS_vSubstituicaoTributaria = this.ICMS_vBaseCalculoSubstituicaoTributaria *
                                    ((this.ICMS_pICMS - this.ICMS_pIcmsInterno) / 100);
                            }
                            else if (this.ICMS_stCalculaSubstituicaoTributaria == (byte)1
                                && objItem.stConsumidorFinal == (byte)0
                                && this.GetOrcamentoIde().stContribuinteIcms == (byte)1
                                && (objCliente != null ? objCliente.cliente_fornecedor_fiscal.stSubsticaoTributariaIcmsDiferenciada : (byte)0) != (byte)1
                                && (objUf != null ? objUf.xSiglaUf.ToUpper() : "") == "MT"
                                )
                            {
                                //TODO: REVISAR CÁLCULO COM PAULO
                                //OBS: NO MEIO DO CÁLCULO ESTÁ SENDO SUBTRAIDO VALORES POR % REDUÇÃO BASE ST E NO FIM MULTIPLICADO POR UM CAMPO ST
                                //(((“Orcamento_Item.vTotalItem” – (“Orçamento_Item_Impostos.ICMS_pReduzBaseSubstituicaoTributaria” / 100)
                                //    + “Orçamento_Item_Impostos.IPI_vIPI” + “Orcamento_Item.vFreteItem” + “Orcamento_Item.vSegurosItem” 
                                //        + “Orcamento_Item.vOutrasDespesasItem”) x (“Orçamento_Item_Impostos.ICMS_stCalculaSubstituicaoTributaria”))                                
                            }
                            else if (this.ICMS_stCalculaSubstituicaoTributaria == (byte)1
                                && objItem.stConsumidorFinal == (byte)1
                                && this.GetOrcamentoIde().stContribuinteIcms == (byte)0
                                && (objParametroFiscal != null ? objParametroFiscal.stIcmsSubstDif : (byte)0) == (byte)1
                                && (objRamoAtividade != null ? objRamoAtividade.xRamo : "").ToUpper() == "1-COMERCIO"
                                && this.GetOrcamentoIde().idUfEnderecoCliente == this.GetOrcamentoIde().idUfEnderecoEmpresa
                                && (objCliente != null ? objCliente.cliente_fornecedor_fiscal.stSubsticaoTributariaIcmsDiferenciada : (byte)1) != (byte)0
                                )
                            {
                                this._ICMS_vBaseCalculoSubstituicaoTributaria = this.ICMS_vSubstituicaoTributaria = decimal.Zero;
                                base.NotifyPropertyChanged(propertyName: "ICMS_vBaseCalculoSubstituicaoTributaria");
                            }
                            else if (this.ICMS_stCalculaSubstituicaoTributaria == (byte)1
                                && objItem.stConsumidorFinal == (byte)1
                                && this.GetOrcamentoIde().stContribuinteIcms == (byte)1
                                && (objParametroFiscal != null ? objParametroFiscal.stIcmsSubstDif : (byte)1) == (byte)0
                                && (objRamoAtividade != null ? objRamoAtividade.xRamo : "").ToUpper() == "1-COMERCIO"
                                && this.GetOrcamentoIde().idUfEnderecoCliente != this.GetOrcamentoIde().idUfEnderecoEmpresa
                                && (objCliente != null ? objCliente.cliente_fornecedor_fiscal.stSubsticaoTributariaIcmsDiferenciada : (byte)1) != (byte)0
                                )
                            {
                                this._ICMS_vBaseCalculoSubstituicaoTributaria = this.ICMS_vSubstituicaoTributaria = decimal.Zero;
                                base.NotifyPropertyChanged(propertyName: "ICMS_vBaseCalculoSubstituicaoTributaria");
                            }
                            else if (this.ICMS_stCalculaSubstituicaoTributaria == (byte)1
                                && objItem.stConsumidorFinal == (byte)1
                                && this.GetOrcamentoIde().stContribuinteIcms == (byte)1
                                && (objParametroFiscal != null ? objParametroFiscal.stIcmsSubstDif : (byte)0) == (byte)1
                                && (objRamoAtividade != null ? objRamoAtividade.xRamo : "").ToUpper() == "1-COMERCIO"
                                && this.GetOrcamentoIde().idUfEnderecoCliente != this.GetOrcamentoIde().idUfEnderecoEmpresa
                                && (objCliente != null ? objCliente.cliente_fornecedor_fiscal.stSubsticaoTributariaIcmsDiferenciada : (byte)1) != (byte)0
                                )
                            {
                                this._ICMS_vBaseCalculoSubstituicaoTributaria = this.ICMS_vSubstituicaoTributaria = decimal.Zero;
                                base.NotifyPropertyChanged(propertyName: "ICMS_vBaseCalculoSubstituicaoTributaria");
                            }
                        }
                    }
                }
            }
        }

        public void CalculateBaseIcmsProprio()
        {
            if (this.GetOrcamentoIde().GetOperationModel()
                    == OperationModel.updating)
            {
                if (this.ICMS_stCalculaSubstituicaoTributaria == (byte)1)
                {
                    Orcamento_ItemModel objItem = null;

                    if (this.GetOrcamentoIde().lOrcamento_Itens != null)
                    {
                        objItem = this.GetOrcamentoIde().lOrcamento_Itens.FirstOrDefault(i => i.objImposto == this);
                    }

                    if (objItem != null)
                    {
                        switch (this.ICMS_stCompoeBaseCalculo)
                        {
                            case 0:
                                {
                                    this.ICMS_vBaseCalculoIcmsProprio = objItem.vTotalItem;
                                } break;
                            case 1:
                                {
                                    this.ICMS_vBaseCalculoIcmsProprio = objItem.vTotalItem + this.IPI_vIPI;
                                } break;
                            case 2:
                                {
                                    this.ICMS_vBaseCalculoIcmsProprio = objItem.vTotalItem + this.IPI_vIPI + objItem.vFreteItem;
                                } break;
                            case 3:
                                {
                                    this.ICMS_vBaseCalculoIcmsProprio = objItem.vTotalItem + this.IPI_vIPI
                                        + objItem.vFreteItem + objItem.vOutrasDespesasItem + objItem.vSegurosItem;
                                } break;
                            case 4:
                                {
                                    this.ICMS_vBaseCalculoIcmsProprio = decimal.Zero;
                                } break;
                        }

                        if ((this.ICMS_stReduzBaseCalculo == (byte)1 ||
                            this.ICMS_stReduzBaseCalculo == (byte)2) && this.ICMS_stCompoeBaseCalculo != (byte)4)
                        {
                            this.ICMS_vBaseCalculoIcmsProprio -= (this.ICMS_vBaseCalculoIcmsProprio * (this.ICMS_pReduzBase / 100));
                        }
                    }
                }
            }
        }

        public void CalculateVlrIcmsProprio()
        {
            if (this.GetOrcamentoIde().GetOperationModel()
                    == OperationModel.updating && this._ICMS_stCalculaSubstituicaoTributaria == (byte)1)
            {
                this.ICMS_vIcmsProprio = this.ICMS_vBaseCalculoIcmsProprio * (this.ICMS_pICMS / 100);
            }
        }

        public void CalculatePorcIcmsInterno()
        {
            if (this.GetOrcamentoIde().GetOperationModel()
                    == OperationModel.updating)
            {

                Codigo_IcmsModel objCodigoIcms = this.GetMethodDataContextWindowValue(
                        xname: "GetCodigoIcmsByUf", _parameters: new object[] { this.idCodigoIcmsPai,
                                        this.GetOrcamentoIde().idUfEnderecoCliente}) as Codigo_IcmsModel;

                if (objCodigoIcms != null)
                {
                    if (this.ICMS_stCalculaSubstituicaoTributaria == (byte)1)
                        this.ICMS_pIcmsInterno = objCodigoIcms.pIcmsInterna;
                    else
                        this.ICMS_pIcmsInterno = decimal.Zero;
                }
            }
        }

        public void CalculateBasePis()
        {
            if (this.GetOrcamentoIde().GetOperationModel()
                    == OperationModel.updating)
            {
                Orcamento_ItemModel objItem = null;

                if (this.GetOrcamentoIde().lOrcamento_Itens != null)
                {
                    objItem = this.GetOrcamentoIde().lOrcamento_Itens.FirstOrDefault(i => i.objImposto == this);
                }

                if (objItem != null)
                {


                    switch (this.stCalculaPisCofins)
                    {
                        case 0:
                            {
                                this.PIS_vBaseCalculo = decimal.Zero;
                                this._stCompoeBaseCalculoPisCofins = (byte)4;
                                base.NotifyPropertyChanged(propertyName: "stCompoeBaseCalculoPisCofins");
                                this._PIS_stCompoeBaseCalculoSubstituicaoTributaria = (byte)4;
                                base.NotifyPropertyChanged(propertyName: "PIS_stCompoeBaseCalculoSubstituicaoTributaria");
                            } break;
                        case 1:
                            {
                                switch (this.stCompoeBaseCalculoPisCofins)
                                {
                                    case 0:
                                        {
                                            this.PIS_vBaseCalculo = objItem.vTotalItem;
                                        } break;
                                    case 1:
                                        {
                                            this.PIS_vBaseCalculo = objItem.vTotalItem + this.IPI_vIPI;
                                        } break;
                                    case 2:
                                        {
                                            this.PIS_vBaseCalculo = objItem.vTotalItem + this.IPI_vIPI + objItem.vFreteItem;
                                        } break;
                                    case 3:
                                        {
                                            this.PIS_vBaseCalculo = objItem.vTotalItem + this.IPI_vIPI + objItem.vFreteItem + objItem.vSegurosItem + objItem.vOutrasDespesasItem;
                                        } break;
                                    case 4:
                                        {
                                            this.PIS_vBaseCalculo = decimal.Zero;
                                        } break;
                                }

                                this._PIS_stCompoeBaseCalculoSubstituicaoTributaria = (byte)4;
                                base.NotifyPropertyChanged(propertyName: "PIS_stCompoeBaseCalculoSubstituicaoTributaria");
                            } break;
                        case 2:
                            {
                                switch (this.PIS_stCompoeBaseCalculoSubstituicaoTributaria)
                                {
                                    case 0:
                                        {
                                            this.PIS_vBaseCalculo = objItem.vTotalItem;
                                        } break;
                                    case 1:
                                        {
                                            this.PIS_vBaseCalculo = objItem.vTotalItem + this.IPI_vIPI;
                                        } break;
                                    case 2:
                                        {
                                            this.PIS_vBaseCalculo = objItem.vTotalItem + this.IPI_vIPI + objItem.vFreteItem;
                                        } break;
                                    case 3:
                                        {
                                            this.PIS_vBaseCalculo = objItem.vTotalItem + this.IPI_vIPI + objItem.vFreteItem + objItem.vSegurosItem + objItem.vOutrasDespesasItem;
                                        } break;
                                    case 4:
                                        {
                                            this.PIS_vBaseCalculo = decimal.Zero;
                                        } break;
                                }

                                this._stCompoeBaseCalculoPisCofins = (byte)4;
                                base.NotifyPropertyChanged(propertyName: "stCompoeBaseCalculoPisCofins");
                            } break;
                    }
                }
            }
        }

        public void CalculateBaseCofins()
        {
            if (this.GetOrcamentoIde().GetOperationModel()
                    == OperationModel.updating)
            {
                Orcamento_ItemModel objItem = null;

                if (this.GetOrcamentoIde().lOrcamento_Itens != null)
                {
                    objItem = this.GetOrcamentoIde().lOrcamento_Itens.FirstOrDefault(i => i.objImposto == this);
                }

                if (objItem != null)
                {
                    switch (this.stCalculaPisCofins)
                    {
                        case 0:
                            {
                                this.COFINS_vBaseCalculo = decimal.Zero;
                                this._stCompoeBaseCalculoPisCofins = (byte)4;
                                base.NotifyPropertyChanged(propertyName: "stCompoeBaseCalculoPisCofins");
                                this._COFINS_stCompoeBaseCalculoSubstituicaoTributaria = (byte)4;
                                base.NotifyPropertyChanged(propertyName: "COFINS_stCompoeBaseCalculoSubstituicaoTributaria");
                            } break;
                        case 1:
                            {
                                switch (this.stCompoeBaseCalculoPisCofins)
                                {
                                    case 0:
                                        {
                                            this.COFINS_vBaseCalculo = objItem.vTotalItem;
                                        } break;
                                    case 1:
                                        {
                                            this.COFINS_vBaseCalculo = objItem.vTotalItem + this.IPI_vIPI;
                                        } break;
                                    case 2:
                                        {
                                            this.COFINS_vBaseCalculo = objItem.vTotalItem + this.IPI_vIPI + objItem.vFreteItem;
                                        } break;
                                    case 3:
                                        {
                                            this.COFINS_vBaseCalculo = objItem.vTotalItem + this.IPI_vIPI + objItem.vFreteItem + objItem.vSegurosItem + objItem.vOutrasDespesasItem;
                                        } break;
                                    case 4:
                                        {
                                            this.COFINS_vBaseCalculo = decimal.Zero;
                                        } break;
                                }
                                this._COFINS_stCompoeBaseCalculoSubstituicaoTributaria = (byte)4;
                                base.NotifyPropertyChanged(propertyName: "COFINS_stCompoeBaseCalculoSubstituicaoTributaria");
                            } break;
                        case 2:
                            {
                                switch (this.COFINS_stCompoeBaseCalculoSubstituicaoTributaria)
                                {
                                    case 0:
                                        {
                                            this.COFINS_vBaseCalculo = objItem.vTotalItem;
                                        } break;
                                    case 1:
                                        {
                                            this.COFINS_vBaseCalculo = objItem.vTotalItem + this.IPI_vIPI;
                                        } break;
                                    case 2:
                                        {
                                            this.COFINS_vBaseCalculo = objItem.vTotalItem + this.IPI_vIPI + objItem.vFreteItem;
                                        } break;
                                    case 3:
                                        {
                                            this.COFINS_vBaseCalculo = objItem.vTotalItem + this.IPI_vIPI + objItem.vFreteItem + objItem.vSegurosItem + objItem.vOutrasDespesasItem;
                                        } break;
                                    case 4:
                                        {
                                            this.COFINS_vBaseCalculo = decimal.Zero;
                                        } break;
                                }

                                this._stCompoeBaseCalculoPisCofins = (byte)4;
                                base.NotifyPropertyChanged(propertyName: "stCompoeBaseCalculoPisCofins");
                            } break;
                    }
                }
            }
        }

        public void CalculateVlrPis()
        {
            if (this.GetOrcamentoIde().GetOperationModel()
                    == OperationModel.updating)
            {
                switch (this.stCalculaPisCofins)
                {
                    case 0:
                        {
                            this.PIS_vPIS = decimal.Zero;
                        } break;
                    case 1:
                    case 2:
                        {
                            this.PIS_vPIS = this.PIS_vBaseCalculo * (this.PIS_pPIS / 100);
                        } break;
                }
            }
        }

        public void CalculateVlrCofins()
        {
            if (this.GetOrcamentoIde().GetOperationModel()
                    == OperationModel.updating)
            {
                switch (this.stCalculaPisCofins)
                {
                    case 0:
                        {
                            this.COFINS_vCOFINS = decimal.Zero;
                        } break;
                    case 1:
                    case 2:
                        {
                            this.COFINS_vCOFINS = this.COFINS_vBaseCalculo * (this.COFINS_pCOFINS / 100);
                        } break;
                }
            }
        }

        #endregion

        #region Propriedades não Mapeadas

        private string _xNcm;

        public string xNcm
        {
            get { return _xNcm; }
            set
            {
                _xNcm = value;
                base.NotifyPropertyChanged(propertyName: "xNcm");
            }
        }

        #endregion

        //Propriedade criada apenas para utilização do filtro de situação dos impostos
        public byte stOrcamentoImpostos { get; set; }

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
                this.CalculateVlrIcms();
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
                this.CalculateBaseIcms();
                this.CalculateBaseIcmsProprio();
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
                this.CalculateVlrIcms();
                this.CalculateVlrIcmsProprio();
                this.CalculateVlrIcmsSubstTributaria();
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
                this.CalculateVlrIcmsSubstTributaria();
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
                this.CalculateBaseIcmsSubstTributaria();
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
                this.CalculateBaseIcmsSubstTributaria();
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
                this.CalculateVlrIcmsSubstTributaria();
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
                this.CalculatePorcReducaoBaseIcmsIcmsSt();
                this.CalculateBaseIcmsSubstTributaria();
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
                this.CalculateBaseIcms();
                this.CalculateBaseIcmsProprio();
                this.CalculateBaseIcmsSubstTributaria();
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
                this.CalculateBaseIcmsSubstTributaria();
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
                this.CalculateVlrIcmsProprio();
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
                this.CalculateBaseIcmsSubstTributaria();
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
                this.CalculateBaseIcmsSubstTributaria();
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
                this.CalculateBaseIcms();
                this.CalculateBaseIcmsProprio();
                this.CalculatePorcMvaSubstTributaria();
                this.CalculateBaseIcmsSubstTributaria();
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

                if (this.GetOrcamentoIde().GetOperationModel() ==
                     OperationModel.updating)
                {
                    if (this.GetOrcamentoIde().objCliente != null)
                        if (this.GetOrcamentoIde().objCliente.cliente_fornecedor_fiscal != null)
                            if (this.GetOrcamentoIde().objCliente.cliente_fornecedor_fiscal.stZeraIcms == (byte)0)
                            {
                                if (this.ICMS_stCalculaIcms == (byte)1)
                                {
                                    this.CalculatePorcIcms();
                                }
                                else
                                    this.ICMS_pICMS = decimal.Zero;
                            }
                            else
                                this.ICMS_pICMS = decimal.Zero;

                    this.CalculatePorcMvaSubstTributaria();
                }

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
                this.CalculateTotalIpi();
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

                this.CalculateTotalIpi();
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
                this._IPI_vIPI = value;
                this.CalculateBaseIcms();
                this.CalculateBaseIcmsProprio();
                this.CalculateBaseIcmsSubstTributaria();
                this.CalculateBasePis();
                this.CalculateBaseCofins();
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
                this.CalculateTotalIpi();
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

                this.CalculateBaseIpi();
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

                Orcamento_ideModel currentModel = this.GetOrcamentoIde();

                this.objClassificacaoFiscal = this.GetMethodDataContextWindowValue(xname: "GetClassificacaoFiscal",
                    _parameters: new object[] { value })
                    as Classificacao_fiscalModel;

                this.xNcm = objClassificacaoFiscal.cNCM;

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
                this.ISS_vIss = value * (this.ISS_pIss / 100);
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
                this.ISS_vIss = this.ISS_vBaseCalculo * (value / 100);
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
                this.CalculateVlrPis();
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
                this.CalculateVlrPis();
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
                this.CalculateBasePis();
                this.CalculateBaseCofins();
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
                //TODO: Verificar utilidade deste campo, já que não está sendo utilizado em nenhum cálculo
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
                this.CalculateBasePis();
                this.CalculateBaseCofins();
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
                this.CalculateBasePis();
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
                this.CalculateVlrCofins();
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
                this.CalculateVlrCofins();
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
                //TODO: Verificar utilidade deste campo, já que não está sendo utilizado em nenhum cálculo
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
                this.CalculateBaseCofins();
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
                this.CalculatePorcReducaoBaseIcmsIcmsSt();
                base.NotifyPropertyChanged(propertyName: "ICMS_stNaoReduzBase");
            }
        }

        private int? _nItem;
        [ParameterOrder(Order = 54)]
        public int? nItem
        {
            get { return _nItem; }
            set
            {
                _nItem = value;
                base.NotifyPropertyChanged(propertyName: "nItem");
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    public partial class Orcamento_Item_RepresentantesModel : modelBase, ICloneable
    {
        private object GetDataContextWindow()
        {
            return Orcamento_ideModel.GetDataContextWindow().Result;
        }

        private object GetMethodDataContextWindowValue(string xname, object[] _parameters)
        {
            return Orcamento_ideModel.GetMethodDataContextWindowValue(xname: xname,
                _parameters: _parameters);
        }

        public Orcamento_Item_RepresentantesModel()
        {
        }

        private int _idOrcamentoItemRepresentate;
        [ParameterOrder(Order = 1)]
        public int idOrcamentoItemRepresentate
        {
            get { return _idOrcamentoItemRepresentate; }
            set
            {
                _idOrcamentoItemRepresentate = value;
                base.NotifyPropertyChanged(propertyName: "idOrcamentoItemRepresentate");
            }
        }
        private int _idRepresentante;
        [ParameterOrder(Order = 2)]
        public int idRepresentante
        {
            get { return _idRepresentante; }
            set
            {
                _idRepresentante = value;

                if (Orcamento_ideModel.currentModel.GetOperationModel() == OperationModel.updating)
                {
                    #region Cálculo de Comissão
                    Orcamento_ideModel objOrcamento_ide = Orcamento_ideModel.currentModel;

                    if (objOrcamento_ide != null)
                    {
                        Orcamento_ItemModel currentItem = null;

                        foreach (Orcamento_ItemModel it in objOrcamento_ide.lOrcamento_Itens)
                        {
                            if (it.lOrcamentoItemsRepresentantes.Contains(item: this))
                                currentItem = it;
                        }

                        if (currentItem != null)
                        {


                            byte stVistaPrazo = 0;
                            byte stComissao = 1;

                            if (objOrcamento_ide.objCondicaoPagamento != null)
                            {
                                stVistaPrazo = objOrcamento_ide.objCondicaoPagamento.stCondicao; // 0 - a Vista : 1 - a Prazo
                            }

                            if (objOrcamento_ide.objFuncionarioRepresentante != null)
                            {
                                stComissao = objOrcamento_ide.objFuncionarioRepresentante.stComissao ?? 1;
                            }

                            switch (stComissao)
                            {
                                case 0:
                                    {
                                        switch (stVistaPrazo)
                                        {
                                            case 0:
                                                {
                                                    this.pComissao = objOrcamento_ide.objFuncionarioRepresentante.pComissaoAvista;
                                                } break;
                                            case 1:
                                                {
                                                    this.pComissao = objOrcamento_ide.objFuncionarioRepresentante.pComissaoAprazo;
                                                } break;
                                        }
                                    } break;
                                case 1:
                                    {
                                        Lista_precoModel objListaItem = objOrcamento_ide.objListaPreco.lLista_preco.
                                            FirstOrDefault(i => i.idProduto == currentItem.idProduto);

                                        if (objListaItem != null)
                                        {

                                            switch (stVistaPrazo)
                                            {
                                                case 0:
                                                    {
                                                        this.pComissao = objListaItem.pComissaoAvista;
                                                    } break;
                                                case 1:
                                                    {
                                                        this.pComissao = objListaItem.pComissaoAprazo;
                                                    } break;
                                            }
                                        }
                                    } break;
                                case 2:
                                    {
                                        Familia_produtoModel objFamiliaProduto = null;

                                        objFamiliaProduto = this.GetMethodDataContextWindowValue(
                                                xname: "GetFamiliaProduto", _parameters: new object[] { currentItem.objProduto.idFamiliaProduto }) as Familia_produtoModel;

                                        switch (stVistaPrazo)
                                        {
                                            case 0:
                                                {
                                                    this.pComissao = objFamiliaProduto.pComissaoAvista;
                                                } break;
                                            case 1:
                                                {
                                                    this.pComissao = objFamiliaProduto.pComissaoAprazo;
                                                } break;
                                        }
                                    } break;
                                case 3:
                                    {
                                        Funcionario_Comissao_ProdutoModel objFuncionarioComissaoProduto = objOrcamento_ide.objFuncionarioRepresentante.lFuncionario_Comissao_Produto
                                                        .FirstOrDefault(i => i.idProduto == currentItem.idProduto);
                                        switch (stVistaPrazo)
                                        {
                                            case 0:
                                                {
                                                    this.pComissao = objFuncionarioComissaoProduto.pComissaoAvista;
                                                } break;
                                            case 1:
                                                {
                                                    this.pComissao = objFuncionarioComissaoProduto.pComissaoAprazo;
                                                } break;
                                        }
                                    } break;
                                case 4:
                                    {
                                        decimal pLucro = decimal.Zero;

                                        if (currentItem.vVenda > 0)
                                            pLucro = (1 - (currentItem.objProduto.vCompra / currentItem.vVenda)) * 100;

                                        Funcionario_Margem_Lucro_ComissaoModel objFuncionarioMargemLucroComissao = objOrcamento_ide.objFuncionarioRepresentante.
                                            lFuncionario_Margem_Lucro_Comissao.FirstOrDefault(i => i.pDeMargemVenda >= pLucro ||
                                            i.pAteMargemVenda <= pLucro);

                                        switch (stVistaPrazo)
                                        {
                                            case 0:
                                                {
                                                    this.pComissao = objFuncionarioMargemLucroComissao.pComissaoAvista;
                                                } break;
                                            case 1:
                                                {
                                                    this.pComissao = objFuncionarioMargemLucroComissao.pComissaoAprazo;
                                                } break;
                                        }
                                    } break;
                            }
                        }
                    }
                    #endregion
                }

                base.NotifyPropertyChanged(propertyName: "idRepresentante");
            }
        }
        private decimal? _pComissao;
        [ParameterOrder(Order = 3)]
        public decimal? pComissao
        {
            get { return _pComissao; }
            set
            {
                _pComissao = value;
                base.NotifyPropertyChanged(propertyName: "pComissao");
            }
        }
        private int? _idOrcamentoItem;
        [ParameterOrder(Order = 4)]
        public int? idOrcamentoItem
        {
            get { return _idOrcamentoItem; }
            set
            {
                _idOrcamentoItem = value;
                base.NotifyPropertyChanged(propertyName: "idOrcamentoItem");
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    public partial class Orcamento_Total_ImpostosModel : modelBase
    {
        private object _objDataContext;

        private object GetDataContextWindow()
        {
            //Window w = Sistema.GetOpenWindow(xName: "WinOrcamento");

            //if (_objDataContext == null)
            //    await Application.Current.Dispatcher.BeginInvoke((Action)(() =>
            //    {
            //        _objDataContext = w.DataContext;
            //    }));

            return Orcamento_ideModel.GetDataContextWindow().Result;
        }

        private object GetMethodDataContextWindowValue(string xname, object[] _parameters)
        {
            return Orcamento_ideModel.GetMethodDataContextWindowValue(xname: xname,
                _parameters: _parameters);
        }

        private Orcamento_ideModel GetOrcamentoIde()
        {
            Orcamento_ideModel objOrcamento_ide = Orcamento_ideModel.currentModel;
            return objOrcamento_ide ?? new Orcamento_ideModel();
        }

        public Orcamento_Total_ImpostosModel()
            : base(xTabela: "Orcamento_Total_Impostos")
        {
        }

        #region propriedades não mapeadas


        private string _xIM;

        public string xIM
        {
            get { return _xIM; }
            set
            {
                _xIM = value;
                base.NotifyPropertyChanged(propertyName: "xIM");
            }
        }


        #endregion

        #region métodos públicos

        public void CalcularTotais()
        {
            Orcamento_ideModel objOrcamento_ide = this.GetOrcamentoIde();

            if (objOrcamento_ide != null)
            {
                #region Cálculo de totais produtos

                decimal dTotalProdutos = decimal.Zero;

                if (objOrcamento_ide.bCriado || objOrcamento_ide.bTodos)
                {
                    dTotalProdutos += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => !i.stServico && i.stOrcamentoItem == 0)
                        .Sum(i => (i.vVenda * i.qProduto));
                }

                if (objOrcamento_ide.bEnviado || objOrcamento_ide.bTodos)
                {
                    dTotalProdutos += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => !i.stServico && i.stOrcamentoItem == 1)
                        .Sum(i => (i.vVenda * i.qProduto));
                }

                if (objOrcamento_ide.bConfirmado || objOrcamento_ide.bTodos)
                {
                    dTotalProdutos += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => !i.stServico && i.stOrcamentoItem == 2)
                        .Sum(i => (i.vVenda * i.qProduto));
                }

                if (objOrcamento_ide.bPerdido || objOrcamento_ide.bTodos)
                {
                    dTotalProdutos += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => !i.stServico && i.stOrcamentoItem == 3)
                        .Sum(i => (i.vVenda * i.qProduto));
                }

                if (objOrcamento_ide.bCancelado || objOrcamento_ide.bTodos)
                {
                    dTotalProdutos += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => !i.stServico && i.stOrcamentoItem == 4)
                        .Sum(i => (i.vVenda * i.qProduto));
                }

                this._vProdutoTotal = dTotalProdutos;
                base.NotifyPropertyChanged(propertyName: "vProdutoTotal");

                #endregion

                #region Cálculo de totais servicos

                decimal dTotalServicos = decimal.Zero;

                if (objOrcamento_ide.bCriado || objOrcamento_ide.bTodos)
                {
                    dTotalServicos += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stServico && i.stOrcamentoItem == 0)
                        .Sum(i => (i.vVenda * i.qProduto));
                }

                if (objOrcamento_ide.bEnviado || objOrcamento_ide.bTodos)
                {
                    dTotalServicos += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stServico && i.stOrcamentoItem == 1)
                        .Sum(i => (i.vVenda * i.qProduto));
                }

                if (objOrcamento_ide.bConfirmado || objOrcamento_ide.bTodos)
                {
                    dTotalServicos += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stServico && i.stOrcamentoItem == 2)
                        .Sum(i => (i.vVenda * i.qProduto));
                }

                if (objOrcamento_ide.bPerdido || objOrcamento_ide.bTodos)
                {
                    dTotalServicos += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stServico && i.stOrcamentoItem == 3)
                        .Sum(i => (i.vVenda * i.qProduto));
                }

                if (objOrcamento_ide.bCancelado || objOrcamento_ide.bTodos)
                {
                    dTotalServicos += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stServico && i.stOrcamentoItem == 4)
                        .Sum(i => (i.vVenda * i.qProduto));
                }

                if (dTotalServicos > 0)
                {
                    if (objOrcamento_ide.objCliente != null)
                        this.xIM = objOrcamento_ide.objCliente.xIm;
                }
                else
                    this.xIM = string.Empty;


                this._vServicoTotal = dTotalServicos;
                base.NotifyPropertyChanged(propertyName: "vServicoTotal");

                #endregion

                #region Cálculo de totais descontos

                decimal dTotalVlrDescontos = decimal.Zero;

                if (objOrcamento_ide.bCriado || objOrcamento_ide.bTodos)
                {
                    dTotalVlrDescontos += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 0)
                        .Sum(i => i.vDesconto * i.qProduto);
                }

                if (objOrcamento_ide.bEnviado || objOrcamento_ide.bTodos)
                {
                    dTotalVlrDescontos += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 1)
                        .Sum(i => i.vDesconto * i.qProduto);
                }

                if (objOrcamento_ide.bConfirmado || objOrcamento_ide.bTodos)
                {
                    dTotalVlrDescontos += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 2)
                        .Sum(i => i.vDesconto * i.qProduto);
                }

                if (objOrcamento_ide.bPerdido || objOrcamento_ide.bTodos)
                {
                    dTotalVlrDescontos += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 3)
                        .Sum(i => i.vDesconto * i.qProduto);
                }

                if (objOrcamento_ide.bCancelado || objOrcamento_ide.bTodos)
                {
                    dTotalVlrDescontos += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 4)
                        .Sum(i => i.vDesconto * i.qProduto);
                }

                this._vDescontoTotal = dTotalVlrDescontos;
                decimal valorTotal = (this._vProdutoTotal + (this._vServicoTotal ?? 0));
                if (valorTotal != 0)
                    this._pDescontoTotal = this._vDescontoTotal / valorTotal;
                else
                    this._pDescontoTotal = decimal.Zero;
                base.NotifyPropertyChanged(propertyName: "vDescontoTotal");
                base.NotifyPropertyChanged(propertyName: "pDescontoTotal");

                #endregion

                //#region Cálculo de totais porc. Desconto

                //decimal dTotalPorcDescontos = decimal.Zero;

                //if (objOrcamento_ide.bCriado || objOrcamento_ide.bTodos)
                //{
                //    dTotalPorcDescontos += objOrcamento_ide.lOrcamento_Itens
                //        .Where(i => i.stOrcamentoItem == 0)
                //        .Sum(i => i.pDesconto);
                //}

                //if (objOrcamento_ide.bEnviado || objOrcamento_ide.bTodos)
                //{
                //    dTotalPorcDescontos += objOrcamento_ide.lOrcamento_Itens
                //        .Where(i => i.stOrcamentoItem == 1)
                //        .Sum(i => i.pDesconto);
                //}

                //if (objOrcamento_ide.bConfirmado || objOrcamento_ide.bTodos)
                //{
                //    dTotalPorcDescontos += objOrcamento_ide.lOrcamento_Itens
                //        .Where(i => i.stOrcamentoItem == 2)
                //        .Sum(i => i.pDesconto);
                //}

                //if (objOrcamento_ide.bPerdido || objOrcamento_ide.bTodos)
                //{
                //    dTotalPorcDescontos += objOrcamento_ide.lOrcamento_Itens
                //        .Where(i => i.stOrcamentoItem == 3)
                //        .Sum(i => i.pDesconto);
                //}

                //if (objOrcamento_ide.bCancelado || objOrcamento_ide.bTodos)
                //{
                //    dTotalPorcDescontos += objOrcamento_ide.lOrcamento_Itens
                //        .Where(i => i.stOrcamentoItem == 4)
                //        .Sum(i => i.pDesconto);
                //}

                //this._pDescontoTotal = dTotalPorcDescontos;
                //base.NotifyPropertyChanged(propertyName: "pDescontoTotal");

                //#endregion

                #region Cálculo de Vlr Suframa

                decimal dTotalDescSuframa = decimal.Zero;

                if (objOrcamento_ide.bCriado || objOrcamento_ide.bTodos)
                {
                    dTotalDescSuframa += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 0)
                        .Sum(i => i.vDescontoSuframa ?? 0);
                }

                if (objOrcamento_ide.bEnviado || objOrcamento_ide.bTodos)
                {
                    dTotalDescSuframa += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 1)
                        .Sum(i => i.vDescontoSuframa ?? 0);
                }

                if (objOrcamento_ide.bConfirmado || objOrcamento_ide.bTodos)
                {
                    dTotalDescSuframa += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 2)
                        .Sum(i => i.vDescontoSuframa ?? 0);
                }

                if (objOrcamento_ide.bPerdido || objOrcamento_ide.bTodos)
                {
                    dTotalDescSuframa += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 3)
                        .Sum(i => i.vDescontoSuframa ?? 0);
                }

                if (objOrcamento_ide.bCancelado || objOrcamento_ide.bTodos)
                {
                    dTotalDescSuframa += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 4)
                        .Sum(i => i.vDescontoSuframa ?? 0);
                }

                this._vDescontoSuframaTotal = dTotalDescSuframa;
                base.NotifyPropertyChanged(propertyName: "vDescontoSuframaTotal");

                #endregion

                #region Cálculo de totais frete

                decimal dTotalFrete = decimal.Zero;

                if (objOrcamento_ide.bCriado || objOrcamento_ide.bTodos)
                {
                    dTotalFrete += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 0)
                        .Sum(i => i.vFreteItem);
                }

                if (objOrcamento_ide.bEnviado || objOrcamento_ide.bTodos)
                {
                    dTotalFrete += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 1)
                        .Sum(i => i.vFreteItem);
                }

                if (objOrcamento_ide.bConfirmado || objOrcamento_ide.bTodos)
                {
                    dTotalFrete += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 2)
                        .Sum(i => i.vFreteItem);
                }

                if (objOrcamento_ide.bPerdido || objOrcamento_ide.bTodos)
                {
                    dTotalFrete += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 3)
                        .Sum(i => i.vFreteItem);
                }

                if (objOrcamento_ide.bCancelado || objOrcamento_ide.bTodos)
                {
                    dTotalFrete += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 4)
                        .Sum(i => i.vFreteItem);
                }

                this._vFreteTotal = dTotalFrete;
                base.NotifyPropertyChanged(propertyName: "vFreteTotal");

                #endregion

                #region Cálculo de totais seguro

                decimal dTotalSeguro = decimal.Zero;

                if (objOrcamento_ide.bCriado || objOrcamento_ide.bTodos)
                {
                    dTotalSeguro += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 0)
                        .Sum(i => i.vSegurosItem);
                }

                if (objOrcamento_ide.bEnviado || objOrcamento_ide.bTodos)
                {
                    dTotalSeguro += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 1)
                        .Sum(i => i.vSegurosItem);
                }

                if (objOrcamento_ide.bConfirmado || objOrcamento_ide.bTodos)
                {
                    dTotalSeguro += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 2)
                        .Sum(i => i.vSegurosItem);
                }

                if (objOrcamento_ide.bPerdido || objOrcamento_ide.bTodos)
                {
                    dTotalSeguro += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 3)
                        .Sum(i => i.vSegurosItem);
                }

                if (objOrcamento_ide.bCancelado || objOrcamento_ide.bTodos)
                {
                    dTotalSeguro += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 4)
                        .Sum(i => i.vSegurosItem);
                }

                this._vSeguroTotal = dTotalSeguro;
                base.NotifyPropertyChanged(propertyName: "vSeguroTotal");

                #endregion

                #region Cálculo de totais outras despesas

                decimal dOutrasDespesas = decimal.Zero;

                if (objOrcamento_ide.bCriado || objOrcamento_ide.bTodos)
                {
                    dOutrasDespesas += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 0)
                        .Sum(i => i.vOutrasDespesasItem);
                }

                if (objOrcamento_ide.bEnviado || objOrcamento_ide.bTodos)
                {
                    dOutrasDespesas += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 1)
                        .Sum(i => i.vOutrasDespesasItem);
                }

                if (objOrcamento_ide.bConfirmado || objOrcamento_ide.bTodos)
                {
                    dOutrasDespesas += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 2)
                        .Sum(i => i.vOutrasDespesasItem);
                }

                if (objOrcamento_ide.bPerdido || objOrcamento_ide.bTodos)
                {
                    dOutrasDespesas += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 3)
                        .Sum(i => i.vOutrasDespesasItem);
                }

                if (objOrcamento_ide.bCancelado || objOrcamento_ide.bTodos)
                {
                    dOutrasDespesas += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 4)
                        .Sum(i => i.vOutrasDespesasItem);
                }

                this._vOutrasDespesasTotal = dOutrasDespesas;
                base.NotifyPropertyChanged(propertyName: "vOutrasDespesasTotal");

                #endregion

                #region Cálculo de totais Base de Cálculo ICMS

                decimal dBaseCalcIcms = decimal.Zero;

                if (objOrcamento_ide.bCriado || objOrcamento_ide.bTodos)
                {
                    dBaseCalcIcms += objOrcamento_ide.lOrcamento_Itens.Where(i => i.stOrcamentoItem == 0).
                    Sum(i => i.objImposto.ICMS_vBaseCalculo ?? 0);
                }

                if (objOrcamento_ide.bEnviado || objOrcamento_ide.bTodos)
                {
                    dBaseCalcIcms += objOrcamento_ide.lOrcamento_Itens.Where(i => i.stOrcamentoItem == 1).
                    Sum(i => i.objImposto.ICMS_vBaseCalculo ?? 0);
                }

                if (objOrcamento_ide.bConfirmado || objOrcamento_ide.bTodos)
                {
                    dBaseCalcIcms += objOrcamento_ide.lOrcamento_Itens.Where(i => i.stOrcamentoItem == 2).
                    Sum(i => i.objImposto.ICMS_vBaseCalculo ?? 0);
                }

                if (objOrcamento_ide.bPerdido || objOrcamento_ide.bTodos)
                {
                    dBaseCalcIcms += objOrcamento_ide.lOrcamento_Itens.Where(i => i.stOrcamentoItem == 3).
                    Sum(i => i.objImposto.ICMS_vBaseCalculo ?? 0);
                }

                if (objOrcamento_ide.bCancelado || objOrcamento_ide.bTodos)
                {
                    dBaseCalcIcms += objOrcamento_ide.lOrcamento_Itens.Where(i => i.stOrcamentoItem == 4).
                    Sum(i => i.objImposto.ICMS_vBaseCalculo ?? 0);
                }

                this._vBaseCalculoIcmsTotal = dBaseCalcIcms;
                base.NotifyPropertyChanged(propertyName: "vBaseCalculoIcmsTotal");

                #endregion

                #region Cálculo de totais Valor ICMS

                decimal dVlrIcms = decimal.Zero;

                if (objOrcamento_ide.bCriado || objOrcamento_ide.bTodos)
                {
                    dVlrIcms += objOrcamento_ide.lOrcamento_Itens.Where(i => i.stOrcamentoItem == 0)
                        .Sum(i => i.objImposto.ICMS_vICMS ?? 0);
                }

                if (objOrcamento_ide.bEnviado || objOrcamento_ide.bTodos)
                {
                    dVlrIcms += objOrcamento_ide.lOrcamento_Itens.Where(i => i.stOrcamentoItem == 1)
                        .Sum(i => i.objImposto.ICMS_vICMS ?? 0);
                }

                if (objOrcamento_ide.bConfirmado || objOrcamento_ide.bTodos)
                {
                    dVlrIcms += objOrcamento_ide.lOrcamento_Itens.Where(i => i.stOrcamentoItem == 2)
                        .Sum(i => i.objImposto.ICMS_vICMS ?? 0);
                }

                if (objOrcamento_ide.bPerdido || objOrcamento_ide.bTodos)
                {
                    dVlrIcms += objOrcamento_ide.lOrcamento_Itens.Where(i => i.stOrcamentoItem == 3)
                        .Sum(i => i.objImposto.ICMS_vICMS ?? 0);
                }

                if (objOrcamento_ide.bCancelado || objOrcamento_ide.bTodos)
                {
                    dVlrIcms += objOrcamento_ide.lOrcamento_Itens.Where(i => i.stOrcamentoItem == 4)
                        .Sum(i => i.objImposto.ICMS_vICMS ?? 0);
                }

                this._vICMSTotal = dVlrIcms;
                base.NotifyPropertyChanged(propertyName: "vICMSTotal");

                #endregion

                #region Cálculo de totais Base de Cálculo Icms Próprio

                decimal dVlrBaseIcmsProprio = decimal.Zero;

                if (objOrcamento_ide.bCriado || objOrcamento_ide.bTodos)
                {
                    dVlrBaseIcmsProprio += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 0).Sum(i => i.objImposto.ICMS_vBaseCalculoIcmsProprio ?? 0);
                }

                if (objOrcamento_ide.bEnviado || objOrcamento_ide.bTodos)
                {
                    dVlrBaseIcmsProprio += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 1).Sum(i => i.objImposto.ICMS_vBaseCalculoIcmsProprio ?? 0);
                }

                if (objOrcamento_ide.bConfirmado || objOrcamento_ide.bTodos)
                {
                    dVlrBaseIcmsProprio += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 2).Sum(i => i.objImposto.ICMS_vBaseCalculoIcmsProprio ?? 0);
                }

                if (objOrcamento_ide.bPerdido || objOrcamento_ide.bTodos)
                {
                    dVlrBaseIcmsProprio += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 3).Sum(i => i.objImposto.ICMS_vBaseCalculoIcmsProprio ?? 0);
                }

                if (objOrcamento_ide.bCancelado || objOrcamento_ide.bTodos)
                {
                    dVlrBaseIcmsProprio += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 4).Sum(i => i.objImposto.ICMS_vBaseCalculoIcmsProprio ?? 0);
                }

                this._vBaseCalculoIcmsProprioTotal = dVlrBaseIcmsProprio;
                base.NotifyPropertyChanged(propertyName: "vBaseCalculoIcmsProprioTotal");

                #endregion

                #region Cálculo de totais Valor Icms Próprio

                decimal dVlrIcmsPróprio = decimal.Zero;

                if (objOrcamento_ide.bCriado || objOrcamento_ide.bTodos)
                {
                    dVlrIcmsPróprio += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 0).Sum(i => i.objImposto.ICMS_vIcmsProprio ?? 0);
                }

                if (objOrcamento_ide.bEnviado || objOrcamento_ide.bTodos)
                {
                    dVlrIcmsPróprio += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 1).Sum(i => i.objImposto.ICMS_vIcmsProprio ?? 0);
                }

                if (objOrcamento_ide.bConfirmado || objOrcamento_ide.bTodos)
                {
                    dVlrIcmsPróprio += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 2).Sum(i => i.objImposto.ICMS_vIcmsProprio ?? 0);
                }

                if (objOrcamento_ide.bPerdido || objOrcamento_ide.bTodos)
                {
                    dVlrIcmsPróprio += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 3).Sum(i => i.objImposto.ICMS_vIcmsProprio ?? 0);
                }

                if (objOrcamento_ide.bCancelado || objOrcamento_ide.bTodos)
                {
                    dVlrIcmsPróprio += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 4).Sum(i => i.objImposto.ICMS_vIcmsProprio ?? 0);
                }

                this._vIcmsProprioTotal = dVlrBaseIcmsProprio;
                base.NotifyPropertyChanged(propertyName: "vIcmsProprioTotal");

                #endregion

                #region Cálculo de totais Valor Base de Cálculo Ipi

                decimal dVlrBaseCalculoIpi = decimal.Zero;

                if (objOrcamento_ide.bCriado || objOrcamento_ide.bTodos)
                {
                    dVlrBaseCalculoIpi += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 0).Sum(i => i.objImposto.IPI_vBaseCalculo ?? 0);
                }

                if (objOrcamento_ide.bEnviado || objOrcamento_ide.bTodos)
                {
                    dVlrBaseCalculoIpi += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 1).Sum(i => i.objImposto.IPI_vBaseCalculo ?? 0);
                }

                if (objOrcamento_ide.bConfirmado || objOrcamento_ide.bTodos)
                {
                    dVlrBaseCalculoIpi += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 2).Sum(i => i.objImposto.IPI_vBaseCalculo ?? 0);
                }

                if (objOrcamento_ide.bPerdido || objOrcamento_ide.bTodos)
                {
                    dVlrBaseCalculoIpi += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 3).Sum(i => i.objImposto.IPI_vBaseCalculo ?? 0);
                }

                if (objOrcamento_ide.bCancelado || objOrcamento_ide.bTodos)
                {
                    dVlrBaseCalculoIpi += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 4).Sum(i => i.objImposto.IPI_vBaseCalculo ?? 0);
                }

                this._vBaseCalculoIpiTotal = dVlrBaseCalculoIpi;
                base.NotifyPropertyChanged(propertyName: "vBaseCalculoIpiTotal");

                #endregion

                #region Cálculo de totais Valor Ipi

                decimal dVlrIpi = decimal.Zero;

                if (objOrcamento_ide.bCriado || objOrcamento_ide.bTodos)
                {
                    dVlrIpi += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 0).Sum(i => i.objImposto.IPI_vIPI ?? 0);
                }

                if (objOrcamento_ide.bEnviado || objOrcamento_ide.bTodos)
                {
                    dVlrIpi += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 1).Sum(i => i.objImposto.IPI_vIPI ?? 0);
                }

                if (objOrcamento_ide.bConfirmado || objOrcamento_ide.bTodos)
                {
                    dVlrIpi += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 2).Sum(i => i.objImposto.IPI_vIPI ?? 0);
                }

                if (objOrcamento_ide.bPerdido || objOrcamento_ide.bTodos)
                {
                    dVlrIpi += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 3).Sum(i => i.objImposto.IPI_vIPI ?? 0);
                }

                if (objOrcamento_ide.bCancelado || objOrcamento_ide.bTodos)
                {
                    dVlrIpi += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 4).Sum(i => i.objImposto.IPI_vIPI ?? 0);
                }

                this._vIPITotal = dVlrIpi;
                base.NotifyPropertyChanged(propertyName: "vIPITotal");

                #endregion

                #region Cálculo de totais Valor de Base Substituição Tributária

                decimal dVlrBaseSubstTribut = decimal.Zero;

                if (objOrcamento_ide.bCriado || objOrcamento_ide.bTodos)
                {
                    dVlrBaseSubstTribut += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 0).Sum(i => i.objImposto.ICMS_vBaseCalculoSubstituicaoTributaria ?? 0);
                }

                if (objOrcamento_ide.bEnviado || objOrcamento_ide.bTodos)
                {
                    dVlrBaseSubstTribut += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 1).Sum(i => i.objImposto.ICMS_vBaseCalculoSubstituicaoTributaria ?? 0);
                }

                if (objOrcamento_ide.bConfirmado || objOrcamento_ide.bTodos)
                {
                    dVlrBaseSubstTribut += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 2).Sum(i => i.objImposto.ICMS_vBaseCalculoSubstituicaoTributaria ?? 0);
                }

                if (objOrcamento_ide.bPerdido || objOrcamento_ide.bTodos)
                {
                    dVlrBaseSubstTribut += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 3).Sum(i => i.objImposto.ICMS_vBaseCalculoSubstituicaoTributaria ?? 0);
                }

                if (objOrcamento_ide.bCancelado || objOrcamento_ide.bTodos)
                {
                    dVlrBaseSubstTribut += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 4).Sum(i => i.objImposto.ICMS_vBaseCalculoSubstituicaoTributaria ?? 0);
                }

                this._vBaseCalculoICmsSubstituicaoTributariaTotal = dVlrBaseSubstTribut;
                base.NotifyPropertyChanged(propertyName: "vBaseCalculoICmsSubstituicaoTributariaTotal");

                #endregion

                #region Cálculo de totais Valor Substituição Tributária

                decimal dVlrSubsTrib = decimal.Zero;

                if (objOrcamento_ide.bCriado || objOrcamento_ide.bTodos)
                {
                    dVlrSubsTrib += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 0).Sum(i => i.objImposto.ICMS_vSubstituicaoTributaria ?? 0);
                }

                if (objOrcamento_ide.bEnviado || objOrcamento_ide.bTodos)
                {
                    dVlrSubsTrib += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 1).Sum(i => i.objImposto.ICMS_vSubstituicaoTributaria ?? 0);
                }

                if (objOrcamento_ide.bConfirmado || objOrcamento_ide.bTodos)
                {
                    dVlrSubsTrib += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 2).Sum(i => i.objImposto.ICMS_vSubstituicaoTributaria ?? 0);
                }

                if (objOrcamento_ide.bPerdido || objOrcamento_ide.bTodos)
                {
                    dVlrSubsTrib += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 3).Sum(i => i.objImposto.ICMS_vSubstituicaoTributaria ?? 0);
                }

                if (objOrcamento_ide.bCancelado || objOrcamento_ide.bTodos)
                {
                    dVlrSubsTrib += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 4).Sum(i => i.objImposto.ICMS_vSubstituicaoTributaria ?? 0);
                }

                this._vIcmsSubstituicaoTributariaTotal = dVlrSubsTrib;
                base.NotifyPropertyChanged(propertyName: "vIcmsSubstituicaoTributariaTotal");

                #endregion

                #region Cálculo de totais base de cálculo Pis

                decimal dVlrBaseCalcPis = decimal.Zero;

                if (objOrcamento_ide.bCriado || objOrcamento_ide.bTodos)
                {
                    dVlrBaseCalcPis += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 0).Sum(i => i.objImposto.PIS_vBaseCalculo ?? 0);
                }

                if (objOrcamento_ide.bEnviado || objOrcamento_ide.bTodos)
                {
                    dVlrBaseCalcPis += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 1).Sum(i => i.objImposto.PIS_vBaseCalculo ?? 0);
                }

                if (objOrcamento_ide.bConfirmado || objOrcamento_ide.bTodos)
                {
                    dVlrBaseCalcPis += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 2).Sum(i => i.objImposto.PIS_vBaseCalculo ?? 0);
                }

                if (objOrcamento_ide.bPerdido || objOrcamento_ide.bTodos)
                {
                    dVlrBaseCalcPis += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 3).Sum(i => i.objImposto.PIS_vBaseCalculo ?? 0);
                }

                if (objOrcamento_ide.bCancelado || objOrcamento_ide.bTodos)
                {
                    dVlrBaseCalcPis += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 4).Sum(i => i.objImposto.PIS_vBaseCalculo ?? 0);
                }

                this._vBaseCalculoPisTotal = dVlrBaseCalcPis;
                base.NotifyPropertyChanged(propertyName: "vBaseCalculoPisTotal");

                #endregion

                #region Cálculo de totais valor Pis

                decimal dVlrPis = decimal.Zero;

                if (objOrcamento_ide.bCriado || objOrcamento_ide.bTodos)
                {
                    dVlrPis += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 0).Sum(i => i.objImposto.PIS_vPIS ?? 0);
                }

                if (objOrcamento_ide.bEnviado || objOrcamento_ide.bTodos)
                {
                    dVlrPis += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 1).Sum(i => i.objImposto.PIS_vPIS ?? 0);
                }

                if (objOrcamento_ide.bConfirmado || objOrcamento_ide.bTodos)
                {
                    dVlrPis += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 2).Sum(i => i.objImposto.PIS_vPIS ?? 0);
                }

                if (objOrcamento_ide.bPerdido || objOrcamento_ide.bTodos)
                {
                    dVlrPis += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 3).Sum(i => i.objImposto.PIS_vPIS ?? 0);
                }

                if (objOrcamento_ide.bCancelado || objOrcamento_ide.bTodos)
                {
                    dVlrPis += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 4).Sum(i => i.objImposto.PIS_vPIS ?? 0);
                }

                this._vPISTotal = dVlrPis;
                base.NotifyPropertyChanged(propertyName: "vPISTotal");

                #endregion

                #region Cálculo de totais base de cálculo Cofins

                decimal dVlrBaseCalcCofins = decimal.Zero;

                if (objOrcamento_ide.bCriado || objOrcamento_ide.bTodos)
                {
                    dVlrBaseCalcCofins += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 0).Sum(i => i.objImposto.COFINS_vBaseCalculo ?? 0);
                }

                if (objOrcamento_ide.bEnviado || objOrcamento_ide.bTodos)
                {
                    dVlrBaseCalcCofins += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 1).Sum(i => i.objImposto.COFINS_vBaseCalculo ?? 0);
                }

                if (objOrcamento_ide.bConfirmado || objOrcamento_ide.bTodos)
                {
                    dVlrBaseCalcCofins += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 2).Sum(i => i.objImposto.COFINS_vBaseCalculo ?? 0);
                }

                if (objOrcamento_ide.bPerdido || objOrcamento_ide.bTodos)
                {
                    dVlrBaseCalcCofins += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 3).Sum(i => i.objImposto.COFINS_vBaseCalculo ?? 0);
                }

                if (objOrcamento_ide.bCancelado || objOrcamento_ide.bTodos)
                {
                    dVlrBaseCalcCofins += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 4).Sum(i => i.objImposto.COFINS_vBaseCalculo ?? 0);
                }

                this._vBaseCalculoCofinsTotal = dVlrBaseCalcCofins;
                base.NotifyPropertyChanged(propertyName: "vBaseCalculoCofinsTotal");

                #endregion

                #region Cálculo de totais Valor Cofins

                decimal dVlrCofins = decimal.Zero;

                if (objOrcamento_ide.bCriado || objOrcamento_ide.bTodos)
                {
                    dVlrCofins += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 0).Sum(i => i.objImposto.COFINS_vCOFINS ?? 0);
                }

                if (objOrcamento_ide.bEnviado || objOrcamento_ide.bTodos)
                {
                    dVlrCofins += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 1).Sum(i => i.objImposto.COFINS_vCOFINS ?? 0);
                }

                if (objOrcamento_ide.bConfirmado || objOrcamento_ide.bTodos)
                {
                    dVlrCofins += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 2).Sum(i => i.objImposto.COFINS_vCOFINS ?? 0);
                }

                if (objOrcamento_ide.bPerdido || objOrcamento_ide.bTodos)
                {
                    dVlrCofins += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 3).Sum(i => i.objImposto.COFINS_vCOFINS ?? 0);
                }

                if (objOrcamento_ide.bCancelado || objOrcamento_ide.bTodos)
                {
                    dVlrCofins += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 4).Sum(i => i.objImposto.COFINS_vCOFINS ?? 0);
                }

                this._vCOFINSTotal = dVlrCofins;
                base.NotifyPropertyChanged(propertyName: "vCOFINSTotal");

                #endregion

                #region Cálculo de Valor Base de Cálculo Iss

                decimal dVlrBaseCalcIss = decimal.Zero;

                if (objOrcamento_ide.bCriado || objOrcamento_ide.bTodos)
                {
                    dVlrBaseCalcIss += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 0).Sum(i => i.objImposto.ISS_vBaseCalculo ?? 0);
                }

                if (objOrcamento_ide.bEnviado || objOrcamento_ide.bTodos)
                {
                    dVlrBaseCalcIss += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 1).Sum(i => i.objImposto.ISS_vBaseCalculo ?? 0);
                }

                if (objOrcamento_ide.bConfirmado || objOrcamento_ide.bTodos)
                {
                    dVlrBaseCalcIss += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 2).Sum(i => i.objImposto.ISS_vBaseCalculo ?? 0);
                }

                if (objOrcamento_ide.bPerdido || objOrcamento_ide.bTodos)
                {
                    dVlrBaseCalcIss += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 3).Sum(i => i.objImposto.ISS_vBaseCalculo ?? 0);
                }

                if (objOrcamento_ide.bCancelado || objOrcamento_ide.bTodos)
                {
                    dVlrBaseCalcIss += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 4).Sum(i => i.objImposto.ISS_vBaseCalculo ?? 0);
                }

                this._vBaseCalculoIssTotal = dVlrBaseCalcIss;
                base.NotifyPropertyChanged(propertyName: "vBaseCalculoIssTotal");

                #endregion

                #region Cálculo de Valor Iss

                decimal dVlrIss = decimal.Zero;

                if (objOrcamento_ide.bCriado || objOrcamento_ide.bTodos)
                {
                    dVlrIss += objOrcamento_ide.lOrcamento_Itens.Where(i => i.stOrcamentoItem == 0).Sum(i => i.objImposto.ISS_vIss ?? 0);
                }

                if (objOrcamento_ide.bEnviado || objOrcamento_ide.bTodos)
                {
                    dVlrIss += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 1).Sum(i => i.objImposto.ISS_vIss ?? 0);
                }

                if (objOrcamento_ide.bConfirmado || objOrcamento_ide.bTodos)
                {
                    dVlrIss += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 2).Sum(i => i.objImposto.ISS_vIss ?? 0);
                }

                if (objOrcamento_ide.bPerdido || objOrcamento_ide.bTodos)
                {
                    dVlrIss += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 3).Sum(i => i.objImposto.ISS_vIss ?? 0);
                }

                if (objOrcamento_ide.bCancelado || objOrcamento_ide.bTodos)
                {
                    dVlrIss += objOrcamento_ide.lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 4).Sum(i => i.objImposto.ISS_vIss ?? 0);
                }

                this._vIssTotal = dVlrIss;
                base.NotifyPropertyChanged(propertyName: "vIssTotal");

                #endregion

                #region Valor Total

                this._vTotal = this._vProdutoTotal + (this._vServicoTotal ?? 0) + this._vDescontoTotal - (this._vDescontoSuframaTotal ?? 0)
                    + this._vIPITotal + this._vIcmsSubstituicaoTributariaTotal + this._vSeguroTotal + this._vOutrasDespesasTotal;
                base.NotifyPropertyChanged(propertyName: "vTotal");

                #endregion
            }
        }

        #endregion

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


                if (this.GetOperationModel() == OperationModel.updating)
                {
                    decimal vTotal = (this._vProdutoTotal + (this._vServicoTotal ?? 0));

                    if (vTotal != 0)
                    {
                        Orcamento_ideModel objOrcamento_ide = this.GetOrcamentoIde();

                        if (objOrcamento_ide != null)
                        {
                            foreach (Orcamento_ItemModel item in objOrcamento_ide.lOrcamento_Itens)
                            {
                                item.vFreteItem = (((item.vVenda * item.qProduto) / vTotal) * value);
                            }
                        }
                    }
                }
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
                if (this.GetOperationModel() == OperationModel.updating)
                {
                    decimal vTotal = (this._vProdutoTotal + (this._vServicoTotal ?? 0));

                    if (vTotal != 0)
                    {
                        Orcamento_ideModel objOrcamento_ide = this.GetOrcamentoIde();

                        if (objOrcamento_ide != null)
                        {
                            foreach (Orcamento_ItemModel item in objOrcamento_ide.lOrcamento_Itens)
                            {
                                item.vSegurosItem = (((item.vVenda * item.qProduto) / vTotal) * value);
                            }
                        }
                    }
                }
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
                Window wd = Sistema.GetOpenWindow(xName: "WinOrcamento");

                if (wd != null)
                {
                    Orcamento_ideModel objOrcamento_ide = this.GetOrcamentoIde();

                    if (objOrcamento_ide != null)
                    {
                        if (objOrcamento_ide.GetOperationModel() == OperationModel.updating)
                        {
                            decimal vBruto = objOrcamento_ide.lOrcamento_Itens.Select(i => (i.qProduto * i.vVenda)).Sum();
                            this._pDescontoTotal = value / vBruto;
                            FieldInfo fivDesconto;
                            decimal _vDescontoItem = decimal.Zero;
                            FieldInfo fipDesconto;
                            decimal _pDescontoItem = decimal.Zero;

                            foreach (Orcamento_ItemModel item in objOrcamento_ide.lOrcamento_Itens)
                            {
                                fivDesconto = item.GetType().GetField(name: "_vDesconto", bindingAttr: BindingFlags.NonPublic | BindingFlags.Instance);

                                if (item.qProduto > 0 && vBruto > 0)
                                    _vDescontoItem = (((item.vVenda * item.qProduto) / vBruto) * value) / item.qProduto;

                                fipDesconto = item.GetType().GetField(name: "_pDesconto", bindingAttr: BindingFlags.NonPublic | BindingFlags.Instance);

                                if (vBruto > 0)
                                    _pDescontoItem = (_vDescontoItem / item.vVenda) * 100;

                                if (fivDesconto != null)
                                {
                                    fivDesconto.SetValue(obj: item, value: _vDescontoItem);
                                    base.NotifyPropertyChanged(propertyName: "vDesconto");
                                }

                                if (fipDesconto != null)
                                {
                                    fipDesconto.SetValue(obj: item, value: _pDescontoItem);
                                    base.NotifyPropertyChanged(propertyName: "pDesconto");
                                }

                                item.DescValidated(p: _pDescontoItem, bShowWdSupervisor: false);
                                item.ValidateProperty(columnName: "pDesconto");
                                item.SetTotalItem();
                            }

                            CollectionViewSource lItens = wd.FindResource("cvsItens") as CollectionViewSource;

                            lItens.View.Refresh();

                            if (objOrcamento_ide.lOrcamento_Itens.Count(i => !i.bPermitePorcentagem) > 0)
                            {
                                MessageBox.Show(messageBoxText: "Alguns itens ultrapassaram o limite de porcentagem. Verifique!",
                                    caption: "Verifique!", button: MessageBoxButton.OK, icon: MessageBoxImage.Exclamation);
                                TabControl t = wd.FindName(name: "tcPrincipal") as TabControl;
                                if (t != null)
                                    t.SelectedIndex = 1;
                            }
                        }
                    }
                }
                _vDescontoTotal = value;
                base.NotifyPropertyChanged(propertyName: "vDescontoTotal");
                base.NotifyPropertyChanged(propertyName: "pDescontoTotal");
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
                if (this.GetOperationModel() == OperationModel.updating)
                {
                    decimal vTotal = (this._vProdutoTotal + (this._vServicoTotal ?? 0));

                    if (vTotal != 0)
                    {
                        Orcamento_ideModel objOrcamento_ide = this.GetOrcamentoIde();

                        if (objOrcamento_ide != null)
                        {
                            foreach (Orcamento_ItemModel item in objOrcamento_ide.lOrcamento_Itens)
                            {
                                item.vOutrasDespesasItem = (((item.vVenda * item.qProduto) / vTotal) * value);
                            }
                        }
                    }
                }
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
                this.vDescontoTotal = (value / 100) * (this._vProdutoTotal + (this._vServicoTotal ?? 0));
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
        private object _objDataContext;

        private object GetDataContextWindow()
        {
            //Window w = Sistema.GetOpenWindow(xName: "WinOrcamento");

            //if (_objDataContext == null)
            //    await Application.Current.Dispatcher.BeginInvoke((Action)(() =>
            //    {
            //        _objDataContext = w.DataContext;
            //    }));

            return Orcamento_ideModel.GetDataContextWindow().Result;
        }

        private object GetMethodDataContextWindowValue(string xname, object[] _parameters)
        {
            return Orcamento_ideModel.GetMethodDataContextWindowValue(xname: xname,
                _parameters: _parameters);
        }

        private Orcamento_ideModel GetOrcamentoIde()
        {
            Orcamento_ideModel objOrcamento_ide = Orcamento_ideModel.currentModel;
            return objOrcamento_ide ?? new Orcamento_ideModel();
        }

        public Orcamento_retTranspModel()
            : base("Orcamento_retTransp")
        {
        }

        #region Propriedades relacionadas

        private TransportadorModel _objTransportador;

        public TransportadorModel objTransportador
        {
            get { return _objTransportador; }
            set { _objTransportador = value; }
        }

        #endregion

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
        private decimal _vServ; //Os campos em seguida, estão na model, na base, porém não estão na tela, e nem na documentação
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
                this.objTransportador = this.GetMethodDataContextWindowValue(xname: "GetTransportador",
                        _parameters: new object[] { value })
                    as TransportadorModel;
                if (objTransportador != null)
                {
                    this.xRntrc = this.objTransportador.xRntrc;
                    this.xCpfCnpj = this.objTransportador.stPessoa == (byte)1 ? this.objTransportador.xCnpj : this.objTransportador.xCpf;
                }

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
        private string _xRntrc;
        [ParameterOrder(Order = 18)]
        public string xRntrc
        {
            get { return _xRntrc; }
            set
            {
                _xRntrc = value;
                base.NotifyPropertyChanged(propertyName: "xRntrc");
            }
        }
        private string _xCpfCnpj;
        [ParameterOrder(Order = 19)]
        public string xCpfCnpj
        {
            get { return _xCpfCnpj; }
            set
            {
                _xCpfCnpj = value;
                base.NotifyPropertyChanged(propertyName: "xCpfCnpj");
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
        public string ValidateProperty(string columnName)
        {
            return this[columnName: columnName];
        }

        public override string this[string columnName]
        {
            get
            {
                string valid = base[columnName];

                if (string.IsNullOrEmpty(value: valid))
                {
                    if (columnName == "pDesconto")
                    {
                        if (!bPermitePorcentagem)
                            return "% de desconto ultrapassa o permitido na lista de preço selecionada!";
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
                string res = base[columnName];

                if (res == null)
                {
                    if (columnName == "PIS_pPIS")
                    {
                        if ((this.stCalculaPisCofins == 1 || this.stCalculaPisCofins == 2) && this.PIS_pPIS <= 0)
                        {
                            return "% PIS deve ser maior que zero quando opção Calcula COFINS for igual a '2 - NORMAL' ou '3 - SUBSTITUIÇÃO TRIBUTÁRIA'";
                        }
                    }
                    else if (columnName == "stCompoeBaseCalculoPisCofins")
                    {
                        if (this.stCalculaPisCofins == 1 && this.stCompoeBaseCalculoPisCofins == (byte)4)
                        {
                            return "Quando selecionada a opção Calcula PIS/COFINS '2 - NORMAL' Compõe Base Cálculo PIS/COFINS deve ser diferente de '5 - NENHUM'";
                        }
                    }
                    else if (columnName == "PIS_stCompoeBaseCalculoSubstituicaoTributaria")
                    {
                        if (this.stCalculaPisCofins == 2 && this.PIS_stCompoeBaseCalculoSubstituicaoTributaria == (byte)4)
                        {
                            return "Quando selecionada a opção Calcula PIS/COFINS '3 - SUBSTITUIÇÃO TRIBUTÁRIA' Compõe Base Cálculo PIS ST deve ser diferente de '5 - NENHUM'";
                        }
                    }
                    else if (columnName == "stCalculaPisCofins")
                    {
                        res = this[columnName: "stCompoeBaseCalculoPisCofins"];

                        if (string.IsNullOrEmpty(value: res))
                            res = this[columnName: "PIS_stCompoeBaseCalculoSubstituicaoTributaria"];
                    }
                    else if (columnName == "PIS_nCoeficienteSubstituicaoTributaria")
                    {
                        if (this.stCalculaPisCofins == (byte)2 && this.PIS_nCoeficienteSubstituicaoTributaria <= decimal.Zero)
                            return "Coeficiente PIS deve ser maior que 0 caso opção Calcula PIS/COFINS = '3 - SUBSTITUIÇÃO TRIBUTÁRIA'";
                    }
                    else if (columnName == "COFINS_pCOFINS")
                    {
                        if ((this.stCalculaPisCofins == (byte)1 || this.stCalculaPisCofins == (byte)2) && this.COFINS_pCOFINS <= decimal.Zero)
                        {
                            return "% COFINS deve ser maior que zero quando opção Calcula COFINS for igual a '2 - NORMAL' ou '3 - SUBSTITUIÇÃO TRIBUTÁRIA'";
                        }
                    }
                    else if (columnName == "COFINS_stCompoeBaseCalculoSubstituicaoTributaria")
                    {
                        if (this.stCalculaPisCofins == 2 && this.COFINS_stCompoeBaseCalculoSubstituicaoTributaria == (byte)4)
                        {
                            return "Quando selecionada a opção Calcula PIS/COFINS '3 - SUBSTITUIÇÃO TRIBUTÁRIA' Compõe Base Cálculo PIS ST deve ser diferente de '5 - NENHUM'";
                        }
                    }
                }
                return res;
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
