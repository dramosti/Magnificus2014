using HLP.Base.ClassesBases;
using HLP.Comum.Resources.Util;
using HLP.Dependencies;
using HLP.Entries.Model.Repository.Interfaces.Components;
using Ninject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_HlpPesqPadrao" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_HlpPesqPadrao.svc or wcf_HlpPesqPadrao.svc.cs at the Solution Explorer and start debugging.
    public class wcf_HlpPesqPadrao : Iwcf_HlpPesqPadrao
    {
        [Inject]
        public IHlpPesquisaPadraoRepository iHlpPesquisaPadraoRepository { get; set; }

        public wcf_HlpPesqPadrao()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }


        public List<PesquisaPadraoModelContract> GetTableInformation(string sViewName)
        {
            try
            {
                var dados = iHlpPesquisaPadraoRepository.GetTableInformationContract(sViewName);
                return dados.ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public DataSet GetData(string sSelect, bool addDefault = false, string sWhere = "", bool bOrdena = true)
        {
            object dados = iHlpPesquisaPadraoRepository.GetData(sSelect,
                addDefault,
                sWhere,
                bOrdena);
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add((dados as DataTable));

            return dsReturn;
        }
    }
}
