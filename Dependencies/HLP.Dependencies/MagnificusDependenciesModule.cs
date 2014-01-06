using HLP.Comum.Infrastructure;
using HLP.Comum.Model.Repository.Implementation.Components;
using HLP.Comum.Model.Repository.Interfaces.ClassesBases;
using HLP.Comum.Model.Repository.Interfaces.Components;
using HLP.Entries.Model.Repository.Implementation.Gerais;
using HLP.Entries.Model.Repository.Implementation.Fiscal;
using HLP.Entries.Model.Repository.Interfaces.Gerais;
using HLP.Entries.Model.Repository.Interfaces.Fiscal;
using Ninject.Modules;
using HLP.Entries.Model.Repository.Interfaces.RecursosHumanos;
using HLP.Entries.Model.Repository.Implementation.RecursosHumanos;
using HLP.Entries.Model.Repository.Interfaces.Comercial;
using HLP.Entries.Model.Repository.Implementation.Comercial;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.Model.Repository.Interfaces.Transportes;
using HLP.Entries.Model.Repository.Implementation.Transportes;
using HLP.Entries.Model.Repository.Interfaces.Parametros;
using HLP.Entries.Model.Repository.Implementation.Parametros;
using HLP.Entries.Model.Repository.Interfaces.Financeiro;
using HLP.Entries.Model.Repository.Implementation.Financeiro;
using HLP.Entries.Model.Repository.Interfaces.Crm;
using HLP.Entries.Model.Repository.Implementation.Crm;
using HLP.Sales.Model.Repository.Interfaces;
using HLP.Sales.Model.Repository.Implementation;

namespace HLP.Dependencies
{
    public class MagnificusDependenciesModule : NinjectModule
    {
        public override void Load()
        {
            Bind<UnitOfWorkBase>().ToConstant(new UnitOfWork());
            ResolveRepositories();
            ResolveServices();
        }

        protected void ResolveRepositories()
        {
            Bind<IHlpPesquisaRapidaRepository>().To<HlpPesquisaRapidaRepository>();
            Bind<IHlpPesquisaPadraoRepository>().To<HlpPesquisaPadraoRepository>();
            Bind<IFillComboBoxRepository>().To<FillComboBoxRepository>();

            //Bind<IPesquisaPadraoRepository>().To<PesquisaPadraoRepository>();
            //Bind<IConfiguraBaseRepository>().To<ConfiguraBaseRepository>();
            //Bind<IConfigFormulariosRepository>().To<ConfigFormulariosRepository>();
            //Bind<IRelatoriosRepository>().To<RelatoriosRepository>();
            //Bind<IConfigColunasGridRepository>().To<ConfigColunasGridRepository>();
            //Bind<IConfigComponenteRepository>().To<ConfigComponenteRepository>();
            //Bind<IConfigTabPageRepository>().To<ConfigTabPageRepository>();
            //Bind<IConfigPesquisaRepository>().To<ConfigPesquisaRepository>();
            ////IConta_bancariaService into property contaService


            //#region Fiscal

            Bind<ICfopRepository>().To<CfopRepository>();
            Bind<ITipo_documentoRepository>().To<Tipo_documentoRepository>();
            Bind<ITipo_documento_oper_validaRepository>().To<Tipo_documento_oper_validaRepository>();
            Bind<ITipo_operacaoRepository>().To<Tipo_operacaoRepository>();
            Bind<IOperacao_reducao_baseRepository>().To<Operacao_reducao_baseRepository>();
            //Bind<IOperacao_importacaoRepository>().To<Operacao_importacaoRepository>();
            Bind<ISituacao_tributaria_cofinsRepository>().To<Situacao_tributaria_cofinsRepository>();
            Bind<ISituacao_tributaria_icmsRepository>().To<Situacao_tributaria_icmsRepository>();
            Bind<ISituacao_tributaria_pisRepository>().To<Situacao_tributaria_pisRepository>();
            Bind<ISituacao_tributaria_ipiRepository>().To<Situacao_tributaria_ipiRepository>();
            Bind<ICodigo_Icms_paiRepository>().To<Codigo_Icms_paiRepository>();
            Bind<ICodigo_IcmsRepository>().To<Codigo_IcmsRepository>();
            Bind<IClassificacao_fiscalRepository>().To<Classificacao_fiscalRepository>();
            Bind<IRamo_atividadeRepository>().To<Ramo_atividadeRepository>();
            Bind<ICarga_trib_media_st_icmsRepository>().To<Carga_trib_media_st_icmsRepository>();

            //#endregion

            //#region Comercial

            Bind<IRota_pracaRepository>().To<Rota_pracaRepository>();
            Bind<ISite_enderecoRepository>().To<Site_enderecoRepository>();
            Bind<IModos_entregaRepository>().To<Modos_entregaRepository>();
            Bind<IMultasRepository>().To<MultasRepository>();
            Bind<ICanal_vendaRepository>().To<Canal_vendaRepository>();
            Bind<IJurosRepository>().To<JurosRepository>();
            Bind<ICliente_fornecedorRepository>().To<Cliente_fornecedorRepository>();
            Bind<ICliente_fornecedor_arquivoRepository>().To<Cliente_fornecedor_arquivoRepository>();
            Bind<ICliente_fornecedor_contatoRepository>().To<Cliente_fornecedor_contatoRepository>();
            Bind<ICliente_fornecedor_EnderecoRepository>().To<Cliente_fornecedor_EnderecoRepository>();
            Bind<ICliente_fornecedor_fiscalRepository>().To<Cliente_fornecedor_fiscalRepository>();
            Bind<ICliente_Fornecedor_ObservacaoRepository>().To<Cliente_fornecedor_ObservacaoRepository>();
            Bind<ICliente_fornecedor_produtoRepository>().To<Cliente_fornecedor_produtoRepository>();
            Bind<ICliente_fornecedor_representanteRepository>().To<Cliente_fornecedor_representanteRepository>();
            Bind<IPlano_pagamentoRepository>().To<Plano_pagamentoRepository>();
            Bind<IPlano_pagamento_linhasRepository>().To<Plano_pagamento_linhasRepository>();
            Bind<ILista_Preco_PaiRepository>().To<Lista_Preco_PaiRepository>();
            Bind<ILista_precoRepository>().To<Lista_precoRepository>();
            Bind<IProdutoRepository>().To<ProdutoRepository>();
            Bind<ITipo_produtoRepository>().To<Tipo_produtoRepository>();
            //Bind<IProduto_localizacaoRepository>().To<Produto_localizacaoRepository>();
            Bind<ICondicao_pagamentoRepository>().To<Condicao_pagamentoRepository>();
            Bind<IProduto_Fornecedor_HomologadoRepository>().To<Produto_Fornecedor_HomologadoRepository>();
            Bind<IProduto_RevisaoRepository>().To<Produto_RevisaoRepository>();

            //#endregion

            //#region Gerais

            Bind<IDepositoRepository>().To<DepositoRepository>();
            Bind<ICondicoes_entregaRepository>().To<Condicoes_entregaRepository>();
            Bind<IRotaRepository>().To<RotaRepository>();
            Bind<IUFRepository>().To<UFRepository>();
            Bind<ICidadeRepository>().To<CidadeRepository>();
            Bind<IEmpresaRepository>().To<EmpresaRepository>();
            Bind<IRegiaoRepository>().To<RegiaoRepository>();
            //Bind<ISetorRepository>().To<SetorRepository>();
            Bind<IContatoRepository>().To<ContatoRepository>();
            Bind<IDepartamentoRepository>().To<DepartamentoRepository>();
            Bind<ICalendarioRepository>().To<CalendarioRepository>();
            Bind<ICalendario_DetalheRepository>().To<Calendario_DetalheRepository>();
            Bind<ITransportadorReposiroty>().To<TransportadorRepository>();
            Bind<IFuncionarioRepository>().To<FuncionarioRepository>();
            Bind<IUnidade_medidaRepository>().To<Unidade_medidaRepository>();
            Bind<ITipo_servicoRepository>().To<Tipo_servicoRepository>();
            Bind<IFabricanteRepository>().To<FabricanteRepository>();
            Bind<IFamilia_ProdutoRepository>().To<Familia_produtoRepository>();
            Bind<IFamilia_Produto_ClassesRepository>().To<Familia_Produto_ClassesRepository>();
            Bind<IConversaoRepository>().To<ConversaoRepository>();
            Bind<ISiteRepository>().To<SiteRepository>();
            Bind<IContato_EnderecoRepository>().To<Contato_EnderecoRepository>();
            Bind<IFuncionario_Margem_Lucro_ComissaoRepository>().To<Funcionario_Margem_LucroComissaoRepository>();
            Bind<IFuncionario_EnderecoRepository>().To<Funcionario_EnderecoRepository>();
            Bind<IFuncionario_Comissao_ProdutoRepository>().To<Funcionario_Comissao_ProdutoRepository>();
            Bind<IFuncionario_ArquivoRepository>().To<Funcionario_ArquivoRepository>();
            Bind<IFuncionario_CertificacaoRepository>().To<Funcionario_CertificacaoRepository>();
            Bind<ITransportador_VeiculosRepository>().To<Transportador_VeiculosRepository>();
            Bind<ITransportador_MotoristaRepository>().To<Transportador_MotoristaRepository>();
            Bind<ITransportador_ContatoRepository>().To<Transportador_ContatoRepository>();
            Bind<ITransportador_EnderecoRepository>().To<Transportador_EnderecoRepository>();
            Bind<IEmpresa_EnderecoRepository>().To<Empresa_EnderecoRepository>();
            Bind<IAcessoRepository>().To<AcessoRepository>();
            //Bind<ILog_ScriptsRepository>().To<Log_ScriptsRepository>();
            Bind<IOrcamento_ideRepository>().To<Orcamento_ideRepository>();
            Bind<IOrcamento_Item_ImpostosRepository>().To<Orcamento_Item_ImpostosRepository>();
            Bind<IOrcamento_ItemRepository>().To<Orcamento_ItemRepository>();
            Bind<IOrcamento_retTranspRepository>().To<Orcamento_retTranspRepository>();
            Bind<IOrcamento_Total_ImpostosRepository>().To<Orcamento_Total_ImpostosRepository>();

            //#endregion

            //#region Financeiro

            Bind<IBancoRepository>().To<BancoRepository>();
            Bind<IAgenciaRepository>().To<AgenciaRepository>();
            Bind<IAgencia_ContatoRepository>().To<Agencia_ContatoRepository>();
            Bind<IAgencia_EnderecoRepository>().To<Agencia_EnderecoRepository>();
            Bind<IMoedaRepository>().To<MoedaRepository>();
            Bind<IDescontos_AvistaRepository>().To<Descontos_AvistaRepository>();
            Bind<IDia_PagamentoRepository>().To<Dia_PagamentoRepository>();
            Bind<IDia_pagamento_linhasRepository>().To<Dia_Pagamento_LinhaRepository>();
            Bind<IConta_bancariaRepository>().To<Conta_bancariaRepository>();

            //#endregion

            //#region Parametros

            Bind<IParametro_EstoqueRepository>().To<Parametro_EstoqueRepository>();
            Bind<IParametro_CustosRepository>().To<Parametro_CustosRepository>();
            Bind<IParametro_ComprasRepository>().To<Parametro_ComprasRepository>();
            Bind<IParametro_Ordem_ProducaoRepository>().To<Parametro_Ordem_ProducaoRepository>();
            Bind<IParametro_FiscalRepository>().To<Parametro_FiscalRepository>();
            Bind<IParametro_ComercialRepository>().To<Parametro_ComercialRepository>();
            Bind<IParametro_FinanceiroRepository>().To<Parametro_FinanceiroRepository>();

            //#endregion

            //#region CRM

            Bind<IDecisaoRepository>().To<DecisaoRepository>();
            Bind<IPersonalidadeRepository>().To<PersonalidadeRepository>();
            Bind<IFidelidadeRepository>().To<FidelidadeRepository>();

            //#endregion

            #region Recursos Humanos

            Bind<ICargoRepository>().To<CargoRepository>();
            Bind<ISetorRepository>().To<SetorRepository>();

            #endregion

        }

        protected void ResolveServices()
        {
            //Bind<IConfigPesquisaService>().To<ConfigPesquisaService>();
            //Bind<IPesquisaPadraoService>().To<PesquisaPadraoService>();
            //Bind<IConfiguraBaseService>().To<ConfiguraBaseService>();
            //Bind<IConfigFormulariosService>().To<ConfigFormulariosService>();
            //Bind<IConfigColunasGridService>().To<ConfigColunasGridService>();
            //Bind<IConfigComponenteService>().To<ConfigComponenteService>();
            //Bind<IConfigTabPageService>().To<ConfigTabPageService>();
            //Bind<ILogExceptionService>().To<LogExceptionService>();
            //Bind<IInitializeConfigService>().To<InitializeConfigService>();


            //#region Fiscal

            //Bind<ICfopService>().To<CfopService>();
            //Bind<ITipo_documentoService>().To<Tipo_documentoService>();
            //Bind<ITipo_documento_oper_validaService>().To<Tipo_documento_oper_validaService>();
            //Bind<ITipo_operacaoService>().To<Tipo_operacaoService>();
            //Bind<IOperacao_importacaoService>().To<Operacao_importacaoService>();
            //Bind<IOperacao_reducao_baseService>().To<Operacao_reducao_baseService>();
            //Bind<ISituacao_tributaria_cofinsService>().To<Situacao_tributaria_cofinsService>();
            //Bind<ISituacao_tributaria_icmsService>().To<Situacao_tributaria_icmsService>();
            //Bind<ISituacao_tributaria_pisService>().To<Situacao_tributaria_pisService>();
            //Bind<ISituacao_tributaria_ipiService>().To<Situacao_tributaria_ipiService>();
            //Bind<ICodigo_Icms_paiService>().To<Codigo_Icms_paiService>();
            //Bind<ICodigo_IcmsService>().To<Codigo_IcmsService>();
            //Bind<IClassificacao_fiscalService>().To<Classificacao_fiscalService>();
            //Bind<IRamo_atividadeService>().To<Ramo_atividadeService>();
            //Bind<ICarga_trib_media_st_icmsService>().To<Carga_trib_media_st_icmsService>();

            //#endregion

            //#region Comercial

            //Bind<IRota_pracaService>().To<Rota_pracaService>();
            //Bind<ISite_enderecoService>().To<Site_enderecoService>();
            //Bind<IModos_entregaService>().To<Modos_entregaService>();
            //Bind<IMultasService>().To<MultasService>();
            //Bind<ICanal_vendaService>().To<Canal_vendaService>();
            //Bind<IJurosService>().To<JurosService>();
            //Bind<ICliente_fornecedorService>().To<Cliente_fornecedorService>();
            //Bind<ICliente_fornecedor_arquivoService>().To<Cliente_fornecedor_arquivoService>();
            //Bind<ICliente_fornecedor_contatoService>().To<Cliente_fornecedor_contatoService>();
            //Bind<ICliente_fornecedor_EnderecoService>().To<Cliente_fornecedor_EnderecoService>();
            //Bind<ICliente_fornecedor_fiscalService>().To<Cliente_fornecedor_fiscalService>();
            //Bind<ICliente_Fornecedor_ObservacaoService>().To<Cliente_Fornecedor_ObservacaoService>();
            //Bind<ICliente_fornecedor_produtoService>().To<Cliente_fornecedor_produtoService>();
            //Bind<ICliente_fornecedor_representanteService>().To<Cliente_fornecedor_representanteService>();
            //Bind<IPlano_pagamentoService>().To<Plano_pagamentoService>();
            //Bind<IPlano_pagamento_linhasService>().To<Plano_pagamento_linhasService>();
            //Bind<ILista_Preco_PaiService>().To<Lista_Preco_PaiService>();
            //Bind<ILista_precoService>().To<Lista_precoService>();
            //Bind<IProdutoService>().To<ProdutoService>();
            //Bind<ITipo_produtoService>().To<Tipo_produtoService>();
            //Bind<IProduto_localizacaoService>().To<Produto_localizacaoService>();
            //Bind<IProduto_Fornecedor_HomologadoService>().To<Produto_Fornecedor_HomologadoService>();
            //Bind<IProduto_RevisaoService>().To<Produto_RevisaoService>();

            //#endregion

            //#region Gerais

            //Bind<IDepositoService>().To<DepositoService>();
            //Bind<ICondicoes_entregaService>().To<Condicoes_entregaService>();
            //Bind<IRotaService>().To<RotaService>();
            //Bind<ICidadeService>().To<CidadeService>();
            //Bind<IUFService>().To<UFService>();
            //Bind<IEmpresaService>().To<EmpresaService>();
            //Bind<IRegiaoService>().To<RegiaoService>();
            //Bind<ISetorService>().To<SetorService>();
            //Bind<IContatoService>().To<ContatoService>();
            //Bind<ICargoService>().To<CargoService>();
            //Bind<IDepartamentoService>().To<DepartamentoService>();
            //Bind<ICalendarioService>().To<CalendarioService>();
            //Bind<ICalendario_DetalheService>().To<Calendario_DetalheService>();
            //Bind<ITransportadorService>().To<TransportadorService>();
            //Bind<IFuncionarioService>().To<FuncionarioService>();
            //Bind<IUnidade_medidaService>().To<Unidade_medidaService>();
            //Bind<ITipo_servicoService>().To<Tipo_servicoService>();
            //Bind<IFabricanteService>().To<FabricanteService>();
            //Bind<IFamilia_ProdutoService>().To<Familia_produtoService>();
            //Bind<IFamilia_Produto_ClassesService>().To<Familia_Produto_ClassesService>();
            //Bind<IConversaoService>().To<ConversaoService>();
            //Bind<ISiteService>().To<SiteService>();
            //Bind<ICondicao_pagamentoService>().To<Condicao_pagamentoService>();
            //Bind<IContato_EnderecoService>().To<Contato_EnderecoService>();
            //Bind<IFuncionario_Margem_Lucro_ComissaoService>().To<Funcionario_Margem_Lucro_ComissaoService>();
            //Bind<IFuncionario_EnderecoService>().To<Funcionario_EnderecoService>();
            //Bind<IFuncionario_Comissao_ProdutoService>().To<Funcionario_Comissao_ProdutoService>();
            //Bind<IFuncionario_ArquivoService>().To<Funcionario_ArquivoService>();
            //Bind<IFuncionario_CertificacaoService>().To<Funcionario_CertificacaoService>();
            //Bind<IAcessoService>().To<AcessoService>();
            //Bind<ILog_ScriptsService>().To<Log_ScriptsService>();
            //Bind<IOrcamento_ideService>().To<Orcamento_ideService>();
            //Bind<ITransportador_VeiculosService>().To<Transportador_VeiculosService>();
            //Bind<ITransportador_MotoristaService>().To<Transportador_MotoristaService>();
            //Bind<ITransportador_ContatoService>().To<Transportador_ContatoService>();
            //Bind<ITransportador_EnderecoService>().To<Transportador_EnderecoService>();
            //Bind<IEmpresa_EnderecoService>().To<Empresa_enderecoService>();

            //#endregion

            //#region Financeiro

            //Bind<IBancoService>().To<BancoService>();
            //Bind<IAgenciaService>().To<AgenciaService>();
            //Bind<IAgencia_ContatoService>().To<Agencia_ContatoService>();
            //Bind<IAgencia_EnderecoService>().To<Agencia_EnderecoService>();
            //Bind<IMoedaService>().To<MoedaService>();
            //Bind<IDescontos_AvistaService>().To<Descontos_AvistaService>();
            //Bind<IDia_PagamentoService>().To<Dia_PagamentoService>();
            //Bind<IDia_Pagamento_LinhasService>().To<Dia_Pagamento_LinhasService>();
            //Bind<IConta_bancariaService>().To<Conta_bancariaService>();

            //#endregion

            //#region Parametros

            //Bind<IParametro_EstoqueService>().To<Parametro_EstoqueService>();
            //Bind<IParametro_CustosService>().To<Parametro_CustosService>();
            //Bind<IParametro_ComprasService>().To<Parametro_ComprasService>();
            //Bind<IParametro_Ordem_ProducaoService>().To<Parametro_Ordem_ProducaoService>();
            //Bind<IParametro_FiscalService>().To<Parametro_FiscalService>();
            //Bind<IParametro_ComercialService>().To<Parametro_ComercialService>();
            //Bind<IParametro_FinanceiroService>().To<Parametro_FinanceiroService>();

            //#endregion

            //#region CRM

            //Bind<IDecisaoService>().To<DecisaoService>();
            //Bind<IPersonalidadeService>().To<PersonalidadeService>();
            //Bind<IFidelidadeService>().To<FidelidadeService>();
            //#endregion
        }

    }
}
