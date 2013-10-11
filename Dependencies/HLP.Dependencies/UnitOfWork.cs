using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Infrastructure;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System.Data.Common;

namespace HLP.Dependencies
{
    public class UnitOfWork : UnitOfWorkBase
    {
        private Database _dbPrincipal;

        private DbTransaction _transaction;

        public override Database dbPrincipal
        {
            get { return _dbPrincipal; }
        }

        public UnitOfWork()
        {
            this._dbPrincipal = EnterpriseLibraryContainer.Current.GetInstance<Database>("dbPrincipal");
        }

    }
}
