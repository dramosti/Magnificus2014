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
    public class FamiliaProdutoService
    {
        const string xTabela = "Familia_produto;Familia_Produto_Classes";

        HLP.Wcf.Entries.wcf_FamiliaProduto servicoRede;
        wcf_FamiliaProduto.Iwcf_FamiliaProdutoClient servicoInternet;

        HLP.Wcf.Entries.wcf_CamposBaseDados serviceCamposBaseDadosNetwork;
        wcf_CamposBaseDados.Iwcf_CamposBaseDadosClient serviceCamposBaseDadosWeb;

        public FamiliaProdutoService()
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        this.servicoRede = new Wcf.Entries.wcf_FamiliaProduto();
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
                        this.servicoInternet = new wcf_FamiliaProduto.Iwcf_FamiliaProdutoClient();
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
            }
        }

        public Familia_produtoModel Save(Familia_produtoModel objModel)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.servicoRede.Save(familia_produto: objModel);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.servicoInternet.Save(familia_produto: objModel);
                    }
            }
            return null;
        }

        public bool Delete(Familia_produtoModel objModel)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.servicoRede.Delete(idFamiliaProduto: objModel.idFamiliaProduto ?? 0);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.servicoInternet.Delete(idFamiliaProduto: objModel.idFamiliaProduto ?? 0);
                    }
            }
            return false;
        }

        public Familia_produtoModel Copy(Familia_produtoModel objModel)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.servicoRede.Copy(familia_produto: objModel);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.servicoInternet.Copy(familia_produto: objModel);
                    }
            }
            return null;
        }

        public Familia_produtoModel GetObjeto(int id)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.servicoRede.GetObject(idFamiliaProduto: id);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.servicoInternet.GetObject(idFamiliaProduto: id);
                    }
            }
            return null;
        }

        public List<Familia_produtoModel> GetAll()
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.servicoRede.GetAll();
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.servicoInternet.GetAll();
                    }
            }
            return null;
        }

        public List<modelToTreeView> GetHierarquia(string xMask, string xCodAlt)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.servicoRede.GetHierarquia(xMask: xMask, xCodAlt: xCodAlt);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.servicoInternet.GetHierarquia(xMask: xMask, xCodAlt: xCodAlt);
                    }
                default:
                    {
                        return null;
                    }
            }
        }
    }
}
