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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_Moeda" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_Moeda.svc or wcf_Moeda.svc.cs at the Solution Explorer and start debugging.

    public class wcf_Moeda : Iwcf_Moeda
    {
        [Inject]
        public IMoedaRepository moedaRepository { get; set; }

        public wcf_Moeda()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public MoedaModel GetObject(int id)
        {
            try
            {
                return this.moedaRepository.GetMoeda(idMoeda: id);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw;
            }
        }

        public int SaveObject(MoedaModel obj)
        {
            try
            {
                moedaRepository.Save(moeda: obj);
                return obj.idMoeda ?? 0;
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
                moedaRepository.Delete(idMoeda: id);
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
                return this.moedaRepository.Copy(idMoeda: id);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }

}
