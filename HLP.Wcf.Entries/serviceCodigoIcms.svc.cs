using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HLP.Comum.Resources.Util;
using HLP.Dependencies;
using HLP.Entries.Model.Repository.Interfaces.Fiscal;
using Ninject;
using HLP.Base.EnumsBases;
using HLP.Base.ClassesBases;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serviceCodigoIcms" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serviceCodigoIcms.svc or serviceCodigoIcms.svc.cs at the Solution Explorer and start debugging.
    public class serviceCodigoIcms : IserviceCodigoIcms
    {

        [Inject]
        public ICodigo_Icms_paiRepository iCodigo_Icms_paiRepository { get; set; }
        [Inject]
        public ICodigo_IcmsRepository iCodigo_IcmsRepository { get; set; }

        public serviceCodigoIcms()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public HLP.Entries.Model.Models.Fiscal.Codigo_Icms_paiModel Save(HLP.Entries.Model.Models.Fiscal.Codigo_Icms_paiModel objModel)
        {

            try
            {
                iCodigo_Icms_paiRepository.BeginTransaction();
                iCodigo_Icms_paiRepository.Save(objModel);
                foreach (var item in objModel.lCodigo_IcmsModel)
                {
                    switch (item.status)
                    {
                        case statusModel.criado:
                        case statusModel.alterado:
                            item.idCodigoIcmsPai = (int) objModel.idCodigoIcmsPai;
                            iCodigo_IcmsRepository.Save(item);
                            break;
                        case statusModel.excluido:
                            iCodigo_IcmsRepository.Delete(item);
                            break;
                    }
                }
                iCodigo_Icms_paiRepository.CommitTransaction();
                return objModel;

            }
            catch (Exception ex)
            {
                iCodigo_Icms_paiRepository.RollackTransaction();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public HLP.Entries.Model.Models.Fiscal.Codigo_Icms_paiModel GetObjeto(int idObjeto)
        {
            try
            {
                HLP.Entries.Model.Models.Fiscal.Codigo_Icms_paiModel objret = iCodigo_Icms_paiRepository.GetCodigo_Icms_pai(idObjeto);
                if (objret != null)
                {
                    objret.lCodigo_IcmsModel = new ObservableCollectionBaseCadastros<HLP.Entries.Model.Models.Fiscal.Codigo_IcmsModel>(iCodigo_IcmsRepository.GetAllCodigo_Icms(idObjeto));
                }
                return objret;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public bool Delete(HLP.Entries.Model.Models.Fiscal.Codigo_Icms_paiModel objModel)
        {
            try
            {
                iCodigo_Icms_paiRepository.BeginTransaction();
                iCodigo_IcmsRepository.DeleteCodigosByPai((int)objModel.idCodigoIcmsPai);
                iCodigo_Icms_paiRepository.Delete(objModel);
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

        public HLP.Entries.Model.Models.Fiscal.Codigo_Icms_paiModel Copy(HLP.Entries.Model.Models.Fiscal.Codigo_Icms_paiModel objModel)
        {
            try
            {
                //objModel = this.GetObjeto(1064);
                iCodigo_Icms_paiRepository.BeginTransaction();

               

                iCodigo_Icms_paiRepository.Copy(objModel);
                foreach (var item in objModel.lCodigo_IcmsModel)
                {
                    item.idCodigoIcmsPai = (int)objModel.idCodigoIcmsPai;
                    item.idCodigoIcms = null;
                    iCodigo_IcmsRepository.Save(item);
                }
                iCodigo_Icms_paiRepository.CommitTransaction();

                return this.GetObjeto((int)objModel.idCodigoIcmsPai);

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
