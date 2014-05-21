using HLP.Base.ClassesBases;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.Model.Repository.Interfaces.Gerais;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Implementation.Gerais
{
    public class Calendario_IntervaloRepository : ICalendario_IntervaloRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Calendario_IntervalosModel> reglCalendarioIntervaloAccessor;

        public void Save(Calendario_IntervalosModel objCalendario_IntervalosModel)
        {
            if (objCalendario_IntervalosModel.idCalendarioIntervalo == null)
            {
                objCalendario_IntervalosModel.idCalendario = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                    UndTrabalho.dbTransaction,
                "[dbo].[Proc_save_Calendario_Intervalos]",
                ParameterBase<Calendario_IntervalosModel>.SetParameterValue(objCalendario_IntervalosModel));
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar(
                    UndTrabalho.dbTransaction,
                "[dbo].[Proc_update_Calendario_Intervalos]",
                ParameterBase<Calendario_IntervalosModel>.SetParameterValue(objCalendario_IntervalosModel));
            }
        }

        public void Delete(Calendario_IntervalosModel objCalendario, int idUser)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar(
            UndTrabalho.dbTransaction,
           "[dbo].[Proc_delete_Calendario_Intervalos]",
            idUser,
            objCalendario.idCalendarioIntervalo);
        }

        public List<Calendario_IntervalosModel> GetIntervalos(int idCalendario)
        {
            if (reglCalendarioIntervaloAccessor == null)
            {
                reglCalendarioIntervaloAccessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor("SELECT * FROM Calendario_Intervalos WHERE idCalendario= @idCalendario",
                                  new Parameters(UndTrabalho.dbPrincipal)
                                    .AddParameter<int>("idCalendario"),
                                  MapBuilder<Calendario_IntervalosModel>.MapAllProperties().DoNotMap(c => c.status).Build());
            }
            return reglCalendarioIntervaloAccessor.Execute(idCalendario).ToList();
        }

        public void DeleteIntervalosByCalendario(int idCalendario)
        {
            UndTrabalho.dbPrincipal.ExecuteNonQuery(
                UndTrabalho.dbTransaction,
                System.Data.CommandType.Text,
              "DELETE Calendario_Intervalos WHERE idCalendario = " + idCalendario);
        }

               
    }
}
