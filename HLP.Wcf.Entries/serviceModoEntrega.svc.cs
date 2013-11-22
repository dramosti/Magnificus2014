using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HLP.Comum.Resources.Util;
using HLP.Dependencies;
using HLP.Entries.Model.Repository.Interfaces.Transportes;
using Ninject;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serviceModoEntrega" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serviceModoEntrega.svc or serviceModoEntrega.svc.cs at the Solution Explorer and start debugging.
    public class serviceModoEntrega : IserviceModoEntrega
    {
        [Inject]
        public IModos_entregaRepository iModos_entregaRepository { get; set; }

        public serviceModoEntrega() 
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public HLP.Entries.Model.Models.Transportes.Modos_entregaModel GetModo(int idModosEntrega)
        {
            try
            {
                return iModos_entregaRepository.GetModo(idModosEntrega);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }        
        }

        public void Save(HLP.Entries.Model.Models.Transportes.Modos_entregaModel modo)
        {
            try
            {
                iModos_entregaRepository.Save(modo);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public bool Delete(int idModosEntrega)
        {
            try
            {
                iModos_entregaRepository.Delete(idModosEntrega);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public int Copy(int idModosEntrega)
        {
            try
            {
                return iModos_entregaRepository.Copy(idModosEntrega);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }
}
