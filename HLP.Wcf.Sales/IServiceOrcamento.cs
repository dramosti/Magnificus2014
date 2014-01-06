using HLP.Sales.Model.Models.Comercial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Sales
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceOrcamento" in both code and config file together.
    [ServiceContract]
    public interface IServiceOrcamento
    {
        [OperationContract]
        int Save(Orcamento_ideModel objModel);

        [OperationContract]
        Orcamento_ideModel GetObjeto(int idObjeto);

        [OperationContract]
        bool Delete(Orcamento_ideModel objModel);

        [OperationContract]
        int Copy(Orcamento_ideModel objModel);
    }
}
