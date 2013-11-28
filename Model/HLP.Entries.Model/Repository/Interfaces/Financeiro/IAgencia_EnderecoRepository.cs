using HLP.Entries.Model.Models.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.Financeiro
{
    public interface IAgencia_EnderecoRepository
    {
        void Save(Agencia_EnderecoModel objAgencia_Endereco);
        void Delete(int idEnderecoAgencia);
        void DeletePorAgencia(int idAgencia);
        void Copy(Agencia_EnderecoModel objAgencia_Endereco);
        Agencia_EnderecoModel GetAgencia_Endereco(int idEndereco);
        List<Agencia_EnderecoModel> GetAllAgencia_Endereco(int idAgencia);
    }
}
