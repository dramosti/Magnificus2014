using HLP.Base.ClassesBases;
using HLP.Base.EnumsBases;
using HLP.Base.Static;
using HLP.Dependencies;
using HLP.Entries.Model.Models.Fiscal;
using HLP.Entries.Model.Repository.Interfaces.Fiscal;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_CodigoIcms" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_CodigoIcms.svc or wcf_CodigoIcms.svc.cs at the Solution Explorer and start debugging.

    public class wcf_CodigoIcms : Iwcf_CodigoIcms
    {
        [Inject]
        public ICodigo_Icms_paiRepository iCodigo_Icms_paiRepository { get; set; }
        [Inject]
        public ICodigo_IcmsRepository iCodigo_IcmsRepository { get; set; }

        public wcf_CodigoIcms()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public Codigo_Icms_paiModel GetObject(int id)
        {
            try
            {
                HLP.Entries.Model.Models.Fiscal.Codigo_Icms_paiModel objret = iCodigo_Icms_paiRepository.GetCodigo_Icms_pai(idCodigoIcmsPai: id);
                if (objret != null)
                {
                    objret.lCodigo_IcmsModel = new ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Fiscal.Codigo_IcmsModel>(iCodigo_IcmsRepository.GetAllCodigo_Icms(idCodigoIcmsPai: id));
                }
                return objret;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public Codigo_Icms_paiModel SaveObject(Codigo_Icms_paiModel obj)
        {
            try
            {
                iCodigo_Icms_paiRepository.BeginTransaction();
                iCodigo_Icms_paiRepository.Save(obj);
                foreach (var item in obj.lCodigo_IcmsModel)
                {
                    switch (item.status)
                    {
                        case statusModel.criado:
                        case statusModel.alterado:
                            item.idCodigoIcmsPai = (int)obj.idCodigoIcmsPai;
                            iCodigo_IcmsRepository.Save(item);
                            break;
                        case statusModel.excluido:
                            iCodigo_IcmsRepository.Delete(item);
                            break;
                    }
                }
                iCodigo_Icms_paiRepository.CommitTransaction();
                return obj;

            }
            catch (Exception ex)
            {
                iCodigo_Icms_paiRepository.RollackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public bool DeleteObject(int id)
        {
            try
            {
                iCodigo_Icms_paiRepository.BeginTransaction();
                iCodigo_IcmsRepository.DeleteCodigosByPai(id);
                iCodigo_Icms_paiRepository.Delete(id: id);
                iCodigo_Icms_paiRepository.CommitTransaction();
                return true;
            }
            catch (Exception ex)
            {
                iCodigo_Icms_paiRepository.RollackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public Codigo_Icms_paiModel CopyObject(Codigo_Icms_paiModel obj)
        {
            try
            {
                iCodigo_Icms_paiRepository.BeginTransaction();



                iCodigo_Icms_paiRepository.Copy(objCodigo_Icms_pai: obj);
                foreach (var item in obj.lCodigo_IcmsModel)
                {
                    item.idCodigoIcmsPai = obj.idCodigoIcmsPai ?? 0;
                    item.idCodigoIcms = null;
                    iCodigo_IcmsRepository.Save(item);
                }
                iCodigo_Icms_paiRepository.CommitTransaction();

                return this.GetObject(id: obj.idCodigoIcmsPai ?? 0);

            }
            catch (Exception ex)
            {
                iCodigo_Icms_paiRepository.RollackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }

}
