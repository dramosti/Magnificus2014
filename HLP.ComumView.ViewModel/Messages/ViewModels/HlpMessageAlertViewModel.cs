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
    public class HlpMessageAlertViewModel : INotifyPropertyChanged
    {
        public ICommand commOk { get; set; }

        HlpMessageAlertCommands comm;

        public HlpMessageAlertViewModel()
        {
            this.comm = new HlpMessageAlertCommands(objViewModel: this);
        }

        public HlpMessageAlertViewModel(string xAlertMessageToUser, string xAlertMessageFramework = "", string xAlertCode = "")
        {
            this.xAlertCode = xAlertCode;
            this.xAlertMessageToUser = xAlertMessageToUser;
            this.xAlertMessageFramework = xAlertMessageFramework;
            this.comm = new HlpMessageAlertCommands(objViewModel: this);
        }


        private string _xAlertCode;

        public string xAlertCode
        {
            get { return _xAlertCode; }
            set
            {
                _xAlertCode = value;
                this.NotifyPropertyChanged(propertyName: "xAlertCode");
            }
        }


        private string _xAlertMessageToUser;

        public string xAlertMessageToUser
        {
            get { return _xAlertMessageToUser; }
            set
            {
                _xAlertMessageToUser = value;
                this.NotifyPropertyChanged(propertyName: "xAlertMessageToUser");
            }
        }


        private string _xAlertMessageFramework;

        public string xAlertMessageFramework
        {
            get { return _xAlertMessageFramework; }
            set
            {
                _xAlertMessageFramework = value;
                this.NotifyPropertyChanged(propertyName: "xAlertMessageFramework");
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
