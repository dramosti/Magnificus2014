using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IserviceCfop" in both code and config file together.
    [ServiceContract]
    public interface IserviceCfop
    {
        
        [OperationContract]
        int Save(HLP.Entries.Model.Models.Fiscal.CfopModel objModel);

        [OperationContract]
        HLP.Entries.Model.Models.Fiscal.CfopModel GetObjeto(int idObjeto);

        [OperationContract]
        bool Delete(HLP.Entries.Model.Models.Fiscal.CfopModel objModel);

        [OperationContract]
        int Copy(HLP.Entries.Model.Models.Fiscal.CfopModel objModel);
        
    }
}
