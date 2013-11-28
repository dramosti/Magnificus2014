using HLP.Entries.Model.Models.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.Financeiro
{
    public interface IAgenciaRepository
    {
        void Save(AgenciaModel objAgencia);
        void Delete(int idAgencia);
        void Copy(AgenciaModel objAgencia);
        AgenciaModel GetAgencia(int idAgencia);
        List<AgenciaModel> GetByBanco(int idBanco);

        void BeginTransaction();
        void CommitTransaction();
        void RollackTransaction();
    }
}
