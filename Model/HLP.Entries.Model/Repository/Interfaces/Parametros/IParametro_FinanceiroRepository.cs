using HLP.Entries.Model.Models.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Interfaces.Parametros
{
    public interface IParametro_FinanceiroRepository
    {
        void Save(Parametro_FinanceiroModel objParametro_Financeiro);
        void Delete(int idParametroFinanceiro);
        int Copy(int idParametroFinanceiro);
        Parametro_FinanceiroModel GetParametro_Financeiro(int idEmpresa);
        List<Parametro_FinanceiroModel> GetAllParametro_Financeiro();
        bool GetCreditoAprovado();
    }
}
