using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "Iwcf_Acesso" in both code and config file together.
    [ServiceContract]
    public interface Iwcf_Acesso
    {
        [OperationContract]
        HLP.Entries.Model.Models.Gerais.FuncionarioModel Save(HLP.Entries.Model.Models.Gerais.FuncionarioModel objModel);

        [OperationContract]
        HLP.Entries.Model.Models.Gerais.FuncionarioModel GetObjeto(int idObjeto);

        [OperationContract]
        bool ValidaUsuario(string xLogin, string xSenha, int idFuncionario);
    }
}
