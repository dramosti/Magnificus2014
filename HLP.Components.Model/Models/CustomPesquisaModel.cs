using HLP.Base.ClassesBases;
using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Components.Model.Models
{
    public partial class CustomPesquisaModel : modelComum
    {        
        private string _xDisplay;

        public string xDisplay
        {
            get { return _xDisplay; }
            set
            {
                _xDisplay = value;
                base.NotifyPropertyChanged(propertyName: "xDisplay");
            }
        }
    }

    public partial class CustomPesquisaModel : IDataErrorInfo
    {
        #region Validação de Dados

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public virtual string this[string columnName]
        {
            get
            {
                if(columnName == "xDisplay")
                {
                    if (this.xDisplay == "")
                        return "Não foi encontrado registro na base de dados com o código informado.";
                }

                return string.Empty;
            }
        }

        #endregion

    }
}
