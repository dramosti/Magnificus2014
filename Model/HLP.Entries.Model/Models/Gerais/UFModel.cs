using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Infrastructure;
using HLP.Comum.Model.Models;
using HLP.Comum.Model.Repository.Implementation.ClassesBases;
using Ninject;
using HLP.Comum.Model.Repository.Interfaces.ClassesBases;

namespace HLP.Entries.Model.Models.Gerais
{
    public partial class UFModel : modelBase
    {
        modelBaseRepository _modelBaseRepository;

        public UFModel()
            : base()
        {
            this._modelBaseRepository = new modelBaseRepository();
            base.lcamposSqlNotNull = this._modelBaseRepository.getCamposSqlNotNull(xTabela: "UF");
        }

        private int? _idUF;
        [ParameterOrder(Order = 1)]

        public int? idUF
        {
            get { return _idUF; }
            set
            {
                _idUF = value;
                base.NotifyPropertyChanged(propertyName: "idUF");
            }
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
                return true;
            }
        }

        //public bool IsValid
        //{
        //    get
        //    {
        //        foreach (string property in ValidatedProperties)
        //            if (GetValidationError(property) != null)
        //                return false;
        //        return true;
        //    }
        //}

        //static readonly string[] ValidatedProperties = 
        //{ 
        //    "xSiglaUf", 
        //    "xUf", 
        //    "cIbgeUf",
        //    "idRegiao",
        //};
    }

    public partial class UFModel : IDataErrorInfo
    {
        #region Validação de Dados

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get
            {
                return base.GetValidationErrorEmpty(columnName: columnName, objeto: this);
            }
        }

        #endregion
    }
}
