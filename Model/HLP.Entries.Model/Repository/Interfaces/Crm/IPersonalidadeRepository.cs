using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Entries.Model.Models.Crm;

namespace HLP.Entries.Model.Repository.Interfaces.Crm
{
    public interface IPersonalidadeRepository
    {
        PersonalidadeModel GetPersonalidade(int idPersonalidade);
        void Save(PersonalidadeModel personalidade);
        void Delete(int idPersonalidade);
        int Copy(int idPersonalidade);
    }
}
