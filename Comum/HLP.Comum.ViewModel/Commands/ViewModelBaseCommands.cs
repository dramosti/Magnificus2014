using HLP.Comum.Model.Models;
using HLP.Comum.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Resources.RecursosBases;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using HLP.Comum.Modules;
using HLP.Comum.Infrastructure.Static;
using System.Collections.ObjectModel;

namespace HLP.Comum.ViewModel.Commands
{
    public class ViewModelBaseCommands
    {
        ViewModelBase objviewModel;
        private OperacaoCadastro _currentOp;
        public OperacaoCadastro currentOp
        {
            get
            { return this._currentOp; }
            set
            {
                Dispatcher.CurrentDispatcher.BeginInvoke(
                    method: new Action(() => this._currentOp = value),
                    priority: DispatcherPriority.Background, args: null);
                Dispatcher.CurrentDispatcher.BeginInvoke(
                    method: new Action(() => CommandManager.InvalidateRequerySuggested()),
                    priority: DispatcherPriority.Background, args: null);
            }
        }


        public ViewModelBaseCommands(ViewModelBase vViewModel)
        {
            this.objviewModel = vViewModel;
            this.objviewModel.novoBaseCommand = new RelayCommand(execute: pExec => this.novoBase(),
                canExecute: pCanExec => this.novoBaseCanExecute());
            this.objviewModel.alterarBaseCommand = new RelayCommand(execute: pExec => this.alterarBase(),
                canExecute: pCanExec => this.alterarBaseCanExecute());
            this.objviewModel.deletarBaseCommand = new RelayCommand(execute: pExec => this.delBase(),
                canExecute: pCanExec => this.delBaseCanExecute());
            this.objviewModel.salvarBaseCommand = new RelayCommand(execute: pExec => this.salvarBase(),
                canExecute: pCanExec => this.salvarBaseCanExecute());
            this.objviewModel.cancelarBaseCommand = new RelayCommand(execute: pExec => this.cancelarBase(),
                canExecute: pCanExec => this.cancelarBaseCanExecute());
            this.objviewModel.pesquisarBaseCommand = new RelayCommand(
                    execute: ex => ShowPesquisaExecute(),
                    canExecute: canExecute => ShowPesquisaCanEcexute());

            this.currentOp = OperacaoCadastro.livre;
            this.objviewModel.proximoCommand = new RelayCommand(
              execute: exec => ExecAcao(tpAcao.Proximo),
              canExecute: CanExec => CanExecAcao());

            this.objviewModel.anteriorCommand = new RelayCommand(
               execute: exec => ExecAcao(tpAcao.Anterior),
               canExecute: CanExec => CanExecAcao());

            this.objviewModel.primeiroCommand = new RelayCommand(
               execute: exec => ExecAcao(tpAcao.Primeiro),
               canExecute: CanExec => CanExecAcao());

            this.objviewModel.ultimoCommand = new RelayCommand(
               execute: exec => ExecAcao(tpAcao.Ultimo),
               canExecute: CanExec => CanExecAcao());

            this.ExecAcao(tpAcao.Primeiro);
        }

        #region Executes & CanExecutes


        private void ShowPesquisaExecute()
        {
            Window winPesquisa = GerenciadorModulo.Instancia.CarregaForm("WinPesquisaPadrao", Modules.Interface.TipoExibeForm.Normal);
            winPesquisa.WindowState = WindowState.Maximized;
            winPesquisa.SetPropertyValue("NameView", objviewModel.NameView);

            if (winPesquisa != null)
            {
                winPesquisa.ShowDialog();

                if ((winPesquisa.GetPropertyValue("lResult") as List<int>).Count > 0)
                {
                    objviewModel.bsPesquisa.DataSource = new ObservableCollection<int>((winPesquisa.GetPropertyValue("lResult") as List<int>));
                    objviewModel.primeiroCommand.Execute(HLP.Comum.ViewModel.Commands.ViewModelBaseCommands.tpAcao.Primeiro);
                    objviewModel.visibilityNavegacao = Visibility.Visible;
                }
            }
        }
        private bool ShowPesquisaCanEcexute()
        {
            bool bReturn = false;

            if (objviewModel.NameView != string.Empty)
                bReturn = true;
            else
                bReturn = false;

            return bReturn;
        }



        public void ExecAcao(tpAcao tipoAcao)
        {
            try
            {
                switch (tipoAcao)
                {
                    case tpAcao.Primeiro:
                        objviewModel.bsPesquisa.MoveFirst();
                        break;
                    case tpAcao.Anterior:
                        objviewModel.bsPesquisa.MovePrevious();
                        break;
                    case tpAcao.Proximo:
                        objviewModel.bsPesquisa.MoveNext();
                        break;
                    case tpAcao.Ultimo:
                        objviewModel.bsPesquisa.MoveLast();
                        break;
                    default:
                        break;
                }
                if (objviewModel.bsPesquisa.Current != null)
                {
                    try
                    {
                        objviewModel.currentID = (int)objviewModel.bsPesquisa.Current;
                        objviewModel.sText = (objviewModel.bsPesquisa.IndexOf(objviewModel.bsPesquisa.Current) + 1).ToString() + " de " + objviewModel.bsPesquisa.Count.ToString();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public bool CanExecAcao()
        {
            if (objviewModel.bsPesquisa.DataSource != null)
                return true;
            else
                return false;
        }

        public enum tpAcao { Primeiro, Anterior, Proximo, Ultimo }

        private void novoBase()
        {
            this.currentOp = Resources.RecursosBases.OperacaoCadastro.criando;
            this.objviewModel.bIsEnabled = true;
        }
        private bool novoBaseCanExecute()
        {
            return (this.currentOp == Resources.RecursosBases.OperacaoCadastro.livre
                || this.currentOp == Resources.RecursosBases.OperacaoCadastro.pesquisando);
        }

        private void alterarBase()
        {
            this.currentOp = Resources.RecursosBases.OperacaoCadastro.alterando;
            this.objviewModel.bIsEnabled = true;
        }
        private bool alterarBaseCanExecute()
        {
            return this.currentOp == Resources.RecursosBases.OperacaoCadastro.pesquisando;
        }

        private void delBase()
        {
            this.currentOp = Resources.RecursosBases.OperacaoCadastro.livre;
        }
        private bool delBaseCanExecute()
        {
            return this.currentOp == Resources.RecursosBases.OperacaoCadastro.pesquisando;
        }

        private void salvarBase()
        {
            this.currentOp = Resources.RecursosBases.OperacaoCadastro.pesquisando;
            this.objviewModel.bIsEnabled = false;
        }
        private bool salvarBaseCanExecute()
        {
            if (this.currentOp != Resources.RecursosBases.OperacaoCadastro.criando &&
                this.currentOp != Resources.RecursosBases.OperacaoCadastro.alterando)
                return false;
            else
                return true;
        }

        private void cancelarBase()
        {
            this.currentOp = Resources.RecursosBases.OperacaoCadastro.livre;
            this.objviewModel.bIsEnabled = false;
        }
        private bool cancelarBaseCanExecute()
        {
            return (this.currentOp == Resources.RecursosBases.OperacaoCadastro.criando ||
                this.currentOp == Resources.RecursosBases.OperacaoCadastro.alterando);
        }

        #endregion

    }
}
