using HLP.Comum.Infrastructure;
using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.RecursosHumanos
{
    public partial class DepartamentoModel : modelBase
    {
        public DepartamentoModel()
        {
        }

        public DepartamentoModel(campoSqlModel[] lCamposSql)
            : base()
        {
            base.lcamposSqlNotNull = lCamposSql.ToList();
        }

        private int? _idDepartamento;
        [ParameterOrder(Order = 1)]
        public int? idDepartamento
        {
            get { return _idDepartamento; }
            set
            {
                _idDepartamento = value;
                base.NotifyPropertyChanged(propertyName: "idDepartamento");
            }
        }
        [ParameterOrder(Order = 2)]
        public string xDepartamento { get; set; }
        [ParameterOrder(Order = 3)]
        public string xDescricao { get; set; }
        [ParameterOrder(Order = 4)]
        public int? idSetor { get; set; }
        [ParameterOrder(Order = 5)]
        public string xEmail { get; set; }
    }

    public partial class DepartamentoModel
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
