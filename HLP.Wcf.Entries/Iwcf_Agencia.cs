using HLP.Entries.Model.Models.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "Iwcf_Agencia" in both code and config file together.
    [ServiceContract]
    public interface Iwcf_Agencia
    {
        [OperationContract]
        AgenciaModel GetObject(int id);

        [OperationContract]
        AgenciaModel SaveObject(AgenciaModel obj);

        [OperationContract]
        bool DeleteObject(int id);

        [OperationContract]
        AgenciaModel CopyObject(AgenciaModel Objeto);
    }
}
