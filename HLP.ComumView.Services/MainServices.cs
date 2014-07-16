using HLP.Base.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.ComumView.Services
{

    public class MainService
    {
        wcf_Cidade.Iwcf_CidadeClient objServiceCidadeWeb;

        HLP.Wcf.Entries.wcf_Cidade objServiceCidadeNetWork;

        public MainService()
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        objServiceCidadeNetWork = new Wcf.Entries.wcf_Cidade();
                    }
                    break;
                case StConnection.OnlineWeb:
                    {
                        objServiceCidadeWeb = new wcf_Cidade.Iwcf_CidadeClient();
                    }
                    break;
                case StConnection.Offline:
                default:
                    {
                    } break;
            }
        }        
    }

}
