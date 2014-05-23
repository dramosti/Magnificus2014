using HLP.Components.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HLP.Components.ViewModel.ViewModels
{
    public class CustomTextBoxViewModel
    {
        public ICommand searchCommand { get; set; }

        CustomTextBoxCommands comm;

        public CustomTextBoxViewModel()
        {
            comm = new CustomTextBoxCommands(objViewModel: this);
        }
    }
}
