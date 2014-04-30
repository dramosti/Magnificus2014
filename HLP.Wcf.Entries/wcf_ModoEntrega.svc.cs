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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_ModoEntrega" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_ModoEntrega.svc or wcf_ModoEntrega.svc.cs at the Solution Explorer and start debugging.

    public class wcf_ModoEntrega : Iwcf_ModoEntrega
    {
        [Inject]
        public IModos_entregaRepository modos_EntregaRepository { get; set; }

        public wcf_ModoEntrega()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public Modos_entregaModel GetObject(int id)
        {
            try
            {
                return this.modos_EntregaRepository.GetModo(idModosEntrega: id);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public int SaveObject(Modos_entregaModel obj)
        {
            try
            {
                modos_EntregaRepository.Save(modo: obj);
                return obj.idModosEntrega ?? 0;
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
                modos_EntregaRepository.Delete(idModosEntrega: id);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public Modos_entregaModel CopyObject(int id)
        {
            try
            {
                return this.GetObject(id:
                    this.modos_EntregaRepository.Copy(idModosEntrega: id));
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }

}
