using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using HLP.Comum.ViewModel.Commands;
using HLP.Entries.ViewModel.ViewModels.Gerais;

namespace HLP.Entries.ViewModel.Commands.Gerais
{
    public class TipoServicoCommand
    {
        TipoServicoViewModel objViewModel;
        tipoServicoService.IserviceTipoServicoClient servicotpServico = new tipoServicoService.IserviceTipoServicoClient();

        public TipoServicoCommand(TipoServicoViewModel _objViewModel)
        {
            this.objViewModel = _objViewModel;
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
        #region Implementação Commands

        public async void Save()
        {
            try
            {
                //TODO: método de serviço para salvar
                objViewModel.currentModel = await servicotpServico.SaveAsync(objViewModel.currentModel);
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
                if (MessageBox.Show(messageBoxText: "Deseja excluir o cadastro?",
                    caption: "Excluir?", button: MessageBoxButton.YesNo, icon: MessageBoxImage.Question)
                    == MessageBoxResult.Yes)
                {
                    if (await servicotpServico.DeleteAsync((int)objViewModel.currentModel.idTipoServico))
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

        private bool DeleteCanExecute()
        {
            if (objViewModel.currentModel == null)
                return false;

            return this.objViewModel.deletarBaseCommand.CanExecute(parameter: null);
        }

        private void Novo()
        {
            //TODO: instanciar novo objeto
            this.objViewModel.currentModel = new Model.Models.Gerais.Tipo_servicoModel();
            this.objViewModel.novoBaseCommand.Execute(parameter: null);
        }
        private bool NovoCanExecute()
        {
            return this.objViewModel.novoBaseCommand.CanExecute(parameter: null);
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
            try
            {
                //TODO: Implementar serviço de copy
                await servicotpServico.CopyAsync((int)objViewModel.currentModel.idTipoServico);
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
            bw.RunWorkerAsync();

        }

        private async void metodoGetModel(object sender, DoWorkEventArgs e)
        {
            this.objViewModel.currentModel = await servicotpServico.GetTipoAsync(objViewModel.currentID); //TODO: método de serviço para pesquisar
        }
        #endregion




    }
}
