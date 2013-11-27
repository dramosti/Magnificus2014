using HLP.Comum.Infrastructure;
using HLP.Comum.Infrastructure.Static;
using HLP.Entries.Model.Models.Parametros;
using HLP.Entries.Model.Repository.Interfaces.Parametros;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Implementation.Parametros
{
    public class Parametro_FinanceiroRepository : IParametro_FinanceiroRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<bool> regCreditoAprovadoAcesso;
        private DataAccessor<Parametro_FinanceiroModel> regParametro_FinanceiroAccessor;
        private DataAccessor<Parametro_FinanceiroModel> regAllParametro_FinanceiroAccessor;

        public void Save(Parametro_FinanceiroModel objParametro_Financeiro)
        {
            if (objParametro_Financeiro.idParametroFinanceiro == null)
            {
                objParametro_Financeiro.idParametroFinanceiro = (int)UndTrabalho.dbPrincipal.ExecuteScalar("dbo.Proc_save_Parametro_Financeiro",
                ParameterBase<Parametro_FinanceiroModel>.SetParameterValue(objParametro_Financeiro));
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar("[dbo].[Proc_update_Parametro_Financeiro]",
                ParameterBase<Parametro_FinanceiroModel>.SetParameterValue(objParametro_Financeiro));
            }
        }

        public void Delete(int idParametroFinanceiro)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar("dbo.Proc_delete_Parametro_Financeiro",
                 UserData.idUser,
                 idParametroFinanceiro);
        }

        public int Copy(int idParametroFinanceiro)
        {
            return (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                      "dbo.Proc_copy_Parametro_Financeiro",
                       idParametroFinanceiro);
        }

        public Parametro_FinanceiroModel GetParametro_Financeiro(int idEmpresa)
        {
            if (regParametro_FinanceiroAccessor == null)
            {
                regParametro_FinanceiroAccessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor("SELECT * FROM Parametro_Financeiro" +
                " where idEmpresa = " + idEmpresa,
                                MapBuilder<Parametro_FinanceiroModel>.MapAllProperties().DoNotMap(i => i.status).Build());
            }

            return regParametro_FinanceiroAccessor.Execute().FirstOrDefault();
        }

        public List<Parametro_FinanceiroModel> GetAllParametro_Financeiro()
        {
            if (regAllParametro_FinanceiroAccessor == null)
            {
                regAllParametro_FinanceiroAccessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor("SELECT * FROM Parametro_Financeiro",
                                MapBuilder<Parametro_FinanceiroModel>.MapAllProperties().DoNotMap(i => i.status).Build());
            }
            return regAllParametro_FinanceiroAccessor.Execute().ToList();
        }

        public bool GetCreditoAprovado()
        {
            regCreditoAprovadoAcesso = UndTrabalho.dbPrincipal.CreateSqlStringAccessor("select stCreditoAprovado from Parametro_Financeiro where "
                + "idEmpresa = " + CompanyData.idEmpresa,
                                MapBuilder<bool>.MapAllProperties().Build());
            return regCreditoAprovadoAcesso.Execute().FirstOrDefault();
        }
    }
}
