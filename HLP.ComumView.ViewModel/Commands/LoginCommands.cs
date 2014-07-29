using HLP.Base.ClassesBases;
using HLP.Base.Static;
using HLP.Comum.Facade.Magnificus;
using HLP.ComumView.ViewModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using HLP.ComumView.Services;
using HLP.Entries.Services.Parametros;
using HLP.Entries.Model.Models.Gerais;

namespace HLP.ComumView.ViewModel.Commands
{
    public class LoginCommands
    {
        LoginViewModel objViewModel;
        LoginService objService;
        EmpresaParametrosService objServiceEmpresa;

        public LoginCommands(LoginViewModel objViewModel)
        {
            this.objViewModel = objViewModel;
            objViewModel.fecharCommand = new RelayCommand(execute: i => this.FecharExec());
            objViewModel.loginCommand = new RelayCommand(execute: i => this.LoginExec(objDependency: i),
                canExecute: i => this.LoginCanExec(objDependency: i));
            objService = new LoginService();
            objServiceEmpresa = new EmpresaParametrosService();
        }

        private void FecharExec()
        {
            Application.Current.Shutdown();
        }

        private void LoginExec(object objDependency)
        {
            this.objViewModel.currentModel.xError = string.Empty;
            foreach (UIElement item in (objDependency as Panel).Children)
            {
                if (item.GetType() == typeof(PasswordBox))
                {

                    if (objService.ValidaLogin(xId: this.objViewModel.currentModel.xId,
                        xSenha: (item as PasswordBox).Password) < 1)
                        this.objViewModel.currentModel.xError = "* Senha incorreta!";
                    else if (objService.ValidaAcesso(idEmpresa: this.objViewModel.currentModel.idEmpresa,
                        xId: this.objViewModel.currentModel.xId) < 1)
                    {
                        this.objViewModel.currentModel.xError = "* Usuário não tem acesso a empresa selecionada!";
                    }
                    else
                    {
                        UserData.idUser = objService.GetIdFuncionarioByXid(xId: this.objViewModel.currentModel.xId);
                        CompanyData.idEmpresa = this.objViewModel.currentModel.idEmpresa;
                        CompanyData.objEmpresaModel = objServiceEmpresa.GetObject(this.objViewModel.currentModel.idEmpresa);

                        this.objViewModel.bLogado = true;
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
