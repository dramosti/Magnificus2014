﻿using HLP.Comum.ViewModel.Commands;
using HLP.Dependencies;
using HLP.Entries.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Entries.Model.Repository.Interfaces.Gerais;
using HLP.Entries.Model.Models.Gerais;
using System.Windows.Controls;
using System.Windows;
using System.ComponentModel;

namespace HLP.Entries.ViewModel.Commands
{
    public class DecisaoCommands
    {

        DecisaoViewModel objViewModel;
        decisaoService.IserviceDecisaoClient servico = new decisaoService.IserviceDecisaoClient();
        public DecisaoCommands(DecisaoViewModel vViewModel)
        {
            this.objViewModel = vViewModel;

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
                this.objViewModel.currentModel.idDecisao = await this.servico.saveDecisaoAsync(objDecisao: this.objViewModel.currentModel);
                this.objViewModel.commandSalvarBase.Execute(parameter: null);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private bool SaveCanExecute(object objDependencia)
        {
            if (this.objViewModel.currentModel == null)
                return false;

            return (this.objViewModel.commandSalvarBase.CanExecute(parameter: null)
                && this.objViewModel.IsValid(obj: objDependencia as Panel));
        }

        public async void Delete()
        {
            try
            {
                if (MessageBox.Show(messageBoxText: "Deseja excluir o cadastro?",
                    caption: "Excluir?", button: MessageBoxButton.YesNo, icon: MessageBoxImage.Question)
                    == MessageBoxResult.Yes)
                {
                    if (await this.servico.deleteDecisaoAsync(idDecisao: (int)this.objViewModel.currentModel.idDecisao))
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

            return this.objViewModel.commandDeletarBase.CanExecute(parameter: null);
        }

        private void Novo()
        {
            this.objViewModel.currentModel = new DecisaoModel();
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

        public async void Copy()
        {
            try
            {
                this.objViewModel.currentModel.idDecisao = await this.servico.copyDecisaoAsync(idDecisao: (int)this.objViewModel.currentModel.idDecisao);
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
            bw.DoWork += new DoWorkEventHandler(this.GetUFBackground);
            bw.RunWorkerAsync();

        }

        private async void GetUFBackground(object sender, DoWorkEventArgs e)
        {
            this.objViewModel.currentModel = await servico.getDecisaoAsync(idDecisao: (int)this.objViewModel.currentID);
        }

        #endregion


    }
}
