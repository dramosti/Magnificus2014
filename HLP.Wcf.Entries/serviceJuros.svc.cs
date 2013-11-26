using HLP.Comum.Resources.Util;
using HLP.Dependencies;
using HLP.Entries.Model.Repository.Interfaces.Comercial;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serviceJuros" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serviceJuros.svc or serviceJuros.svc.cs at the Solution Explorer and start debugging.
    public class serviceJuros : IserviceJuros
    {
        [Inject]
        public IJurosRepository jurosRepository { get; set; }

        public serviceJuros()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public HLP.Entries.Model.Models.Comercial.JurosModel getJuros(int idJuros)
        {

            try
            {
                return this.jurosRepository.GetJuros(idJuros: idJuros);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public int saveJuros(HLP.Entries.Model.Models.Comercial.JurosModel objJuros)
        {

            try
            {
                this.jurosRepository.Save(juros: objJuros);
                return (int)objJuros.idJuros;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public bool deleteJuros(int idJuros)
        {

            try
            {
                this.jurosRepository.Delete(idJuros: idJuros);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public int copyJuros(int idJuros)
        {

            try
            {
                return this.jurosRepository.Copy(idJuros: idJuros);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }
    }
}
