using HLP.Entries.Model.Models.Fiscal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "Iwcf_StCofins" in both code and config file together.
    [ServiceContract]
    public interface Iwcf_StCofins
    {
        [OperationContract]
        Situacao_tributaria_cofinsModel GetObject(int id);

        [OperationContract]
        int SaveObject(Situacao_tributaria_cofinsModel obj);

        [OperationContract]
        bool DeleteObject(int id);

        [OperationContract]
        Situacao_tributaria_cofinsModel CopyObject(int id);
    }
}
