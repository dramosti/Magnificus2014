using HLP.Base.EnumsBases;
using HLP.Base.Static;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Base.ClassesBases
{
    [DataContract]
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
            this.lErrors = new ObservableCollection<ErrorsModel>();
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

            CamposSqlNotNullModel x = lCamposSqlNotNull._lCamposSql.FirstOrDefault(i => i.xTabela.ToUpper()
                      == xTabela.ToUpper());

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

            this.lErrors = new ObservableCollection<ErrorsModel>();
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

        public int ForceValidateModel()
        {
            int countErrors = 0;

            foreach (var p in this.GetType().GetProperties())
            {
                if (p.SetMethod != null && p.GetMethod != null)
                    if (!(string.IsNullOrEmpty(value: this[columnName: p.Name])))
                        countErrors++;
            }

            return countErrors;
        }

        protected virtual List<ErrorsModel> GetErrors()
        {
            return this.lErrors != null ? this.lErrors.ToList() : new List<ErrorsModel>();
        }

        private ObservableCollection<ErrorsModel> _lErrors;

        public ObservableCollection<ErrorsModel> lErrors
        {
            get { return _lErrors; }
            set
            {
                _lErrors = value;
                this.NotifyPropertyChanged(propertyName: "lErrors");
            }
        }


        public string Error
        {
            get { return string.Empty; }
        }

        public virtual string this[string columnName]
        {
            get
            {
                PropertyInfo pi = this.GetType().GetProperty(columnName);

                Attribute a = pi.GetCustomAttribute(attributeType: typeof(SkipValidation));
                bool bSkip = false;

                if (a != null)
                {
                    if ((a as SkipValidation).skip == TypeSkipValidation.onlyDataGrid)
                        bSkip = true;
                    else if ((a as SkipValidation).skip == TypeSkipValidation.all)
                        return string.Empty;
                }

                object valor = pi.GetValue(this);
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
                    else if (columnName.ToUpper().Contains("STPESSOA"))
                    {
                        this.NotifyPropertyChanged(propertyName: "xCpfCnpj");
                        this.NotifyPropertyChanged(propertyName: "xRgIe");
                    }
                    else if (columnName.ToUpper().Contains(value: "XRGIE"))
                    {
                        PropertyInfo piStPessoa = this.GetType().GetProperty(name: "stPessoa");

                        if (piStPessoa != null)
                        {
                            PropertyInfo piRgIe = this.GetType().GetProperty(name: "xRgIe");
                            object xRgIe = null;

                            if (piRgIe != null)
                            {
                                xRgIe = piRgIe.GetValue(obj: this);
                            }


                            if (xRgIe != null)
                                if ((byte?)piStPessoa.GetValue(obj: this) == (byte)1)
                                {
                                    if (!Util.ValidaRg(xRg: xRgIe.ToString()))
                                        sMessage = "RG inválido";
                                }
                        }
                    }
                    else if (columnName.ToUpper().Contains("XCPFCNPJ"))
                    {
                        PropertyInfo piStPessoa = this.GetType().GetProperty(name: "stPessoa");

                        if (piStPessoa != null)
                        {
                            PropertyInfo piCpfCnpj = this.GetType().GetProperty(name: "xCpfCnpj");
                            object xCpfCnpj = null;

                            if (piCpfCnpj != null)
                            {
                                xCpfCnpj = piCpfCnpj.GetValue(obj: this);
                            }


                            if (xCpfCnpj != null)
                                if ((byte?)piStPessoa.GetValue(obj: this) == (byte)1)
                                {
                                    if (!Util.ValidaCpf(strCpf: xCpfCnpj.ToString()))
                                        sMessage = "Cpf inválido";
                                }
                                else
                                {
                                    if (!Util.ValidaCnpj(strCnpj: xCpfCnpj.ToString()))
                                        sMessage = "Cnpj inválido";
                                }
                        }
                    }

                ErrorsModel error = this.lErrors.FirstOrDefault(
                    i => i.xId == columnName);

                if (error != null)
                    this.lErrors.Remove(item: error);

                if (!String.IsNullOrEmpty(value: sMessage))
                {
                    this.lErrors.Add(item: new ErrorsModel
                        {
                            xId = columnName,
                            xErro = sMessage,
                            skipValidation = bSkip,
                            xTable = this.GetType().Name
                        });
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

    public class ErrorsModel : INotifyPropertyChanged
    {
        private string _nItem;

        public string nItem
        {
            get { return _nItem; }
            set
            {
                _nItem = value;
                this.NotifyPropertyChanged(propertyName: "nItem");
            }
        }


        private string _xTable;

        public string xTable
        {
            get { return _xTable; }
            set
            {
                _xTable = value;
                this.NotifyPropertyChanged(propertyName: "xTable");
            }
        }


        private string _xId;

        public string xId
        {
            get { return _xId; }
            set
            {
                _xId = value;
                this.NotifyPropertyChanged(propertyName: "xId");
            }
        }

        private string _xErro;

        public string xErro
        {
            get { return _xErro; }
            set
            {
                _xErro = value;
                this.NotifyPropertyChanged(propertyName: "xErro");
            }
        }

        private bool _skipValidation;

        public bool skipValidation
        {
            get { return _skipValidation; }
            set
            {
                _skipValidation = value;
                this.NotifyPropertyChanged(propertyName: "skipValidation");
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
}
