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
        protected List<camposBaseDadosService.campoSqlModel> lcamposSqlNotNull = new List<camposBaseDadosService.campoSqlModel>();
        camposBaseDadosService.IcamposBaseDadosServiceClient service = new camposBaseDadosService.IcamposBaseDadosServiceClient();

        public modelBase(string xTabela = "")
        {
            if (xTabela != "" && lcamposSqlNotNull.Count == 0)
                this.GetCamposSqlNotNull(xTabela: xTabela);
        }

        private async void GetCamposSqlNotNull(string xTabela)
        {
            camposBaseDadosService.campoSqlModel[] arrayCamposSqlNotNull = await service.getCamposNotNullAsync(xTabela: xTabela);
            foreach (camposBaseDadosService.campoSqlModel item in arrayCamposSqlNotNull)
            {
                lcamposSqlNotNull.Add(item: item);
            }
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
            camposBaseDadosService.campoSqlModel campo = lcamposSqlNotNull.FirstOrDefault(predicate:
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

    public class campoSqlModel
    {
        public string COLUMN_NAME { get; set; }
        public string TYPE { get; set; }
    }
}
