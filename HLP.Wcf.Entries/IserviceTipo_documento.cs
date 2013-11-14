using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HLP.Entries.Model.Fiscal;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IserviceTipo_documento" in both code and config file together.
    [ServiceContract]
    public interface IserviceTipo_documento
    {
        [OperationContract]
        void DoWork();
        [OperationContract]
        Tipo_documentoModel GetDocumento(int idTipoDocumento);
        [OperationContract]
        void Save(Tipo_documentoModel documento);
        [OperationContract]
        void Delete(int idTipoDocumento);
        [OperationContract]
        void Begin();
        [OperationContract]
        void Commit();
        [OperationContract]
        void RollBack();
        [OperationContract]
        int Copy(int idTipoDocumento);
        [OperationContract]
        List<Tipo_documentoModel> GetTipo_documentoAll();
    }
}
