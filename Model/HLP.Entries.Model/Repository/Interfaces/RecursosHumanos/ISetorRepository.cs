using HLP.Entries.Model.Models.RecursosHumanos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.RecursosHumanos
{
    public interface ISetorRepository
    {
        SetorModel GetSetor(int idSetor);
        void Save(SetorModel setor);
        void Delete(int idSetor);
        int Copy(int idSetor);
        List<SetorModel> GetAll();
    }
}
