using HLP.Base.Static;
using HLP.Comum.Model.Repository.Interfaces;
using HLP.Dependencies;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_ConnectionConfig" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_ConnectionConfig.svc or wcf_ConnectionConfig.svc.cs at the Solution Explorer and start debugging.
    public class wcf_ConnectionConfig : Iwcf_ConnectionConfig
    {
        [Inject]
        public IConnectionConfigRepository connectionConfig { get; set; }

        public wcf_ConnectionConfig()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public System.Data.DataTable GetServer()
        {

            try
            {
                return connectionConfig.GetServer();
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public System.Data.DataSet GetDatabases(string connectionString)
        {
            try
            {
                return connectionConfig.GetDatabases(connectionString: connectionString);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public bool TestConnection(string connectionString)
        {
            try
            {
                return connectionConfig.TestConnection(connectionString: connectionString);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }
}
