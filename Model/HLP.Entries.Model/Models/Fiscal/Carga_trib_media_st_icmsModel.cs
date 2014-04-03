using HLP.Base.ClassesBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.Fiscal
{
    public partial class Carga_trib_media_st_icmsModel : modelBase
    {
        public Carga_trib_media_st_icmsModel() : base("Carga_trib_media_st_icms") { }
        private int? _idCargaTribMediaStIcms;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idCargaTribMediaStIcms
        {
            get { return _idCargaTribMediaStIcms; }
            set { _idCargaTribMediaStIcms = value; base.NotifyPropertyChanged("idCargaTribMediaStIcms"); }
        }
        
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
