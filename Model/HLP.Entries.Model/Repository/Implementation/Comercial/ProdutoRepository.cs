using HLP.Comum.Infrastructure;
using HLP.Comum.Infrastructure.Static;
using HLP.Entries.Model.Models;
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
                                    MapBuilder<ProdutoModel>.MapAllProperties()
                                    .DoNotMap(i => i.status)                                    
                                    .Build());
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
                                  MapBuilder<ProdutoModel>.MapAllProperties()
                                  .DoNotMap(i => i.status)
                                  .Build());
            }


            return regProdutoByTypeAccessor.Execute(idTipoProduto).ToList();
        }

        public List<ProdutoModel> GetAll()
        {
            if (regProdutoByTypeAccessor == null)
            {
                regProdutoByTypeAccessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor("SELECT * FROM Produto",
                                  new Parameters(UndTrabalho.dbPrincipal),
                                  MapBuilder<ProdutoModel>.MapAllProperties()
                                  .DoNotMap(i => i.status)
                                  .Build());
            }
            return regProdutoByTypeAccessor.Execute().ToList();
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
