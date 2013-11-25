using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IserviceTransportador" in both code and config file together.
    [ServiceContract]
    public interface IserviceTransportador
    {
        [OperationContract]
        HLP.Entries.Model.Models.Transportes.TransportadorModel getTransportador(int idTransportador);

        [OperationContract]
        int saveTransportador(HLP.Entries.Model.Models.Transportes.TransportadorModel objTransportador);

        [OperationContract]
        bool delTransportador(int idTransportador);

        [OperationContract]
        int copyTransportador(HLP.Entries.Model.Models.Transportes.TransportadorModel objTransportador);
    }
}
