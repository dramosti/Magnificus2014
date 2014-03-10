using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Entries.Model.Models.Gerais;

namespace HLP.Entries.Model.Repository.Interfaces.Gerais
{
    public interface IFamilia_ProdutoRepository
    {
        Familia_produtoModel GetFamilia_produto(int idFamiliaProduto);
        void Save(Familia_produtoModel familia_produto);
        void Delete(int idFamiliaProduto);
        int Copy(Familia_produtoModel familia_produto);
        List<Familia_produtoModel> GetAll();

        void BeginTransaction();
        void CommitTransaction();
        void RollackTransaction();
    }
}
