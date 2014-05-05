using HLP.Base.ClassesBases;
using HLP.Base.Static;
using HLP.Entries.Model.Models.Fiscal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Services
{
    public class St_CofinsService
    {
        const string xTabela = "St_Cofins;";

        HLP.Wcf.Entries.wcf_StCofins serviceNetwork;
        wcf_StCofins.Iwcf_StCofinsClient serviceWeb;

        HLP.Wcf.Entries.wcf_CamposBaseDados serviceCamposBaseDadosNetwork;
        wcf_CamposBaseDados.Iwcf_CamposBaseDadosClient serviceCamposBaseDadosWeb;

        public St_CofinsService()
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        serviceNetwork = new HLP.Wcf.Entries.wcf_StCofins();
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
                        serviceWeb = new wcf_StCofins.Iwcf_StCofinsClient();
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

        public Situacao_tributaria_cofinsModel GetObject(int id)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.serviceNetwork.GetObject(id: id);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.serviceWeb.GetObject(id: id);
                    }
                case StConnection.Offline:
                default:
                    {
                        return null;
                    }
            }
        }

        public int SaveObject(Situacao_tributaria_cofinsModel obj)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.serviceNetwork.SaveObject(obj: obj);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.serviceWeb.SaveObject(obj: obj);
                    }
                case StConnection.Offline:
                default:
                    {
                        return 0;
                    }
            }
        }

        public bool DeleteObject(int id)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.serviceNetwork.DeleteObject(id: id);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.serviceWeb.DeleteObject(id: id);
                    }
                case StConnection.Offline:
                default:
                    {
                        return false;
                    }
            }
        }

        public Situacao_tributaria_cofinsModel CopyObject(int id)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.serviceNetwork.CopyObject(id: id);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.serviceWeb.CopyObject(id: id);
                    }
                case StConnection.Offline:
                default:
                    {
                        return null;
                    }
            }
        }
    }

}
