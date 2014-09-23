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
using HLP.Comum.Model.Models;
using System.Runtime.InteropServices;

namespace HLP.Sales.Model.Models.Comercial
{
    public partial class Orcamento_ideModel : modelComum
    {
        protected override List<ErrorsModel> GetErrors()
        {
            List<ErrorsModel> _Erros = new List<ErrorsModel>();

            _Erros.AddRange(collection: this.lErrors != null ? this.lErrors.ToList() : new List<ErrorsModel>());

            _Erros.AddRange(collection: this.orcamento_retTransp.lErrors != null ? this.orcamento_retTransp.lErrors.ToList() : new List<ErrorsModel>());

            _Erros.AddRange(collection: this.orcamento_Total_Impostos.lErrors != null ? this.orcamento_Total_Impostos.lErrors.ToList() : new List<ErrorsModel>());

            int indexItem = 0;
            foreach (Orcamento_ItemModel it in this.lOrcamento_Itens)
            {
                indexItem++;

                if (it.lErrors != null)
                {
                    it.lErrors.ToList().ForEach(i => i.nItem = indexItem.ToString());
                    _Erros.AddRange(collection: it.lErrors.ToList());
                }

                if (it.objImposto != null)
                    if (it.objImposto.lErrors != null)
                    {
                        it.objImposto.lErrors.ToList().ForEach(i => i.nItem = indexItem.ToString());
                        _Erros.AddRange(collection: it.objImposto.lErrors.ToList());
                    }
            }

            return _Erros;
        }

        public Orcamento_ideModel()
            : base("Orcamento_ide")
        {
            try
            {
                this.orcamento_Total_Impostos = new Orcamento_Total_ImpostosModel();

                this.orcamento_retTransp = new Orcamento_retTranspModel();
                this.orcamento_Total_Impostos.refOrcamentoIde = GCHandle.Alloc(value: this);


                //this.bTodos = true;
                this.lOrcamento_Itens = new ObservableCollectionBaseCadastros<Orcamento_ItemModel>();
                this.lOrcamento_Itens.CollectionChanged += lOrcamento_Itens_CollectionChanged;
                this.idFuncionario = UserData.idUser;
                this.dDataHora = DateTime.Now;

                EnderecoModel objEnderecoEmpresa = null;

                if ((CompanyData.objEmpresaModel as EmpresaModel) != null)
                {
                    objEnderecoEmpresa = (CompanyData.objEmpresaModel as EmpresaModel).lEmpresa_endereco.FirstOrDefault(i => i.stPrincipal == ((byte)1));

                    if (objEnderecoEmpresa == null)
                        objEnderecoEmpresa = (CompanyData.objEmpresaModel as EmpresaModel).lEmpresa_endereco.FirstOrDefault();
                }

                if (objEnderecoEmpresa != null)
                {
                    if (objEnderecoEmpresa.objCidade != null)
                        idUfEnderecoEmpresa = (objEnderecoEmpresa.objCidade as CidadeModel).idUF;
                }

                if ((CompanyData.objEmpresaModel as EmpresaModel) != null)
                {
                    this.idTipoDocumento = (HLP.Base.Static.CompanyData.objEmpresaModel as EmpresaModel)
                        .empresaParametros.ObjParametro_ComercialModel.idTipoDocumentoDefaultOrcamento ?? 0;

                    this.idMoeda = (HLP.Base.Static.CompanyData.objEmpresaModel as EmpresaModel)
                            .empresaParametros.ObjParametro_ComercialModel.idMoeda;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void lOrcamento_Itens_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
                foreach (Orcamento_ItemModel item in e.NewItems)
                {
                    item.refOrcamentoIde = GCHandle.Alloc(value: this);
                    item.objImposto.refOrcamentoIde = GCHandle.Alloc(value: this);


                    if ((this.lOrcamento_Itens.Count
                            > 0))
                    {
                        int? cont = null;
                        if (this.lOrcamento_Itens.Count == 1)
                        {
                            Orcamento_ItemModel objItem = this.lOrcamento_Itens.FirstOrDefault();

                            cont = objItem.nItem ?? 1;
                        }
                        else
                        {
                            cont = this.lOrcamento_Itens.Max(i => i.nItem).Value;
                        }

                        item.nItem = cont == null ? 1 : cont + 1;
                    }
                    else
                        item.nItem = 1;

                    item.AfterConstructor();
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

                this.NotifyPropertyChanged(propertyName: "bCriado");
                this.NotifyPropertyChanged(propertyName: "bEnviado");
                this.NotifyPropertyChanged(propertyName: "bConfirmado");
                this.NotifyPropertyChanged(propertyName: "bPerdido");
                this.NotifyPropertyChanged(propertyName: "bCancelado");
                this.NotifyPropertyChanged(propertyName: "bTodos");
            }
        }

        private bool _bCriadoTotais;

        public bool bCriadoTotais
        {
            get { return _bCriadoTotais; }
            set
            {
                _bCriadoTotais = value;
                if (!value)
                {
                    this._bTodosTotais = false;
                    base.NotifyPropertyChanged(propertyName: "bTodosTotais");
                }
                this.orcamento_Total_Impostos.CalcularTotais();
                base.NotifyPropertyChanged(propertyName: "bCriadoTotais");
            }
        }

        private bool _bEnviadoTotais;

        public bool bEnviadoTotais
        {
            get { return _bEnviadoTotais; }
            set
            {
                _bEnviadoTotais = value;
                if (!value)
                {
                    this._bTodosTotais = false;
                    base.NotifyPropertyChanged(propertyName: "bTodosTotais");
                }
                this.orcamento_Total_Impostos.CalcularTotais();
                base.NotifyPropertyChanged(propertyName: "bEnviadoTotais");
            }
        }

        private bool _bConfirmadoTotais;

        public bool bConfirmadoTotais
        {
            get { return _bConfirmadoTotais; }
            set
            {
                _bConfirmadoTotais = value;
                if (!value)
                {
                    this._bTodosTotais = false;
                    base.NotifyPropertyChanged(propertyName: "bTodosTotais");
                }
                this.orcamento_Total_Impostos.CalcularTotais();
                base.NotifyPropertyChanged(propertyName: "bConfirmadoTotais");
            }
        }

        private bool _bPerdidoTotais;

        public bool bPerdidoTotais
        {
            get { return _bPerdidoTotais; }
            set
            {
                _bPerdidoTotais = value;
                if (!value)
                {
                    this._bTodosTotais = false;
                    base.NotifyPropertyChanged(propertyName: "bTodosTotais");
                }
                this.orcamento_Total_Impostos.CalcularTotais();
                base.NotifyPropertyChanged(propertyName: "bPerdidoTotais");
            }
        }

        private bool _bCanceladoTotais;

        public bool bCanceladoTotais
        {
            get { return _bCanceladoTotais; }
            set
            {
                _bCanceladoTotais = value;
                if (!value)
                {
                    this._bTodosTotais = false;
                    base.NotifyPropertyChanged(propertyName: "bTodosTotais");
                }
                this.orcamento_Total_Impostos.CalcularTotais();
                base.NotifyPropertyChanged(propertyName: "bCanceladoTotais");
            }
        }

        private bool _bTodosTotais;

        public bool bTodosTotais
        {
            get { return _bTodosTotais; }
            set
            {
                _bTodosTotais = this._bCriadoTotais = this._bEnviadoTotais = this._bConfirmadoTotais = this._bPerdidoTotais = this._bCanceladoTotais = value;
                if (orcamento_Total_Impostos != null)
                    this.orcamento_Total_Impostos.CalcularTotais();
                this.NotifyPropertyChanged(propertyName: "bCriadoTotais");
                this.NotifyPropertyChanged(propertyName: "bEnviadoTotais");
                this.NotifyPropertyChanged(propertyName: "bConfirmadoTotais");
                this.NotifyPropertyChanged(propertyName: "bPerdidoTotais");
                this.NotifyPropertyChanged(propertyName: "bCanceladoTotais");
                this.NotifyPropertyChanged(propertyName: "bTodosTotais");
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


        private Ramo_atividadeModel _objRamoAtividade;

        public Ramo_atividadeModel objRamoAtividade
        {
            get { return _objRamoAtividade; }
            set
            {
                _objRamoAtividade = value;
                base.NotifyPropertyChanged(propertyName: "objRamoAtividade");
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


        private string _xEmpresa;

        public string xEmpresa
        {
            get { return _xEmpresa; }
            set
            {
                _xEmpresa = value;
                base.NotifyPropertyChanged(propertyName: "xEmpresa");
            }
        }


        #endregion

        #region Models Relacionadas a Orçamento

        private Cliente_fornecedorModel _objCliente;

        public Cliente_fornecedorModel objCliente
        {
            get { return _objCliente; }
            set
            {
                _objCliente = value;

                if (value != null)
                {
                    this.bIsEnabledClListaPreco = value.stObrigaListaPreco != (byte)1;
                    this.idFuncionarioRepresentante = value.idFuncionario ?? 0;

                    //Criei esta validação para facilitar em todas as partes do código que precise ser validado se é venda no estado ou não. Valor será setado na variável 'this.VendaNoEstado'
                    #region Venda no Estado?
                    EnderecoModel objEnderecoCliente = value.lCliente_fornecedor_Endereco.FirstOrDefault(i => i.stPrincipal == ((byte)1));


                    if (objEnderecoCliente == null)
                        objEnderecoCliente = value.lCliente_fornecedor_Endereco.FirstOrDefault();

                    if (objEnderecoCliente != null)
                        if (objEnderecoCliente.objCidade != null)
                        {
                            idUfEnderecoCliente = (objEnderecoCliente.objCidade as CidadeModel).idUF;

                            if (this.lOrcamento_Itens != null)
                            {
                                foreach (Orcamento_ItemModel item in this.lOrcamento_Itens)
                                {
                                    item.objImposto.CalculateVlrIcmsSubstTributaria();
                                }
                            }
                        }

                    if (objCliente.lCliente_fornecedor_contato != null)
                    {
                        ContatoModel objContato = objCliente.lCliente_fornecedor_contato.FirstOrDefault(i => i.stPrincipal);

                        if (objContato != null)
                            this.idContato = objContato.idContato;
                    }
                }

                    #endregion

                if (this.GetOperationModel() == OperationModel.updating)
                {

                    if (value != null)
                    {
                        this.idCondicaoPagamento = value.idCondicaoPagamento;
                        this.idRamoAtividade = value.idRamoAtividade;
                        this.idCanalVenda = value.idCanalVenda;
                        this.idDescontos = value.idDescontos;
                        if (value.cliente_fornecedor_fiscal != null)
                            this.stContribuinteIcms = value.cliente_fornecedor_fiscal.stContribuienteIcms;

                        if (value.objListaPrecoPai != null)
                        {
                            foreach (var item in this.lOrcamento_Itens)
                            {
                                item.idListaPrecoPai = value.objListaPrecoPai.idListaPrecoPai ?? 0;
                                item.CalculateVlrDescontoSuframa();
                            }
                        }

                        if (value.lCliente_fornecedor_contato != null)
                        {
                            ContatoModel objContato = value.lCliente_fornecedor_contato.FirstOrDefault(i => i.stPrincipal);

                            if (objContato != null)
                                this.idContato = objContato.idContato;
                        }
                    }
                }

                if (this.lOrcamento_Itens != null)
                {
                    foreach (Orcamento_ItemModel item in this.lOrcamento_Itens)
                    {
                        if (item.objImposto != null)
                        {
                            item.objImposto.CalculateTotalIpi();
                            item.objImposto.CalculatePorcIcms();
                            item.objImposto.CalculateBaseIcms();
                            item.objImposto.CalculateVlrIcmsSubstTributaria();
                        }
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
            set
            {
                _objTipoDocumento = value;

                if (value != null && this.GetOperationModel() == OperationModel.updating)
                    if (this.orcamento_retTransp != null)
                        this.orcamento_retTransp.xMarcaVolumeNf = this.objTipoDocumento.xMarcaVolumeNf;
            }
        }

        #endregion

        private void FiltrarItems()
        {
            Window w = Sistema.GetOpenWindow(xName: "WinOrcamento");
            if (w != null)
            {
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, (Action)(() =>
                {
                    DataGrid dg = w.FindName(name: "dgItens") as DataGrid;

                    if (dg != null)
                    {
                        dg.CommitEdit(editingUnit: DataGridEditingUnit.Row, exitEditingMode: true);
                    }
                }));

                Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, (Action)(() =>
                {
                    CollectionViewSource cvs = w.FindResource(resourceKey: "cvsItens") as CollectionViewSource;
                    cvs.Filter += new FilterEventHandler(this.ItensOrcamentoFilter);
                }));

                Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, (Action)(() =>
                {
                    CollectionViewSource cvsImpostos = w.FindResource(resourceKey: "cvsImpostos") as CollectionViewSource;
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


        private int? _idOrcamento;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true), SkipValidation(TypeSkipValidation.all)]
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
        private int? _idTipoOrcamento;
        [ParameterOrder(Order = 5)]
        public int? idTipoOrcamento
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
        private int? _idDescontos;
        [ParameterOrder(Order = 19)]
        public int? idDescontos
        {
            get { return _idDescontos; }
            set
            {
                _idDescontos = value;
                base.NotifyPropertyChanged(propertyName: "idDescontos");
            }
        }
        private int? _idJuros;
        [ParameterOrder(Order = 20)]
        public int? idJuros
        {
            get { return _idJuros; }
            set
            {
                _idJuros = value;
                base.NotifyPropertyChanged(propertyName: "idJuros");
            }
        }
        private int? _idMulta;
        [ParameterOrder(Order = 21)]
        public int? idMulta
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
        [ParameterOrder(Order = 27)]
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
        [ParameterOrder(Order = 28)]
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
        [ParameterOrder(Order = 29)]
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

                        base.NotifyPropertyChanged(propertyName: "idTipoDocumento");
                    }
                }
                else
                {
                    _idTipoDocumento = value;
                    base.NotifyPropertyChanged(propertyName: "idTipoDocumento");
                }
            }
        }

        private int _idEmpresa;
        [ParameterOrder(Order = 30)]
        public int idEmpresa
        {
            get { return _idEmpresa; }
            set
            {
                _idEmpresa = value;

                if (HLP.Base.Static.CompanyData.objEmpresaModel != null)
                    this.xEmpresa = string.Format(format: "{0} - {1}", arg0: value,
                        arg1: (HLP.Base.Static.CompanyData.objEmpresaModel as EmpresaModel).xFantasia);
                base.NotifyPropertyChanged(propertyName: "idEmpresa");
            }
        }
        private int? _idContato;
        [ParameterOrder(Order = 31)]
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
        [ParameterOrder(Order = 32)]
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
        [ParameterOrder(Order = 33)]
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
        [ParameterOrder(Order = 34)]
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
        [ParameterOrder(Order = 35)]
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
        [ParameterOrder(Order = 36)]
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
        [ParameterOrder(Order = 37)]
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
        [ParameterOrder(Order = 38)]
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
        [ParameterOrder(Order = 39)]
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

    public partial class Orcamento_ItemModel : modelComum
    {
        private GCHandle _refOrcamentoIde;

        public GCHandle refOrcamentoIde
        {
            get { return _refOrcamentoIde; }
            set
            {
                _refOrcamentoIde = value;
                base.NotifyPropertyChanged(propertyName: "refOrcamentoIde");
            }
        }


        private ProdutoModel _objProduto;

        public ProdutoModel objProduto
        {
            get { return _objProduto; }
            set
            {
                _objProduto = value;

                if (value != null)
                {
                    if (value.objFamiliaProduto != null)
                    {
                        if (value.objFamiliaProduto.stAlteraDescricaoComercialProdutoVenda
                            == 0)
                            this.bXComercialEnabled = false;
                        else
                            this.bXComercialEnabled = true;
                    }

                    if (this.objProduto.lUnidades != null)
                        this.lUnMedida = new ObservableCollection<modelToComboBox>(list:
                            this.objProduto.lUnidades);

                    if (this.refOrcamentoIde.IsAllocated)
                    {
                        if ((this.refOrcamentoIde.Target as Orcamento_ideModel).GetOperationModel() == OperationModel.updating)
                        {
                            if (this.lUnMedida != null)
                                this.idUnidadeMedida = objProduto.idUnidadeMedidaVendas ?? 0;

                            this.xComercial = this.objProduto.xComercial;
                            this.objImposto.ICMS_stOrigemMercadoria = objProduto.stOrigemMercadoria;
                            this.nPesoBruto = objProduto.nPesoBruto;
                            this.nPesoLiquido = objProduto.nPesoLiquido;

                            if (this.objListaPreco != null)
                            {
                                Lista_precoModel objListaItem = this.objListaPreco.lLista_preco
                                    .FirstOrDefault(i => i.idProduto == value.idProduto);

                                if (objListaItem != null)
                                {
                                    this.vVendaSemDesconto = this.vVenda = objListaItem.vVenda;
                                }
                            }
                        }
                    }
                }

                base.NotifyPropertyChanged(propertyName: "objProduto");
            }
        }


        private Lista_Preco_PaiModel _objListaPreco;

        public Lista_Preco_PaiModel objListaPreco
        {
            get { return _objListaPreco; }
            set
            {
                _objListaPreco = value;

                if (this.refOrcamentoIde.IsAllocated && value != null)
                    if ((this.refOrcamentoIde.Target as Orcamento_ideModel).GetOperationModel() == OperationModel.updating)
                    {
                        Lista_precoModel objListaItem = value.lLista_preco
                                .FirstOrDefault(i => i.idProduto == this.idProduto);

                        if (objListaItem != null)
                        {
                            this.vVenda = this.vVendaSemDesconto = objListaItem.vVenda;
                        }
                    }

                base.NotifyPropertyChanged(propertyName: "objListaPreco");
            }
        }

        public void AfterConstructor()
        {
            if (this.refOrcamentoIde.IsAllocated)
                if ((this.refOrcamentoIde.Target as Orcamento_ideModel) != null)
                {
                    if ((this.refOrcamentoIde.Target as Orcamento_ideModel).GetOperationModel() == OperationModel.updating)
                    {
                        this.stOrcamentoItem = (byte)0;

                        if (!(string.IsNullOrEmpty(value: (this.refOrcamentoIde.Target as Orcamento_ideModel).xPedidoCliente)))
                        {
                            this.xPedidoCliente = (this.refOrcamentoIde.Target as Orcamento_ideModel).xPedidoCliente;
                            this.bPedidoClienteEnabled = false;
                        }
                        else
                        {
                            this.bPedidoClienteEnabled = true;
                        }

                        if ((this.refOrcamentoIde.Target as Orcamento_ideModel).objCliente != null)
                            if ((this.refOrcamentoIde.Target as Orcamento_ideModel).objCliente.objListaPrecoPai != null)
                                this.idListaPrecoPai = (this.refOrcamentoIde.Target as Orcamento_ideModel).objCliente.objListaPrecoPai.idListaPrecoPai ?? 0;


                        if ((this.refOrcamentoIde.Target as Orcamento_ideModel).objCliente != null)
                            if ((this.refOrcamentoIde.Target as Orcamento_ideModel).objCliente.objDesconto != null)
                                this.pDesconto = (this.refOrcamentoIde.Target as Orcamento_ideModel).objCliente.objDesconto.pDesconto ?? 0;

                        this.lOrcamentoItemsRepresentantes = new ObservableCollectionBaseCadastros<Orcamento_Item_RepresentantesModel>();
                        this.idFuncionarioRepresentante = (this.refOrcamentoIde.Target as Orcamento_ideModel).idFuncionarioRepresentante;
                    }
                }
        }

        public Orcamento_ItemModel()
            : base(xTabela: "Orcamento_Item")
        {

            this.bPermitePorcentagem = true;

            this.objImposto = new Orcamento_Item_ImpostosModel();
            objProduto = new ProdutoModel();

            this.bXComercialEnabled = false;
        }

        #region Métodos de Cálculos

        public void DescValidated(decimal p, bool bShowWdSupervisor = true)
        {
            if (this.refOrcamentoIde.IsAllocated)
            {
                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).GetOperationModel() == OperationModel.updating)
                {
                    this.bPermitePorcentagem = false;
                    Lista_precoModel objItemListaPreco = null;
                    if (this.objListaPreco != null)
                    {
                        if (p < 0) //Desconto
                        {
                            decimal pDescontoMaximo = 100;

                            if (this.objListaPreco.pDescontoMaximo != null)
                            {
                                pDescontoMaximo = (decimal)this.objListaPreco.pDescontoMaximo;
                            }
                            else
                            {
                                if (this.objListaPreco.lLista_preco != null)
                                {
                                    objItemListaPreco = (this.objListaPreco as Lista_Preco_PaiModel).lLista_preco.FirstOrDefault(
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

                            if (this.objListaPreco.pAcressimoMaximo != null)
                            {
                                pAcrescimoMaximo = (decimal)this.objListaPreco.pAcressimoMaximo;
                            }
                            else
                            {
                                if (this.objListaPreco.lLista_preco != null)
                                {
                                    objItemListaPreco = this.objListaPreco.lLista_preco.FirstOrDefault(
                                        i => i.idProduto == this.idProduto);

                                    if (objItemListaPreco != null)
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

        public void SetTotalItem()
        {
            try
            {
                if (this.refOrcamentoIde.IsAllocated)
                {
                    if ((this.refOrcamentoIde.Target as Orcamento_ideModel).GetOperationModel() == OperationModel.updating)
                    {
                        this.vTotalSemDescontoItem = (this._qProduto * this._vVendaSemDesconto);

                        this.vTotalItem = (this._vVenda * this._qProduto) + (this._vDesconto ?? 0) + this._vFreteItem + this._vSegurosItem + this._vOutrasDespesasItem;

                        this.objImposto.CalculateBaseIpi();

                        base.NotifyPropertyChanged(propertyName: "vTotalSemDescontoItem");
                        base.NotifyPropertyChanged(propertyName: "vTotalItem");
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
            if (this.refOrcamentoIde.IsAllocated)
                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).GetOperationModel()
                        == OperationModel.updating)
                {
                    if ((this.refOrcamentoIde.Target as Orcamento_ideModel).objCliente != null)
                        if ((this.refOrcamentoIde.Target as Orcamento_ideModel).objCliente.cliente_fornecedor_fiscal != null)
                            if ((this.refOrcamentoIde.Target as Orcamento_ideModel).objCliente.cliente_fornecedor_fiscal.stDescontaIcmsSuframa ==
                                (byte)1 && !(string.IsNullOrEmpty(value: (this.refOrcamentoIde.Target as Orcamento_ideModel).objCliente.cliente_fornecedor_fiscal.xCodigoSuframa)))
                            {
                                this.vDescontoSuframa = (1 + ((this.refOrcamentoIde.Target as Orcamento_ideModel).objCliente.cliente_fornecedor_fiscal.pDescontaIcmsSuframa / 100))
                                    * this.vTotalItem;
                            }
                }
        }

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

        private int? _idOrcamentoItem;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        [SkipValidation(skip: TypeSkipValidation.all)]
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
        [ParameterOrder(Order = 2), SkipValidation(skip: TypeSkipValidation.all)]
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


        private DepositoModel _objDeposito;

        public DepositoModel objDeposito
        {
            get { return _objDeposito; }
            set
            {
                _objDeposito = value;

                if (this.refOrcamentoIde.IsAllocated && value != null)
                    if ((this.refOrcamentoIde.Target as Orcamento_ideModel).GetOperationModel()
                        == OperationModel.updating)
                        this.idSite = value.idSite;

                base.NotifyPropertyChanged(propertyName: "objDeposito");
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


        private Tipo_operacaoModel _objTipoOperacao;

        public Tipo_operacaoModel objTipoOperacao
        {
            get { return _objTipoOperacao; }
            set
            {
                _objTipoOperacao = value;

                if (this.refOrcamentoIde.IsAllocated)
                {
                    if ((this.refOrcamentoIde.Target as Orcamento_ideModel).GetOperationModel() == OperationModel.updating
                        && this.objImposto.objTipoOperacao != null)
                    {
                        //Dúvida: Este Campo, idCfop, poderá ser modificado?
                        this.idCfop = (this.refOrcamentoIde.Target as Orcamento_ideModel).idUfEnderecoCliente ==
                            (this.refOrcamentoIde.Target as Orcamento_ideModel).idUfEnderecoEmpresa ? this.objImposto.objTipoOperacao.cCfopNaUf : this.objImposto.objTipoOperacao.cCfopOutraUf;
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

                        if ((this.refOrcamentoIde.Target as Orcamento_ideModel).objCliente != null)
                            if ((this.refOrcamentoIde.Target as Orcamento_ideModel).objCliente.cliente_fornecedor_fiscal != null)
                                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).objCliente.cliente_fornecedor_fiscal.stCalculaIcms == (byte)0)
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

                base.NotifyPropertyChanged(propertyName: "objTipoOperacao");
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


        private Unidade_medidaModel _objUnidadeMedida;

        public Unidade_medidaModel objUnidadeMedida
        {
            get { return _objUnidadeMedida; }
            set
            {
                _objUnidadeMedida = value;

                if (value != null)
                    this.xUnidadeMedida = value.xUnidadeMedida;

                base.NotifyPropertyChanged(propertyName: "objUnidadeMedida");
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
        private decimal? _pDesconto;
        [ParameterOrder(Order = 18)]
        public decimal? pDesconto
        {
            get { return _pDesconto; }
            set
            {
                this.DescValidated(p: value ?? 0);
                _pDesconto = value;
                this._vDesconto = ((this._vVenda * this._qProduto) * (this._pDesconto / 100));
                this.SetTotalItem();

                base.NotifyPropertyChanged(propertyName: "pDesconto");
                base.NotifyPropertyChanged(propertyName: "vDesconto");
            }
        }
        private decimal? _vDesconto;
        [ParameterOrder(Order = 19)]
        public decimal? vDesconto
        {
            get { return _vDesconto; }
            set
            {
                decimal pDesconto = decimal.Zero;

                if (this._vVenda > 0)
                    pDesconto = ((value ?? 0) / (this._vVenda * this._qProduto)) * 100;

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
                if (this.refOrcamentoIde.IsAllocated)
                    (this.refOrcamentoIde.Target as Orcamento_ideModel).orcamento_Total_Impostos.CalcularTotais();
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
                this.SetTotalItem();
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

                if (this.refOrcamentoIde.IsAllocated)
                {
                    (this.refOrcamentoIde.Target as Orcamento_ideModel).orcamento_retTransp.vPesoBruto = decimal.Zero;

                    if ((this.refOrcamentoIde.Target as Orcamento_ideModel).GetOperationModel() == OperationModel.updating)
                    {
                        foreach (Orcamento_ItemModel item in (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens)
                        {
                            (this.refOrcamentoIde.Target as Orcamento_ideModel).orcamento_retTransp.vPesoBruto += item.nPesoBruto;
                        }
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

                if (this.refOrcamentoIde.IsAllocated)
                {
                    (this.refOrcamentoIde.Target as Orcamento_ideModel).orcamento_retTransp.vPesoLiquido = decimal.Zero;
                    if ((this.refOrcamentoIde.Target as Orcamento_ideModel).GetOperationModel() == OperationModel.updating)
                    {
                        foreach (Orcamento_ItemModel item in (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens)
                        {
                            (this.refOrcamentoIde.Target as Orcamento_ideModel).orcamento_retTransp.vPesoLiquido += item.nPesoLiquido;
                        }
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

                if (this.refOrcamentoIde.IsAllocated)
                    if ((this.refOrcamentoIde.Target as Orcamento_ideModel).GetOperationModel() == OperationModel.updating)
                    {
                        List<int> lCountStatus = new List<int>();

                        lCountStatus.Add(item: (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens.Count(i => i.stOrcamentoItem == 0));
                        lCountStatus.Add(item: (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens.Count(i => i.stOrcamentoItem == 1));
                        lCountStatus.Add(item: (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens.Count(i => i.stOrcamentoItem == 2));
                        lCountStatus.Add(item: (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens.Count(i => i.stOrcamentoItem == 3));
                        lCountStatus.Add(item: (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens.Count(i => i.stOrcamentoItem == 4));

                        byte vStOrcamentoItem = 0;

                        byte.TryParse(s: lCountStatus.IndexOf(item: lCountStatus.FirstOrDefault(
                            i => i == lCountStatus.Max())).ToString(), result: out vStOrcamentoItem);

                        (this.refOrcamentoIde.Target as Orcamento_ideModel).stOrcamento = vStOrcamentoItem;
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
                this.SetTotalItem();
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
                this.SetTotalItem();
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
                if (this.lOrcamentoItemsRepresentantes != null)
                {
                    Orcamento_Item_RepresentantesModel repToDelete = this.lOrcamentoItemsRepresentantes.
                        FirstOrDefault(i => i.idRepresentante == _idFuncionarioRepresentante);

                    if (repToDelete != null)
                        this.lOrcamentoItemsRepresentantes.RemoveAt(index: this.lOrcamentoItemsRepresentantes.IndexOf(
                            item: repToDelete));
                }

                _idFuncionarioRepresentante = value;

                Orcamento_Item_RepresentantesModel objRep = new Orcamento_Item_RepresentantesModel
                    {
                        idRepresentante = value ?? 0,
                        pComissao = this.pComissao
                    };

                if (this.lOrcamentoItemsRepresentantes != null)
                    this.lOrcamentoItemsRepresentantes.Insert(index: 0, item: objRep);

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

                if (this.lOrcamentoItemsRepresentantes != null)
                {
                    Orcamento_Item_RepresentantesModel objRep = this.lOrcamentoItemsRepresentantes.FirstOrDefault(i => i.idRepresentante == this.idFuncionarioRepresentante);

                    if (objRep != null)
                        objRep.pComissao = value;
                }
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
                if (this.refOrcamentoIde.IsAllocated)
                    (this.refOrcamentoIde.Target as Orcamento_ideModel).orcamento_Total_Impostos.CalcularTotais();
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
                //this.setxRepresentante();
                base.NotifyPropertyChanged(propertyName: "lOrcamentoItemsRepresentantes");
            }
        }
    }

    public partial class Orcamento_Item_ImpostosModel : modelComum
    {

        private GCHandle _refOrcamentoIde;

        public GCHandle refOrcamentoIde
        {
            get { return _refOrcamentoIde; }
            set
            {
                _refOrcamentoIde = value;
                base.NotifyPropertyChanged(propertyName: "refOrcamentoIde");
            }
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
            set
            {
                _objClassificacaoFiscal = value;
                if (value != null)
                    this.xNcm = value.cNCM;
            }
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
            if (this.refOrcamentoIde.IsAllocated)
                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).GetOperationModel()
                        == OperationModel.updating)
                {
                    Orcamento_ItemModel objItem = null;

                    if ((this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens != null)
                    {
                        objItem = (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens.FirstOrDefault(i => i.objImposto == this);
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
            if (this.refOrcamentoIde.IsAllocated)
                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).GetOperationModel()
                        == OperationModel.updating)
                {
                    Orcamento_ItemModel objItem = null;

                    if ((this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens != null)
                    {
                        objItem = (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens.FirstOrDefault(i => i.objImposto == this);
                    }

                    if (objItem != null)
                    {
                        if ((this.refOrcamentoIde.Target as Orcamento_ideModel).objCliente != null)
                            if ((this.refOrcamentoIde.Target as Orcamento_ideModel).objCliente.cliente_fornecedor_fiscal.stCalculaIpi == (byte)1)
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
            if (this.refOrcamentoIde.IsAllocated)
            {
                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).GetOperationModel()
                        == OperationModel.updating)
                {

                    if (this.objCodigoIcms != null)
                    {
                        Codigo_IcmsModel objCodigoIcms =
                            this.objCodigoIcms.lCodigo_IcmsModel.FirstOrDefault(
                            i => i.idUf == (this.refOrcamentoIde.Target as Orcamento_ideModel).idUfEnderecoCliente);

                        if (objCodigoIcms != null)
                            this.ICMS_pICMS = objCodigoIcms.pIcmsEstado;
                    }
                }
            }
        }

        public void CalculateBaseIcms()
        {
            if (this.refOrcamentoIde.IsAllocated)
                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).GetOperationModel()
                        == OperationModel.updating)
                {
                    if (this.ICMS_stCalculaSubstituicaoTributaria == (byte)0)
                    {
                        Orcamento_ItemModel objItem = null;

                        if ((this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens != null)
                        {
                            objItem = (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens.FirstOrDefault(i => i.objImposto == this);
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

                            if ((this.refOrcamentoIde.Target as Orcamento_ideModel).objCliente != null)
                                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).objCliente.cliente_fornecedor_fiscal != null)
                                {
                                    if ((this.refOrcamentoIde.Target as Orcamento_ideModel).objCliente.cliente_fornecedor_fiscal.stZeraIcms == (byte)1 ||
                                        (this.refOrcamentoIde.Target as Orcamento_ideModel).objCliente.cliente_fornecedor_fiscal.stCalculaIcms == (byte)0)
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
            if (this.refOrcamentoIde.IsAllocated)
                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).GetOperationModel()
                        == OperationModel.updating && this._ICMS_stCalculaSubstituicaoTributaria == (byte)0)
                {
                    if (this.ICMS_stCalculaIcms == (byte)0)
                    {
                        this.ICMS_vICMS = decimal.Zero;
                    }
                    else
                    {
                        this.ICMS_vICMS = this._ICMS_vBaseCalculo * (this._ICMS_pICMS / 100);
                    }
                }
        }

        public void CalculatePorcReducaoBaseIcmsIcmsSt()
        {
            if (this.refOrcamentoIde.IsAllocated)
                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).GetOperationModel()
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
                                        .FirstOrDefault(i => i.idUf == (this.refOrcamentoIde.Target as Orcamento_ideModel).idUfEnderecoCliente);

                                    if (objOperacaoReducaoBase != null)
                                    {
                                        this.ICMS_pReduzBase = objOperacaoReducaoBase.pReducaoIcms;
                                        this.ICMS_pReduzBaseSubstituicaoTributaria = objOperacaoReducaoBase.pReducaoIcmsSubstTributaria;
                                    }
                                } break;
                            case 2:
                                {
                                    Operacao_reducao_baseModel objOperacaoReducaoBase = this.objTipoOperacao.lOperacaoReducaoBase
                                        .FirstOrDefault(i => i.idUf == (this.refOrcamentoIde.Target as Orcamento_ideModel).idUfEnderecoCliente);

                                    if (objOperacaoReducaoBase != null)
                                    {
                                        this.ICMS_pReduzBase = objOperacaoReducaoBase.pReducaoIcms;
                                    }
                                } break;
                            case 3:
                                {
                                    Operacao_reducao_baseModel objOperacaoReducaoBase = this.objTipoOperacao.lOperacaoReducaoBase
                                        .FirstOrDefault(i => i.idUf == (this.refOrcamentoIde.Target as Orcamento_ideModel).idUfEnderecoCliente);

                                    if (objOperacaoReducaoBase != null)
                                    {
                                        this.ICMS_pReduzBaseSubstituicaoTributaria = objOperacaoReducaoBase.pReducaoIcmsSubstTributaria;
                                    }
                                } break;
                        }

                        Orcamento_ItemModel objItem = null;

                        if ((this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens != null)
                        {
                            objItem = (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens.FirstOrDefault(i => i.objImposto == this);
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
            if (this.refOrcamentoIde.IsAllocated)
                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).GetOperationModel()
                        == OperationModel.updating)
                {
                    if (this.objCodigoIcms != null)
                    {
                        Codigo_IcmsModel objCodigoIcms =
                        this.objCodigoIcms.lCodigo_IcmsModel.FirstOrDefault(i => i.idUf
                            == (this.refOrcamentoIde.Target as Orcamento_ideModel).idUfEnderecoCliente);

                        if (objCodigoIcms != null)
                            if (this.ICMS_stCalculaSubstituicaoTributaria == (byte)1)
                            {
                                this.ICMS_pMvaSubstituicaoTributaria = objCodigoIcms.pMvaSubstituicaoTributaria;
                            }
                            else
                                this.ICMS_pMvaSubstituicaoTributaria = decimal.Zero;
                    }
                }
        }

        public void CalculateBaseIcmsSubstTributaria()
        {
            if (this.refOrcamentoIde.IsAllocated)
                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).GetOperationModel()
                        == OperationModel.updating)
                {
                    Orcamento_ItemModel objItem = null;

                    if ((this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens != null)
                    {
                        objItem = (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens.FirstOrDefault(i => i.objImposto == this);
                    }

                    if (objItem != null)
                    {
                        if (this.ICMS_stCalculaSubstituicaoTributaria == (byte)1 && objItem.stConsumidorFinal == (byte)0)
                        {
                            if (objItem.stConsumidorFinal == (byte)1 &&
                                (this.refOrcamentoIde.Target as Orcamento_ideModel).stContribuinteIcms == (byte)0)
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
            if (this.refOrcamentoIde.IsAllocated)
                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).GetOperationModel()
                        == OperationModel.updating)
                {
                    Orcamento_ItemModel objItem = null;

                    if ((this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens != null)
                    {
                        objItem = (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens.FirstOrDefault(i => i.objImposto == this);
                    }

                    if (objItem != null)
                    {
                        if ((this.refOrcamentoIde.Target as Orcamento_ideModel).GetOperationModel()
                        == OperationModel.updating)
                        {
                            //TODO: RESOLVER JÁ
                            //UFModel objUf = this.GetMethodDataContextWindowValue(xname: "GetUf",
                            //    _parameters: new object[] { this.GetOrcamentoIde().idUfEnderecoCliente }) as UFModel;

                            UFModel objUf = null;

                            Parametro_FiscalModel objParametroFiscal = null;

                            Cliente_fornecedorModel objCliente = (this.refOrcamentoIde.Target as Orcamento_ideModel).objCliente;

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
                                    && (this.refOrcamentoIde.Target as Orcamento_ideModel).stContribuinteIcms == (byte)1
                                    && (objCliente != null ? objCliente.cliente_fornecedor_fiscal.stSubsticaoTributariaIcmsDiferenciada : (byte)1) != (byte)0)
                                {
                                    this.ICMS_vSubstituicaoTributaria =
                                        (this.ICMS_vBaseCalculoSubstituicaoTributaria * this.ICMS_pIcmsInterno / 100) - (this.ICMS_vICMS * this.ICMS_pIcmsInterno);
                                }
                                else if (this.ICMS_stCalculaSubstituicaoTributaria == (byte)1
                                    && objItem.stConsumidorFinal == (byte)1
                                    && (this.refOrcamentoIde.Target as Orcamento_ideModel).stContribuinteIcms == (byte)1
                                    && ((this.refOrcamentoIde.Target as Orcamento_ideModel).objRamoAtividade != null ?
                                    (this.refOrcamentoIde.Target as Orcamento_ideModel).objRamoAtividade.xRamo : "").ToUpper() == "1-COMERCIO"
                                    && (this.refOrcamentoIde.Target as Orcamento_ideModel).idUfEnderecoCliente != (this.refOrcamentoIde.Target as Orcamento_ideModel).idUfEnderecoEmpresa
                                    )
                                {
                                    this.ICMS_vSubstituicaoTributaria = this.ICMS_vBaseCalculoSubstituicaoTributaria *
                                        ((this.ICMS_pICMS - this.ICMS_pIcmsInterno) / 100);
                                }
                                else if (this.ICMS_stCalculaSubstituicaoTributaria == (byte)1
                                    && objItem.stConsumidorFinal == (byte)0
                                    && (this.refOrcamentoIde.Target as Orcamento_ideModel).stContribuinteIcms == (byte)1
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
                                    && (this.refOrcamentoIde.Target as Orcamento_ideModel).stContribuinteIcms == (byte)0
                                    && (objParametroFiscal != null ? objParametroFiscal.stIcmsSubstDif : (byte)0) == (byte)1
                                    && ((this.refOrcamentoIde.Target as Orcamento_ideModel).objRamoAtividade != null ?
                                    (this.refOrcamentoIde.Target as Orcamento_ideModel).objRamoAtividade.xRamo : "").ToUpper() == "1-COMERCIO"
                                    && (this.refOrcamentoIde.Target as Orcamento_ideModel).idUfEnderecoCliente == (this.refOrcamentoIde.Target as Orcamento_ideModel).idUfEnderecoEmpresa
                                    && (objCliente != null ? objCliente.cliente_fornecedor_fiscal.stSubsticaoTributariaIcmsDiferenciada : (byte)1) != (byte)0
                                    )
                                {
                                    this._ICMS_vBaseCalculoSubstituicaoTributaria = this.ICMS_vSubstituicaoTributaria = decimal.Zero;
                                    base.NotifyPropertyChanged(propertyName: "ICMS_vBaseCalculoSubstituicaoTributaria");
                                }
                                else if (this.ICMS_stCalculaSubstituicaoTributaria == (byte)1
                                    && objItem.stConsumidorFinal == (byte)1
                                    && (this.refOrcamentoIde.Target as Orcamento_ideModel).stContribuinteIcms == (byte)1
                                    && (objParametroFiscal != null ? objParametroFiscal.stIcmsSubstDif : (byte)1) == (byte)0
                                    && ((this.refOrcamentoIde.Target as Orcamento_ideModel).objRamoAtividade != null ?
                                    (this.refOrcamentoIde.Target as Orcamento_ideModel).objRamoAtividade.xRamo : "").ToUpper() == "1-COMERCIO"
                                    && (this.refOrcamentoIde.Target as Orcamento_ideModel).idUfEnderecoCliente != (this.refOrcamentoIde.Target as Orcamento_ideModel).idUfEnderecoEmpresa
                                    && (objCliente != null ? objCliente.cliente_fornecedor_fiscal.stSubsticaoTributariaIcmsDiferenciada : (byte)1) != (byte)0
                                    )
                                {
                                    this._ICMS_vBaseCalculoSubstituicaoTributaria = this.ICMS_vSubstituicaoTributaria = decimal.Zero;
                                    base.NotifyPropertyChanged(propertyName: "ICMS_vBaseCalculoSubstituicaoTributaria");
                                }
                                else if (this.ICMS_stCalculaSubstituicaoTributaria == (byte)1
                                    && objItem.stConsumidorFinal == (byte)1
                                    && (this.refOrcamentoIde.Target as Orcamento_ideModel).stContribuinteIcms == (byte)1
                                    && (objParametroFiscal != null ? objParametroFiscal.stIcmsSubstDif : (byte)0) == (byte)1
                                    && ((this.refOrcamentoIde.Target as Orcamento_ideModel).objRamoAtividade != null ?
                                    (this.refOrcamentoIde.Target as Orcamento_ideModel).objRamoAtividade.xRamo : "").ToUpper() == "1-COMERCIO"
                                    && (this.refOrcamentoIde.Target as Orcamento_ideModel).idUfEnderecoCliente != (this.refOrcamentoIde.Target as Orcamento_ideModel).idUfEnderecoEmpresa
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
            if (this.refOrcamentoIde.IsAllocated)
                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).GetOperationModel()
                        == OperationModel.updating)
                {
                    if (this.ICMS_stCalculaSubstituicaoTributaria == (byte)1)
                    {
                        Orcamento_ItemModel objItem = null;

                        if ((this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens != null)
                        {
                            objItem = (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens.FirstOrDefault(i => i.objImposto == this);
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
            if (this.refOrcamentoIde.IsAllocated)
                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).GetOperationModel()
                        == OperationModel.updating && this._ICMS_stCalculaSubstituicaoTributaria == (byte)1)
                {
                    this.ICMS_vIcmsProprio = this.ICMS_vBaseCalculoIcmsProprio * (this.ICMS_pICMS / 100);
                }
        }

        public void CalculatePorcIcmsInterno()
        {
            if (this.refOrcamentoIde.IsAllocated)
                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).GetOperationModel()
                        == OperationModel.updating)
                {

                    if (this.objCodigoIcms != null)
                    {
                        Codigo_IcmsModel objCodigoIcms = this.objCodigoIcms.lCodigo_IcmsModel.FirstOrDefault(i => i.idUf
                            == (this.refOrcamentoIde.Target as Orcamento_ideModel).idUfEnderecoCliente);

                        if (objCodigoIcms != null)
                        {
                            if (this.ICMS_stCalculaSubstituicaoTributaria == (byte)1)
                                this.ICMS_pIcmsInterno = objCodigoIcms.pIcmsInterna;
                            else
                                this.ICMS_pIcmsInterno = decimal.Zero;
                        }
                    }
                }
        }

        public void CalculateBasePis()
        {
            if (this.refOrcamentoIde.IsAllocated)
                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).GetOperationModel()
                        == OperationModel.updating)
                {
                    Orcamento_ItemModel objItem = null;

                    if ((this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens != null)
                    {
                        objItem = (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens.FirstOrDefault(i => i.objImposto == this);
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
            if (this.refOrcamentoIde.IsAllocated)
                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).GetOperationModel()
                        == OperationModel.updating)
                {
                    Orcamento_ItemModel objItem = null;

                    if ((this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens != null)
                    {
                        objItem = (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens.FirstOrDefault(i => i.objImposto == this);
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
            if (this.refOrcamentoIde.IsAllocated)
                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).GetOperationModel()
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
            if (this.refOrcamentoIde.IsAllocated)
                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).GetOperationModel()
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

        public void CalculateVlrIss()
        {
            if (this.refOrcamentoIde.IsAllocated)
                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).GetOperationModel() == OperationModel.updating)
                {
                    if (this.ISS_stCalculaIss == (byte)1)
                    {
                        this.ISS_vIss = this.ISS_vBaseCalculo * (this.ISS_pIss / 100);
                    }
                    else
                    {
                        this.ISS_vIss = decimal.Zero;
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
        [SkipValidation(skip: TypeSkipValidation.all)]
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
                if (this.refOrcamentoIde.IsAllocated)
                    (this.refOrcamentoIde.Target as Orcamento_ideModel).orcamento_Total_Impostos.CalcularTotais();
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

                if (this.refOrcamentoIde.IsAllocated)
                    (this.refOrcamentoIde.Target as Orcamento_ideModel).orcamento_Total_Impostos.CalcularTotais();

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

                this.CalculateVlrIcms();

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

                if (this.refOrcamentoIde.IsAllocated)
                    (this.refOrcamentoIde.Target as Orcamento_ideModel).orcamento_Total_Impostos.CalcularTotais();
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
        [ParameterOrder(Order = 23), SkipValidation(skip: TypeSkipValidation.all)]
        public int idOrcamentoItem
        {
            get { return _idOrcamentoItem; }
            set
            {
                _idOrcamentoItem = value;
                base.NotifyPropertyChanged(propertyName: "idOrcamentoItem");
            }
        }

        private Codigo_Icms_paiModel _objCodigoIcms;

        public Codigo_Icms_paiModel objCodigoIcms
        {
            get { return _objCodigoIcms; }
            set
            {
                _objCodigoIcms = value;
                base.NotifyPropertyChanged(propertyName: "objCodigoIcms");
            }
        }

        private int _idCodigoIcmsPai;
        [ParameterOrder(Order = 24), SkipValidation(skip: TypeSkipValidation.onlyDataGrid)]
        public int idCodigoIcmsPai
        {
            get { return _idCodigoIcmsPai; }
            set
            {
                _idCodigoIcmsPai = value;

                if (this.refOrcamentoIde.IsAllocated)
                    if ((this.refOrcamentoIde.Target as Orcamento_ideModel).GetOperationModel() ==
                         OperationModel.updating)
                    {
                        if ((this.refOrcamentoIde.Target as Orcamento_ideModel).objCliente != null)
                            if ((this.refOrcamentoIde.Target as Orcamento_ideModel).objCliente.cliente_fornecedor_fiscal != null)
                                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).objCliente.cliente_fornecedor_fiscal.stZeraIcms == (byte)0)
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

                if (this.refOrcamentoIde.IsAllocated)
                    (this.refOrcamentoIde.Target as Orcamento_ideModel).orcamento_Total_Impostos.CalcularTotais();
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
                this.CalculateVlrIss();
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
                this.CalculateVlrIss();
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

                if (this.refOrcamentoIde.IsAllocated)
                    (this.refOrcamentoIde.Target as Orcamento_ideModel).orcamento_Total_Impostos.CalcularTotais();
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
                this.CalculateVlrIss();
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

                if (this.refOrcamentoIde.IsAllocated)
                    (this.refOrcamentoIde.Target as Orcamento_ideModel).orcamento_Total_Impostos.CalcularTotais();
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

                if (this.refOrcamentoIde.IsAllocated)
                    (this.refOrcamentoIde.Target as Orcamento_ideModel).orcamento_Total_Impostos.CalcularTotais();
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
    }

    public partial class Orcamento_Item_RepresentantesModel : modelComum
    {
        private GCHandle _refOrcamentoIde;

        public GCHandle refOrcamentoIde
        {
            get { return _refOrcamentoIde; }
            set
            {
                _refOrcamentoIde = value;
                base.NotifyPropertyChanged(propertyName: "refOrcamentoIde");
            }
        }

        public Orcamento_Item_RepresentantesModel()
        {
        }

        private int? _idOrcamentoItemRepresentate;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        [SkipValidation(skip: TypeSkipValidation.all)]
        public int? idOrcamentoItemRepresentate
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

                if (this.refOrcamentoIde.IsAllocated)
                    if ((this.refOrcamentoIde.Target as Orcamento_ideModel).GetOperationModel() == OperationModel.updating)
                    {
                        #region Cálculo de Comissão

                        Orcamento_ItemModel currentItem = null;

                        foreach (Orcamento_ItemModel it in (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens)
                        {
                            if (it.lOrcamentoItemsRepresentantes.Contains(item: this))
                                currentItem = it;
                        }

                        if (currentItem != null)
                        {


                            byte stVistaPrazo = 0;
                            byte stComissao = 1;

                            if ((this.refOrcamentoIde.Target as Orcamento_ideModel).objCondicaoPagamento != null)
                            {
                                stVistaPrazo = (this.refOrcamentoIde.Target as Orcamento_ideModel).objCondicaoPagamento.stCondicao; // 0 - a Vista : 1 - a Prazo
                            }

                            if ((this.refOrcamentoIde.Target as Orcamento_ideModel).objFuncionarioRepresentante != null)
                            {
                                stComissao = (this.refOrcamentoIde.Target as Orcamento_ideModel).objFuncionarioRepresentante.stComissao ?? 1;
                            }

                            switch (stComissao)
                            {
                                case 0:
                                    {
                                        switch (stVistaPrazo)
                                        {
                                            case 0:
                                                {
                                                    this.pComissao = (this.refOrcamentoIde.Target as Orcamento_ideModel).objFuncionarioRepresentante.pComissaoAvista;
                                                } break;
                                            case 1:
                                                {
                                                    this.pComissao = (this.refOrcamentoIde.Target as Orcamento_ideModel).objFuncionarioRepresentante.pComissaoAprazo;
                                                } break;
                                        }
                                    } break;
                                case 1:
                                    {
                                        Lista_precoModel objListaItem = currentItem.objListaPreco.lLista_preco.
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
                                        if (currentItem.objProduto.objFamiliaProduto != null)
                                            switch (stVistaPrazo)
                                            {
                                                case 0:
                                                    {
                                                        this.pComissao = currentItem.objProduto.objFamiliaProduto.pComissaoAvista;
                                                    } break;
                                                case 1:
                                                    {
                                                        this.pComissao = currentItem.objProduto.objFamiliaProduto.pComissaoAprazo;
                                                    } break;
                                            }
                                    } break;
                                case 3:
                                    {
                                        Funcionario_Comissao_ProdutoModel objFuncionarioComissaoProduto =
                                            (this.refOrcamentoIde.Target as Orcamento_ideModel).objFuncionarioRepresentante.lFuncionario_Comissao_Produto
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

                                        Funcionario_Margem_Lucro_ComissaoModel objFuncionarioMargemLucroComissao =
                                            (this.refOrcamentoIde.Target as Orcamento_ideModel).objFuncionarioRepresentante.
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
        [SkipValidation(skip: TypeSkipValidation.all)]
        public int? idOrcamentoItem
        {
            get { return _idOrcamentoItem; }
            set
            {
                _idOrcamentoItem = value;
                base.NotifyPropertyChanged(propertyName: "idOrcamentoItem");
            }
        }
    }

    public partial class Orcamento_Total_ImpostosModel : modelComum
    {
        private GCHandle _refOrcamentoIde;

        public GCHandle refOrcamentoIde
        {
            get { return _refOrcamentoIde; }
            set
            {
                _refOrcamentoIde = value;
                base.NotifyPropertyChanged(propertyName: "refOrcamentoIde");
            }
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
            #region Cálculo de totais produtos

            decimal dTotalProdutos = decimal.Zero;

            if (this.refOrcamentoIde.IsAllocated)
            {
                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bCriadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dTotalProdutos += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => !i.stServico && i.stOrcamentoItem == 0)
                        .Sum(i => i.vTotalItem);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bEnviadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dTotalProdutos += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => !i.stServico && i.stOrcamentoItem == 1)
                        .Sum(i => i.vTotalItem);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bConfirmadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dTotalProdutos += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => !i.stServico && i.stOrcamentoItem == 2)
                        .Sum(i => i.vTotalItem);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bPerdidoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dTotalProdutos += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => !i.stServico && i.stOrcamentoItem == 3)
                        .Sum(i => i.vTotalItem);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bCanceladoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dTotalProdutos += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => !i.stServico && i.stOrcamentoItem == 4)
                        .Sum(i => i.vTotalItem);
                }

                this._vProdutoTotal = dTotalProdutos;
                base.NotifyPropertyChanged(propertyName: "vProdutoTotal");

            #endregion

                #region Cálculo de totais servicos

                decimal dTotalServicos = decimal.Zero;

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bCriadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dTotalServicos += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stServico && i.stOrcamentoItem == 0)
                        .Sum(i => i.vTotalItem);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bEnviadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dTotalServicos += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stServico && i.stOrcamentoItem == 1)
                        .Sum(i => i.vTotalItem);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bConfirmadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dTotalServicos += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stServico && i.stOrcamentoItem == 2)
                        .Sum(i => i.vTotalItem);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bPerdidoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dTotalServicos += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stServico && i.stOrcamentoItem == 3)
                        .Sum(i => i.vTotalItem);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bCanceladoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dTotalServicos += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stServico && i.stOrcamentoItem == 4)
                        .Sum(i => i.vTotalItem);
                }

                if (dTotalServicos > 0)
                {
                    if ((this.refOrcamentoIde.Target as Orcamento_ideModel).objCliente != null)
                        this.xIM = (this.refOrcamentoIde.Target as Orcamento_ideModel).objCliente.xIm;
                }
                else
                    this.xIM = string.Empty;


                this._vServicoTotal = dTotalServicos;
                base.NotifyPropertyChanged(propertyName: "vServicoTotal");

                #endregion

                #region Cálculo de totais descontos

                decimal dTotalVlrDescontos = decimal.Zero;

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bCriadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dTotalVlrDescontos += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 0)
                        .Sum(i => (i.vDesconto ?? 0));
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bEnviadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dTotalVlrDescontos += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 1)
                        .Sum(i => (i.vDesconto ?? 0));
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bConfirmadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dTotalVlrDescontos += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 2)
                        .Sum(i => (i.vDesconto ?? 0));
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bPerdidoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dTotalVlrDescontos += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 3)
                        .Sum(i => (i.vDesconto ?? 0));
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bCanceladoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dTotalVlrDescontos += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 4)
                        .Sum(i => (i.vDesconto ?? 0));
                }

                this._vDescontoTotal = dTotalVlrDescontos;
                decimal valorTotal = (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens.Select(i => (i.qProduto * i.vVenda)).Sum();
                if (valorTotal != 0)
                    this._pDescontoTotal = (this._vDescontoTotal / valorTotal) * 100;
                else
                    this._pDescontoTotal = decimal.Zero;
                base.NotifyPropertyChanged(propertyName: "vDescontoTotal");
                base.NotifyPropertyChanged(propertyName: "pDescontoTotal");

                #endregion

                //#region Cálculo de totais porc. Desconto

                //decimal dTotalPorcDescontos = decimal.Zero;

                //if (objOrcamento_ide.bCriadoTotais || objOrcamento_ide.bTodosTotais)
                //{
                //    dTotalPorcDescontos += objOrcamento_ide.lOrcamento_Itens
                //        .Where(i => i.stOrcamentoItem == 0)
                //        .Sum(i => i.pDesconto);
                //}

                //if (objOrcamento_ide.bEnviadoTotais || objOrcamento_ide.bTodosTotais)
                //{
                //    dTotalPorcDescontos += objOrcamento_ide.lOrcamento_Itens
                //        .Where(i => i.stOrcamentoItem == 1)
                //        .Sum(i => i.pDesconto);
                //}

                //if (objOrcamento_ide.bConfirmadoTotais || objOrcamento_ide.bTodosTotais)
                //{
                //    dTotalPorcDescontos += objOrcamento_ide.lOrcamento_Itens
                //        .Where(i => i.stOrcamentoItem == 2)
                //        .Sum(i => i.pDesconto);
                //}

                //if (objOrcamento_ide.bPerdidoTotais || objOrcamento_ide.bTodosTotais)
                //{
                //    dTotalPorcDescontos += objOrcamento_ide.lOrcamento_Itens
                //        .Where(i => i.stOrcamentoItem == 3)
                //        .Sum(i => i.pDesconto);
                //}

                //if (objOrcamento_ide.bCanceladoTotais || objOrcamento_ide.bTodosTotais)
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

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bCriadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dTotalDescSuframa += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 0)
                        .Sum(i => i.vDescontoSuframa ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bEnviadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dTotalDescSuframa += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 1)
                        .Sum(i => i.vDescontoSuframa ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bConfirmadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dTotalDescSuframa += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 2)
                        .Sum(i => i.vDescontoSuframa ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bPerdidoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dTotalDescSuframa += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 3)
                        .Sum(i => i.vDescontoSuframa ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bCanceladoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dTotalDescSuframa += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 4)
                        .Sum(i => i.vDescontoSuframa ?? 0);
                }

                this._vDescontoSuframaTotal = dTotalDescSuframa;
                base.NotifyPropertyChanged(propertyName: "vDescontoSuframaTotal");

                #endregion

                #region Cálculo de totais frete

                decimal dTotalFrete = decimal.Zero;

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bCriadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dTotalFrete += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 0)
                        .Sum(i => i.vFreteItem);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bEnviadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dTotalFrete += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 1)
                        .Sum(i => i.vFreteItem);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bConfirmadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dTotalFrete += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 2)
                        .Sum(i => i.vFreteItem);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bPerdidoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dTotalFrete += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 3)
                        .Sum(i => i.vFreteItem);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bCanceladoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dTotalFrete += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 4)
                        .Sum(i => i.vFreteItem);
                }

                this._vFreteTotal = dTotalFrete;
                base.NotifyPropertyChanged(propertyName: "vFreteTotal");

                #endregion

                #region Cálculo de totais seguro

                decimal dTotalSeguro = decimal.Zero;

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bCriadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dTotalSeguro += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 0)
                        .Sum(i => i.vSegurosItem);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bEnviadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dTotalSeguro += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 1)
                        .Sum(i => i.vSegurosItem);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bConfirmadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dTotalSeguro += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 2)
                        .Sum(i => i.vSegurosItem);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bPerdidoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dTotalSeguro += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 3)
                        .Sum(i => i.vSegurosItem);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bCanceladoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dTotalSeguro += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 4)
                        .Sum(i => i.vSegurosItem);
                }

                this._vSeguroTotal = dTotalSeguro;
                base.NotifyPropertyChanged(propertyName: "vSeguroTotal");

                #endregion

                #region Cálculo de totais outras despesas

                decimal dOutrasDespesas = decimal.Zero;

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bCriadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dOutrasDespesas += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 0)
                        .Sum(i => i.vOutrasDespesasItem);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bEnviadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dOutrasDespesas += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 1)
                        .Sum(i => i.vOutrasDespesasItem);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bConfirmadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dOutrasDespesas += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 2)
                        .Sum(i => i.vOutrasDespesasItem);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bPerdidoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dOutrasDespesas += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 3)
                        .Sum(i => i.vOutrasDespesasItem);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bCanceladoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dOutrasDespesas += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 4)
                        .Sum(i => i.vOutrasDespesasItem);
                }

                this._vOutrasDespesasTotal = dOutrasDespesas;
                base.NotifyPropertyChanged(propertyName: "vOutrasDespesasTotal");

                #endregion

                #region Cálculo de totais Base de Cálculo ICMS

                decimal dBaseCalcIcms = decimal.Zero;

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bCriadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dBaseCalcIcms += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens.Where(i => i.stOrcamentoItem == 0).
                    Sum(i => i.objImposto.ICMS_vBaseCalculo ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bEnviadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dBaseCalcIcms += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens.Where(i => i.stOrcamentoItem == 1).
                    Sum(i => i.objImposto.ICMS_vBaseCalculo ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bConfirmadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dBaseCalcIcms += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens.Where(i => i.stOrcamentoItem == 2).
                    Sum(i => i.objImposto.ICMS_vBaseCalculo ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bPerdidoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dBaseCalcIcms += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens.Where(i => i.stOrcamentoItem == 3).
                    Sum(i => i.objImposto.ICMS_vBaseCalculo ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bCanceladoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dBaseCalcIcms += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens.Where(i => i.stOrcamentoItem == 4).
                    Sum(i => i.objImposto.ICMS_vBaseCalculo ?? 0);
                }

                this._vBaseCalculoIcmsTotal = dBaseCalcIcms;
                base.NotifyPropertyChanged(propertyName: "vBaseCalculoIcmsTotal");

                #endregion

                #region Cálculo de totais Valor ICMS

                decimal dVlrIcms = decimal.Zero;

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bCriadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrIcms += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens.Where(i => i.stOrcamentoItem == 0)
                        .Sum(i => i.objImposto.ICMS_vICMS ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bEnviadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrIcms += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens.Where(i => i.stOrcamentoItem == 1)
                        .Sum(i => i.objImposto.ICMS_vICMS ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bConfirmadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrIcms += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens.Where(i => i.stOrcamentoItem == 2)
                        .Sum(i => i.objImposto.ICMS_vICMS ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bPerdidoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrIcms += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens.Where(i => i.stOrcamentoItem == 3)
                        .Sum(i => i.objImposto.ICMS_vICMS ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bCanceladoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrIcms += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens.Where(i => i.stOrcamentoItem == 4)
                        .Sum(i => i.objImposto.ICMS_vICMS ?? 0);
                }

                this._vICMSTotal = dVlrIcms;
                base.NotifyPropertyChanged(propertyName: "vICMSTotal");

                #endregion

                #region Cálculo de totais Base de Cálculo Icms Próprio

                decimal dVlrBaseIcmsProprio = decimal.Zero;

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bCriadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrBaseIcmsProprio += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 0).Sum(i => i.objImposto.ICMS_vBaseCalculoIcmsProprio ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bEnviadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrBaseIcmsProprio += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 1).Sum(i => i.objImposto.ICMS_vBaseCalculoIcmsProprio ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bConfirmadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrBaseIcmsProprio += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 2).Sum(i => i.objImposto.ICMS_vBaseCalculoIcmsProprio ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bPerdidoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrBaseIcmsProprio += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 3).Sum(i => i.objImposto.ICMS_vBaseCalculoIcmsProprio ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bCanceladoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrBaseIcmsProprio += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 4).Sum(i => i.objImposto.ICMS_vBaseCalculoIcmsProprio ?? 0);
                }

                this._vBaseCalculoIcmsProprioTotal = dVlrBaseIcmsProprio;
                base.NotifyPropertyChanged(propertyName: "vBaseCalculoIcmsProprioTotal");

                #endregion

                #region Cálculo de totais Valor Icms Próprio

                decimal dVlrIcmsPróprio = decimal.Zero;

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bCriadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrIcmsPróprio += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 0).Sum(i => i.objImposto.ICMS_vIcmsProprio ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bEnviadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrIcmsPróprio += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 1).Sum(i => i.objImposto.ICMS_vIcmsProprio ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bConfirmadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrIcmsPróprio += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 2).Sum(i => i.objImposto.ICMS_vIcmsProprio ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bPerdidoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrIcmsPróprio += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 3).Sum(i => i.objImposto.ICMS_vIcmsProprio ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bCanceladoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrIcmsPróprio += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 4).Sum(i => i.objImposto.ICMS_vIcmsProprio ?? 0);
                }

                this._vIcmsProprioTotal = dVlrBaseIcmsProprio;
                base.NotifyPropertyChanged(propertyName: "vIcmsProprioTotal");

                #endregion

                #region Cálculo de totais Valor Base de Cálculo Ipi

                decimal dVlrBaseCalculoIpi = decimal.Zero;

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bCriadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrBaseCalculoIpi += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 0).Sum(i => i.objImposto.IPI_vBaseCalculo ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bEnviadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrBaseCalculoIpi += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 1).Sum(i => i.objImposto.IPI_vBaseCalculo ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bConfirmadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrBaseCalculoIpi += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 2).Sum(i => i.objImposto.IPI_vBaseCalculo ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bPerdidoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrBaseCalculoIpi += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 3).Sum(i => i.objImposto.IPI_vBaseCalculo ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bCanceladoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrBaseCalculoIpi += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 4).Sum(i => i.objImposto.IPI_vBaseCalculo ?? 0);
                }

                this._vBaseCalculoIpiTotal = dVlrBaseCalculoIpi;
                base.NotifyPropertyChanged(propertyName: "vBaseCalculoIpiTotal");

                #endregion

                #region Cálculo de totais Valor Ipi

                decimal dVlrIpi = decimal.Zero;

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bCriadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrIpi += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 0).Sum(i => i.objImposto.IPI_vIPI ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bEnviadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrIpi += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 1).Sum(i => i.objImposto.IPI_vIPI ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bConfirmadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrIpi += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 2).Sum(i => i.objImposto.IPI_vIPI ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bPerdidoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrIpi += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 3).Sum(i => i.objImposto.IPI_vIPI ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bCanceladoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrIpi += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 4).Sum(i => i.objImposto.IPI_vIPI ?? 0);
                }

                this._vIPITotal = dVlrIpi;
                base.NotifyPropertyChanged(propertyName: "vIPITotal");

                #endregion

                #region Cálculo de totais Valor de Base Substituição Tributária

                decimal dVlrBaseSubstTribut = decimal.Zero;

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bCriadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrBaseSubstTribut += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 0).Sum(i => i.objImposto.ICMS_vBaseCalculoSubstituicaoTributaria ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bEnviadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrBaseSubstTribut += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 1).Sum(i => i.objImposto.ICMS_vBaseCalculoSubstituicaoTributaria ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bConfirmadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrBaseSubstTribut += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 2).Sum(i => i.objImposto.ICMS_vBaseCalculoSubstituicaoTributaria ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bPerdidoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrBaseSubstTribut += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 3).Sum(i => i.objImposto.ICMS_vBaseCalculoSubstituicaoTributaria ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bCanceladoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrBaseSubstTribut += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 4).Sum(i => i.objImposto.ICMS_vBaseCalculoSubstituicaoTributaria ?? 0);
                }

                this._vBaseCalculoICmsSubstituicaoTributariaTotal = dVlrBaseSubstTribut;
                base.NotifyPropertyChanged(propertyName: "vBaseCalculoICmsSubstituicaoTributariaTotal");

                #endregion

                #region Cálculo de totais Valor Substituição Tributária

                decimal dVlrSubsTrib = decimal.Zero;

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bCriadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrSubsTrib += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 0).Sum(i => i.objImposto.ICMS_vSubstituicaoTributaria ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bEnviadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrSubsTrib += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 1).Sum(i => i.objImposto.ICMS_vSubstituicaoTributaria ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bConfirmadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrSubsTrib += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 2).Sum(i => i.objImposto.ICMS_vSubstituicaoTributaria ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bPerdidoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrSubsTrib += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 3).Sum(i => i.objImposto.ICMS_vSubstituicaoTributaria ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bCanceladoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrSubsTrib += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 4).Sum(i => i.objImposto.ICMS_vSubstituicaoTributaria ?? 0);
                }

                this._vIcmsSubstituicaoTributariaTotal = dVlrSubsTrib;
                base.NotifyPropertyChanged(propertyName: "vIcmsSubstituicaoTributariaTotal");

                #endregion

                #region Cálculo de totais base de cálculo Pis

                decimal dVlrBaseCalcPis = decimal.Zero;

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bCriadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrBaseCalcPis += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 0).Sum(i => i.objImposto.PIS_vBaseCalculo ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bEnviadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrBaseCalcPis += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 1).Sum(i => i.objImposto.PIS_vBaseCalculo ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bConfirmadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrBaseCalcPis += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 2).Sum(i => i.objImposto.PIS_vBaseCalculo ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bPerdidoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrBaseCalcPis += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 3).Sum(i => i.objImposto.PIS_vBaseCalculo ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bCanceladoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrBaseCalcPis += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 4).Sum(i => i.objImposto.PIS_vBaseCalculo ?? 0);
                }

                this._vBaseCalculoPisTotal = dVlrBaseCalcPis;
                base.NotifyPropertyChanged(propertyName: "vBaseCalculoPisTotal");

                #endregion

                #region Cálculo de totais valor Pis

                decimal dVlrPis = decimal.Zero;

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bCriadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrPis += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 0).Sum(i => i.objImposto.PIS_vPIS ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bEnviadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrPis += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 1).Sum(i => i.objImposto.PIS_vPIS ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bConfirmadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrPis += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 2).Sum(i => i.objImposto.PIS_vPIS ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bPerdidoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrPis += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 3).Sum(i => i.objImposto.PIS_vPIS ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bCanceladoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrPis += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 4).Sum(i => i.objImposto.PIS_vPIS ?? 0);
                }

                this._vPISTotal = dVlrPis;
                base.NotifyPropertyChanged(propertyName: "vPISTotal");

                #endregion

                #region Cálculo de totais base de cálculo Cofins

                decimal dVlrBaseCalcCofins = decimal.Zero;

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bCriadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrBaseCalcCofins += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 0).Sum(i => i.objImposto.COFINS_vBaseCalculo ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bEnviadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrBaseCalcCofins += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 1).Sum(i => i.objImposto.COFINS_vBaseCalculo ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bConfirmadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrBaseCalcCofins += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 2).Sum(i => i.objImposto.COFINS_vBaseCalculo ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bPerdidoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrBaseCalcCofins += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 3).Sum(i => i.objImposto.COFINS_vBaseCalculo ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bCanceladoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrBaseCalcCofins += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 4).Sum(i => i.objImposto.COFINS_vBaseCalculo ?? 0);
                }

                this._vBaseCalculoCofinsTotal = dVlrBaseCalcCofins;
                base.NotifyPropertyChanged(propertyName: "vBaseCalculoCofinsTotal");

                #endregion

                #region Cálculo de totais Valor Cofins

                decimal dVlrCofins = decimal.Zero;

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bCriadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrCofins += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 0).Sum(i => i.objImposto.COFINS_vCOFINS ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bEnviadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrCofins += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 1).Sum(i => i.objImposto.COFINS_vCOFINS ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bConfirmadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrCofins += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 2).Sum(i => i.objImposto.COFINS_vCOFINS ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bPerdidoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrCofins += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 3).Sum(i => i.objImposto.COFINS_vCOFINS ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bCanceladoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrCofins += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 4).Sum(i => i.objImposto.COFINS_vCOFINS ?? 0);
                }

                this._vCOFINSTotal = dVlrCofins;
                base.NotifyPropertyChanged(propertyName: "vCOFINSTotal");

                #endregion

                #region Cálculo de Valor Base de Cálculo Iss

                decimal dVlrBaseCalcIss = decimal.Zero;

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bCriadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrBaseCalcIss += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 0).Sum(i => i.objImposto.ISS_vBaseCalculo ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bEnviadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrBaseCalcIss += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 1).Sum(i => i.objImposto.ISS_vBaseCalculo ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bConfirmadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrBaseCalcIss += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 2).Sum(i => i.objImposto.ISS_vBaseCalculo ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bPerdidoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrBaseCalcIss += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 3).Sum(i => i.objImposto.ISS_vBaseCalculo ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bCanceladoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrBaseCalcIss += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 4).Sum(i => i.objImposto.ISS_vBaseCalculo ?? 0);
                }

                this._vBaseCalculoIssTotal = dVlrBaseCalcIss;
                base.NotifyPropertyChanged(propertyName: "vBaseCalculoIssTotal");

                #endregion

                #region Cálculo de Valor Iss

                decimal dVlrIss = decimal.Zero;

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bCriadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrIss += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens.Where(i => i.stOrcamentoItem == 0).Sum(i => i.objImposto.ISS_vIss ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bEnviadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrIss += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 1).Sum(i => i.objImposto.ISS_vIss ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bConfirmadoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrIss += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 2).Sum(i => i.objImposto.ISS_vIss ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bPerdidoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrIss += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
                        .Where(i => i.stOrcamentoItem == 3).Sum(i => i.objImposto.ISS_vIss ?? 0);
                }

                if ((this.refOrcamentoIde.Target as Orcamento_ideModel).bCanceladoTotais || (this.refOrcamentoIde.Target as Orcamento_ideModel).bTodosTotais)
                {
                    dVlrIss += (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens
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
        [SkipValidation(skip: TypeSkipValidation.all)]
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


                if (this.refOrcamentoIde.IsAllocated)
                    if ((this.refOrcamentoIde.Target as Orcamento_ideModel).GetOperationModel() == OperationModel.updating)
                    {
                        decimal vTotal = (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens.Select(i => (i.qProduto * i.vVenda)).Sum();

                        if (vTotal != 0)
                        {
                            foreach (Orcamento_ItemModel item in (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens)
                            {
                                item.vFreteItem = (((item.vVenda * item.qProduto) / vTotal) * value);
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
                if (this.refOrcamentoIde.IsAllocated)
                    if ((this.refOrcamentoIde.Target as Orcamento_ideModel).GetOperationModel() == OperationModel.updating)
                    {
                        decimal vTotal = (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens.Select(i => (i.qProduto * i.vVenda)).Sum();

                        if (vTotal != 0)
                        {
                            foreach (Orcamento_ItemModel item in (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens)
                            {
                                item.vSegurosItem = (((item.vVenda * item.qProduto) / vTotal) * value);
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
                if (this.refOrcamentoIde.IsAllocated)
                {
                    if ((this.refOrcamentoIde.Target as Orcamento_ideModel).GetOperationModel() == OperationModel.updating)
                    {
                        decimal vBruto = (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens.Select(i => (i.qProduto * i.vVenda)).Sum();
                        this._pDescontoTotal = (value / vBruto) * 100;
                        base.NotifyPropertyChanged(propertyName: "pDescontoTotal");
                        FieldInfo fivDesconto;
                        decimal _vDescontoItem = decimal.Zero;
                        FieldInfo fipDesconto;
                        decimal _pDescontoItem = decimal.Zero;

                        foreach (Orcamento_ItemModel item in (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens)
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
                                item.status = statusModel.alterado;
                                base.NotifyPropertyChanged(propertyName: "vDesconto");
                            }

                            if (fipDesconto != null)
                            {
                                fipDesconto.SetValue(obj: item, value: _pDescontoItem);
                                item.status = statusModel.alterado;
                                base.NotifyPropertyChanged(propertyName: "pDesconto");
                            }

                            item.DescValidated(p: _pDescontoItem, bShowWdSupervisor: false);
                            item.ValidateProperty(columnName: "pDesconto");
                            item.SetTotalItem();
                        }

                        //TODO: UI Orçamento
                        //CollectionViewSource lItens = wd.FindResource("cvsItens") as CollectionViewSource;

                        //lItens.View.Refresh();

                        if ((this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens.Count(i => !i.bPermitePorcentagem) > 0)
                        {
                            MessageBox.Show(messageBoxText: "Alguns itens ultrapassaram o limite de porcentagem. Verifique!",
                                caption: "Verifique!", button: MessageBoxButton.OK, icon: MessageBoxImage.Exclamation);
                            //TODO: UI Orçamento
                            //TabControl t = wd.FindName(name: "tcPrincipal") as TabControl;
                            //if (t != null)
                            //    t.SelectedIndex = 1;
                        }
                    }
                }
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
                if (this.refOrcamentoIde.IsAllocated)
                    if ((this.refOrcamentoIde.Target as Orcamento_ideModel).GetOperationModel() == OperationModel.updating)
                    {
                        decimal vTotal = (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens.Select(i => (i.qProduto * i.vVenda)).Sum();

                        if (vTotal != 0)
                        {
                            foreach (Orcamento_ItemModel item in (this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens)
                            {
                                item.vOutrasDespesasItem = (((item.vVenda * item.qProduto) / vTotal) * value);
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

                if (this.refOrcamentoIde.IsAllocated)
                    this.vDescontoTotal = (value / 100) * ((this.refOrcamentoIde.Target as Orcamento_ideModel).lOrcamento_Itens.Select(i => (i.qProduto * i.vVenda)).Sum());

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
        [SkipValidation(skip: TypeSkipValidation.all)]
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

    public partial class Orcamento_retTranspModel : modelComum
    {
        public Orcamento_retTranspModel()
            : base("Orcamento_retTransp")
        {
        }

        #region Propriedades relacionadas


        private TransportadorModel _objTransportador;

        public TransportadorModel objTransportador
        {
            get { return _objTransportador; }
            set
            {
                _objTransportador = value;

                if (value != null)
                {
                    this.xRntrc = value.xRntrc;
                    this.xCpfCnpj = value.xCpfCnpj;
                }

                base.NotifyPropertyChanged(propertyName: "objTransportador");
            }
        }

        #endregion

        private int? _idRetTransp;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        [SkipValidation(skip: TypeSkipValidation.all)]
        public int? idRetTransp
        {
            get { return _idRetTransp; }
            set
            {
                _idRetTransp = value;
                base.NotifyPropertyChanged(propertyName: "idRetTransp");
            }
        }
        private int _idOrcamento;
        [ParameterOrder(Order = 2)]
        [SkipValidation(skip: TypeSkipValidation.all)]
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
        [ParameterOrder(Order = 3)]
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
        [ParameterOrder(Order = 4)]
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
        [ParameterOrder(Order = 5)]
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
        [ParameterOrder(Order = 6)]
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
        [ParameterOrder(Order = 7)]
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
        [ParameterOrder(Order = 8)]
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
        [ParameterOrder(Order = 9)]
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
        [ParameterOrder(Order = 10)]
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
        [ParameterOrder(Order = 11)]
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
        [ParameterOrder(Order = 12)]
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
        [ParameterOrder(Order = 13)]
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

    #region Clone

    public partial class Orcamento_ideModel : ICloneable
    {
        public Orcamento_ideModel CloneFullObject()
        {
            Orcamento_ideModel objClone = (Orcamento_ideModel)this.Clone();
            objClone.idOrcamento = null;

            if (objClone.lOrcamento_Itens != null)
                foreach (Orcamento_ItemModel orcamentoItem in this.lOrcamento_Itens)
                {
                    orcamentoItem.idOrcamento = 0;
                    orcamentoItem.idOrcamentoItem = null;
                    orcamentoItem.status = statusModel.criado;

                    if (orcamentoItem.objImposto != null)
                    {
                        orcamentoItem.objImposto.idOrcamentoItem = 0;
                        orcamentoItem.objImposto.idOrcamentoTotalizadorImpostos = null;
                        orcamentoItem.status = statusModel.criado;
                    }

                    if (orcamentoItem.lOrcamentoItemsRepresentantes != null)
                        foreach (Orcamento_Item_RepresentantesModel orcamentoRepresentante in orcamentoItem.lOrcamentoItemsRepresentantes)
                        {
                            orcamentoRepresentante.idOrcamentoItem = null;
                            orcamentoRepresentante.idOrcamentoItemRepresentate = null;
                            orcamentoRepresentante.status = statusModel.criado;
                        }
                }

            if (this.orcamento_Total_Impostos != null)
            {
                this.orcamento_Total_Impostos.idOrcamento = 0;
                this.orcamento_Total_Impostos.idOrcamentoTotalImpostos = null;
            }

            if (this.orcamento_retTransp != null)
            {
                this.orcamento_retTransp.idOrcamento = 0;
                this.orcamento_retTransp.idRetTransp = null;
            }

            return objClone;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    //TODO* : Versão alternativa de clone, onde é tudo clonado manualmente
    //public partial class Orcamento_ideModel : ICloneable
    //{
    //    public Orcamento_ideModel CloneFullObject()
    //    {
    //        Orcamento_ideModel objClone = (Orcamento_ideModel)this.Clone();
    //        objClone.idOrcamento = null;

    //        Orcamento_ItemModel orcamentoItemClone = null;

    //        if (objClone.lOrcamento_Itens != null)
    //            foreach (Orcamento_ItemModel orcamentoItem in this.lOrcamento_Itens)
    //            {
    //                orcamentoItemClone = (Orcamento_ItemModel)orcamentoItem.Clone();

    //                orcamentoItemClone.objImposto = orcamentoItem.objImposto != null ? (Orcamento_Item_ImpostosModel)orcamentoItem.objImposto.Clone() :
    //                    new Orcamento_Item_ImpostosModel();

    //                if (orcamentoItem.lOrcamentoItemsRepresentantes != null)
    //                    foreach (Orcamento_Item_RepresentantesModel orcamentoRepresentante in orcamentoItem.lOrcamentoItemsRepresentantes)
    //                    {
    //                        orcamentoItemClone.lOrcamentoItemsRepresentantes.Add(item:
    //                            (Orcamento_Item_RepresentantesModel)orcamentoRepresentante.Clone());
    //                    }

    //                objClone.lOrcamento_Itens.Add(orcamentoItemClone);
    //            }

    //        if (this.orcamento_Total_Impostos != null)
    //            objClone.orcamento_Total_Impostos = (Orcamento_Total_ImpostosModel)this.orcamento_Total_Impostos.Clone();

    //        if (this.orcamento_retTransp != null)
    //            objClone.orcamento_retTransp = (Orcamento_retTranspModel)this.orcamento_retTransp.Clone();

    //        return objClone;
    //    }

    //    public object Clone()
    //    {
    //        return this.MemberwiseClone();
    //    }
    //}

    public partial class Orcamento_ItemModel : ICloneable
    {
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    public partial class Orcamento_Item_ImpostosModel : ICloneable
    {
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    public partial class Orcamento_Item_RepresentantesModel
    {
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    public partial class Orcamento_Total_ImpostosModel : ICloneable
    {
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    public partial class Orcamento_retTranspModel : ICloneable
    {

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    #endregion

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
