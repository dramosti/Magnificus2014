using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Entries.Model.Models.Fiscal;

namespace HLP.Entries.Model.Repository.Interfaces.Fiscal
{
    public interface ICarga_trib_media_st_icmsRepository
    {
        void Save(Carga_trib_media_st_icmsModel objCarga_trib_media_st_icms);
        void Delete(int idCargaTribMediaStIcms);
        int Copy(int idCargaTribMediaStIcms);
        Carga_trib_media_st_icmsModel GetCarga_trib_media_st_icms(int idCargaTribMediaStIcms);
        List<Carga_trib_media_st_icmsModel> GetAllCarga_trib_media_st_icms();
        Carga_trib_media_st_icmsModel GetCarga_trib_media_st_icmsByUf(int idUf);
    }
}
