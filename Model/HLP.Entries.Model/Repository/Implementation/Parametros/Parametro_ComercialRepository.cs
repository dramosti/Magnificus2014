using HLP.Base.ClassesBases;
using HLP.Base.Static;
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
    public class Parametro_ComercialRepository : IParametro_ComercialRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Parametro_ComercialModel> regParametro_ComercialAccessor;
        private DataAccessor<Parametro_ComercialModel> regAllParametro_ComercialAccessor;

        public void Save(Parametro_ComercialModel objParametro_Comercial)
        {
            if (objParametro_Comercial.idParametroComercial == null)
            {
                objParametro_Comercial.idParametroComercial = (int)UndTrabalho.dbPrincipal.ExecuteScalar("dbo.Proc_save_Parametro_Comercial",
                ParameterBase<Parametro_ComercialModel>.SetParameterValue(objParametro_Comercial));
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar("[dbo].[Proc_update_Parametro_Comercial]",
                ParameterBase<Parametro_ComercialModel>.SetParameterValue(objParametro_Comercial));
            }
        }

        public void Delete(int idParametroComercial)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar("dbo.Proc_delete_Parametro_Comercial",
                 UserData.idUser,
                 idParametroComercial);
        }

        public int Copy(int idParametroComercial)
        {
            return (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                      "dbo.Proc_copy_Parametro_Comercial",
                       idParametroComercial);
        }

        public Parametro_ComercialModel GetParametro_Comercial(int idEmpresa)
        {
            if (regParametro_ComercialAccessor == null)
            {
                regParametro_ComercialAccessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor("SELECT * FROM Parametro_Comercial" +
                " where idEmpresa = " + idEmpresa,
                                MapBuilder<Parametro_ComercialModel>.MapAllProperties().DoNotMap(i => i.status).Build());
            }
            return regParametro_ComercialAccessor.Execute().FirstOrDefault();
        }

        public List<Parametro_ComercialModel> GetAllParametro_Comercial()
        {
            if (regAllParametro_ComercialAccessor == null)
            {
                regAllParametro_ComercialAccessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor("SELECT * FROM Parametro_Comercial",
                                MapBuilder<Parametro_ComercialModel>.MapAllProperties().DoNotMap(i => i.status).Build());
            }
            return regAllParametro_ComercialAccessor.Execute().ToList();
        }
    }

}
