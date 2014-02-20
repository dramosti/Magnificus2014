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
using System.Windows.Data;
using System.Windows.Controls;
using System.ComponentModel;

namespace HLP.Comum.ViewModel.Commands
{
    public class ViewModelBaseCommands<T> where T : class
    {
        public ViewModelBase<T> objviewModel;
        private OperacaoCadastro _currentOp;
        public OperacaoCadastro currentOp
        {
            get
            { return this._currentOp; }
            set
            {
                this._currentOp = value;
            }
        }


        public ViewModelBaseCommands(object vViewModel)
        {
            this.objviewModel = vViewModel as ViewModelBase<T>;
            this.objviewModel.novoBaseCommand = new RelayCommand(execute: pExec => this.novoBase(panel: pExec),
                canExecute: pCanExec => this.novoBaseCanExecute());
            this.objviewModel.alterarBaseCommand = new RelayCommand(execute: pExec => this.alterarBase(panel: pExec),
                canExecute: pCanExec => this.GenericCanExecute());
            this.objviewModel.deletarBaseCommand = new RelayCommand(execute: pExec => this.delBase(iRemoved: pExec),
                canExecute: pCanExec => this.GenericCanExecute());
            this.objviewModel.salvarBaseCommand = new RelayCommand(execute: pExec => this.salvarBase(panel: pExec),
                canExecute: pCanExec => this.salvarBaseCanExecute());
            this.objviewModel.cancelarBaseCommand = new RelayCommand(execute: pExec => this.cancelarBase(),
                canExecute: pCanExec => this.cancelarBaseCanExecute());
            this.objviewModel.copyBaseCommand = new RelayCommand(execute: pExec => this.GenericCanExecute(),
                canExecute: pCanExec => this.GenericCanExecute());
            this.objviewModel.fecharCommand = new RelayCommand(execute: pExec => this.Fechar(wd: pExec),
                canExecute: pCanExec => this.FecharCanExecute(wd: pCanExec));

            this.currentOp = OperacaoCadastro.livre;

            this.objviewModel.pesquisarBaseCommand = new RelayCommand(
                 execute: ex => ShowPesquisaExecute(),
                 canExecute: canExecute => ShowPesquisaCanEcexute());

            this.objviewModel.navegarBaseCommand = new RelayCommand(
               execute: exec => ExecAcao(ContentBotao: exec),
               canExecute: CanExec => CanExecAcao(ContentBotao: CanExec));

        }

        #region Executes & CanExecutes

        private void Fechar(object wd)
        {
            ((Window)wd).Close();
        }
        private bool FecharCanExecute(object wd)
        {
            return true;
        }

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
                    objviewModel.navigatePesquisa = new MyObservableCollection<int>((winPesquisa.GetPropertyValue("lResult") as List<int>));
                    //MessageBox.Show(this.delBaseCanExecute().ToString());
                    objviewModel.navegarBaseCommand.Execute("Primeiro");
                    objviewModel.visibilityNavegacao = Visibility.Visible;
                    this.currentOp = OperacaoCadastro.pesquisando;
                }
            }
        }
        private bool ShowPesquisaCanEcexute()
        {
            bool bReturn = false;

            if ((objviewModel.NameView != string.Empty) && ((this.currentOp == OperacaoCadastro.livre) || (this.currentOp == OperacaoCadastro.pesquisando)))
                bReturn = true;
            else
                bReturn = false;

            return bReturn;
        }

        public void ExecAcao(object ContentBotao)
        {
            try
            {
                switch (ContentBotao.ToString())
                {
                    case "btnPrimeiro":
                        objviewModel.navigatePesquisa.MoveFirst();
                        break;
                    case "btnAnterior":
                        objviewModel.navigatePesquisa.MovePrevious();
                        break;
                    case "btnProximo":
                        objviewModel.navigatePesquisa.MoveNext();
                        break;
                    case "btnUltimo":
                        objviewModel.navigatePesquisa.MoveLast();
                        break;
                    default:
                        break;
                }
                if (objviewModel.navigatePesquisa != null)
                {
                    try
                    {
                        //int i =  objviewModel.currentID;

                        if (objviewModel.navigatePesquisa.Count > 0)
                        {
                            objviewModel.iPositionCollection = objviewModel.navigatePesquisa.CurrentPosition;
                            objviewModel.currentID = (int)objviewModel.navigatePesquisa.CurrentValue;
                        }
                        objviewModel.sText = (objviewModel.navigatePesquisa.CurrentPosition + 1).ToString() + " de " + objviewModel.navigatePesquisa.Count.ToString();
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
        public bool CanExecAcao(object ContentBotao)
        {

            bool bCanExecute = false;
            int currentPosition;
            int lastIndex;

            if (objviewModel.navigatePesquisa != null)
            {
                if (objviewModel.navigatePesquisa.Count() > 0)
                {
                    switch (ContentBotao.ToString())
                    {
                        case "btnPrimeiro":
                            bCanExecute = true;
                            break;
                        case "btnAnterior":
                            currentPosition = objviewModel.navigatePesquisa.CurrentPosition;
                            bCanExecute = currentPosition > 0;
                            break;
                        case "btnProximo":
                            {
                                currentPosition = objviewModel.navigatePesquisa.CurrentPosition;
                                lastIndex = objviewModel.navigatePesquisa.Count - 1;
                                bCanExecute = currentPosition < lastIndex;
                            }
                            break;
                        case "btnUltimo":
                            bCanExecute = true;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    objviewModel.sText = (objviewModel.navigatePesquisa.CurrentPosition + 1).ToString() + " de " + objviewModel.navigatePesquisa.Count.ToString();
                }
            }
            return bCanExecute;
        }

        private void novoBase(object panel)
        {
            this.currentOp = Resources.RecursosBases.OperacaoCadastro.criando;
            this.objviewModel.bIsEnabled = true;
            this.objviewModel.navigatePesquisa = new MyObservableCollection<int>(new List<int>());
            objviewModel.currentID = 0;
            objviewModel.SetFocusFirstTab(panel as Panel);
        }



        private bool novoBaseCanExecute()
        {
            return (this.currentOp == Resources.RecursosBases.OperacaoCadastro.livre
                || this.GenericCanExecute());
        }

        private void alterarBase(object panel)
        {
            this.objviewModel.bIsEnabled = true;
            this.currentOp = Resources.RecursosBases.OperacaoCadastro.alterando;
            this.objviewModel.SetFocusFirstTab(panel as Panel);
        }

        private void delBase(object iRemoved)
        {
            if (this.objviewModel.navigatePesquisa != null)
            {
                if (iRemoved == null)
                {
                    throw new Exception("É necessário corrigir o método de Excluir!");
                }
                else
                {
                    if (objviewModel.navigatePesquisa.Where(c => c == (int)iRemoved).Count() > 0)
                    {
                        objviewModel.navigatePesquisa.Remove((int)iRemoved);
                    }

                    if (objviewModel.navigatePesquisa.Count() > 0)
                    {
                        this.currentOp = Resources.RecursosBases.OperacaoCadastro.pesquisando;
                    }
                    else
                    {
                        this.currentOp = Resources.RecursosBases.OperacaoCadastro.livre;
                    }
                    this.ExecAcao("");

                }
            }
        }

        private void salvarBase(object panel)
        {
            this.currentOp = Resources.RecursosBases.OperacaoCadastro.pesquisando;
            this.objviewModel.bIsEnabled = false;
            if (panel != null)
            {
                objviewModel.FocusToComponente(panel as Panel, Util.focoComponente.Primeiro);
            }
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
            System.Threading.Thread.Sleep(200);
            if (objviewModel.currentID == 0)
            {
                this.currentOp = Resources.RecursosBases.OperacaoCadastro.livre;
            }
            else
            {
                this.currentOp = Resources.RecursosBases.OperacaoCadastro.pesquisando;
            }
            this.objviewModel.bIsEnabled = false;

        }
        private bool cancelarBaseCanExecute()
        {
            return (this.currentOp == Resources.RecursosBases.OperacaoCadastro.criando ||
                this.currentOp == Resources.RecursosBases.OperacaoCadastro.alterando);
        }


        private bool GenericCanExecute()
        {
            return this.currentOp == OperacaoCadastro.pesquisando;
        }


        #endregion

    }
}
