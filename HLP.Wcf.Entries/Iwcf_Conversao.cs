using HLP.Base.ClassesBases;
using HLP.Entries.Model.Models.Comercial;
using HLP.Entries.Model.Models.Gerais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "Iwcf_Conversao" in both code and config file together.
    [ServiceContract]
    public interface Iwcf_Conversao
    {
        [OperationContract]
        ProdutoModel GetObject(int id);

        [OperationContract]
        ObservableCollectionBaseCadastros<ConversaoModel> SaveObject(ProdutoModel obj);

        [OperationContract]
        bool DeleteObject(int id);
    }
}
