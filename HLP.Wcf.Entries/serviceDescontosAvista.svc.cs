using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HLP.Comum.Resources.Util;
using HLP.Dependencies;
using Ninject;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serviceDescontosAvista" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serviceDescontosAvista.svc or serviceDescontosAvista.svc.cs at the Solution Explorer and start debugging.
    public class serviceDescontosAvista : IserviceDescontosAvista
    {

        [Inject]
        public HLP.Entries.Model.Repository.Interfaces.Financeiro.IDescontos_AvistaRepository iDescontos_AvistaRepository { get; set; }
        public serviceDescontosAvista()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public HLP.Entries.Model.Models.Financeiro.Descontos_AvistaModel GetObject(int idDescontosAvista)
        {
            try
            {
                return iDescontos_AvistaRepository.GetDesconto(idDescontosAvista);

            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public List<HLP.Entries.Model.Models.Financeiro.Descontos_AvistaModel> GetAll()
        {
            try
            {
                return iDescontos_AvistaRepository.GetAll();
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        
        }

        public int Save(HLP.Entries.Model.Models.Financeiro.Descontos_AvistaModel desconto)
        {
            try
            {
                iDescontos_AvistaRepository.Save(desconto);
                return (int)desconto.idDescontosAvista;

            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        
        }

        public bool Delete(int idDescontosAvista)
        {
            try
            {
                iDescontos_AvistaRepository.Delete(idDescontosAvista);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        
        }

        public int Copy(int idDescontosAvista)
        {
            try
            {
              return iDescontos_AvistaRepository.Copy(idDescontosAvista);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        
        }
    }
}
