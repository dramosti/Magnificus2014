using HLP.Comum.Facade.Magnificus;
using HLP.Comum.Facade.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Comum.Model.Models
{
    public partial class loginModel : modelBase
    {

        public loginModel()
        {
            if (loginFacade.loginClient == null)
                loginFacade.loginClient = new Facade.loginService.IserviceLoginClient();
        }

        public int idEmpresa { get; set; }
        public string xId { get; set; }
        public string xPassword { get; set; }
    }

    public partial class loginModel
    {
        public override string this[string columnName]
        {
            get
            {
                if (columnName == "idEmpresa")
                {
                    if (this.idEmpresa == 0)
                        return "Necessário selecionar empresa!";
                }
                else if (columnName == "xId")
                {
                    if (this.xId == "")
                        return "Necessário informar Nome de Usuário!";
                    else if (loginFacade.loginClient.ValidaUsuario(xId: this.xId) < 1)
                        return "Nome de Usuário não existe na base de dados!";
                }
                else if(columnName == "xPassword")
                {
                    if (this.xPassword == "")
                        return "Campo de senha não pode ser vazio!";
                }
                return null;
            }
        }
    }
}
