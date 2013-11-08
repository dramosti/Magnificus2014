using HLP.Comum.Infrastructure;
using HLP.Comum.Model.Models;
using HLP.Comum.Model.Repository.Interfaces.ClassesBases;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Comum.Model.Repository.Implementation.ClassesBases
{
    public class modelBaseRepository : ImodelBaseRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }
        public modelBaseRepository()
        {            
        }

        DataAccessor<campoSqlModel> regAcessor = null;

        public List<campoSqlModel> getCamposSqlNotNull(string xTabela)
        {
            if (regAcessor == null)
            {
                regAcessor = this.UndTrabalho.dbPrincipal.CreateSqlStringAccessor(
                    sqlString: ("select c.COLUMN_NAME, (select keyC.type from sys.key_constraints keyC " +
                                "where keyC.name = (select const.CONSTRAINT_NAME from INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE const " +
                                "where const.TABLE_NAME = c.TABLE_NAME and const.COLUMN_NAME = c.COLUMN_NAME)) as TYPE " +
                                "from INFORMATION_SCHEMA.COLUMNS c " +
                                "where c.TABLE_NAME = '" + xTabela + "' and IS_NULLABLE = 'NO'"),
                                rowMapper: MapBuilder<campoSqlModel>.MapAllProperties().Build());
            }
            return regAcessor.Execute().ToList();
        }
    }
}
