using HLP.Entries.Model.Models.Contabil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "Iwcf_ClasseFinanceira" in both code and config file together.
    [ServiceContract]
    public interface Iwcf_ClasseFinanceira
    {
        
        [OperationContract]
        Classe_FinanceiraModel GetObject(int id);

        [OperationContract]
        int SaveObject(Classe_FinanceiraModel obj);

        [OperationContract]
        bool DeleteObject(int id);

        [OperationContract]
        Classe_FinanceiraModel CopyObject(int id);
        
    }
}
