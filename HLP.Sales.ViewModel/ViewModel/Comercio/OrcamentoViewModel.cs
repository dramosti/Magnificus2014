using HLP.Base.ClassesBases;
using HLP.Components.Model.Models;
using HLP.Entries.Model.Fiscal;
using HLP.Entries.Model.Models.Comercial;
using HLP.Entries.Model.Models.Financeiro;
using HLP.Entries.Model.Models.Fiscal;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.Model.Models.Transportes;
using HLP.Sales.Model.Models.Comercial;
using HLP.Sales.ViewModel.Commands.Comercio;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace HLP.Sales.ViewModel.ViewModel.Comercio
{
    public class OrcamentoViewModel : ViewModelBase<Orcamento_ideModel>
    {
        #region Icommands
        public ICommand commandSalvar { get; set; }
        public ICommand commandDeletar { get; set; }
        public ICommand commandNovo { get; set; }
        public ICommand commandAlterar { get; set; }
        public ICommand commandCancelar { get; set; }
        public ICommand commandCopiar { get; set; }
        public ICommand commandPesquisar { get; set; }
        public ICommand navegarCommand { get; set; }
        public ICommand aprovarDescontosCommand { get; set; }
        public ICommand alterarStatusItenCommand { get; set; }
        public ICommand gerarVersaoCommand { get; set; }
        public ICommand moveItensCommand { get; set; }

        #endregion

        OrcamentoCommands comm = null;

        public OrcamentoViewModel()
        {
            ResourceDictionary resource = new ResourceDictionary
            {
                Source = new Uri("/HLP.Comum.Resources;component/Styles/Sales/Orcamento/Template/Buttons_Shurtcut.xaml", UriKind.RelativeOrAbsolute)
            };

            comm = new OrcamentoCommands(objViewModel: this);

            Button btnAprovarDescontos = new Button();
            btnAprovarDescontos.Content = "Aprovar descontos?";
            btnAprovarDescontos.Command = this.aprovarDescontosCommand;
            btnAprovarDescontos.Template = resource["ControlTemplateBotaoAprovar"] as ControlTemplate;

            Button btnEnviarItens = new Button();
            btnEnviarItens.Template = resource["ControlTemplateBotaoEnviar"] as ControlTemplate;

            Button btnConfirmarItens = new Button();
            btnConfirmarItens.Content = "Confirmar Itens";
            btnConfirmarItens.Command = this.alterarStatusItenCommand;
            btnConfirmarItens.CommandParameter = 'c';
            btnConfirmarItens.Template = resource["ControlTemplateBotaoConfirmar"] as ControlTemplate;

            Button btnItensPerdidos = new Button();
            btnItensPerdidos.Content = "Definir Itens Perdidos";
            btnItensPerdidos.Command = this.alterarStatusItenCommand;
            btnItensPerdidos.CommandParameter = 'p';

            Button btnItensCancelados = new Button();
            btnItensCancelados.Content = "Definir Itens Cancelados";
            btnItensCancelados.Command = this.alterarStatusItenCommand;
            btnItensCancelados.CommandParameter = 'e';
            btnItensCancelados.Template = resource["ControlTemplateBotaoCancelado"] as ControlTemplate;

            Button btnGerarVersao = new Button();
            btnGerarVersao.Content = "Gerar Nova Versão";
            btnGerarVersao.Command = this.gerarVersaoCommand;

            this.Botoes.Children.Add(element: btnAprovarDescontos);
            this.Botoes.Children.Add(element: btnEnviarItens);
            this.Botoes.Children.Add(element: btnConfirmarItens);
            this.Botoes.Children.Add(element: btnItensPerdidos);
            this.Botoes.Children.Add(element: btnItensCancelados);
            this.Botoes.Children.Add(element: btnGerarVersao);
        }

        private Orcamento_ItemModel _currentItem;

        public Orcamento_ItemModel currentItem
        {
            get { return _currentItem; }
            set
            {
                if (value != null)
                {
                    _currentItem = value;                    
                    base.NotifyPropertyChanged(propertyName: "currentItem");
                }
            }
        }

        #region GetObjectsInModel

        public EmpresaModel GetEmpresa(int idEmpresa)
        {
            return comm.GetEmpresa(idEmpresa: idEmpresa);
        }

        public Cliente_fornecedorModel GetCliente(int idCliente)
        {
            return comm.GetCliente(idCliente: idCliente);
        }

        public FuncionarioModel GetFuncionario(int idFuncionario)
        {
            return comm.GetFuncionario(idFuncionario: idFuncionario);
        }

        public List<modelToComboBox> GetOperacoesValidas(int idTipoDocumento)
        {
            return comm.GetOperacoesValidas(idTipoDocumento: idTipoDocumento);
        }

        public Familia_produtoModel GetFamiliaProduto(int idFamiliaProduto)
        {
            return comm.GetFamiliaProduto(idFamiliaProduto: idFamiliaProduto);
        }

        public ProdutoModel GetProduto(int idProduto)
        {
            return comm.GetProduto(idProduto: idProduto);
        }

        public List<modelToComboBox> GetListUnidadeMedida(int idProduto)
        {
            return comm.GetListUnidadeMedida(idProduto: idProduto);
        }

        public Lista_Preco_PaiModel GetListaPreco(int idListaPreco)
        {
            return comm.GetListaPreco(idListaPreco: idListaPreco);
        }

        public Descontos_AvistaModel GetDesconto(int idDesconto)
        {
            return comm.GetDesconto(idDesconto: idDesconto);
        }

        public Condicao_pagamentoModel GetCondicaoPagamento(int idCondicaoPagamento)
        {
            return comm.GetCondicaoPagamento(idCondicaoPagamento: idCondicaoPagamento);
        }

        public CidadeModel GetCidade(int idCidade)
        {
            return comm.GetCidade(idCidade: idCidade);
        }

        public Tipo_operacaoModel GetTipoOperacao(int idTipoOperacao)
        {
            return comm.GetTipoOperacao(idTipoOperacao: idTipoOperacao);
        }

        public Classificacao_fiscalModel GetClassificacaoFiscal(int idClassificacaoFiscal)
        {
            return comm.GetClassificacaoFiscal(idClassificacaoFiscal: idClassificacaoFiscal);
        }

        public Codigo_IcmsModel GetCodigoIcmsByUf(int idCodigoIcmsPai, int idUf)
        {
            return comm.GetCodigoIcmsByUf(idCodigoIcmsPai: idCodigoIcmsPai, idUf: idUf);
        }

        public Ramo_atividadeModel GetRamoAtividade(int idRamoAtividade)
        {
            return comm.GetRamoAtividade(idRamoAtividade: idRamoAtividade);
        }

        public UFModel GetUf(int idUf)
        {
            return comm.GetUf(idUf: idUf);
        }

        public Unidade_medidaModel GetUnidadeMedida(int idUnidadeMedida)
        {
            return comm.GetUnidadeMedida(idUnidadeMedida: idUnidadeMedida);
        }

        public TransportadorModel GetTransportador(int idTransportador)
        {
            return comm.GetTransportador(idTransportador: idTransportador);
        }

        public Tipo_documentoModel GetTipoDocumento(int idTipoDocumento)
        {
            return comm.GetTipoDocumento(idTipoDocumento: idTipoDocumento);
        }

        #endregion

        #region Métodos Públicos
        public void AtualizarTotais()
        {
            if (currentModel != null)
                this.currentModel.orcamento_Total_Impostos.CalcularTotais();
        }

        #endregion
    }
}
