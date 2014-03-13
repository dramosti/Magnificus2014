﻿using HLP.Comum.Infrastructure.Static;
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
        BackgroundWorker bWorkerAcoes;
        Empresa_ParametrosViewModel objViewModel;
        Empresa_ParametrosService.IserviceEmpresaParametrosClient servico = new Empresa_ParametrosService.IserviceEmpresaParametrosClient();
        public Empresa_ParametrosCommands(Empresa_ParametrosViewModel objViewModel)
        {
            this.objViewModel = objViewModel;
            this.objViewModel.commandDeletar = new RelayCommand(paramExec => Delete(),
                    paramCanExec => false);

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
                        canExecute: paramCanExec => false);

            this.objViewModel.navegarCommand = new RelayCommand(execute: paramExec => this.Navegar(ContentBotao: paramExec),
                canExecute: paramCanExec => objViewModel.navegarBaseCommand.CanExecute(paramCanExec));
        }


        #region Implementação Commands
        public void Save(object _panel)
        {
            try
            {
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
            servico.saveEmpresaParamestros(objEmpresaParametros: this.objViewModel.currentModel.empresaParametros);
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
                    object w = objViewModel.GetParentWindow(e.Result);

                    if (w != null)
                        if (w.GetType() == typeof(HLP.Comum.View.Formularios.HlpPesquisaInsert))
                        {
                            (w as HLP.Comum.View.Formularios.HlpPesquisaInsert).idSalvo = this.objViewModel.currentID;
                            (w as HLP.Comum.View.Formularios.HlpPesquisaInsert).DialogResult = true;
                            (w as HLP.Comum.View.Formularios.HlpPesquisaInsert).Close();
                        }
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


        private void Novo(object _panel)
        {
            this.objViewModel.novoBaseCommand.Execute(parameter: _panel);
            bWorkerAcoes = new BackgroundWorker();
            bWorkerAcoes.DoWork += bwNovo_DoWork;
            bWorkerAcoes.RunWorkerCompleted += bwNovo_RunWorkerCompleted;
            bWorkerAcoes.RunWorkerAsync(_panel);
        }

        void bwNovo_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Threading.Thread.Sleep(millisecondsTimeout: 100);
            e.Result = e.Argument;
        }
        void bwNovo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            objViewModel.FocusToComponente(e.Result as Panel, Comum.Infrastructure.Static.Util.focoComponente.Segundo);
        }
        private bool NovoCanExecute()
        {
            return false;
            //return this.objViewModel.novoBaseCommand.CanExecute(parameter: null);
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
            //return this.objViewModel.alterarBaseCommand.CanExecute(parameter: null);
            return (this.objViewModel.viewModelBaseCommands.currentOp == Comum.Resources.RecursosBases.OperacaoCadastro.pesquisando ||
                this.objViewModel.viewModelBaseCommands.currentOp == Comum.Resources.RecursosBases.OperacaoCadastro.livre);
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

        public async void Copy()
        {
            try
            {
                //Acredito que não será possível copiar parametros da empresa
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
