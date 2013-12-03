using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Infrastructure;
using HLP.Comum.Infrastructure.Static;
using HLP.Entries.Model.Models.Fiscal;
using HLP.Entries.Model.Repository.Interfaces.Fiscal;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;

namespace HLP.Entries.Model.Repository.Implementation.Fiscal
{
    public class Carga_trib_media_st_icmsRepository : ICarga_trib_media_st_icmsRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Carga_trib_media_st_icmsModel> regCarga_trib_media_st_icmsAccessor;
        private DataAccessor<Carga_trib_media_st_icmsModel> regAllCarga_trib_media_st_icmsAccessor;

        public void Save(Carga_trib_media_st_icmsModel objCarga_trib_media_st_icms)
        {
            if (objCarga_trib_media_st_icms.idCargaTribMediaStIcms == null)
            {
                objCarga_trib_media_st_icms.idCargaTribMediaStIcms = (int)UndTrabalho.dbPrincipal.ExecuteScalar("dbo.Proc_save_Carga_trib_media_st_icms",
                ParameterBase<Carga_trib_media_st_icmsModel>.SetParameterValue(objCarga_trib_media_st_icms));
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar(
              "[dbo].[Proc_update_Carga_trib_media_st_icms]",
             ParameterBase<Carga_trib_media_st_icmsModel>.SetParameterValue(objCarga_trib_media_st_icms));
            }
        }

        public void Delete(int idCargaTribMediaStIcms)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar("dbo.Proc_delete_Carga_trib_media_st_icms",
                 UserData.idUser,
                 idCargaTribMediaStIcms);
        }

        public int Copy(int idCargaTribMediaStIcms)
        {
            return (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                      "dbo.Proc_copy_Carga_trib_media_st_icms",
                       idCargaTribMediaStIcms);
        }

        public Carga_trib_media_st_icmsModel GetCarga_trib_media_st_icms(int idCargaTribMediaStIcms)
        {
            if (regCarga_trib_media_st_icmsAccessor == null)
            {
                regCarga_trib_media_st_icmsAccessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("dbo.Proc_sel_Carga_trib_media_st_icms",
                                 new Parameters(UndTrabalho.dbPrincipal)
                                 .AddParameter<int>("idCargaTribMediaStIcms"),
                                 MapBuilder<Carga_trib_media_st_icmsModel>.MapAllProperties().DoNotMap(c=>c.status).Build());
            }

            return regCarga_trib_media_st_icmsAccessor.Execute(idCargaTribMediaStIcms).FirstOrDefault();
        }

        public List<Carga_trib_media_st_icmsModel> GetAllCarga_trib_media_st_icms()
        {
            if (regAllCarga_trib_media_st_icmsAccessor == null)
            {
                regAllCarga_trib_media_st_icmsAccessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor("SELECT * FROM Carga_trib_media_st_icms",
                                MapBuilder<Carga_trib_media_st_icmsModel>.MapAllProperties().DoNotMap(c => c.status).Build());
            }
            return regAllCarga_trib_media_st_icmsAccessor.Execute().ToList();
        }

        public Carga_trib_media_st_icmsModel GetCarga_trib_media_st_icmsByUf(int idUf)
        {
            DataAccessor<Carga_trib_media_st_icmsModel> reg = UndTrabalho.dbPrincipal.CreateSqlStringAccessor
               ("SELECT * FROM Carga_trib_media_st_icms c " +
                "where c.idUf = @idUf",
               new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idUf"),
               MapBuilder<Carga_trib_media_st_icmsModel>.MapAllProperties().DoNotMap(c => c.status).Build());
            return reg.Execute(idUf).FirstOrDefault();
        }
    }
}
