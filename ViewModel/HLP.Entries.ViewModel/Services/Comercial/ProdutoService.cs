using HLP.Comum.Infrastructure.Static;
using HLP.Entries.Model.Models.Comercial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.ViewModel.Services.Comercial
{
    public class ProdutoService
    {
        HLP.Wcf.Entries.wcf_Produto servicoRede;
        wcf_Produto.Iwcf_ProdutoClient servicoInternet;

        public ProdutoService()
        {
            switch (Sistema.bOnline)
            {
                case TipoConexao.OnlineRede:
                    {
                        this.servicoRede = new Wcf.Entries.wcf_Produto();
                    }
                    break;
                case TipoConexao.OnlineInternet:
                    {
                        this.servicoInternet = new wcf_Produto.Iwcf_ProdutoClient();
                    }
                    break;
            }
        }

        public ProdutoModel Save(ProdutoModel objModel)
        {
            switch (Sistema.bOnline)
            {
                case TipoConexao.OnlineRede:
                    {
                        return this.servicoRede.Save(objProduto: objModel);
                    }
                case TipoConexao.OnlineInternet:
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
                case TipoConexao.OnlineRede:
                    {
                        return this.servicoRede.Delete(idProduto: objModel.idProduto ?? 0);
                    }
                case TipoConexao.OnlineInternet:
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
                case TipoConexao.OnlineRede:
                    {
                        return this.servicoRede.Copy(objProduto: objModel);
                    }
                case TipoConexao.OnlineInternet:
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
                case TipoConexao.OnlineRede:
                    {
                        return this.servicoRede.GetObjeto(idProduto: id);
                    }
                case TipoConexao.OnlineInternet:
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
                case TipoConexao.OnlineRede:
                    {
                        return this.servicoRede.getAll();
                    }
                case TipoConexao.OnlineInternet:
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
                    case TipoConexao.OnlineRede:
                        {
                            return this.servicoRede.PrecoCustoManual(idProduto: idProduto);
                        }

                    case TipoConexao.OnlineInternet:
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
                    case TipoConexao.OnlineRede:
                        {
                            return this.servicoRede.GetValorCompraProduto(idProduto: idProduto);
                        }

                    case TipoConexao.OnlineInternet:
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
