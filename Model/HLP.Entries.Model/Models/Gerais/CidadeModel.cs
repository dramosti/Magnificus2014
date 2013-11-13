using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Infrastructure;
using System.ComponentModel;
using HLP.Comum.Model.Models;

namespace HLP.Entries.Model.Models.Gerais
{
    public partial class CidadeModel : modelBase
    {
        public CidadeModel()
        {
        }

        public CidadeModel(campoSqlModel[] aCamposSql)
            : base()
        {
            base.lcamposSqlNotNull = aCamposSql.ToList();
        }

        private int? _idCidade;

        [ParameterOrder(Order = 1)]
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
            set { _idUF = value; base.NotifyPropertyChanged("idUF"); }
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
