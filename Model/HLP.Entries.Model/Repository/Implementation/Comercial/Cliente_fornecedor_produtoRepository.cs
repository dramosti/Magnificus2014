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
    public class Cliente_fornecedor_produtoRepository : ICliente_fornecedor_produtoRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Cliente_fornecedor_produtoModel> regAcessor;

        public void Save(Cliente_fornecedor_produtoModel objCliente_fornecedor_produto)
        {
            if (objCliente_fornecedor_produto.idClienteFornecedorProduto == null)
            {
                objCliente_fornecedor_produto.idClienteFornecedorProduto = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                    UndTrabalho.dbTransaction,
               "[dbo].[Proc_save_Cliente_fornecedor_produto]",
                ParameterBase<Cliente_fornecedor_produtoModel>.SetParameterValue(objCliente_fornecedor_produto));
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar(
                    UndTrabalho.dbTransaction,
            "[dbo].[Proc_update_Cliente_fornecedor_produto]",
            ParameterBase<Cliente_fornecedor_produtoModel>.SetParameterValue(objCliente_fornecedor_produto));

            }

        }

        public void Delete(int idClienteFornecedorProduto)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar(
                UndTrabalho.dbTransaction,
                "[dbo].[Proc_delete_Cliente_fornecedor_produto]",
                  UserData.idUser,
                  idClienteFornecedorProduto);
        }

        public void DeletePorClienteFornecedor(int idClienteFornecedor)
        {
            UndTrabalho.dbPrincipal.ExecuteNonQuery(
                UndTrabalho.dbTransaction,
                System.Data.CommandType.Text,
              "DELETE Cliente_fornecedor_produto WHERE idClienteFornecedor = " + idClienteFornecedor);
        }

        public void Copy(Cliente_fornecedor_produtoModel objCliente_fornecedor_produto)
        {
            objCliente_fornecedor_produto.idClienteFornecedorProduto = null;
            objCliente_fornecedor_produto.idClienteFornecedorProduto = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                                           UndTrabalho.dbTransaction,
                                           "[dbo].[Proc_save_Cliente_fornecedor_produto]",
        ParameterBase<Cliente_fornecedor_produtoModel>.SetParameterValue(objCliente_fornecedor_produto));
        }

        public Cliente_fornecedor_produtoModel GetCliente_fornecedor_produto(int idClienteFornecedorProduto)
        {
            if (regAcessor == null)
            {
                regAcessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("[dbo].[Proc_sel_Cliente_fornecedor_produto]",
                   new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idClienteFornecedorProduto"),
                   MapBuilder<Cliente_fornecedor_produtoModel>.MapAllProperties().DoNotMap(i => i.status).Build());
            }
            return regAcessor.Execute(idClienteFornecedorProduto).FirstOrDefault();
        }

        public List<Cliente_fornecedor_produtoModel> GetAllCliente_fornecedor_produto(int idClienteFornecedor)
        {
            DataAccessor<Cliente_fornecedor_produtoModel> reg = UndTrabalho.dbPrincipal.CreateSqlStringAccessor
            ("SELECT * FROM Cliente_fornecedor_produto WHERE idClienteFornecedor = @idClienteFornecedor", new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idClienteFornecedor"),
            MapBuilder<Cliente_fornecedor_produtoModel>.MapAllProperties().DoNotMap(i => i.status).Build());

            return reg.Execute(idClienteFornecedor).ToList();
        }
    }
}
