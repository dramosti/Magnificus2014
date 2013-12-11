using HLP.Comum.Infrastructure.Static;
using HLP.Comum.ViewModel.Commands;
using HLP.Entries.ViewModel.ViewModels.Parametros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HLP.Entries.ViewModel.Commands.Parametros
{
    public class Empresa_ParametrosCommands
    {
        Empresa_ParametrosViewModel objViewModel;
        Empresa_ParametrosService.IserviceEmpresaParametrosClient servico = new Empresa_ParametrosService.IserviceEmpresaParametrosClient();
        public Empresa_ParametrosCommands(Empresa_ParametrosViewModel objViewModel)
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
                        canExecute: paramCanExec => false);

            this.objViewModel.navegarCommand = new RelayCommand(execute: paramExec => this.Navegar(ContentBotao: paramExec),
                canExecute: paramCanExec => objViewModel.navegarBaseCommand.CanExecute(paramCanExec));
        }


        #region Implementação Commands

        public async void Save()
        {
            try
            {
                await servico.saveEmpresaParamestrosAsync(objEmpresaParametros: this.objViewModel.currentModel.empresaParametros);
                this.objViewModel.salvarBaseCommand.Execute(parameter: null);
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
            try
            {
                //Acredito que não será possível deletar os parametros da empresa
                //if (MessageBox.Show(messageBoxText: "Deseja excluir o cadastro?",
                //    caption: "Excluir?", button: MessageBoxButton.YesNo, icon: MessageBoxImage.Question)
                //    == MessageBoxResult.Yes)
                //{
                //    if (await 
                //    )
                //    {
                //        MessageBox.Show(messageBoxText: "Cadastro excluido com sucesso!", caption: "Ok",
                //            button: MessageBoxButton.OK, icon: MessageBoxImage.Information);
                //        this.objViewModel.currentModel = null;
                //    }
                //    else
                //    {
                //        MessageBox.Show(messageBoxText: "Não foi possível excluir o cadastro!", caption: "Falha",
                //            button: MessageBoxButton.OK, icon: MessageBoxImage.Exclamation);
                //    }
                //}
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

        private bool DeleteCanExecute()
        {
            //if (objViewModel.currentModel == null)
            //    return false;

            //return this.objViewModel.deletarBaseCommand.CanExecute(parameter: null);
            return false;
        }

        private void Novo()
        {
            //TODO: instanciar novo objeto
            this.objViewModel.novoBaseCommand.Execute(parameter: null);
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
                //Acredito que não será possível copiar parametros da empresa
                //TODO: Implementar serviço de copy
                this.objViewModel.copyBaseCommand.Execute(null);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool CopyCanExecute()
        {
            return false;
            //return this.objViewModel.copyBaseCommand.CanExecute(null);
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
            try
            {
                if (e.Error != null)
                {
                    new ApplicationException(message: e.Error.Message);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async void metodoGetModel(object sender, DoWorkEventArgs e)
        {
            //não será possível pesquisar os paramêtros da empresa, pois sempre será uma parametrização por empresa
            this.objViewModel.currentModel = await this.servico.getEmpresaParametrosAsync(
                idEmpresa: CompanyData.idEmpresa);
        }
        #endregion


    }
}
