using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Comum.Model.Models
{
    public class FindAllModel : modelBase
    {
        private string _output;

        public string output
        {
            get { return _output; }
            set { _output = value; }
        }


        private byte[] _icon;

        public byte[] icon
        {
            get { return _icon; }
            set { _icon = value; }
        }
        
        
    }
}
