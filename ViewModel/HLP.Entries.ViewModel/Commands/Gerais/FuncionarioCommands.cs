using HLP.Base.ClassesBases;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.ViewModel.ViewModels.Gerais;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using HLP.Base.EnumsBases;
using HLP.Components.Model.Models;
using HLP.Entries.Services.Gerais;

namespace HLP.Entries.ViewModel.Commands.Gerais
{
    public class FuncionarioCommands
    {
        FuncionarioViewModel objViewModel;
        FuncionarioService objService;
        bool bOpCancelada = false;
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

            this.objService = new FuncionarioService();

            this.objViewModel.bwHierarquia = new BackgroundWorker();
            this.objViewModel.bwHierarquia.WorkerSupportsCancellation = true;
            this.objViewModel.bwHierarquia.DoWork += bwHierarquia_DoWork;
            this.objViewModel.bwHierarquia.RunWorkerCompleted += bwHierarquia_RunWorkerCompleted;

            objViewModel.bWorkerSave.DoWork += bwSalvar_DoWork;
            objViewModel.bWorkerSave.RunWorkerCompleted += bwSalvar_RunWorkerCompleted;

            objViewModel.bWorkerCopy.DoWork += bwCopy_DoWork;
            objViewModel.bWorkerCopy.RunWorkerCompleted += bwCopy_RunWorkerCompleted;

            objViewModel.bWorkerPesquisa.DoWork += new DoWorkEventHandler(this.metodoGetModel);
            objViewModel.bWorkerPesquisa.RunWorkerCompleted += bw_RunWorkerCompleted;
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
                        item: new EnderecoModel
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
                this.objViewModel.bWorkerSave.RunWorkerAsync();
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
                if (objViewModel.message.Save())
                {
                    this.objViewModel.currentModel = this.objService.SaveObject(this.objViewModel.currentModel);
                    e.Result = e.Argument;
                }

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
                if (e.Error != null)
                {
                    throw new Exception(message: e.Error.Message);
                }
                else
                {
                    if (objViewModel.message.bSave)
                    {
                        this.objViewModel.salvarBaseCommand.Execute(parameter: null);

                        object w = objViewModel.GetParentWindow(e.Result);

                        if (w != null)
                        {
                            w.GetType().GetProperty(name: "idSalvo").SetValue(obj: w, value: this.objViewModel.currentID);
                            (w as Window).DialogResult = true;
                            (w as Window).Close();
                        }
                        this.Inicia_Collections();
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

        public void Delete()
        {
            int iExcluir = 0;

            try
            {
                if (objViewModel.message.Excluir())
                {
                    if (this.objService.DeleteObject(this.objViewModel.currentID))
                    {
                        objViewModel.message.Excluido();
                        iExcluir = (int)this.objViewModel.currentModel.idFuncionario;
                        this.objViewModel.currentModel = null;
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
            if (this.objViewModel.bwHierarquia != null)
                if (this.objViewModel.bwHierarquia.IsBusy)
                    this.objViewModel.bwHierarquia.CancelAsync();

            this.objViewModel.currentModel = new FuncionarioModel();
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
            if (objViewModel.message.Cancelar())
            {
                this.PesquisarRegistro();
                this.objViewModel.cancelarBaseCommand.Execute(parameter: null);
            }
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
            if (this.objViewModel.bwHierarquia != null)
                if (this.objViewModel.bwHierarquia.IsBusy)
                {
                    this.bOpCancelada = true;
                }

            this.objViewModel.bWorkerPesquisa.RunWorkerAsync();
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Inicia_Collections();
            this.objViewModel.bTreeCarregada = false;
        }

        public void MontraTreeView()
        {
            TreeView t = new TreeView();
            t.Items.Add(newItem:
            new TreeViewItem
            {
                Header = "Hierarquia Funcionários"
            });


            TextBlock txt = new TextBlock();
            txt.Text = "Carregando Hierarquia...";

            this.objViewModel.hierarquiaFunc = txt;

            if (this.bOpCancelada)
            {
                txt.Text = "Cancelando carregamento de Hierarquia anterior, por favor, aguarde...";
                this.objViewModel.hierarquiaFunc = txt;
            }
            else
            {
                this.objViewModel.bwHierarquia.RunWorkerAsync(argument: t);
                this.objViewModel.bTreeCarregada = true;
            }
        }

        void bwHierarquia_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                throw new Exception(message: e.Error.Message);
            }
            else
            {
                if (this.bOpCancelada)
                {
                    this.bOpCancelada = false;
                    this.MontraTreeView();
                }
                else
                {
                    this.objViewModel.hierarquiaFunc = (TreeView)e.Result;
                }
            }
        }

        void bwHierarquia_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (!this.bOpCancelada)
                    this.GetHierarquiaFuncionario();
                if (!this.bOpCancelada)
                {
                    if (this.objViewModel.lObjHierarquia != null)
                        this.objViewModel.lObjHierarquia.MontaHierarquia(m: this.objViewModel.lObjHierarquia,
                             tvi: ((TreeView)e.Argument).Items[0] as TreeViewItem);
                    e.Result = e.Argument;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void metodoGetModel(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (this.objViewModel.currentID != 0)
                {
                    this.objViewModel.currentModel = this.objService.GetObject(id: this.objViewModel.currentID);
                    this.objViewModel.lObjHierarquia = null;
                }
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

        public void GetHierarquiaFuncionario()
        {
            this.objViewModel.lObjHierarquia = new modelToTreeView();
            this.objViewModel.lObjHierarquia = this.objService.GetHierarquia(idFuncionario: this.objViewModel.currentID);
        }



    }
}
