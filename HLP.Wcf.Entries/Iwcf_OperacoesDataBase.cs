using HLP.Base.EnumsBases;
using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "Iwcf_OperacoesDataBase" in both code and config file together.
    [ServiceContract]
    public interface Iwcf_OperacoesDataBase
    {
        [OperationContract]
        List<RecordsSqlModel> GetRecordsFKUsed(string xTabela, string xCampo, string valor, int idEmpresa);

        [OperationContract]
        int GetRecord(string xNameTable, string xCampo, string xValue, stFilterQuickSearch stFilterQS, int idEmpresa = 0);
    }
}
