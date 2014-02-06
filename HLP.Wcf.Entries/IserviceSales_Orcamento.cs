﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IserviceSales_Orcamento" in both code and config file together.
    [ServiceContract]
    public interface IserviceSales_Orcamento
    {
        [OperationContract]
        HLP.Sales.Model.Models.Comercial.Orcamento_ideModel Save(HLP.Sales.Model.Models.Comercial.Orcamento_ideModel objModel);

        [OperationContract]
        HLP.Sales.Model.Models.Comercial.Orcamento_ideModel GetObjeto(int idObjeto, int idEmpresa);

        [OperationContract]
        bool Delete(HLP.Sales.Model.Models.Comercial.Orcamento_ideModel objModel);

        [OperationContract]
        int Copy(HLP.Sales.Model.Models.Comercial.Orcamento_ideModel objModel);
    }
}
