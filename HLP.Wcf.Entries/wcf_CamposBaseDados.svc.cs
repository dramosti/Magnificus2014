using HLP.Base.ClassesBases;
using HLP.Comum.Resources.Util;
using HLP.Dependencies;
using HLP.Entries.Model.Repository.Interfaces.Components;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_CamposBaseDados" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_CamposBaseDados.svc or wcf_CamposBaseDados.svc.cs at the Solution Explorer and start debugging.
    public class wcf_CamposBaseDados : Iwcf_CamposBaseDados
    {
        [Inject]
        public IHlpPesquisaPadraoRepository pesquisaPadraoRepository { get; set; }

        public wcf_CamposBaseDados()
        {
            Log.xPath = @"C:\inetpub\wwwroot\log";
            try
            {
                IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
                kernel.Settings.ActivationCacheDisabled = false;
                kernel.Inject(this);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw;
            }
        }

        public List<PesquisaPadraoModelContract> getCamposNotNull(string xTabela)
        {
            try
            {
                return pesquisaPadraoRepository.getCamposSqlNotNull(xTabela: xTabela);
            }
            catch (Exception e)
            {
                Log.AddLog(xLog: e.Message);
                throw e;
            }
        }
    }
}
