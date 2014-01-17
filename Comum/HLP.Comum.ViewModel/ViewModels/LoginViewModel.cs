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

        public LoginViewModel()
        {
            LoginCommands cmm = new LoginCommands(objViewModel: this);
            this.currentLogin = new loginModel();
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
}
