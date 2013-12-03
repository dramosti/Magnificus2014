using HLP.Comum.Infrastructure;
using HLP.Comum.Infrastructure.Static;
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
    public class Funcionario_Comissao_ProdutoRepository : IFuncionario_Comissao_ProdutoRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Funcionario_Comissao_ProdutoModel> regAcessor;

        public void Save(Funcionario_Comissao_ProdutoModel objFuncionario_Comissao_Produto)
        {
            if (objFuncionario_Comissao_Produto.idFuncionarioComissaoProduto == null)
            {
                objFuncionario_Comissao_Produto.idFuncionarioComissaoProduto = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                    UndTrabalho.dbTransaction,
               "[dbo].[Proc_save_Funcionario_Comissao_Produto]",
                ParameterBase<Funcionario_Comissao_ProdutoModel>.SetParameterValue(objFuncionario_Comissao_Produto));
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar(
                UndTrabalho.dbTransaction,
            "[dbo].[Proc_update_Funcionario_Comissao_Produto]",
            ParameterBase<Funcionario_Comissao_ProdutoModel>.SetParameterValue(objFuncionario_Comissao_Produto));
            }
        }

        public void Delete(Funcionario_Comissao_ProdutoModel objFuncionario_Comissao_Produto)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar(
                UndTrabalho.dbTransaction,
                "[dbo].[Proc_delete_Funcionario_Comissao_Produto]",
                  UserData.idUser,
                  objFuncionario_Comissao_Produto.idFuncionarioComissaoProduto);
        }

        public void Delete(int idFuncionario)
        {
            UndTrabalho.dbPrincipal.ExecuteNonQuery(
                UndTrabalho.dbTransaction,
                System.Data.CommandType.Text,
              "DELETE Funcionario_Comissao_Produto WHERE idFuncionario = " + idFuncionario);
        }

        public void Copy(Funcionario_Comissao_ProdutoModel objFuncionario_Comissao_Produto)
        {
            objFuncionario_Comissao_Produto.idFuncionarioComissaoProduto = null;
            objFuncionario_Comissao_Produto.idFuncionarioComissaoProduto = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                                           UndTrabalho.dbTransaction,
                                           "[dbo].[Proc_save_Funcionario_Comissao_Produto]",
        ParameterBase<Funcionario_Comissao_ProdutoModel>.SetParameterValue(objFuncionario_Comissao_Produto));
        }

        public Funcionario_Comissao_ProdutoModel GetFuncionario_Comissao_Produto(int idFuncionarioComissaoProduto)
        {
            if (regAcessor == null)
            {
                regAcessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("[dbo].[Proc_sel_Funcionario_Comissao_Produto]",
                   new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idFuncionarioComissaoProduto"),
                   MapBuilder<Funcionario_Comissao_ProdutoModel>.MapAllProperties().DoNotMap(i => i.status).Build());
            }
            return regAcessor.Execute(idFuncionarioComissaoProduto).FirstOrDefault();
        }

        public List<Funcionario_Comissao_ProdutoModel> GetAllFuncionario_Comissao_Produto(int idFuncionario)
        {
            DataAccessor<Funcionario_Comissao_ProdutoModel> reg = UndTrabalho.dbPrincipal.CreateSqlStringAccessor
            ("SELECT * FROM Funcionario_Comissao_Produto WHERE idFuncionario = @idFuncionario", new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idFuncionario"),
            MapBuilder<Funcionario_Comissao_ProdutoModel>.MapAllProperties().DoNotMap(i => i.status).Build());

            return reg.Execute(idFuncionario).ToList();
        }
    }
}
