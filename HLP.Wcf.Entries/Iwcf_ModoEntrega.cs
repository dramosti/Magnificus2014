using HLP.Entries.Model.Models.Transportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "Iwcf_ModoEntrega" in both code and config file together.
    [ServiceContract]
    public interface Iwcf_ModoEntrega
    {
        [OperationContract]
        Modos_entregaModel GetObject(int id);

        [OperationContract]
        int SaveObject(Modos_entregaModel obj);

        [OperationContract]
        bool DeleteObject(int id);

        [OperationContract]
        Modos_entregaModel CopyObject(int id);
    }
}
