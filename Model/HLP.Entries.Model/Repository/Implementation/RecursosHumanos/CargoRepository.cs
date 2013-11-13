using HLP.Comum.Infrastructure;
using HLP.Comum.Infrastructure.Static;
using HLP.Entries.Model.Models.RecursosHumanos;
using HLP.Entries.Model.Repository.Interfaces.RecursosHumanos;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Implementation.RecursosHumanos
{
    public class CargoRepository : ICargoRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<CargoModel> regCargoAccessor;

        public CargoModel GetCargo(int idCargo)
        {
            if (regCargoAccessor == null)
            {
                regCargoAccessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("dbo.Proc_sel_cargo",
                                    new Parameters(UndTrabalho.dbPrincipal)
                                    .AddParameter<int>("idCargo"),
                                    MapBuilder<CargoModel>.MapAllProperties().DoNotMap(i => i.status).Build());
            }
            return regCargoAccessor.Execute(idCargo).FirstOrDefault();
        }

        public void Save(CargoModel cargo)
        {
            if (cargo.idCargo == null)
            {
                int idCargo = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                  "dbo.Proc_save_cargo",
                 ParameterBase<CargoModel>.SetParameterValue(cargo));

                cargo.idCargo = idCargo;
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar(
                  "[dbo].[Proc_update_Cargo]",
                 ParameterBase<CargoModel>.SetParameterValue(cargo));
            }
        }

        public void Delete(int idCargo)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar(
                       "dbo.Proc_delete_cargo",
                        UserData.idUser,
                        idCargo);
        }

        public int Copy(int idCargo)
        {
            return (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                        "dbo.Proc_copy_cargo",
                         idCargo);
        }
    }
}
