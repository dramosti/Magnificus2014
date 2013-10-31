using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Comum.Model.Components
{
    public class PesquisaPadraoModel
    {
        public string COLUMN_NAME { get; set; }
        public string DATA_TYPE { get; set; }
        public string HeaderText { get; set; }
        public string Operador { get; set; }
        public string Valor { get; set; }
        public string EOU { get; set; }
    }
}
