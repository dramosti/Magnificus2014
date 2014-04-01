using HLP.Base.ClassesBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Components.Model.Models
{
    public class modelToComboBox
    {
        [ParameterOrder(Order = 1)]
        public int id { get; set; }
        [ParameterOrder(Order = 2)]
        public string display { get; set; }
    }
}
