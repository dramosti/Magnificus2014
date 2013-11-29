using HLP.Comum.Infrastructure;
using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.Fiscal
{
    public partial class Situacao_tributaria_ipiModel : modelBase
    {
        public Situacao_tributaria_ipiModel()
            : base(xTabela: "Situacao_tributaria_ipi")
        {
        }
        
        private int? _idCSTIpi;
        [ParameterOrder(Order = 1)]
        public int? idCSTIpi
        {
            get { return _idCSTIpi; }
            set
            {
                _idCSTIpi = value;
                base.NotifyPropertyChanged(propertyName: "idCSTIpi");
            }
        }

        [ParameterOrder(Order = 2)]
        public string cCSTIpi { get; set; }
        [ParameterOrder(Order = 3)]
        public string xCSTIpi { get; set; }
        [ParameterOrder(Order = 4)]
        public byte stSimplesNacional { get; set; }
    }

    public partial class Situacao_tributaria_ipiModel
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
