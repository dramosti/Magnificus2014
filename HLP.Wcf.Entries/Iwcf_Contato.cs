using HLP.Components.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "Iwcf_Contato" in both code and config file together.
    [ServiceContract]
    public interface Iwcf_Contato
    {
        [OperationContract]
        ContatoModel Save(ContatoModel objContato);

        [OperationContract]
        bool Delete(int idContato);

        [OperationContract]
        ContatoModel Copy(ContatoModel objContato);

        [OperationContract]
        ContatoModel GetObject(int idContato);

        [OperationContract]
        List<ContatoModel> GetContato_ByClienteFornec(int idContato);
    }
}
