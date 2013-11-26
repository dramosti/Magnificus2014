using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IserviceMulta" in both code and config file together.
    [ServiceContract]
    public interface IserviceMulta
    {
        [OperationContract]
        HLP.Entries.Model.Models.Comercial.MultasModel getMulta(int idMulta);

        [OperationContract]
        int saveMulta(HLP.Entries.Model.Models.Comercial.MultasModel objMulta);

        [OperationContract]
        bool deleteMulta(int idMulta);

        [OperationContract]
        int copyMulta(int idMulta);
    }
}
