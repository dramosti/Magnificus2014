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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serviceMoeda" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serviceMoeda.svc or serviceMoeda.svc.cs at the Solution Explorer and start debugging.
    public class serviceMoeda : IserviceMoeda
    {
        [Inject]
        public IMoedaRepository moedaRepository { get; set; }

        public serviceMoeda()
        {

            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";

        }

        public HLP.Entries.Model.Models.Gerais.MoedaModel getMoeda(int idMoeda)
        {

            try
            {
                return this.moedaRepository.GetMoeda(idMoeda: idMoeda);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public int saveMoeda(HLP.Entries.Model.Models.Gerais.MoedaModel objMoeda)
        {

            try
            {
                this.moedaRepository.Save(moeda: objMoeda);
                return (int)objMoeda.idMoeda;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public bool deleteMoeda(int idMoeda)
        {

            try
            {
                this.moedaRepository.Delete(idMoeda: idMoeda);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public int copyMoeda(int idMoeda)
        {

            try
            {
                return this.moedaRepository.Copy(idMoeda: idMoeda);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }
    }
}
