using HLP.Entries.Model.Models.Comercial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "Iwcf_CanalDeVenda" in both code and config file together.
    [ServiceContract]
    public interface Iwcf_CanalDeVenda
    {

        [OperationContract]
        Canal_vendaModel GetObject(int id);

        [OperationContract]
        int SaveObject(Canal_vendaModel obj);

        [OperationContract]
        bool DeleteObject(int id);

        [OperationContract]
        int CopyObject(int id);

    }
}
