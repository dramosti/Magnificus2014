using HLP.Base.Static;
using HLP.Dependencies;
using HLP.Entries.Model.Models.Fiscal;
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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_StIpi" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_StIpi.svc or wcf_StIpi.svc.cs at the Solution Explorer and start debugging.

    public class wcf_StIpi : Iwcf_StIpi
    {
        [Inject]
        public ISituacao_tributaria_ipiRepository situacao_Tributaria_IpiRepository { get; set; }

        public wcf_StIpi()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public Situacao_tributaria_ipiModel GetObject(int id)
        {
            try
            {
                return this.situacao_Tributaria_IpiRepository.GetStIpi(idCSTIpi: id);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public int SaveObject(Situacao_tributaria_ipiModel obj)
        {
            try
            {
                situacao_Tributaria_IpiRepository.Save(ipi: obj);
                return obj.idCSTIpi ?? 0;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public bool DeleteObject(int id)
        {
            try
            {
                situacao_Tributaria_IpiRepository.Delete(idCSTIpi: id);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public Situacao_tributaria_ipiModel CopyObject(int id)
        {
            try
            {
                return this.GetObject(id:
                    this.situacao_Tributaria_IpiRepository.Copy(idCSTIpi: id));
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }

}
