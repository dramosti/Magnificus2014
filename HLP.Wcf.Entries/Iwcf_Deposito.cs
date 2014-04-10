using HLP.Entries.Model.Models.Gerais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "Iwcf_Deposito" in both code and config file together.
    [ServiceContract]
    public interface Iwcf_Deposito
    {
        [OperationContract]
        DepositoModel GetObject(int id);

        [OperationContract]
        int SaveObject(DepositoModel obj);

        [OperationContract]
        bool DeleteObject(int id);

        [OperationContract]
        int CopyObject(int id);
    }
}
