using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HLP.Entries.Model.Models.Financeiro;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IserviceDiaPagamento" in both code and config file together.
    [ServiceContract]
    public interface IserviceDiaPagamento
    {
        [OperationContract]
        HLP.Entries.Model.Models.Financeiro.Dia_pagamentoModel Save(HLP.Entries.Model.Models.Financeiro.Dia_pagamentoModel objDia_pagamento);
        [OperationContract]
        void Delete(HLP.Entries.Model.Models.Financeiro.Dia_pagamentoModel objDia_pagamento);
        [OperationContract]
        int Copy(HLP.Entries.Model.Models.Financeiro.Dia_pagamentoModel objDia_pagamento);
        [OperationContract]
        Dia_pagamentoModel GetObect(int idDiaPagamento);
    }
}
