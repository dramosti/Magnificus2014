using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IserviceDeposito" in both code and config file together.
    [ServiceContract]
    public interface IserviceDeposito
    {
        [OperationContract]
        HLP.Entries.Model.Models.Gerais.DepositoModel getDeposito(int idDeposito);

        [OperationContract]
        int saveDeposito(HLP.Entries.Model.Models.Gerais.DepositoModel objDeposito);

        [OperationContract]
        bool deleteDeposito(int idDeposito);

        [OperationContract]
        int copyDeposito(int idDeposito);
    }
}
