using HLP.Base.ClassesBases;
using HLP.Base.Static;
using HLP.Comum.ViewModel.ViewModel;
using HLP.ComumView.Model.Model;
using HLP.ComumView.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HLP.ComumView.ViewModel.ViewModel
{
    public class SenhaSupervisorViewModel : viewModelComum<loginModel>
    {
        public ICommand autorizarCommand { get; set; }
        public ICommand closeCommand { get; set; }

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
                base.NotifyPropertyChanged(propertyName: "error");
            }
        }

    }
}
