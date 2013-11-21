using HLP.Entries.Model.Models.RecursosHumanos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IserviceSetor" in both code and config file together.
    [ServiceContract]
    public interface IserviceSetor
    {
        [OperationContract]
        SetorModel getSetor(int idSetor);

        [OperationContract]
        int saveSetor(SetorModel objSetor);

        [OperationContract]
        bool deleteSetor(int idSetor);

        [OperationContract]
        int copySetor(int idSetor);
    }
}
