using HLP.Base.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Comum.Services
{
    public class SelectConnectionService
    {
        HLP.Wcf.Entries.wcf_SelectConnectionConfig serviceNetwork;


        public SelectConnectionService() 
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        serviceNetwork = new Wcf.Entries.wcf_SelectConnectionConfig();
                    }
                    break;
                case StConnection.OnlineWeb:
                    {
                      //  serviceWeb = new wcf_ConnectionConfig.Iwcf_ConnectionConfigClient();
                    }
                    break;
                case StConnection.Offline:
                default:
                    {
                    } break;
            };
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
