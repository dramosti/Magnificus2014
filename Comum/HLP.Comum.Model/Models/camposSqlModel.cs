using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Comum.Model.Models
{
    [DataContract]
    public class campoSqlModel
    {
        [DataMember]
        public string COLUMN_NAME { get; set; }
        [DataMember]
        public string TYPE { get; set; }
    }
}
