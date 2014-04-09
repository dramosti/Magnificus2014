using HLP.Entries.Model.Models.Gerais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "Iwcf_PlanoPagamento" in both code and config file together.
    [ServiceContract]
    public interface Iwcf_PlanoPagamento
    {

        [OperationContract]
        Plano_pagamentoModel GetObject(int id);

        [OperationContract]
        Plano_pagamentoModel SaveObject(Plano_pagamentoModel obj);

        [OperationContract]
        bool DeleteObject(Plano_pagamentoModel obj);

        [OperationContract]
        Plano_pagamentoModel CopyObject(Plano_pagamentoModel obj);
        
    }
}
