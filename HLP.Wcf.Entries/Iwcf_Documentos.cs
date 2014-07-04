using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "Iwcf_Documentos" in both code and config file together.
    [ServiceContract]
    public interface Iwcf_Documentos
    {
        [OperationContract]
        List<DocumentosModel> GetListObject(string xTabela, int idPk);

        [OperationContract]
        List<DocumentosModel> SaveObject(List<DocumentosModel> lDocumentos, string xNameTabela, int idPk);

        [OperationContract]
        bool DeleteObject(string xNameTabela, int idPk);

        [OperationContract]
        List<DocumentosModel> CopyObject(List<DocumentosModel> lDocumentos);
    }
}
