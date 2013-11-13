using HLP.Entries.Model.Models.Gerais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IserviceDecisao" in both code and config file together.
    [ServiceContract]
    public interface IserviceDecisao
    {
        [OperationContract]
        DecisaoModel getDecisao(int idDecisao);

        [OperationContract]
        int saveDecisao(DecisaoModel objDecisao);

        [OperationContract]
        bool deleteDecisao(int idDecisao);

        [OperationContract]
        int copyDecisao(int idDecisao);
    }
}
