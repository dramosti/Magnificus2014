using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HLP.ComumView.ViewModel.Messages.ViewModels
{
    public class HlpMessageAlertViewModel: INotifyPropertyChanged
    {
        public ICommand commOk { get; set; }

        public HlpMessageAlertViewModel()
        {
        }

        public HlpMessageAlertViewModel(string xAlertMessageToUser, string xAlertMessageFramework = "", string xAlertCode = "")
        {
            this.xAlertCode = xAlertCode;
            this.xAlertMessageToUser = xAlertMessageToUser;
            this.xAlertMessageFramework = xAlertMessageFramework;
        }


        private string _xAlertCode;

        public string xAlertCode
        {
            get { return _xAlertCode; }
            set
            {
                _xAlertCode = value;
                this.NotifyPropertyChanged(propertyName: "xErrorCode");
            }
        }


        private string _xAlertMessageToUser;

        public string xAlertMessageToUser
        {
            get { return _xAlertMessageToUser; }
            set
            {
                _xAlertMessageToUser = value;
                this.NotifyPropertyChanged(propertyName: "xErrorMessageToUser");
            }
        }


        private string _xAlertMessageFramework;

        public string xAlertMessageFramework
        {
            get { return _xAlertMessageFramework; }
            set
            {
                _xAlertMessageFramework = value;
                this.NotifyPropertyChanged(propertyName: "xErrorMessageFramework");
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
