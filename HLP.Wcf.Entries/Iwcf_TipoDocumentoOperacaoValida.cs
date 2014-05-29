using HLP.Entries.Model.Fiscal;
using HLP.Entries.Model.Models.Fiscal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "Iwcf_TipoDocumentoOperacaoValida" in both code and config file together.
    [ServiceContract]
    public interface Iwcf_TipoDocumentoOperacaoValida
    {
        [OperationContract]
        List<Tipo_documento_oper_validaModel> GetOperacoesValidas(int idTipoDocumento);
    }
}
