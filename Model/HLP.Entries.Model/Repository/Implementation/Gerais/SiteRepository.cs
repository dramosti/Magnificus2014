using HLP.Base.ClassesBases;
using HLP.Base.Static;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.Model.Repository.Interfaces.Gerais;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Implementation.Gerais
{
    public class SiteRepository : ISiteRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<SiteModel> regSiteAccessor;

        private DataAccessor<SiteModel> regAllSiteAccessor;

        public void Save(SiteModel objSite)
        {
            if (objSite.idSite == null)
            {
                objSite.idSite = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                   UndTrabalho.dbTransaction,
                "[dbo].[Proc_save_Site]",
                ParameterBase<SiteModel>.SetParameterValue(objSite));
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar(
                    UndTrabalho.dbTransaction,
                "[dbo].[Proc_update_Site]",
                ParameterBase<SiteModel>.SetParameterValue(objSite));
            }
        }

        public void Delete(int idSite)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar(
            UndTrabalho.dbTransaction,
           "[dbo].[Proc_delete_Site]",
            UserData.idUser,
            idSite);
        }

        public void Copy(SiteModel objSite)
        {
            objSite.idSite = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
            UndTrabalho.dbTransaction,
           "dbo.Proc_copy_Site",
            objSite.idSite);
        }

        public SiteModel GetSite(int idSite)
        {

            if (regSiteAccessor == null)
            {
                regSiteAccessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("dbo.Proc_sel_Site",
                                         new Parameters(UndTrabalho.dbPrincipal)
                                         .AddParameter<int>("idSite"),
                                         MapBuilder<SiteModel>.MapAllProperties()
                                         .DoNotMap(i => i.status).Build());
            }

            return regSiteAccessor.Execute(idSite).FirstOrDefault();
        }

        public List<SiteModel> GetAll()
        {
            if (regAllSiteAccessor == null)
            {
                regAllSiteAccessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor("SELECT * FROM Site",
                                  MapBuilder<SiteModel>.MapAllProperties().DoNotMap(i => i.status).Build());
            }
            return regAllSiteAccessor.Execute().ToList();
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
