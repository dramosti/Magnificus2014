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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serviceCfop" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serviceCfop.svc or serviceCfop.svc.cs at the Solution Explorer and start debugging.
    public class serviceCfop : IserviceCfop
    {
        [Inject]
        public ICfopRepository iCfopRepository { get; set; }
        public serviceCfop()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }
        public int Save(HLP.Entries.Model.Models.Fiscal.CfopModel objModel)
        {
            try
            {
                iCfopRepository.Save(objModel);
                return (int)objModel.idCfop;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public HLP.Entries.Model.Models.Fiscal.CfopModel GetObjeto(int idObjeto)
        {
            try
            {
                return iCfopRepository.GetCfop(idObjeto);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public bool Delete(HLP.Entries.Model.Models.Fiscal.CfopModel objModel)
        {
            try
            {
                iCfopRepository.Delete((int)objModel.idCfop);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public int Copy(HLP.Entries.Model.Models.Fiscal.CfopModel objModel)
        {
            try
            {
                return iCfopRepository.Copy((int)objModel.idCfop);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }
}
