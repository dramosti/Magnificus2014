﻿using HLP.Comum.Resources.RecursosBases;
using HLP.Comum.ViewModel.Commands;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.ViewModel.ViewModels.Gerais;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HLP.Entries.ViewModel.Commands.Gerais
{
    public class FuncionarioCommands
    {
        BackgroundWorker bWorkerAcoes;
        FuncionarioViewModel objViewModel;
        funcionarioService.IserviceFuncionarioClient servico = new funcionarioService.IserviceFuncionarioClient();
        public FuncionarioCommands(FuncionarioViewModel objViewModel)
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


        #region Implementação Commands


        public void Save(object _panel)
        {
            try
            {
                #region Carregar Ids Excluidos Collections


                foreach (int id in objViewModel.currentModel.lFuncionario_Arquivo.idExcluidos)
                {
                    this.objViewModel.currentModel.lFuncionario_Arquivo.Add(
                        item: new Funcionario_ArquivoModel
                        {
                            idFuncionarioArquivo = id,
                            status = statusModel.excluido
                        });
                }

                foreach (int id in objViewModel.currentModel.lFuncionario_Certificacao.idExcluidos)
                {
                    this.objViewModel.currentModel.lFuncionario_Certificacao.Add(
                        item: new Funcionario_CertificacaoModel
                        {
                            idFuncionarioCertificacao = id,
                            status = statusModel.excluido
                        });
                }

                foreach (int id in objViewModel.currentModel.lFuncionario_Comissao_Produto.idExcluidos)
                {
                    this.objViewModel.currentModel.lFuncionario_Comissao_Produto.Add(
                        item: new Funcionario_Comissao_ProdutoModel
                        {
                            idFuncionarioComissaoProduto = id,
                            status = statusModel.excluido
                        });
                }

                foreach (int id in objViewModel.currentModel.lFuncionario_Endereco.idExcluidos)
                {
                    this.objViewModel.currentModel.lFuncionario_Endereco.Add(
                        item: new Funcionario_EnderecoModel
                        {
                            idEndereco = id,
                            status = statusModel.excluido
                        });
                }

                foreach (int id in objViewModel.currentModel.lFuncionario_Margem_Lucro_Comissao.idExcluidos)
                {
                    this.objViewModel.currentModel.lFuncionario_Margem_Lucro_Comissao.Add(
                        item: new Funcionario_Margem_Lucro_ComissaoModel
                        {
                            idFuncionarioMargemLucroComissao = id,
                            status = statusModel.excluido
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
                this.objViewModel.currentModel = servico.saveFuncionario(objFuncionario:
                    this.objViewModel.currentModel);
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
                    if (this.servico.deleteFuncionario((int)this.objViewModel.currentModel.idFuncionario))
                    {
                        MessageBox.Show(messageBoxText: "Cadastro excluido com sucesso!", caption: "Ok",
                            button: MessageBoxButton.OK, icon: MessageBoxImage.Information);
                        iExcluir = (int)this.objViewModel.currentModel.idFuncionario;
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
            this.objViewModel.currentModel = new FuncionarioModel();
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
                this.objViewModel.currentModel.idFuncionario = await this.servico.copyFuncionarioAsync(objFuncionario: this.objViewModel.currentModel);
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
            try
            {
                if (this.objViewModel.currentID != 0)
                    this.objViewModel.currentModel = this.servico.getFuncionario(idFuncionario: this.objViewModel.currentID);
                else
                    this.objViewModel.currentModel = null;

            }
            catch (Exception)
            {

                throw;
            }

        }

        private void Inicia_Collections()
        {
            if (this.objViewModel.currentModel != null)
            {
                this.objViewModel.currentModel.lFuncionario_Arquivo.CollectionCarregada();
                this.objViewModel.currentModel.lFuncionario_Certificacao.CollectionCarregada();
                this.objViewModel.currentModel.lFuncionario_Comissao_Produto.CollectionCarregada();
                this.objViewModel.currentModel.lFuncionario_Endereco.CollectionCarregada();
                this.objViewModel.currentModel.lFuncionario_Margem_Lucro_Comissao.CollectionCarregada();
            }
        }
        #endregion


    }
}
