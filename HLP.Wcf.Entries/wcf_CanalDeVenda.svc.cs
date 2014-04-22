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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_CanalDeVenda" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_CanalDeVenda.svc or wcf_CanalDeVenda.svc.cs at the Solution Explorer and start debugging.

    public class wcf_CanalDeVenda : Iwcf_CanalDeVenda
    {
        [Inject]
        public ICanal_vendaRepository canal_VendaRepository { get; set; }

        public wcf_CanalDeVenda()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public Canal_vendaModel GetObject(int id)
        {
            try
            {
                return this.canal_VendaRepository.GetCanal(
                    idCanalVenda: id);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw;
            }
        }

        public int SaveObject(Canal_vendaModel obj)
        {
            try
            {
                this.canal_VendaRepository.Save(canal: obj);
                return obj.idCanalVenda ?? 0;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw;
            }
        }

        public bool DeleteObject(int id)
        {
            try
            {
                canal_VendaRepository.Delete(idCanalVenda: id);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                return false;
            }
        }

        public int CopyObject(int id)
        {
            try
            {
                return this.canal_VendaRepository.Copy(idCanalVenda: id);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }


}
