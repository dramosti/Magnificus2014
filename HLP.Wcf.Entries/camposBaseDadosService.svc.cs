using Ninject;
using System;
using HLP.Comum.Model.Repository.Interfaces.ClassesBases;
using HLP.Dependencies;
using HLP.Comum.Resources.Util;
using HLP.Comum.Model.Models;
using System.Collections.Generic;

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
