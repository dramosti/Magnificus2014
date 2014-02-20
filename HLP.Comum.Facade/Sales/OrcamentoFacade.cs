using HLP.Comum.Facade.FillComboBoxService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Comum.Facade.Sales
{
    public static class OrcamentoFacade
    {
        public static clienteService.IserviceClienteClient clienteServico;
        public static FillComboBoxService.IserviceFillComboBoxClient servico;
        public static contato_Service.IserviceContatoClient contatoServico;
        public static cidadeService.IserviceCidadeClient cidadeService;
        public static ufService.IserviceUfClient ufService;
        public static Canal_VendaService.IserviceCanal_VendaClient canal_VendaService;
        public static Tipo_Documento_Oper_ValidaService.IserviceTipo_documento_Operacao_ValidaClient tipo_Documento_Oper_ValidaService;
        private static OrcamentoCadastros _objCadastros;
        public static OrcamentoCadastros objCadastros
        {
            get
            {
                if (_objCadastros == null)
                    _objCadastros = new OrcamentoCadastros();

                return _objCadastros;
            }
            set
            {
                _objCadastros = value;
            }
        }
        public static produtoService.IserviceProdutoClient produtoService;
        public static Familia_ProdutoService.IserviceFamiliaProduto familiaProdutoService;
        public static Lista_PrecoService.IserviceLista_PrecoClient lista_PrecoService;
        public static funcionarioService.IserviceFuncionarioClient funcionarioService;
        public static Condicao_PagamentoService.IserviceCondicao_PagamentoClient condicaoPagamentoService;
        public static Tipo_OperacaoService.IserviceTipo_OperacaoClient tipoOperacaoService;
        public static empresaService.IserviceEmpresaClient empresaService;
        public static ClassificacaoFiscalServico.IserviceClassificacaoFiscalClient classificFiscalService;
        public static CodigoIcmsService.IserviceCodigoIcmsClient icmsService;
        public static Carga_trib_media_st_icmsServico.IserviceCarga_trib_media_st_icmsClient cargaTribMediaService;
        public static Ramo_AtividadeService.IserviceRamoAtividadeClient ramo_AtividadeService;

        public static int GetIdCfop(int idTipoOpercacao)
        {
            int idEstadoCliente = 0;

            if (OrcamentoFacade.objCadastros.objCliente.lCliente_fornecedor_Endereco != null)
            {
                if (OrcamentoFacade.objCadastros.objCliente.lCliente_fornecedor_Endereco.Count(i => i.stPrincipal == 1) > 0)
                {
                    idEstadoCliente = OrcamentoFacade.cidadeService.getCidade(
                        idCidade: OrcamentoFacade.objCadastros.objCliente.lCliente_fornecedor_Endereco.FirstOrDefault(i => i.stPrincipal == 1).idCidade).idUF;
                }
                else if (OrcamentoFacade.objCadastros.objCliente.lCliente_fornecedor_Endereco.Count() > 0)
                {
                    idEstadoCliente = OrcamentoFacade.cidadeService.getCidade(
                        idCidade: OrcamentoFacade.objCadastros.objCliente.lCliente_fornecedor_Endereco.FirstOrDefault().idCidade).idUF;
                }
                else
                {
                    idEstadoCliente = 0;
                }
            }

            if (idTipoOpercacao > 0)
            {
                if (idEstadoCliente != OrcamentoFacade.objCadastros.idEstadoEmpresa)
                {
                    return OrcamentoFacade.tipoOperacaoService.GetObjeto(idObjeto: idTipoOpercacao).cCfopOutraUf;
                }
                else
                {
                    return OrcamentoFacade.tipoOperacaoService.GetObjeto(idObjeto: idTipoOpercacao).cCfopNaUf;
                }
            }

            return 0;
        }

        public static ObservableCollection<modelToComboBox> GetAllValuesToComboBox(string sNameView, string sParameter = "")
        {
            if (servico == null)
                servico = new IserviceFillComboBoxClient();
            return new ObservableCollection<modelToComboBox>(servico.GetAllValuesToComboBox(sNameView, sParameter));
        }
    }

    public class OrcamentoCadastros
    {
        public OrcamentoCadastros()
        {
            this.objContato = new contato_Service.ContatoModel();
            this.objCliente = new clienteService.Cliente_fornecedorModel();
            this.objListaPreco = new Lista_PrecoService.Lista_Preco_PaiModel();
            lProdutos = new List<produtoService.ProdutoModel>();
            this.lTipoOperacao = new List<Tipo_OperacaoService.Tipo_operacaoModel>();
            this.objFuncionario = new funcionarioService.FuncionarioModel();
            this.objCondicaoPagamento = new Condicao_PagamentoService.Condicao_pagamentoModel();
            this.objCargaTrib = new Carga_trib_media_st_icmsServico.Carga_trib_media_st_icmsModel();
            this.objRamoAtividade = new Ramo_AtividadeService.Ramo_atividadeModel();


            if (OrcamentoFacade.empresaService == null)
                OrcamentoFacade.empresaService = new empresaService.IserviceEmpresaClient();

            //this.objEmpresa = new empresaService.EmpresaModel();            
            this.objEmpresa = OrcamentoFacade.empresaService.getEmpresa(idEmpresa: HLP.Comum.Infrastructure.Static.CompanyData.idEmpresa);
        }

        public contato_Service.ContatoModel objContato;
        public List<produtoService.ProdutoModel> lProdutos;
        public List<Tipo_OperacaoService.Tipo_operacaoModel> lTipoOperacao { get; set; }
        public int idTipoOperacao;
        public Lista_PrecoService.Lista_Preco_PaiModel objListaPreco;
        public clienteService.Cliente_fornecedorModel objCliente;
        public funcionarioService.FuncionarioModel objFuncionario;
        public Condicao_PagamentoService.Condicao_pagamentoModel objCondicaoPagamento;
        public empresaService.EmpresaModel objEmpresa;
        public int idEstadoEmpresa;
        public int idEstadoCliente;
        public Carga_trib_media_st_icmsServico.Carga_trib_media_st_icmsModel objCargaTrib;
        public int stContribuinteIcms;
        public Ramo_AtividadeService.Ramo_atividadeModel objRamoAtividade;

        #region NotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
