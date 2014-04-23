using HLP.Components.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Components.Model.Repository.Interfaces
{
    public interface IContato_EnderecoRepository
    {
        void Save(Contato_EnderecoModel objContato_Endereco);
        void DeleteEnderecosByContato(int idContato);
        void Delete(int idContato);
        void Copy(Contato_EnderecoModel objContato_Endereco);
        Contato_EnderecoModel GetContato_Endereco(int idEndereco);
        List<Contato_EnderecoModel> GetAllContato_Endereco(int idContato);
    }
}
