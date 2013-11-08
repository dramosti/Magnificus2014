using HLP.Comum.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum;
using HLP.Comum.Modules;
using System.Windows;
using System.Windows.Controls;
using HLP.Comum.Model.Models;
using HLP.Comum.Infrastructure.Static;

namespace HLP.Comum.ViewModel.Commands
{
    public class MainCommands
    {
        MainViewModel objviewModel;

        public MainCommands(MainViewModel objTabPagesAtivasViewModel)
        {
            try
            {
                this.objviewModel = objTabPagesAtivasViewModel;

                this.objviewModel.AddWindowCommand = new RelayCommand(
                    execute: ex => AddWindow(xNomeForm: ex),
                    canExecute: ex => AddWindowCanExecute());
                this.objviewModel.DelWindowCommand = new RelayCommand(
                    execute: ex => DelWindow(tabItem: ex),
                    canExecute: ex => DelWindowCanExecute());
                this.objviewModel.pesquisarBaseCommand = new RelayCommand(
                    execute: ex => ShowPesquisaExecute(),
                    canExecute: canExecute => ShowPesquisaCanEcexute());

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
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #region Executes & CanExecutes

        private void AddWindow(object xNomeForm)
        {
            try
            {
                Window form = GerenciadorModulo.Instancia.CarregaForm(nome: xNomeForm.ToString(),
                exibeForm: Modules.Interface.TipoExibeForm.Modal);

                TabPagesAtivasModel objTabPageAtivasModel = new TabPagesAtivasModel();
                objTabPageAtivasModel._windows = form;

                if (this.objviewModel._lTabPagesAtivas.Count(
                    i => i._windows.Name == form.Name) == 0)
                {
                    this.objviewModel._lTabPagesAtivas.Add(item: objTabPageAtivasModel);
                }
                this.objviewModel._currentTab = objTabPageAtivasModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private bool AddWindowCanExecute()
        {
            return true;
        }

        private void DelWindow(object tabItem)
        {
            try
            {
                this.objviewModel._lTabPagesAtivas.Remove(item: tabItem as TabPagesAtivasModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private bool DelWindowCanExecute()
        {
            return true;
        }

        private void ShowPesquisaExecute()
        {
            Window winPesquisa = GerenciadorModulo.Instancia.CarregaForm("WinPesquisaPadrao", Modules.Interface.TipoExibeForm.Normal);
            winPesquisa.WindowState = WindowState.Maximized;
            winPesquisa.SetPropertyValue("NameView", objviewModel._currentTab.NameView);

            if (winPesquisa != null)
            {
                winPesquisa.ShowDialog();

                if ((winPesquisa.GetPropertyValue("lResult") as List<int>).Count > 0)
                {
                    objviewModel.bsPesquisa.DataSource = (winPesquisa.GetPropertyValue("lResult") as List<int>);
                    this.ExecAcao(tpAcao.Primeiro);
                    objviewModel.visibilityNavegacao = Visibility.Visible;
                }
            }
        }
        private bool ShowPesquisaCanEcexute()
        {
            bool bReturn = false;
            if (objviewModel._currentTab != null)
            {
                if (objviewModel._currentTab.NameView != string.Empty)
                    bReturn = true;
                else
                    bReturn = false;
            }
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
                    objviewModel._currentTab.currentID = (int)objviewModel.bsPesquisa.Current;
                    objviewModel.sText = (objviewModel.bsPesquisa.IndexOf(objviewModel.bsPesquisa.Current) + 1).ToString() + " de " + objviewModel.bsPesquisa.Count.ToString();
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

        #endregion
    }
}
