using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Infrastructure;
using HLP.Comum.Model.Models;

namespace HLP.Entries.Model.Models.Fiscal
{
    public partial class Carga_trib_media_st_icmsModel : modelBase
    {
        public Carga_trib_media_st_icmsModel() : base("Carga_trib_media_st_icms") { }
        [ParameterOrder(Order = 1)]
        public int? idCargaTribMediaStIcms { get; set; }
        [ParameterOrder(Order = 2)]
        public int idRamoAtividade { get; set; }
        [ParameterOrder(Order = 3)]
        public int idUf { get; set; }
        [ParameterOrder(Order = 4)]
        public decimal pCargaTributariaMedia { get; set; }
    }
    public partial class Carga_trib_media_st_icmsModel
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
