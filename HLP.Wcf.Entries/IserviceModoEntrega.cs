using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IserviceModoEntrega" in both code and config file together.
    [ServiceContract]
    public interface IserviceModoEntrega
    {
        [OperationContract]
        HLP.Entries.Model.Models.Transportes.Modos_entregaModel GetModo(int idModosEntrega);
        [OperationContract]
        HLP.Entries.Model.Models.Transportes.Modos_entregaModel Save(HLP.Entries.Model.Models.Transportes.Modos_entregaModel modo);
        [OperationContract]
        bool Delete(int idModosEntrega);
        [OperationContract]
        HLP.Entries.Model.Models.Transportes.Modos_entregaModel Copy(int idModosEntrega);
    }
}
