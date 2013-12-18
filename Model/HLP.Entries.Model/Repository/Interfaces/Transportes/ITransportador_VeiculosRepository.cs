using HLP.Entries.Model.Models.Transportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.Transportes
{
    public interface ITransportador_VeiculosRepository
    {
        void Save(Transportador_VeiculosModel objTransportador_Veiculos);
        void Delete(int idTransportadorVeiculo);
        void DeletePorTransportador(int idTransportador);
        void Copy(Transportador_VeiculosModel objTransportador_Veiculos);
        Transportador_VeiculosModel GetTransportador_Veiculos(int idTransportadorVeiculo);
        List<Transportador_VeiculosModel> GetAllTransportador_Veiculos(int idTransportador);
    }
}
