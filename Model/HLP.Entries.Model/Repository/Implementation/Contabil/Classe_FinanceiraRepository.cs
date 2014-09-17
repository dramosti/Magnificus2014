using HLP.Base.ClassesBases;
using HLP.Base.Static;
using HLP.Entries.Model.Models.Contabil;
using HLP.Entries.Model.Repository.Interfaces.Contabil;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Implementation.Contabil
{
    public class Classe_FinanceiraRepository : IClasse_FinanceiraRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Classe_FinanceiraModel> regClasse_FinanceiraAccessor;
        private DataAccessor<Classe_FinanceiraModel> regAllClasse_FinanceiraAccessor;

        public int Save(Classe_FinanceiraModel objClasse_Financeira)
        {
            objClasse_Financeira.idClasseFinanceira = (int)UndTrabalho.dbPrincipal.ExecuteScalar("dbo.Proc_save_Classe_Financeira",
            ParameterBase<Classe_FinanceiraModel>.SetParameterValue(objClasse_Financeira));

            return Convert.ToInt32(objClasse_Financeira.idClasseFinanceira);
        }

        public bool Delete(int idClasseFinanceira)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar("dbo.Proc_delete_Classe_Financeira",
                 UserData.idUser,
                 idClasseFinanceira);
            return true;
        }

        public Classe_FinanceiraModel Copy(int idClasseFinanceira)
        {
            int idRet = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                      "dbo.Proc_copy_Classe_Financeira",
                       idClasseFinanceira);

            return this.GetClasse_Financeira(idRet);
        }

        public Classe_FinanceiraModel GetClasse_Financeira(int idClasseFinanceira)
        {
            if (regClasse_FinanceiraAccessor == null)
            {
                regClasse_FinanceiraAccessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("dbo.Proc_sel_Classe_Financeira",
                                 new Parameters(UndTrabalho.dbPrincipal)
                                 .AddParameter<int>("idClasseFinanceira"),
                                 Util.GetMap<Classe_FinanceiraModel>());
                
            }

            return regClasse_FinanceiraAccessor.Execute(idClasseFinanceira).FirstOrDefault();
        }

        public List<Classe_FinanceiraModel> GetAllClasse_Financeira()
        {
            if (regAllClasse_FinanceiraAccessor == null)
            {
                regAllClasse_FinanceiraAccessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor("SELECT * FROM Classe_Financeira",
                                MapBuilder<Classe_FinanceiraModel>.MapAllProperties().Build());
            }
            return regAllClasse_FinanceiraAccessor.Execute().ToList();
        }
       
    }
}
