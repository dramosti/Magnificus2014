using HLP.Base.Static;
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
                case StConnection.OnlineNetwork:
                    {
                        this.servicoRede = new Wcf.Entries.wcf_FamiliaProduto();
                    }
                    break;
                case StConnection.OnlineWeb:
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
    }
}
