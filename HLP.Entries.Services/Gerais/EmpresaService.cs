﻿using HLP.Base.ClassesBases;
using HLP.Base.Static;
using HLP.Entries.Model.Models.Gerais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Services.Gerais
{
    public class EmpresaService
    {
        const string xTabela = "Empresa";

        HLP.Wcf.Entries.wcf_Empresa serviceNetwork;
        wcf_Empresa.Iwcf_EmpresaClient serviceWeb;

        HLP.Wcf.Entries.wcf_CamposBaseDados serviceCamposBaseDadosNetwork;
        wcf_CamposBaseDados.Iwcf_CamposBaseDadosClient serviceCamposBaseDadosWeb;

        public EmpresaService()
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        serviceNetwork = new HLP.Wcf.Entries.wcf_Empresa();
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
                        serviceWeb = new wcf_Empresa.Iwcf_EmpresaClient();
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

        public EmpresaModel GetObject(int id)
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

        public EmpresaModel SaveObject(EmpresaModel obj)
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

        public EmpresaModel CopyObject(EmpresaModel obj)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.serviceNetwork.CopyObject(obj: obj);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.serviceWeb.CopyObject(obj: obj);
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