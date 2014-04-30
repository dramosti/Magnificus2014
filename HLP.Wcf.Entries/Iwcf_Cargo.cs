using HLP.Entries.Model.Models.RecursosHumanos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "Iwcf_Cargo" in both code and config file together.
    [ServiceContract]
    public interface Iwcf_Cargo
    {
        
        [OperationContract]
        CargoModel GetObject(int id);

        [OperationContract]
        int SaveObject(CargoModel obj);

        [OperationContract]
        bool DeleteObject(int id);

        [OperationContract]
        CargoModel CopyObject(int id);
        
    }
}
