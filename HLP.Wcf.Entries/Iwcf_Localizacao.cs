using HLP.Entries.Model.Models.GestaoDeMateriais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "Iwcf_Localizacao" in both code and config file together.
    [ServiceContract]
    public interface Iwcf_Localizacao
    {

        [OperationContract]
        LocalizacaoModel GetObject(int id);

        [OperationContract]
        int SaveObject(LocalizacaoModel obj);

        [OperationContract]
        bool DeleteObject(int id);

        [OperationContract]
        LocalizacaoModel CopyObject(int id);

    }
}
