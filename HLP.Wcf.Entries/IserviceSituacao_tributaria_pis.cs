using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IserviceSituacao_tributaria_pis" in both code and config file together.
    [ServiceContract]
    public interface IserviceSituacao_tributaria_pis
    {
        [OperationContract]
        int Save(HLP.Entries.Model.Models.Fiscal.Situacao_tributaria_pisModel objModel);

        [OperationContract]
        HLP.Entries.Model.Models.Fiscal.Situacao_tributaria_pisModel GetObjeto(int idObjeto);

        [OperationContract]
        bool Delete(HLP.Entries.Model.Models.Fiscal.Situacao_tributaria_pisModel objModel);

        [OperationContract]
        int Copy(HLP.Entries.Model.Models.Fiscal.Situacao_tributaria_pisModel objModel);
        
    }
}
