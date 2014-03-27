using HLP.Comum.Infrastructure.Static;
using HLP.Comum.Resources.Models;
using HLP.Comum.Resources.RecursosBases;
using HLP.Entries.Model.Models.Comercial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.ViewModel.Services.Comercial
{
    public class Lista_PrecoService
    {
        HLP.Wcf.Entries.wcf_Lista_Preco servicoRede;
        wcf_Lista_Preco.Iwcf_Lista_PrecoClient servicoInternet;

        public Lista_PrecoService()
        {
            switch (Sistema.bOnline)
            {
                case TipoConexao.OnlineRede:
                    {
                        this.servicoRede = new Wcf.Entries.wcf_Lista_Preco();
                    }
                    break;
                case TipoConexao.OnlineInternet:
                    {
                        this.servicoInternet = new wcf_Lista_Preco.Iwcf_Lista_PrecoClient();
                    }
                    break;
            }
        }

        public Lista_Preco_PaiModel Save(Lista_Preco_PaiModel objModel)
        {
            switch (Sistema.bOnline)
            {
                case TipoConexao.OnlineRede:
                    {
                        return this.servicoRede.saveLista_Preco(objListaPreco: objModel);
                    }
                case TipoConexao.OnlineInternet:
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
                case TipoConexao.OnlineRede:
                    {
                        return this.servicoRede.deleteLista_Preco(idListaPrecoPai: (int)objModel.idListaPrecoPai);
                    }
                case TipoConexao.OnlineInternet:
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
                case TipoConexao.OnlineRede:
                    {
                        return this.servicoRede.copyLista_Preco(objListaPreco: objModel);
                    }
                case TipoConexao.OnlineInternet:
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
                case TipoConexao.OnlineRede:
                    {
                        return this.servicoRede.getLista_Preco(idListaPrecoPai: id);
                    }
                case TipoConexao.OnlineInternet:
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
                case TipoConexao.OnlineRede:
                    {
                        return this.servicoRede.GetAllIdsListaPreco();
                    }
                case TipoConexao.OnlineInternet:
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
                case TipoConexao.OnlineRede:
                    {
                        return this.servicoRede.GetItensListaPreco(idListaPrecoPai: idListaPrecoPai);
                    }
                case TipoConexao.OnlineInternet:
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
                case TipoConexao.OnlineRede:
                    {
                        return this.servicoRede.GetIdListaPreferencial();
                    }
                case TipoConexao.OnlineInternet:
                    {
                        return this.servicoInternet.GetIdListaPreferencial();
                    }
            }
            return 0;
        }

        public List<HlpButtonHierarquiaStruct> getHierarquiaLista(int idListaPreco)
        {
            switch (Sistema.bOnline)
            {
                case TipoConexao.OnlineRede:
                    {
                        return this.servicoRede.GetLista_PrecoHierarquia(idListaPreco: idListaPreco);
                    }
                case TipoConexao.OnlineInternet:
                    {
                        return this.servicoInternet.GetLista_PrecoHierarquia(idListaPreco: idListaPreco);
                    }
            }
            return null;
        }

        public modelToTreeView GetHierarquiaListaFull(int idListaPreco)
        {
            switch (Sistema.bOnline)
            {
                case TipoConexao.OnlineRede:
                    {
                        return this.servicoRede.GetSelectedLista_PrecoFullHierarquia(idListaPreco: idListaPreco);
                    }
                case TipoConexao.OnlineInternet:
                    {
                        return this.servicoInternet.GetSelectedLista_PrecoFullHierarquia(idListaPreco: idListaPreco);
                    }
            }
            return null;
        }
    }
}
