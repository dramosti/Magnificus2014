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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_ClassificacaoFiscal" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_ClassificacaoFiscal.svc or wcf_ClassificacaoFiscal.svc.cs at the Solution Explorer and start debugging.

    public class wcf_ClassificacaoFiscal : Iwcf_ClassificacaoFiscal
    {
        [Inject]
        public IClassificacao_fiscalRepository classificacao_FiscalRepository { get; set; }

        public wcf_ClassificacaoFiscal()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public Classificacao_fiscalModel GetObject(int id)
        {
            try
            {
                //IMPLEMENTAR GET
                return this.classificacao_FiscalRepository.GetClassificacao(idClassificacaoFiscal: id);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public int SaveObject(Classificacao_fiscalModel obj)
        {
            try
            {
                classificacao_FiscalRepository.Save(classificacao: obj);
                return obj.idClassificacaoFiscal ?? 0;
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
                classificacao_FiscalRepository.Delete(idClassificacaoFiscal: id);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public Classificacao_fiscalModel CopyObject(int id)
        {
            try
            {
                return this.GetObject(id:
                    this.classificacao_FiscalRepository.Copy(idClassificacaoFiscal: id));
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }

}
