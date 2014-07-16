using HLP.Base.ClassesBases;
using HLP.Base.Static;
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
        Empresa_ParametrosViewModel objViewModel;
        HLP.Entries.Services.Parametros.EmpresaParametrosService servico = new Entries.Services.Parametros.EmpresaParametrosService();
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

            objViewModel.bWorkerSave.DoWork += bwSalvar_DoWork;
            objViewModel.bWorkerSave.RunWorkerCompleted += bwSalvar_RunWorkerCompleted;
        }


        #region Implementação Commands

        public void Save(object _panel)
        {
            try
            {
                this.objViewModel.bWorkerSave.RunWorkerAsync(argument: _panel);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        void bwSalvar_DoWork(object sender, DoWorkEventArgs e)
        {
            if (objViewModel.message.Save())
            {                
                servico.SaveObject(this.objViewModel.currentModel.empresaParametros);
                e.Result = e.Argument;
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
            try
            {

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
        }
        private bool NovoCanExecute()
        {
            return false;
            //return this.objViewModel.novoBaseCommand.CanExecute(parameter: null);
        }

        private void Alterar(object _panel)
        {
            this.objViewModel.alterarBaseCommand.Execute(parameter: _panel);
        }
        private bool AlterarCanExecute()
        {
            //return this.objViewModel.alterarBaseCommand.CanExecute(parameter: null);
            return (this.objViewModel.currentModel as modelBase).GetOperationModel() != Base.EnumsBases.OperationModel.updating;
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
            //this.PesquisarRegistro();
            this.objViewModel.currentModel = this.servico.GetObject(CompanyData.idEmpresa);
        }
        private void PesquisarRegistro()
        {
            this.objViewModel.bWorkerPesquisa.RunWorkerAsync();

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
        private void metodoGetModel(object sender, DoWorkEventArgs e)
        {
            //não será possível pesquisar os paramêtros da empresa, pois sempre será uma parametrização por empresa
            this.objViewModel.currentModel = this.servico.GetObject(CompanyData.idEmpresa);
        }

        #endregion


    }
}
