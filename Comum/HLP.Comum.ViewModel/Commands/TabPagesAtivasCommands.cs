using HLP.Comum.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Comum.ViewModel.Commands
{
    public class TabPagesAtivasCommands
    {
        TabPagesAtivasViewModel _objTabPagesAtivasViewModel;

        public TabPagesAtivasCommands(TabPagesAtivasViewModel objTabPagesAtivasViewModel)
        {
            try
            {
                this._objTabPagesAtivasViewModel = objTabPagesAtivasViewModel;

                this._objTabPagesAtivasViewModel.AddWindowCommand = new RelayCommand(
                    execute: ex => AddWindow(),
                    canExecute: ex => AddWindowCanExecute());
                this._objTabPagesAtivasViewModel.DelWindowCommand = new RelayCommand(
                    execute: ex => DelWindow(),
                    canExecute: ex => DelWindowCanExecute());
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #region Executes & CanExecutes

        private void AddWindow()
        {

        }

        private bool AddWindowCanExecute()
        {
            return true;
        }

        private void DelWindow()
        {
        }

        private bool DelWindowCanExecute()
        {
            return true;
        }

        #endregion
    }
}
