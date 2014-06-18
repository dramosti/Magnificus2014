﻿using HLP.Base.ClassesBases;
using HLP.Base.EnumsBases;
using HLP.Base.Modules;
using HLP.Base.Static;
using HLP.Components.Model.Models;
using HLP.Components.Services;
using HLP.Comum.View.Formularios;
using HLP.Entries.Model.Fiscal;
using HLP.Entries.Model.Models.Comercial;
using HLP.Entries.Model.Models.Financeiro;
using HLP.Entries.Model.Models.Fiscal;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.Model.Models.Transportes;
using HLP.Entries.Services.Comercial;
using HLP.Entries.Services.Financeiro;
using HLP.Entries.Services.Fiscal;
using HLP.Entries.Services.Gerais;
using HLP.Entries.Services.Transportes;
using HLP.Sales.Model.Models.Comercial;
using HLP.Sales.Services.Comercial;
using HLP.Sales.ViewModel.ViewModel.Comercio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Threading;

namespace HLP.Sales.ViewModel.Commands.Comercio
{
    public class OrcamentoCommands
    {
        OrcamentoViewModel objViewModel;
        BackgroundWorker bWorkerAcoes;
        OrcamentoService objServico;
        ClienteService objClienteService;
        FuncionarioService objFuncionarioService;
        Tipo_Documento_Operacao_ValidaService objTipoDocumentoOperacaoValidaService;
        FillComboBoxService objFillComboBoxService;
        FamiliaProdutoService objFamiliaProdutoService;
        ProdutoService objProdutoService;
        Lista_PrecoService objListaPrecoService;
        Descontos_AvistaService objDescontoService;
        Condicao_PagamentoService objCondicaoPagamentoService;
        EmpresaService objEmpresaService;
        CidadeService objCidadeService;
        Tipo_OperacaoService objTipoOperacaoService;
        Classificacao_FiscalService objClassificacaoFiscalService;
        Codigo_IcmsService objCodigoIcmsService;
        Ramo_AtividadeService objRamoAtividadeService;
        UfService objUfService;
        Unidade_MedidaService objUnidadeMedidaService;
        TransportadoraService objTransportadoraService;
        Tipo_DocumentoService objTipoDocumentoService;

        public OrcamentoCommands(OrcamentoViewModel objViewModel)
        {
            objServico = new OrcamentoService();
            objClienteService = new ClienteService();
            objFuncionarioService = new FuncionarioService();
            objTipoDocumentoOperacaoValidaService = new Tipo_Documento_Operacao_ValidaService();
            objEmpresaService = new EmpresaService();
            objCidadeService = new CidadeService();
            this.objFillComboBoxService = new FillComboBoxService();
            this.objFamiliaProdutoService = new FamiliaProdutoService();
            this.objProdutoService = new ProdutoService();
            this.objListaPrecoService = new Lista_PrecoService();
            this.objDescontoService = new Descontos_AvistaService();
            this.objCondicaoPagamentoService = new Condicao_PagamentoService();
            this.objTipoOperacaoService = new Tipo_OperacaoService();
            this.objClassificacaoFiscalService = new Classificacao_FiscalService();
            this.objCodigoIcmsService = new Codigo_IcmsService();
            this.objRamoAtividadeService = new Ramo_AtividadeService();
            this.objUfService = new UfService();
            this.objUnidadeMedidaService = new Unidade_MedidaService();
            this.objTransportadoraService = new TransportadoraService();
            this.objTipoDocumentoService = new Tipo_DocumentoService();

            this.objViewModel = objViewModel;

            this.objViewModel.commandDeletar = new RelayCommand(paramExec => Delete(),
                    paramCanExec => this.DeleteCanExec());

            this.objViewModel.commandSalvar = new RelayCommand(paramExec => Save(_panel: paramExec),
                    paramCanExec => SaveCanExecute(paramCanExec));

            this.objViewModel.commandNovo = new RelayCommand(execute: paramExec => this.Novo(_panel: paramExec),
                   canExecute: paramCanExec => this.NovoCanExecute());

            this.objViewModel.commandAlterar = new RelayCommand(execute: paramExec => this.Alterar(_panel: paramExec),
                    canExecute: paramCanExec => this.AlterarCanExecute());

            this.objViewModel.commandCancelar = new RelayCommand(execute: paramExec => this.Cancelar(),
                    canExecute: paramCanExec => this.CancelarCanExecute());

            this.objViewModel.commandCopiar = new RelayCommand(execute: paramExec => this.Copy(),
            canExecute: paramCanExec => this.CopyCanExecute());

            this.objViewModel.commandPesquisar = new RelayCommand(execute: paramExec => this.ExecPesquisa(paramExec),
                        canExecute: paramCanExec => true);

            this.objViewModel.navegarCommand = new RelayCommand(execute: paramExec => this.Navegar(ContentBotao: paramExec),
                canExecute: paramCanExec => objViewModel.navegarBaseCommand.CanExecute(paramCanExec));

            this.objViewModel.aprovarDescontosCommand = new RelayCommand(execute: paramExec => this.AprovarDescontosExecute(),
                canExecute: paramCanExec => this.AprovarDescontosCanExecute());

            this.objViewModel.alterarStatusItenCommand = new RelayCommand(execute: paramExec => this.AlterarStatusExecute(o: paramExec),
                canExecute: paramCanExec => this.AlterarStatusCanExecute());

            this.objViewModel.gerarVersaoCommand = new RelayCommand(execute: ex => this.GerarVersaoExecute(),
                canExecute: canEx => this.GerarVersaoCanExecute());

            this.objViewModel.moveItensCommand = new RelayCommand(execute: ex => this.MoveExec(xAction: ex),
                canExecute: canExec => this.MoveCanExec(xAcao: canExec));

            this.objViewModel.itensRepresentantesCommands = new RelayCommand(execute: ex => this.ItensRepresentantesExecute());

            this.objViewModel.bWorkerPesquisa = new BackgroundWorker();
            this.objViewModel.bWorkerPesquisa.DoWork += this.getOrcamento;
            this.objViewModel.bWorkerPesquisa.RunWorkerCompleted += this.bw_RunWorkerCompleted;
        }

        #region Implementação Commands

        public void ItensRepresentantesExecute()
        {
            object ret = Sistema.ExecuteMethodByReflection(xNamespace: "HLP.Sales.View.WPF", xType: "WinItensRepresentantes", xMethod: "WindowShowDialog",
                parameters: new object[] { this.objViewModel.currentItem.lOrcamentoItemsRepresentantes });

            if (ret != null)
            {
                this.objViewModel.currentItem.lOrcamentoItemsRepresentantes = new ObservableCollectionBaseCadastros<Orcamento_Item_RepresentantesModel>(
                    list: (ret as OrcamentoItensRepresentanteViewModel)
                    .orcamentoItensRepresentantes);
                this.objViewModel.currentItem.setxRepresentante();
            }
        }

        public void MoveExec(object xAction)
        {
            int index = this.objViewModel.currentModel.lOrcamento_Itens.IndexOf(item: this.objViewModel.currentItem);

            switch (xAction.ToString())
            {
                case "first":
                    {
                        this.objViewModel.currentItem = this.objViewModel.currentModel.lOrcamento_Itens.First();
                    }; break;
                case "last":
                    {
                        this.objViewModel.currentItem = this.objViewModel.currentModel.lOrcamento_Itens.Last();
                    }; break;
                case "next":
                    {
                        if ((index + 1) < this.objViewModel.currentModel.lOrcamento_Itens.Count)
                        {
                            this.objViewModel.currentItem = this.objViewModel.currentModel.lOrcamento_Itens.ElementAt(index: index + 1);
                        }
                        else
                            this.objViewModel.currentItem = this.objViewModel.currentModel.lOrcamento_Itens.Last();
                    }; break;
                case "prior":
                    {
                        if (index > 0)
                        {
                            this.objViewModel.currentItem = this.objViewModel.currentModel.lOrcamento_Itens.ElementAt(index: index - 1);
                        }
                        else
                        {
                            this.objViewModel.currentItem = this.objViewModel.currentModel.lOrcamento_Itens.First();
                        }
                    }; break;
            }
        }

        private bool MoveCanExec(object xAcao)
        {
            if (this.objViewModel.currentModel == null)
                return false;

            if (this.objViewModel.currentModel.lOrcamento_Itens == null)
                return false;

            if (this.objViewModel.currentModel.lOrcamento_Itens.Count == 0)
                return false;

            if (this.objViewModel.currentItem == null)
                return false;

            return true;
        }

        public void Save(object _panel)
        {
            try
            {
                foreach (int item in this.objViewModel.currentModel.lOrcamento_Itens.idExcluidos)
                {
                    this.objViewModel.currentModel.lOrcamento_Itens.Add(item:
                        new Orcamento_ItemModel
                        {
                            idOrcamentoItem = item,
                            status = statusModel.excluido
                        });
                }

                this.objViewModel.currentModel.bTodos = true;
                objViewModel.SetFocusFirstTab(_panel as Panel);
                bWorkerAcoes = new BackgroundWorker();
                bWorkerAcoes.DoWork += bwSalvar_DoWork;
                bWorkerAcoes.RunWorkerCompleted += bwSalvar_RunWorkerCompleted;
                bWorkerAcoes.RunWorkerAsync(_panel);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        void bwSalvar_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = e.Argument;
                this.objViewModel.currentModel = this.objServico.
                    Save(objModel: this.objViewModel.currentModel);
                this.IniciaCollection();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        void bwSalvar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    throw new Exception(message: e.Error.Message);
                }
                else
                {
                    this.objViewModel.salvarBaseCommand.Execute(parameter: null);
                    this.IniciaCollection();
                    this.objViewModel.currentModel.bTodos = true;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private bool SaveCanExecute(object objDependency)
        {
            if (objViewModel.currentModel == null || objDependency == null)
                return false;

            return (this.objViewModel.salvarBaseCommand.CanExecute(parameter: null)
                && this.objViewModel.IsValid(objDependency as Panel));
        }

        private void IniciaCollection()
        {
            if (this.objViewModel.currentModel != null)
            {
                if (this.objViewModel.currentModel.lOrcamento_Itens != null)
                    this.objViewModel.currentModel.lOrcamento_Itens.CollectionCarregada();
            }
        }

        public void Delete()
        {
            int iExcluir = (int)0;
            try
            {
                if (MessageBox.Show(messageBoxText: "Deseja excluir o cadastro?",
                    caption: "Excluir?", button: MessageBoxButton.YesNo, icon: MessageBoxImage.Question)
                    == MessageBoxResult.Yes)
                {
                    if (this.objServico.Delete(objModel: this.objViewModel.currentModel))
                    {
                        MessageBox.Show(messageBoxText: "Cadastro excluido com sucesso!", caption: "Ok",
                            button: MessageBoxButton.OK, icon: MessageBoxImage.Information);
                        iExcluir = (int)this.objViewModel.currentModel.idOrcamento;
                        this.objViewModel.currentModel = null;
                    }
                    else
                    {
                        MessageBox.Show(messageBoxText: "Não foi possível excluir o cadastro!", caption: "Falha",
                            button: MessageBoxButton.OK, icon: MessageBoxImage.Exclamation);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.objViewModel.deletarBaseCommand.Execute(parameter: iExcluir);
                this.objViewModel.lItensHierarquia = new List<int>();
            }
        }

        private bool DeleteCanExec()
        {
            try
            {
                return this.objViewModel.deletarBaseCommand.CanExecute(null)
                    && !this.objServico.PossuiFilho(idOrcamento: this.objViewModel.currentModel.idOrcamento ?? 0);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Novo(object _panel)
        {
            this.objViewModel.currentModel = new Orcamento_ideModel();
            this.objViewModel.currentModel.dDataHora = DateTime.Now;
            this.objViewModel.novoBaseCommand.Execute(parameter: _panel);
            bWorkerAcoes = new BackgroundWorker();
            bWorkerAcoes.DoWork += bwNovo_DoWork;
            bWorkerAcoes.RunWorkerCompleted += bwNovo_RunWorkerCompleted;
            bWorkerAcoes.RunWorkerAsync(_panel);

        }
        void bwNovo_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Threading.Thread.Sleep(100);
            e.Result = e.Argument;
        }
        void bwNovo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            objViewModel.FocusToComponente(e.Result as Panel, HLP.Base.Static.Util.focoComponente.Segundo);
            this.objViewModel.currentModel.bTodos = true;
            Sistema.stSender = TipoSender.Sistema;
        }
        private bool NovoCanExecute()
        {
            return this.objViewModel.novoBaseCommand.CanExecute(parameter: null);
        }

        private void Alterar(object _panel)
        {
            this.objViewModel.alterarBaseCommand.Execute(parameter: _panel);
            bWorkerAcoes = new BackgroundWorker();
            bWorkerAcoes.DoWork += bwAlterar_DoWork;
            bWorkerAcoes.RunWorkerCompleted += bwAlterar_RunWorkerCompleted;
            bWorkerAcoes.RunWorkerAsync(_panel);
        }
        void bwAlterar_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Threading.Thread.Sleep(100);
            e.Result = e.Argument;
        }
        void bwAlterar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            objViewModel.FocusToComponente(e.Result as Panel, HLP.Base.Static.Util.focoComponente.Segundo);
            Sistema.stSender = TipoSender.Sistema;
        }
        private bool AlterarCanExecute()
        {
            return this.objViewModel.alterarBaseCommand.CanExecute(parameter: null)
                && !this.objServico.PossuiFilho(idOrcamento: this.objViewModel.currentModel.idOrcamento ?? 0);
        }

        private void Cancelar()
        {
            if (MessageBox.Show(messageBoxText: "Deseja realmente cancelar a transação?", caption: "Cancelar?", button: MessageBoxButton.YesNo, icon: MessageBoxImage.Question) == MessageBoxResult.No) return;
            this.PesquisarRegistro(this.objViewModel.currentID);
            this.objViewModel.cancelarBaseCommand.Execute(parameter: null);
        }
        private bool CancelarCanExecute()
        {
            return this.objViewModel.cancelarBaseCommand.CanExecute(parameter: null);
        }

        public void Copy()
        {
            try
            {
                BackgroundWorker bwCopy = new BackgroundWorker();
                bwCopy.DoWork += bwCopy_DoWork;
                bwCopy.RunWorkerCompleted += bwCopy_RunWorkerCompleted;
                bwCopy.RunWorkerAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        void bwCopy_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    throw new Exception(message: e.Error.Message);
                }
                else
                {
                    this.objViewModel.currentID = (int)e.Result;
                    this.getOrcamento(this, null);
                    this.objViewModel.copyBaseCommand.Execute(null);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void bwCopy_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result =
                    objServico.Copy(objModel: this.objViewModel.currentModel);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool CopyCanExecute()
        {
            return this.objViewModel.copyBaseCommand.CanExecute(null);
        }

        public void Navegar(object ContentBotao)
        {
            try
            {
                objViewModel.navegarBaseCommand.Execute(ContentBotao);
                this.PesquisarRegistro(this.objViewModel.currentID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExecPesquisa(object o)
        {
            int id = 0;

            if (o == null)
            {
                this.objViewModel.pesquisarBaseCommand.Execute(null);
                id = this.objViewModel.currentID;
            }
            else if (o.GetType() != typeof(string))
            {
                this.objViewModel.pesquisarBaseCommand.Execute(null);
                id = this.objViewModel.currentID;
            }
            else
                id = Convert.ToInt32(value: o);

            this.objViewModel.selectedId = id;
            this.PesquisarRegistro(id: id);
        }

        private void PesquisarRegistro(int id)
        {
            this.objViewModel.bWorkerPesquisa.RunWorkerAsync(argument: id);
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                throw new Exception(message: e.Error.Message);
            }
            else
            {
                this.IniciaCollection();
                this.objViewModel.currentModel = e.Result as Orcamento_ideModel;
                if (objViewModel.currentModel != null)
                {
                    this.objViewModel.currentModel.LoadListTipoDocumento();
                    this.objViewModel.currentModel.bTodos = true;

                    if (this.objViewModel.currentModel.lOrcamento_Itens != null)
                        this.objViewModel.currentItem = this.objViewModel.currentModel.lOrcamento_Itens.FirstOrDefault();

                    this.objViewModel.lItensHierarquia = this.objServico.GetIdVersoes(idOrcamento: this.objViewModel.currentModel.idOrcamento ?? 0);

                    this.objViewModel.GenerateItensComissoes();
                }
            }
        }

        private void getOrcamento(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = this.objServico.GetObjeto(id: this.objViewModel.currentID);
                //bool bCarregado = false;

                //Application.Current.Dispatcher.BeginInvoke((Action)(() =>
                //    {

                //        bCarregado = true;
                //    }));

                //while (!bCarregado)
                //{
                //    Thread.Sleep(millisecondsTimeout: 500);
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Implementação Commands de Funcionalidades

        private void GerarVersaoExecute()
        {
            this.objViewModel.currentModel = this.objServico.GerarVersao(objModel: this.objViewModel.currentModel);
            this.objViewModel.lItensHierarquia = this.objServico.GetIdVersoes(idOrcamento: this.objViewModel.currentModel.idOrcamento ?? 0);
        }

        private bool GerarVersaoCanExecute()
        {
            return !this.objViewModel.bIsEnabled && this.objViewModel.currentModel != null;
        }

        private void AlterarStatusExecute(object o)
        {
            Window form = GerenciadorModulo.Instancia.CarregaForm(nome: "StatusItensOrcamento",
                exibeForm: Base.InterfacesBases.TipoExibeForm.Modal);
            byte novoStatus = 0;

            //<ComboBoxItem>0-Criado</ComboBoxItem>
            //                                            <ComboBoxItem>1-Enviado</ComboBoxItem>
            //                                            <ComboBoxItem>2-Confirmado</ComboBoxItem>
            //                                            <ComboBoxItem>3-Perdido</ComboBoxItem>
            //                                            <ComboBoxItem>4-Cancelado</ComboBoxItem>

            if (((char)o) == 'c')
            {
                novoStatus = (form.DataContext as OrcamentoTrocarStatusViewModel).statusItens = 2;
            }
            else if (((char)o) == 'p')
            {
                novoStatus = (form.DataContext as OrcamentoTrocarStatusViewModel).statusItens = 3;

            }
            else if (((char)o) == 'e')
            {
                novoStatus = (form.DataContext as OrcamentoTrocarStatusViewModel).statusItens = 4;
            }

            (form.DataContext as OrcamentoTrocarStatusViewModel).lOrcamento_Itens = new System.Collections.ObjectModel.ObservableCollection<TrocaStatus_Orcamento_Itens>();

            foreach (var item in this.objViewModel.currentModel.lOrcamento_Itens.Where(
                i => i.stOrcamentoItem == 0 || i.stOrcamentoItem == 1).ToList())
            {
                (form.DataContext as OrcamentoTrocarStatusViewModel).lOrcamento_Itens.Add(
                    item: new TrocaStatus_Orcamento_Itens
                    {
                        codItem = (int)item.nItem,
                        codProduto = item.idProduto,
                        dataPrevEntrega = item.dConfirmacaoItem,
                        quantEnvPend = item.qProduto,
                        dataConf = DateTime.Now
                    });
            }

            if (form.ShowDialog() == true)
            {
                foreach (var item in ((form.DataContext) as OrcamentoTrocarStatusViewModel).lOrcamento_Itens)
                {
                    this.objViewModel.currentModel.lOrcamento_Itens.FirstOrDefault(i => i.nItem == item.codItem).dConfirmacaoItem =
                        item.dataConf;

                    this.objViewModel.currentModel.lOrcamento_Itens.FirstOrDefault(i => i.nItem == item.codItem).idMotivo = item.idMotivoPercaCanc;

                    if (item.quantItens == item.quantEnvPend)
                    {
                        this.objViewModel.currentModel.lOrcamento_Itens.FirstOrDefault(i => i.nItem == item.codItem).stOrcamentoItem =
                            this.objViewModel.currentModel.lOrcamento_Itens.FirstOrDefault(i => i.nItem == item.codItem).objImposto.stOrcamentoImpostos
                            = novoStatus;
                    }
                    else if (item.quantItens > 0)
                    {

                        decimal vFrete = this.objViewModel.currentModel.lOrcamento_Itens.FirstOrDefault(i => i.nItem == item.codItem).vFreteItem;
                        decimal vSeguro = this.objViewModel.currentModel.lOrcamento_Itens.FirstOrDefault(i => i.nItem == item.codItem).vSegurosItem;
                        decimal vOutrasDespesas = this.objViewModel.currentModel.lOrcamento_Itens.FirstOrDefault(i => i.nItem == item.codItem).vOutrasDespesasItem;
                        decimal qItem = this.objViewModel.currentModel.lOrcamento_Itens.FirstOrDefault(i => i.nItem == item.codItem).qProduto;

                        this.objViewModel.currentModel.lOrcamento_Itens.FirstOrDefault(i => i.nItem == item.codItem).qProduto = (item.quantEnvPend - item.quantItens);

                        this.objViewModel.currentModel.lOrcamento_Itens.FirstOrDefault(i => i.nItem == item.codItem).vFreteItem =
                            (this.objViewModel.currentModel.lOrcamento_Itens.FirstOrDefault(i => i.nItem == item.codItem).qProduto / qItem) *
                            vFrete;

                        this.objViewModel.currentModel.lOrcamento_Itens.FirstOrDefault(i => i.nItem == item.codItem).vSegurosItem =
                            (this.objViewModel.currentModel.lOrcamento_Itens.FirstOrDefault(i => i.nItem == item.codItem).qProduto / qItem) *
                            vSeguro;

                        this.objViewModel.currentModel.lOrcamento_Itens.FirstOrDefault(i => i.nItem == item.codItem).vOutrasDespesasItem =
                            (this.objViewModel.currentModel.lOrcamento_Itens.FirstOrDefault(i => i.nItem == item.codItem).qProduto / qItem) *
                            vOutrasDespesas;

                        Orcamento_ItemModel objItem = new Orcamento_ItemModel();
                        objItem =
                            this.objViewModel.currentModel.lOrcamento_Itens.FirstOrDefault(i => i.nItem == item.codItem).Clone() as Orcamento_ItemModel;

                        objItem.objImposto =
                            objItem.objImposto.Clone() as Orcamento_Item_ImpostosModel;
                        objItem.qProduto = item.quantItens;
                        objItem.vFreteItem = (objItem.qProduto / qItem) * vFrete;
                        objItem.vSegurosItem = (objItem.qProduto / qItem) * vSeguro;
                        objItem.vOutrasDespesasItem = (objItem.qProduto / qItem) * vOutrasDespesas;
                        objItem.stOrcamentoItem = novoStatus;
                        objItem.idOrcamentoItem = null;
                        objItem.nItem = this.objViewModel.currentModel.lOrcamento_Itens.Count;
                        objItem.objImposto.idOrcamentoTotalizadorImpostos = null;
                        objItem.objImposto.stOrcamentoImpostos = novoStatus;
                        objItem.objImposto.nItem = objItem.nItem;

                        objItem.status = objItem.objImposto.status
                            = statusModel.criado;

                        this.objViewModel.currentModel.lOrcamento_Itens.Add(item: objItem);
                    }
                }
            }
        }

        private bool AlterarStatusCanExecute()
        {
            if (!this.objViewModel.bIsEnabled)
                return false;

            if (this.objViewModel.currentModel != null)
                if (this.objViewModel.currentModel.lOrcamento_Itens != null)
                    if (this.objViewModel.currentModel.lOrcamento_Itens.Count(i => i.stOrcamentoItem == 0 ||
                        i.stOrcamentoItem == 1) > 0)
                        return true;

            return false;
        }

        private void AprovarDescontosExecute()
        {
            if ((bool)Sistema.ExecuteMethodByReflection(xNamespace: "HLP.Comum.View.WPF",
                                                xType: "wdSenhaSupervisor", xMethod: "WindowShowDialog", parameters: new object[] { }))
            {
                foreach (var item in this.objViewModel.currentModel.lOrcamento_Itens)
                {
                    item.bPermitePorcentagem = true;
                    item.ValidateProperty(columnName: "pDesconto");
                    item.status = statusModel.alterado;
                }

                Window wd = Sistema.GetOpenWindow(xName: "WinOrcamento");

                if (wd != null)
                {
                    CollectionViewSource lItens = wd.FindResource("cvsItens") as CollectionViewSource;
                    lItens.View.Refresh();
                }
            }
        }

        private bool AprovarDescontosCanExecute()
        {

            if (this.objViewModel.bIsEnabled)
            {
                if (this.objViewModel.currentModel.lOrcamento_Itens.Count(i => !i.bPermitePorcentagem) > 0)
                    return true;
            }
            return false;
        }

        #endregion

        #region Métodos para utilização via Model

        public EmpresaModel GetEmpresa(int idEmpresa)
        {
            return objEmpresaService.GetObject(id: idEmpresa);
        }

        public Cliente_fornecedorModel GetCliente(int idCliente)
        {
            return objClienteService.GetObjeto(id: idCliente);
        }

        public FuncionarioModel GetFuncionario(int idFuncionario)
        {
            return objFuncionarioService.GetObject(id: idFuncionario, bGetChild: false) ?? new FuncionarioModel();
        }

        public List<modelToComboBox> GetOperacoesValidas(int idTipoDocumento)
        {
            return objFillComboBoxService.GetAllValuesToComboBox(sNameView: "getTipoOperacaoValidaToComboBoxOrcamento",
                sParameter: idTipoDocumento.ToString());
        }

        public Familia_produtoModel GetFamiliaProduto(int idFamiliaProduto)
        {
            return objFamiliaProdutoService.GetObjeto(id: idFamiliaProduto);
        }

        public ProdutoModel GetProduto(int idProduto)
        {
            return objProdutoService.GetObjeto(id: idProduto);
        }

        public List<modelToComboBox> GetListUnidadeMedida(int idProduto)
        {
            return this.objFillComboBoxService.GetAllValuesToComboBox(
                sNameView: "getUnidadeMedidaToComboBox", sParameter: idProduto.ToString());
        }

        public Lista_Preco_PaiModel GetListaPreco(int idListaPreco)
        {
            return this.objListaPrecoService.GetObjeto(id: idListaPreco);
        }

        public Descontos_AvistaModel GetDesconto(int idDesconto)
        {
            return this.objDescontoService.GetObject(id: idDesconto);
        }

        public Condicao_pagamentoModel GetCondicaoPagamento(int idCondicaoPagamento)
        {
            return this.objCondicaoPagamentoService.GetObject(id: idCondicaoPagamento);
        }

        public CidadeModel GetCidade(int idCidade)
        {
            return this.objCidadeService.GetObject(id: idCidade);
        }

        public Tipo_operacaoModel GetTipoOperacao(int idTipoOperacao)
        {
            return this.objTipoOperacaoService.GetObject(id: idTipoOperacao);
        }

        public Classificacao_fiscalModel GetClassificacaoFiscal(int idClassificacaoFiscal)
        {
            return this.objClassificacaoFiscalService.GetObject(id: idClassificacaoFiscal);
        }

        public Codigo_IcmsModel GetCodigoIcmsByUf(int idCodigoIcmsPai, int idUf)
        {
            return this.objCodigoIcmsService.GetObjectByUf(id: idCodigoIcmsPai, idUf: idUf);
        }

        public Ramo_atividadeModel GetRamoAtividade(int idRamoAtividade)
        {
            return this.objRamoAtividadeService.GetObject(id: idRamoAtividade);
        }

        public UFModel GetUf(int idUf)
        {
            return this.objUfService.GetObject(id: idUf);
        }

        public Unidade_medidaModel GetUnidadeMedida(int idUnidadeMedida)
        {
            return this.objUnidadeMedidaService.GetObject(id: idUnidadeMedida);
        }

        public TransportadorModel GetTransportador(int idTransportador)
        {
            return this.objTransportadoraService.GetObject(id: idTransportador);
        }

        public Tipo_documentoModel GetTipoDocumento(int idTipoDocumento)
        {
            return this.objTipoDocumentoService.GetObject(id: idTipoDocumento);
        }

        #endregion
    }
}
