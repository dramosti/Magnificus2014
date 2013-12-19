﻿using HLP.Comum.ViewModel.Commands;
using HLP.Entries.Model.Models.Comercial;
using HLP.Entries.ViewModel.ViewModels.Comercial;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HLP.Entries.ViewModel.Commands.Comercial
{
    class ClienteCommands
    {
        clienteService.IserviceClienteClient servico = new clienteService.IserviceClienteClient();
        ClienteViewModel objViewModel;
        public ClienteCommands(ClienteViewModel objViewModel)
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


        #region Implementação Commands

        public void Save()
        {
            try
            {
                BackgroundWorker bwSalvar = new BackgroundWorker();
                bwSalvar.DoWork += bwSalvar_DoWork;
                bwSalvar.RunWorkerCompleted += bwSalvar_RunWorkerCompleted;
                bwSalvar.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        void bwSalvar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.objViewModel.salvarBaseCommand.Execute(parameter: null);
                this.IniciaCollection();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        void bwSalvar_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (int id in this.objViewModel.currentModel.lCliente_fornecedor_arquivo.idExcluidos)
            {
                this.objViewModel.currentModel.lCliente_fornecedor_arquivo.Add(
                    new Cliente_fornecedor_arquivoModel
                    {
                        idClienteFornecedorArquivo = id,
                        status = Comum.Resources.RecursosBases.statusModel.excluido
                    });
            }
            foreach (int id in this.objViewModel.currentModel.lCliente_fornecedor_contato.idExcluidos)
            {
                this.objViewModel.currentModel.lCliente_fornecedor_contato.Add(
                    new Cliente_fornecedor_contatoModel
                    {
                        idClienteFornecedorContato = id,
                        status = Comum.Resources.RecursosBases.statusModel.excluido
                    });
            }
            foreach (int id in this.objViewModel.currentModel.lCliente_fornecedor_Endereco.idExcluidos)
            {
                this.objViewModel.currentModel.lCliente_fornecedor_Endereco.Add(
                    new Cliente_fornecedor_EnderecoModel
                    {
                        idClienteFornecedor = id,
                        status = Comum.Resources.RecursosBases.statusModel.excluido
                    });
            }
            foreach (int id in this.objViewModel.currentModel.lCliente_Fornecedor_Observacao.idExcluidos)
            {
                this.objViewModel.currentModel.lCliente_Fornecedor_Observacao.Add(
                    new Cliente_Fornecedor_ObservacaoModel
                    {
                        idClienteFornecedorObservacao = id,
                        status = Comum.Resources.RecursosBases.statusModel.excluido
                    });
            }
            foreach (int id in this.objViewModel.currentModel.lCliente_fornecedor_produto.idExcluidos)
            {
                this.objViewModel.currentModel.lCliente_fornecedor_produto.Add(
                    new Cliente_fornecedor_produtoModel
                    {
                        idClienteFornecedorProduto = id,
                        status = Comum.Resources.RecursosBases.statusModel.excluido
                    });
            }
            foreach (int id in this.objViewModel.currentModel.lCliente_fornecedor_representante.idExcluidos)
            {
                this.objViewModel.currentModel.lCliente_fornecedor_representante.Add(
                    new Cliente_fornecedor_representanteModel
                    {
                        idClienteFornecedorRepresentante = id,
                        status = Comum.Resources.RecursosBases.statusModel.excluido
                    });
            }
            this.objViewModel.currentModel.idClienteFornecedor = this.servico.saveCliente(objCliente: this.objViewModel.currentModel);
            this.Inicia_Collections();
        }
        private void Inicia_Collections()
        {
            this.objViewModel.currentModel.lCliente_fornecedor_arquivo.CollectionCarregada();
            this.objViewModel.currentModel.lCliente_fornecedor_contato.CollectionCarregada();
            this.objViewModel.currentModel.lCliente_fornecedor_Endereco.CollectionCarregada();
            this.objViewModel.currentModel.lCliente_Fornecedor_Observacao.CollectionCarregada();
            this.objViewModel.currentModel.lCliente_fornecedor_produto.CollectionCarregada();
            this.objViewModel.currentModel.lCliente_fornecedor_representante.CollectionCarregada();
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
            int idRemoved = 0;
            try
            {
                if (MessageBox.Show(messageBoxText: "Deseja excluir o cadastro?",
                    caption: "Excluir?", button: MessageBoxButton.YesNo, icon: MessageBoxImage.Question)
                    == MessageBoxResult.Yes)
                {
                    if (await this.servico.deleteClienteAsync(
                        idCliente: (int)this.objViewModel.currentModel.idClienteFornecedor)
                    )
                    {
                        MessageBox.Show(messageBoxText: "Cadastro excluido com sucesso!", caption: "Ok",
                            button: MessageBoxButton.OK, icon: MessageBoxImage.Information);
                        idRemoved = (int)this.objViewModel.currentModel.idClienteFornecedor;
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
                this.objViewModel.deletarBaseCommand.Execute(parameter: idRemoved);
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
            this.objViewModel.currentModel = new Cliente_fornecedorModel();
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

        public void Copy()
        {
            try
            {
                BackgroundWorker bwCopy = new BackgroundWorker();
                bwCopy.DoWork += bwCopy_DoWork;
                bwCopy.RunWorkerCompleted += bwCopy_RunWorkerCompleted;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        void bwCopy_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.objViewModel.copyBaseCommand.Execute(null);
                this.getCliente(this, null);
                this.IniciaCollection();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        void bwCopy_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                this.objViewModel.currentID =
                    this.servico.copyCliente(objCliente:
                    this.objViewModel.currentModel);
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
            bw.DoWork += new DoWorkEventHandler(this.getCliente);
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;
            bw.RunWorkerAsync();

        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.IniciaCollection();
        }

        private void getCliente(object sender, DoWorkEventArgs e)
        {
            try
            {
                this.objViewModel.currentModel = this.servico.getCliente(
                idCliente: this.objViewModel.currentID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void IniciaCollection()
        {
            this.objViewModel.currentModel.lCliente_fornecedor_arquivo.CollectionCarregada();
            this.objViewModel.currentModel.lCliente_fornecedor_contato.CollectionCarregada();
            this.objViewModel.currentModel.lCliente_fornecedor_Endereco.CollectionCarregada();
            this.objViewModel.currentModel.lCliente_Fornecedor_Observacao.CollectionCarregada();
            this.objViewModel.currentModel.lCliente_fornecedor_produto.CollectionCarregada();
            this.objViewModel.currentModel.lCliente_fornecedor_representante.CollectionCarregada();
        }
        #endregion


    }
}
