using HLP.Base.ClassesBases;
using HLP.Base.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Services.Gerais
{
    public class LoginService
    {
        const string xTabela = "Login;";

        HLP.Wcf.Entries.wcf_Login serviceNetwork;
        wcf_Login.Iwcf_LoginClient serviceWeb;
        //Namespace Web serviceWeb;

        HLP.Wcf.Entries.wcf_CamposBaseDados serviceCamposBaseDadosNetwork;        

        public LoginService()
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        serviceNetwork = new Wcf.Entries.wcf_Login();
                     //   serviceCamposBaseDadosNetwork = new Wcf.Entries.wcf_CamposBaseDados();
                    }
                    break;
                case StConnection.OnlineWeb:
                    {
                        serviceWeb = new wcf_Login.Iwcf_LoginClient(); 
                    }
                    break;
                case StConnection.Offline:
                default:
                    {
                    } break;
            }
        }

        public int ValidaLogin(string xId, string xSenha)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.serviceNetwork.ValidaLogin(xId: xId, xSenha: xSenha);
                    }
                case StConnection.OnlineWeb:
                    {
                        return serviceWeb.ValidaLogin(xId: xId, xSenha: xSenha);
                    }
                case StConnection.Offline:
                default:
                    {
                        return 0;
                    }
            }
        }

        public int ValidaAcesso(int idEmpresa, string xId)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.serviceNetwork.ValidaAcesso(idEmpresa: idEmpresa, xId: xId);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.serviceWeb.ValidaAcesso(idEmpresa: idEmpresa, xId: xId);
                    }
                case StConnection.Offline:
                default:
                    {
                        return 0;
                    }
            }
        }

        public int GetIdFuncionarioByXid(string xId)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.serviceNetwork.GetIdFuncionarioByXid(xId: xId);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.serviceWeb.GetIdFuncionarioByXid(xId: xId);
                    }
                case StConnection.Offline:
                default:
                    {
                        return 0;
                    }
            }
        }
    }
}
