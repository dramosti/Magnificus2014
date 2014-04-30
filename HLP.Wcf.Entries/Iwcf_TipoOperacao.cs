using HLP.Entries.Model.Models.Fiscal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "Iwcf_TipoOperacao" in both code and config file together.
    [ServiceContract]
    public interface Iwcf_TipoOperacao
    {
        [OperationContract]
        Tipo_operacaoModel GetObject(int id);

        [OperationContract]
        Tipo_operacaoModel SaveObject(Tipo_operacaoModel obj);

        [OperationContract]
        bool DeleteObject(Tipo_operacaoModel obj);

        [OperationContract]
        Tipo_operacaoModel CopyObject(Tipo_operacaoModel obj);
    }
}
