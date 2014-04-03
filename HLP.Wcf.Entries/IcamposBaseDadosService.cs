using HLP.Base.ClassesBases;
using System.Collections.Generic;
using System.ServiceModel;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IcamposBaseDadosService" in both code and config file together.
    [ServiceContract]
    public interface IcamposBaseDadosService
    {
        [OperationContract]
        List<PesquisaPadraoModelContract> getCamposNotNull(string xTabela);
    }
}
