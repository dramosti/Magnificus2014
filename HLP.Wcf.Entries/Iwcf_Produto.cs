using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "Iwcf_Produto" in both code and config file together.
    [ServiceContract]
    public interface Iwcf_Produto
    {
        [OperationContract]
        HLP.Entries.Model.Models.Comercial.ProdutoModel GetObjeto(int idProduto);

        [OperationContract]
        HLP.Entries.Model.Models.Comercial.ProdutoModel Save(HLP.Entries.Model.Models.Comercial.ProdutoModel objProduto);

        [OperationContract]
        HLP.Entries.Model.Models.Comercial.ProdutoModel Copy(HLP.Entries.Model.Models.Comercial.ProdutoModel objProduto);

        [OperationContract]
        bool Delete(int idProduto);

        [OperationContract]
        List<HLP.Entries.Model.Models.Comercial.ProdutoModel> getAll();

        [OperationContract]
        bool PrecoCustoManual(int idProduto);

        [OperationContract]
        decimal GetValorCompraProduto(int idProduto);
    }
}
