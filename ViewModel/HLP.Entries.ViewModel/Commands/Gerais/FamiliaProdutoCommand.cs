using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using HLP.Comum.ViewModel.Commands;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.ViewModel.ViewModels.Gerais;

namespace HLP.Entries.ViewModel.Commands.Gerais
{
    public class FamiliaProdutoCommand
    {
        FamiliaProdutoViewModel objViewModel;
        BackgroundWorker bWorkerAcoes;

        public FamiliaProdutoCommand(FamiliaProdutoViewModel objViewModel)
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
                        canExecute: paramCanExec => this.objViewModel.pesquisarBaseCommand.CanExecute(parameter: null));

            this.objViewModel.navegarCommand = new RelayCommand(execute: paramExec => this.Navegar(ContentBotao: paramExec),
                canExecute: paramCanExec => objViewModel.navegarBaseCommand.CanExecute(paramCanExec));

        }

        Familia_ProdutoService.IserviceFamiliaProdutoClient servico = new Familia_ProdutoService.IserviceFamiliaProdutoClient();


        #region Implementação Commands
        public void Save(object _panel)
        {
            try
            {
                #region Itens excluidos
                foreach (int id in this.objViewModel.currentModel.lFamilia_Produto_ClassesModel.idExcluidos)
                {
                    this.objViewModel.currentModel.lFamilia_Produto_ClassesModel.Add(
                        item: new Familia_Produto_ClassesModel
                        {
                            idFamilia_Produto_Classes = id,
                            status = Comum.Resources.RecursosBases.statusModel.excluido
                        });
                }
                #endregion
                objViewModel.SetFocusFirstTab(_panel as Panel);
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
                this.objViewModel.currentModel = servico.Save(this.objViewModel.currentModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            e.Result = e.Argument;
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
                    this.Inicia_Collections();
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

        public void Delete()
        {
            int iExcluir = 0;

            try
            {
                if (MessageBox.Show(messageBoxText: "Deseja excluir o cadastro?",
                    caption: "Excluir?", button: MessageBoxButton.YesNo, icon: MessageBoxImage.Question)
                    == MessageBoxResult.Yes)
                {
                    if (this.servico.Delete((int)this.objViewModel.currentModel.idFamiliaProduto))
                    {
                        MessageBox.Show(messageBoxText: "Cadastro excluido com sucesso!", caption: "Ok",
                            button: MessageBoxButton.OK, icon: MessageBoxImage.Information);
                        iExcluir = (int)this.objViewModel.currentModel.idFamiliaProduto;
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
                if (this.objViewModel.currentModel == null)
                {
                    this.objViewModel.deletarBaseCommand.Execute(parameter: iExcluir);
                    this.PesquisarRegistro();
                }
            }
        }

        
        private void Novo(object _panel)
        {
            this.objViewModel.currentModel = new Familia_produtoModel();
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
            if (MessageBox.Show(messageBoxText: "Deseja realmente cancelar a transação?",caption: "Cancelar?", button: MessageBoxButton.YesNo, icon: MessageBoxImage.Question)== MessageBoxResult.No) return;
            this.PesquisarRegistro();
            this.objViewModel.cancelarBaseCommand.Execute(parameter: null);
        }
        private bool CancelarCanExecute()
        {
            return this.objViewModel.cancelarBaseCommand.CanExecute(parameter: null);
        }

        public async void Copy()
        {
            try
            {
                this.objViewModel.currentModel = await servico.CopyAsync(this.objViewModel.currentModel);
                this.objViewModel.copyBaseCommand.Execute(null);
            }
            catch (Exception ex)
            {

                throw ex;
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
            bw.DoWork += new DoWorkEventHandler(this.metodoGetModel);
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;
            bw.RunWorkerAsync();

        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Inicia_Collections();
        }

        private void metodoGetModel(object sender, DoWorkEventArgs e)
        {
            this.objViewModel.currentModel = this.servico.GetObject((int)this.objViewModel.currentID);
        }


        private void Inicia_Collections()
        {
            if (this.objViewModel.currentModel != null)
                this.objViewModel.currentModel.lFamilia_Produto_ClassesModel.CollectionCarregada();
        }


        #endregion





    }
}
