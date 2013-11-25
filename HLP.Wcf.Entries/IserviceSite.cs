using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IserviceSite" in both code and config file together.
    [ServiceContract]
    public interface IserviceSite
    {
        [OperationContract]
        HLP.Entries.Model.Models.Gerais.SiteModel getSite(int idSite);

        [OperationContract]
        int saveSite(HLP.Entries.Model.Models.Gerais.SiteModel objSite);

        [OperationContract]
        bool deleteSite(int idSite);

        [OperationContract]
        int copySite(HLP.Entries.Model.Models.Gerais.SiteModel objSite);

    }
}
