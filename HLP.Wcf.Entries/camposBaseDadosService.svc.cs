using HLP.Comum.Model.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HLP.Comum.Model.Repository.Interfaces.ClassesBases;
using HLP.Dependencies;
using HLP.Comum.Resources.Util;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "camposBaseDadosService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select camposBaseDadosService.svc or camposBaseDadosService.svc.cs at the Solution Explorer and start debugging.
    public class camposBaseDadosService : IcamposBaseDadosService
    {
        [Inject]
        public ImodelBaseRepository modelBaseRepository { get; set; }

        public camposBaseDadosService()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public List<campoSqlModel> getCamposNotNull(string xTabela)
        {
            try
            {
                return modelBaseRepository.getCamposSqlNotNull(xTabela: xTabela);
            }
            catch (Exception e)
            {
                Log.AddLog(xLog: e.Message);
                throw e;
            }
        }
    }
}
