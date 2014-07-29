using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Entries.Model.Models.Gerais;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;
using HLP.Entries.Model.Repository.Interfaces.Gerais;
using HLP.Base.ClassesBases;
using HLP.Base.Static;
using HLP.Base;

namespace HLP.Entries.Model.Repository.Implementation.Gerais
{
    public class Familia_produtoRepository : IFamilia_ProdutoRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Familia_produtoModel> regFamiliaProdAccessor;

        public List<Familia_produtoModel> GetAll()
        {
            DataAccessor<Familia_produtoModel> reg = UndTrabalho.dbPrincipal.CreateSqlStringAccessor
            ("SELECT * FROM Familia_produto",
            MapBuilder<Familia_produtoModel>.MapAllProperties()
            .DoNotMap(c => c.status)
            .Build());

            return reg.Execute().ToList();
        }

        public Familia_produtoModel GetFamilia_produto(int idFamiliaProduto)
        {
            Familia_produtoModel familia;
            if (regFamiliaProdAccessor == null)
            {
                regFamiliaProdAccessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("dbo.Proc_sel_familia_produto",
                                    new Parameters(UndTrabalho.dbPrincipal)
                                    .AddParameter<int>("idFamiliaProduto"),
                                    MapBuilder<Familia_produtoModel>.MapAllProperties().DoNotMap(c => c.status).Build());
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

        public List<Familia_produtoModel> GetFamiliaProdutoSinteticos(string xValue, string xLength)
        {
            DataAccessor<Familia_produtoModel> reg = UndTrabalho.dbPrincipal.CreateSqlStringAccessor
                (string.Format(format: "select * from Familia_produto " +
                "where xFamiliaProduto like '{0}%' " +
                "and len(xFamiliaProduto) = {1}", arg0: xValue, arg1: xLength),
            MapBuilder<Familia_produtoModel>.MapAllProperties()
            .DoNotMap(c => c.status)
            .Build());

            return reg.Execute().ToList();
        }

        public Familia_produtoModel GetFamiliaProdutoByxFamilia(string xValue)
        {
            DataAccessor<Familia_produtoModel> reg = UndTrabalho.dbPrincipal.CreateSqlStringAccessor
                (string.Format(format: "select * from Familia_produto " +
                "where xFamiliaProduto = '{0}' ", arg0: xValue),
            MapBuilder<Familia_produtoModel>.MapAllProperties()
            .DoNotMap(c => c.status)
            .Build());

            return reg.Execute().FirstOrDefault();
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
