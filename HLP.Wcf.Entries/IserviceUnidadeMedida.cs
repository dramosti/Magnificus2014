using HLP.Entries.Model.Models.Gerais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IserviceUnidadeMedida" in both code and config file together.
    [ServiceContract]
    public interface IserviceUnidadeMedida
    {
        [OperationContract]
        Unidade_medidaModel getUnidade_medida(int idUnidadeMedida);

        [OperationContract]
        int saveUnidade_medida(Unidade_medidaModel objUnidadeMedida);

        [OperationContract]
        bool deleteUnidade_medida(int idUnidadeMedida);
    }
}
