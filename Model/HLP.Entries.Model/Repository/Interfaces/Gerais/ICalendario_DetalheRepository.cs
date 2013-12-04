using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Entries.Model.Models.Gerais;

namespace HLP.Entries.Model.Repository.Interfaces.Gerais
{
    public interface ICalendario_DetalheRepository
    {
        void Save(Calendario_DetalheModel objCalendario_Detalhe);
        void Delete(Calendario_DetalheModel objCalendario_Detalhe);
        void DeleteDetalhesByCalendario(int idCalendario);
        void Copy(Calendario_DetalheModel objCalendario_Detalhe);
        Calendario_DetalheModel GetCalendario_Detalhe(int idCalendarioDetalhe);
        List<Calendario_DetalheModel> GetAllCalendario_Detalhe(int idCalendario);
    }
}
