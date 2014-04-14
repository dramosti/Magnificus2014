using HLP.Base.ClassesBases;
using HLP.Entries.Model.Models.Comercial;
using HLP.Entries.ViewModel.Services.Comercial;
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

namespace HLP.Entries.ViewModel.Commands.Comercial
{
    class ClienteCommands
    {
        ClienteViewModel objViewModel;
        BackgroundWorker bWorkerAcoes;
        ClienteService objServico;


        public ClienteCommands(ClienteViewModel objViewModel)
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

            this.objServico = new ClienteService();
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
                objViewModel.SetFocusFirstTab(_panel as Panel);
                bWorkerAcoes = new BackgroundWorker();
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
            e.Result = e.Argument;
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
                    new Cliente_fornecedor_contatoModel
                    {
                        idClienteFornecedorContato = id,
                        status = statusModel.excluido
                    });
            }
            foreach (int id in this.objViewModel.currentModel.lCliente_fornecedor_Endereco.idExcluidos)
            {
                this.objViewModel.currentModel.lCliente_fornecedor_Endereco.Add(
                    new Cliente_fornecedor_EnderecoModel
                    {
                        idClienteFornecedor = id,
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
                    this.objViewModel.salvarBaseCommand.Execute(parameter: e.Result as Panel);
                    object w = objViewModel.GetParentWindow(e.Result);

                    if (w != null)
                        if (w.GetType() == typeof(HLP.Comum.View.Formularios.HlpPesquisaInsert))
                        {
                            (w as HLP.Comum.View.Formularios.HlpPesquisaInsert).idSalvo = this.objViewModel.currentID;
                            (w as HLP.Comum.View.Formularios.HlpPesquisaInsert).DialogResult = true;
                            (w as HLP.Comum.View.Formularios.HlpPesquisaInsert).Close();
                        }
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
            objViewModel.FocusToComponente(e.Result as Panel, HLP.Base.Static.Util.focoComponente.Segundo);
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
            objViewModel.FocusToComponente(e.Result as Panel, HLP.Base.Static.Util.focoComponente.Segundo);
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
                BackgroundWorker bwCopy = new BackgroundWorker();
                bwCopy.DoWork += bwCopy_DoWork;
                bwCopy.RunWorkerCompleted += bwCopy_RunWorkerCompleted;
                bwCopy.RunWorkerAsync();
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
                    this.objViewModel.copyBaseCommand.Execute(null);
                    this.getCliente(this, null);
                    this.IniciaCollection();
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
                this.objViewModel.currentModel =
                    this.objServico.Copy(this.objViewModel.currentModel);
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

        public bool RotaPossuiListaPrecoPai(int idRota)
        {
            objServico = new ClienteService();
            return objServico.RotaPossuiListaPrecoPai(idRota: idRota);
        }
    }
}
