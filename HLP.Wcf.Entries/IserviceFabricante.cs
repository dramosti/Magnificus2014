using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IserviceFabricante" in both code and config file together.
    [ServiceContract]
    public interface IserviceFabricante
    {
        [OperationContract]
        HLP.Entries.Model.Models.Gerais.FabricanteModel getFabricante(int idFabricante);

        [OperationContract]
        int saveFabricante(HLP.Entries.Model.Models.Gerais.FabricanteModel objFabricante);

        [OperationContract]
        bool deleteFabricante(int idFabricante);

        [OperationContract]
        int copyFabricante(int idFabricante);

    }
}
