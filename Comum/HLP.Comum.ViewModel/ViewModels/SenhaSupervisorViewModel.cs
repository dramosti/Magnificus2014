using HLP.Comum.Infrastructure.Static;
using HLP.Comum.Model.Models;
using HLP.Comum.ViewModel.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HLP.Comum.ViewModel.ViewModels
{
    public class SenhaSupervisorViewModel : ViewModelBase<loginModel>
    {
        public ICommand autorizarCommand { get; set; }

        public SenhaSupervisorViewModel()
        {
            SenhaSupervisorCommands comm = new SenhaSupervisorCommands(objViewModel: this);
            this.currentModel = new loginModel();
            this.currentModel.idEmpresa = CompanyData.idEmpresa;
        }

        private string _error;

        public string error
        {
            get { return _error; }
            set
            {
                _error = value;
                base.NotifyPropertyChanged(propertyName: "status");
            }
        }

    }
}
