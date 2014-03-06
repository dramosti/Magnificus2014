using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Sales
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "Iwcf_Orcamento" in both code and config file together.
    [ServiceContract]
    public interface Iwcf_Orcamento
    {
        [OperationContract]
        HLP.Sales.Model.Models.Comercial.Orcamento_ideModel Save(HLP.Sales.Model.Models.Comercial.Orcamento_ideModel objModel);

        [OperationContract]
        HLP.Sales.Model.Models.Comercial.Orcamento_ideModel GetObjeto(int idObjeto, int idEmpresa);

        [OperationContract]
        bool Delete(HLP.Sales.Model.Models.Comercial.Orcamento_ideModel objModel);

        [OperationContract]
        HLP.Sales.Model.Models.Comercial.Orcamento_ideModel Copy(HLP.Sales.Model.Models.Comercial.Orcamento_ideModel objModel);

        [OperationContract]
        HLP.Sales.Model.Models.Comercial.Orcamento_ideModel GerarVersao(
            HLP.Sales.Model.Models.Comercial.Orcamento_ideModel objModel);

        [OperationContract]
        List<int> GetListaVersoes(int idOrcamento);

        [OperationContract]
        bool PossuiFilho(int idOrcamento);
    }
}
