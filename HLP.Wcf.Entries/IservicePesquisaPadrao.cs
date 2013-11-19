using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HLP.Comum.Model.Components;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IservicePesquisaPadrao" in both code and config file together.
    [ServiceContract]
    [DataContractFormat]
    public interface IservicePesquisaPadrao
    {
        [OperationContract]
        PesquisaPadraoModelContract[] GetTableInformation(string sViewName);

        [OperationContract]
        System.Data.DataSet GetData(string sSelect, bool addDefault = false, string sWhere = "", bool bOrdena = true);
    }
}
