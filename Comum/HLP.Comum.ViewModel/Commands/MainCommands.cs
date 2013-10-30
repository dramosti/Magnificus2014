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

namespace HLP.Comum.ViewModel.Commands
{
    public class MainCommands
    {
        MainViewModel _objTabPagesAtivasViewModel;

        public MainCommands(MainViewModel objTabPagesAtivasViewModel)
        {
            try
            {
                this._objTabPagesAtivasViewModel = objTabPagesAtivasViewModel;

                this._objTabPagesAtivasViewModel.AddWindowCommand = new RelayCommand(
                    execute: ex => AddWindow(xNomeForm: ex),
                    canExecute: ex => AddWindowCanExecute());
                this._objTabPagesAtivasViewModel.DelWindowCommand = new RelayCommand(
                    execute: ex => DelWindow(tabItem: ex),
                    canExecute: ex => DelWindowCanExecute());
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

                if (this._objTabPagesAtivasViewModel._lTabPagesAtivas.Count(
                    i => i._windows.Name == form.Name) == 0)
                {
                    this._objTabPagesAtivasViewModel._lTabPagesAtivas.Add(item: objTabPageAtivasModel);
                }
                this._objTabPagesAtivasViewModel._currentTab = objTabPageAtivasModel;
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
                this._objTabPagesAtivasViewModel._lTabPagesAtivas.Remove(item: tabItem as TabPagesAtivasModel);
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

        #endregion
    }
}
