﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Entries.Model.Models.Gerais;
using HLP.Base.Static;
using HLP.Base.ClassesBases;

namespace HLP.Entries.Services.Gerais
{

    public class CalendarioService
    {
        const string xTabela = "Calendario";

        Wcf.Entries.wcf_Calendario serviceNetwork;
        wcf_Calendarios.Iwcf_CalendarioClient serviceWeb;

        HLP.Wcf.Entries.wcf_CamposBaseDados serviceCamposBaseDadosNetwork;
        wcf_CamposBaseDados.Iwcf_CamposBaseDadosClient serviceCamposBaseDadosWeb;

        public CalendarioService()
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        serviceNetwork = new Wcf.Entries.wcf_Calendario();
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
                        serviceWeb = new wcf_Calendarios.Iwcf_CalendarioClient();
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

        public CalendarioModel GetObject(int id, bool bGetChild = true)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.serviceNetwork.GetObjeto(idObjeto: id, bGetChild: bGetChild);
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

        public CalendarioModel SaveObject(CalendarioModel obj)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.serviceNetwork.Save(obj, UserData.idUser);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.serviceWeb.Save(obj);
                    }
                case StConnection.Offline:
                default:
                    {
                        return new CalendarioModel();
                    }
            }
        }

        public bool DeleteObject(CalendarioModel obj)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.serviceNetwork.Delete(obj, UserData.idUser);
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


        public List<HLP.Entries.Model.Models.Gerais.Calendario_IntervalosModel> GetIntervalos(int idCalendario) 
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.serviceNetwork.GetIntervalos(idCalendario);
                    }
                case StConnection.OnlineWeb:
                    {
                        //return this.serviceWeb.GetIntervalos(idCalendario);
                        return new List<Calendario_IntervalosModel>();
                    }
                case StConnection.Offline:
                default:
                    {
                        return new List<Calendario_IntervalosModel>();
                    }
            }

        }

    }

}
