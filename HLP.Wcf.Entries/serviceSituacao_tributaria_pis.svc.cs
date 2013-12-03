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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serviceSituacao_tributaria_pis" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serviceSituacao_tributaria_pis.svc or serviceSituacao_tributaria_pis.svc.cs at the Solution Explorer and start debugging.
    public class serviceSituacao_tributaria_pis : IserviceSituacao_tributaria_pis
    {
        [Inject]
        public ISituacao_tributaria_pisRepository iSituacao_tributaria_pisRepository { get; set; }

        public serviceSituacao_tributaria_pis()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }




        public int Save(HLP.Entries.Model.Models.Fiscal.Situacao_tributaria_pisModel objModel)
        {
            try
            {
                iSituacao_tributaria_pisRepository.Save(objModel);
                return (int)objModel.idCSTPis;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public HLP.Entries.Model.Models.Fiscal.Situacao_tributaria_pisModel GetObjeto(int idObjeto)
        {
            try
            {

                return iSituacao_tributaria_pisRepository.GetStPis(idObjeto);

            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public bool Delete(HLP.Entries.Model.Models.Fiscal.Situacao_tributaria_pisModel objModel)
        {
            try
            {
                iSituacao_tributaria_pisRepository.Delete((int)objModel.idCSTPis);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public int Copy(HLP.Entries.Model.Models.Fiscal.Situacao_tributaria_pisModel objModel)
        {
            try
            {
                return iSituacao_tributaria_pisRepository.Copy((int)objModel.idCSTPis);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }
}
