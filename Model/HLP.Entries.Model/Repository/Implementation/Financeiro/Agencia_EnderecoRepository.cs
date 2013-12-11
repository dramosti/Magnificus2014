using HLP.Comum.Infrastructure;
using HLP.Comum.Infrastructure.Static;
using HLP.Entries.Model.Models.Financeiro;
using HLP.Entries.Model.Repository.Interfaces.Financeiro;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Implementation.Financeiro
{
    public class Agencia_EnderecoRepository : IAgencia_EnderecoRepository
    {

        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Agencia_EnderecoModel> regAcessor;

        public void Save(Agencia_EnderecoModel objAgencia_Endereco)
        {
            if (objAgencia_Endereco.idEndereco == null)
            {
                objAgencia_Endereco.idEndereco = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                    UndTrabalho.dbTransaction,
               "[dbo].[Proc_save_Agencia_Endereco]",
                ParameterBase<Agencia_EnderecoModel>.SetParameterValue(objAgencia_Endereco));
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar(
                    UndTrabalho.dbTransaction,
            "[dbo].[Proc_update_Agencia_Endereco]",
            ParameterBase<Agencia_EnderecoModel>.SetParameterValue(objAgencia_Endereco));
            }
        }

        public void Delete(int idEnderecoAgencia)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar("[dbo].[Proc_delete_Agencia_Endereco]",
                UndTrabalho.dbTransaction,
                UserData.idUser,
                  idEnderecoAgencia);
        }

        public void DeletePorAgencia(int idAgencia)
        {
            UndTrabalho.dbPrincipal.ExecuteNonQuery(
                UndTrabalho.dbTransaction,
                System.Data.CommandType.Text,
              "DELETE Agencia_Endereco WHERE idAgencia = " + idAgencia);
        }

        public void Copy(Agencia_EnderecoModel objAgencia_Endereco)
        {
            objAgencia_Endereco.idEndereco = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                                           UndTrabalho.dbTransaction,
                                           "[dbo].[Proc_save_Agencia_Endereco]",
        ParameterBase<Agencia_EnderecoModel>.SetParameterValue(objAgencia_Endereco));
        }

        public Agencia_EnderecoModel GetAgencia_Endereco(int idEndereco)
        {
            if (regAcessor == null)
            {
                regAcessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("[dbo].[Proc_sel_Agencia_Endereco]",
                   new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idEndereco"),
                   MapBuilder<Agencia_EnderecoModel>.MapAllProperties()
                   .DoNotMap(c => c.enumTipoEndereco)
                   .DoNotMap(c => c.enumTipoLogradouro)
                   .DoNotMap(i => i.status).Build());
            }
            return regAcessor.Execute(idEndereco).FirstOrDefault();
        }

        public List<Agencia_EnderecoModel> GetAllAgencia_Endereco(int idAgencia)
        {
            DataAccessor<Agencia_EnderecoModel> reg = UndTrabalho.dbPrincipal.CreateSqlStringAccessor
            ("SELECT * FROM Agencia_Endereco WHERE idAgencia = @idAgencia", new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idAgencia"),
            MapBuilder<Agencia_EnderecoModel>.MapAllProperties()
            .DoNotMap(c => c.enumTipoEndereco)
                   .DoNotMap(c => c.enumTipoLogradouro)
            .DoNotMap(i => i.status).Build());

            return reg.Execute(idAgencia).ToList();
        }

    }
}
