using HLP.Entries.Model.Models.Transportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "Iwcf_CondicaoEntrega" in both code and config file together.
    [ServiceContract]
    public interface Iwcf_CondicaoEntrega
    {
        [OperationContract]
        Condicoes_entregaModel GetObject(int id);

        [OperationContract]
        int SaveObject(Condicoes_entregaModel obj);

        [OperationContract]
        bool DeleteObject(int id);

        [OperationContract]
        Condicoes_entregaModel CopyObject(int id);
    }
}
