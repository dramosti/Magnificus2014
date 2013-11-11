using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Resources.RecursosBases;

namespace HLP.Comum.Model.Models
{
    public class modelBase : INotifyPropertyChanged, IDataErrorInfo
    {
        protected List<campoSqlModel> lcamposSqlNotNull;
        public statusModel status { get; set; }

        public modelBase()
        {
        }

        #region NotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                if (this.status == statusModel.nenhum)
                    this.status = statusModel.alterado;
            }
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
                if (campo.TYPE == "F " && valor == "0")
                    return "Necessário que campo possua valor!";
                else if ((campo.TYPE == null || campo.TYPE == "UQ")
                    && valor == "")
                {
                    return "Necessário que campo possua valor!";
                }
            }
            return null;
        }
    }
}
