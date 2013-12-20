using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IserviceProduto" in both code and config file together.
    [ServiceContract]
    public interface IserviceProduto
    {
        [OperationContract]
        HLP.Entries.Model.Models.Comercial.ProdutoModel getProduto(int idProduto);

        [OperationContract]
        HLP.Entries.Model.Models.Comercial.ProdutoModel saveProduto(HLP.Entries.Model.Models.Comercial.ProdutoModel objProduto);

        [OperationContract]
        bool deleteProduto(int idProduto);

        [OperationContract]
        int copyProduto(HLP.Entries.Model.Models.Comercial.ProdutoModel objProduto);

        [OperationContract]
        List<HLP.Entries.Model.Models.Comercial.ProdutoModel> getAll();

    }
}
