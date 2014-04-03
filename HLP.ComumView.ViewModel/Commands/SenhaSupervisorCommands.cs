using HLP.Base.ClassesBases;
using HLP.ComumView.ViewModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HLP.ComumView.ViewModel.Commands
{
    public class SenhaSupervisorCommands
    {
        SenhaSupervisorViewModel objViewModel;

        public SenhaSupervisorCommands(SenhaSupervisorViewModel objViewModel)
        {
            this.objViewModel = objViewModel;
            //if (loginFacade.loginClient == null)
            //    loginFacade.loginClient
            //        = new Facade.loginService.IserviceLoginClient();
            this.objViewModel.autorizarCommand = new RelayCommand(execute: execute => this.AutorizarExecute(o: execute),
                canExecute: canExecute => this.AutorizarCanExecute(o: canExecute));
        }

        private void AutorizarExecute(object o)
        {
            Grid objGrid = (o as Window).FindName(name: "GridPrincipal") as Grid;

            foreach (UIElement item in objGrid.Children)
            {
                if (item.GetType() == typeof(PasswordBox))
                {

                    //if (loginFacade.loginClient.ValidaLogin(xId: this.objViewModel.currentModel.xId,
                    //    xSenha: (item as PasswordBox).Password) < 1)
                    //    this.objViewModel.error = "* Senha incorreta!";
                    //else if (loginFacade.loginClient.ValidaAdministrador(xID: this.objViewModel.currentModel.xId, xSenha: (item as PasswordBox).Password,
                    //    idEmpresa: CompanyData.idEmpresa) < 1)
                    //{
                    //    this.objViewModel.error = "* Usuário não é administrador!";
                    //}
                    //else
                    //{
                    //    (o as Window).DialogResult = true;
                    //    (o as Window).Close();
                    //}
                }
            }


        }

        private bool AutorizarCanExecute(object o)
        {
            return true;
        }
    }
}
