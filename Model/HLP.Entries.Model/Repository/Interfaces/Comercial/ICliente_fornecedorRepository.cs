using HLP.Entries.Model.Models.Comercial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.Comercial
{
    public interface ICliente_fornecedorRepository
    {
        void Save(Cliente_fornecedorModel objCliente_fornecedor);
        void Delete(int idClienteFornecedor);
        void Copy(Cliente_fornecedorModel objCliente_fornecedor);
        Cliente_fornecedorModel GetCliente_fornecedor(int idClienteFornecedor);
        Cliente_fornecedor_EnderecoModel GetCliente_fornecedor_EnderecoPrincipal(int idCliente_fornecedor);
        List<Cliente_fornecedor_representanteModel> GetCliente_fornecedor_Representante(int idCliente_fornecedor);

        void BeginTransaction();
        void CommitTransaction();
        void RollackTransaction();
    }
}
