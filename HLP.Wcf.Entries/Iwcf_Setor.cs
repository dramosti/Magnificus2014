using HLP.Entries.Model.Models.RecursosHumanos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "Iwcf_Setor" in both code and config file together.
    [ServiceContract]
    public interface Iwcf_Setor
    {

        [OperationContract]
        SetorModel GetObject(int id);

        [OperationContract]
        int SaveObject(SetorModel obj);

        [OperationContract]
        bool DeleteObject(int id);

        [OperationContract]
        SetorModel CopyObject(int id);

    }
}
