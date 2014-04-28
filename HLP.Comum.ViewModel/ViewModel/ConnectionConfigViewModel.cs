using HLP.Base.ClassesBases;
using HLP.Comum.Model.Models;
using HLP.Comum.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HLP.Comum.ViewModel.ViewModel
{
    public class ConnectionConfigViewModel : ViewModelBase<ConnectionConfigModel>
    {
        ConnectionConfigCommand command;
        public ICommand saveCommand { get; set; }

        public ConnectionConfigViewModel()
        {            
            command = new ConnectionConfigCommand(this);

        }
    }
}
