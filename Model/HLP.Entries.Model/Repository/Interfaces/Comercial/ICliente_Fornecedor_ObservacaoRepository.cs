using HLP.Entries.Model.Models.Comercial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.Comercial
{
    public interface ICliente_Fornecedor_ObservacaoRepository
    {
        void Save(Cliente_Fornecedor_ObservacaoModel objCliente_Fornecedor_Observacao);
        void Delete(int idClienteFornecedorObservacao);
        void DeletePorClienteFornecedor(int idClienteFornecedor);
        void Copy(Cliente_Fornecedor_ObservacaoModel objCliente_Fornecedor_Observacao);
        Cliente_Fornecedor_ObservacaoModel GetCliente_Fornecedor_Observacao(int idClienteFornecedorObservacao);
        List<Cliente_Fornecedor_ObservacaoModel> GetAllCliente_Fornecedor_Observacao(int idClienteFornecedor);
    }
}
