using HLP.Base.ClassesBases;
using HLP.Base.Static;
using HLP.Entries.Model.Models.Transportes;
using HLP.Entries.Model.Repository.Interfaces.Transportes;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Implementation.Transportes
{
    public class TransportadorRepository : ITransportadorReposiroty
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<TransportadorModel> regTransportadorAccessor;

        public void Save(TransportadorModel objTransportador)
        {
            if (objTransportador.idTransportador == null)
            {
                objTransportador.idTransportador = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                UndTrabalho.dbTransaction,
                "[dbo].[Proc_save_Transportador]",
                ParameterBase<TransportadorModel>.SetParameterValue(objTransportador));
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar(
                    UndTrabalho.dbTransaction,
                "[dbo].[Proc_update_Transportador]",
                ParameterBase<TransportadorModel>.SetParameterValue(objTransportador));
            }
        }

        public void Delete(int idTransportador)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar(
            UndTrabalho.dbTransaction,
           "[dbo].[Proc_delete_Transportador]",
            UserData.idUser,
            idTransportador);
        }

        public void Copy(TransportadorModel objTransportador)
        {
            objTransportador.idTransportador = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
            UndTrabalho.dbTransaction,
           "dbo.Proc_copy_Transportador",
            objTransportador.idTransportador);
        }

        public TransportadorModel GetTransportador(int idTransportador)
        {

            if (regTransportadorAccessor == null)
            {
                regTransportadorAccessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("dbo.Proc_sel_Transportador",
                                         new Parameters(UndTrabalho.dbPrincipal)
                                         .AddParameter<int>("idTransportador"),
                                         MapBuilder<TransportadorModel>.MapAllProperties()
                                         .DoNotMap(i => i.status).Build());
            }

            return regTransportadorAccessor.Execute(idTransportador).FirstOrDefault();
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
