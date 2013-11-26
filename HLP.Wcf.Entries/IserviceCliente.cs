using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IserviceCliente" in both code and config file together.
    [ServiceContract]
    public interface IserviceCliente
    {
        [OperationContract]
        HLP.Entries.Model.Models.Comercial.Cliente_fornecedorModel getCliente(int idCliente);

        [OperationContract]
        int saveCliente(HLP.Entries.Model.Models.Comercial.Cliente_fornecedorModel objCliente);

        [OperationContract]
        bool deleteCliente(int idCliente);

        [OperationContract]
        int copyCliente(HLP.Entries.Model.Models.Comercial.Cliente_fornecedorModel objCliente);

    }
}
