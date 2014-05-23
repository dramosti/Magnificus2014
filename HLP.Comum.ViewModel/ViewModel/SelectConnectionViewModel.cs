using HLP.Base.ClassesBases;
using HLP.Comum.Model.Models;
using HLP.Comum.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HLP.Comum.ViewModel.ViewModel
{
    public class SelectConnectionViewModel : ViewModelBase<ConnectionConfigModel>
    {
        public ICommand ConcluirCommand { get; set; }
        public ICommand FecharCommand { get; set; }

        SelectConnectionCommand command;

        public SelectConnectionViewModel()
        {
            command = new SelectConnectionCommand(this);
        }

        private ObservableCollection<ConnectionConfigModel> _conexoes = new ObservableCollection<ConnectionConfigModel>();
        public ObservableCollection<ConnectionConfigModel> conexoes
        {
            get { return _conexoes; }
            set
            {
                _conexoes = value;
                base.NotifyPropertyChanged(propertyName: "conexoes");
            }
        }


        private bool? _bProssegue = null;

        public bool? bProssegue
        {
            get { return _bProssegue; }
            set
            {
                _bProssegue = value;
                base.NotifyPropertyChanged(propertyName: "bProssegue");
            }
        }



    }
}
