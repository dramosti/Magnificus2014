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
    public class Parametro_EstoqueRepository : IParametro_EstoqueRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Parametro_EstoqueModel> regParametro_EstoqueAccessor;
        private DataAccessor<Parametro_EstoqueModel> regAllParametro_EstoqueAccessor;

        public void Save(Parametro_EstoqueModel objParametro_Estoque)
        {
            if (objParametro_Estoque.idParametroEstoque == null)
            {
                objParametro_Estoque.idParametroEstoque = (int)UndTrabalho.dbPrincipal.ExecuteScalar("dbo.Proc_save_Parametro_Estoque",
                ParameterBase<Parametro_EstoqueModel>.SetParameterValue(objParametro_Estoque));
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar("dbo.Proc_update_Parametro_Estoque",
            ParameterBase<Parametro_EstoqueModel>.SetParameterValue(objParametro_Estoque));
            }
        }

        public void Delete(int idParametroEstoque)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar("dbo.Proc_delete_Parametro_Estoque",
                 UserData.idUser,
                 idParametroEstoque);
        }

        public int Copy(int idParametroEstoque)
        {
            return (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                      "dbo.Proc_copy_Parametro_Estoque",
                       idParametroEstoque);
        }

        public Parametro_EstoqueModel GetParametro_Estoque(int idEmpresa)
        {
            if (regParametro_EstoqueAccessor == null)
            {
                regParametro_EstoqueAccessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor("SELECT * FROM Parametro_Estoque" +
                " where idEmpresa = " + idEmpresa,
                                MapBuilder<Parametro_EstoqueModel>.MapAllProperties().DoNotMap(i => i.status).Build());
            }

            return regParametro_EstoqueAccessor.Execute().FirstOrDefault();
        }

        public List<Parametro_EstoqueModel> GetAllParametro_Estoque()
        {
            if (regAllParametro_EstoqueAccessor == null)
            {
                regAllParametro_EstoqueAccessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor("SELECT * FROM Parametro_Estoque",
                                MapBuilder<Parametro_EstoqueModel>.MapAllProperties().DoNotMap(i => i.status).Build());
            }
            return regAllParametro_EstoqueAccessor.Execute().ToList();
        }
    }
}
