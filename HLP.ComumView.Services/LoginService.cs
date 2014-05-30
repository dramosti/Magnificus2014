using HLP.Base.ClassesBases;
using HLP.Base.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.ComumView.Services
{
    public class LoginService
    {
        const string xTabela = "Login;";

        HLP.Wcf.Entries.wcf_Login serviceNetwork;
        wcf_Login.Iwcf_LoginClient serviceWeb;

        HLP.Wcf.Entries.wcf_CamposBaseDados serviceCamposBaseDadosNetwork;
        wcf_CamposBaseDados.Iwcf_CamposBaseDadosClient serviceCamposBaseDadosWeb;

        public LoginService()
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        serviceNetwork = new Wcf.Entries.wcf_Login();
                        serviceCamposBaseDadosNetwork = new Wcf.Entries.wcf_CamposBaseDados();
                        #region Validação

                        foreach (string str in xTabela.Split(';').ToArray())
                        {
                            if (lCamposSqlNotNull._lCamposSql.Count(i => i.xTabela == str) == 0)
                            {
                                CamposSqlNotNullModel lCampos = new CamposSqlNotNullModel();
                                lCampos.xTabela = str;
                                lCampos.lCamposSqlModel = serviceCamposBaseDadosNetwork.getCamposNotNull(
                                    xTabela: str);
                                lCamposSqlNotNull.AddCampoSql(objCamposSqlNotNull: lCampos);
                            }
                        }

                        #endregion
                    }
                    break;
                case StConnection.OnlineWeb:
                    {
                        serviceWeb = new wcf_Login.Iwcf_LoginClient();
                        serviceCamposBaseDadosWeb = new wcf_CamposBaseDados.Iwcf_CamposBaseDadosClient();
                        #region Validação

                        foreach (string str in xTabela.Split(';').ToArray())
                        {
                            if (lCamposSqlNotNull._lCamposSql.Count(i => i.xTabela == str) == 0)
                            {
                                CamposSqlNotNullModel lCampos = new CamposSqlNotNullModel();
                                lCampos.xTabela = str;
                                lCampos.lCamposSqlModel = serviceCamposBaseDadosWeb.getCamposNotNull(
                                    xTabela: str);
                                lCamposSqlNotNull.AddCampoSql(objCamposSqlNotNull: lCampos);
                            }
                        }

                        #endregion
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

        public int ValidaAdministrador(string xID, string xSenha, int idEmpresa)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.serviceNetwork.ValidaAdministrador(xID: xID, xSenha: xSenha, idEmpresa: idEmpresa);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.serviceWeb.ValidaAdministrador(xID: xID, xSenha: xSenha, idEmpresa: idEmpresa);
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
