using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using HLP.Base.ClassesBases;
using HLP.Comum.Model.Models;
using System.Runtime.Serialization;

namespace HLP.Entries.Model.Models.Gerais
{
    public partial class CidadeModel : modelComum
    {
        public CidadeModel()
            : base(xTabela: "Cidade")
        {
        }

        private int? _idCidade;

        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idCidade
        {
            get { return _idCidade; }
            set
            {
                _idCidade = value;
                base.NotifyPropertyChanged(propertyName: "idCidade");
            }
        }

        [ParameterOrder(Order = 2)]
        public string xCidade { get; set; }

        [ParameterOrder(Order = 3)]
        public int cIbge { get; set; }

        public int _idUF;
        [ParameterOrder(Order = 4)]
        public int idUF
        {
            get { return _idUF; }
            set
            {
                _idUF = value;
                base.NotifyPropertyChanged("idUF");
            }
        }
    }

    public partial class CidadeModel : IDataErrorInfo
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
