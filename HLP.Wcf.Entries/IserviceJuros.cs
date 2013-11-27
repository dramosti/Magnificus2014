using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IserviceJuros" in both code and config file together.
    [ServiceContract]
    public interface IserviceJuros
    {
        [OperationContract]
        HLP.Entries.Model.Models.Comercial.JurosModel getJuros(int idJuros);

        [OperationContract]
        int saveJuros(HLP.Entries.Model.Models.Comercial.JurosModel objJuros);

        [OperationContract]
        bool deleteJuros(int idJuros);

        [OperationContract]
        int copyJuros(int idJuros);
    }
}
