using HLP.Entries.Model.Models.Comercial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.Comercial
{
    public interface ICliente_fornecedor_EnderecoRepository
    {
        void Save(Cliente_fornecedor_EnderecoModel objCliente_Fornecedor_Endereco);
        void Delete(int idEndereco_Cliente_Fornecedor);
        void DeletePorClienteFornecedor(int idClienteFornecedor);
        void Copy(Cliente_fornecedor_EnderecoModel objCliente_Fornecedor_Endereco);
        Cliente_fornecedor_EnderecoModel GetCliente_Fornecedor_Endereco(int idEndereco);
        List<Cliente_fornecedor_EnderecoModel> GetAllCliente_Fornecedor_Endereco(int idClienteFornecedor);
    }
}
