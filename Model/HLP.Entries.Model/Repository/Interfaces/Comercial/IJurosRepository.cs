using HLP.Entries.Model.Models.Comercial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.Comercial
{
    public interface IJurosRepository
    {
        JurosModel GetJuros(int idJuros);
        void Save(JurosModel juros);
        void Delete(int idJuros);
        int Copy(int idJuros);
    }
}
