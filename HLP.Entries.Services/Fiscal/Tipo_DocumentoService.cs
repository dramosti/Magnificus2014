using HLP.Base.ClassesBases;
using HLP.Base.Static;
using HLP.Entries.Model.Fiscal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Services.Fiscal
{

    public class Tipo_DocumentoService
    {
        const string xTabela = "Tipo_documento;";

        HLP.Wcf.Entries.wcf_TipoDocumento serviceNetwork;
        wcf_TipoDocumento.Iwcf_TipoDocumentoClient serviceWeb;

        HLP.Wcf.Entries.wcf_CamposBaseDados serviceCamposBaseDadosNetwork;
        wcf_CamposBaseDados.Iwcf_CamposBaseDadosClient serviceCamposBaseDadosWeb;

        public Tipo_DocumentoService()
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        serviceNetwork = new HLP.Wcf.Entries.wcf_TipoDocumento();
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
                        serviceWeb = new wcf_TipoDocumento.Iwcf_TipoDocumentoClient();
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

        public Tipo_documentoModel GetObject(int id, bool loadOptionalParameters = false)
        {
            Tipo_documentoModel objTipoDocumento = null;

            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        objTipoDocumento = this.serviceNetwork.GetObject(id: id);
                    } break;
                case StConnection.OnlineWeb:
                    {
                        objTipoDocumento = this.serviceWeb.GetObject(id: id);
                    } break;
                case StConnection.Offline:
                default:
                    {
                        return null;
                    }
            }

            if (loadOptionalParameters)
            {
                this.SetTipoOperacao(objTipoDocumento: objTipoDocumento);
            }

            return objTipoDocumento;
        }

        private void SetTipoOperacao(Tipo_documentoModel objTipoDocumento)
        {
            Tipo_OperacaoService objTipoOperacaoService = new Tipo_OperacaoService();
            if (objTipoDocumento != null)
                if (objTipoDocumento.lTipo_documento_oper_validaModel.Count > 0)
                    foreach (Tipo_documento_oper_validaModel item in objTipoDocumento.lTipo_documento_oper_validaModel)
                    {
                        item.objTipoOperacao = objTipoOperacaoService.GetObject(id: item.idTipoOperacao);
                    }
        }

        public Tipo_documentoModel SaveObject(Tipo_documentoModel obj)
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

        public Tipo_documentoModel CopyObject(Tipo_documentoModel obj)
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
