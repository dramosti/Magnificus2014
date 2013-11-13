using HLP.Entries.Model.Models.RecursosHumanos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IserviceCargo" in both code and config file together.
    [ServiceContract]
    public interface IserviceCargo
    {
        [OperationContract]
        CargoModel getCargo(int idCargo);

        [OperationContract]
        int saveCargo(CargoModel objCargo);

        [OperationContract]
        bool delCargo(int idCargo);

        [OperationContract]
        int copyCargo(int idCargo);
    }
}
