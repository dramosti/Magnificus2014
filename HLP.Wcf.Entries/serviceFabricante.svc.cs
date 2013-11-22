using HLP.Comum.Resources.Util;
using HLP.Dependencies;
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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serviceFabricante" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serviceFabricante.svc or serviceFabricante.svc.cs at the Solution Explorer and start debugging.
    public class serviceFabricante : IserviceFabricante
    {
        [Inject]
        public IFabricanteRepository fabricanteRepository { get; set; }

        public serviceFabricante()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public HLP.Entries.Model.Models.Gerais.FabricanteModel getFabricante(int idFabricante)
        {

            try
            {
                return this.fabricanteRepository.GetFabricante(idFabricante: idFabricante);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public int saveFabricante(HLP.Entries.Model.Models.Gerais.FabricanteModel objFabricante)
        {

            try
            {
                this.fabricanteRepository.Save(fabricante: objFabricante);
                return (int)objFabricante.idFabricante;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public bool deleteFabricante(int idFabricante)
        {

            try
            {
                this.fabricanteRepository.Delete(idFabricante: idFabricante);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public int copyFabricante(int idFabricante)
        {

            try
            {
                return this.fabricanteRepository.Copy(idFabricante: idFabricante);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }
    }
}
