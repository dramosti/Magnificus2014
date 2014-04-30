using HLP.Entries.Model.Models.Fiscal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "Iwcf_ClassificacaoFiscal" in both code and config file together.
    [ServiceContract]
    public interface Iwcf_ClassificacaoFiscal
    {
        
        [OperationContract]
        Classificacao_fiscalModel GetObject(int id);

        [OperationContract]
        int SaveObject(Classificacao_fiscalModel obj);

        [OperationContract]
        bool DeleteObject(int id);

        [OperationContract]
        Classificacao_fiscalModel CopyObject(int id);
        
    }
}
