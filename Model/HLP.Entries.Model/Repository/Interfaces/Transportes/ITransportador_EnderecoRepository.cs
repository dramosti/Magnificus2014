using HLP.Entries.Model.Models.Transportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.Transportes
{
    public interface ITransportador_EnderecoRepository
    {
        void Save(Transportador_EnderecoModel objTransportador_Endereco);
        void Delete(int idTransportadorEndereco);
        void DeletePorTransportador(int idTransportador);
        void Copy(Transportador_EnderecoModel objTransportador_Endereco);
        Transportador_EnderecoModel GetTransportador_Endereco(int idEndereco);
        List<Transportador_EnderecoModel> GetAllTransportador_Endereco(int idTransportador);
    }
}
