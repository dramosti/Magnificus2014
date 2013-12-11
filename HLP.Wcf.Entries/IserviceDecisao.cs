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
        HLP.Entries.Model.Models.Gerais.DecisaoModel getDecisao(int idDecisao);

        [OperationContract]
        HLP.Entries.Model.Models.Gerais.DecisaoModel saveDecisao(HLP.Entries.Model.Models.Gerais.DecisaoModel objDecisao);

        [OperationContract]
        bool deleteDecisao(int idDecisao);

        [OperationContract]
        int copyDecisao(int idDecisao);
    }
}
