using HLP.Base.ClassesBases;
using HLP.Base.Static;
using HLP.Entries.Model.Models.Fiscal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Services.Fiscal
{

    public class Tipo_OperacaoService
    {
        const string xTabela = "Tipo_Operacao;";

        HLP.Wcf.Entries.wcf_TipoOperacao serviceNetwork;
        wcf_TipoOperacao.Iwcf_TipoOperacaoClient serviceWeb;

        HLP.Wcf.Entries.wcf_CamposBaseDados serviceCamposBaseDadosNetwork;
        wcf_CamposBaseDados.Iwcf_CamposBaseDadosClient serviceCamposBaseDadosWeb;

        public Tipo_OperacaoService()
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        serviceNetwork = new HLP.Wcf.Entries.wcf_TipoOperacao();
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
                        serviceWeb = new wcf_TipoOperacao.Iwcf_TipoOperacaoClient();
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

        public Tipo_operacaoModel GetObject(int id)
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

        public Tipo_operacaoModel SaveObject(Tipo_operacaoModel obj)
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

        public bool DeleteObject(Tipo_operacaoModel obj)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.serviceNetwork.DeleteObject(obj: obj);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.serviceWeb.DeleteObject(obj: obj);
                    }
                case StConnection.Offline:
                default:
                    {
                        return false;
                    }
            }
        }

        public Tipo_operacaoModel CopyObject(Tipo_operacaoModel obj)
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
