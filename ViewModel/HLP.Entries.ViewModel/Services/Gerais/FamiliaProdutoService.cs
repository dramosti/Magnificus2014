using HLP.Comum.Infrastructure.Static;
using HLP.Entries.Model.Models.Gerais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.ViewModel.Services.Gerais
{
    public class FamiliaProdutoService
    {
        HLP.Wcf.Entries.wcf_FamiliaProduto servicoRede;
        wcf_FamiliaProduto.Iwcf_FamiliaProdutoClient servicoInternet;

        public FamiliaProdutoService()
        {
            switch (Sistema.bOnline)
            {
                case TipoConexao.OnlineRede:
                    {
                        this.servicoRede = new Wcf.Entries.wcf_FamiliaProduto();
                    }
                    break;
                case TipoConexao.OnlineInternet:
                    {
                        this.servicoInternet = new wcf_FamiliaProduto.Iwcf_FamiliaProdutoClient();
                    }
                    break;
            }
        }

        public Familia_produtoModel Save(Familia_produtoModel objModel)
        {
            switch (Sistema.bOnline)
            {
                case TipoConexao.OnlineRede:
                    {
                        return this.servicoRede.Save(familia_produto: objModel);
                    }
                case TipoConexao.OnlineInternet:
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
                case TipoConexao.OnlineRede:
                    {
                        return this.servicoRede.Delete(idFamiliaProduto: objModel.idFamiliaProduto ?? 0);
                    }
                case TipoConexao.OnlineInternet:
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
                case TipoConexao.OnlineRede:
                    {
                        return this.servicoRede.Copy(familia_produto: objModel);
                    }
                case TipoConexao.OnlineInternet:
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
                case TipoConexao.OnlineRede:
                    {
                        return this.servicoRede.GetObject(idFamiliaProduto: id);
                    }
                case TipoConexao.OnlineInternet:
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
                case TipoConexao.OnlineRede:
                    {
                        return this.servicoRede.GetAll();
                    }
                case TipoConexao.OnlineInternet:
                    {
                        return this.servicoInternet.GetAll();
                    }
            }
            return null;
        }
    }
}
