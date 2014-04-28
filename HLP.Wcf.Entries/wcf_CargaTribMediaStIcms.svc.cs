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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_CargaTribMediaStIcms" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_CargaTribMediaStIcms.svc or wcf_CargaTribMediaStIcms.svc.cs at the Solution Explorer and start debugging.

    public class wcf_CargaTribMediaStIcms : Iwcf_CargaTribMediaStIcms
    {
        [Inject]
        public ICarga_trib_media_st_icmsRepository carga_Trib_Media_StIcmsRepository { get; set; }

        public wcf_CargaTribMediaStIcms()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public Carga_trib_media_st_icmsModel GetObject(int id)
        {
            try
            {
                return this.carga_Trib_Media_StIcmsRepository.GetCarga_trib_media_st_icms(
                    idCargaTribMediaStIcms: id);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public int SaveObject(Carga_trib_media_st_icmsModel obj)
        {
            try
            {
                carga_Trib_Media_StIcmsRepository.Save(
                    objCarga_trib_media_st_icms: obj);
                return obj.idCargaTribMediaStIcms ?? 0;
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
                carga_Trib_Media_StIcmsRepository.Delete(idCargaTribMediaStIcms: id);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public Carga_trib_media_st_icmsModel CopyObject(int id)
        {
            try
            {
                return this.GetObject(id:
                    this.carga_Trib_Media_StIcmsRepository.Copy(idCargaTribMediaStIcms: id));
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }

}
