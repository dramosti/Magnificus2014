using HLP.Entries.Model.Models.Gerais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "Iwcf_Fabricante" in both code and config file together.
    [ServiceContract]
    public interface Iwcf_Fabricante
    {
        [OperationContract]
        FabricanteModel GetObject(int id);

        [OperationContract]
        int SaveObject(FabricanteModel obj);

        [OperationContract]
        bool DeleteObject(int id);

        [OperationContract]
        FabricanteModel CopyObject(int id);
    }
}
