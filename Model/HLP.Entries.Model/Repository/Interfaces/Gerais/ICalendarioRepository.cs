using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Entries.Model.Models.Gerais;

namespace HLP.Entries.Model.Repository.Interfaces.Gerais
{
    public interface ICalendarioRepository
    {
        void Save(CalendarioModel objCalendario);
        void Delete(CalendarioModel objCalendario);
        void Copy(CalendarioModel objCalendario);
        CalendarioModel GetCalendario(int idCalendario);
        List<CalendarioModel> GetCalendarios(int idEmpresa);

        void BeginTransaction();
        void CommitTransaction();
        void RollackTransaction();
    }
}
