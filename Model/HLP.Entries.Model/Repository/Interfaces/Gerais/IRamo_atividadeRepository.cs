using HLP.Entries.Model.Models.Gerais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.Gerais
{
    public interface IRamo_atividadeRepository
    {
        Ramo_atividadeModel GetRamo(int idRamoAtividade);
        void Save(Ramo_atividadeModel ramo);
        void Delete(int idRamoAtividade);
        int Copy(int idRamoAtividade);
    }
}
