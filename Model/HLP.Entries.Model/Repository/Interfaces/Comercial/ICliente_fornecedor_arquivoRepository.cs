using HLP.Entries.Model.Models.Comercial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.Comercial
{
    public interface ICliente_fornecedor_arquivoRepository
    {
        void Save(Cliente_fornecedor_arquivoModel objCliente_fornecedor_arquivo);
        void Update(Cliente_fornecedor_arquivoModel objCliente_fornecedor_arquivo);
        void Delete(int idClienteFornecedorArquivo);
        void DeletePorClienteFornecedor(int idClienteFornecedor);
        void Copy(Cliente_fornecedor_arquivoModel objCliente_fornecedor_arquivo);
        Cliente_fornecedor_arquivoModel GetCliente_fornecedor_arquivo(int idClienteFornecedorArquivo);
        List<Cliente_fornecedor_arquivoModel> GetAllCliente_fornecedor_arquivo(int idClienteFornecedor);
    }
}
