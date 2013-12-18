using HLP.Entries.Model.Models.Transportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.Transportes
{
    public interface ITransportador_ContatoRepository
    {
        void Save(Transportador_ContatoModel objTransportador_Contato);
        void Delete(int idTransportadorContato);
        void DeletePorTransportador(int idTransportador);
        void Copy(Transportador_ContatoModel objTransportador_Contato);
        Transportador_ContatoModel GetTransportador_Contato(int idTransportdorContato);
        List<Transportador_ContatoModel> GetAllTransportador_Contato(int idTransportador);
    }
}
