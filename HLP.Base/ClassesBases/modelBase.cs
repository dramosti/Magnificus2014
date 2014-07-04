using HLP.Base.EnumsBases;
using HLP.Base.Static;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Base.ClassesBases
{
    public class modelBase : INotifyPropertyChanged, IDataErrorInfo
    {
        public List<PesquisaPadraoModelContract> lcamposSqlNotNull;
        public statusModel status { get; set; }
        public readonly string[] camposSeremIgnorados = { "Item", "Error" }; //Campos que não devem ser verificados no reflection de iniciaobjeto()        

        private OperationModel operationModel;

        public OperationModel GetOperationModel()
        {
            return this.operationModel;
        }

        public void SetOperationModel(OperationModel _value)
        {
            this.operationModel = _value;
        }

        public modelBase()
        {
            this.operationModel = OperationModel.searching;
        }

        public void IniciaObjeto()
        {
            try
            {
                object o;
                foreach (PropertyInfo p in this.GetType().GetProperties())
                {
                    if (camposSeremIgnorados.ToList().Count(i => i.ToString() == p.Name) == 0)
                    {
                        o = p.GetValue(obj: this);
                        if (o != null)
                            if (p.GetValue(obj: this).GetType() == typeof(DateTime))
                                p.SetValue(obj: this, value: (DateTime.Now));
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public modelBase(string xTabela)
        {
            this.operationModel = OperationModel.searching;

            CamposSqlNotNullModel x = lCamposSqlNotNull._lCamposSql.FirstOrDefault(i => i.xTabela
                      == xTabela);

            if (x == null)
                return;

            lcamposSqlNotNull = x.lCamposSqlModel;
            PropertyInfo p = this.GetType().GetProperty("idEmpresa");

            if (p != null && !xTabela.Contains("Empresa"))
            {
                if (CompanyData.idEmpresa != 0)
                    p.SetValue(this, CompanyData.idEmpresa);
            }

            this.IniciaObjeto();
        }

        #region NotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged(string propertyName)
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
            get { return string.Empty; }
        }

        public virtual string this[string columnName]
        {
            get
            {
                object valor = this.GetType().GetProperty(columnName).GetValue(this);
                string sMessage = string.Empty;
                sMessage = this.GetValidationError(columnName: columnName, objeto: this);

                if (sMessage == null)
                    if (columnName.ToUpper().Contains("XEMAIL"))
                    {
                        if (valor != null)
                            if (valor.ToString() != "")
                                if (!(valor.ToString()).IsValidEmailAddress())
                                    sMessage = "Email inválido.";
                    }
                    else if (columnName.ToUpper().Contains("HTTP"))
                    {
                        if (valor != null)
                            if (valor.ToString().Count(i => i == '.') < 1)
                                sMessage = "Site inválido";
                    }


                return sMessage;
            }
        }

        protected string GetValidationError<T>(string columnName, T objeto) where T : class
        {
            object valor = objeto.GetType().GetProperty(columnName).GetValue(objeto);
            if (lcamposSqlNotNull != null)
            {
                PesquisaPadraoModelContract campo = lcamposSqlNotNull.FirstOrDefault(predicate:
                    i => i.COLUMN_NAME == columnName);
                if (campo != null)
                {
                    if (campo.DATA_TYPE == "F")
                    {
                        if (valor != null)
                            if (valor.ToString() == "0")
                                return "Campos de pesquisa não podem conter valor igual a 0";

                    }
                    if (campo.IS_NULLABLE == "NO" && campo.DATA_TYPE == "F ")
                    {
                        try
                        {
                            if (valor == null)
                                return "Necessário que campo possua valor!";
                            else if (valor.ToString() == "0")
                                return "Campos de pesquisa não podem conter valor igual a 0";
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }
                    else if (campo.IS_NULLABLE == "NO" && (campo.DATA_TYPE == null || campo.DATA_TYPE == "UQ")
                        && (valor == null))
                    {
                        return "Necessário que campo possua valor!";
                    }
                    else if (campo.IS_NULLABLE == "NO" && (campo.DATA_TYPE == null || campo.DATA_TYPE == "UQ")
                    && (valor.ToString() == ""))
                    {
                        return "Necessário que campo possua valor!";
                    }
                    else if (campo.IS_NULLABLE == "NO" && (objeto.GetType().GetProperty(columnName).GetType()
                        == typeof(DateTime) && ((DateTime)valor) < SqlDateTime.MinValue))
                    {
                        return "Necessário uma data maior que " + SqlDateTime.MinValue.ToString();
                    }

                    if (valor != null)
                    {
                        if (valor.GetType() == typeof(string) && valor.ToString().Count() > campo.CHARACTER_MAXIMUM_LENGTH && campo.CHARACTER_MAXIMUM_LENGTH > 0)
                            return "Valor deve possuir menos que " + campo.CHARACTER_MAXIMUM_LENGTH.ToString() +
                                " caracteres!";
                    }
                }
            }

            if (valor == null)
            {
                return null;
            }
            if (valor.GetType()
                == typeof(DateTime) && ((DateTime)valor) != DateTime.MinValue && ((DateTime)valor) < ((DateTime)SqlDateTime.MinValue))
            {
                return "Necessário uma data maior que " + SqlDateTime.MinValue.ToString();
            }

            return null;
        }

        #endregion
    }

    public static class lCamposSqlNotNull
    {
        public static List<CamposSqlNotNullModel> _lCamposSql = new List<CamposSqlNotNullModel>();
        public static void AddCampoSql(CamposSqlNotNullModel objCamposSqlNotNull)
        {
            _lCamposSql.Add(item: objCamposSqlNotNull);
        }
    }

    public class CamposSqlNotNullModel
    {
        public string xTabela { get; set; }
        public List<PesquisaPadraoModelContract> lCamposSqlModel { get; set; }
    }

    public class PesquisaPadraoModelContract
    {
        public string COLUMN_NAME { get; set; }
        public string DATA_TYPE { get; set; }
        public string IS_NULLABLE { get; set; }
        public int CHARACTER_MAXIMUM_LENGTH { get; set; }
    }
}
