using HLP.Comum.Resources.Util;
using HLP.Dependencies;
using HLP.Entries.Model.Repository.Interfaces.Fiscal;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serviceStIcms" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serviceStIcms.svc or serviceStIcms.svc.cs at the Solution Explorer and start debugging.
    public class serviceStIcms : IserviceStIcms
    {
        [Inject]
        public ISituacao_tributaria_icmsRepository situaca_Tributaria_IcmsRepository { get; set; }

        public serviceStIcms()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public int Save(HLP.Entries.Model.Models.Fiscal.Situacao_tributaria_icmsModel Objeto)
        {

            try
            {
                this.situaca_Tributaria_IcmsRepository.Save(icms: Objeto);
                return (int)Objeto.idCSTIcms;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public HLP.Entries.Model.Models.Fiscal.Situacao_tributaria_icmsModel GetObjeto(int idObjeto)
        {

            try
            {
                return this.situaca_Tributaria_IcmsRepository.GetStIcms(idCSTIcms: idObjeto);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public bool Delete(HLP.Entries.Model.Models.Fiscal.Situacao_tributaria_icmsModel Objeto)
        {

            try
            {
                this.situaca_Tributaria_IcmsRepository.Delete(idCSTIcms: (int)Objeto.idCSTIcms);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public int Copy(HLP.Entries.Model.Models.Fiscal.Situacao_tributaria_icmsModel Objeto)
        {

            try
            {
                return this.situaca_Tributaria_IcmsRepository.Copy(idCSTIcms: (int)Objeto.idCSTIcms);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }
    }
}
