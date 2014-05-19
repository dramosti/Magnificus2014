using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.ComumView.ViewModel.Messages.ViewModels
{
    public class HlpMessageErrorViewModel : INotifyPropertyChanged
    {
        public HlpMessageErrorViewModel()
        {
        }

        public HlpMessageErrorViewModel(string xErrorCode, string xErrorMessageToUser, string xErrorMessageFramework)
        {
            this.xErrorCode = xErrorCode;
            this.xErrorMessageToUser = xErrorMessageToUser;
            this.xErrorMessageFramework = xErrorMessageFramework;            
        }

        private string _xErrorCode;

        public string xErrorCode
        {
            get { return _xErrorCode; }
            set
            {
                _xErrorCode = value;
                this.NotifyPropertyChanged(propertyName: "xErrorCode");
            }
        }


        private string _xErrorMessageToUser;

        public string xErrorMessageToUser
        {
            get { return _xErrorMessageToUser; }
            set
            {
                _xErrorMessageToUser = value;
                this.NotifyPropertyChanged(propertyName: "xErrorMessageToUser");
            }
        }


        private string _xErrorMessageFramework;

        public string xErrorMessageFramework
        {
            get { return _xErrorMessageFramework; }
            set
            {
                _xErrorMessageFramework = value;
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
