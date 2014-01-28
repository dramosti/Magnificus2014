using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Infrastructure;
using HLP.Comum.Model.Models;

namespace HLP.Entries.Model.Models.Crm
{
    public partial class FidelidadeModel : modelBase
    {
        public FidelidadeModel() : base("Fidelidade") { }
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idFidelidade { get; set; }
        [ParameterOrder(Order = 2)]
        public string xFidelidade { get; set; }
        [ParameterOrder(Order = 3)]
        public string xDescricao { get; set; }

    }
    public partial class FidelidadeModel
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
