using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System.Data.Common;
using HLP.Base.Static;
using System.Configuration;

namespace HLP.Dependencies
{
    public class UnitOfWork2 : HLP.Base.ClassesBases.UnitOfWorkBase
    {
        private Database _dbPrincipal;

        //private DbTransaction _transaction; **comentei esta linha pq não tem sentido uma variável privada e a mesma não ser utilizada em nenhum lugar

        public override Database dbPrincipal
        {
            get
            {
                return _dbPrincipal;
            }
        }

        public UnitOfWork2()
        {
            try
            {

                 this._dbPrincipal = EnterpriseLibraryContainer.Current.GetInstance<Database>(WcfData.xNameConnection);
                //System.Configuration.Configuration config =
                //        ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                //this._dbPrincipal = DatabaseFactory.CreateDatabase(config.ConnectionStrings.ConnectionStrings[WcfData.xNameConnection].ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
