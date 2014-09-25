using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.ComumView.Model.Model
{
    public partial class configuracaoModel : INotifyPropertyChanged
    {

        private Dictionary<int?, configuracaoModel> _lProfiles;

        public Dictionary<int?, configuracaoModel> lProfiles
        {
            get { return _lProfiles; }
            set
            {
                _lProfiles = value;
                this.NotifyPropertyChanged(propertyName: "lProfiles");
            }
        }


        public configuracaoModel()
        {
        }

        public void LoadProfiles()
        {
            this.lProfiles = new Dictionary<int?, configuracaoModel>();

            lProfiles.Add(key: 0, value: null);

            lProfiles.Add(key: 1, value: new configuracaoModel
            {
                xName = "Teste",
                xBaseDados = @"Data Source=HLPSRV\SQLSERVER14;Initial Catalog=PROD_MAGNIFICUS;User Id=SA;Password=H029060tSql;",
                xUriWcf = "http://hlpsistemas.no-ip.org:8081/wcf/"
            });

            lProfiles.Add(key: 2, value: new configuracaoModel
            {
                xName = "Desenvolvimento",
                xBaseDados = @"Data Source=HLPSRV\SQLSERVER14;Initial Catalog=BD_MAGNIFICUS_ATUAL;User Id=SA;Password=H029060tSql;",
                xUriWcf = "http://hlpsistemas.no-ip.org:8081/wcf_dev/"
            });

            this.NotifyPropertyChanged(propertyName: "lProfiles");
        }

        private string _xName;

        public string xName
        {
            get { return _xName; }
            set
            {
                _xName = value;
                this.NotifyPropertyChanged(propertyName: "xName");
            }
        }


        private int? _selectedPredefinedProfile;

        public int? selectedPredefinedProfile
        {
            get { return _selectedPredefinedProfile; }
            set
            {
                _selectedPredefinedProfile = value;

                configuracaoModel conf = this.lProfiles.FirstOrDefault(i => i.Key == (value ?? 0)).Value;

                if (conf != null && value > 0)
                {
                    this.xBaseDados = conf.xBaseDados;
                    this.xUriWcf = conf.xUriWcf;
                }

                this.NotifyPropertyChanged(propertyName: "selectedPredefinedProfile");
            }
        }



        private string _xUriWcf;

        public string xUriWcf
        {
            get { return _xUriWcf; }
            set
            {
                _xUriWcf = value;
                this.NotifyPropertyChanged(propertyName: "xUriWcf");
            }
        }


        private string _xBaseDados;

        public string xBaseDados
        {
            get { return _xBaseDados; }
            set
            {
                _xBaseDados = value;
                this.NotifyPropertyChanged(propertyName: "xBaseDados");
            }
        }


        #region NotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

    }

    public partial class configuracaoModel : IDataErrorInfo
    {
        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get
            {
                if (columnName == "xUriWcf")
                {
                    if (string.IsNullOrEmpty(value: this.xUriWcf))
                        return "Valor não pode ser vazio";
                    else if (!this.xUriWcf.Contains(value: "http://")
                        || !this.xUriWcf.EndsWith(value: "/"))
                        return "Uri fornecida é inválida";
                }
                else if (columnName == "xBaseDados")
                {
                    if (string.IsNullOrEmpty(value: this.xBaseDados))
                        return "Valor não pode ser vazio";
                }

                return null;
            }
        }
    }


}
