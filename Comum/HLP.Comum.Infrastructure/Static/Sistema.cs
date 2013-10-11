using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HLP.Comum.Infrastructure.Static
{
    public class Sistema
    {
        public static ContatoStatic contatoStatico = new ContatoStatic();
        public struct ContatoStatic
        {
            public  string nmTable { get; set; }
            public  string fkTableReferencia { get; set; }
            public  int idFkReferencia { get; set; }
            public int  idFkContato { get; set; }
        }
    }
}
