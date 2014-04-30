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
        HLP.Wcf.Entries.wcf_Produto servicoRede;
        wcf_Produto.Iwcf_ProdutoClient servicoInternet;

        public ProdutoService()
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        this.servicoRede = new Wcf.Entries.wcf_Produto();
                    }
                    break;
                case StConnection.OnlineWeb:
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
