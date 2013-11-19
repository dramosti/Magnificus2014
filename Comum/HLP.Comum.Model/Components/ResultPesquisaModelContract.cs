using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Comum.Model.Components
{
    [DataContract]
    public class ResultPesquisaModelContract
    {
        [DataMember]
        public DataTable ResultTable
        {
            get;
            set;
        }
    }
}
