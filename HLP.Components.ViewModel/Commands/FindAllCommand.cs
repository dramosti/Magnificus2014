using HLP.Base.ClassesBases;
using HLP.Components.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HLP.Components.ViewModel.Commands
{
    public class FindAllCommand
    {
        FindAllViewModel objViewModel;

        public FindAllCommand(FindAllViewModel objViewModel)
        {
            this.objViewModel = objViewModel;

            objViewModel.CloseWindowCommand = new RelayCommand(execute: i => this.CloseWindow(win: i),
                canExecute: i => true);
        }


        private void CloseWindow(object win)
        {
            Window window = win as Window;
            window.Close();
        }
    }
}
