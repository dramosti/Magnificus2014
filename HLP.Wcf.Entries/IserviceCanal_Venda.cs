using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IserviceCanal_Venda" in both code and config file together.
    [ServiceContract]
    public interface IserviceCanal_Venda
    {
        [OperationContract]
        HLP.Entries.Model.Models.Comercial.Canal_vendaModel getCanal_venda(int idCanal_venda);

        [OperationContract]
        int saveCanal_venda(HLP.Entries.Model.Models.Comercial.Canal_vendaModel objCanal_venda);

        [OperationContract]
        bool deleteCanal_venda(int idCanal_venda);

        [OperationContract]
        int copyCanal_venda(int idCanal_venda);
    }
}
