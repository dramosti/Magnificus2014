using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IservicePlanoPagamento" in both code and config file together.
    [ServiceContract]
    public interface IservicePlanoPagamento
    {
        [OperationContract]
        HLP.Entries.Model.Models.Gerais.Plano_pagamentoModel Save(HLP.Entries.Model.Models.Gerais.Plano_pagamentoModel objPlano_pagamento);
        [OperationContract]
        bool Delete(HLP.Entries.Model.Models.Gerais.Plano_pagamentoModel objPlano_pagamento);
        [OperationContract]
        HLP.Entries.Model.Models.Gerais.Plano_pagamentoModel Copy(HLP.Entries.Model.Models.Gerais.Plano_pagamentoModel objPlano_pagamento);
        [OperationContract]
        HLP.Entries.Model.Models.Gerais.Plano_pagamentoModel GetObject(int idPlanoPagamento);
    }
}
