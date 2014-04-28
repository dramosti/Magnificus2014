using HLP.Base.ClassesBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Comum.Model.Models
{
    public class ConnectionConfigModel : modelBase
    {

        private string _xServerName;

        public string xServerName
        {
            get { return _xServerName; }
            set
            {
                _xServerName = value;
                base.NotifyPropertyChanged(propertyName: "xServerName");
            }
        }


        private bool _Autentication = false;

        public bool Autentication
        {
            get { return _Autentication; }
            set
            {
                _Autentication = value;
                base.NotifyPropertyChanged(propertyName: "Autentication");
            }
        }


        private string _xLogin;

        public string xLogin
        {
            get { return _xLogin; }
            set
            {
                _xLogin = value;
                base.NotifyPropertyChanged(propertyName: "xLogin");
            }
        }


        private string _xPassword;

        public string xPassword
        {
            get { return _xPassword; }
            set
            {
                _xPassword = value;
                base.NotifyPropertyChanged(propertyName: "xPassword");
            }
        }

        
        private string _xFile;

        public string xFile
        {
            get { return _xFile; }
            set
            {
                _xFile = value;
                base.NotifyPropertyChanged(propertyName: "xFile");
            }
        }
        

        public string ConnectionString
        {
            get
            {
                if (this.Autentication == true)
                {
                    return "Data Source=" + _xServerName + ";Initial Catalog=master;Integrated Security=true;";
                }
                else
                {
                    if (!String.IsNullOrEmpty(_xLogin) && !String.IsNullOrEmpty(_xPassword))
                    {
                        return "Data Source=" + _xServerName + ";Initial Catalog=master;User Id=" + _xLogin + ";Password=" + _xPassword + ";";
                    }
                }
                return "";
            }
        }






    }
}
