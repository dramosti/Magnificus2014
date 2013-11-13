using HLP.Entries.Model.Models.Gerais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IserviceUf
    {

        [OperationContract]
        UFModel getUf(int idUf);

        [OperationContract]
        int saveUf(UFModel objModel);

        [OperationContract]
        bool deleteUf(int idUf);

        [OperationContract]
        int copyUf(int idUf);
    }
}
