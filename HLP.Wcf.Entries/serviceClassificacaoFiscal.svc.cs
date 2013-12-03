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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serviceClassificacaoFiscal" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serviceClassificacaoFiscal.svc or serviceClassificacaoFiscal.svc.cs at the Solution Explorer and start debugging.
    public class serviceClassificacaoFiscal : IserviceClassificacaoFiscal
    {
        [Inject]
        public IClassificacao_fiscalRepository iClassificacao_fiscalRepository { get; set; }
        public serviceClassificacaoFiscal() 
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public int Save(HLP.Entries.Model.Models.Fiscal.Classificacao_fiscalModel objModel)
        {
            try
            {
                iClassificacao_fiscalRepository.Save(objModel);
                return (int)objModel.idClassificacaoFiscal;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        
        }

        public HLP.Entries.Model.Models.Fiscal.Classificacao_fiscalModel GetObjeto(int idObjeto)
        {
            try
            {
                return iClassificacao_fiscalRepository.GetClassificacao(idObjeto);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public bool Delete(HLP.Entries.Model.Models.Fiscal.Classificacao_fiscalModel objModel)
        {
            try
            {
                iClassificacao_fiscalRepository.Delete((int)objModel.idClassificacaoFiscal);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public int Copy(HLP.Entries.Model.Models.Fiscal.Classificacao_fiscalModel objModel)
        {
            try
            {
                return iClassificacao_fiscalRepository.Copy((int)objModel.idClassificacaoFiscal);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }
}
