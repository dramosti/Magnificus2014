using HLP.Entries.Model.Models.Comercial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "Iwcf_Juros" in both code and config file together.
    [ServiceContract]
    public interface Iwcf_Juros
    {
        [OperationContract]
        JurosModel GetObject(int id);

        [OperationContract]
        int SaveObject(JurosModel obj);

        [OperationContract]
        bool DeleteObject(int id);

        [OperationContract]
        JurosModel CopyObject(int id);
        
    }
}
