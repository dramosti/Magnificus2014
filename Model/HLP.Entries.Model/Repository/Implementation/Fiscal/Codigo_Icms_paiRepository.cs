using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Entries.Model.Models.Fiscal;
using HLP.Entries.Model.Repository.Interfaces.Fiscal;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;
using HLP.Base.ClassesBases;
using HLP.Base.Static;

namespace HLP.Entries.Model.Repository.Implementation.Fiscal
{
    public class Codigo_Icms_paiRepository : ICodigo_Icms_paiRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Codigo_Icms_paiModel> regCodigo_Icms_paiAccessor;

        public void Save(Codigo_Icms_paiModel objCodigo_Icms_pai)
        {
            if (objCodigo_Icms_pai.idCodigoIcmsPai == null)
            {
                objCodigo_Icms_pai.idCodigoIcmsPai = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                    UndTrabalho.dbTransaction,
                "[dbo].[Proc_save_Codigo_Icms_pai]",
                ParameterBase<Codigo_Icms_paiModel>.SetParameterValue(objCodigo_Icms_pai));
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar(
                    UndTrabalho.dbTransaction,
                "[dbo].[Proc_update_Codigo_Icms_pai]",
                ParameterBase<Codigo_Icms_paiModel>.SetParameterValue(objCodigo_Icms_pai));
            }
        }

        public void Delete(Codigo_Icms_paiModel objCodigo_Icms_pai)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar(
            UndTrabalho.dbTransaction,
           "[dbo].[Proc_delete_Codigo_Icms_pai]",
            UserData.idUser,
            objCodigo_Icms_pai.idCodigoIcmsPai);
        }

        public void Copy(Codigo_Icms_paiModel objCodigo_Icms_pai)
        {
            objCodigo_Icms_pai.idCodigoIcmsPai = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
            UndTrabalho.dbTransaction,
           "dbo.Proc_copy_Codigo_Icms_pai",
            objCodigo_Icms_pai.idCodigoIcmsPai);
        }

        public Codigo_Icms_paiModel GetCodigo_Icms_pai(int idCodigoIcmsPai)
        {

            if (regCodigo_Icms_paiAccessor == null)
            {
                regCodigo_Icms_paiAccessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("dbo.Proc_sel_Codigo_Icms_pai",
                                         new Parameters(UndTrabalho.dbPrincipal)
                                         .AddParameter<int>("idCodigoIcmsPai"),
                                         MapBuilder<Codigo_Icms_paiModel>.MapAllProperties().DoNotMap(c => c.status).Build());
            }

            return regCodigo_Icms_paiAccessor.Execute(idCodigoIcmsPai).FirstOrDefault();
        }

        public void BeginTransaction()
        {
            UndTrabalho.BeginTransaction();
        }
        public void CommitTransaction()
        {
            UndTrabalho.CommitTransaction();
        }
        public void RollackTransaction()
        {
            UndTrabalho.RollBackTransaction();
        }
    }
}
