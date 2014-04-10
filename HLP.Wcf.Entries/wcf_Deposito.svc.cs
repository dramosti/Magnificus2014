using HLP.Base.Static;
using HLP.Dependencies;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.Model.Repository.Interfaces.Gerais;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_Deposito" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_Deposito.svc or wcf_Deposito.svc.cs at the Solution Explorer and start debugging.

    public class wcf_Deposito : Iwcf_Deposito
    {
        [Inject]
        public IDepositoRepository depositoRepository { get; set; }

        public wcf_Deposito()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public DepositoModel GetObject(int id)
        {
            try
            {
                return this.depositoRepository.GetDeposito(idDeposito: id);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw;
            }
        }

        public int SaveObject(DepositoModel obj)
        {
            try
            {
                depositoRepository.Save(deposito: obj);
                return obj.idDeposito ?? 0;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw;
            }
        }

        public bool DeleteObject(int id)
        {
            try
            {
                depositoRepository.Delete(idDeposito: id);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                return false;
            }
        }

        public int CopyObject(int id)
        {
            try
            {
                return this.depositoRepository.Copy(idDeposito: id);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }

}
