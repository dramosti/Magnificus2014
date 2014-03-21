using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IserviceRota" in both code and config file together.
    [ServiceContract]
    public interface IserviceRota
    {
        [OperationContract]
        HLP.Entries.Model.Models.Transportes.RotaModel Save(HLP.Entries.Model.Models.Transportes.RotaModel objRota);
        [OperationContract]
        bool Delete(int idRota);
        [OperationContract]
        HLP.Entries.Model.Models.Transportes.RotaModel Copy(HLP.Entries.Model.Models.Transportes.RotaModel objRota);
        [OperationContract]
        HLP.Entries.Model.Models.Transportes.RotaModel GetObject(int idRota);        
    }
}
