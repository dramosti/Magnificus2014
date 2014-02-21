using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IserviceLogin" in both code and config file together.
    [ServiceContract]
    public interface IserviceLogin
    {
        [OperationContract]
        int ValidaUsuario(string xId);

        [OperationContract]
        int ValidaAcesso(int idEmpresa, string xId);

        [OperationContract]
        int ValidaLogin(string xId, string xSenha);

        [OperationContract]
        int GetIdFuncionarioByXid(string xId);

        [OperationContract]
        int ValidaAdministrador(string xID, string xSenha, int idEmpresa);
    }
}
