using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IserviceTipo_documento_Operacao_Valida" in both code and config file together.
    [ServiceContract]
    public interface IserviceTipo_documento_Operacao_Valida
    {
        [OperationContract]
        int Save(HLP.Entries.Model.Fiscal.Tipo_documento_oper_validaModel objModel);

        [OperationContract]
        HLP.Entries.Model.Fiscal.Tipo_documento_oper_validaModel GetObjeto(int idObjeto);

        [OperationContract]
        bool Delete(HLP.Entries.Model.Fiscal.Tipo_documento_oper_validaModel objModel);

        [OperationContract]
        int Copy(HLP.Entries.Model.Fiscal.Tipo_documento_oper_validaModel objModel);

        [OperationContract]
        IEnumerable<HLP.Entries.Model.Fiscal.Tipo_documento_oper_validaModel> GetOperacoesValidas(int idTipoDocumento);
    }
}
