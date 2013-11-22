using HLP.Comum.Resources.Util;
using HLP.Dependencies;
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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serviceDeposito" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serviceDeposito.svc or serviceDeposito.svc.cs at the Solution Explorer and start debugging.
    public class serviceDeposito : IserviceDeposito
    {
        [Inject]
        public IDepositoRepository depositoRepository { get; set; }

        public serviceDeposito()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public HLP.Entries.Model.Models.Gerais.DepositoModel getDeposito(int idDeposito)
        {

            try
            {
                return depositoRepository.GetDeposito(idDeposito: idDeposito);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public int saveDeposito(HLP.Entries.Model.Models.Gerais.DepositoModel objDeposito)
        {

            try
            {
                this.depositoRepository.Save(deposito: objDeposito);
                return (int)objDeposito.idDeposito;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public bool deleteDeposito(int idDeposito)
        {

            try
            {
                this.depositoRepository.Delete(idDeposito: idDeposito);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public int copyDeposito(int idDeposito)
        {

            try
            {
                return this.depositoRepository.Copy(idDeposito: idDeposito);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }
    }
}
