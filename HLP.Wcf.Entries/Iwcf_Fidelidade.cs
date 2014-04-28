using HLP.Entries.Model.Models.Crm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "Iwcf_Fidelidade" in both code and config file together.
    [ServiceContract]
    public interface Iwcf_Fidelidade
    {
        [OperationContract]
        FidelidadeModel GetObject(int id);

        [OperationContract]
        int SaveObject(FidelidadeModel obj);

        [OperationContract]
        bool DeleteObject(int id);

        [OperationContract]
        FidelidadeModel CopyObject(int id);
    }
}
