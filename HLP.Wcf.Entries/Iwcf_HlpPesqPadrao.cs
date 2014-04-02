using HLP.Base.ClassesBases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "Iwcf_HlpPesqPadrao" in both code and config file together.
    [ServiceContract]
    public interface Iwcf_HlpPesqPadrao
    {
        [OperationContract]
        List<PesquisaPadraoModelContract> GetTableInformation(string sViewName);

        [OperationContract]
        DataSet GetData(string sSelect, bool addDefault = false, string sWhere = "", bool bOrdena = true);
    }
}
