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
    public class Codigo_IcmsRepository : ICodigo_IcmsRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Codigo_IcmsModel> regAcessor;

        public void Save(Codigo_IcmsModel objCodigo_Icms)
        {
            if (objCodigo_Icms.idCodigoIcms == null)
            {
                objCodigo_Icms.idCodigoIcms = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                    UndTrabalho.dbTransaction,
               "[dbo].[Proc_save_Codigo_Icms]",
                ParameterBase<Codigo_IcmsModel>.SetParameterValue(objCodigo_Icms));
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar(
                    UndTrabalho.dbTransaction,
                    "[dbo].[Proc_update_Codigo_Icms]",
                    ParameterBase<Codigo_IcmsModel>.SetParameterValue(objCodigo_Icms));
            }
        }


        public void Delete(Codigo_IcmsModel objCodigo_Icms)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar(
                UndTrabalho.dbTransaction,
                "[dbo].[Proc_delete_Codigo_Icms]",
                  UserData.idUser,
                  objCodigo_Icms.idCodigoIcms);
        }

        public void DeleteCodigosByPai(int idCodigoIcmsPai)
        {
            UndTrabalho.dbPrincipal.ExecuteNonQuery(
                UndTrabalho.dbTransaction,
                System.Data.CommandType.Text,
              "DELETE Codigo_Icms WHERE idCodigoIcmsPai = " + idCodigoIcmsPai);
        }

        public void Copy(Codigo_IcmsModel objCodigo_Icms)
        {
            objCodigo_Icms.idCodigoIcms = null;
            objCodigo_Icms.idCodigoIcms = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                                           UndTrabalho.dbTransaction,
                                           "[dbo].[Proc_save_Codigo_Icms]",
        ParameterBase<Codigo_IcmsModel>.SetParameterValue(objCodigo_Icms));
        }

        public Codigo_IcmsModel GetCodigo_Icms(int idCodigoIcms)
        {
            if (regAcessor == null)
            {
                regAcessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("[dbo].[Proc_sel_Codigo_Icms]",
                   new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idCodigoIcms"),
                   MapBuilder<Codigo_IcmsModel>.MapAllProperties().DoNotMap(c => c.status).Build());
            }
            return regAcessor.Execute(idCodigoIcms).FirstOrDefault();
        }

        public Codigo_IcmsModel GetCodigo_IcmsByUf(int idCodigoIcmsPai, int idUf)
        {
            DataAccessor<Codigo_IcmsModel> reg = UndTrabalho.dbPrincipal.CreateSqlStringAccessor
            ("SELECT * FROM Codigo_Icms WHERE idCodigoIcmsPai = @idCodigoIcmsPai and idUf = @idUf",
            new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idCodigoIcmsPai").AddParameter<int>("idUf"),
            MapBuilder<Codigo_IcmsModel>.MapAllProperties().DoNotMap(c => c.status).Build());

            return reg.Execute(idCodigoIcmsPai, idUf).FirstOrDefault();
        }

        public List<Codigo_IcmsModel> GetAllCodigo_Icms(int idCodigoIcmsPai)
        {
            DataAccessor<Codigo_IcmsModel> reg = UndTrabalho.dbPrincipal.CreateSqlStringAccessor
            ("SELECT * FROM Codigo_Icms WHERE idCodigoIcmsPai = @idCodigoIcmsPai", new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idCodigoIcmsPai"),
            MapBuilder<Codigo_IcmsModel>.MapAllProperties().DoNotMap(c => c.status).Build());

            return reg.Execute(idCodigoIcmsPai).ToList();
        }
    }
}
