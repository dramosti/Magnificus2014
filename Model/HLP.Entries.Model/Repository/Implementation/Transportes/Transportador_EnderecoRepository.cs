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
    public class Transportador_EnderecoRepository : ITransportador_EnderecoRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Transportador_EnderecoModel> regAcessor;

        public void Save(Transportador_EnderecoModel objTransportador_Endereco)
        {
            if (objTransportador_Endereco.idEndereco == null)
            {
                objTransportador_Endereco.idEndereco = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                    UndTrabalho.dbTransaction,
               "[dbo].[Proc_save_Transportador_Endereco]",
                ParameterBase<Transportador_EnderecoModel>.SetParameterValue(objTransportador_Endereco));
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar(
                    UndTrabalho.dbTransaction,
                    "[dbo].[Proc_update_Transportador_Endereco]",
                    ParameterBase<Transportador_EnderecoModel>.SetParameterValue(objTransportador_Endereco));
            }
        }

        public void Delete(int idTransportadorEndereco)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar(
                UndTrabalho.dbTransaction,
                "[dbo].[Proc_delete_Transportador_Endereco]",
                  UserData.idUser,
                  idTransportadorEndereco);
        }

        public void DeletePorTransportador(int idTransportador)
        {
            UndTrabalho.dbPrincipal.ExecuteNonQuery(
                UndTrabalho.dbTransaction,
                System.Data.CommandType.Text,
              "DELETE Transportador_Endereco WHERE idTransportador = " + idTransportador);
        }

        public void Copy(Transportador_EnderecoModel objTransportador_Endereco)
        {
            objTransportador_Endereco.idEndereco = null;
            objTransportador_Endereco.idEndereco = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                                           UndTrabalho.dbTransaction,
                                           "[dbo].[Proc_save_Transportador_Endereco]",
        ParameterBase<Transportador_EnderecoModel>.SetParameterValue(objTransportador_Endereco));
        }

        public Transportador_EnderecoModel GetTransportador_Endereco(int idEndereco)
        {
            if (regAcessor == null)
            {
                regAcessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("[dbo].[Proc_sel_Transportador_Endereco]",
                   new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idEndereco"),
                   MapBuilder<Transportador_EnderecoModel>.MapAllProperties()
                   .DoNotMap(c => c.enumTipoEndereco)
                   .DoNotMap(c => c.enumTipoLogradouro)
                   .DoNotMap(i => i.status).Build());
            }
            return regAcessor.Execute(idEndereco).FirstOrDefault();
        }

        public List<Transportador_EnderecoModel> GetAllTransportador_Endereco(int idTransportador)
        {
            DataAccessor<Transportador_EnderecoModel> reg = UndTrabalho.dbPrincipal.CreateSqlStringAccessor
            ("SELECT * FROM Transportador_Endereco WHERE idTransportador = @idTransportador", new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idTransportador"),
            MapBuilder<Transportador_EnderecoModel>.MapAllProperties()
            .DoNotMap(c => c.enumTipoEndereco)
            .DoNotMap(c => c.enumTipoLogradouro)
            .DoNotMap(i => i.status).Build());

            return reg.Execute(idTransportador).ToList();
        }
    }
}
