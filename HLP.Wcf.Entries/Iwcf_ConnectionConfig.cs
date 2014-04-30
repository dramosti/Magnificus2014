using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "Iwcf_ConnectionConfig" in both code and config file together.
    [ServiceContract]
    public interface Iwcf_ConnectionConfig
    {
        [OperationContract]
        DataTable GetServer();

        [OperationContract]
        DataSet GetDatabases(string connectionString);

        [OperationContract]
        bool TestConnection(string connectionString);

        [OperationContract]
        HLP.Comum.Model.Models.MagnificusBaseConfiguration GetBaseConfiguration();
    }
}
