using HLP.Comum.Resources.Util;
using HLP.Dependencies;
using HLP.Entries.Model.Repository.Interfaces.Gerais;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serviceDecisao" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serviceDecisao.svc or serviceDecisao.svc.cs at the Solution Explorer and start debugging.
    public class serviceDecisao : IserviceDecisao
    {
        [Inject]
        public IDecisaoRepository decisaoRepository { get; set; }

        public serviceDecisao()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public HLP.Entries.Model.Models.Gerais.DecisaoModel getDecisao(int idDecisao)
        {
            try
            {
                return decisaoRepository.GetDecisao(idDecisao: idDecisao);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public HLP.Entries.Model.Models.Gerais.DecisaoModel saveDecisao(HLP.Entries.Model.Models.Gerais.DecisaoModel objDecisao)
        {
            try
            {
                this.decisaoRepository.Save(decisao: objDecisao);
                return objDecisao;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public bool deleteDecisao(int idDecisao)
        {
            try
            {
                this.decisaoRepository.Delete(idDecisao: idDecisao);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public int copyDecisao(int idDecisao)
        {
            try
            {
                return this.decisaoRepository.Copy(idDecisao: idDecisao);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }
}
