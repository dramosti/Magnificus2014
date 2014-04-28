using HLP.Comum.ViewModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Comum.ViewModel.Commands
{
    public class ConnectionConfigCommand
    {
        public ConnectionConfigViewModel viewModel { get; set; }
        public ConnectionConfigCommand(ConnectionConfigViewModel viewModel) 
        {
            this.viewModel = viewModel;
            
        }
    }
}
