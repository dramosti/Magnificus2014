using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IserviceCondicao_Pagamento" in both code and config file together.
    [ServiceContract]
    public interface IserviceCondicao_Pagamento
    {
        [OperationContract]
        HLP.Entries.Model.Models.Gerais.Condicao_pagamentoModel getCondicao_pagamento(int idCondicao_pagamento);

        [OperationContract]
        int saveCondicao_pagamento(HLP.Entries.Model.Models.Gerais.Condicao_pagamentoModel objCondicao_pagamento);

        [OperationContract]
        bool deleteCondicao_pagamento(int idCondicao_pagamento);

        [OperationContract]
        int copyCondicao_pagamento(int idCondicao_Pagamento);
    }
}
