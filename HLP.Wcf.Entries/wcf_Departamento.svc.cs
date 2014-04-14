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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_Departamento" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_Departamento.svc or wcf_Departamento.svc.cs at the Solution Explorer and start debugging.

    public class wcf_Departamento : Iwcf_Departamento
    {
        [Inject]
        public IDepartamentoRepository departamentoRepository { get; set; }

        public wcf_Departamento()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public DepartamentoModel GetObject(int id)
        {
            try
            {
                return this.departamentoRepository.GetDepartamento(idDepartamento: id);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw;
            }
        }

        public int SaveObject(DepartamentoModel obj)
        {
            try
            {
                departamentoRepository.Save(departamento: obj);
                return obj.idDepartamento ?? 0;
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
                departamentoRepository.Delete(idDepartamento: id);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public int CopyObject(int id)
        {
            try
            {
                return this.departamentoRepository.Copy(idDepartamento: id);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }

}
