using HLP.Base.ClassesBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.ComumView.Model.Model
{
    public partial class loginModel : modelBase
    {

        public loginModel()
        {
            //if (loginFacade.loginClient == null)
            //    loginFacade.loginClient = new Facade.loginService.IserviceLoginClient();

            indexEmpresa = 0;
        }


        public int indexEmpresa { get; set; }
        public int idEmpresa { get; set; }
        public string xId { get; set; }
        public string xPassword { get; set; }
        private string _xError;

        public string xError
        {
            get { return _xError; }
            set { _xError = value; base.NotifyPropertyChanged("xError"); }
        }

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
                    //else if (loginFacade.loginClient.ValidaUsuario(xId: this.xId) < 1)
                    //    return "Nome de Usuário não existe na base de dados!";                   
                }
                else if (columnName == "xPassword")
                {
                    if (this.xPassword == "")
                        return "Campo de senha não pode ser vazio!";
                }
                return null;
            }
        }
    }
}
