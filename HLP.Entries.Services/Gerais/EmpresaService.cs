using HLP.Base.ClassesBases;
using HLP.Base.Static;
using HLP.Components.Model.Models;
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
        const string xTabela = "Empresa;Enderecos";

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
                        serviceWeb = new wcf_Empresa.Iwcf_EmpresaClient();
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

        public EmpresaModel GetObject(int id, bool loadOptionalParameters = false)
        {
            EmpresaModel objEmpresa = null;
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        objEmpresa = this.serviceNetwork.GetObject(id: id);
                    } break;
                case StConnection.OnlineWeb:
                    {
                        objEmpresa = this.serviceWeb.GetObject(id: id);
                    } break;
                case StConnection.Offline:
                default:
                    {
                        return null;
                    }
            }

            if (loadOptionalParameters)
            {
                this.SetObjCidades(objEmpresa: ref objEmpresa);
            }

            return objEmpresa;


        }

        private void SetObjCidades(ref EmpresaModel objEmpresa)
        {
            CidadeService objCidadeService = new CidadeService();

            if (objEmpresa.lEmpresa_endereco.Count > 0)
                foreach (EnderecoModel item in objEmpresa.lEmpresa_endereco)
                {
                    item.objCidade = objCidadeService.GetObject(id: item.idCidade);
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

        public enum ExecuteOptionalSearchs
        {
            _default,
            cidade
        }
    }


}
