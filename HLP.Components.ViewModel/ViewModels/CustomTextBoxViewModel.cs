using HLP.Base.ClassesBases;
using HLP.Components.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HLP.Components.ViewModel.ViewModels
{
    public class CustomTextBoxViewModel : ViewModelBase<object>,  INotifyPropertyChanged
    {
        public ICommand searchCommand { get; set; }

        CustomTextBoxCommands comm;

        public CustomTextBoxViewModel()
        {
            comm = new CustomTextBoxCommands(objViewModel: this);            
        }

        private Visibility _visibility;

        public Visibility visibility
        {
            get { return _visibility; }
            set
            {
                _visibility = value;
                base.NotifyPropertyChanged(propertyName: "visibility");
            }
        }
    }
}
