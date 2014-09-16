using HLP.Base.ClassesBases;
using HLP.Base.Static;
using HLP.Components.Model.Models;
using HLP.Entries.Model.Models.Gerais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Services.Gerais
{
    public class FuncionarioService
    {
        const string xTabela = "Funcionario;Enderecos;Funcionario_Arquivo;Funcionario_BancoHoras;Funcionario_Certificacao;Funcionario_Comissao_Produto;Funcionario_Controle_Horas_Ponto;Funcionario_Margem_Lucro_Comissao";

        HLP.Wcf.Entries.wcf_Funcionario serviceNetwork;        
        wcf_Funcionario.Iwcf_FuncionarioClient serviceWeb;

        HLP.Wcf.Entries.wcf_CamposBaseDados serviceCamposBaseDadosNetwork;
        wcf_CamposBaseDados.Iwcf_CamposBaseDadosClient serviceCamposBaseDadosWeb;

        public FuncionarioService()
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        serviceNetwork = new Wcf.Entries.wcf_Funcionario();
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
                        serviceWeb = new wcf_Funcionario.Iwcf_FuncionarioClient();
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

        public FuncionarioModel GetObject(int id, bool bGetChild= true)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.serviceNetwork.getFuncionario(id, bGetChild);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.serviceWeb.getFuncionario(id, bGetChild);
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
                        return this.serviceNetwork.saveFuncionario(obj);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.serviceWeb.saveFuncionario(obj);
                    }
                case StConnection.Offline:
                default:
                    {
                        return new FuncionarioModel();
                    }
            }
        }

        public bool DeleteObject(int id)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.serviceNetwork.deleteFuncionario(id);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.serviceWeb.deleteFuncionario(id);
                    }
                case StConnection.Offline:
                default:
                    {
                        return false;
                    }
            }
        }

        public FuncionarioModel CopyObject(FuncionarioModel obj)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.serviceNetwork.copyFuncionario(obj);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.serviceWeb.copyFuncionario(obj);
                    }
                case StConnection.Offline:
                default:
                    {
                        return new FuncionarioModel();
                    }
            }
        }

        public modelToTreeView GetHierarquia(int idFuncionario)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.serviceNetwork.GetHierarquiaFuncionario(idFuncionario: idFuncionario);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.serviceWeb.GetHierarquiaFuncionario(idFuncionario);
                    }
            }
            return null;
        }
    }
}
