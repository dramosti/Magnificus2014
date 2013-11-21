using HLP.Comum.Infrastructure;
using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.RecursosHumanos
{
    [DataContract]
    public partial class SetorModel : modelBase
    {
        //[DataMember(Name = "Attributes")]
        [ParameterOrder(Order = 1)]
        public int idEmpresa { get; set; }
        //[DataMember(Name = "Attributes")]
        [ParameterOrder(Order = 2)]
        public int? idSetor { get; set; }
        //[DataMember(Name = "Attributes")]
        [ParameterOrder(Order = 3)]
        public string xSetor { get; set; }
        //[DataMember(Name = "Attributes")]
        [ParameterOrder(Order = 4)]
        public string xDescricao { get; set; }
        //[DataMember(Name = "Attributes")]
        [ParameterOrder(Order = 5)]
        public string xEmail { get; set; }
    }

    public partial class SetorModel
    {
        public override string this[string columnName]
        {
            get
            {
                return base[columnName];
            }
        }
    }
}
