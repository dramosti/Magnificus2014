using HLP.Entries.Model.Models.Fiscal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "Iwcf_StIcms" in both code and config file together.
    [ServiceContract]
    public interface Iwcf_StIcms
    {
        [OperationContract]
        Situacao_tributaria_icmsModel GetObject(int id);

        [OperationContract]
        int SaveObject(Situacao_tributaria_icmsModel obj);

        [OperationContract]
        bool DeleteObject(int id);

        [OperationContract]
        Situacao_tributaria_icmsModel CopyObject(int id);
    }
}
