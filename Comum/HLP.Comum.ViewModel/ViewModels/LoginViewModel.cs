using HLP.Comum.Infrastructure.Static;
using HLP.Comum.Model.Models;
using HLP.Comum.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HLP.Comum.ViewModel.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public ICommand fecharCommand { get; set; }
        public ICommand loginCommand { get; set; }
        public bool bLogado = false;

        funcionarioService.IserviceFuncionarioClient funcService;

        public LoginViewModel(ModoInicial st)
        {
            LoginCommands cmm = new LoginCommands(objViewModel: this);
            this.currentLogin = new loginModel();

            switch (st)
            {
                case ModoInicial.trocaUsuario:
                    {
                        this.currentLogin.idEmpresa = CompanyData.idEmpresa;
                    }
                    break;
                case ModoInicial.trocaEmpresa:
                    {
                        funcService = new funcionarioService.IserviceFuncionarioClient();

                        funcionarioService.FuncionarioModel objFunc = funcService.getFuncionario(idFuncionario: UserData.idUser);
                        if (objFunc != null)
                            this.currentLogin.xId = objFunc.xID;
                    }
                    break;
                default:
                    break;
            }
        }

        private loginModel _currentLogin;

        public loginModel currentLogin
        {
            get { return _currentLogin; }
            set
            {
                _currentLogin = value;
                base.NotifyPropertyChanged(propertyName: "currentLogin");
            }
        }

    }

    public enum ModoInicial
    {
        padrao,
        trocaUsuario,
        trocaEmpresa
    }
}
