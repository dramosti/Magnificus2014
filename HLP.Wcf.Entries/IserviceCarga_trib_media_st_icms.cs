using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IserviceCarga_trib_media_st_icms" in both code and config file together.
    [ServiceContract]
    public interface IserviceCarga_trib_media_st_icms
    {
        
        [OperationContract]
        int Save(HLP.Entries.Model.Models.Fiscal.Carga_trib_media_st_icmsModel objModel);

        [OperationContract]
        HLP.Entries.Model.Models.Fiscal.Carga_trib_media_st_icmsModel GetObjeto(int idObjeto);

        [OperationContract]
        bool Delete(HLP.Entries.Model.Models.Fiscal.Carga_trib_media_st_icmsModel objModel);

        [OperationContract]
        int Copy(HLP.Entries.Model.Models.Fiscal.Carga_trib_media_st_icmsModel objModel);

        [OperationContract]
        List<HLP.Entries.Model.Models.Fiscal.Carga_trib_media_st_icmsModel> GetAllCarga_trib_media_st_icms();

        [OperationContract]
        HLP.Entries.Model.Models.Fiscal.Carga_trib_media_st_icmsModel GetCarga_trib_media_st_icmsByUf(int idUf);
        
    }
}
