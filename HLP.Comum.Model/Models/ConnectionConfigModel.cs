using HLP.Base.ClassesBases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Comum.Model.Models
{
    public partial class ConnectionConfigModel : modelBase
    {
        public ConnectionConfigModel() : base("") 
        {
            this._xServerName = "";
        }
        private string _xServerName= "";
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

        private string _xLogin = "";
        public string xLogin
        {
            get { return _xLogin; }
            set
            {
                _xLogin = value;
                base.NotifyPropertyChanged(propertyName: "xLogin");
            }
        }

        private string _xPassword = "";
        public string xPassword
        {
            get { return _xPassword; }
            set
            {
                _xPassword = value;
                base.NotifyPropertyChanged(propertyName: "xPassword");
            }
        }

        private string _xFile = "";
        public string xFile
        {
            get { return _xFile; }
            set
            {
                _xFile = value;
                base.NotifyPropertyChanged(propertyName: "xFile");
            }
        }

        private string _xBaseDados = "";
        public string xBaseDados
        {
            get { return _xBaseDados; }
            set
            {
                _xBaseDados = value;
                base.NotifyPropertyChanged(propertyName: "xBaseDados");
            }
        }


        private string _xNameConexao = "";
        public string xNameConexao
        {
            get { return _xNameConexao; }
            set
            {
                _xNameConexao = value;
                base.NotifyPropertyChanged(propertyName: "xNameConexao");
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
        public string ConnectionStringCompleted
        {
            get
            {

                if (this.Autentication == true)
                {
                    if (this.xServerName != "" && this.xBaseDados != "")
                        return "Data Source=" + this.xServerName + ";Initial Catalog=" + this.xBaseDados + ";Integrated Security=true;";
                }
                else
                {
                    if (!String.IsNullOrEmpty(_xLogin) && !String.IsNullOrEmpty(_xPassword) && this.xServerName != "" && this.xBaseDados != "")
                    {
                        return "Data Source=" + this.xServerName + ";Initial Catalog=" + this.xBaseDados + ";User Id=" + this.xLogin + ";Password=" + this.xPassword + ";";
                    }
                }
                return "";
            }
        }
    }

    public partial class ConnectionConfigModel
    {
        public override string this[string columnName]
        {
            get
            {
                string sAviso = "Campo é obrigatório";
                if (columnName == "xLogin")
                    if (this.xLogin == "")
                        return sAviso;
                if (columnName == "xNameConexao")
                    if (this.xNameConexao == "")
                        return sAviso;
                if (columnName == "xPassword")
                    if (this.xPassword == "")
                        return sAviso;
                if (columnName == "xServerName")
                    if (this.xServerName == "")
                        return sAviso;
                if (columnName == "xBaseDados")
                    if (this.xBaseDados == "")
                        return sAviso;
                return base[columnName];
            }
        }
    }

    [Serializable]
    public class MagnificusBaseConfiguration
    {
        public ObservableCollection<ConnectionConfigModel> conexoes { get; set; }
    }

}
