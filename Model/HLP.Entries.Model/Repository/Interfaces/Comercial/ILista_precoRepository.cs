using HLP.Entries.Model.Models.Comercial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.Comercial
{
    public interface ILista_precoRepository
    {
        void Save(Lista_precoModel objLista_preco);
        void Delete(int idListaPreco);
        void DeletePorListaPrecoPai(int idListaPrecoPai);
        void Copy(Lista_precoModel objLista_preco);
        Lista_precoModel GetLista_preco(int idListaPreco);
        List<Lista_precoModel> GetAllLista_preco(int idListaPrecoPai);

        List<int> ReturnProducts(List<int> lidProduto);
    }
}
