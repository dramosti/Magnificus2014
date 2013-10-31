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
                    sqlString: ("select COLUMN_NAME, "+
                                "case IS_NULLABLE when 'NO' THEN 0 "+
                                "ELSE 1 END as IS_NULLABLE from INFORMATION_SCHEMA.COLUMNS " +
                                "where TABLE_NAME = '"+xTabela+"'"),
                                rowMapper: MapBuilder<campoSqlModel>.MapAllProperties().Build());
            }

            return regAcessor.Execute().ToList();
        }
    }
}
