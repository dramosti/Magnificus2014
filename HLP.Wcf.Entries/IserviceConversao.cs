using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IserviceConversao" in both code and config file together.
    [ServiceContract]
    public interface IserviceConversao
    {
        [OperationContract]
        HLP.Entries.Model.Models.Comercial.ProdutoModel getlConversao(int idProduto);

        [OperationContract]
        void savelConversao(ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Gerais.ConversaoModel> lConversao);

        [OperationContract]
        bool dellConversao(int idProduto);
    }
}
