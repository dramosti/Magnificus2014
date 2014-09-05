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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_UnidadeMedida" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_UnidadeMedida.svc or wcf_UnidadeMedida.svc.cs at the Solution Explorer and start debugging.
    public class wcf_UnidadeMedida : Iwcf_UnidadeMedida
    {
        [Inject]
        public IUnidade_medidaRepository unidade_medidaRepository { get; set; }

        public wcf_UnidadeMedida()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public Unidade_medidaModel GetObject(int id)
        {
            try
            {
                return this.unidade_medidaRepository.GetUnidade(idUnidadeMedida: id);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw;
            }
        }

        public int SaveObject(Unidade_medidaModel obj)
        {
            try
            {
                unidade_medidaRepository.Save(unidade: obj);
                return (int)obj.idUnidadeMedida;
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
                unidade_medidaRepository.Delete(idUnidadeMedida: id);
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
                return this.unidade_medidaRepository.Copy(idUnidadeMedida: id);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }
}
