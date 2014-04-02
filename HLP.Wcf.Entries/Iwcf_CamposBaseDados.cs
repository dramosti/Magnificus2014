using HLP.Base.ClassesBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "Iwcf_CamposBaseDados" in both code and config file together.
    [ServiceContract]
    public interface Iwcf_CamposBaseDados
    {
        [OperationContract]
        List<PesquisaPadraoModelContract> getCamposNotNull(string xTabela);
    }
}
