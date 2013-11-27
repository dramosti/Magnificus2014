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
    public class Parametro_Ordem_ProducaoRepository : IParametro_Ordem_ProducaoRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Parametro_Ordem_ProducaoModel> regParametro_Ordem_ProducaoAccessor;
        private DataAccessor<Parametro_Ordem_ProducaoModel> regAllParametro_Ordem_ProducaoAccessor;

        public void Save(Parametro_Ordem_ProducaoModel objParametro_Ordem_Producao)
        {
            if (objParametro_Ordem_Producao.idParametroOrdemProducao == null)
            {
                objParametro_Ordem_Producao.idParametroOrdemProducao = (int)UndTrabalho.dbPrincipal.ExecuteScalar("dbo.Proc_save_Parametro_Ordem_Producao",
                ParameterBase<Parametro_Ordem_ProducaoModel>.SetParameterValue(objParametro_Ordem_Producao));
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar("[dbo].[Proc_update_Parametro_Ordem_Producao]",
                ParameterBase<Parametro_Ordem_ProducaoModel>.SetParameterValue(objParametro_Ordem_Producao));
            }
        }

        public void Delete(int idParametroOrdemProducao)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar("dbo.Proc_delete_Parametro_Ordem_Producao",
                 UserData.idUser,
                 idParametroOrdemProducao);
        }

        public int Copy(int idParametroOrdemProducao)
        {
            return (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                      "dbo.Proc_copy_Parametro_Ordem_Producao",
                       idParametroOrdemProducao);
        }

        public Parametro_Ordem_ProducaoModel GetParametro_Ordem_Producao(int idEmpresa)
        {
            if (regParametro_Ordem_ProducaoAccessor == null)
            {
                regParametro_Ordem_ProducaoAccessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor("SELECT * FROM Parametro_Ordem_Producao" +
                " where idEmpresa = " + idEmpresa,
                                MapBuilder<Parametro_Ordem_ProducaoModel>.MapAllProperties().DoNotMap(i => i.status).Build());
            }

            return regParametro_Ordem_ProducaoAccessor.Execute().FirstOrDefault();
        }

        public List<Parametro_Ordem_ProducaoModel> GetAllParametro_Ordem_Producao()
        {
            if (regAllParametro_Ordem_ProducaoAccessor == null)
            {
                regAllParametro_Ordem_ProducaoAccessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor("SELECT * FROM Parametro_Ordem_Producao",
                                MapBuilder<Parametro_Ordem_ProducaoModel>.MapAllProperties().DoNotMap(i => i.status).Build());
            }
            return regAllParametro_Ordem_ProducaoAccessor.Execute().ToList();
        }
    }
}
