using HLP.Comum.Infrastructure.Static;
using HLP.Comum.Resources.Util;
using HLP.Comum.View.Formularios;
using HLP.Comum.ViewModel.Commands;
using HLP.Sales.Model.Models.Comercial;
using HLP.Sales.ViewModel.ViewModel.Comercio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HLP.Sales.ViewModel.Commands.Comercio
{
    public class OrcamentoCommands
    {
        OrcamentoViewModel objViewModel;
        sales_OrcamentoService.IserviceSales_OrcamentoClient servico = new sales_OrcamentoService.IserviceSales_OrcamentoClient();
        BackgroundWorker bWorkerAcoes;
        Window wd = null;

        public OrcamentoCommands(OrcamentoViewModel objViewModel)
        {

            this.objViewModel = objViewModel;

            this.objViewModel.commandDeletar = new RelayCommand(paramExec => Delete(),
                    paramCanExec => objViewModel.deletarBaseCommand.CanExecute(null));

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

            this.objViewModel.commandPesquisar = new RelayCommand(execute: paramExec => this.ExecPesquisa(),
                        canExecute: paramCanExec => true);

            this.objViewModel.navegarCommand = new RelayCommand(execute: paramExec => this.Navegar(ContentBotao: paramExec),
                canExecute: paramCanExec => objViewModel.navegarBaseCommand.CanExecute(paramCanExec));

            this.objViewModel.aprovarDescontosCommand = new RelayCommand(execute: paramExec => this.AprovarDescontosExecute(),
                canExecute: paramCanExec => this.AprovarDescontosCanExecute());
        }

        #region Implementação Commands

        public void Save(object _panel)
        {
            try
            {
                foreach (int item in this.objViewModel.currentModel.lOrcamento_Itens.idExcluidos)
                {
                    this.objViewModel.currentModel.lOrcamento_Itens.Add(item:
                        new Orcamento_ItemModel
                        {
                            idOrcamento = item,
                            status = Comum.Resources.RecursosBases.statusModel.excluido
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
                this.objViewModel.currentModel = this.servico.Save(objModel: this.objViewModel.currentModel);
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
                    this.objViewModel.salvarBaseCommand.Execute(parameter: e.Result as Panel);
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
                this.objViewModel.currentModel.lOrcamento_Item_Impostos.CollectionCarregada();
                this.objViewModel.currentModel.lOrcamento_Itens.CollectionCarregada();
            }

        }

        public void Delete()
        {
            try
            {
                int iExcluir = (int)this.objViewModel.currentModel.idOrcamento;
                if (MessageBox.Show(messageBoxText: "Deseja excluir o cadastro?",
                    caption: "Excluir?", button: MessageBoxButton.YesNo, icon: MessageBoxImage.Question)
                    == MessageBoxResult.Yes)
                {
                    if (servico.Delete(objModel: objViewModel.currentModel))
                    {
                        MessageBox.Show(messageBoxText: "Cadastro excluido com sucesso!", caption: "Ok",
                            button: MessageBoxButton.OK, icon: MessageBoxImage.Information);
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
                this.objViewModel.deletarBaseCommand.Execute(parameter: null);
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
            objViewModel.FocusToComponente(e.Result as Panel, Comum.Infrastructure.Static.Util.focoComponente.Segundo);
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
            objViewModel.FocusToComponente(e.Result as Panel, Comum.Infrastructure.Static.Util.focoComponente.Segundo);
        }
        private bool AlterarCanExecute()
        {
            return this.objViewModel.alterarBaseCommand.CanExecute(parameter: null);
        }

        private void Cancelar()
        {
            if (MessageBox.Show(messageBoxText: "Deseja realmente cancelar a transação?", caption: "Cancelar?", button: MessageBoxButton.YesNo, icon: MessageBoxImage.Question) == MessageBoxResult.No) return;
            this.PesquisarRegistro();
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
                    servico.Copy(objModel: this.objViewModel.currentModel);
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
                this.PesquisarRegistro();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExecPesquisa()
        {
            this.objViewModel.pesquisarBaseCommand.Execute(null);
            this.PesquisarRegistro();
        }

        private void PesquisarRegistro()
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(this.getOrcamento);
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;
            bw.RunWorkerAsync();
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

                if (this.objViewModel.currentModel != null)
                {
                    foreach (Orcamento_ItemModel item in this.objViewModel.currentModel.lOrcamento_Itens)
                    {
                        if (item.objImposto != null)
                        {
                            item.objImposto = this.objViewModel.currentModel.lOrcamento_Item_Impostos
                                .FirstOrDefault(i => i.idOrcamentoItem == item.idOrcamentoItem);
                            item.objImposto.stOrcamentoImpostos = item.stOrcamentoItem;
                            item.objImposto.vTotalItem = item.vTotalItem;
                        }
                    }
                }
            }
        }

        private void getOrcamento(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (this.objViewModel.currentID != 0)
                {
                    e.Result =
                    this.objViewModel.currentModel = this.servico.GetObjeto(idObjeto: this.objViewModel.currentID, idEmpresa: HLP.Comum.Infrastructure.Static.CompanyData.idEmpresa);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Implementação Commands de Funcionalidades

        private void AprovarDescontosExecute()
        {
            wdSenhaSupervisor wdSenhaSupervisor = new wdSenhaSupervisor();
            if (wdSenhaSupervisor.ShowDialog() == true)
            {
                foreach (var item in this.objViewModel.currentModel.lOrcamento_Itens)
                {
                    item.bPermitePorcentagem = true;
                    item.pDesconto = item.pDesconto;
                }
            }
        }

        private bool AprovarDescontosCanExecute()
        {

            if (this.objViewModel.bIsEnabled)
            {
                wd = Sistema.GetOpenWindow(xName: "WinOrcamento");
                if (wd != null)
                {
                    DataGrid dg = wd.FindName(name: "dgItens") as DataGrid;


                    DataGridRow row = null;
                    DataGridColumn column = dg.Columns.FirstOrDefault(i => i.Header.ToString() == "% Desc"); ;
                    object o;

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
                                        return true;
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        #endregion
    }
}
