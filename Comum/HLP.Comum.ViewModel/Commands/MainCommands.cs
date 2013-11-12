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
using HLP.Comum.Resources.RecursosBases;

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
                    canExecute: ex => AddWindowCanExecute(xNomeForm: ex));
                this.objviewModel.DelWindowCommand = new RelayCommand(
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
        private bool AddWindowCanExecute(object xNomeForm)
        {
            bool bReturn = true;
            if (this.objviewModel._currentTab != null)
                if (this.objviewModel._currentTab._windows != null)
                    if (this.objviewModel._currentTab._windows.Name == xNomeForm.ToString())
                        bReturn = false;
            return bReturn;
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

        #endregion
    }
}
