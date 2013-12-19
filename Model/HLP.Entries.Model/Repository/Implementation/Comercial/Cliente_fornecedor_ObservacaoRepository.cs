using HLP.Comum.Infrastructure;
using HLP.Comum.Infrastructure.Static;
using HLP.Entries.Model.Models.Comercial;
using HLP.Entries.Model.Repository.Interfaces.Comercial;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Implementation.Comercial
{
    public class Cliente_fornecedor_ObservacaoRepository : ICliente_Fornecedor_ObservacaoRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Cliente_Fornecedor_ObservacaoModel> regAcessor;

        public void Save(Cliente_Fornecedor_ObservacaoModel objCliente_Fornecedor_Observacao)
        {
            if (objCliente_Fornecedor_Observacao.idClienteFornecedorObservacao == null)
            {
                objCliente_Fornecedor_Observacao.idClienteFornecedorObservacao = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                    UndTrabalho.dbTransaction,
               "[dbo].[Proc_save_Cliente_Fornecedor_Observacao]",
                ParameterBase<Cliente_Fornecedor_ObservacaoModel>.SetParameterValue(objCliente_Fornecedor_Observacao));
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar(
                    UndTrabalho.dbTransaction,
                   "[dbo].[Proc_update_Cliente_Fornecedor_Observacao]",
                   ParameterBase<Cliente_Fornecedor_ObservacaoModel>.SetParameterValue(objCliente_Fornecedor_Observacao));
            }
        }


        public void Delete(int idClienteFornecedorObservacao)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar(
                UndTrabalho.dbTransaction,
                "[dbo].[Proc_delete_Cliente_Fornecedor_Observacao]",
                  UserData.idUser,
                  idClienteFornecedorObservacao);
        }

        public void DeletePorClienteFornecedor(int idClienteFornecedor)
        {
            UndTrabalho.dbPrincipal.ExecuteNonQuery(
                UndTrabalho.dbTransaction, System.Data.CommandType.Text,
              "DELETE Cliente_Fornecedor_Observacao WHERE idClienteFornecedor = " + idClienteFornecedor);
        }

        public void Copy(Cliente_Fornecedor_ObservacaoModel objCliente_Fornecedor_Observacao)
        {
            objCliente_Fornecedor_Observacao.idClienteFornecedorObservacao = null;
            objCliente_Fornecedor_Observacao.idClienteFornecedorObservacao = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                                           UndTrabalho.dbTransaction,
                                           "[dbo].[Proc_save_Cliente_Fornecedor_Observacao]",
        ParameterBase<Cliente_Fornecedor_ObservacaoModel>.SetParameterValue(objCliente_Fornecedor_Observacao));
        }

        public Cliente_Fornecedor_ObservacaoModel GetCliente_Fornecedor_Observacao(int idClienteFornecedorObservacao)
        {
            if (regAcessor == null)
            {
                regAcessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("[dbo].[Proc_sel_Cliente_Fornecedor_Observacao]",
                   new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idClienteFornecedorObservacao"),
                   MapBuilder<Cliente_Fornecedor_ObservacaoModel>.MapAllProperties().DoNotMap(c=>c.status).Build());
            }
            return regAcessor.Execute(idClienteFornecedorObservacao).FirstOrDefault();
        }

        public List<Cliente_Fornecedor_ObservacaoModel> GetAllCliente_Fornecedor_Observacao(int idClienteFornecedor)
        {
            DataAccessor<Cliente_Fornecedor_ObservacaoModel> reg = UndTrabalho.dbPrincipal.CreateSqlStringAccessor
            ("SELECT * FROM Cliente_Fornecedor_Observacao WHERE idClienteFornecedor = @idClienteFornecedor", new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idClienteFornecedor"),
            MapBuilder<Cliente_Fornecedor_ObservacaoModel>.MapAllProperties().DoNotMap(c => c.status).Build());

            return reg.Execute(idClienteFornecedor).ToList();
        }
    }
}
