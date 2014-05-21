using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.Model.Repository.Interfaces.Gerais;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;
using HLP.Base.ClassesBases;
using HLP.Base.Static;

namespace HLP.Entries.Model.Repository.Implementation.Gerais
{
    public class CalendarioRepository : ICalendarioRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<CalendarioModel> regCalendarioAccessor;

        private DataAccessor<CalendarioModel> reglCalendarioAccessor;


        public void Save(CalendarioModel objCalendario)
        {
            if (objCalendario.idCalendario == null)
            {
                objCalendario.idCalendario = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                    UndTrabalho.dbTransaction,
                "[dbo].[Proc_save_Calendario]",
                ParameterBase<CalendarioModel>.SetParameterValue(objCalendario));
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar(
                    UndTrabalho.dbTransaction,
                "[dbo].[Proc_update_Calendario]",
                ParameterBase<CalendarioModel>.SetParameterValue(objCalendario));
            }
        }

        public void Delete(CalendarioModel objCalendario, int idUser)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar(
            UndTrabalho.dbTransaction,
           "[dbo].[Proc_delete_Calendario]",
            idUser,
            objCalendario.idCalendario);
        }

        public void Copy(CalendarioModel objCalendario)
        {
            objCalendario.idCalendario = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
            UndTrabalho.dbTransaction,
           "dbo.Proc_copy_Calendario",
            objCalendario.idCalendario);
        }

        public CalendarioModel GetCalendario(int idCalendario)
        {

            if (regCalendarioAccessor == null)
            {
                regCalendarioAccessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("dbo.Proc_sel_Calendario",
                                         new Parameters(UndTrabalho.dbPrincipal)
                                         .AddParameter<int>("idCalendario"),
                                         MapBuilder<CalendarioModel>.MapAllProperties().DoNotMap(c => c.status).Build());
            }

            return regCalendarioAccessor.Execute(idCalendario).FirstOrDefault();
        }

        public List<CalendarioModel> GetCalendarios(int idEmpresa)
        {
            if (reglCalendarioAccessor == null)
            {
                reglCalendarioAccessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor("SELECT * FROM Calendario WHERE idEmpresa= @idEmpresa",
                                  new Parameters(UndTrabalho.dbPrincipal)
                                    .AddParameter<int>("idEmpresa"),
                                  MapBuilder<CalendarioModel>.MapAllProperties().DoNotMap(c => c.status).Build());
            }


            return reglCalendarioAccessor.Execute(idEmpresa).ToList();
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
