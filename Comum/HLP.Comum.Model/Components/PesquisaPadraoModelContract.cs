using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Comum.Model.Components
{
    [DataContract]
    public class PesquisaPadraoModelContract
    {
        [DataMember]
        public string COLUMN_NAME { get; set; }
        [DataMember]
        public string DATA_TYPE { get; set; }
    }
}
