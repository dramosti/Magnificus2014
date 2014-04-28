using HLP.Base.Static;
using HLP.Dependencies;
using HLP.Entries.Model.Models.Crm;
using HLP.Entries.Model.Repository.Interfaces.Crm;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_Fidelidade" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_Fidelidade.svc or wcf_Fidelidade.svc.cs at the Solution Explorer and start debugging.

    public class wcf_Fidelidade : Iwcf_Fidelidade
    {
        [Inject]
        public IFidelidadeRepository fidelidadeRepository { get; set; }

        public wcf_Fidelidade()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public FidelidadeModel GetObject(int id)
        {
            try
            {
                //IMPLEMENTAR GET
                return this.fidelidadeRepository.GetFidelidade(idFidelidade: id);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public int SaveObject(FidelidadeModel obj)
        {
            try
            {
                //IMPLEMENTAR SAVE
                fidelidadeRepository.Save(fidelidade: obj);
                return obj.idFidelidade ?? 0;
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
                //IMPLEMENTAR DELETE
                fidelidadeRepository.Delete(idFidelidade: id);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public FidelidadeModel CopyObject(int id)
        {
            try
            {
                //IMPLEMENTAR COPY
                return this.GetObject(id:
                    this.fidelidadeRepository.Copy(idFidelidade: id));
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }

}
