using HLP.Base.ClassesBases;
using HLP.Base.Static;
using HLP.Entries.Model.Models.Gerais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Services.Gerais
{
    public class Funcionario_AcessoService
    {
        const string xTabela = "Acesso;";

        HLP.Wcf.Entries.wcf_Acesso serviceNetwork;        
        wcf_Acesso.Iwcf_AcessoClient serviceWeb;

        HLP.Wcf.Entries.wcf_CamposBaseDados serviceCamposBaseDadosNetwork;
        wcf_CamposBaseDados.Iwcf_CamposBaseDadosClient serviceCamposBaseDadosWeb;

        public Funcionario_AcessoService()
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        serviceNetwork = new HLP.Wcf.Entries.wcf_Acesso();
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
                        serviceWeb = new wcf_Acesso.Iwcf_AcessoClient();
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

        public FuncionarioModel GetObject(int id)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.serviceNetwork.GetObjeto(idObjeto: id);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.serviceWeb.GetObjeto(idObjeto: id);
                    }
                case StConnection.Offline:
                default:
                    {
                        return null;
                    }
            }
        }

        public FuncionarioModel SaveObject(FuncionarioModel obj)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.serviceNetwork.Save(objModel: obj);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.serviceWeb.Save(objModel: obj);
                    }
                case StConnection.Offline:
                default:
                    {
                        return null;
                    }
            }
        }

        public bool ValidaUsuario(string xLogin, string xSenha, int idFuncionario)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.serviceNetwork.ValidaUsuario(xLogin: xLogin, xSenha: xSenha,
                            idFuncionario: idFuncionario);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.serviceWeb.ValidaUsuario(xLogin: xLogin, xSenha: xSenha,
                            idFuncionario: idFuncionario);
                    }
                case StConnection.Offline:
                default:
                    {
                        return false;
                    }
            }
        }
    }

}
