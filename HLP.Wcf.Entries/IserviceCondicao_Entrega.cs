using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IserviceCondicao_Entrega" in both code and config file together.
    [ServiceContract]
    public interface IserviceCondicao_Entrega
    {
        [OperationContract]
        HLP.Entries.Model.Models.Transportes.Condicoes_entregaModel getCondicao_entrega(int idCondicao_entrega);

        [OperationContract]
        int saveCondicao_entrega(HLP.Entries.Model.Models.Transportes.Condicoes_entregaModel objCondicao_entrega);

        [OperationContract]
        bool delCondicao_entrega(int idCondicao_entrega);

        [OperationContract]
        int copyCondicao_entrega(int idCondicao_entrega);
    }
}
