using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Infrastructure;
using HLP.Comum.Infrastructure.Static;
using HLP.Entries.Model.Models.Transportes;
using HLP.Entries.Model.Repository.Interfaces.Transportes;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;

namespace HLP.Entries.Model.Repository.Implementation.Transportes
{
    public class RotaRepository : IRotaRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<RotaModel> regRotaAccessor;

        public void Save(RotaModel objRota)
        {
            if (objRota.idRota == null)
            {
                objRota.idRota = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                "[dbo].[Proc_save_Rota]",
                ParameterBase<RotaModel>.SetParameterValue(objRota));
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar(
                "[dbo].[Proc_update_Rota]",
                ParameterBase<RotaModel>.SetParameterValue(objRota));
            }
        }

        public void Delete(int idRota)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar(
            UndTrabalho.dbTransaction,
           "[dbo].[Proc_delete_Rota]",
            UserData.idUser,
            idRota);
        }

        public void Copy(RotaModel objRota)
        {
            objRota.idRota = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
            UndTrabalho.dbTransaction,
           "dbo.Proc_copy_Rota",
            objRota.idRota);
        }

        public RotaModel GetRota(int idRota)
        {

            if (regRotaAccessor == null)
            {
                regRotaAccessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("dbo.Proc_sel_Rota",
                                         new Parameters(UndTrabalho.dbPrincipal)
                                         .AddParameter<int>("idRota"),
                                         MapBuilder<RotaModel>.MapAllProperties().Build());
            }

            return regRotaAccessor.Execute(idRota).FirstOrDefault();
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
