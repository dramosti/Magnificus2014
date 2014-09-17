using HLP.Base.Static;
using HLP.Dependencies;
using HLP.Entries.Model.Models.Contabil;
using HLP.Entries.Model.Repository.Implementation.Contabil;
using HLP.Entries.Model.Repository.Interfaces.Contabil;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_ClasseFinanceira" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_ClasseFinanceira.svc or wcf_ClasseFinanceira.svc.cs at the Solution Explorer and start debugging.

    public class wcf_ClasseFinanceira : Iwcf_ClasseFinanceira
    {
        [Inject]
        public IClasse_FinanceiraRepository repository { get; set; }

        public wcf_ClasseFinanceira()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public Classe_FinanceiraModel GetObject(int id)
        {
            try
            {
                //IMPLEMENTAR GET
                return this.repository.GetClasse_Financeira(idClasseFinanceira: id);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public int SaveObject(Classe_FinanceiraModel obj)
        {
            try
            {
                return repository.Save(obj);
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
                return repository.Delete(id);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public Classe_FinanceiraModel CopyObject(int id)
        {
            try
            {
                return this.repository.Copy(id);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }

}
