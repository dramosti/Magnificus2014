using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.Model.Repository.Interfaces.Gerais;
using HLP.Entries.ViewModel.ViewModels;
using HLP.Dependencies;
using HLP.Comum.ViewModel.Commands;
using System.Windows.Controls;
using System.Windows;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace HLP.Entries.ViewModel.Commands
{
    public class CidadeCommands
    {
        cidadeService.IserviceCidadeClient servico = new cidadeService.IserviceCidadeClient();
        CidadeViewModel objViewModel;

        public CidadeCommands(CidadeViewModel objViewModel)
        {
            this.objViewModel = objViewModel;

            this.objViewModel.commandDeletar = new RelayCommand(paramExec => Delete(),
                    paramCanExec => DeleteCanExecute());

            this.objViewModel.commandSalvar = new RelayCommand(paramExec => Save(_panel: paramExec),
                    paramCanExec => SaveCanExecute(paramCanExec));

            this.objViewModel.commandNovo = new RelayCommand(execute: paramExec => this.Novo(_panel: paramExec),
                   canExecute: paramCanExec => this.NovoCanExecute());

            this.objViewModel.commandAlterar = new RelayCommand(execute: paramExec => this.Alterar(_panel: paramExec),
                    canExecute: paramCanExec => this.AlterarCanExecute());

            this.objViewModel.commandCancelar = new RelayCommand(execute: paramExec => this.Cancelar(),
                    canExecute: paramCanExec => this.CancelarCanExecute());

            this.objViewModel.commandPesquisar = new RelayCommand(execute: paramExec => this.Pesquisar(),
                    canExecute: paramCanExec => true);

            this.objViewModel.commandCopiar = new RelayCommand(execute: paramExec => this.Copy(),
                canExecute: paramCanExec => this.CopyCanExecute());
        }

        public void GetCidadeByUf(int idUF)
        {

        }




        #region Implementação Commands

        public async void Save(object _panel)
        {
            try
            {
                this.objViewModel.currentModel.idCidade = await servico.saveCidadeAsync(objCidade: this.objViewModel.currentModel);
                this.objViewModel.salvarBaseCommand.Execute(parameter: _panel);
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
            try
            {
                int iExcluido = (int)this.objViewModel.currentModel.idCidade;
                if (MessageBox.Show(messageBoxText: "Deseja excluir o cadastro?",
                    caption: "Excluir?", button: MessageBoxButton.YesNo, icon: MessageBoxImage.Question)
                    == MessageBoxResult.Yes)
                {
                    if (servico.delCidade(idCidade: (int)this.objViewModel.currentModel.idCidade))
                    {
                        MessageBox.Show(messageBoxText: "Cadastro excluido com sucesso!", caption: "Ok",
                            button: MessageBoxButton.OK, icon: MessageBoxImage.Information);
                        this.objViewModel.deletarBaseCommand.Execute(parameter: iExcluido);
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
        }

        private bool DeleteCanExecute()
        {
            if (objViewModel.currentModel == null)
                return false;

            return this.objViewModel.deletarBaseCommand.CanExecute(parameter: null);
        }

        private void Novo(object _panel)
        {
            this.objViewModel.currentModel = new CidadeModel();
            this.objViewModel.novoBaseCommand.Execute(parameter: _panel);
        }
        private bool NovoCanExecute()
        {
            return this.objViewModel.novoBaseCommand.CanExecute(parameter: null);
        }

        private void Alterar(object _panel)
        {
            this.objViewModel.alterarBaseCommand.Execute(parameter: _panel);
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
            bw.DoWork += new DoWorkEventHandler(this.GetCidadeBackground);

            bw.RunWorkerAsync();
        }

        private async void GetCidadeBackground(object sender, DoWorkEventArgs e)
        {
            this.objViewModel.currentModel = await servico.getCidadeAsync(idCidade:
                this.objViewModel.currentID);
        }

        public async void Copy()
        {
            try
            {
                this.objViewModel.currentModel.idCidade = await servico.copyCidadeAsync(idCidade: (int)this.objViewModel.currentModel.idCidade);
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

        #endregion


    }
}
