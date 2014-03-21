using HLP.Comum.Resources.Util;
using HLP.Dependencies;
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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_Rota" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_Rota.svc or wcf_Rota.svc.cs at the Solution Explorer and start debugging.
    public class wcf_Rota : Iwcf_Rota
    {
        [Inject]
        public IRotaRepository iRotaRepository { get; set; }
        [Inject]
        public IRota_pracaRepository iRota_pracaRepository { get; set; }

        public wcf_Rota()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public HLP.Entries.Model.Models.Transportes.RotaModel Save(HLP.Entries.Model.Models.Transportes.RotaModel objRota)
        {
            try
            {
                iRotaRepository.BeginTransaction();

                iRotaRepository.Save(objRota);

                foreach (var item in objRota.lRota_Praca)
                {
                    switch (item.status)
                    {
                        case HLP.Comum.Resources.RecursosBases.statusModel.criado:
                        case HLP.Comum.Resources.RecursosBases.statusModel.alterado:
                            item.idRota = (int)objRota.idRota;
                            iRota_pracaRepository.Save(item);
                            break;
                        case HLP.Comum.Resources.RecursosBases.statusModel.excluido:
                            iRota_pracaRepository.Delete(item);
                            break;
                    }
                }
                iRotaRepository.CommitTransaction();
                return objRota;
            }
            catch (Exception ex)
            {
                iRotaRepository.RollackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public bool Delete(int idRota)
        {
            try
            {
                iRotaRepository.BeginTransaction();
                iRota_pracaRepository.DeletePracasByRota(idRota);
                iRotaRepository.Delete(idRota);
                iRotaRepository.CommitTransaction();
                return true;

            }
            catch (Exception ex)
            {
                iRotaRepository.RollackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public HLP.Entries.Model.Models.Transportes.RotaModel Copy(HLP.Entries.Model.Models.Transportes.RotaModel objRota)
        {
            try
            {
                iRotaRepository.BeginTransaction();

                iRotaRepository.Copy(objRota);
                foreach (var item in objRota.lRota_Praca)
                {
                    item.idRota = (int)objRota.idRota;
                    item.idRotaPraca = null;
                    iRota_pracaRepository.Copy(item);
                }
                iRotaRepository.CommitTransaction();

                return this.GetObject((int)objRota.idRota);

            }
            catch (Exception ex)
            {
                iRotaRepository.RollackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public HLP.Entries.Model.Models.Transportes.RotaModel GetObject(int idRota)
        {
            try
            {
                HLP.Entries.Model.Models.Transportes.RotaModel objRet = iRotaRepository.GetRota(idRota);
                if (objRet != null)
                {
                    objRet.lRota_Praca = new Comum.Model.Models.ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Transportes.Rota_pracaModel>(iRota_pracaRepository.GetAllRota_Praca(idRota));
                }
                return objRet;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

    }
}
