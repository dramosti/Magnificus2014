using HLP.Entries.Model.Models.RecursosHumanos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.RecursosHumanos
{
    public interface ICargoRepository
    {
        CargoModel GetCargo(int idCargo);
        void Save(CargoModel cargo);
        void Delete(int idCargo);
        int Copy(int idCargo);
    }
}
