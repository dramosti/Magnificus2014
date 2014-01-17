using HLP.Comum.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HLP.Comum.ViewModel.Commands
{
    public class LoginCommands
    {
        LoginViewModel objViewModel;
        public LoginCommands(LoginViewModel objViewModel)
        {
            this.objViewModel = objViewModel;
            objViewModel.fecharCommand = new RelayCommand(execute: i => this.FecharExec());
            objViewModel.loginCommand = new RelayCommand(execute: i => this.LoginExec(),
                canExecute: i => this.LoginCanExec(objDependency: i));
        }

        private void FecharExec()
        {
            Application.Current.Shutdown();
        }

        private void LoginExec()
        {

        }

        private bool LoginCanExec(object objDependency)
        {
            return this.objViewModel.IsValid(objDependency as Panel);
        }
    }
}
