using HLP.Comum.Resources.Util;
using HLP.Dependencies;
using HLP.Entries.Model.Repository.Interfaces.RecursosHumanos;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serviceSetor" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serviceSetor.svc or serviceSetor.svc.cs at the Solution Explorer and start debugging.
    public class serviceSetor : IserviceSetor
    {
        [Inject]
        public ISetorRepository serviceSetorRepository { get; set; }

        public serviceSetor()
        {
            try
            {
                IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
                kernel.Settings.ActivationCacheDisabled = false;
                kernel.Inject(this);
                Log.xPath = @"C:\inetpub\wwwroot\log";
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        public HLP.Entries.Model.Models.RecursosHumanos.SetorModel getSetor(int idSetor)
        {

            try
            {
                return serviceSetorRepository.GetSetor(idSetor: idSetor);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public int saveSetor(HLP.Entries.Model.Models.RecursosHumanos.SetorModel objSetor)
        {

            try
            {
                serviceSetorRepository.Save(setor: objSetor);
                return (int)objSetor.idSetor;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public bool deleteSetor(int idSetor)
        {

            try
            {
                serviceSetorRepository.Delete(idSetor: idSetor);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public int copySetor(int idSetor)
        {

            try
            {
                return serviceSetorRepository.Copy(idSetor: idSetor);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }
    }
}
