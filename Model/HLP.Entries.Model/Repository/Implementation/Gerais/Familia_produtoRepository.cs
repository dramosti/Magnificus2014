using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Infrastructure;
using HLP.Entries.Model.Models.Gerais;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;
using HLP.Comum.Infrastructure.Static;
using HLP.Entries.Model.Repository.Interfaces.Gerais;

namespace HLP.Entries.Model.Repository.Implementation.Gerais
{
    public class Familia_produtoRepository : IFamilia_ProdutoRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Familia_produtoModel> regFamiliaProdAccessor;

        public Familia_produtoModel GetFamilia_produto(int idFamiliaProduto)
        {
            Familia_produtoModel familia;
            if (regFamiliaProdAccessor == null)
            {
                regFamiliaProdAccessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("dbo.Proc_sel_familia_produto",
                                    new Parameters(UndTrabalho.dbPrincipal)
                                    .AddParameter<int>("idFamiliaProduto"),
                                    MapBuilder<Familia_produtoModel>.MapAllProperties().DoNotMap(c=>c.status).Build());
            }
            familia = regFamiliaProdAccessor.Execute(idFamiliaProduto).FirstOrDefault();
            return familia;
        }

        public void Save(Familia_produtoModel familia_produto)
        {
            try
            {

                if (familia_produto.idFamiliaProduto == null)
                {
                    familia_produto.idFamiliaProduto = (int)UndTrabalho.dbPrincipal.ExecuteScalar(UndTrabalho.dbTransaction,
                                        "dbo.Proc_save_familia_produto",
                                         ParameterBase<Familia_produtoModel>.SetParameterValue(familia_produto));
                }
                else
                {
                    familia_produto.idFamiliaProduto = (int)UndTrabalho.dbPrincipal.ExecuteScalar(UndTrabalho.dbTransaction,
                                          "dbo.Proc_update_Familia_produto",
                                           ParameterBase<Familia_produtoModel>.SetParameterValue(familia_produto));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Copy(Familia_produtoModel familia_produto)
        {
            try
            {
                familia_produto.idFamiliaProduto = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                    UndTrabalho.dbTransaction,
                           "dbo.Proc_copy_familia_produto",
                            familia_produto.idFamiliaProduto);
                return familia_produto.idFamiliaProduto.ToInt32();

            }
            catch (Exception)
            {
                throw;
            }

        }
        public void Delete(int idFamiliaProduto)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar(UndTrabalho.dbTransaction, "dbo.Proc_delete_Familia_produto",
                 UserData.idUser,
                 idFamiliaProduto);
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
