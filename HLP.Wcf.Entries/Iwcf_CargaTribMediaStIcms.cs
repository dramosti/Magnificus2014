using HLP.Entries.Model.Models.Fiscal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "Iwcf_CargaTribMediaStIcms" in both code and config file together.
    [ServiceContract]
    public interface Iwcf_CargaTribMediaStIcms
    {

        [OperationContract]
        Carga_trib_media_st_icmsModel GetObject(int id);

        [OperationContract]
        int SaveObject(Carga_trib_media_st_icmsModel obj);

        [OperationContract]
        bool DeleteObject(int id);

        [OperationContract]
        Carga_trib_media_st_icmsModel CopyObject(int id);

    }
}
