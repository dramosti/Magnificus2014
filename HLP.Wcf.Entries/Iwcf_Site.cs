using HLP.Components.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "Iwcf_Site" in both code and config file together.
    [ServiceContract]
    public interface Iwcf_Site
    {
        [OperationContract]
        HLP.Entries.Model.Models.Gerais.SiteModel Copy(HLP.Entries.Model.Models.Gerais.SiteModel obj);

        [OperationContract]
        bool Delete(int id);

        [OperationContract]
        HLP.Entries.Model.Models.Gerais.SiteModel Save(HLP.Entries.Model.Models.Gerais.SiteModel obj);

        [OperationContract]
        HLP.Entries.Model.Models.Gerais.SiteModel GetObject(int id);

        [OperationContract]
        modelToTreeView GetHierarquiaSite(int idSite);
    }
}
