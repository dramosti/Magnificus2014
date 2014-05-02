using HLP.Base.ClassesBases;
using HLP.Base.Static;
using HLP.Entries.Model.Models.Transportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Services.Transportes
{
    public class RotaService
    {
        const string xTabela = "Rota;Rota_Praca";
        HLP.Wcf.Entries.wcf_CamposBaseDados serviceCamposBaseDadosNetwork;
        wcf_CamposBaseDados.Iwcf_CamposBaseDadosClient serviceCamposBaseDadosWeb;
        HLP.Wcf.Entries.wcf_Rota servicoRede;
        wcf_Rota.Iwcf_RotaClient servicoInternet;
        public RotaService()
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        servicoRede = new Wcf.Entries.wcf_Rota();
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
                        servicoInternet = new wcf_Rota.Iwcf_RotaClient();
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

        public RotaModel Save(RotaModel objModel)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.servicoRede.Save(objRota: objModel);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.servicoInternet.Save(objRota: objModel);
                    }
                case StConnection.Offline:
                default:
                    {
                        return null;
                    }
            }
        }

        public bool Delete(RotaModel objModel)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.servicoRede.Delete(idRota: objModel.idRota ?? 0);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.servicoInternet.Delete(idRota: objModel.idRota ?? 0);
                    }
                case StConnection.Offline:
                default:
                    {
                        return false;
                    }
            }
        }

        public RotaModel Copy(RotaModel objModel)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.servicoRede.Copy(objRota: objModel);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.servicoInternet.Copy(objRota: objModel);
                    }
                case StConnection.Offline:
                default:
                    {
                        return null;
                    }
            }
        }

        public RotaModel GetObjeto(int id)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.servicoRede.GetObject(idRota: id);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.servicoInternet.GetObject(idRota: id);
                    }
                case StConnection.Offline:
                default:
                    {
                        return null;
                    }
            }
        }

        public bool PossuiListaPreco(int id)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.servicoRede.PossuiListaPreco(idRota: id);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.servicoInternet.PossuiListaPreco(idRota: id);
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
