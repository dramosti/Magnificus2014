using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Comum.Model.Models
{
    public class modelBase : INotifyPropertyChanged, IDataErrorInfo
    {
        protected List<campoSqlModel> lcamposSqlNotNull;

        public modelBase()
        {
            this.lcamposSqlNotNull = new List<campoSqlModel>();
        }

        #region NotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Validação de Dados

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public virtual string this[string columnName]
        {
            get
            {
                return this.GetValidationErrorEmpty(columnName: columnName, objeto: this);
            }
        }

        #endregion


        protected string GetValidationErrorEmpty<T>(string columnName, T objeto) where T : class
        {
            campoSqlModel campo = lcamposSqlNotNull.FirstOrDefault(predicate:
                i => i.COLUMN_NAME == columnName);
            if (campo != null)
            {
                string valor = objeto.GetType().GetProperty(columnName).GetValue(objeto).ToString();
                if (campo.TYPECONSTRAINT == "F " && valor == "0")
                    return "Necessário que campo possua valor!";
                else if ((campo.TYPECONSTRAINT == null || campo.TYPECONSTRAINT == "UQ") 
                    && valor == "")
                {
                    return "Necessário que campo possua valor!";
                }
            }

            return null;
        }
    }

    public class campoSqlModel
    {
        public string COLUMN_NAME { get; set; }
        public byte IS_NULLABLE { get; set; }
        public string TYPECONSTRAINT { get; set; }
    }
}
