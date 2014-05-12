using HLP.Base.ClassesBases;
using HLP.Base.Static;
using HLP.Entries.Model.Models.Comercial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Services.Comercial
{
    public class Lista_PrecoService
    {
        const string xTabela = "Lista_preco;Lista_Preco_Pai;";
        HLP.Wcf.Entries.wcf_CamposBaseDados serviceCamposBaseDadosNetwork;
        wcf_CamposBaseDados.Iwcf_CamposBaseDadosClient serviceCamposBaseDadosWeb;

        HLP.Wcf.Entries.wcf_Lista_Preco servicoRede;
        wcf_Lista_Preco.Iwcf_Lista_PrecoClient servicoInternet;

        public Lista_PrecoService()
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        servicoRede = new Wcf.Entries.wcf_Lista_Preco();
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
                        servicoInternet = new wcf_Lista_Preco.Iwcf_Lista_PrecoClient();
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

        public Lista_Preco_PaiModel Save(Lista_Preco_PaiModel objModel)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.servicoRede.saveLista_Preco(objListaPreco: objModel);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.servicoInternet.saveLista_Preco(objListaPreco: objModel);
                    }
            }
            return null;
        }

        public bool Delete(Lista_Preco_PaiModel objModel)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.servicoRede.deleteLista_Preco(idListaPrecoPai: (int)objModel.idListaPrecoPai);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.servicoInternet.deleteLista_Preco(idListaPrecoPai: (int)objModel.idListaPrecoPai);
                    }
            }
            return false;
        }

        public Lista_Preco_PaiModel Copy(Lista_Preco_PaiModel objModel)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.servicoRede.copyLista_Preco(objListaPreco: objModel);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.servicoInternet.copyLista_Preco(objListaPreco: objModel);
                    }
            }
            return null;
        }

        public Lista_Preco_PaiModel GetObjeto(int id)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.servicoRede.getLista_Preco(idListaPrecoPai: id);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.servicoInternet.getLista_Preco(idListaPrecoPai: id);
                    }
            }
            return null;
        }

        public List<int> GetAllIdsListaPreco()
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.servicoRede.GetAllIdsListaPreco();
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.servicoInternet.GetAllIdsListaPreco();
                    }
            }
            return null;
        }

        public List<Lista_precoModel> GetItensListaPreco(int idListaPrecoPai)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.servicoRede.GetItensListaPreco(idListaPrecoPai: idListaPrecoPai);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.servicoInternet.GetItensListaPreco(idListaPrecoPai: idListaPrecoPai);
                    }
            }
            return null;
        }

        public int getIdListaPreferencial()
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.servicoRede.GetIdListaPreferencial();
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.servicoInternet.GetIdListaPreferencial();
                    }
            }
            return 0;
        }

        public List<HLP.Components.Model.Models.HlpButtonHierarquiaStruct> getHierarquiaLista(int idListaPreco)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        if (this.servicoRede != null)
                            return this.servicoRede.GetLista_PrecoHierarquia(idListaPreco: idListaPreco);
                        else
                            return null;
                    }
                case StConnection.OnlineWeb:
                    {
                        if (this.servicoInternet != null)
                            return this.servicoInternet.GetLista_PrecoHierarquia(idListaPreco: idListaPreco);
                        else return null;
                    }
            }
            return null;
        }

        public HLP.Components.Model.Models.modelToTreeView GetHierarquiaListaFull(int idListaPreco)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.servicoRede.GetSelectedLista_PrecoFullHierarquia(idListaPreco: idListaPreco);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.servicoInternet.GetSelectedLista_PrecoFullHierarquia(idListaPreco: idListaPreco);
                    }
            }
            return null;
        }
    }
}
