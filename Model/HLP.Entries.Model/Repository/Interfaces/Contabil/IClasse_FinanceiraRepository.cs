using HLP.Entries.Model.Models.Contabil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.Contabil
{
   public interface IClasse_FinanceiraRepository
    {
        int Save(Classe_FinanceiraModel objClasse_Financeira);

        bool Delete(int idClasseFinanceira);

        Classe_FinanceiraModel Copy(int idClasseFinanceira);

        Classe_FinanceiraModel GetClasse_Financeira(int idClasseFinanceira);

        List<Classe_FinanceiraModel> GetAllClasse_Financeira();
    }
}
