using HLP.Comum.Infrastructure;
using HLP.Comum.Infrastructure.Static;
using HLP.Entries.Model.Models.Financeiro;
using HLP.Entries.Model.Repository.Interfaces.Financeiro;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Implementation.Financeiro
{
    public class AgenciaRepository : IAgenciaRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<AgenciaModel> regAgenciaAccessor;
        private DataAccessor<AgenciaModel> regAgenciaByBancoAccessor;

        public void Save(AgenciaModel objAgencia)
        {
            if (objAgencia.idAgencia == null)
            {
                objAgencia.idAgencia = (int)UndTrabalho.dbPrincipal.ExecuteScalar(UndTrabalho.dbTransaction,
                "[dbo].[Proc_save_Agencia]",
                ParameterBase<AgenciaModel>.SetParameterValue(objAgencia));
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar(UndTrabalho.dbTransaction,
                "[dbo].[Proc_update_Agencia]",
                ParameterBase<AgenciaModel>.SetParameterValue(objAgencia));
            }
        }

        public void Delete(int idAgencia)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar(
            UndTrabalho.dbTransaction,
           "[dbo].[Proc_delete_Agencia]",
            UserData.idUser,
            idAgencia);
        }

        public void Copy(AgenciaModel objAgencia)
        {
            objAgencia.idAgencia = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
            UndTrabalho.dbTransaction,
           "dbo.Proc_copy_Agencia",
            objAgencia.idAgencia);
        }

        public AgenciaModel GetAgencia(int idAgencia)
        {

            if (regAgenciaAccessor == null)
            {
                regAgenciaAccessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("dbo.Proc_sel_Agencia",
                                         new Parameters(UndTrabalho.dbPrincipal)
                                         .AddParameter<int>("idAgencia"),
                                         MapBuilder<AgenciaModel>.MapAllProperties()                                         
                                         .DoNotMap(i => i.status).Build());
            }

            return regAgenciaAccessor.Execute(idAgencia).FirstOrDefault();
        }

        public List<AgenciaModel> GetByBanco(int idBanco)
        {
            if (regAgenciaByBancoAccessor == null)
            {
                regAgenciaByBancoAccessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor("SELECT * FROM Agencia WHERE idBanco = @idBanco",
                                  new Parameters(UndTrabalho.dbPrincipal)
                                    .AddParameter<int>("idBanco"),
                                  MapBuilder<AgenciaModel>.MapAllProperties().DoNotMap(i => i.status).Build());
            }


            return regAgenciaByBancoAccessor.Execute(idBanco).ToList();
        }

        public void BeginTransaction()
        {
            UndTrabalho.BeginTransaction();
        }
        public void CommitTransaction()
        {
            UndTrabalho.CommitTransaction();
        }
        public void RollackTransaction()
        {
            UndTrabalho.RollBackTransaction();
        }

    }
}
