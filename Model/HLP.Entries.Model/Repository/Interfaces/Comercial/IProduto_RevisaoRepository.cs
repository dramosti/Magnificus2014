using HLP.Entries.Model.Models.Comercial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.Comercial
{
    public interface IProduto_RevisaoRepository
    {
        void Save(Produto_RevisaoModel produtoRevisao);

        void Delete(int idProdutoRevisao);

        void DeletePorProduto(int idProduto);

        void Copy(Produto_RevisaoModel produtoRevisao);

        Produto_RevisaoModel GetProdutoRevisao(int idProdutoRevisao);

        List<Produto_RevisaoModel> GetAllProdutoRevisao(int idProduto);
    }
}
