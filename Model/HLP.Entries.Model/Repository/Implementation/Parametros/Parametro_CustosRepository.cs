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
    public class Parametro_CustosRepository : IParametro_CustosRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Parametro_CustosModel> regParametro_CustosAccessor;
        private DataAccessor<Parametro_CustosModel> regAllParametro_CustosAccessor;

        public void Save(Parametro_CustosModel objParametro_Custos)
        {
            if (objParametro_Custos.idParametroCustos == null)
            {
                objParametro_Custos.idParametroCustos = (int)UndTrabalho.dbPrincipal.ExecuteScalar("dbo.Proc_save_Parametro_Custos",
                ParameterBase<Parametro_CustosModel>.SetParameterValue(objParametro_Custos));
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar("[dbo].[Proc_update_Parametro_Custos]",
                ParameterBase<Parametro_CustosModel>.SetParameterValue(objParametro_Custos));
            }
        }

        public void Delete(int idParametroCustos)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar("dbo.Proc_delete_Parametro_Custos",
                 UserData.idUser,
                 idParametroCustos);
        }

        public int Copy(int idParametroCustos)
        {
            return (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                      "dbo.Proc_copy_Parametro_Custos",
                       idParametroCustos);
        }

        public Parametro_CustosModel GetParametro_Custos(int idEmpresa)
        {
            if (regParametro_CustosAccessor == null)
            {
                regParametro_CustosAccessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor("SELECT * FROM Parametro_Custos" +
                " where idEmpresa = " + idEmpresa,
                                MapBuilder<Parametro_CustosModel>.MapAllProperties().DoNotMap(i => i.status).Build());
            }

            return regParametro_CustosAccessor.Execute().FirstOrDefault();
        }

        public List<Parametro_CustosModel> GetAllParametro_Custos()
        {
            if (regAllParametro_CustosAccessor == null)
            {
                regAllParametro_CustosAccessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor("SELECT * FROM Parametro_Custos",
                                MapBuilder<Parametro_CustosModel>.MapAllProperties().DoNotMap(i => i.status).Build());
            }
            return regAllParametro_CustosAccessor.Execute().ToList();
        }
    }
}
