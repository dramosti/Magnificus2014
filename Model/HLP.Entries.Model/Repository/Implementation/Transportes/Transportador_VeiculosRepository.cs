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
    public class Transportador_VeiculosRepository : ITransportador_VeiculosRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Transportador_VeiculosModel> regAcessor;

        public void Save(Transportador_VeiculosModel objTransportador_Veiculos)
        {
            if (objTransportador_Veiculos.idTransportadorVeiculo == null)
            {
                objTransportador_Veiculos.idTransportadorVeiculo = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                    UndTrabalho.dbTransaction,
               "[dbo].[Proc_save_Transportador_Veiculos]",
                ParameterBase<Transportador_VeiculosModel>.SetParameterValue(objTransportador_Veiculos));
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar(
                          UndTrabalho.dbTransaction,
                     "[dbo].[Proc_update_Transportador_Veiculos]",
                     ParameterBase<Transportador_VeiculosModel>.SetParameterValue(objTransportador_Veiculos));
            }
        }

        public void Delete(int idTransportadorVeiculo)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar(
                      UndTrabalho.dbTransaction,
                "[dbo].[Proc_delete_Transportador_Veiculos]",
                  UserData.idUser,
                  idTransportadorVeiculo);
        }

        public void DeletePorTransportador(int idTransportador)
        {
            UndTrabalho.dbPrincipal.ExecuteNonQuery(
                      UndTrabalho.dbTransaction,
                System.Data.CommandType.Text,
              "DELETE Transportador_Veiculos WHERE idTransportador = " + idTransportador);
        }

        public void Copy(Transportador_VeiculosModel objTransportador_Veiculos)
        {
            objTransportador_Veiculos.idTransportadorVeiculo = null;
            objTransportador_Veiculos.idTransportadorVeiculo = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                                           UndTrabalho.dbTransaction,
                                           "[dbo].[Proc_save_Transportador_Veiculos]",
        ParameterBase<Transportador_VeiculosModel>.SetParameterValue(objTransportador_Veiculos));
        }

        public Transportador_VeiculosModel GetTransportador_Veiculos(int idTransportadorVeiculo)
        {
            if (regAcessor == null)
            {
                regAcessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("[dbo].[Proc_sel_Transportador_Veiculos]",
                   new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idTransportadorVeiculo"),
                   MapBuilder<Transportador_VeiculosModel>.MapAllProperties().DoNotMap(i => i.status).Build());
            }
            return regAcessor.Execute(idTransportadorVeiculo).FirstOrDefault();
        }

        public List<Transportador_VeiculosModel> GetAllTransportador_Veiculos(int idTransportador)
        {
            DataAccessor<Transportador_VeiculosModel> reg = UndTrabalho.dbPrincipal.CreateSqlStringAccessor
            ("SELECT * FROM Transportador_Veiculos WHERE idTransportador = @idTransportador", new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idTransportador"),
            MapBuilder<Transportador_VeiculosModel>.MapAllProperties().DoNotMap(i => i.status).Build());

            return reg.Execute(idTransportador).ToList();
        }
    }
}
