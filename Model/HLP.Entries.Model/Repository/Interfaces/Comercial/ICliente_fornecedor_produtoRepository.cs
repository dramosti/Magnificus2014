using HLP.Entries.Model.Models.Comercial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.Comercial
{
    public interface ICliente_fornecedor_produtoRepository
    {
        void Save(Cliente_fornecedor_produtoModel objCliente_fornecedor_produto);
        void Update(Cliente_fornecedor_produtoModel objCliente_fornecedor_produto);
        void Delete(int idClienteFornecedorProduto);
        void DeletePorClienteFornecedor(int idClienteFornecedor);
        void Copy(Cliente_fornecedor_produtoModel objCliente_fornecedor_produto);
        Cliente_fornecedor_produtoModel GetCliente_fornecedor_produto(int idClienteFornecedorProduto);
        List<Cliente_fornecedor_produtoModel> GetAllCliente_fornecedor_produto(int idClienteFornecedor);
    }
}
