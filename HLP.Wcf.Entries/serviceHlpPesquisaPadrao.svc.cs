using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HLP.Comum.Model.Components;
using HLP.Comum.Model.Repository.Interfaces.Components;
using HLP.Comum.Resources.Util;
using HLP.Dependencies;
using Ninject;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serviceHlpPesquisaPadrao" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serviceHlpPesquisaPadrao.svc or serviceHlpPesquisaPadrao.svc.cs at the Solution Explorer and start debugging.
    public class serviceHlpPesquisaPadrao : IserviceHlpPesquisaPadrao
    {
        public serviceHlpPesquisaPadrao()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        [Inject]
        public IHlpPesquisaPadraoRepository iHlpPesquisaPadraoRepository { get; set; }

        [OperationBehavior]
        public DataTable GetData(string sSelect, bool addDefault = false, string sWhere = "", bool bOrdena = true)
        {
            try
            {
                return iHlpPesquisaPadraoRepository.GetData(sSelect, addDefault, sWhere, bOrdena);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public ObservableCollection<PesquisaPadraoModel> GetTableInformation(string sViewName)
        {

            try
            {
                return iHlpPesquisaPadraoRepository.GetTableInformation(sViewName: sViewName);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }
    }
}
