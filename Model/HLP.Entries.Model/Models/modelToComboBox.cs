using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Infrastructure;

namespace HLP.Entries.Model.Models
{
    public class modelToComboBox
    {
        [ParameterOrder(Order = 1)]
        public int id { get; set; }
        [ParameterOrder(Order = 2)]
        public string display { get; set; }
    }
}
