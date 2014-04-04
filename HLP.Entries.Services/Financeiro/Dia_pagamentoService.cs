using HLP.Base.ClassesBases;
using HLP.Base.Static;
using HLP.Entries.Model.Models.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Services.Financeiro
{
    public class Dia_pagamentoService
    {
        const string xTabela = "Dia_pagamento;Dia_pagamento_linhas";

        HLP.Wcf.Entries.wcf_DiaPagamento serviceNetwork;
        wcf_DiaPagamento.Iwcf_DiaPagamentoClient serviceWeb;

        HLP.Wcf.Entries.wcf_CamposBaseDados serviceCamposBaseDadosNetwork;
        wcf_CamposBaseDados.Iwcf_CamposBaseDadosClient serviceCamposBaseDadosWeb;

        public Dia_pagamentoService()
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        serviceNetwork = new HLP.Wcf.Entries.wcf_DiaPagamento();
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
                        serviceWeb = new wcf_DiaPagamento.Iwcf_DiaPagamentoClient();
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

        public Dia_pagamentoModel GetObject(int id)
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

        public Dia_pagamentoModel SaveObject(Dia_pagamentoModel obj)
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

        public Dia_pagamentoModel CopyObject(Dia_pagamentoModel obj)
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
