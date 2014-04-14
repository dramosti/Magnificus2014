using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HLP.Entries.Model.Models.Gerais;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "Iwcf_CondicaoPagamento" in both code and config file together.
    [ServiceContract]
    public interface Iwcf_CondicaoPagamento
    {
        [OperationContract]
        Condicao_pagamentoModel GetObject(int id);

        [OperationContract]
        int SaveObject(Condicao_pagamentoModel obj);

        [OperationContract]
        bool DeleteObject(int id);

        [OperationContract]
        Condicao_pagamentoModel CopyObject(int id);
    }
}
