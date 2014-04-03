using HLP.Entries.Model.Models.Gerais;
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
        EmpresaModel GetObject(int id);

        [OperationContract]
        EmpresaModel SaveObject(EmpresaModel obj);

        [OperationContract]
        bool DeleteObject(int id);

        [OperationContract]
        EmpresaModel CopyObject(EmpresaModel obj);

    }
}
