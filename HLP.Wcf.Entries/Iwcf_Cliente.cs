using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "Iwcf_Cliente" in both code and config file together.
    [ServiceContract]
    public interface Iwcf_Cliente
    {
        [OperationContract]
        HLP.Entries.Model.Models.Comercial.Cliente_fornecedorModel GetObject(int id);

        [OperationContract]
        HLP.Entries.Model.Models.Comercial.Cliente_fornecedorModel Save(HLP.Entries.Model.Models.Comercial.Cliente_fornecedorModel obj);

        [OperationContract]
        bool Delete(int id);

        [OperationContract]
        HLP.Entries.Model.Models.Comercial.Cliente_fornecedorModel Copy(HLP.Entries.Model.Models.Comercial.Cliente_fornecedorModel obj);
    }
}
