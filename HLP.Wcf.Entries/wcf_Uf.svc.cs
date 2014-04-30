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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_Uf" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_Uf.svc or wcf_Uf.svc.cs at the Solution Explorer and start debugging.

    public class wcf_Uf : Iwcf_Uf
    {
        [Inject]
        public IUFRepository ufRepository { get; set; }

        public wcf_Uf()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public UFModel GetObject(int id)
        {
            try
            {
                return this.ufRepository.GetUF(idUF: id);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public int SaveObject(UFModel obj)
        {
            try
            {
                ufRepository.Save(uf: obj);
                return obj.idUF ?? 0;
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
                ufRepository.Delete(idUF: id);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public UFModel CopyObject(int id)
        {
            try
            {
                return this.GetObject(id:
                    this.ufRepository.Copy(idUF: id));
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }

}
