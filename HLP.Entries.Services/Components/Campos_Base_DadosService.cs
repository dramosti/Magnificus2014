using HLP.Base.ClassesBases;
using HLP.Base.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Services.Components
{
    public class Campos_Base_DadosService
    {
        HLP.Wcf.Entries.wcf_CamposBaseDados serviceNetwork;
        wcf_CamposBaseDados.Iwcf_CamposBaseDadosClient serviceWeb;

        public Campos_Base_DadosService()
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        serviceNetwork = new Wcf.Entries.wcf_CamposBaseDados();
                    }
                    break;
                case StConnection.OnlineWeb:
                    {
                        serviceWeb = new wcf_CamposBaseDados.Iwcf_CamposBaseDadosClient();
                    }
                    break;
                case StConnection.Offline:
                    break;
                default:
                    break;
            }
        }

        public List<PesquisaPadraoModelContract> GetFieldsNotNull(string xTabela)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return this.serviceNetwork.getCamposNotNull(xTabela: xTabela);
                    }
                case StConnection.OnlineWeb:
                    {
                        return this.serviceWeb.getCamposNotNull(xTabela: xTabela);
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
