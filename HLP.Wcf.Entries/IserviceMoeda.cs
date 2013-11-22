using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IserviceMoeda" in both code and config file together.
    [ServiceContract]
    public interface IserviceMoeda
    {
        [OperationContract]
        HLP.Entries.Model.Models.Gerais.MoedaModel getMoeda(int idMoeda);

        [OperationContract]
        int saveMoeda(HLP.Entries.Model.Models.Gerais.MoedaModel objMoeda);

        [OperationContract]
        bool deleteMoeda(int idMoeda);

        [OperationContract]
        int copyMoeda(int idMoeda);
    }
}
