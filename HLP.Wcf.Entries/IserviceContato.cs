using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IserviceContato" in both code and config file together.
    [ServiceContract]
    public interface IserviceContato
    {
        [OperationContract]
        HLP.Entries.Model.Models.Gerais.ContatoModel Save(HLP.Entries.Model.Models.Gerais.ContatoModel objContato);
        [OperationContract]
        bool  Delete(int idContato);
        [OperationContract]
        HLP.Entries.Model.Models.Gerais.ContatoModel Copy(HLP.Entries.Model.Models.Gerais.ContatoModel objContato);
        [OperationContract]
        HLP.Entries.Model.Models.Gerais.ContatoModel GetObject(int idContato);
        [OperationContract]
        List<HLP.Entries.Model.Models.Gerais.ContatoModel> GetContato_ByClienteFornec(int idContato);
    }
}
