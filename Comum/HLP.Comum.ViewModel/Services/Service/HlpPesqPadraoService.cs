using HLP.Comum.Infrastructure.Static;
using HLP.Comum.Model.Components;
using System;

using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Comum.ViewModel.Services.Service
{

    public class HlpPesqPadraoService
    {
        private HlpPesquisaPadraoService.IservicePesquisaPadraoClient serviceOn;
        private HLP.Wcf.Entries.servicePesquisaPadrao serviceOff;

        public DataSet GetData(string sSelect, bool addDefault = false, string sWhere = "", bool bOrdena = true)
        {
            if (Sistema.bOnline == TipoConexao.OnlineInternet)
            {
                if (serviceOn == null)
                    serviceOn = new HlpPesquisaPadraoService.IservicePesquisaPadraoClient();
                return serviceOn.GetData(sSelect, addDefault, sWhere, bOrdena);

            }
            else if (Sistema.bOnline == TipoConexao.OnlineRede)
            {
                if (serviceOff == null)
                    serviceOff = new Wcf.Entries.servicePesquisaPadrao();
                return serviceOff.GetData(sSelect, addDefault, sWhere, bOrdena);
            }
            else
            {
                return null;
            }
        }

        public List<PesquisaPadraoModel> GetTableInformation(string sViewName)
        {
            List<PesquisaPadraoModel> lResult = new List<PesquisaPadraoModel>();

            if (Sistema.bOnline == TipoConexao.OnlineInternet)
            {
                if (serviceOn == null)
                    serviceOn = new HlpPesquisaPadraoService.IservicePesquisaPadraoClient();
                HlpPesquisaPadraoService.PesquisaPadraoModelContract[] l = serviceOn.GetTableInformation(sViewName);
                lResult = (from c in l
                           select new PesquisaPadraoModel
                           {
                               DATA_TYPE = c.DATA_TYPE,
                               COLUMN_NAME = c.COLUMN_NAME
                           }).ToList<PesquisaPadraoModel>();
                return lResult;
            }
            else if (Sistema.bOnline == TipoConexao.OnlineRede)
            {
                if (serviceOff == null)
                    serviceOff = new Wcf.Entries.servicePesquisaPadrao();
                HLP.Comum.Model.Components.PesquisaPadraoModelContract[] l = serviceOff.GetTableInformation(sViewName);
                lResult = (from c in l
                           select new PesquisaPadraoModel
                           {
                               DATA_TYPE = c.DATA_TYPE,
                               COLUMN_NAME = c.COLUMN_NAME
                           }).ToList<PesquisaPadraoModel>();
                return lResult;
            }
            else
            {
                return lResult;
            }
        }
    }
}
