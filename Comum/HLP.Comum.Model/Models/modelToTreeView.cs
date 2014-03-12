using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Comum.Model.Models
{
    public class modelToTreeView
    {
        public int id { get; set; }
        public string xDisplay { get; set; }
        public List<modelToTreeView> lFilhos { get; set; }
    }
}
