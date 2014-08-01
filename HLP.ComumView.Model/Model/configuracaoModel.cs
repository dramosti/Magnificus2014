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
        public configuracaoModel()
        {

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
