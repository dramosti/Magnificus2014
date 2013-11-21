using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Infrastructure;
using HLP.Comum.Model.Models;

namespace HLP.Entries.Model.Models.Gerais
{
    public partial class Tipo_servicoModel : modelBase
    {
        public Tipo_servicoModel() : base("Tipo_servico") { }


        [ParameterOrder(Order = 1)]
        public int? idTipoServico { get; set; }
        [ParameterOrder(Order = 2)]
        public int cTipoServico { get; set; }
        [ParameterOrder(Order = 3)]
        public string xTipoServico { get; set; }
    }

    public partial class Tipo_servicoModel
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
