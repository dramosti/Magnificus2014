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
                    execute: ex => DelWindow(xNomeForm: ex),
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
                if (_objTabPagesAtivasViewModel._lTabPagesAtivas.Count(
                    predicate: i => i._xNomeTab == xNomeForm.ToString()) > 0)
                {
                    return;
                }

                Window form = GerenciadorModulo.Instancia.CarregaForm(nome: xNomeForm.ToString(),
                exibeForm: Modules.Interface.TipoExibeForm.Modal);

                object o = form != null ? form.Content :
                    new Exception("Form não existe");

                StackPanel stkTemp = new StackPanel();
                stkTemp.Children.Add(element: o as UIElement);

                TabItem tabItem = new TabItem();
                tabItem.Content = stkTemp;

                TabPagesAtivasModel objTabPageAtivasModel = new TabPagesAtivasModel();
                objTabPageAtivasModel._openTab = tabItem;
                objTabPageAtivasModel._xNomeTab = (o as Window).Name;
                this._objTabPagesAtivasViewModel._lTabPagesAtivas.Add(item: objTabPageAtivasModel);
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

        private void DelWindow(object xNomeForm)
        {
            try
            {
                TabPagesAtivasModel form = _objTabPagesAtivasViewModel
                    ._lTabPagesAtivas.FirstOrDefault(predicate: i => i._xNomeTab == xNomeForm.ToString());
                _objTabPagesAtivasViewModel._lTabPagesAtivas.Remove(item: form);
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
