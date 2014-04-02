using HLP.Base.ClassesBases;
using HLP.Base.Static;
using HLP.Components.Model.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Components.Services
{

    public class HlpPesqPadraoService
    {
        private HLP.Wcf.Entries.wcf_HlpPesqPadrao serviceNetwork;
        private wcf_HlpPesqPadrao.Iwcf_HlpPesqPadraoClient serviceWeb;

        public HlpPesqPadraoService()
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {                        
                        serviceNetwork = new Wcf.Entries.wcf_HlpPesqPadrao();
                    }
                    break;
                case StConnection.OnlineWeb:
                    {
                        serviceWeb = new wcf_HlpPesqPadrao.Iwcf_HlpPesqPadraoClient();
                    }
                    break;
                case StConnection.Offline:
                default:
                    break;
            }
        }

        public DataSet GetData(string sSelect, bool addDefault = false, string sWhere = "", bool bOrdena = true)
        {
            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        return serviceNetwork.GetData(sSelect, addDefault, sWhere, bOrdena);

                    }
                case StConnection.OnlineWeb:
                    {
                        return serviceWeb.GetData(sSelect, addDefault, sWhere, bOrdena);
                    }
                case StConnection.Offline:
                default:
                    {
                        return null;
                    }
            }
        }

        public List<PesquisaPadraoModel> GetTableInformation(string sViewName)
        {
            List<PesquisaPadraoModel> lResult = new List<PesquisaPadraoModel>();

            switch (Sistema.bOnline)
            {
                case StConnection.OnlineNetwork:
                    {
                        lResult = (from c in serviceNetwork.GetTableInformation(sViewName: sViewName)
                                   select new PesquisaPadraoModel
                                   {
                                       DATA_TYPE = c.DATA_TYPE,
                                       COLUMN_NAME = c.COLUMN_NAME
                                   }).ToList<PesquisaPadraoModel>();
                        return lResult;
                    }
                case StConnection.OnlineWeb:
                    {
                        lResult = (from c in serviceWeb.GetTableInformation(sViewName: sViewName)
                                   select new PesquisaPadraoModel
                                   {
                                       DATA_TYPE = c.DATA_TYPE,
                                       COLUMN_NAME = c.COLUMN_NAME
                                   }).ToList<PesquisaPadraoModel>();
                        return lResult;
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
