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
    public class Unidade_MedidaCommands
    {
        private Unidade_MedidaViewModel objViewModel;

        unidadeMedidaService.IserviceUnidadeMedidaClient servico = new unidadeMedidaService.IserviceUnidadeMedidaClient();

        public Unidade_MedidaCommands(Unidade_MedidaViewModel objViewModel)
        {
            this.objViewModel = objViewModel;

            this.objViewModel = objViewModel;

            this.objViewModel.commandDeletar = new RelayCommand(paramExec => Delete(this.objViewModel.currentModel),
                    paramCanExec => DeleteCanExecute());

            this.objViewModel.commandSalvar = new RelayCommand(paramExec => Save(),
                    paramCanExec => SaveCanExecute(paramCanExec));

            this.objViewModel.commandNovo = new RelayCommand(execute: paramExec => this.Novo(),
                   canExecute: paramCanExec => this.NovoCanExecute());

            this.objViewModel.commandAlterar = new RelayCommand(execute: paramExec => this.Alterar(),
                    canExecute: paramCanExec => this.AlterarCanExecute());

            this.objViewModel.commandCancelar = new RelayCommand(execute: paramExec => this.Cancelar(),
                    canExecute: paramCanExec => this.CancelarCanExecute());

            this.objViewModel.commandPesquisar = new RelayCommand(execute: paramExec => this.Pesquisar(param: paramExec),
                    canExecute: paramCanExec => this.PesquisarCanExecute(param: paramCanExec));

        }


        #region Implementação Commands

        public async void Save()
        {
            try
            {
                this.objViewModel.currentModel.idUnidadeMedida = await this.servico.saveUnidade_medidaAsync(
                    objUnidadeMedida: this.objViewModel.currentModel);
                this.objViewModel.commandSalvarBase.Execute(parameter: null);
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

            return (this.objViewModel.commandSalvarBase.CanExecute(parameter: null)
                && this.objViewModel.IsValid(objDependency as Grid));
        }

        public async void Delete(object objUFModel)
        {
            try
            {
                if (MessageBox.Show(messageBoxText: "Deseja excluir o cadastro?",
                    caption: "Excluir?", button: MessageBoxButton.YesNo, icon: MessageBoxImage.Question)
                    == MessageBoxResult.Yes)
                {
                    if (await this.servico.deleteUnidade_medidaAsync(idUnidadeMedida: (int)this.objViewModel.currentModel.idUnidadeMedida))
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
                this.objViewModel.commandDeletarBase.Execute(parameter: null);
            }
        }

        private bool DeleteCanExecute()
        {
            if (objViewModel.currentModel == null)
                return false;

            return this.objViewModel.commandDeletarBase.CanExecute(parameter: null);
        }

        private void Novo()
        {
            this.objViewModel.currentModel = new Unidade_medidaModel();
            this.objViewModel.commandNovoBase.Execute(parameter: null);
        }
        private bool NovoCanExecute()
        {
            return this.objViewModel.commandNovoBase.CanExecute(parameter: null);
        }

        private void Alterar()
        {
            this.objViewModel.commandAlterarBase.Execute(parameter: null);
        }
        private bool AlterarCanExecute()
        {
            return this.objViewModel.commandAlterarBase.CanExecute(parameter: null);
        }

        private void Cancelar()
        {
            this.objViewModel.currentModel = null;
            this.objViewModel.commandCancelarBase.Execute(parameter: null);
        }
        private bool CancelarCanExecute()
        {
            return this.objViewModel.commandCancelarBase.CanExecute(parameter: null);
        }

        private void Pesquisar(object param)
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(this.GetWorkOrdersBackground);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.GetWorkOrdersBackgroundComplete);

            if (param != null)
                bw.RunWorkerAsync(argument: param);
        }
        private bool PesquisarCanExecute(object param)
        {
            if (param == null)
                return false;

            int iResult;
            return int.TryParse(s: param.ToString(), result: out iResult) &&
                this.objViewModel.commandPesquisarBase.CanExecute(parameter: null);
        }

        private async void GetWorkOrdersBackground(object sender, DoWorkEventArgs e)
        {
            this.objViewModel.currentModel = await this.servico.getUnidade_medidaAsync(
                idUnidadeMedida: Convert.ToInt32(e.Argument));
        }
        private void GetWorkOrdersBackgroundComplete(
          object sender,
          RunWorkerCompletedEventArgs e)
        {
            this.objViewModel.commandPesquisarBase.Execute(parameter: null);
        }
        #endregion


    }
}
