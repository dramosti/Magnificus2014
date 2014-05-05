using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Wcf.Entries
{
    [ServiceContract]
    public interface Iwcf_EmpresaParametros
    {
        [OperationContract]
        HLP.Entries.Model.Models.Gerais.EmpresaModel getEmpresaParametros(int idEmpresa);

        [OperationContract]
        void saveEmpresaParamestros(HLP.Entries.Model.Models.Gerais.EmpresaParametrosModel objEmpresaParametros);
    }
}
