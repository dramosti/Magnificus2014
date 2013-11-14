using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HLP.Comum.Model.Components;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IserviceHlpPesquisaPadrao" in both code and config file together.
    [ServiceContract]
    public interface IserviceHlpPesquisaPadrao
    {
        [OperationContract]
        DataTable GetData(string sSelect, bool addDefault = false, string sWhere = "", bool bOrdena = true);

        [OperationContract]
        ObservableCollection<PesquisaPadraoModel> GetTableInformation(string sViewName);
    }
}
