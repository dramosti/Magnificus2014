using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Entries.Model.Models.Crm;

namespace HLP.Entries.Model.Repository.Interfaces.Crm
{
    public interface IFidelidadeRepository
    {
        FidelidadeModel GetFidelidade(int idFidelidade);
        void Save(FidelidadeModel fidelidade);
        void Delete(int idFidelidade);
        int Copy(int idFidelidade);
    }
}
