using HLP.Comum.Resources.Util;
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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serviceDepartamento" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serviceDepartamento.svc or serviceDepartamento.svc.cs at the Solution Explorer and start debugging.
    public class serviceDepartamento : IserviceDepartamento
    {
        [Inject]
        public IDepartamentoRepository departamentoRepository { get; set; }

        public void DoWork()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }


        public DepartamentoModel getDepartamento(int idDepartamento)
        {
            try
            {
                return departamentoRepository.GetDepartamento(idDepartamento: idDepartamento);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public int saveDepartamento(DepartamentoModel objDepartamento)
        {
            try
            {
                this.departamentoRepository.Save(departamento: objDepartamento);
                return (int)objDepartamento.idDepartamento;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public bool deleteDepartamento(int idDepartamento)
        {
            try
            {
                this.departamentoRepository.Delete(idDepartamento: idDepartamento);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public int copyDepartamento(int idDepartamento)
        {
            try
            {
                return this.departamentoRepository.Copy(idDepartamento: idDepartamento);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }
}
