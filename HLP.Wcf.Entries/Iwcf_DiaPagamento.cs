using HLP.Entries.Model.Models.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "Iwcf_DiaPagamento" in both code and config file together.
    [ServiceContract]
    public interface Iwcf_DiaPagamento
    {
        [OperationContract]
        Dia_pagamentoModel GetObject(int id);

        [OperationContract]
        Dia_pagamentoModel SaveObject(Dia_pagamentoModel obj);

        [OperationContract]
        bool DeleteObject(int id);

        [OperationContract]
        Dia_pagamentoModel CopyObject(Dia_pagamentoModel obj);
    }
}
