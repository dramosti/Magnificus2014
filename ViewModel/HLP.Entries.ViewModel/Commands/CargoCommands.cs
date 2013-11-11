using HLP.Comum.ViewModel.Commands;
using HLP.Entries.Model.Models.RecursosHumanos;
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
    public class CargoCommands
    {
        cargoService.IserviceCargoClient servico = new cargoService.IserviceCargoClient();
        CargoViewModel objViewModel;
        public CargoCommands(CargoViewModel objViewModel)
        {
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
        }


        #region Implementação Commands

        public async void Save()
        {
            try
            {
                await servico.saveCargoAsync(this.objViewModel.currentModel);
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
                    if (await this.servico.delCargoAsync(idCargo: (int)this.objViewModel.currentModel.idCargo))
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
            this.objViewModel.currentModel = new CargoModel();
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

        private async void GetWorkOrdersBackground(object sender, DoWorkEventArgs e)
        {
            //this.objViewModel.currentModel = await //TODO: método de serviço para pesquisar
        }
        #endregion


    }
}
