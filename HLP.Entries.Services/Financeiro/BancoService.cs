using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Base.ClassesBases;
using HLP.Entries.Model.Models.Financeiro;
using HLP.Base.Static;

namespace HLP.Entries.Services.Financeiro
{
   
        public class BancoService
        {
            const string xTabela = "Banco;";
            
            HLP.Wcf.Entries.wcf_Banco serviceNetwork;
            HLP.Entries.Services.wcf_Banco.Iwcf_BancoClient serviceWeb;

            HLP.Wcf.Entries.wcf_CamposBaseDados serviceCamposBaseDadosNetwork;
            wcf_CamposBaseDados.Iwcf_CamposBaseDadosClient serviceCamposBaseDadosWeb;

            public BancoService()
            {
                switch (Sistema.bOnline)
                {
                    case StConnection.OnlineNetwork:
                        {
                            serviceNetwork = new HLP.Wcf.Entries.wcf_Banco();
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
                            serviceWeb = new HLP.Entries.Services.wcf_Banco.Iwcf_BancoClient();
                            serviceCamposBaseDadosWeb = new wcf_CamposBaseDados.Iwcf_CamposBaseDadosClient();

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
                    case StConnection.Offline:
                    default:
                        {
                        } break;
                }
            }

            public BancoModel GetObject(int id)
            {
                switch (Sistema.bOnline)
                {
                    case StConnection.OnlineNetwork:
                        {
                            return this.serviceNetwork.GetObjeto(id);
                        }
                    case StConnection.OnlineWeb:
                        {
                            return this.serviceWeb.GetObjeto(id);
                        }
                    case StConnection.Offline:
                    default:
                        {
                            return null;
                        }
                }
            }

            public int SaveObject(BancoModel obj)
            {
                switch (Sistema.bOnline)
                {
                    case StConnection.OnlineNetwork:
                        {
                            return this.serviceNetwork.Save(obj);
                        }
                    case StConnection.OnlineWeb:
                        {
                            return this.serviceWeb.Save(obj);
                        }
                    case StConnection.Offline:
                    default:
                        {
                            return 0;
                        }
                }
            }

            public bool DeleteObject(BancoModel obj)
            {
                switch (Sistema.bOnline)
                {
                    case StConnection.OnlineNetwork:
                        {
                            return this.serviceNetwork.Delete(obj);
                        }
                    case StConnection.OnlineWeb:
                        {
                            return this.serviceWeb.Delete(obj);
                        }
                    case StConnection.Offline:
                    default:
                        {
                            return false;
                        }
                }
            }

            public int CopyObject(BancoModel obj)
            {
                switch (Sistema.bOnline)
                {
                    case StConnection.OnlineNetwork:
                        {
                            return this.serviceNetwork.Copy(obj);
                        }
                    case StConnection.OnlineWeb:
                        {
                            return this.serviceWeb.Copy(obj);
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
