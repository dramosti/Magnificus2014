using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HLP.Entries.Model.Comercial;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IserviceTipo_produto" in both code and config file together.
    [ServiceContract]
    public interface IserviceTipoProduto
    {
        [OperationContract]
        HLP.Entries.Model.Comercial.Tipo_produtoModel GetTipo(int idTipoProduto);
        [OperationContract]
        int Save(HLP.Entries.Model.Comercial.Tipo_produtoModel tipo);
        [OperationContract]
        bool Delete(int idTipoProduto);
        [OperationContract]
        int Copy(int idTipoProduto);
    }
}
