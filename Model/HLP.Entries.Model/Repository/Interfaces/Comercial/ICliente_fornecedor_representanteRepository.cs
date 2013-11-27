using HLP.Entries.Model.Models.Comercial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.Comercial
{
    public interface ICliente_fornecedor_representanteRepository
    {
        void Save(Cliente_fornecedor_representanteModel objCliente_fornecedor_representante);
        void Update(Cliente_fornecedor_representanteModel objCliente_fornecedor_representante);
        void Delete(int idClienteFornecedorRepresentante);
        void DeletePorClienteFornecedor(int idClienteFornecedor);
        void Copy(Cliente_fornecedor_representanteModel objCliente_fornecedor_representante);
        Cliente_fornecedor_representanteModel GetCliente_fornecedor_representante(int idClienteFornecedorRepresentante);
        List<Cliente_fornecedor_representanteModel> GetAllCliente_fornecedor_representante(int idClienteFornecedor);
    }
}
