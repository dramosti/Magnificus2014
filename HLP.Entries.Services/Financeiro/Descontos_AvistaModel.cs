﻿using HLP.Base.ClassesBases;
using HLP.Base.Static;
using HLP.Entries.Model.Models.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Services.Financeiro
{
        public class Descontos_AvistaService
        {
            const string xTabela = "Descontos_Avista";
            
            Wcf.Entries.wcf_DescontoAVista serviceNetwork;
            wcf_DescontoAVista.Iwcf_DescontoAVistaClient serviceWeb;

            HLP.Wcf.Entries.wcf_CamposBaseDados serviceCamposBaseDadosNetwork;
            wcf_CamposBaseDados.Iwcf_CamposBaseDadosClient serviceCamposBaseDadosWeb;

            public Descontos_AvistaService()
            {
                switch (Sistema.bOnline)
                {
                    case StConnection.OnlineNetwork:
                        {
                            serviceNetwork = new Wcf.Entries.wcf_DescontoAVista();
                            serviceCamposBaseDadosNetwork = new Wcf.Entries.wcf_CamposBaseDados();

                            #region Validação

                            if (lCamposSqlNotNull._lCamposSql.Count(i => i.xTabela == xTabela)
                    == 0)
                            {
                                CamposSqlNotNullModel lCampos = new CamposSqlNotNullModel();
                                lCampos.xTabela = xTabela;
                                lCampos.lCamposSqlModel = serviceCamposBaseDadosNetwork.getCamposNotNull(
                                    xTabela: xTabela);
                                lCamposSqlNotNull.AddCampoSql(objCamposSqlNotNull: lCampos);
                            }

                            #endregion
                        }
                        break;
                    case StConnection.OnlineWeb:
                        {
                            serviceWeb = new wcf_DescontoAVista.Iwcf_DescontoAVistaClient();
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

            public Descontos_AvistaModel GetObject(int id)
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

            public int SaveObject(Descontos_AvistaModel obj)
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

            public int CopyObject(int id)
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
                            return 0;
                        }
                }
            }
        }
        
}
