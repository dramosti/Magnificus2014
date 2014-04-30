using HLP.Base.Static;
using HLP.Dependencies;
using HLP.Entries.Model.Models.Transportes;
using HLP.Entries.Model.Repository.Interfaces.Transportes;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_CondicaoEntrega" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_CondicaoEntrega.svc or wcf_CondicaoEntrega.svc.cs at the Solution Explorer and start debugging.

    public class wcf_CondicaoEntrega : Iwcf_CondicaoEntrega
    {
        [Inject]
        public ICondicoes_entregaRepository condicaoEntrega { get; set; }

        public wcf_CondicaoEntrega()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public Condicoes_entregaModel GetObject(int id)
        {
            try
            {
                return this.condicaoEntrega.GetCondicao(idCondicaoEntrega: id);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public int SaveObject(Condicoes_entregaModel obj)
        {
            try
            {
                condicaoEntrega.Save(condicao: obj);
                return obj.idCondicaoEntrega ?? 0;
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
                condicaoEntrega.Delete(idCondicaoEntrega: id);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public Condicoes_entregaModel CopyObject(int id)
        {
            try
            {
                return this.GetObject(id:
                    this.condicaoEntrega.Copy(idCondicaoEntrega: id));
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }

}
