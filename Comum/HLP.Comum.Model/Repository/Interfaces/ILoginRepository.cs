using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Comum.Model.Repository.Interfaces
{
    public interface ILoginRepository
    {
        int ValidaUsuario(string xId);
        int ValidaLogin(string xID, string xSenha);
        int ValidaAcesso(string xId, int idEmpresa);
    }
}
