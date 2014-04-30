using HLP.Base.Static;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Comum.Services
{
    public class ConnectionConfigService
    {
        HLP.Wcf.Entries.wcf_ConnectionConfig serviceNetwork;
        wcf_ConnectionConfig.Iwcf_ConnectionConfigClient serviceWeb;


        public ConnectionConfigService() 
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        serviceNetwork = new Wcf.Entries.wcf_ConnectionConfig();
                    }
                    break;
                case StConnection.OnlineWeb:
                    {
                        serviceWeb = new wcf_ConnectionConfig.Iwcf_ConnectionConfigClient();
                    }
                    break;
                case StConnection.Offline:
                default:
                    {
                    } break;
            };
        }

        public DataTable GetServer()
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.serviceNetwork.GetServer();
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.serviceWeb.GetServer();
                    }
                case StConnection.Offline:
                default:
                    {
                        return null;
                    }
            }
        }

        public DataSet GetDatabases(string connectionString) 
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.serviceNetwork.GetDatabases(connectionString);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.serviceWeb.GetDatabases(connectionString);
                    }
                case StConnection.Offline:
                default:
                    {
                        return null;
                    }
            }
        }

        public bool TestConnection(string connectionString) 
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.serviceNetwork.TestConnection(connectionString);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.serviceWeb.TestConnection(connectionString);
                    }
                case StConnection.Offline:
                default:
                    {
                        return false;
                    }
            }
        }


        public HLP.Comum.Model.Models.MagnificusBaseConfiguration GetBaseConfiguration() 
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.serviceNetwork.GetBaseConfiguration();
                    }
                case StConnection.OnlineWeb:
                    {
                        //return this.serviceWeb.GetBaseConfiguration();
                        return null;
                    }
                case StConnection.Offline:
                default:
                    {
                        return null;
                    }
            }

        }
    }
}
