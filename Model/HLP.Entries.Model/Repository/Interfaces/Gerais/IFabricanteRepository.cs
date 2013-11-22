using HLP.Entries.Model.Models.Gerais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.Gerais
{
    public interface IFabricanteRepository
    {
        FabricanteModel GetFabricante(int idFabricante);
        void Save(FabricanteModel fabricante);
        void Delete(int idFabricante);
        int Copy(int idFabricante);
    }
}
