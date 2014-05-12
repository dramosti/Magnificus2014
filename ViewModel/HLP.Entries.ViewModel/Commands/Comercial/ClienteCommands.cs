using HLP.Base.ClassesBases;
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
using HLP.Base.EnumsBases;
using HLP.Entries.Services.Comercial;
using HLP.Entries.Services.Gerais;
using HLP.Entries.Model.Models.Gerais;
using HLP.Comum.ViewModel.ViewModel;
using HLP.Base.Static;
using HLP.Comum.View.Components;
using HLP.Components.Model.Models;

namespace HLP.Entries.ViewModel.Commands.Comercial
{
    class ClienteCommands
    {
        ClienteViewModel objViewModel;
        ClienteService objServico;
        Condicao_PagamentoService objCondicao_PagamentoService;

        public ClienteCommands(ClienteViewModel objViewModel)
        {
            this.objViewModel = objViewModel;
            this.objCondicao_PagamentoService = new Condicao_PagamentoService();

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

            this.objServico = new ClienteService();

            objViewModel.bWorkerSave.DoWork += bwSalvar_DoWork;
            objViewModel.bWorkerSave.RunWorkerCompleted += bwSalvar_RunWorkerCompleted;

            objViewModel.bWorkerCopy.DoWork += bwCopy_DoWork;
            objViewModel.bWorkerCopy.RunWorkerCompleted += bwCopy_RunWorkerCompleted;

            objViewModel.bWorkerPesquisa.DoWork += new DoWorkEventHandler(this.getCliente);
            objViewModel.bWorkerPesquisa.RunWorkerCompleted += bw_RunWorkerCompleted;
        }


        #region Implementação Commands

        public void Delete()
        {
            int iExcluir = 0;

            try
            {
                if (MessageBox.Show(messageBoxText: "Deseja excluir o cadastro?",
                    caption: "Excluir?", button: MessageBoxButton.YesNo, icon: MessageBoxImage.Question)
                    == MessageBoxResult.Yes)
                {
                    if (this.objServico.Delete(this.objViewModel.currentModel))
                    {
                        MessageBox.Show(messageBoxText: "Cadastro excluido com sucesso!", caption: "Ok",
                            button: MessageBoxButton.OK, icon: MessageBoxImage.Information);
                        iExcluir = (int)this.objViewModel.currentModel.idClienteFornecedor;
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
                if (ex.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                {
                    OperacoesDataBaseViewModel vm = new OperacoesDataBaseViewModel();
                    vm.ShowWinExclusionDenied(xMessage: ex.Message, xValor: this.objViewModel.currentID.ToString());
                }
                else
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



        public void Save(object _panel)
        {
            try
            {
                foreach (int id in this.objViewModel.currentModel.lCliente_fornecedor_arquivo.idExcluidos)
                {
                    this.objViewModel.currentModel.lCliente_fornecedor_arquivo.Add(
                        new Cliente_fornecedor_arquivoModel
                        {
                            idClienteFornecedorArquivo = id,
                            status = statusModel.excluido
                        });
                }
                foreach (int id in this.objViewModel.currentModel.lCliente_fornecedor_contato.idExcluidos)
                {
                    this.objViewModel.currentModel.lCliente_fornecedor_contato.Add(
                        new ContatoModel
                        {
                            idContato = id,
                            status = statusModel.excluido
                        });
                }
                foreach (int id in this.objViewModel.currentModel.lCliente_fornecedor_Endereco.idExcluidos)
                {
                    this.objViewModel.currentModel.lCliente_fornecedor_Endereco.Add(
                        new EnderecoModel
                        {
                            idEndereco = id,
                            status = statusModel.excluido
                        });
                }
                foreach (int id in this.objViewModel.currentModel.lCliente_Fornecedor_Observacao.idExcluidos)
                {
                    this.objViewModel.currentModel.lCliente_Fornecedor_Observacao.Add(
                        new Cliente_Fornecedor_ObservacaoModel
                        {
                            idClienteFornecedorObservacao = id,
                            status = statusModel.excluido
                        });
                }
                foreach (int id in this.objViewModel.currentModel.lCliente_fornecedor_produto.idExcluidos)
                {
                    this.objViewModel.currentModel.lCliente_fornecedor_produto.Add(
                        new Cliente_fornecedor_produtoModel
                        {
                            idClienteFornecedorProduto = id,
                            status = statusModel.excluido
                        });
                }
                foreach (int id in this.objViewModel.currentModel.lCliente_fornecedor_representante.idExcluidos)
                {
                    this.objViewModel.currentModel.lCliente_fornecedor_representante.Add(
                        new Cliente_fornecedor_representanteModel
                        {
                            idClienteFornecedorRepresentante = id,
                            status = statusModel.excluido
                        });
                }
                this.objViewModel.bWorkerSave.RunWorkerAsync(argument: _panel);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        void bwSalvar_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = e.Argument;
            this.objViewModel.currentModel = this.objServico.Save(this.objViewModel.currentModel);
            this.IniciaCollection();
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
                    while (this.objViewModel.currentModel.lCliente_fornecedor_arquivo.Count(i => i.status == statusModel.excluido)
                            > 0)
                    {
                        this.objViewModel.currentModel.lCliente_fornecedor_arquivo.RemoveAt(
                            index: this.objViewModel.currentModel.lCliente_fornecedor_arquivo.IndexOf(
                            item: this.objViewModel.currentModel.lCliente_fornecedor_arquivo.FirstOrDefault(i => i.status == statusModel.excluido)));
                    }
                    while (this.objViewModel.currentModel.lCliente_fornecedor_contato.Count(i => i.status == statusModel.excluido)
                            > 0)
                    {
                        this.objViewModel.currentModel.lCliente_fornecedor_contato.RemoveAt(
                            index: this.objViewModel.currentModel.lCliente_fornecedor_contato.IndexOf(
                            item: this.objViewModel.currentModel.lCliente_fornecedor_contato.FirstOrDefault(i => i.status == statusModel.excluido)));
                    }
                    while (this.objViewModel.currentModel.lCliente_fornecedor_Endereco.Count(i => i.status == statusModel.excluido)
                            > 0)
                    {
                        this.objViewModel.currentModel.lCliente_fornecedor_Endereco.RemoveAt(
                            index: this.objViewModel.currentModel.lCliente_fornecedor_Endereco.IndexOf(
                            item: this.objViewModel.currentModel.lCliente_fornecedor_Endereco.FirstOrDefault(i => i.status == statusModel.excluido)));
                    }
                    while (this.objViewModel.currentModel.lCliente_Fornecedor_Observacao.Count(i => i.status == statusModel.excluido)
                            > 0)
                    {
                        this.objViewModel.currentModel.lCliente_Fornecedor_Observacao.RemoveAt(
                            index: this.objViewModel.currentModel.lCliente_Fornecedor_Observacao.IndexOf(
                            item: this.objViewModel.currentModel.lCliente_Fornecedor_Observacao.FirstOrDefault(i => i.status == statusModel.excluido)));
                    }
                    while (this.objViewModel.currentModel.lCliente_fornecedor_produto.Count(i => i.status == statusModel.excluido)
                            > 0)
                    {
                        this.objViewModel.currentModel.lCliente_fornecedor_produto.RemoveAt(
                            index: this.objViewModel.currentModel.lCliente_fornecedor_produto.IndexOf(
                            item: this.objViewModel.currentModel.lCliente_fornecedor_produto.FirstOrDefault(i => i.status == statusModel.excluido)));
                    }
                    while (this.objViewModel.currentModel.lCliente_fornecedor_representante.Count(i => i.status == statusModel.excluido)
                            > 0)
                    {
                        this.objViewModel.currentModel.lCliente_fornecedor_representante.RemoveAt(
                            index: this.objViewModel.currentModel.lCliente_fornecedor_representante.IndexOf(
                            item: this.objViewModel.currentModel.lCliente_fornecedor_representante.FirstOrDefault(i => i.status == statusModel.excluido)));
                    }

                    this.objViewModel.salvarBaseCommand.Execute(parameter: null);
                    this.IniciaCollection();
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


        private void Novo(object _panel)
        {
            this.objViewModel.currentModel = new Cliente_fornecedorModel();
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
            if (MessageBox.Show(messageBoxText: "Deseja realmente cancelar a transação?", caption: "Cancelar?", button: MessageBoxButton.YesNo, icon: MessageBoxImage.Question) == MessageBoxResult.No) return;
            this.PesquisarRegistro();
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
                this.objViewModel.bWorkerCopy.RunWorkerAsync();
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
                if (e.Error != null)
                {
                    throw new Exception(message: e.Error.Message);
                }
                else
                {
                    this.objViewModel.viewModelBaseCommands.SetFocusFirstControl();
                }
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
            this.objViewModel.bWorkerPesquisa.RunWorkerAsync();
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.IniciaCollection();
        }

        private void getCliente(object sender, DoWorkEventArgs e)
        {
            try
            {
                this.objViewModel.currentModel = this.objServico.GetObjeto(id: this.objViewModel.currentID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void IniciaCollection()
        {
            if (this.objViewModel.currentModel != null)
            {
                this.objViewModel.currentModel.lCliente_fornecedor_arquivo.CollectionCarregada();
                this.objViewModel.currentModel.lCliente_fornecedor_contato.CollectionCarregada();
                this.objViewModel.currentModel.lCliente_fornecedor_Endereco.CollectionCarregada();
                this.objViewModel.currentModel.lCliente_Fornecedor_Observacao.CollectionCarregada();
                this.objViewModel.currentModel.lCliente_fornecedor_produto.CollectionCarregada();
                this.objViewModel.currentModel.lCliente_fornecedor_representante.CollectionCarregada();
            }

        }
        #endregion

        public Condicao_pagamentoModel getCondicaoPagamentoByCliente(int idCondicaoPagamento)
        {
            objCondicao_PagamentoService = new Condicao_PagamentoService();

            return objCondicao_PagamentoService.GetObject(id: idCondicaoPagamento);
        }

        public bool RotaPossuiListaPrecoPai(int idRota)
        {
            objServico = new ClienteService();
            return objServico.RotaPossuiListaPrecoPai(idRota: idRota);
        }

        public int GetIdSiteByDeposito(int idDeposito)
        {
            return objServico.GetIdSiteByDeposito(idDeposito: idDeposito);
        }
    }
}
