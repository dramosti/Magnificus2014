using HLP.Entries.Model.Models.Comercial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.Comercial
{
    public interface ICliente_fornecedor_contatoRepository
    {
        void Save(Cliente_fornecedor_contatoModel objCliente_fornecedor_contato);
        void Update(Cliente_fornecedor_contatoModel objCliente_fornecedor_contato);
        void Delete(int idClienteFornecedorContato);
        void DeletePorClienteFornecedor(int idClienteFornecedor);
        void Copy(Cliente_fornecedor_contatoModel objCliente_fornecedor_contato);
        Cliente_fornecedor_contatoModel GetCliente_fornecedor_contato(int idClienteFornecedorContato);
        List<Cliente_fornecedor_contatoModel> GetAllCliente_fornecedor_contato(int idClienteFornecedor);
    }
}
