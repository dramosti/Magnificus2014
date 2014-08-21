using HLP.Base.ClassesBases;
using HLP.Base.Static;
using HLP.Entries.Model.Models;
using HLP.Entries.Model.Models.Comercial;
using HLP.Entries.Model.Repository.Interfaces.Comercial;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Implementation.Comercial
{
    public class ProdutoRepository : IProdutoRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<ProdutoModel> regProduToAccessor;

        private DataAccessor<ProdutoModel> regProdutoByTypeAccessor;

        public ProdutoModel GetProduto(int idProduto)
        {

            if (regProduToAccessor == null)
            {
                regProduToAccessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("dbo.Proc_sel_produto",
                                     new Parameters(UndTrabalho.dbPrincipal)
                                    .AddParameter<int>("idProduto"),
                                    this.ProdutoMapping());
            }

            return regProduToAccessor.Execute(idProduto).FirstOrDefault();
        }

        public void Save(ProdutoModel produto)
        {
            if (produto.idProduto == null)
            {
                produto.idProduto = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                "[dbo].[Proc_save_produto]",
                ParameterBase<ProdutoModel>.SetParameterValue(produto));
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar(
                "[dbo].[Proc_update_Produto]",
                ParameterBase<ProdutoModel>.SetParameterValue(produto));
            }

        }

        public void Delete(int idProduto)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar(
            UndTrabalho.dbTransaction,
            "[dbo].[Proc_delete_Produto]",
            UserData.idUser,
            idProduto);
        }

        public void Copy(ProdutoModel produto)
        {
            produto.idProduto = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                                UndTrabalho.dbTransaction,
                                "dbo.Proc_copy_produto",
                                produto.idProduto);
        }

        public List<ProdutoModel> GetByProdutoType(int idTipoProduto)
        {
            if (regProdutoByTypeAccessor == null)
            {
                regProdutoByTypeAccessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor("SELECT * FROM Produto WHERE idTipoProduto = @idTipoProduto",
                                  new Parameters(UndTrabalho.dbPrincipal)
                                    .AddParameter<int>("idTipoProduto"),
                                  this.ProdutoMapping());
            }


            return regProdutoByTypeAccessor.Execute(idTipoProduto).ToList();
        }

        public List<ProdutoModel> GetAll()
        {
            if (regProdutoByTypeAccessor == null)
            {
                regProdutoByTypeAccessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor("SELECT * FROM Produto",
                                  new Parameters(UndTrabalho.dbPrincipal),
                                  this.ProdutoMapping());
            }
            return regProdutoByTypeAccessor.Execute().ToList();
        }

        public object GetStCustoProduto(int idProduto)
        {
            DbCommand command = UndTrabalho.dbPrincipal.GetSqlStringCommand(string.Format(
                format: "select stCusto from Produto where idProduto = '{0}'", arg0: idProduto));

            return UndTrabalho.dbPrincipal.ExecuteScalar(command);
        }

        public decimal? GetValorCompraProduto(int idProduto)
        {
            DbCommand command = UndTrabalho.dbPrincipal.GetSqlStringCommand(string.Format(
                format: "select vCompra from Produto where idProduto = '{0}'", arg0: idProduto));

            return UndTrabalho.dbPrincipal.ExecuteScalar(command) as decimal?;
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

        private IRowMapper<ProdutoModel> ProdutoMapping()
        {
            return MapBuilder<ProdutoModel>.MapAllProperties()
                .DoNotMap(i => i.status)
                .DoNotMap(i => i.IsService)
                .DoNotMap(i => i.idSite)
                .DoNotMap(i => i.objDeposito)
                .DoNotMap(i => i.objTipoProduto)
                .Build();
        }

    }
}
