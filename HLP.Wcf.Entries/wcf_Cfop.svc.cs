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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_Cfop" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_Cfop.svc or wcf_Cfop.svc.cs at the Solution Explorer and start debugging.

    public class wcf_Cfop : Iwcf_Cfop
    {
        [Inject]
        public ICfopRepository cfopRepository { get; set; }

        public wcf_Cfop()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public CfopModel GetObject(int id)
        {
            try
            {
                return this.cfopRepository.GetCfop(idCfop: id);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public int SaveObject(CfopModel obj)
        {
            try
            {
                cfopRepository.Save(cfop: obj);
                return obj.idCfop ?? 0;
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
                cfopRepository.Delete(idCfop: id);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public CfopModel CopyObject(int id)
        {
            try
            {
                return this.GetObject(id:
                    this.cfopRepository.Copy(idCfop: id));
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }

}
