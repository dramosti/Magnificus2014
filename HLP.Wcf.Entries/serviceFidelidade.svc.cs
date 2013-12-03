using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HLP.Comum.Resources.Util;
using HLP.Dependencies;
using HLP.Entries.Model.Repository.Interfaces.Crm;
using Ninject;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serviceFidelidade" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serviceFidelidade.svc or serviceFidelidade.svc.cs at the Solution Explorer and start debugging.
    public class serviceFidelidade : IserviceFidelidade
    {
        [Inject]
        public IFidelidadeRepository iFidelidadeRepository { get; set; }

        public serviceFidelidade()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public int Save(HLP.Entries.Model.Models.Crm.FidelidadeModel objModel)
        {

            try
            {
                iFidelidadeRepository.Save(objModel);
                return (int)objModel.idFidelidade;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public HLP.Entries.Model.Models.Crm.FidelidadeModel GetObjeto(int idObjeto)
        {
            try
            {
                return iFidelidadeRepository.GetFidelidade(idObjeto);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public bool Delete(HLP.Entries.Model.Models.Crm.FidelidadeModel objModel)
        {

            try
            {
                iFidelidadeRepository.Delete((int)objModel.idFidelidade);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public int Copy(HLP.Entries.Model.Models.Crm.FidelidadeModel objModel)
        {
            try
            {
                return iFidelidadeRepository.Copy((int)objModel.idFidelidade);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }
    }
}
