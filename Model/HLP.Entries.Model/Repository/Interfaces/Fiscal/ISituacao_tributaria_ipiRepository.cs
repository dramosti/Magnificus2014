using HLP.Entries.Model.Models.Fiscal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.Fiscal
{
    public interface ISituacao_tributaria_ipiRepository
    {
        Situacao_tributaria_ipiModel GetStIpi(int idCSTIpi);
        void Save(Situacao_tributaria_ipiModel ipi);
        void Delete(int idCSTIpi);
        int Copy(int idCSTIpi);
    }
}
