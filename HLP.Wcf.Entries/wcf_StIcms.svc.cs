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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_StIcms" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_StIcms.svc or wcf_StIcms.svc.cs at the Solution Explorer and start debugging.

    public class wcf_StIcms : Iwcf_StIcms
    {
        [Inject]
        public ISituacao_tributaria_icmsRepository Situacao_Tributaria_IcmsRepository { get; set; }

        public wcf_StIcms()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public Situacao_tributaria_icmsModel GetObject(int id)
        {
            try
            {
                return this.Situacao_Tributaria_IcmsRepository
                    .GetStIcms(idCSTIcms: id);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public int SaveObject(Situacao_tributaria_icmsModel obj)
        {
            try
            {
                Situacao_Tributaria_IcmsRepository.Save(icms: obj);
                return obj.idCSTICms ?? 0;
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
                Situacao_Tributaria_IcmsRepository.Delete(idCSTIcms: id);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public Situacao_tributaria_icmsModel CopyObject(int id)
        {
            try
            {
                //IMPLEMENTAR COPY
                return this.GetObject(id:
                    this.Situacao_Tributaria_IcmsRepository.Copy(idCSTIcms: id));
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }

}
