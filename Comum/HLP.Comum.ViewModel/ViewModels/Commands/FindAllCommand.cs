using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using HLP.Comum.ViewModel.ViewModels;

namespace HLP.Comum.ViewModel.Commands
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
