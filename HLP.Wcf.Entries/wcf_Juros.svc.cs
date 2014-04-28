using HLP.Base.Static;
using HLP.Dependencies;
using HLP.Entries.Model.Models.Comercial;
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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_Juros" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_Juros.svc or wcf_Juros.svc.cs at the Solution Explorer and start debugging.

    public class wcf_Juros : Iwcf_Juros
    {
        [Inject]
        public IJurosRepository jurosRepository { get; set; }

        public wcf_Juros()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public JurosModel GetObject(int id)
        {
            try
            {
                return this.jurosRepository.GetJuros(idJuros: id);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public int SaveObject(JurosModel obj)
        {
            try
            {
                jurosRepository.Save(juros: obj);
                return obj.idJuros ?? 0;
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
                jurosRepository.Delete(idJuros: id);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public JurosModel CopyObject(int id)
        {
            try
            {
                return this.GetObject(id:
                    this.jurosRepository.Copy(idJuros: id));
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }

}
