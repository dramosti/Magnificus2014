using HLP.Entries.Model.Comercial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "Iwcf_TipoProduto" in both code and config file together.
    [ServiceContract]
    public interface Iwcf_TipoProduto
    {
        [OperationContract]
        Tipo_produtoModel GetObject(int id);

        [OperationContract]
        int SaveObject(Tipo_produtoModel obj);

        [OperationContract]
        bool DeleteObject(int id);

        [OperationContract]
        Tipo_produtoModel CopyObject(int id);
    }
}
