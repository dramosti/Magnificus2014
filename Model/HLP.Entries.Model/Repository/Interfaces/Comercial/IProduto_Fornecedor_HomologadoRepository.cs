using HLP.Entries.Model.Models.Comercial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.Comercial
{
    public interface IProduto_Fornecedor_HomologadoRepository
    {
        void Save(Produto_Fornecedor_HomologadoModel produtoFornHom);

        void Delete(int idProdutoFornecedorHomologado);

        void DeletePorProduto(int idProduto);

        void Copy(Produto_Fornecedor_HomologadoModel produtoFornHom);

        Produto_Fornecedor_HomologadoModel GetProdForncHom(int idProdutoFornecedorHomologado);

        List<Produto_Fornecedor_HomologadoModel> GetAllProdForncHom(int idProduto);
    }
}
