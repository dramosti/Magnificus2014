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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_Fabricante" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_Fabricante.svc or wcf_Fabricante.svc.cs at the Solution Explorer and start debugging.

    public class wcf_Fabricante : Iwcf_Fabricante
    {
        [Inject]
        public IFabricanteRepository fabricanteRepository { get; set; }

        public wcf_Fabricante()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public FabricanteModel GetObject(int id)
        {
            try
            {
                return this.fabricanteRepository.GetFabricante(idFabricante: id);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public int SaveObject(FabricanteModel obj)
        {
            try
            {
                fabricanteRepository.Save(fabricante: obj);
                return obj.idFabricante ?? 0;
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
                fabricanteRepository.Delete(idFabricante: id);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public FabricanteModel CopyObject(int id)
        {
            try
            {
                //IMPLEMENTAR COPY
                return this.GetObject(id:
                    this.fabricanteRepository.Copy(idFabricante: id));
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }

}
