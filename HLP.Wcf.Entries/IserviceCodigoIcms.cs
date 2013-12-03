using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IserviceCodigoIcms" in both code and config file together.
    [ServiceContract]
    public interface IserviceCodigoIcms
    {
        
        [OperationContract]
        HLP.Entries.Model.Models.Fiscal.Codigo_Icms_paiModel Save(HLP.Entries.Model.Models.Fiscal.Codigo_Icms_paiModel objModel);

        [OperationContract]
        HLP.Entries.Model.Models.Fiscal.Codigo_Icms_paiModel GetObjeto(int idObjeto);

        [OperationContract]
        bool Delete(HLP.Entries.Model.Models.Fiscal.Codigo_Icms_paiModel objModel);

        [OperationContract]
        HLP.Entries.Model.Models.Fiscal.Codigo_Icms_paiModel Copy(HLP.Entries.Model.Models.Fiscal.Codigo_Icms_paiModel objModel);
        
    }
}
