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
    public class Tipo_Documento_Operacao_ValidaService
    {
        const string xTabela = "Tipo_documento_oper_valida;";

        HLP.Wcf.Entries.wcf_TipoDocumentoOperacaoValida serviceNetwork;
        wcf_TipoDocumentoOperacaoValida.Iwcf_TipoDocumentoOperacaoValidaClient serviceWeb;

        HLP.Wcf.Entries.wcf_CamposBaseDados serviceCamposBaseDadosNetwork;
        wcf_CamposBaseDados.Iwcf_CamposBaseDadosClient serviceCamposBaseDadosWeb;

        public Tipo_Documento_Operacao_ValidaService()
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        serviceNetwork = new Wcf.Entries.wcf_TipoDocumentoOperacaoValida();
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
                        serviceWeb = new wcf_TipoDocumentoOperacaoValida.Iwcf_TipoDocumentoOperacaoValidaClient();
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

        public List<Tipo_documento_oper_validaModel> GetOperacoesValidas(int idTipoDocumento)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return serviceNetwork.GetOperacoesValidas(idTipoDocumento: idTipoDocumento);
                    }
                case StConnection.OnlineWeb:
                    {
                        return serviceWeb.GetOperacoesValidas(idTipoDocumento: idTipoDocumento);
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
