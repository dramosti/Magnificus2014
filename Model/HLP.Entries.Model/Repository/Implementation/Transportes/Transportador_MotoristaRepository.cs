using HLP.Comum.Infrastructure;
using HLP.Comum.Infrastructure.Static;
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
    public class Transportador_MotoristaRepository : ITransportador_MotoristaRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Transportador_MotoristaModel> regAcessor;

        public void Save(Transportador_MotoristaModel objTransportador_Motorista)
        {
            if (objTransportador_Motorista.idTransportdorMotorista == null)
            {
                objTransportador_Motorista.idTransportdorMotorista = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                    UndTrabalho.dbTransaction,
               "[dbo].[Proc_save_Transportador_Motorista]",
                ParameterBase<Transportador_MotoristaModel>.SetParameterValue(objTransportador_Motorista));
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar(
                    UndTrabalho.dbTransaction,
                   "[dbo].[Proc_update_Transportador_Motorista]",
                   ParameterBase<Transportador_MotoristaModel>.SetParameterValue(objTransportador_Motorista));
            }
        }



        public void Delete(int idTransportadorMotorista)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar(
                UndTrabalho.dbTransaction,
                "[dbo].[Proc_delete_Transportador_Motorista]",
                  UserData.idUser,
                  idTransportadorMotorista);
        }

        public void DeletePorTransportador(int idTransportador)
        {
            UndTrabalho.dbPrincipal.ExecuteNonQuery(
                UndTrabalho.dbTransaction,
                System.Data.CommandType.Text,
              "DELETE Transportador_Motorista WHERE idTransportador = " + idTransportador);
        }

        public void Copy(Transportador_MotoristaModel objTransportador_Motorista)
        {
            objTransportador_Motorista.idTransportdorMotorista = null;
            objTransportador_Motorista.idTransportdorMotorista = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                                           UndTrabalho.dbTransaction,
                                           "[dbo].[Proc_save_Transportador_Motorista]",
        ParameterBase<Transportador_MotoristaModel>.SetParameterValue(objTransportador_Motorista));
        }

        public Transportador_MotoristaModel GetTransportador_Motorista(int idTransportdorMotorista)
        {
            if (regAcessor == null)
            {
                regAcessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("[dbo].[Proc_sel_Transportador_Motorista]",
                   new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idTransportdorMotorista"),
                   MapBuilder<Transportador_MotoristaModel>.MapAllProperties().DoNotMap(i => i.status).Build());
            }
            return regAcessor.Execute(idTransportdorMotorista).FirstOrDefault();
        }

        public List<Transportador_MotoristaModel> GetAllTransportador_Motorista(int idTransportador)
        {
            DataAccessor<Transportador_MotoristaModel> reg = UndTrabalho.dbPrincipal.CreateSqlStringAccessor
            ("SELECT * FROM Transportador_Motorista WHERE idTransportador = @idTransportador", new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idTransportador"),
            MapBuilder<Transportador_MotoristaModel>.MapAllProperties().DoNotMap(i => i.status).Build());

            return reg.Execute(idTransportador).ToList();
        }
    }
}
