﻿using HLP.Comum.Facade.Magnificus;
using HLP.Comum.Infrastructure.Static;
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
            objViewModel.loginCommand = new RelayCommand(execute: i => this.LoginExec(objDependency: i),
                canExecute: i => this.LoginCanExec(objDependency: i));
        }

        private void FecharExec()
        {
            Application.Current.Shutdown();
        }

        private void LoginExec(object objDependency)
        {
            foreach (UIElement item in (objDependency as Panel).Children)
            {
                if (item.GetType() == typeof(PasswordBox))
                {
                    if (loginFacade.loginClient == null)
                        loginFacade.loginClient = new Facade.loginService.IserviceLoginClient();

                    if (loginFacade.loginClient.ValidaLogin(xId: this.objViewModel.currentLogin.xId,
                        xSenha: (item as PasswordBox).Password) < 1)
                        MessageBox.Show(messageBoxText: "Login e Senha incorretos.");
                    else
                    {
                        UserData.idUser = loginFacade.loginClient.GetIdFuncionarioByXid(xId: this.objViewModel.currentLogin.xId);
                        CompanyData.idEmpresa = this.objViewModel.currentLogin.idEmpresa;
                        SearchWindow(objeto: objDependency);
                    }
                }
            }
        }

        private void SearchWindow(object objeto)
        {
            if (objeto.GetType().BaseType == typeof(Window))
                (objeto as Window).Close();
            else
                this.SearchWindow(objeto: (objeto as Panel).Parent);
        }

        private bool LoginCanExec(object objDependency)
        {
            return this.objViewModel.IsValid(objDependency as Panel);
        }
    }
}
