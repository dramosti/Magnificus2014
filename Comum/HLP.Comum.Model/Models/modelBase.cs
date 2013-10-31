using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Comum.Model.Models
{
    public class modelBase : INotifyPropertyChanged
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

        protected string GetValidationErrorEmpty<T>(string columnName, T objeto) where T : class
        {
            if (lcamposSqlNotNull.Count(predicate:
                i => i.COLUMN_NAME == columnName) > 0)
                if (objeto.GetType().GetProperty(columnName).GetValue(objeto).ToString() == "")
                    return "Necessário que campo possua valor!";

            return null;
        }
    }

    public class campoSqlModel
    {
        public string COLUMN_NAME { get; set; }
        public byte IS_NULLABLE { get; set; }
    }
}
