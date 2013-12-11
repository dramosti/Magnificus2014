using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IserviceEmpresaParametros" in both code and config file together.
    [ServiceContract]
    public interface IserviceEmpresaParametros
    {
        [OperationContract]
        HLP.Entries.Model.Models.Gerais.EmpresaModel getEmpresaParametros(int idEmpresa);

        [OperationContract]
        void saveEmpresaParamestros(HLP.Entries.Model.Models.Gerais.EmpresaParametrosModel objEmpresaParametros);
    }
}
