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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serviceStIpi" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serviceStIpi.svc or serviceStIpi.svc.cs at the Solution Explorer and start debugging.
    public class serviceStIpi : IserviceStIpi
    {
        [Inject]
        public ISituacao_tributaria_ipiRepository situacao_tributaria_ipiRepository { get; set; }


        public serviceStIpi()
        {

            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";

        }

        public int Save(HLP.Entries.Model.Models.Fiscal.Situacao_tributaria_ipiModel Objeto)
        {

            try
            {
                this.situacao_tributaria_ipiRepository.Save(ipi: Objeto);
                return (int)Objeto.idCSTIpi;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public HLP.Entries.Model.Models.Fiscal.Situacao_tributaria_ipiModel GetObjeto(int idObjeto)
        {

            try
            {
                return this.situacao_tributaria_ipiRepository.GetStIpi(idCSTIpi: idObjeto);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public bool Delete(HLP.Entries.Model.Models.Fiscal.Situacao_tributaria_ipiModel Objeto)
        {

            try
            {
                this.situacao_tributaria_ipiRepository.Delete(idCSTIpi: (int)Objeto.idCSTIpi);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public int Copy(HLP.Entries.Model.Models.Fiscal.Situacao_tributaria_ipiModel Objeto)
        {

            try
            {
                return this.situacao_tributaria_ipiRepository.Copy(idCSTIpi: (int)Objeto.idCSTIpi);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }
    }
}
