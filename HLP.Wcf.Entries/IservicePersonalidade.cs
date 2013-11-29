using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IservicePersonalidade" in both code and config file together.
    [ServiceContract]
    public interface IservicePersonalidade
    {
        
        [OperationContract]
        int Save(HLP.Entries.Model.Models.Crm.PersonalidadeModel Objeto);

        [OperationContract]
        HLP.Entries.Model.Models.Crm.PersonalidadeModel GetObjeto(int idObjeto);

        [OperationContract]
        bool Delete(HLP.Entries.Model.Models.Crm.PersonalidadeModel Objeto);

        [OperationContract]
        int Copy(HLP.Entries.Model.Models.Crm.PersonalidadeModel Objeto);
        
        
        
    }
}
