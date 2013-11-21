using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Infrastructure;

namespace HLP.Entries.Model.Models.Gerais
{
    public class Tipo_servicoModel
    {
        [ParameterOrder(Order = 1)]
        public int? idTipoServico { get; set; }
        [ParameterOrder(Order = 2)]
        public int cTipoServico { get; set; }
        [ParameterOrder(Order = 3)]
        public string xTipoServico { get; set; }
    }
}
