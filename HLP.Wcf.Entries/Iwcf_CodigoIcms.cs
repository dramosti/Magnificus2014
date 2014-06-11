using HLP.Entries.Model.Models.Fiscal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "Iwcf_CodigoIcms" in both code and config file together.
    [ServiceContract]
    public interface Iwcf_CodigoIcms
    {
        [OperationContract]
        Codigo_Icms_paiModel GetObject(int id);

        [OperationContract]
        Codigo_Icms_paiModel SaveObject(Codigo_Icms_paiModel obj);

        [OperationContract]
        bool DeleteObject(int id);

        [OperationContract]
        Codigo_Icms_paiModel CopyObject(Codigo_Icms_paiModel obj);

        [OperationContract]
        Codigo_IcmsModel GetObjectByUf(int id, int idUf);
    }
}
