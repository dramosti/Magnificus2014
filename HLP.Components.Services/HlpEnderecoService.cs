using HLP.Base.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Components.Services
{

    public class HlpEnderecoService
    {
        const string xTabela = "HlpEndereco;";

        HLP.Wcf.Entries.wcf_Cidade serviceNetwork;
        wcf_Cidade.Iwcf_CidadeClient serviceWeb;


        public HlpEnderecoService()
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        serviceNetwork = new Wcf.Entries.wcf_Cidade();
                    }
                    break;
                case StConnection.OnlineWeb:
                    {
                        serviceWeb = new wcf_Cidade.Iwcf_CidadeClient();
                    }
                    break;
                case StConnection.Offline:
                default:
                    {
                    } break;
            }
        }

        public int? GetIdCidadeByDesc(string xDesc)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.serviceNetwork.GetCidadeByName(xName: xDesc);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.serviceWeb.GetCidadeByName(xName: xDesc);
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
