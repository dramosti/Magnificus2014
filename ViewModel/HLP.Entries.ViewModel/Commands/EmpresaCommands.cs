using HLP.Comum.ViewModel.Commands;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HLP.Entries.ViewModel.Commands
{
    public class EmpresaCommands
    {
        EmpresaViewModel objViewModel;
        empresaService.IserviceEmpresaClient servico = new empresaService.IserviceEmpresaClient();

        public EmpresaCommands(EmpresaViewModel objViewModel)
        {

            this.objViewModel = objViewModel;

            this.objViewModel.commandDeletar = new RelayCommand(paramExec => Delete(this.objViewModel.currentModel.idEmpresa),
                    paramCanExec => DeleteCanExecute());

            this.objViewModel.commandSalvar = new RelayCommand(paramExec => Save(),
                    paramCanExec => SaveCanExecute(paramCanExec));

            this.objViewModel.commandNovo = new RelayCommand(execute: paramExec => this.Novo(),
                   canExecute: paramCanExec => this.NovoCanExecute());

            this.objViewModel.commandAlterar = new RelayCommand(execute: paramExec => this.Alterar(),
                    canExecute: paramCanExec => this.AlterarCanExecute());

            this.objViewModel.commandCancelar = new RelayCommand(execute: paramExec => this.Cancelar(),
                    canExecute: paramCanExec => this.CancelarCanExecute());

            this.objViewModel.commandPesquisar = new RelayCommand(execute: paramExec => this.Pesquisar(),
                    canExecute: paramCanExec => true);
        }


        #region Implementação Commands

        public async void Save()
        {
            try
            {
                foreach (int id in this.objViewModel.currentModel.lEmpresa_endereco.idExcluidos)
                {
                    this.objViewModel.currentModel.lEmpresa_endereco.Add(
                        new Empresa_EnderecoModel
                        {
                            idEmpresaEndereco = id,
                            status = Comum.Resources.RecursosBases.statusModel.excluido
                        });
                }
                //this.objViewModel.currentModel.idEmpresa = 
                    await servico.SaveAsync(objEmpresa:
                    objViewModel.currentModel);
                this.objViewModel.salvarBaseCommand.Execute(parameter: null);
                this.Inicia_Collections();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private bool SaveCanExecute(object objDependency)
        {
            if (objViewModel.currentModel == null && objDependency == null)
                return false;

            return (this.objViewModel.salvarBaseCommand.CanExecute(parameter: null)
                && this.objViewModel.IsValid(objDependency as Panel));
        }

        public async void Delete(object objUFModel)
        {
            try
            {
                if (MessageBox.Show(messageBoxText: "Deseja excluir o cadastro?",
                    caption: "Excluir?", button: MessageBoxButton.YesNo, icon: MessageBoxImage.Question)
                    == MessageBoxResult.Yes)
                {
                    if (await servico.DeleteAsync(idEmpresa: (int)this.objViewModel.currentModel.idEmpresa))
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
            this.objViewModel.currentModel = new EmpresaModel();
            this.objViewModel.novoBaseCommand.Execute(parameter: null);
        }
        private bool NovoCanExecute()
        {
            return this.objViewModel.novoBaseCommand.CanExecute(parameter: null);
        }

        private void Alterar()
        {
            this.objViewModel.alterarBaseCommand.Execute(parameter: null);
            this.objViewModel.currentModel.lEmpresa_endereco.xCampoId = "idEmpresaEndereco";
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

        public void Pesquisar()
        {
            this.objViewModel.pesquisarBaseCommand.Execute(null);
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(this.GetEmpresasBackground);
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;

            bw.RunWorkerAsync();

        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.Inicia_Collections();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void Inicia_Collections()
        {
            this.objViewModel.currentModel.lEmpresa_endereco.CollectionCarregada();
        }

        private void GetEmpresasBackground(object sender, DoWorkEventArgs e)
        {
            this.objViewModel.currentModel = servico.getEmpresa(idEmpresa: this.objViewModel.currentID);
        }
        #endregion


    }
}
