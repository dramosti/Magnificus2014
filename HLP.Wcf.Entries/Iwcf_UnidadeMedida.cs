using HLP.Entries.Model.Models.Gerais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "Iwcf_UnidadeMedida" in both code and config file together.
    [ServiceContract]
    public interface Iwcf_UnidadeMedida
    {
        [OperationContract]
        Unidade_medidaModel GetObject(int id);

        [OperationContract]
        int SaveObject(Unidade_medidaModel obj);

        [OperationContract]
        bool DeleteObject(int id);

        [OperationContract]
        int CopyObject(int id);
    }
}
