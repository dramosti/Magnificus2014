using HLP.Comum.ViewModel.Commands;
using HLP.Entries.ViewModel.ViewModels.Gerais;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HLP.Entries.ViewModel.Commands.Gerais
{
    public class Funcionario_AcessoCommands
    {
        Funcionario_AcessoViewModel objViewModel;
        AcessoFuncionarioService.IserviceAcessoClient servico = new AcessoFuncionarioService.IserviceAcessoClient();

        public Funcionario_AcessoCommands(Funcionario_AcessoViewModel objViewModel)
        {
            this.objViewModel = objViewModel;

            this.objViewModel.commandDeletar = new RelayCommand(paramExec => Delete(),
                    paramCanExec => DeleteCanExecute());

            this.objViewModel.commandSalvar = new RelayCommand(paramExec => Save(),
                    paramCanExec => SaveCanExecute(paramCanExec));

            this.objViewModel.commandNovo = new RelayCommand(execute: paramExec => this.Novo(),
                   canExecute: paramCanExec => this.NovoCanExecute());

            this.objViewModel.commandAlterar = new RelayCommand(execute: paramExec => this.Alterar(),
                    canExecute: paramCanExec => this.AlterarCanExecute());

            this.objViewModel.commandCancelar = new RelayCommand(execute: paramExec => this.Cancelar(),
                    canExecute: paramCanExec => this.CancelarCanExecute());

            this.objViewModel.commandCopiar = new RelayCommand(execute: paramExec => this.Copy(),
            canExecute: paramCanExec => this.CopyCanExecute());

            this.objViewModel.commandPesquisar = new RelayCommand(execute: paramExec => this.ExecPesquisa(),
                        canExecute: paramCanExec => true);

            this.objViewModel.navegarCommand = new RelayCommand(execute: paramExec => this.Navegar(ContentBotao: paramExec),
                canExecute: paramCanExec => objViewModel.navegarBaseCommand.CanExecute(paramCanExec));
        }

        private void IniciaCollections()
        {
            this.objViewModel.currentModel.lFuncionario_Acesso.CollectionCarregada();
        }

        #region Implementação Commands

        public void Save()
        {
            try
            {
                BackgroundWorker bw = new BackgroundWorker();
                bw.DoWork += bw_DoWork;
                bw.RunWorkerCompleted += bw_RunWorkerCompleted;
                bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
                    this.IniciaCollections();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                this.objViewModel.currentModel =
                    this.servico.Save(objModel:
                    this.objViewModel.currentModel);
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

        public async void Delete()
        {
            //try
            //{
            //    if (MessageBox.Show(messageBoxText: "Deseja excluir o cadastro?",
            //        caption: "Excluir?", button: MessageBoxButton.YesNo, icon: MessageBoxImage.Question)
            //        == MessageBoxResult.Yes)
            //    {
            //        if (await //TODO: método de serviço para deletar
            //        )
            //        {
            //            MessageBox.Show(messageBoxText: "Cadastro excluido com sucesso!", caption: "Ok",
            //                button: MessageBoxButton.OK, icon: MessageBoxImage.Information);
            //            this.objViewModel.currentModel = null;
            //        }
            //        else
            //        {
            //            MessageBox.Show(messageBoxText: "Não foi possível excluir o cadastro!", caption: "Falha",
            //                button: MessageBoxButton.OK, icon: MessageBoxImage.Exclamation);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            //finally
            //{
            //    this.objViewModel.deletarBaseCommand.Execute(parameter: null);
            //}
        }

        private bool DeleteCanExecute()
        {
            return false;
            //if (objViewModel.currentModel == null)
            //    return false;

            //return this.objViewModel.deletarBaseCommand.CanExecute(parameter: null);
        }

        private void Novo()
        {
            //this.objViewModel.novoBaseCommand.Execute(parameter: null);
        }
        private bool NovoCanExecute()
        {
            return false;
            //return this.objViewModel.novoBaseCommand.CanExecute(parameter: null);
        }

        private void Alterar()
        {
            this.objViewModel.alterarBaseCommand.Execute(parameter: null);
        }
        private bool AlterarCanExecute()
        {
            return this.objViewModel.alterarBaseCommand.CanExecute(parameter: null);
        }

        private void Cancelar()
        {
            this.objViewModel.currentModel = null;
            this.objViewModel.cancelarBaseCommand.Execute(parameter: null);
        }
        private bool CancelarCanExecute()
        {
            return this.objViewModel.cancelarBaseCommand.CanExecute(parameter: null);
        }

        public async void Copy()
        {
            //try
            //{
            //    BackgroundWorker bwCopy = new BackgroundWorker();
            //    bwCopy.DoWork += bwCopy_DoWork;
            //    bwCopy.RunWorkerCompleted += bwCopy_RunWorkerCompleted;
            //    bwCopy.RunWorkerAsync();
            //}
            //catch (Exception ex)
            //{

            //    throw ex;
            //}
        }

        //void bwCopy_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    try
        //    {
        //        if (e.Error != null)
        //        {
        //            throw new Exception(message: e.Error.Message);
        //        }
        //        else
        //        {
        //            this.objViewModel.currentID = (int)e.Result;
        //            this.getFuncionario(this, null);
        //            this.objViewModel.copyBaseCommand.Execute(null);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //void bwCopy_DoWork(object sender, DoWorkEventArgs e)
        //  {
        //      try
        //      {
        //          e.Result = 
        //          //TODO: implementar serviço de copy
        //      }
        //      catch (Exception)
        //      {

        //          throw;
        //      }
        //  }

        public bool CopyCanExecute()
        {
            //return this.objViewModel.copyBaseCommand.CanExecute(null);
            return false;
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
            bw.DoWork += new DoWorkEventHandler(this.getFuncionario);
            bw.RunWorkerCompleted += bwSalvar_RunWorkerCompleted;
            bw.RunWorkerAsync();

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
                    this.IniciaCollections();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void getFuncionario(object sender, DoWorkEventArgs e)
        {
            try
            {
                this.objViewModel.currentModel = this.servico.GetObjeto(idObjeto:
                this.objViewModel.currentID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


    }
}
