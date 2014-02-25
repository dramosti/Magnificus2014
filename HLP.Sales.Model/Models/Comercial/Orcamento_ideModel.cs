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
using HLP.Comum.Resources.RecursosBases;
using HLP.Comum.Infrastructure.Static;
using HLP.Comum.Facade.Magnificus;
using System.Reactive.Linq;
using HLP.Entries.Model.Models.Parametros;
using System.Windows;
using System.Windows.Data;
using System.Windows.Threading;
using System.Windows.Controls;
using HLP.Comum.Resources.Util;
using System.Windows.Media;

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

                if (OrcamentoFacade.funcionarioService == null)
                    OrcamentoFacade.funcionarioService = new Comum.Facade.funcionarioService.IserviceFuncionarioClient();

                if (OrcamentoFacade.condicaoPagamentoService == null)
                    OrcamentoFacade.condicaoPagamentoService = new Comum.Facade.Condicao_PagamentoService.IserviceCondicao_PagamentoClient();

                if (OrcamentoFacade.tipoOperacaoService == null)
                    OrcamentoFacade.tipoOperacaoService = new Comum.Facade.Tipo_OperacaoService.IserviceTipo_OperacaoClient();

                if (OrcamentoFacade.classificFiscalService == null)
                    OrcamentoFacade.classificFiscalService = new Comum.Facade.ClassificacaoFiscalServico.IserviceClassificacaoFiscalClient();

                if (OrcamentoFacade.icmsService == null)
                    OrcamentoFacade.icmsService = new Comum.Facade.CodigoIcmsService.IserviceCodigoIcmsClient();

                if (OrcamentoFacade.cargaTribMediaService == null)
                    OrcamentoFacade.cargaTribMediaService = new Comum.Facade.Carga_trib_media_st_icmsServico.IserviceCarga_trib_media_st_icmsClient();

                if (OrcamentoFacade.ramo_AtividadeService == null)
                    OrcamentoFacade.ramo_AtividadeService = new Comum.Facade.Ramo_AtividadeService.IserviceRamoAtividadeClient();

                this.orcamento_Total_Impostos = new Orcamento_Total_ImpostosModel();
                this.orcamento_retTransp = new Orcamento_retTranspModel();
                this.lOrcamento_Itens = new ObservableCollectionBaseCadastros<Orcamento_ItemModel>();
                this.lOrcamento_Item_Impostos = new ObservableCollectionBaseCadastros<Orcamento_Item_ImpostosModel>();
                this.lOrcamento_Itens.CollectionChanged += lOrcamento_Itens_CollectionChanged;
                this.bTodos = true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void lOrcamento_Itens_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    {
                        Orcamento_Item_ImpostosModel objImposto;
                        if (e.NewItems != null)
                        {
                            foreach (Orcamento_ItemModel item in e.NewItems)
                            {
                                item.stOrcamentoItem = 0;
                                item.nItem = this._lOrcamento_Itens.Count;
                                objImposto = null;
                                if (this.lOrcamento_Item_Impostos.Count > 0)
                                {
                                    Orcamento_Item_ImpostosModel objImp = this.lOrcamento_Item_Impostos.FirstOrDefault(
                                        i => i.idOrcamentoItem == item.idOrcamentoItem);
                                    if (objImp != null)
                                        objImposto = objImp;
                                }
                                if (objImposto == null)
                                {
                                    objImposto = new Orcamento_Item_ImpostosModel
                                    {
                                        ICMS_pCargaTributariaMedia = OrcamentoFacade.objCadastros.objCargaTrib.pCargaTributariaMedia
                                    };
                                    this.lOrcamento_Item_Impostos.Add(item: objImposto);
                                }

                                objImposto.nItem = item.nItem;
                                item.objImposto = objImposto;
                            }
                            base.NotifyPropertyChanged(propertyName: "lOrcamento_Item_Impostos");
                        }
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    {
                        if (e.OldItems != null)
                        {
                            foreach (Orcamento_ItemModel item in e.OldItems)
                            {
                                if (this.lOrcamento_Item_Impostos.Count(i => i.nItem == item.nItem) > 0)
                                {
                                    this.lOrcamento_Item_Impostos.RemoveAt(index: this.lOrcamento_Item_Impostos.IndexOf(item:
                                        this.lOrcamento_Item_Impostos.FirstOrDefault(i => i.nItem == item.nItem)));
                                }
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
        }

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


        private int _idRamoAtividade;

        public int idRamoAtividade
        {
            get { return _idRamoAtividade; }
            set
            {
                _idRamoAtividade = value;

                if (value > 0)
                    OrcamentoFacade.objCadastros.objRamoAtividade = OrcamentoFacade.ramo_AtividadeService.getRamo_atividade(
                        idRamo_atividade: value);

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
                return OrcamentoFacade.objCadastros.objCliente != null ?
                    OrcamentoFacade.objCadastros.objCliente.idListaPrecoPai : 0;
            }
        }


        #endregion

        private void FiltrarItems()
        {
            Window w = Sistema.GetOpenWindow(xName: "WinOrcamento");
            if (w != null)
            {
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
            else if (e.Item.GetType() == typeof(Orcamento_Item_ImpostosModel))
            {
                Orcamento_Item_ImpostosModel i = e.Item as Orcamento_Item_ImpostosModel;

                if (i != null)
                {
                    bool valido = false;
                    switch (i.stOrcamentoImpostos)
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
                        OrcamentoFacade.objCadastros.stContribuinteIcms = this.stContribuinteIcms;
                    }
                    this.idRamoAtividade = OrcamentoFacade.objCadastros.objCliente.idRamoAtividade;

                    this.idFuncionarioRepresentante = OrcamentoFacade.objCadastros.objCliente.idFuncionario ?? 0;
                    foreach (Orcamento_ItemModel item in this.lOrcamento_Itens)
                    {
                        item.idFuncionarioRepresentante = this._idFuncionarioRepresentante;
                    }

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
                                OrcamentoFacade.objCadastros.idEstadoCliente = objCidade.idUF;
                                this.xCidade = objCidade != null ? objCidade.xCidade : "";
                                this.xUf = OrcamentoFacade.ufService.getUf(idUf: objCidade.idUF).xSiglaUf;
                                OrcamentoFacade.objCadastros.objCargaTrib = OrcamentoFacade.cargaTribMediaService.GetCarga_trib_media_st_icmsByUf(
                                    idUf: OrcamentoFacade.objCadastros.idEstadoCliente);
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

                    foreach (var item in this.lOrcamento_Itens)
                    {
                        item.idCfop = OrcamentoFacade.GetIdCfop(idTipoOpercacao: item.idTipoOperacao);
                        base.NotifyPropertyChanged(propertyName: "idCfop");
                        item.idTipoOperacao = item.idTipoOperacao;
                        item.objImposto.ICMS_pCargaTributariaMedia = OrcamentoFacade.objCadastros.objCargaTrib.pCargaTributariaMedia;
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

                if (value != 0)
                    OrcamentoFacade.objCadastros.objCondicaoPagamento = OrcamentoFacade.condicaoPagamentoService.getCondicao_pagamento(
                        idCondicao_pagamento: value);
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
                if (value != 0)
                {
                    var obj = OrcamentoFacade.funcionarioService.getFuncionario(
                            idFuncionario: value);
                    OrcamentoFacade.objCadastros.objFuncionario = obj;
                }
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

                if (value > 0)
                    foreach (var item in this._lOrcamento_Itens)
                    {
                        item.lTipoOperacao = OrcamentoFacade.GetAllValuesToComboBox(sNameView: "getTipoOperacaoValidaToComboBoxOrcamento", sParameter: value.ToString());
                    }

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

        private ObservableCollectionBaseCadastros<Orcamento_Item_ImpostosModel> _lOrcamento_Item_Impostos;

        public ObservableCollectionBaseCadastros<Orcamento_Item_ImpostosModel> lOrcamento_Item_Impostos
        {
            get
            {
                return _lOrcamento_Item_Impostos;
            }
            set
            {
                _lOrcamento_Item_Impostos = value;
                base.NotifyPropertyChanged(propertyName: "lOrcamento_Item_Impostos");
            }
        }
    }

    public partial class Orcamento_ItemModel : modelBase, ICloneable
    {
        public Orcamento_ItemModel()
            : base(xTabela: "Orcamento_Item")
        {
            if (OrcamentoFacade.objCadastros != null)
                if (OrcamentoFacade.objCadastros.objCliente != null)
                {
                    this.idListaPrecoPai = OrcamentoFacade.objCadastros.objCliente.idListaPrecoPai;

                    this.idFuncionarioRepresentante = OrcamentoFacade.objCadastros.objCliente != null
                        ? OrcamentoFacade.objCadastros.objCliente.idFuncionario ?? 0 : 0;

                    if (OrcamentoFacade.objCadastros.objEmpresa != null)
                    {
                        if (OrcamentoFacade.objCadastros.objEmpresa.lEmpresa_endereco.Count() > 0)
                        {
                            if (OrcamentoFacade.objCadastros.objEmpresa.lEmpresa_endereco.Count(i => i.stPrincipal == 0) > 0)
                            {
                                OrcamentoFacade.objCadastros.idEstadoEmpresa = OrcamentoFacade.cidadeService.getCidade(idCidade:
                                    OrcamentoFacade.objCadastros.objEmpresa.lEmpresa_endereco.FirstOrDefault(
                                    i => i.stPrincipal == 0).idCidade).idUF;
                            }
                            else
                            {
                                OrcamentoFacade.objCadastros.idEstadoEmpresa = OrcamentoFacade.cidadeService.getCidade(idCidade:
                                    OrcamentoFacade.objCadastros.objEmpresa.lEmpresa_endereco.FirstOrDefault()
                                    .idCidade).idUF;
                            }
                        }
                    }
                    base.NotifyPropertyChanged(propertyName: "idListaPrecoPai");
                    base.NotifyPropertyChanged(propertyName: "idFuncionarioRepresentante");
                }

            this.lTipoOperacao = OrcamentoFacade.GetAllValuesToComboBox(sNameView: "getTipoOperacaoValidaToComboBoxOrcamento", sParameter: "2");
            this.objImposto = new Orcamento_Item_ImpostosModel();

        }

        #region Métodos de Cálculos

        #endregion

        #region Métodos de busca


        #endregion

        #region Propriedades não mapeadas

        public bool stServico { get; set; }



        public bool bPermitePorcentagem { get; set; }

        private ObservableCollection<HLP.Comum.Facade.FillComboBoxService.modelToComboBox> _lUnMedida;

        public ObservableCollection<HLP.Comum.Facade.FillComboBoxService.modelToComboBox> lUnMedida
        {
            get { return _lUnMedida; }
            set
            {
                _lUnMedida = value;
                base.NotifyPropertyChanged(propertyName: "lUnMedida");
            }
        }

        private ObservableCollection<HLP.Comum.Facade.FillComboBoxService.modelToComboBox> _lTipoOperacao;

        public ObservableCollection<HLP.Comum.Facade.FillComboBoxService.modelToComboBox> lTipoOperacao
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
                        this.lUnMedida = OrcamentoFacade.GetAllValuesToComboBox(sNameView: "getUnidadeMedidaToComboBox", sParameter: value.ToString());

                        HLP.Comum.Facade.produtoService.ProdutoModel objProduto = OrcamentoFacade.produtoService.getProduto(idProduto: value);
                        HLP.Comum.Facade.Tipo_OperacaoService.Tipo_operacaoModel objTipoOperacao =
                            OrcamentoFacade.objCadastros.lTipoOperacao.FirstOrDefault(i => i.idTipoOperacao == this.idTipoOperacao);

                        if (OrcamentoFacade.objCadastros.lProdutos.Count(i => i.idProduto == objProduto.idProduto) < 1)
                            OrcamentoFacade.objCadastros.lProdutos.Add(item: objProduto);

                        if (objTipoOperacao != null)
                            if (objTipoOperacao.idClassificacaoFiscal == 0
                                && objProduto != null)
                            {
                                if (this.objImposto != null)
                                    this.objImposto.idClassificacaoFiscal = objProduto.idClassificacaoFiscalVenda ?? 0;
                                base.NotifyPropertyChanged(propertyName: "idClassificacaoFiscal");
                            }

                        if (objProduto != null)
                            if (objProduto.idClassificacaoFiscalVenda != null &&
                                objProduto.idClassificacaoFiscalVenda != 0)
                            {
                                if (this.objImposto != null)
                                    this.objImposto.IPI_pIPI = OrcamentoFacade.classificFiscalService.GetObjeto(
                                        idObjeto: (int)objProduto.idClassificacaoFiscalVenda).pIPI;
                            }
                            else
                            {
                                if (this.objImposto != null)
                                    if (objTipoOperacao != null)
                                        this.objImposto.IPI_pIPI = objTipoOperacao.pIpi;
                            }
                        else
                            if (this.objImposto != null)
                                if (objTipoOperacao != null)
                                    this.objImposto.IPI_pIPI = objTipoOperacao.pIpi;
                        base.NotifyPropertyChanged(propertyName: "pIpi");

                        HLP.Comum.Facade.Familia_ProdutoService.Familia_produtoModel objFamiliaProduto =
                            OrcamentoFacade.familiaProdutoService.GetObject(idFamiliaProduto: objProduto.idFamiliaProduto);

                        this.xComercial = objProduto.xComercial;
                        this.nPesoBruto = objProduto.nPesoBruto;
                        this.nPesoLiquido = objProduto.nPesoLiquido;
                        if (objProduto.idFamiliaProduto != 0 && objProduto.idFamiliaProduto != null)
                        {
                            this.bXComercialEnabled = (objFamiliaProduto != null ?
                                objFamiliaProduto.stAlteraDescricaoComercialProdutoVenda : 0)
                                == 1;
                        }

                        #region icms

                        if (objTipoOperacao != null)
                        {
                            if (objTipoOperacao.idCodigoIcmsPai == 0)
                                if (this.objImposto != null)
                                    this.objImposto.idCodigoIcmsPai = OrcamentoFacade.objCadastros.lProdutos.FirstOrDefault(
                                        i => i.idProduto == this.idProduto).idCodigoIcmsPaiVenda ?? 0;

                            if (objTipoOperacao.idCSTIcms == 0)
                                if (this.objImposto != null)
                                    this.objImposto.idCSTIcms = OrcamentoFacade.objCadastros.lProdutos.FirstOrDefault(
                                        i => i.idProduto == this.idProduto).idCSTIcms ?? 0;

                            if (this.objImposto != null)
                                this.objImposto.ICMS_stCompoeBaseCalculo =
                                    objTipoOperacao.stCompoeBaseIcms;
                        }

                        #endregion

                        HLP.Comum.Facade.Lista_PrecoService.Lista_precoModel objListaPrecoItem = null;

                        if (OrcamentoFacade.objCadastros.objListaPreco.lLista_preco != null)
                        {
                            objListaPrecoItem = OrcamentoFacade.objCadastros.objListaPreco.lLista_preco
                            .FirstOrDefault(i => i.idProduto == value);
                        }



                        if (objListaPrecoItem != null)
                        {
                            if (Sistema.stSender == TipoSender.WCF)
                            {
                                this.vVendaSemDesconto = this.vVenda = objListaPrecoItem.vVenda;
                                base.NotifyPropertyChanged(propertyName: "vVenda");
                                base.NotifyPropertyChanged(propertyName: "vVendaSemDesconto");
                            }
                        }

                        #region Comissão
                        switch (OrcamentoFacade.objCadastros.objFuncionario.stComissao)
                        {
                            case 0:
                                {
                                    switch (OrcamentoFacade.objCadastros.objCondicaoPagamento.stCondicao)
                                    {
                                        case 0:
                                            {
                                                this.pComissao = OrcamentoFacade.objCadastros.objFuncionario.pComissaoAvista;
                                            } break;
                                        case 1:
                                            {
                                                this.pComissao = OrcamentoFacade.objCadastros.objFuncionario.pComissaoAprazo;
                                                break;
                                            }
                                    }
                                }; break;
                            case 1:
                                {
                                    if (OrcamentoFacade.objCadastros.objListaPreco.lLista_preco.Count(i => i.idProduto == this._idProduto) < 1)
                                    {
                                        this.pComissao = 0;
                                        break;
                                    }

                                    switch (OrcamentoFacade.objCadastros.objCondicaoPagamento.stCondicao)
                                    {
                                        case 0:
                                            {
                                                this.pComissao =
                                                    OrcamentoFacade.objCadastros.objListaPreco.lLista_preco.FirstOrDefault(i => i.idProduto == this._idProduto).pComissaoAvista;
                                            } break;
                                        case 1:
                                            {
                                                this.pComissao =
                                                    OrcamentoFacade.objCadastros.objListaPreco.lLista_preco.FirstOrDefault(i => i.idProduto == this._idProduto).pComissaoAprazo;
                                            } break;
                                    }
                                }; break;
                            case 2:
                                {
                                    if (objFamiliaProduto == null)
                                    {
                                        this.pComissao = 0;
                                        break;
                                    }
                                    switch (OrcamentoFacade.objCadastros.objCondicaoPagamento.stCondicao)
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
                                }; break;
                            case 3:
                                {
                                    if (OrcamentoFacade.objCadastros.objFuncionario.lFuncionario_Comissao_Produto.Count(i => i.idProduto == this._idProduto) < 1)
                                    {
                                        this.pComissao = 0;
                                        break;
                                    }

                                    switch (OrcamentoFacade.objCadastros.objCondicaoPagamento.stCondicao)
                                    {
                                        case 0:
                                            {
                                                this.pComissao = OrcamentoFacade.objCadastros.objFuncionario.lFuncionario_Comissao_Produto
                                                    .FirstOrDefault(i => i.idProduto == this._idProduto).pComissaoAvista;
                                            } break;
                                        case 1:
                                            {
                                                this.pComissao = OrcamentoFacade.objCadastros.objFuncionario.lFuncionario_Comissao_Produto
                                                    .FirstOrDefault(i => i.idProduto == this._idProduto).pComissaoAprazo;
                                            } break;
                                    }
                                }; break;
                            case 4:
                                {
                                    decimal custoProduto = OrcamentoFacade.objCadastros.lProdutos.Count(i => i.idProduto == this._idProduto) < 1 ?
                                        0 : OrcamentoFacade.objCadastros.lProdutos.First(i => i.idProduto == this._idProduto).vCompra;

                                    decimal margemLucro = (this._vVenda - custoProduto) / custoProduto;

                                    HLP.Comum.Facade.funcionarioService.Funcionario_Margem_Lucro_ComissaoModel objFuncionarioMargemLucro =
                                        OrcamentoFacade.objCadastros.objFuncionario.lFuncionario_Margem_Lucro_Comissao.FirstOrDefault(
                                         i => i.pDeMargemVenda >= margemLucro && i.pAteMargemVenda <= margemLucro);

                                    if (objFuncionarioMargemLucro == null)
                                    {
                                        this.pComissao = 0;
                                        break;
                                    }

                                    switch (OrcamentoFacade.objCadastros.objCondicaoPagamento.stCondicao)
                                    {
                                        case 0:
                                            {
                                                this.pComissao = objFuncionarioMargemLucro.pComissaoAvista;
                                            } break;
                                        case 1:
                                            {
                                                this.pComissao = objFuncionarioMargemLucro.pComissaoAprazo;
                                            } break;
                                    }
                                }; break;
                        }
                        #endregion
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

                if (value != 0)
                {
                    HLP.Comum.Facade.Tipo_OperacaoService.Tipo_operacaoModel objTipoOperacao =
                                OrcamentoFacade.tipoOperacaoService.GetObjeto(idObjeto: value);

                    if (OrcamentoFacade.objCadastros.lTipoOperacao.Count(i => i.idTipoOperacao == objTipoOperacao.idTipoOperacao) == 0)
                        OrcamentoFacade.objCadastros.lTipoOperacao.Add(item: objTipoOperacao);

                    if (OrcamentoFacade.objCadastros.lTipoOperacao.FirstOrDefault(i => i.idTipoOperacao == this.idTipoOperacao).idClassificacaoFiscal != 0)
                    {
                        this.objImposto.idClassificacaoFiscal = OrcamentoFacade.objCadastros.lTipoOperacao.FirstOrDefault(i => i.idTipoOperacao == this.idTipoOperacao).idClassificacaoFiscal;
                        base.NotifyPropertyChanged(propertyName: "idClassificacaoFiscal");
                    }

                    this.stServico = objTipoOperacao.stServico == 0 ? false : true;

                    this.objImposto.IPI_stCalculaIpi = OrcamentoFacade.objCadastros.objCliente.cliente_fornecedor_fiscal.stCalculaIpi == (byte)0 ?
                        (byte)0 : OrcamentoFacade.objCadastros.lTipoOperacao.FirstOrDefault(i => i.idTipoOperacao == this.idTipoOperacao).stCalculaIpi;

                    HLP.Comum.Facade.produtoService.ProdutoModel objProduto =
                        OrcamentoFacade.objCadastros.lProdutos.FirstOrDefault(i => i.idProduto == this.idProduto);
                    if (objProduto != null)
                        if (objProduto.idClassificacaoFiscalVenda != null &&
                            objProduto.idClassificacaoFiscalVenda != 0)
                        {
                            this.objImposto.IPI_pIPI = OrcamentoFacade.classificFiscalService.GetObjeto(
                                idObjeto: (int)objProduto.idClassificacaoFiscalVenda).pIPI;
                        }
                        else
                        {
                            this.objImposto.IPI_pIPI = OrcamentoFacade.objCadastros.lTipoOperacao.FirstOrDefault(i => i.idTipoOperacao == this.idTipoOperacao).pIpi;
                        }
                    else
                        this.objImposto.IPI_pIPI = OrcamentoFacade.objCadastros.lTipoOperacao.FirstOrDefault(i => i.idTipoOperacao == this.idTipoOperacao).pIpi;
                    base.NotifyPropertyChanged(propertyName: "pIpi");

                    this.objImposto.IPI_stCompoeBaseCalculo = OrcamentoFacade.objCadastros.lTipoOperacao.FirstOrDefault(i => i.idTipoOperacao == this.idTipoOperacao).stCompoeBaseIpi;
                    this.objImposto.idCSTIpi = OrcamentoFacade.objCadastros.lTipoOperacao.FirstOrDefault(i => i.idTipoOperacao == this.idTipoOperacao).idCSTIpi;


                    #region Icms
                    this.objImposto.idCodigoIcmsPai =
                        OrcamentoFacade.objCadastros.lTipoOperacao.FirstOrDefault(i => i.idTipoOperacao == this.idTipoOperacao).idCodigoIcmsPai;
                    this.objImposto.ICMS_stCalculaSubstituicaoTributaria = OrcamentoFacade.objCadastros.lTipoOperacao.FirstOrDefault(i => i.idTipoOperacao == this.idTipoOperacao).stCalculaIcmsSubstituicaoTributaria;
                    this.objImposto.ICMS_stReduzBaseCalculo =
                            OrcamentoFacade.objCadastros.lTipoOperacao.FirstOrDefault(i => i.idTipoOperacao == this.idTipoOperacao).stReduzBase;
                    this.objImposto.ICMS_stNaoReduzBase =
                        OrcamentoFacade.objCadastros.lTipoOperacao.FirstOrDefault(i => i.idTipoOperacao == this.idTipoOperacao).stNaoReduzBase;
                    this.objImposto.ICMS_stCalculaIcms = OrcamentoFacade.objCadastros.objCliente.cliente_fornecedor_fiscal.stCalculaIcms
                        == 0 ? (byte)0 :
                        OrcamentoFacade.objCadastros.lTipoOperacao.FirstOrDefault(i => i.idTipoOperacao == this.idTipoOperacao).stCalculaIcms;
                    this.objImposto.idCSTIcms = OrcamentoFacade.objCadastros.lTipoOperacao.FirstOrDefault(i => i.idTipoOperacao == this.idTipoOperacao).idCSTIcms;

                    HLP.Comum.Facade.Tipo_OperacaoService.Operacao_reducao_baseModel objReducao =
                                OrcamentoFacade.objCadastros.lTipoOperacao.FirstOrDefault(i => i.idTipoOperacao == this.idTipoOperacao).lOperacaoReducaoBase.
                                FirstOrDefault(i => i.idUf == OrcamentoFacade.objCadastros.idEstadoEmpresa);

                    if (objReducao != null)
                        this.objImposto.ICMS_pReduzBase = objReducao.pReducaoIcms;
                    else
                        this.objImposto.ICMS_pReduzBase = 0;

                    this.objImposto.ICMS_stCompoeBaseCalculo = OrcamentoFacade.objCadastros.lTipoOperacao.FirstOrDefault(i => i.idTipoOperacao == this.idTipoOperacao).stCompoeBaseIcms;
                    #endregion

                    #region Icms Substituição Tributária

                    this.objImposto.ICMS_stCompoeBaseCalculoSubstituicaoTributaria =
                         OrcamentoFacade.objCadastros.lTipoOperacao.FirstOrDefault(i => i.idTipoOperacao == this.idTipoOperacao).stCompoeBaseIcmsSubstituicaoTributaria;
                    if (Sistema.stSender == TipoSender.WCF)
                    {
                        this.objImposto.CalculaBaseIcmsSubstTrib();
                    }

                    #endregion

                    #region PIS/COFINS

                    this.objImposto.stCalculaPisCofins = OrcamentoFacade.objCadastros.lTipoOperacao.FirstOrDefault(i => i.idTipoOperacao == this.idTipoOperacao).stCalculaPisCofins;
                    this.objImposto.stRegimeTributacaoPisCofins = OrcamentoFacade.objCadastros.lTipoOperacao.FirstOrDefault(i => i.idTipoOperacao == this.idTipoOperacao).stRegimeTributacaoPisCofins;
                    this.objImposto.PIS_nCoeficienteSubstituicaoTributaria = OrcamentoFacade.objCadastros.lTipoOperacao.FirstOrDefault(i => i.idTipoOperacao == this.idTipoOperacao).nCoeficienteSubstituicaoTributariaPis;
                    this.objImposto.COFINS_nCoeficienteSubstituicaoTributaria = OrcamentoFacade.objCadastros.lTipoOperacao.FirstOrDefault(i => i.idTipoOperacao == this.idTipoOperacao).nCoeficienteSubstituicaoTributariaCofins;
                    this.objImposto.PIS_pPIS = OrcamentoFacade.objCadastros.lTipoOperacao.FirstOrDefault(i => i.idTipoOperacao == this.idTipoOperacao).pPis;
                    this.objImposto.COFINS_pCOFINS = OrcamentoFacade.objCadastros.lTipoOperacao.FirstOrDefault(i => i.idTipoOperacao == this.idTipoOperacao).pCofins;
                    this.objImposto.idCSTPis = OrcamentoFacade.objCadastros.lTipoOperacao.FirstOrDefault(i => i.idTipoOperacao == this.idTipoOperacao).idCSTPis;
                    this.objImposto.idCSTCofins = OrcamentoFacade.objCadastros.lTipoOperacao.FirstOrDefault(i => i.idTipoOperacao == this.idTipoOperacao).idCSTCofins;
                    this.objImposto.stCompoeBaseCalculoPisCofins = OrcamentoFacade.objCadastros.lTipoOperacao.FirstOrDefault(i => i.idTipoOperacao == this.idTipoOperacao).stCompoeBaseNormalPiscofins;
                    this.objImposto.PIS_stCompoeBaseCalculoSubstituicaoTributaria = OrcamentoFacade.objCadastros.lTipoOperacao.FirstOrDefault(i => i.idTipoOperacao == this.idTipoOperacao).stCompoeBaseSubtTribPis;
                    this.objImposto.COFINS_stCompoeBaseCalculoSubstituicaoTributaria = OrcamentoFacade.objCadastros.lTipoOperacao.FirstOrDefault(i => i.idTipoOperacao == this.idTipoOperacao).stCompoeBaseSubtTribCofins;

                    #endregion

                    #region Iss

                    this.objImposto.ISS_stCalculaIss = OrcamentoFacade.objCadastros.lTipoOperacao.FirstOrDefault(i => i.idTipoOperacao == this.idTipoOperacao).stCalculaIss;
                    this.objImposto.ISS_pIss = OrcamentoFacade.objCadastros.lTipoOperacao.FirstOrDefault(i => i.idTipoOperacao == this.idTipoOperacao).pIss;

                    #endregion
                }

                base.NotifyPropertyChanged(propertyName: "idCfop");
                this.idCfop = OrcamentoFacade.GetIdCfop(idTipoOpercacao: value);

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
                this._vTotalSemDescontoItem = this._vVendaSemDesconto * this._qProduto;
                base.NotifyPropertyChanged(propertyName: "vVendaSemDesconto");
                base.NotifyPropertyChanged(propertyName: "vTotalSemDescontoItem");
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
                this.vTotalItem = (this._vVenda + this._vDesconto) * this._qProduto;
                base.NotifyPropertyChanged(propertyName: "vVenda");
                base.NotifyPropertyChanged(propertyName: "vTotalItem");
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
                this._vTotalSemDescontoItem = this._qProduto * this._vVendaSemDesconto;
                this.vTotalItem = this._qProduto * (this._vVenda + this._vDesconto);
                base.NotifyPropertyChanged(propertyName: "vTotalSemDescontoItem");
                base.NotifyPropertyChanged(propertyName: "vTotalItem");
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
                if (Sistema.stSender != TipoSender.WCF)
                {
                    decimal vDesconto = this._vVenda * (value / 100);
                    this.vTotalItem = (this._vVenda + (vDesconto)) * this._qProduto;
                    this._vDesconto = vDesconto;
                }
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
                if (Sistema.stSender != TipoSender.WCF)
                {
                    if (this._vVenda != 0)
                        this._pDesconto = (value / this._vVenda) * 100;

                    this.vTotalItem = (this._vVenda + value) * this._qProduto;
                }
                _vDesconto = value;
                base.NotifyPropertyChanged(propertyName: "vDesconto");
                base.NotifyPropertyChanged(propertyName: "pDesconto");
                base.NotifyPropertyChanged(propertyName: "vVenda");
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
                if (this.status != statusModel.nenhum ||
                    (this.status == statusModel.nenhum && value > 0))
                    _vTotalItem = value;
                base.NotifyPropertyChanged(propertyName: "vTotalItem");
                this.objImposto.vTotalItem = value;

                if (Sistema.stSender == TipoSender.WCF)
                {
                    if (OrcamentoFacade.objCadastros.objCliente.cliente_fornecedor_fiscal != null)
                    {
                        if (OrcamentoFacade.objCadastros.objCliente.cliente_fornecedor_fiscal.stDescontaIcmsSuframa == 1)
                        {
                            this.vDescontoSuframa = this._vTotalItem *
                                OrcamentoFacade.objCadastros.objCliente.cliente_fornecedor_fiscal.pDescontaIcmsSuframa;
                        }
                    }
                    this.objImposto.CalculaBaseIpi();
                    this.objImposto.CalculaBaseIcms();
                    this.objImposto.CalculaBaseIcmsSubstTrib();
                    this.objImposto.CalculaBaseIcmsProprio();
                    this.objImposto.CalculaBasePis();
                    this.objImposto.CalculaBaseCofins();
                    this.objImposto.ISS_vBaseCalculo = value;
                }
            }
        }
        private decimal _vFreteItem;
        [ParameterOrder(Order = 22)]
        public decimal vFreteItem
        {
            get { return _vFreteItem; }
            set
            {
                if (this.status != statusModel.nenhum ||
                    (this.status == statusModel.nenhum && value > 0))
                    _vFreteItem = value;

                if (Sistema.stSender == TipoSender.WCF)
                {
                    _vFreteItem = value;
                    this.objImposto.vFreteItem = value;
                    this.objImposto.CalculaBaseIpi();
                    this.objImposto.CalculaBaseIcms();
                    this.objImposto.CalculaBaseIcmsProprio();
                    this.objImposto.CalculaBasePis();
                    this.objImposto.CalculaBaseCofins();
                }
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
                _stOrcamentoItem = this.objImposto.stOrcamentoImpostos = value;
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
                if (this.status != statusModel.nenhum ||
                    (this.status == statusModel.nenhum && value > 0))
                    _vSegurosItem = value;


                if (Sistema.stSender == TipoSender.WCF)
                {
                    this.objImposto.vSeguroItem = value;
                    this.objImposto.CalculaBaseIpi();
                    this.objImposto.CalculaBaseIcms();
                    this.objImposto.CalculaBaseIcmsProprio();
                    this.objImposto.CalculaBasePis();
                    this.objImposto.CalculaBaseCofins();
                }
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
                if (this.status != statusModel.nenhum ||
                    (this.status == statusModel.nenhum && value > 0))
                    _vOutrasDespesasItem = value;

                if (Sistema.stSender == TipoSender.WCF)
                {
                    this.objImposto.vOutrasDespesasItem = value;
                    this.objImposto.CalculaBaseIpi();
                    this.objImposto.CalculaBaseIcms();
                    this.objImposto.CalculaBaseIcmsProprio();
                    this.objImposto.CalculaBasePis();
                    this.objImposto.CalculaBaseCofins();
                }

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

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    public partial class Orcamento_Item_ImpostosModel : modelBase, ICloneable
    {
        public void CalculaBaseIpi()
        {
            this.IPI_vBaseCalculo = ImpostosFacade.CalculaBaseIpi(IPI_stCompoeBaseCalculo: this._IPI_stCompoeBaseCalculo, vTotalItem: this.vTotalItem,
                vFreteItem: this.vFreteItem, vSegurosItem: this.vSeguroItem, vOutrasDespesasItem: this.vOutrasDespesasItem);
        }

        public void CalculaBaseIcms()
        {
            this.ICMS_vBaseCalculo = ImpostosFacade.CalculaBaseIcms(ICMS_stCalculaSubstituicaoTributaria: this._ICMS_stCalculaSubstituicaoTributaria,
                ICMS_stCompoeBaseCalculo: this._ICMS_stCompoeBaseCalculo, _vTotalItem: this.vTotalItem, IPI_vIPI: this._IPI_vIPI,
                _vFreteItem: this.vFreteItem, _vSegurosItem: this.vSeguroItem, _vOutrasDespesasItem: this.vOutrasDespesasItem,
                ICMS_stReduzBaseCalculo: this._ICMS_stReduzBaseCalculo, ICMS_pReduzBase: _ICMS_pReduzBase);
        }

        public void CalculaBaseIcmsProprio()
        {
            this.ICMS_vBaseCalculoIcmsProprio = ImpostosFacade.CalculaBaseIcmsProprio(ICMS_stCalculaSubstituicaoTributaria: this.ICMS_stCalculaSubstituicaoTributaria,
                ICMS_stCompoeBaseCalculo: this.ICMS_stCompoeBaseCalculo, vTotalItem: this.vTotalItem, PIS_vPIS: this.PIS_vPIS, vFreteItem: this.vFreteItem,
                vSegurosItem: this.vSeguroItem, vOutrasDespesasItem: this.vOutrasDespesasItem, ICMS_stReduzBaseCalculo: this.ICMS_stReduzBaseCalculo, ICMS_pReduzBase: this.ICMS_pReduzBase);
        }

        public void CalculaBaseIcmsSubstTrib()
        {
            byte stSubstituicaoTributariaDifer = 0;
            byte stConsumidorFinal = 0;
            byte stContribuinteIcms = 0;

            if (OrcamentoFacade.objCadastros.objCliente != null)
                if (OrcamentoFacade.objCadastros.objCliente.cliente_fornecedor_fiscal != null)
                {
                    stSubstituicaoTributariaDifer = OrcamentoFacade.objCadastros.objCliente.cliente_fornecedor_fiscal.stSubsticaoTributariaIcmsDiferenciada;
                    stConsumidorFinal = OrcamentoFacade.objCadastros.objCliente.cliente_fornecedor_fiscal.stConsumidorFinal;
                    stContribuinteIcms = OrcamentoFacade.objCadastros.objCliente.cliente_fornecedor_fiscal.stContribuienteIcms;
                }
            this.ICMS_vBaseCalculoSubstituicaoTributaria = ImpostosFacade.CalculaBaseIcmsSubstTrib(stSubsticaoTributariaIcmsDiferenciada: stSubstituicaoTributariaDifer,
                ICMS_stCompoeBaseCalculoSubstituicaoTributaria: this._ICMS_stCompoeBaseCalculoSubstituicaoTributaria, _stConsumidorFinal: stConsumidorFinal,
                stContribuinteIcms: stContribuinteIcms, _vTotalItem: this.vTotalItem, ICMS_pMvaSubstituicaoTributaria: this.ICMS_pMvaSubstituicaoTributaria,
                IPI_vIPI: this._IPI_vIPI, _vFreteItem: this.vFreteItem, _vSegurosItem: this.vSeguroItem, _vOutrasDespesasItem: this.vOutrasDespesasItem,
                ICMS_pIcmsInterno: this._ICMS_pIcmsInterno, ICMS_vIcmsProprio: this._ICMS_vIcmsProprio, ICMS_vSubstituicaoTributaria: this._ICMS_vSubstituicaoTributaria,
                ICMS_stReduzBaseCalculo: this._ICMS_stReduzBaseCalculo, pReduzBaseSubstituicaoTributaria: this._ICMS_pReduzBaseSubstituicaoTributaria);
            this.CalculaVlrSubstTrib();
        }

        public void CalculaVlrSubstTrib()
        {
            byte stSubstituicaoTributariaDifer = 0;
            byte stConsumidorFinal = 0;
            byte stContribuinteIcms = 0;
            byte stIcmsSubstDif = 0;

            string xUf = "";
            object o = CompanyData.parametros_FiscalEmpresa;

            if (o != null)
                stIcmsSubstDif = (byte)CompanyData.parametros_FiscalEmpresa.GetType().GetProperty("stIcmsSubstDif").GetValue(CompanyData.parametros_FiscalEmpresa);

            if (OrcamentoFacade.objCadastros.idEstadoCliente != 0)
            {
                HLP.Comum.Facade.ufService.UFModel objUf = OrcamentoFacade.ufService.getUf(idUf: OrcamentoFacade.objCadastros.idEstadoCliente);
                xUf = objUf != null ? objUf.xUf : "";
            }

            if (OrcamentoFacade.objCadastros.objCliente != null)
                if (OrcamentoFacade.objCadastros.objCliente.cliente_fornecedor_fiscal != null)
                {
                    stSubstituicaoTributariaDifer = OrcamentoFacade.objCadastros.objCliente.cliente_fornecedor_fiscal.stSubsticaoTributariaIcmsDiferenciada;
                    stConsumidorFinal = OrcamentoFacade.objCadastros.objCliente.cliente_fornecedor_fiscal.stConsumidorFinal;
                    stContribuinteIcms = OrcamentoFacade.objCadastros.objCliente.cliente_fornecedor_fiscal.stContribuienteIcms;
                }

            stSubstituicaoTributariaDifer = OrcamentoFacade.objCadastros.objCliente.cliente_fornecedor_fiscal.stSubsticaoTributariaIcmsDiferenciada;
            this.ICMS_vSubstituicaoTributaria = ImpostosFacade.CalcularVlrSubstTrib(stSubsticaoTributariaIcmsDiferenciada: stSubstituicaoTributariaDifer,
                ICMS_stCalculaSubstituicaoTributaria: this.ICMS_stCalculaSubstituicaoTributaria, stConsumidorFinal: stConsumidorFinal,
                stContribuinteIcms: stContribuinteIcms, xRamo: OrcamentoFacade.objCadastros.objRamoAtividade.xRamo, idEstadoCliente: OrcamentoFacade.objCadastros.idEstadoCliente,
                idEstadoEmpresa: OrcamentoFacade.objCadastros.idEstadoEmpresa, ICMS_vBaseCalculoSubstituicaoTributaria: this.ICMS_vBaseCalculoSubstituicaoTributaria,
                ICMS_pICMS: this.ICMS_pICMS, ICMS_pIcmsInterno: this.ICMS_pIcmsInterno, xSiglaUf: xUf, ICMS_stCalculaIcms: this._ICMS_stCalculaIcms,
                parametros_FiscalEmpresa: stIcmsSubstDif,
                ICMS_vICMS: this._ICMS_vICMS ?? 0);
        }

        public void CalculaBasePis()
        {
            this.PIS_vBaseCalculo = ImpostosFacade.CalcularVlrBasePis(stCalculaPisCofins: this._stCalculaPisCofins, stCompoeBaseCalculoPisCofins: this._stCompoeBaseCalculoPisCofins,
                _vTotalItem: this.vTotalItem, IPI_vIPI: this._IPI_vIPI, _vFreteItem: this.vFreteItem, _vSegurosItem: this.vSeguroItem, _vOutrasDespesasItem: this.vOutrasDespesasItem,
                PIS_stCompoeBaseCalculoSubstituicaoTributaria: this._PIS_stCompoeBaseCalculoSubstituicaoTributaria);
        }

        public void CalculaBaseCofins()
        {
            this.COFINS_vBaseCalculo = ImpostosFacade.CalcularVlrBaseCofins(stCalculaPisCofins: this._stCalculaPisCofins, stCompoeBaseCalculoPisCofins: this.stCompoeBaseCalculoPisCofins,
                COFINS_stCompoeBaseCalculoSubstituicaoTributaria: (this.COFINS_stCompoeBaseCalculoSubstituicaoTributaria ?? 0),
                _vTotalItem: this.vTotalItem, IPI_vIPI: this._IPI_vIPI,
                _vFreteItem: this.vFreteItem, _vSegurosItem: this.vSeguroItem, _vOutrasDespesasItem: this.vOutrasDespesasItem);
        }

        public Orcamento_Item_ImpostosModel()
            : base(xTabela: "Orcamento_Item_Impostos")
        {
        }

        #region Propriedades não Mapeadas

        public decimal vTotalItem { get; set; }

        public decimal vFreteItem { get; set; }

        public decimal vSeguroItem { get; set; }

        public decimal vOutrasDespesasItem { get; set; }

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

        private stOrigem _enumstOrigem;
        public stOrigem enumstOrigem
        {
            get { return _enumstOrigem; }
            set
            {
                _enumstOrigem = value;
                _ICMS_stOrigemMercadoria = (byte)value;
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
                _enumstOrigem = (stOrigem)value;
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
                this.ICMS_vICMS = value * (this.ICMS_pICMS / 100);
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
                this.ICMS_vICMS = this.ICMS_vBaseCalculo * (value / 100);
                this.ICMS_vIcmsProprio = this._ICMS_vBaseCalculoIcmsProprio * (value / 100);
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

                if (OrcamentoFacade.objCadastros.objCliente.cliente_fornecedor_fiscal.stCalculaIcms == 0 ||
                    OrcamentoFacade.objCadastros.objCliente.cliente_fornecedor_fiscal.stZeraIcms == 1)
                    this._ICMS_stCompoeBaseCalculo = 4;

                if (Sistema.stSender == TipoSender.WCF)
                {
                    this.CalculaBaseIcms();
                    this.CalculaBaseIcmsProprio();
                }

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
                this.ICMS_vIcmsProprio = value * (this.ICMS_pICMS / 100);
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

                if (value == 1)
                {
                    HLP.Comum.Facade.CodigoIcmsService.Codigo_Icms_paiModel icmsModel =
                        OrcamentoFacade.icmsService.GetObjeto(idObjeto: this.idCodigoIcmsPai);


                    if (icmsModel != null)
                        if (icmsModel.lCodigo_IcmsModel.Count(i => i.idUf == OrcamentoFacade.objCadastros.idEstadoCliente) > 0)
                            this.ICMS_pMvaSubstituicaoTributaria = icmsModel.lCodigo_IcmsModel.FirstOrDefault(
                                i => i.idUf == OrcamentoFacade.objCadastros.idEstadoCliente).pMvaSubstituicaoTributaria;
                }
                else
                {
                    this.ICMS_pMvaSubstituicaoTributaria = decimal.Zero;
                }

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
                if (value != 0)
                {
                    HLP.Comum.Facade.CodigoIcmsService.Codigo_IcmsModel objIcms =
                                OrcamentoFacade.icmsService.GetObjeto(idObjeto: value).
                                lCodigo_IcmsModel.FirstOrDefault(i => i.idUf == OrcamentoFacade.objCadastros.idEstadoCliente);
                    if (OrcamentoFacade.objCadastros.objCliente.cliente_fornecedor_fiscal.stZeraIcms == 0)
                    {
                        if (this.ICMS_stCalculaIcms == 1)
                        {
                            if (objIcms != null)
                                this.ICMS_pICMS = objIcms.pIcmsEstado;
                        }
                        else
                            this.ICMS_pICMS = decimal.Zero;
                    }
                    else
                        this.ICMS_pICMS = decimal.Zero;

                    if (this.ICMS_stCalculaSubstituicaoTributaria == 1)
                        if (objIcms != null)
                            this.ICMS_pIcmsInterno = this.ICMS_pMvaSubstituicaoTributaria = objIcms.pMvaSubstituicaoTributaria;
                        else
                            this.ICMS_pIcmsInterno = this.ICMS_pMvaSubstituicaoTributaria = decimal.Zero;
                }
                base.NotifyPropertyChanged(propertyName: "ICMS_pICMS");
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
                if (this.status != statusModel.nenhum ||
                    (this.status == statusModel.nenhum && value > 0))
                {
                    _IPI_vBaseCalculo = value;
                    base.NotifyPropertyChanged(propertyName: "IPI_vBaseCalculo");
                }

                if (Sistema.stSender == TipoSender.WCF)
                {
                    this.IPI_vIPI = value * (this.IPI_pIPI / 100);
                }
                base.NotifyPropertyChanged(propertyName: "IPI_vIPI");
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
                this.IPI_vIPI = this.IPI_vIPI * (value / 100);
                base.NotifyPropertyChanged(propertyName: "IPI_pIPI");
                base.NotifyPropertyChanged(propertyName: "IPI_vIPI");
            }
        }
        private decimal? _IPI_vIPI;
        [ParameterOrder(Order = 28)]
        public decimal? IPI_vIPI
        {
            get { return _IPI_vIPI; }
            set
            {
                if (this.status != statusModel.nenhum ||
                    (this.status == statusModel.nenhum && value > 0))
                    _IPI_vIPI = value;

                if (Sistema.stSender == TipoSender.WCF)
                {
                    this.CalculaBaseIcms();
                    this.CalculaBaseIcmsProprio();
                    this.CalculaBasePis();
                    this.CalculaBaseCofins();
                }
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
                if (OrcamentoFacade.objCadastros.objCliente.cliente_fornecedor_fiscal.stCalculaIpi == 0)
                    _IPI_stCompoeBaseCalculo = 3;
                else
                    _IPI_stCompoeBaseCalculo = value;

                if (Sistema.stSender == TipoSender.WCF)
                {
                    this.CalculaBaseIpi();
                }

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
                if (value != 0)
                {
                    this.xNcm = OrcamentoFacade.classificFiscalService.GetObjeto(
                        idObjeto: value).cNCM;
                    base.NotifyPropertyChanged(propertyName: "cNCM");
                }
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
                this.PIS_vPIS = value * (this._PIS_pPIS / 100);
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
                PIS_vPIS = _PIS_vBaseCalculo * (value / 100);
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
                if (this.status != statusModel.nenhum ||
                    (this.status == statusModel.nenhum && value > 0))
                    _stCalculaPisCofins = value;

                base.NotifyPropertyChanged(propertyName: "stCalculaPisCofins");

                if (Sistema.stSender == TipoSender.WCF)
                {
                    switch (value)
                    {
                        case 0:
                            {
                                this._stCompoeBaseCalculoPisCofins = 4;
                                base.NotifyPropertyChanged(propertyName: "stCompoeBaseCalculoPisCofins");
                                this._PIS_stCompoeBaseCalculoSubstituicaoTributaria = 4;
                                base.NotifyPropertyChanged(propertyName: "PIS_stCompoeBaseCalculoSubstituicaoTributaria");
                                this._COFINS_stCompoeBaseCalculoSubstituicaoTributaria = 4;
                                base.NotifyPropertyChanged(propertyName: "COFINS_stCompoeBaseCalculoSubstituicaoTributaria");
                            } break;
                        case 1:
                            {
                                this.stCompoeBaseCalculoPisCofins = this._stCompoeBaseCalculoPisCofins;
                                this._PIS_stCompoeBaseCalculoSubstituicaoTributaria = 4;
                                base.NotifyPropertyChanged(propertyName: "PIS_stCompoeBaseCalculoSubstituicaoTributaria");
                                this._COFINS_stCompoeBaseCalculoSubstituicaoTributaria = 4;
                                base.NotifyPropertyChanged(propertyName: "COFINS_stCompoeBaseCalculoSubstituicaoTributaria");
                            } break;
                        case 2:
                            {
                                this._stCompoeBaseCalculoPisCofins = 4;
                                base.NotifyPropertyChanged(propertyName: "stCompoeBaseCalculoPisCofins");
                                this.PIS_stCompoeBaseCalculoSubstituicaoTributaria = this._PIS_stCompoeBaseCalculoSubstituicaoTributaria;
                                this.COFINS_stCompoeBaseCalculoSubstituicaoTributaria = this._COFINS_stCompoeBaseCalculoSubstituicaoTributaria;
                            } break;
                    }
                    this.CalculaBasePis();
                    this.CalculaBaseCofins();
                }
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
                switch (this.stCalculaPisCofins)
                {
                    case 0:
                    case 2:
                        {
                            this._stCompoeBaseCalculoPisCofins = 4;
                        } break;
                    case 1:
                        {
                            _stCompoeBaseCalculoPisCofins = value;
                        } break;
                }
                if (Sistema.stSender == TipoSender.WCF)
                {
                    this.CalculaBasePis();
                    this.CalculaBaseCofins();
                }
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
                switch (this.stCalculaPisCofins)
                {
                    case 0:
                    case 1:
                        {
                            this._PIS_stCompoeBaseCalculoSubstituicaoTributaria = 4;
                        } break;
                    case 2:
                        {
                            this._PIS_stCompoeBaseCalculoSubstituicaoTributaria = value;
                        } break;
                }
                if (Sistema.stSender == TipoSender.WCF)
                {
                    this.CalculaBasePis();
                }
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
                this.COFINS_vCOFINS = value * (this._COFINS_pCOFINS / 100);
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
                this.COFINS_vCOFINS = this._COFINS_vBaseCalculo * (value / 100);
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
                switch (this.stCalculaPisCofins)
                {
                    case 0:
                    case 1:
                        {
                            this._COFINS_stCompoeBaseCalculoSubstituicaoTributaria = 4;
                        } break;
                    case 2:
                        {
                            this._COFINS_stCompoeBaseCalculoSubstituicaoTributaria = value;
                        } break;
                }
                if (Sistema.stSender == TipoSender.WCF)
                {
                    this.CalculaBaseCofins();
                }
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

    public partial class Orcamento_Total_ImpostosModel : modelBase
    {
        public Orcamento_Total_ImpostosModel()
            : base(xTabela: "Orcamento_Total_Impostos")
        {
        }

        #region propriedades não mapeadas


        #endregion

        #region métodos públicos

        public void CalcularTotais()
        {
            Window wd = Sistema.GetOpenWindow(xName: "WinOrcamento");

            if (wd != null)
            {
                Orcamento_ideModel objOrcamento_ide = null;

                Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, (Action)(() =>
                {
                    objOrcamento_ide = wd.DataContext.GetType().GetProperty(name: "currentModel").GetValue(obj: wd.DataContext)
                    as Orcamento_ideModel;
                }));

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
                    base.NotifyPropertyChanged(propertyName: "vDescontoTotal");

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
                        dBaseCalcIcms += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 0).Sum(i => i.ICMS_vBaseCalculo ?? 0);
                    }

                    if (objOrcamento_ide.bEnviado || objOrcamento_ide.bTodos)
                    {
                        dBaseCalcIcms += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 1).Sum(i => i.ICMS_vBaseCalculo ?? 0);
                    }

                    if (objOrcamento_ide.bConfirmado || objOrcamento_ide.bTodos)
                    {
                        dBaseCalcIcms += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 2).Sum(i => i.ICMS_vBaseCalculo ?? 0);
                    }

                    if (objOrcamento_ide.bPerdido || objOrcamento_ide.bTodos)
                    {
                        dBaseCalcIcms += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 3).Sum(i => i.ICMS_vBaseCalculo ?? 0);
                    }

                    if (objOrcamento_ide.bCancelado || objOrcamento_ide.bTodos)
                    {
                        dBaseCalcIcms += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 4).Sum(i => i.ICMS_vBaseCalculo ?? 0);
                    }

                    this._vBaseCalculoIcmsTotal = dBaseCalcIcms;
                    base.NotifyPropertyChanged(propertyName: "vBaseCalculoIcmsTotal");

                    #endregion

                    #region Cálculo de totais Valor ICMS

                    decimal dVlrIcms = decimal.Zero;

                    if (objOrcamento_ide.bCriado || objOrcamento_ide.bTodos)
                    {
                        dVlrIcms += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 0).Sum(i => i.ICMS_vBaseCalculo ?? 0);
                    }

                    if (objOrcamento_ide.bEnviado || objOrcamento_ide.bTodos)
                    {
                        dVlrIcms += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 1).Sum(i => i.ICMS_vBaseCalculo ?? 0);
                    }

                    if (objOrcamento_ide.bConfirmado || objOrcamento_ide.bTodos)
                    {
                        dVlrIcms += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 2).Sum(i => i.ICMS_vBaseCalculo ?? 0);
                    }

                    if (objOrcamento_ide.bPerdido || objOrcamento_ide.bTodos)
                    {
                        dVlrIcms += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 3).Sum(i => i.ICMS_vBaseCalculo ?? 0);
                    }

                    if (objOrcamento_ide.bCancelado || objOrcamento_ide.bTodos)
                    {
                        dVlrIcms += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 4).Sum(i => i.ICMS_vBaseCalculo ?? 0);
                    }

                    this._vICMSTotal = dVlrIcms;
                    base.NotifyPropertyChanged(propertyName: "vBaseCalculoIcmsTotal");

                    #endregion

                    #region Cálculo de totais Base de Cálculo Icms Próprio

                    decimal dVlrBaseIcmsProprio = decimal.Zero;

                    if (objOrcamento_ide.bCriado || objOrcamento_ide.bTodos)
                    {
                        dVlrBaseIcmsProprio += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 0).Sum(i => i.ICMS_vBaseCalculoIcmsProprio ?? 0);
                    }

                    if (objOrcamento_ide.bEnviado || objOrcamento_ide.bTodos)
                    {
                        dVlrBaseIcmsProprio += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 1).Sum(i => i.ICMS_vBaseCalculoIcmsProprio ?? 0);
                    }

                    if (objOrcamento_ide.bConfirmado || objOrcamento_ide.bTodos)
                    {
                        dVlrBaseIcmsProprio += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 2).Sum(i => i.ICMS_vBaseCalculoIcmsProprio ?? 0);
                    }

                    if (objOrcamento_ide.bPerdido || objOrcamento_ide.bTodos)
                    {
                        dVlrBaseIcmsProprio += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 3).Sum(i => i.ICMS_vBaseCalculoIcmsProprio ?? 0);
                    }

                    if (objOrcamento_ide.bCancelado || objOrcamento_ide.bTodos)
                    {
                        dVlrBaseIcmsProprio += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 4).Sum(i => i.ICMS_vBaseCalculoIcmsProprio ?? 0);
                    }

                    this._vBaseCalculoIcmsProprioTotal = dVlrBaseIcmsProprio;
                    base.NotifyPropertyChanged(propertyName: "vBaseCalculoIcmsTotal");

                    #endregion

                    #region Cálculo de totais Valor Icms Próprio

                    decimal dVlrIcmsPróprio = decimal.Zero;

                    if (objOrcamento_ide.bCriado || objOrcamento_ide.bTodos)
                    {
                        dVlrIcmsPróprio += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 0).Sum(i => i.ICMS_vIcmsProprio ?? 0);
                    }

                    if (objOrcamento_ide.bEnviado || objOrcamento_ide.bTodos)
                    {
                        dVlrIcmsPróprio += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 1).Sum(i => i.ICMS_vIcmsProprio ?? 0);
                    }

                    if (objOrcamento_ide.bConfirmado || objOrcamento_ide.bTodos)
                    {
                        dVlrIcmsPróprio += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 2).Sum(i => i.ICMS_vIcmsProprio ?? 0);
                    }

                    if (objOrcamento_ide.bPerdido || objOrcamento_ide.bTodos)
                    {
                        dVlrIcmsPróprio += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 3).Sum(i => i.ICMS_vIcmsProprio ?? 0);
                    }

                    if (objOrcamento_ide.bCancelado || objOrcamento_ide.bTodos)
                    {
                        dVlrIcmsPróprio += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 4).Sum(i => i.ICMS_vIcmsProprio ?? 0);
                    }

                    this._vIcmsProprioTotal = dVlrBaseIcmsProprio;
                    base.NotifyPropertyChanged(propertyName: "vIcmsProprioTotal");

                    #endregion

                    #region Cálculo de totais Valor Base de Cálculo Ipi

                    decimal dVlrBaseCalculoIpi = decimal.Zero;

                    if (objOrcamento_ide.bCriado || objOrcamento_ide.bTodos)
                    {
                        dVlrBaseCalculoIpi += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 0).Sum(i => i.IPI_vBaseCalculo ?? 0);
                    }

                    if (objOrcamento_ide.bEnviado || objOrcamento_ide.bTodos)
                    {
                        dVlrBaseCalculoIpi += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 1).Sum(i => i.IPI_vBaseCalculo ?? 0);
                    }

                    if (objOrcamento_ide.bConfirmado || objOrcamento_ide.bTodos)
                    {
                        dVlrBaseCalculoIpi += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 2).Sum(i => i.IPI_vBaseCalculo ?? 0);
                    }

                    if (objOrcamento_ide.bPerdido || objOrcamento_ide.bTodos)
                    {
                        dVlrBaseCalculoIpi += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 3).Sum(i => i.IPI_vBaseCalculo ?? 0);
                    }

                    if (objOrcamento_ide.bCancelado || objOrcamento_ide.bTodos)
                    {
                        dVlrBaseCalculoIpi += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 4).Sum(i => i.IPI_vBaseCalculo ?? 0);
                    }

                    this._vBaseCalculoIpiTotal = dVlrBaseCalculoIpi;
                    base.NotifyPropertyChanged(propertyName: "vBaseCalculoIpiTotal");

                    #endregion

                    #region Cálculo de totais Valor Ipi

                    decimal dVlrIpi = decimal.Zero;

                    if (objOrcamento_ide.bCriado || objOrcamento_ide.bTodos)
                    {
                        dVlrIpi += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 0).Sum(i => i.IPI_vIPI ?? 0);
                    }

                    if (objOrcamento_ide.bEnviado || objOrcamento_ide.bTodos)
                    {
                        dVlrIpi += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 1).Sum(i => i.IPI_vIPI ?? 0);
                    }

                    if (objOrcamento_ide.bConfirmado || objOrcamento_ide.bTodos)
                    {
                        dVlrIpi += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 2).Sum(i => i.IPI_vIPI ?? 0);
                    }

                    if (objOrcamento_ide.bPerdido || objOrcamento_ide.bTodos)
                    {
                        dVlrIpi += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 3).Sum(i => i.IPI_vIPI ?? 0);
                    }

                    if (objOrcamento_ide.bCancelado || objOrcamento_ide.bTodos)
                    {
                        dVlrIpi += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 4).Sum(i => i.IPI_vIPI ?? 0);
                    }

                    this._vIPITotal = dVlrIpi;
                    base.NotifyPropertyChanged(propertyName: "vIPITotal");

                    #endregion

                    #region Cálculo de totais Valor de Base Substituição Tributária

                    decimal dVlrBaseSubstTribut = decimal.Zero;

                    if (objOrcamento_ide.bCriado || objOrcamento_ide.bTodos)
                    {
                        dVlrBaseSubstTribut += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 0).Sum(i => i.ICMS_vBaseCalculoSubstituicaoTributaria ?? 0);
                    }

                    if (objOrcamento_ide.bEnviado || objOrcamento_ide.bTodos)
                    {
                        dVlrBaseSubstTribut += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 1).Sum(i => i.ICMS_vBaseCalculoSubstituicaoTributaria ?? 0);
                    }

                    if (objOrcamento_ide.bConfirmado || objOrcamento_ide.bTodos)
                    {
                        dVlrBaseSubstTribut += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 2).Sum(i => i.ICMS_vBaseCalculoSubstituicaoTributaria ?? 0);
                    }

                    if (objOrcamento_ide.bPerdido || objOrcamento_ide.bTodos)
                    {
                        dVlrBaseSubstTribut += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 3).Sum(i => i.ICMS_vBaseCalculoSubstituicaoTributaria ?? 0);
                    }

                    if (objOrcamento_ide.bCancelado || objOrcamento_ide.bTodos)
                    {
                        dVlrBaseSubstTribut += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 4).Sum(i => i.ICMS_vBaseCalculoSubstituicaoTributaria ?? 0);
                    }

                    this._vBaseCalculoICmsSubstituicaoTributariaTotal = dVlrBaseSubstTribut;
                    base.NotifyPropertyChanged(propertyName: "vBaseCalculoICmsSubstituicaoTributariaTotal");

                    #endregion

                    #region Cálculo de totais Valor Substituição Tributária

                    decimal dVlrSubsTrib = decimal.Zero;

                    if (objOrcamento_ide.bCriado || objOrcamento_ide.bTodos)
                    {
                        dVlrSubsTrib += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 0).Sum(i => i.ICMS_vSubstituicaoTributaria ?? 0);
                    }

                    if (objOrcamento_ide.bEnviado || objOrcamento_ide.bTodos)
                    {
                        dVlrSubsTrib += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 1).Sum(i => i.ICMS_vSubstituicaoTributaria ?? 0);
                    }

                    if (objOrcamento_ide.bConfirmado || objOrcamento_ide.bTodos)
                    {
                        dVlrSubsTrib += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 2).Sum(i => i.ICMS_vSubstituicaoTributaria ?? 0);
                    }

                    if (objOrcamento_ide.bPerdido || objOrcamento_ide.bTodos)
                    {
                        dVlrSubsTrib += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 3).Sum(i => i.ICMS_vSubstituicaoTributaria ?? 0);
                    }

                    if (objOrcamento_ide.bCancelado || objOrcamento_ide.bTodos)
                    {
                        dVlrSubsTrib += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 4).Sum(i => i.ICMS_vSubstituicaoTributaria ?? 0);
                    }

                    this._vIcmsSubstituicaoTributariaTotal = dVlrSubsTrib;
                    base.NotifyPropertyChanged(propertyName: "vIcmsSubstituicaoTributariaTotal");

                    #endregion

                    #region Cálculo de totais base de cálculo Pis

                    decimal dVlrBaseCalcPis = decimal.Zero;

                    if (objOrcamento_ide.bCriado || objOrcamento_ide.bTodos)
                    {
                        dVlrBaseCalcPis += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 0).Sum(i => i.PIS_vBaseCalculo ?? 0);
                    }

                    if (objOrcamento_ide.bEnviado || objOrcamento_ide.bTodos)
                    {
                        dVlrBaseCalcPis += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 1).Sum(i => i.PIS_vBaseCalculo ?? 0);
                    }

                    if (objOrcamento_ide.bConfirmado || objOrcamento_ide.bTodos)
                    {
                        dVlrBaseCalcPis += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 2).Sum(i => i.PIS_vBaseCalculo ?? 0);
                    }

                    if (objOrcamento_ide.bPerdido || objOrcamento_ide.bTodos)
                    {
                        dVlrBaseCalcPis += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 3).Sum(i => i.PIS_vBaseCalculo ?? 0);
                    }

                    if (objOrcamento_ide.bCancelado || objOrcamento_ide.bTodos)
                    {
                        dVlrBaseCalcPis += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 4).Sum(i => i.PIS_vBaseCalculo ?? 0);
                    }

                    this._vBaseCalculoPisTotal = dVlrBaseCalcPis;
                    base.NotifyPropertyChanged(propertyName: "vBaseCalculoPisTotal");

                    #endregion

                    #region Cálculo de totais valor Pis

                    decimal dVlrPis = decimal.Zero;

                    if (objOrcamento_ide.bCriado || objOrcamento_ide.bTodos)
                    {
                        dVlrPis += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 0).Sum(i => i.PIS_vPIS ?? 0);
                    }

                    if (objOrcamento_ide.bEnviado || objOrcamento_ide.bTodos)
                    {
                        dVlrPis += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 1).Sum(i => i.PIS_vPIS ?? 0);
                    }

                    if (objOrcamento_ide.bConfirmado || objOrcamento_ide.bTodos)
                    {
                        dVlrPis += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 2).Sum(i => i.PIS_vPIS ?? 0);
                    }

                    if (objOrcamento_ide.bPerdido || objOrcamento_ide.bTodos)
                    {
                        dVlrPis += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 3).Sum(i => i.PIS_vPIS ?? 0);
                    }

                    if (objOrcamento_ide.bCancelado || objOrcamento_ide.bTodos)
                    {
                        dVlrPis += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 4).Sum(i => i.PIS_vPIS ?? 0);
                    }

                    this._vPISTotal = dVlrPis;
                    base.NotifyPropertyChanged(propertyName: "vPISTotal");

                    #endregion

                    #region Cálculo de totais base de cálculo Cofins

                    decimal dVlrBaseCalcCofins = decimal.Zero;

                    if (objOrcamento_ide.bCriado || objOrcamento_ide.bTodos)
                    {
                        dVlrBaseCalcCofins += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 0).Sum(i => i.COFINS_vBaseCalculo ?? 0);
                    }

                    if (objOrcamento_ide.bEnviado || objOrcamento_ide.bTodos)
                    {
                        dVlrBaseCalcCofins += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 1).Sum(i => i.COFINS_vBaseCalculo ?? 0);
                    }

                    if (objOrcamento_ide.bConfirmado || objOrcamento_ide.bTodos)
                    {
                        dVlrBaseCalcCofins += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 2).Sum(i => i.COFINS_vBaseCalculo ?? 0);
                    }

                    if (objOrcamento_ide.bPerdido || objOrcamento_ide.bTodos)
                    {
                        dVlrBaseCalcCofins += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 3).Sum(i => i.COFINS_vBaseCalculo ?? 0);
                    }

                    if (objOrcamento_ide.bCancelado || objOrcamento_ide.bTodos)
                    {
                        dVlrBaseCalcCofins += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 4).Sum(i => i.COFINS_vBaseCalculo ?? 0);
                    }

                    this._vBaseCalculoCofinsTotal = dVlrBaseCalcCofins;
                    base.NotifyPropertyChanged(propertyName: "vBaseCalculoCofinsTotal");

                    #endregion

                    #region Cálculo de totais Valor Cofins

                    decimal dVlrCofins = decimal.Zero;

                    if (objOrcamento_ide.bCriado || objOrcamento_ide.bTodos)
                    {
                        dVlrCofins += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 0).Sum(i => i.COFINS_vCOFINS ?? 0);
                    }

                    if (objOrcamento_ide.bEnviado || objOrcamento_ide.bTodos)
                    {
                        dVlrCofins += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 1).Sum(i => i.COFINS_vCOFINS ?? 0);
                    }

                    if (objOrcamento_ide.bConfirmado || objOrcamento_ide.bTodos)
                    {
                        dVlrCofins += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 2).Sum(i => i.COFINS_vCOFINS ?? 0);
                    }

                    if (objOrcamento_ide.bPerdido || objOrcamento_ide.bTodos)
                    {
                        dVlrCofins += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 3).Sum(i => i.COFINS_vCOFINS ?? 0);
                    }

                    if (objOrcamento_ide.bCancelado || objOrcamento_ide.bTodos)
                    {
                        dVlrCofins += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 4).Sum(i => i.COFINS_vCOFINS ?? 0);
                    }

                    this._vCOFINSTotal = dVlrCofins;
                    base.NotifyPropertyChanged(propertyName: "vCOFINSTotal");

                    #endregion

                    #region Cálculo de Valor Base de Cálculo Iss

                    decimal dVlrBaseCalcIss = decimal.Zero;

                    if (objOrcamento_ide.bCriado || objOrcamento_ide.bTodos)
                    {
                        dVlrBaseCalcIss += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 0).Sum(i => i.ISS_vBaseCalculo ?? 0);
                    }

                    if (objOrcamento_ide.bEnviado || objOrcamento_ide.bTodos)
                    {
                        dVlrBaseCalcIss += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 1).Sum(i => i.ISS_vBaseCalculo ?? 0);
                    }

                    if (objOrcamento_ide.bConfirmado || objOrcamento_ide.bTodos)
                    {
                        dVlrBaseCalcIss += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 2).Sum(i => i.ISS_vBaseCalculo ?? 0);
                    }

                    if (objOrcamento_ide.bPerdido || objOrcamento_ide.bTodos)
                    {
                        dVlrBaseCalcIss += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 3).Sum(i => i.ISS_vBaseCalculo ?? 0);
                    }

                    if (objOrcamento_ide.bCancelado || objOrcamento_ide.bTodos)
                    {
                        dVlrBaseCalcIss += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 4).Sum(i => i.ISS_vBaseCalculo ?? 0);
                    }

                    this._vBaseCalculoIssTotal = dVlrBaseCalcIss;
                    base.NotifyPropertyChanged(propertyName: "vBaseCalculoIssTotal");

                    #endregion

                    #region Cálculo de Valor Iss

                    decimal dVlrIss = decimal.Zero;

                    if (objOrcamento_ide.bCriado || objOrcamento_ide.bTodos)
                    {
                        dVlrIss += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 0).Sum(i => i.ISS_vIss ?? 0);
                    }

                    if (objOrcamento_ide.bEnviado || objOrcamento_ide.bTodos)
                    {
                        dVlrIss += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 1).Sum(i => i.ISS_vIss ?? 0);
                    }

                    if (objOrcamento_ide.bConfirmado || objOrcamento_ide.bTodos)
                    {
                        dVlrIss += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 2).Sum(i => i.ISS_vIss ?? 0);
                    }

                    if (objOrcamento_ide.bPerdido || objOrcamento_ide.bTodos)
                    {
                        dVlrIss += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 3).Sum(i => i.ISS_vIss ?? 0);
                    }

                    if (objOrcamento_ide.bCancelado || objOrcamento_ide.bTodos)
                    {
                        dVlrIss += objOrcamento_ide.lOrcamento_Item_Impostos
                            .Where(i => i.stOrcamentoImpostos == 4).Sum(i => i.ISS_vIss ?? 0);
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
                if (this._vTotal != 0)
                {
                    Window wd = Sistema.GetOpenWindow(xName: "WinOrcamento");

                    if (wd != null)
                    {
                        Orcamento_ideModel objOrcamento_ide = wd.DataContext.GetType().GetProperty(name: "currentModel").GetValue(obj: wd.DataContext)
                            as Orcamento_ideModel;

                        if (objOrcamento_ide != null)
                        {
                            decimal vBruto = objOrcamento_ide.lOrcamento_Itens.Sum(i => i.vVenda * i.qProduto);
                            this._pDescontoTotal = value / vBruto;

                            foreach (Orcamento_ItemModel item in objOrcamento_ide.lOrcamento_Itens)
                            {
                                item.vDesconto = ((((item.vTotalItem / item.qProduto) - item.vDesconto) / vBruto) * value);
                            }
                        }
                        DataGrid dg = wd.FindName(name: "dgItens") as DataGrid;
                        DataGridRow row = null;
                        DataGridColumn column = dg.Columns.FirstOrDefault(i => i.Header.ToString() == "% Desc"); ;
                        object o;
                        bool valido = true;

                        if (dg.ItemsSource != null)
                        {
                            foreach (var item in dg.ItemsSource)
                            {
                                row = dg.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                                if (row != null)
                                {
                                    o = StaticUtil.GetCell(grid: dg, row: row, column: column.DisplayIndex).Content;

                                    if (o.GetType().Name.ToString() == "TextBlock")
                                    {
                                        if (Validation.GetHasError(o as TextBlock))
                                            valido = false;
                                    }
                                }
                            }
                        }

                        if (!valido)
                        {
                            MessageBox.Show(messageBoxText: "Alguns itens ultrapassaram o limite de porcentagem. Verifique!",
                                caption: "Verifique!", button: MessageBoxButton.OK, icon: MessageBoxImage.Exclamation);
                            TabControl t = wd.FindName(name: "tabControlPrincipal") as TabControl;
                            t.SelectedIndex = 2;
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
                        if (!bPermitePorcentagem)
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
                    if (columnName == "PIS_nCoeficienteSubstituicaoTributaria")
                    {
                        if (this.stCalculaPisCofins == 2 && this.PIS_nCoeficienteSubstituicaoTributaria <= 0)
                        {
                            return "Valor deve ser superior a 0";
                        }
                    }
                    else if (columnName == "COFINS_nCoeficienteSubstituicaoTributaria")
                    {
                        if (this.stCalculaPisCofins == 2 && this.COFINS_nCoeficienteSubstituicaoTributaria <= 0)
                        {
                            return "Valor deve ser superior a 0";
                        }
                    }
                    else if (columnName == "PIS_pPIS")
                    {
                        if ((this.stCalculaPisCofins == 1 || this.stCalculaPisCofins == 2) && this.PIS_pPIS <= 0)
                        {
                            return "Valor deve ser superior a 0";
                        }
                    }
                    else if (columnName == "COFINS_pCOFINS")
                    {
                        if ((this.stCalculaPisCofins == 1 || this.stCalculaPisCofins == 2) && this.COFINS_pCOFINS <= 0)
                        {
                            return "Valor deve ser superior a 0";
                        }
                    }
                    else if (columnName == "stCompoeBaseCalculoPisCofins")
                    {
                        if (this.stCalculaPisCofins == 1 && this.stCompoeBaseCalculoPisCofins == 4)
                        {
                            return "Quando selecionada opção '2-NORMAL' no campo calcula pis cofins, este campo deve possuir valor diferente de 5-NENHUM";
                        }
                    }
                    else if (columnName == "PIS_stCompoeBaseCalculoSubstituicaoTributaria")
                    {
                        if (this.stCalculaPisCofins == 2 && this.PIS_stCompoeBaseCalculoSubstituicaoTributaria == 4)
                        {
                            return "Quando selecionada opção '3-SUBSTITUIÇÃO TRIBUTÁRIA' no campo calcula pis cofins, este campo deve possuir valor diferente de 5-NENHUM";
                        }
                    }
                    else if (columnName == "COFINS_stCompoeBaseCalculoSubstituicaoTributaria")
                    {
                        if (this.stCalculaPisCofins == 2 && this.COFINS_stCompoeBaseCalculoSubstituicaoTributaria == 4)
                        {
                            return "Quando selecionada opção '3-SUBSTITUIÇÃO TRIBUTÁRIA' no campo calcula pis cofins, este campo deve possuir valor diferente de 5-NENHUM";
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
