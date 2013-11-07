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
        //[Inject]
        //public UnitOfWorkBase UndTrabalho { get; set; }
        private Database _dbPrincipal;

        public modelBaseRepository()
        {            
            _dbPrincipal = EnterpriseLibraryContainer.Current.GetInstance<Database>("dbPrincipal");
        }

        DataAccessor<campoSqlModel> regAcessor = null;

        public List<campoSqlModel> getCamposSqlNotNull(string xTabela)
        {
            if (regAcessor == null)
            {
                regAcessor = this._dbPrincipal.CreateSqlStringAccessor(
                    sqlString: ("select c.COLUMN_NAME, " +
                                "case c.IS_NULLABLE " +
                                "when 'NO' THEN 0 " +
                                "ELSE 1 END as IS_NULLABLE, " +
                                "(select o.type from sys.all_objects o where o.name = " +
                                "(select k.CONSTRAINT_NAME from INFORMATION_SCHEMA.KEY_COLUMN_USAGE k " +
                                "where k.COLUMN_NAME = c.COLUMN_NAME and k.TABLE_NAME = '" + xTabela + "')) as TYPECONSTRAINT " +
                                "from INFORMATION_SCHEMA.COLUMNS c " +
                                "where c.TABLE_NAME = '" + xTabela + "'"),
                                rowMapper: MapBuilder<campoSqlModel>.MapAllProperties().Build());
            }
            return regAcessor.Execute().ToList();
        }
    }
}
