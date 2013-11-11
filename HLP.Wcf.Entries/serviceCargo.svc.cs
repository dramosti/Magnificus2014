using HLP.Entries.Model.Models.RecursosHumanos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HLP.Entries.Model.Repository.Interfaces.RecursosHumanos;
using HLP.Comum.Resources.Util;
using Ninject;
using HLP.Dependencies;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serviceCargo" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serviceCargo.svc or serviceCargo.svc.cs at the Solution Explorer and start debugging.
    public class serviceCargo : IserviceCargo
    {
        [Inject]
        public ICargoRepository cargoRepository { get; set; }

        public serviceCargo()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public CargoModel getCargo(int idCargo)
        {
            try
            {
                return cargoRepository.GetCargo(idCargo: idCargo);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw ex;
            }
        }

        public int saveCargo(CargoModel objCargo)
        {
            try
            {
                cargoRepository.Save(cargo: objCargo);
                return (int)objCargo.idCargo;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw ex;
            }
        }

        public bool delCargo(int idCargo)
        {
            try
            {
                cargoRepository.Delete(idCargo: idCargo);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                return false;
            }
        }
    }
}
