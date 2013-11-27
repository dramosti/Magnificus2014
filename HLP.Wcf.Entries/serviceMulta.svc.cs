using HLP.Comum.Resources.Util;
using HLP.Dependencies;
using HLP.Entries.Model.Repository.Interfaces.Comercial;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serviceMulta" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serviceMulta.svc or serviceMulta.svc.cs at the Solution Explorer and start debugging.
    public class serviceMulta : IserviceMulta
    {
        [Inject]
        public IMultasRepository multasRepository { get; set; }

        public serviceMulta()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public HLP.Entries.Model.Models.Comercial.MultasModel getMulta(int idMulta)
        {

            try
            {
                return this.multasRepository.GetMulta(idMultas: idMulta);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public int saveMulta(HLP.Entries.Model.Models.Comercial.MultasModel objMulta)
        {
            try
            {
                this.multasRepository.Save(multa: objMulta);
                return (int)objMulta.idMultas;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public bool deleteMulta(int idMulta)
        {

            try
            {
                this.multasRepository.Delete(idMultas: idMulta);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public int copyMulta(int idMulta)
        {

            try
            {
                return this.multasRepository.Copy(idMultas: idMulta);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }
    }
}
