using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Infrastructure;
using HLP.Comum.Model.Models;

namespace HLP.Entries.Model.Models.Gerais
{
    public partial class UFModel
    {
        public UFModel()
        {
        }

        private int? _idUF;
        [ParameterOrder(Order = 1)]

        public int? idUF
        {
            get { return _idUF; }
            set { _idUF = value; }
        }

        private string _xSiglaUf;

        [ParameterOrder(Order = 2)]
        public string xSiglaUf
        {
            get { return _xSiglaUf; }
            set
            {
                _xSiglaUf = value;
            }
        }

        private string _xUf;

        [ParameterOrder(Order = 3)]
        public string xUf
        {
            get { return _xUf; }
            set { _xUf = value; }
        }

        private int _cIbgeUf;

        [ParameterOrder(Order = 4)]
        public int cIbgeUf
        {
            get { return _cIbgeUf; }
            set { _cIbgeUf = value; }
        }

        private int _idRegiao;

        [ParameterOrder(Order = 5)]
        public int idRegiao
        {
            get { return _idRegiao; }
            set { _idRegiao = value; }
        }

        public bool IsValid
        {
            get
            {
                foreach (string property in ValidatedProperties)
                    if (GetValidationError(property) != null)
                        return false;
                return true;
            }
        }

        static readonly string[] ValidatedProperties = 
        { 
            "xSiglaUf", 
            "xUf", 
            "cIbgeUf",
            "idRegiao",
        };

        string GetValidationError(string columnName)
        {
            if (columnName == "xSiglaUf")
            {
                if (this._xSiglaUf.Trim() == "")
                {
                    return "campo não pode ser vazio";
                }
            }
            else if (columnName == "xUf")
            {
                if (this._xUf.Trim() == "")
                {
                    return "campo não pode ser vazio";
                }
            }
            else if (columnName == "cIbgeUf")
            {
                if (this.cIbgeUf == 0)
                {
                    return "campo não pode ser vazio";
                }
            }
            else if (columnName == "cIbgeUf")
            {
                if (this.cIbgeUf == 0)
                {
                    return "campo não pode ser vazio";
                }
            }
            else if (columnName == "idRegiao")
            {
                if (this.idRegiao == 0)
                {
                    return "campo não pode ser vazio";
                }
            }
            return null;
        }
    }

    public partial class UFModel : IDataErrorInfo
    {
        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get
            {
                return this.GetValidationError(columnName: columnName);
            }
        }

    }
}
