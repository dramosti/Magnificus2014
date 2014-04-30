using HLP.Entries.Model.Fiscal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "Iwcf_TipoDocumento" in both code and config file together.
    [ServiceContract]
    public interface Iwcf_TipoDocumento
    {
        [OperationContract]
        Tipo_documentoModel GetObject(int id);

        [OperationContract]
        Tipo_documentoModel SaveObject(Tipo_documentoModel obj);

        [OperationContract]
        bool DeleteObject(int id);

        [OperationContract]
        Tipo_documentoModel CopyObject(Tipo_documentoModel obj);

        [OperationContract]
        List<Tipo_documentoModel> GetTipo_documentoAll();
    }
}
