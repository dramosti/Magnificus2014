using HLP.Base.Static;
using HLP.Dependencies;
using HLP.Entries.Model.Models.RecursosHumanos;
using HLP.Entries.Model.Repository.Interfaces.RecursosHumanos;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_Setor" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_Setor.svc or wcf_Setor.svc.cs at the Solution Explorer and start debugging.

    public class wcf_Setor : Iwcf_Setor
    {
        [Inject]
        public ISetorRepository setorRepository { get; set; }

        public wcf_Setor()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public SetorModel GetObject(int id)
        {
            try
            {
                return this.setorRepository.GetSetor(idSetor: id);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public int SaveObject(SetorModel obj)
        {
            try
            {
                setorRepository.Save(setor: obj);
                return obj.idSetor ?? 0;
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
                setorRepository.Delete(idSetor: id);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public SetorModel CopyObject(int id)
        {
            try
            {
                return this.GetObject(id:
                    this.setorRepository.Copy(idSetor: id));
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }

}
