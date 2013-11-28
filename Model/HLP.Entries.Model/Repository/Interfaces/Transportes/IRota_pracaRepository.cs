using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Entries.Model.Models.Transportes;

namespace HLP.Entries.Model.Repository.Interfaces.Transportes
{
    public interface IRotaRepository
    {
        void Save(RotaModel objRota);
        void Delete(int idRota);
        void Copy(RotaModel objRota);
        RotaModel GetRota(int idRota);

        void BeginTransaction();
        void CommitTransaction();
        void RollackTransaction();
    }
    public interface IRota_pracaRepository
    {
        void Save(Rota_pracaModel objRota_Praca);
        void Update(Rota_pracaModel objRota_Praca);
        void Delete(Rota_pracaModel objRota_Praca);
        void Delete(int idRota);
        void Copy(Rota_pracaModel objRota_Praca);
        Rota_pracaModel GetRota_Praca(int idRotaPraca);
        List<Rota_pracaModel> GetAllRota_Praca(int idRota);
    }
}
