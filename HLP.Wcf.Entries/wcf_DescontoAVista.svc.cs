using HLP.Base.Static;
using HLP.Dependencies;
using HLP.Entries.Model.Models.Financeiro;
using HLP.Entries.Model.Repository.Interfaces.Financeiro;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_DescontoAVista" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_DescontoAVista.svc or wcf_DescontoAVista.svc.cs at the Solution Explorer and start debugging.

    public class wcf_DescontoAVista : Iwcf_DescontoAVista
    {
        [Inject]
        public IDescontos_AvistaRepository descontos_AvistaRepository { get; set; }

        public wcf_DescontoAVista()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public Descontos_AvistaModel GetObject(int id)
        {
            try
            {
                return this.descontos_AvistaRepository.GetDesconto(idDescontosAvista: id);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw;
            }
        }

        public int SaveObject(Descontos_AvistaModel obj)
        {
            try
            {
                descontos_AvistaRepository.Save(desconto: obj);
                return (int)obj.idDescontosAvista;
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
                descontos_AvistaRepository.Delete(idDescontosAvista: id);
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
                return this.descontos_AvistaRepository.Copy(idDescontosAvista: id);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }

}
