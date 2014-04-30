using HLP.Entries.Model.Models.Gerais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "Iwcf_TipoServico" in both code and config file together.
    [ServiceContract]
    public interface Iwcf_TipoServico
    {

        [OperationContract]
        Tipo_servicoModel GetObject(int id);

        [OperationContract]
        int SaveObject(Tipo_servicoModel obj);

        [OperationContract]
        bool DeleteObject(int id);

        [OperationContract]
        Tipo_servicoModel CopyObject(int id);

    }
}
