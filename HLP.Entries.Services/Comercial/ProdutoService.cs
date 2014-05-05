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
    public class ProdutoService
    {
        const string xTabela = "Produto;Produto_composicao;Produto_custo_medio;Produto_Fornecedor_Homologado;Produto_Localizacao;Produto_ref_custo;Produto_Revisao;";

        HLP.Wcf.Entries.wcf_Produto servicoRede;
        wcf_Produto.Iwcf_ProdutoClient servicoInternet;

        HLP.Wcf.Entries.wcf_CamposBaseDados serviceCamposBaseDadosNetwork;
        wcf_CamposBaseDados.Iwcf_CamposBaseDadosClient serviceCamposBaseDadosWeb;

        public ProdutoService()
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        servicoRede = new Wcf.Entries.wcf_Produto();
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
                        servicoInternet = new wcf_Produto.Iwcf_ProdutoClient();
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

        public ProdutoModel Save(ProdutoModel objModel)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.servicoRede.Save(objProduto: objModel);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.servicoInternet.Save(objProduto: objModel);
                    }
            }
            return null;
        }

        public bool Delete(ProdutoModel objModel)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.servicoRede.Delete(idProduto: objModel.idProduto ?? 0);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.servicoInternet.Delete(idProduto: objModel.idProduto ?? 0);
                    }
            }
            return false;
        }

        public ProdutoModel Copy(ProdutoModel objModel)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.servicoRede.Copy(objProduto: objModel);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.servicoInternet.Copy(objProduto: objModel);
                    }
            }
            return null;
        }

        public ProdutoModel GetObjeto(int id)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.servicoRede.GetObjeto(idProduto: id);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.servicoInternet.GetObjeto(idProduto: id);
                    }
            }
            return null;
        }

        public List<ProdutoModel> GetAll()
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.servicoRede.getAll();
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.servicoInternet.getAll();
                    }
            }
            return null;
        }

        public bool PrecoCustoManual(int idProduto)
        {
            try
            {
                switch (Sistema.bOnline)
                {
                    case StConnection.OnlineNetwork:
                        {
                            return this.servicoRede.PrecoCustoManual(idProduto: idProduto);
                        }

                    case StConnection.OnlineWeb:
                        {
                            return this.servicoInternet.PrecoCustoManual(idProduto: idProduto);
                        }
                }

                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public decimal GetPrecoCustoProduto(int idProduto)
        {
            try
            {
                switch (Sistema.bOnline)
                {
                    case StConnection.OnlineNetwork:
                        {
                            return this.servicoRede.GetValorCompraProduto(idProduto: idProduto);
                        }

                    case StConnection.OnlineWeb:
                        {
                            return this.servicoInternet.GetValorCompraProduto(idProduto: idProduto);
                        }
                }
                return decimal.Zero;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
