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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_Cargo" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_Cargo.svc or wcf_Cargo.svc.cs at the Solution Explorer and start debugging.

    public class wcf_Cargo : Iwcf_Cargo
    {
        [Inject]
        public ICargoRepository cargoRepository { get; set; }

        public wcf_Cargo()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public CargoModel GetObject(int id)
        {
            try
            {
                return this.cargoRepository.GetCargo(idCargo: id);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public int SaveObject(CargoModel obj)
        {
            try
            {
                cargoRepository.Save(cargo: obj);
                return obj.idCargo ?? 0;
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
                cargoRepository.Delete(idCargo: id);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public CargoModel CopyObject(int id)
        {
            try
            {
                return this.GetObject(id:
                    this.cargoRepository.Copy(idCargo: id));
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }

}
