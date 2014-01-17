using HLP.Comum.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HLP.Comum.ViewModel.Commands
{
    public class LoginCommands
    {
        LoginViewModel objViewModel;
        public LoginCommands(LoginViewModel objViewModel)
        {
            this.objViewModel = objViewModel;
            objViewModel.fecharCommand = new RelayCommand(execute: i => this.FecharExec());
        }

        private void FecharExec()
        {
            Application.Current.Shutdown();
        }
    }
}
