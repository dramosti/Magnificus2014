using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "Iwcf_Empresa" in both code and config file together.
    [ServiceContract]
    public interface Iwcf_Empresa
    {

        [OperationContract]
        HLP.Entries.Model.Models.Gerais.EmpresaModel GetObject(int id);

        [OperationContract]
        HLP.Entries.Model.Models.Gerais.EmpresaModel SaveObject(HLP.Entries.Model.Models.Gerais.EmpresaModel obj);

        [OperationContract]
        bool DeleteObject(int id);

        [OperationContract]
        HLP.Entries.Model.Models.Gerais.EmpresaModel CopyObject(HLP.Entries.Model.Models.Gerais.EmpresaModel obj);

    }
}
