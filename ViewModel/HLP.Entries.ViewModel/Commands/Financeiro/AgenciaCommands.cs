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
    public class AgenciaCommands
    {
        AgenciaViewModel objViewModel;
        AgenciaService objService;

        public AgenciaCommands(AgenciaViewModel objViewModel)
        {
            objService = new AgenciaService();
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
            this.objViewModel.bWorkerHierarquia = new BackgroundWorker();
            this.objViewModel.bWorkerHierarquia.WorkerSupportsCancellation = true;
            this.objViewModel.bWorkerHierarquia.DoWork += bwHierarquia_DoWork;
            this.objViewModel.bWorkerHierarquia.RunWorkerCompleted += bwHierarquia_RunWorkerCompleted;

            objViewModel.bWorkerSave.DoWork += bwSalvar_DoWork;
            objViewModel.bWorkerSave.RunWorkerCompleted += bwSalvar_RunWorkerCompleted;

            objViewModel.bWorkerCopy.DoWork += bwCopy_DoWork;
            objViewModel.bWorkerCopy.RunWorkerCompleted += bwCopy_RunWorkerCompleted;

            objViewModel.bWorkerPesquisa.DoWork += new DoWorkEventHandler(this.GetAgencia);
            objViewModel.bWorkerPesquisa.RunWorkerCompleted += bw_RunWorkerCompleted;
        }

        private void IniciaCollections()
        {
            if (this.objViewModel.currentModel != null)
            {
                this.objViewModel.currentModel.lAgencia_ContatoModel.CollectionCarregada();
                this.objViewModel.currentModel.lAgencia_EnderecoModel.CollectionCarregada();
            }
        }

        #region Implementação Commands

        public void Save(object _panel)
        {
            try
            {
                foreach (int id in this.objViewModel.currentModel.lAgencia_ContatoModel.idExcluidos)
                {
                    this.objViewModel.currentModel.lAgencia_ContatoModel.Add(
                        item: new ContatoModel
                        {
                            idContato = id,
                            status = Base.EnumsBases.statusModel.excluido
                        });
                }
                foreach (int id in this.objViewModel.currentModel.lAgencia_EnderecoModel.idExcluidos)
                {
                    this.objViewModel.currentModel.lAgencia_EnderecoModel.Add(
                        item: new EnderecoModel
                        {
                            idEndereco = id,
                            status = Base.EnumsBases.statusModel.excluido
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
            try
            {
                if (objViewModel.message.Save())
                {
                    this.objViewModel.currentModel = objService.SaveObject(
                    obj: this.objViewModel.currentModel);
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

                        while (this.objViewModel.currentModel.lAgencia_ContatoModel.Count(i => i.status == Base.EnumsBases.statusModel.excluido) > 1)
                        {
                            this.objViewModel.currentModel.lAgencia_ContatoModel.RemoveAt(
                                this.objViewModel.currentModel.lAgencia_ContatoModel.IndexOf(
                                item: this.objViewModel.currentModel.lAgencia_ContatoModel.FirstOrDefault(i => i.status == Base.EnumsBases.statusModel.excluido)));
                        }

                        while (this.objViewModel.currentModel.lAgencia_EnderecoModel.Count(i => i.status == Base.EnumsBases.statusModel.excluido) > 1)
                        {
                            this.objViewModel.currentModel.lAgencia_EnderecoModel.RemoveAt(
                                this.objViewModel.currentModel.lAgencia_EnderecoModel.IndexOf(
                                item: this.objViewModel.currentModel.lAgencia_EnderecoModel.FirstOrDefault(i => i.status == Base.EnumsBases.statusModel.excluido)));
                        }

                        this.IniciaCollections();
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
            int iRemoved = (int)this.objViewModel.currentModel.idAgencia;
            try
            {
                if (objViewModel.message.Excluir())
                {
                    if (this.objService.DeleteObject(id: this.objViewModel.currentModel.idAgencia ?? 0))
                    {
                        objViewModel.message.Excluido();
                        if (this.objViewModel.currentModel == null) this.objViewModel.deletarBaseCommand.Execute(parameter: iRemoved);
                        this.objViewModel.currentModel = null;
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
                    this.objViewModel.deletarBaseCommand.Execute(parameter: iRemoved);
                    this.PesquisarRegistro();
                }
            }
        }


        private void Novo(object _panel)
        {
            this.objViewModel.currentModel = new AgenciaModel();
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
            this.objViewModel.bWorkerPesquisa.RunWorkerAsync();
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.IniciaCollections();
                this.objViewModel.bTreeCarregada = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GetAgencia(object sender, DoWorkEventArgs e)
        {
            this.objViewModel.currentModel =
                this.objService.GetObject(id: this.objViewModel.currentID);
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
            this.objViewModel.lObjHierarquia = this.objService.GetHierarquia((int)this.objViewModel.currentModel.idAgencia);
        }
        #endregion


    }
}
