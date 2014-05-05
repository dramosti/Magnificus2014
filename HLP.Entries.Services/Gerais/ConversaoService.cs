using HLP.Base.ClassesBases;
using HLP.Base.Static;
using HLP.Entries.Model.Models.Comercial;
using HLP.Entries.Model.Models.Gerais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Services.Gerais
{

        public class ConversaoService
        {
            const string xTabela = "Conversao;";
            
            HLP.Wcf.Entries.wcf_Conversao serviceNetwork;
            wcf_Conversao.Iwcf_ConversaoClient serviceWeb;

            HLP.Wcf.Entries.wcf_CamposBaseDados serviceCamposBaseDadosNetwork;
            wcf_CamposBaseDados.Iwcf_CamposBaseDadosClient serviceCamposBaseDadosWeb;

            public ConversaoService()
            {
                switch (Sistema.bOnline)
                {
                    case StConnection.OnlineNetwork:
                        {
                            serviceNetwork = new HLP.Wcf.Entries.wcf_Conversao();
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
                            serviceWeb = new wcf_Conversao.Iwcf_ConversaoClient();
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

            public ProdutoModel GetObject(int id)
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

            public List<ConversaoModel> SaveList(ProdutoModel obj)
            {
                switch (Sistema.bOnline)
                {
                    case StConnection.OnlineNetwork:
                        {
                            return this.serviceNetwork.SaveObject(obj: obj).ToList();
                        }
                    case StConnection.OnlineWeb:
                        {
                            return this.serviceWeb.SaveObject(obj: obj);
                        }
                    case StConnection.Offline:
                    default:
                        {
                            return null;
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
        }
        
}
