using HLP.Base.ClassesBases;
using HLP.Components.Model.Models;
using HLP.Comum.ViewModel.ViewModel;
using HLP.Entries.Model.Models.Financeiro;
using HLP.Entries.Services.Financeiro;
using HLP.Entries.ViewModel.ViewModels.Financeiro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HLP.Entries.ViewModel.Commands.Financeiro
{
    public class BancoCommands
    {
        BancoViewModel objViewModel;
        BancoService servico = new BancoService();

        public BancoCommands(BancoViewModel objViewModel)
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

            this.objViewModel.bWorkerHierarquia.WorkerSupportsCancellation = true;
            this.objViewModel.bWorkerHierarquia.DoWork += bwHierarquia_DoWork;
            this.objViewModel.bWorkerHierarquia.RunWorkerCompleted += bwHierarquia_RunWorkerCompleted;

            objViewModel.bWorkerSave.DoWork += bwSalvar_DoWork;
            objViewModel.bWorkerSave.RunWorkerCompleted += bwSalvar_RunWorkerCompleted;

            objViewModel.bWorkerCopy.DoWork += bwCopy_DoWork;
            objViewModel.bWorkerCopy.RunWorkerCompleted += bwCopy_RunWorkerCompleted;

            objViewModel.bWorkerPesquisa.DoWork += new DoWorkEventHandler(this.getBanco);
            objViewModel.bWorkerPesquisa.RunWorkerCompleted += bw_RunWorkerCompleted;
        }


        #region Implementação Commands

        public void Save(object _panel)
        {
            try
            {
                objViewModel.bWorkerSave.RunWorkerAsync(_panel);
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
                    this.objViewModel.currentModel.idBanco = this.servico.SaveObject(objViewModel.currentModel);
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
                    if (this.servico.DeleteObject(this.objViewModel.currentModel))
                    {
                        objViewModel.message.Excluido();
                        iExcluir = (int)this.objViewModel.currentModel.idBanco;
                        this.objViewModel.currentModel = null;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.ToUpper().Contains("THE DELETE STATEMENT CONFLICTED WITH THE REFERENCE CONSTRAINT"))
                {
                    OperacoesDataBaseViewModel vm = new OperacoesDataBaseViewModel();
                    vm.ShowWinExclusionDenied(xMessage: ex.Message, xValor: this.objViewModel.currentID.ToString());
                }
                else if (ex.Message.ToUpper().Contains("A INSTRUÇÃO DELETE CONFLITOU COM A RESTRIÇÃO DO REFERENCE"))
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


        private void Novo(object _panel)
        {
            this.objViewModel.currentModel = new BancoModel();
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
                    this.objViewModel.viewModelComumCommands.SetFocusFirstControl();
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
            objViewModel.bWorkerPesquisa.RunWorkerAsync();
        }
        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.objViewModel.bTreeCarregada = false;
        }

        private void getBanco(object sender, DoWorkEventArgs e)
        {
            this.objViewModel.currentModel = this.servico.GetObject(this.objViewModel.currentID);
        }
        #endregion

        #region Hierarquia

        bool bOpCancelada = false;

        public void MontraTreeView()
        {
            TreeView t = new TreeView();
            t.Items.Add(newItem:
            new TreeViewItem
            {
                Header = "Hierarquia..."
            });


            TextBlock txt = new TextBlock();
            txt.Text = "Carregando Hierarquia...";

            this.objViewModel.hierarquiaConta = txt;

            if (this.bOpCancelada)
            {
                txt.Text = "Cancelando carregamento de Hierarquia anterior, por favor, aguarde...";
                this.objViewModel.hierarquiaConta = txt;
            }
            else
            {
                this.objViewModel.bWorkerHierarquia.RunWorkerAsync(argument: t);
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
                    this.objViewModel.hierarquiaConta = (TreeView)e.Result;
                }
            }
        }

        void bwHierarquia_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (!this.bOpCancelada)
                    this.GetHierarquiaSite();
                if (!this.bOpCancelada)
                {
                    this.objViewModel.lObjHierarquia.MontaHierarquia(this.objViewModel.lObjHierarquia, ((TreeView)e.Argument).Items[0] as TreeViewItem);
                    e.Result = e.Argument;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GetHierarquiaSite()
        {
            this.objViewModel.lObjHierarquia = new modelToTreeView();
            this.objViewModel.lObjHierarquia = this.servico.GetHierarquia((int)this.objViewModel.currentModel.idBanco);
        }
        #endregion
    }
}
