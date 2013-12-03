using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HLP.Comum.Resources.Util;
using HLP.Dependencies;
using HLP.Entries.Model.Repository.Interfaces.Fiscal;
using Ninject;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serviceCarga_trib_media_st_icms" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serviceCarga_trib_media_st_icms.svc or serviceCarga_trib_media_st_icms.svc.cs at the Solution Explorer and start debugging.
    public class serviceCarga_trib_media_st_icms : IserviceCarga_trib_media_st_icms
    {
        [Inject]
        public ICarga_trib_media_st_icmsRepository iCarga_trib_media_st_icmsRepository { get; set; }

        public serviceCarga_trib_media_st_icms()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public int Save(HLP.Entries.Model.Models.Fiscal.Carga_trib_media_st_icmsModel objModel)
        {

            try
            {
                iCarga_trib_media_st_icmsRepository.Save(objModel);
                return (int)objModel.idCargaTribMediaStIcms;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public HLP.Entries.Model.Models.Fiscal.Carga_trib_media_st_icmsModel GetObjeto(int idObjeto)
        {

            try
            {
                return iCarga_trib_media_st_icmsRepository.GetCarga_trib_media_st_icms(idObjeto);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public bool Delete(HLP.Entries.Model.Models.Fiscal.Carga_trib_media_st_icmsModel objModel)
        {

            try
            {
                iCarga_trib_media_st_icmsRepository.Delete((int)objModel.idCargaTribMediaStIcms);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public int Copy(HLP.Entries.Model.Models.Fiscal.Carga_trib_media_st_icmsModel objModel)
        {

            try
            {
                return iCarga_trib_media_st_icmsRepository.Copy((int)objModel.idCargaTribMediaStIcms);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public List<HLP.Entries.Model.Models.Fiscal.Carga_trib_media_st_icmsModel> GetAllCarga_trib_media_st_icms()
        {

            try
            {
                return iCarga_trib_media_st_icmsRepository.GetAllCarga_trib_media_st_icms();
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public HLP.Entries.Model.Models.Fiscal.Carga_trib_media_st_icmsModel GetCarga_trib_media_st_icmsByUf(int idUf)
        {

            try
            {
                return iCarga_trib_media_st_icmsRepository.GetCarga_trib_media_st_icmsByUf(idUf);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        
        }
    }
}
