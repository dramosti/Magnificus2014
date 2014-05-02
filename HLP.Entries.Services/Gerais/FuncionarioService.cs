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
        const string xTabela = "Funcionario";

        HLP.Wcf.Entries.wcf_Funcionario serviceNetwork;
        HLP.Entries.Services.wcf_Funcionarios.Iwcf_FuncionarioClient serviceWeb;

        HLP.Wcf.Entries.wcf_CamposBaseDados serviceCamposBaseDadosNetwork;
        wcf_CamposBaseDados.Iwcf_CamposBaseDadosClient serviceCamposBaseDadosWeb;

        public FuncionarioService()
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        serviceNetwork = new HLP.Wcf.Entries.wcf_Funcionario();
                        serviceCamposBaseDadosNetwork = new Wcf.Entries.wcf_CamposBaseDados();

                        #region Validação

                        if (lCamposSqlNotNull._lCamposSql.Count(i => i.xTabela == xTabela)
                == 0)
                        {
                            CamposSqlNotNullModel lCampos = new CamposSqlNotNullModel();
                            lCampos.xTabela = xTabela;
                            lCampos.lCamposSqlModel = serviceCamposBaseDadosWeb.getCamposNotNull(
                                xTabela: xTabela);
                            lCamposSqlNotNull.AddCampoSql(objCamposSqlNotNull: lCampos);
                        }

                        #endregion
                    }
                    break;
                case StConnection.OnlineWeb:
                    {
                        serviceWeb = new wcf_Funcionarios.Iwcf_FuncionarioClient();
                        serviceCamposBaseDadosWeb = new wcf_CamposBaseDados.Iwcf_CamposBaseDadosClient();

                        #region Validação

                        if (lCamposSqlNotNull._lCamposSql.Count(i => i.xTabela == xTabela)
                == 0)
                        {
                            CamposSqlNotNullModel lCampos = new CamposSqlNotNullModel();
                            lCampos.xTabela = xTabela;
                            lCampos.lCamposSqlModel = serviceCamposBaseDadosWeb.getCamposNotNull(
                                xTabela: xTabela);
                            lCamposSqlNotNull.AddCampoSql(objCamposSqlNotNull: lCampos);
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
                        return this.serviceNetwork.getFuncionario(id);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.serviceWeb.getFuncionario(id);
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
