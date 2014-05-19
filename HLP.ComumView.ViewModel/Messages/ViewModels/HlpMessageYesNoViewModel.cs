using HLP.ComumView.ViewModel.Messages.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HLP.ComumView.ViewModel.Messages.ViewModels
{
    public class HlpMessageYesNoViewModel : INotifyPropertyChanged
    {
        public ICommand commYes { get; set; }
        public ICommand commNo { get; set; }

        public HlpMessageYesNoViewModel()
        {
            HlpMessageYesNoCommands comm = new HlpMessageYesNoCommands(
                objViewModel: this);
        }

        public HlpMessageYesNoViewModel(string xMessageToUser)
        {
            this.xMessageToUser = xMessageToUser;
            HlpMessageYesNoCommands comm = new HlpMessageYesNoCommands(
                objViewModel: this);
        }

        private string _xMessageToUser;

        public string xMessageToUser
        {
            get { return _xMessageToUser; }
            set
            {
                _xMessageToUser = value;
                this.NotifyPropertyChanged(propertyName: "xMessageToUser");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
