using HLP.Base.ClassesBases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HLP.Entries.Model.Models.Gerais
{
      
    public partial class UFModel : modelBase
    {
        public UFModel()
            : base("UF")
        {
        }

        private int? _idUF;
       [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
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
    }

    public partial class UFModel
    {
        public override string this[string columnName]
        {
            get
            {
                return base[columnName];
            }
        }
    }
}