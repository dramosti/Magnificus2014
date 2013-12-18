using HLP.Entries.Model.Models.Transportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.Transportes
{
    public interface ITransportador_MotoristaRepository
    {
        void Save(Transportador_MotoristaModel objTransportador_Motorista);
        void Delete(int idTransportadorMotorista);
        void DeletePorTransportador(int idTransportador);
        void Copy(Transportador_MotoristaModel objTransportador_Motorista);
        Transportador_MotoristaModel GetTransportador_Motorista(int idTransportdorMotorista);
        List<Transportador_MotoristaModel> GetAllTransportador_Motorista(int idTransportador);
    }
}
