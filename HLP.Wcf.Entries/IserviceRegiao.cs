using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HLP.Entries.Model.Models.Gerais;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IserviceRegiao" in both code and config file together.
    [ServiceContract]
    public interface IserviceRegiao
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        ObservableCollection<RegiaoModel> GetAll();
    }
}
