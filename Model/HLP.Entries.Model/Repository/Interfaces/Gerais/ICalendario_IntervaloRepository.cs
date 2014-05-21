using HLP.Entries.Model.Models.Gerais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.Gerais
{
    public interface ICalendario_IntervaloRepository
    {
         void Save(Calendario_IntervalosModel objCalendario_IntervalosModel);
         void Delete(Calendario_IntervalosModel objCalendario, int idUser);
         List<Calendario_IntervalosModel> GetIntervalos(int idCalendario);
         void DeleteIntervalosByCalendario(int idCalendario);

    }
}
