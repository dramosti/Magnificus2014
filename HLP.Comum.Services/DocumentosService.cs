using HLP.Base.ClassesBases;
using HLP.Base.Static;
using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Comum.Services
{

    public class DocumentosService
    {
        const string xTabela = "Documentos;";

        HLP.Wcf.Entries.wcf_Documentos serviceNetwork;
        wcf_Documentos.Iwcf_DocumentosClient serviceWeb;

        HLP.Wcf.Entries.wcf_CamposBaseDados serviceCamposBaseDadosNetwork;
        wcf_CamposBaseDados.Iwcf_CamposBaseDadosClient serviceCamposBaseDadosWeb;

        public DocumentosService()
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        serviceNetwork = new HLP.Wcf.Entries.wcf_Documentos();
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
                        serviceWeb = new wcf_Documentos.Iwcf_DocumentosClient();
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

        public List<DocumentosModel> GetObject(string xNameTabela, int idPk)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.serviceNetwork.GetListObject(xTabela: xNameTabela, idPk: idPk);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.serviceWeb.GetListObject(xTabela: xNameTabela, idPk: idPk);
                    }
                case StConnection.Offline:
                default:
                    {
                        return null;
                    }
            }
        }

        public List<DocumentosModel> SaveObject(List<DocumentosModel> obj, string xNameTabela, int idPk)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.serviceNetwork.SaveObject(lDocumentos: obj, xNameTabela: xNameTabela, idPk: idPk);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.serviceWeb.SaveObject(lDocumentos: obj);
                    }
                case StConnection.Offline:
                default:
                    {
                        return new List<DocumentosModel>();
                    }
            }
        }

        public bool DeleteObject(string xNameTabela, int idPk)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.serviceNetwork.DeleteObject(xNameTabela: xNameTabela, idPk: idPk);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.serviceWeb.DeleteObject(xNameTabela: xNameTabela, idPk: idPk);
                    }
                case StConnection.Offline:
                default:
                    {
                        return false;
                    }
            }
        }

        public List<DocumentosModel> CopyObject(List<DocumentosModel> lDocumentos)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.serviceNetwork.CopyObject(lDocumentos: lDocumentos);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.serviceWeb.CopyObject(lDocumentos: lDocumentos);
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
