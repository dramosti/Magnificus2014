using HLP.Base.ClassesBases;
using HLP.Components.Model.Models;
using HLP.Comum.ViewModel.ViewModel;
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
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace HLP.Sales.ViewModel.ViewModel.Comercio
{
    public class OrcamentoViewModel : viewModelComum<Orcamento_ideModel>
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
        public ICommand itensRepresentantesCommands { get; set; }

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

            this.itensComissoes = new ItensComissoes();

            this.getCliente = comm.GetCliente;

        }

        private Func<int, object> _getCliente;

        public Func<int, object> getCliente
        {
            get { return _getCliente; }
            set
            {
                _getCliente = value;
                base.NotifyPropertyChanged(propertyName: "getCliente");
            }
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

        public int GetIdSiteByDeposito(int idDeposito)
        {
            return comm.GetIdSiteByDeposito(idDeposito: idDeposito);
        }

        #endregion

        #region Métodos Públicos
        public void AtualizarTotais()
        {
            if (currentModel != null)
                this.currentModel.orcamento_Total_Impostos.CalcularTotais();
        }

        private int? _idFuncionarioRepresentante;
        public int? idFuncionarioRepresentante
        {
            get { return _idFuncionarioRepresentante; }
            set
            {
                _idFuncionarioRepresentante = value;

                base.NotifyPropertyChanged(propertyName: "idFuncionarioRepresentante");

            }
        }

        private ItensComissoes _itensComissoes;

        public ItensComissoes itensComissoes
        {
            get { return _itensComissoes; }
            set
            {
                _itensComissoes = value;
                base.NotifyPropertyChanged(propertyName: "itensComissoes");
            }
        }

        public void GenerateItensComissoes()
        {
            if (this.currentModel != null)
            {
                CollectionViewSource cvs = HLP.Base.Static.Sistema.GetOpenWindow(xName: "WinOrcamento")
                    .FindResource(resourceKey: "cvsComissoes") as CollectionViewSource;

                if (cvs != null)
                {
                    (cvs.Source as ObservableCollection<ItensComissoes>).Clear();

                    foreach (Orcamento_ItemModel orcamentoItem in this.currentModel.lOrcamento_Itens)
                    {
                        foreach (Orcamento_Item_RepresentantesModel orcamentoItemRepresentante in orcamentoItem.lOrcamentoItemsRepresentantes)
                        {
                            (cvs.Source as ObservableCollection<ItensComissoes>).Add(item: new ItensComissoes
                                {
                                    xProduto = orcamentoItem.nItem + " - " + (orcamentoItem.objProduto != null ?
                                    orcamentoItem.objProduto.xComercial : ""),
                                    xRepresentante = orcamentoItemRepresentante.idRepresentante.ToString() + " - " + comm.GetFuncionario(idFuncionario:
                                    orcamentoItemRepresentante.idRepresentante).xNome,
                                    pComissao = orcamentoItemRepresentante.pComissao ?? 0,
                                    vComissao = orcamentoItem.vTotalItem * (orcamentoItemRepresentante.pComissao ?? 0) / 100
                                });
                        }
                    }
                }
            }
        }

        public decimal GetPorcItems(object lItensGroup)
        {
            return (lItensGroup as ObservableCollection<ItensComissoes>).Sum(i => i.vComissao);
        }

        #endregion
    }

    public class ItensComissoes : ObservableCollection<ItensComissoes>, INotifyPropertyChanged
    {
        public ItensComissoes()
        {

        }


        private string _xProduto;

        public string xProduto
        {
            get { return _xProduto; }
            set
            {
                _xProduto = value;
                this.NotifyPropertyChanged(propertyName: "xProduto");
            }
        }

        private decimal _pComissao;

        public decimal pComissao
        {
            get { return _pComissao; }
            set
            {
                _pComissao = value;
                this.NotifyPropertyChanged(propertyName: "pComissao");
            }
        }


        private decimal _vComissao;

        public decimal vComissao
        {
            get { return _vComissao; }
            set
            {
                _vComissao = value;
                this.NotifyPropertyChanged(propertyName: "vComissao");
            }
        }



        private string _xRepresentante;

        public string xRepresentante
        {
            get { return _xRepresentante; }
            set
            {
                _xRepresentante = value;
                this.NotifyPropertyChanged(propertyName: "xRepresentante");
            }
        }

        #region NotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
