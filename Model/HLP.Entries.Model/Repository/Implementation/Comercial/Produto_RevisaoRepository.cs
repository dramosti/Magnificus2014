using HLP.Base.ClassesBases;
using HLP.Base.Static;
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
    public class Produto_RevisaoRepository : IProduto_RevisaoRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Produto_RevisaoModel> regProdutoRevisaoAcessor;

        public void Save(Produto_RevisaoModel produtoRevisao)
        {
            if (produtoRevisao.idProdutoRevisao == null)
            {
                produtoRevisao.idProdutoRevisao = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
            "[dbo].[Proc_save_Produto_Revisao]",
            ParameterBase<Produto_RevisaoModel>.SetParameterValue(produtoRevisao));
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar(
            "[dbo].[Proc_update_Produto_Revisao]",
            ParameterBase<Produto_RevisaoModel>.SetParameterValue(produtoRevisao));
            }
        }

        public void Delete(int idProdutoRevisao)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar("[dbo].[Proc_delete_Produto_Revisao]",
                    UserData.idUser,
                    idProdutoRevisao);
        }

        public void Copy(Produto_RevisaoModel produtoRevisao)
        {
            produtoRevisao.idProdutoRevisao = null;
            produtoRevisao.idProdutoRevisao = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                                              UndTrabalho.dbTransaction,
                                              "[dbo].[Proc_save_produto_revisao]",
           ParameterBase<Produto_RevisaoModel>.SetParameterValue(produtoRevisao));
        }

        /// <summary>
        /// Deleta todos os registros cujo id seja igual à idProduto
        /// </summary>
        /// <param name="idProduto">Id do registro Pai</param>
        public void DeletePorProduto(int idProduto)
        {
            UndTrabalho.dbPrincipal.ExecuteNonQuery(System.Data.CommandType.Text,
                "DELETE Produto_Revisao WHERE idProduto = " + idProduto);
        }

        public Produto_RevisaoModel GetProdutoRevisao(int idProdutoRevisao)
        {
            if (regProdutoRevisaoAcessor == null)
            {
                regProdutoRevisaoAcessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("[dbo].[Proc_sel_Produto_Revisao]",
                    new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idProdutoRevisao"),
                    MapBuilder<Produto_RevisaoModel>.MapAllProperties().DoNotMap(i => i.status).Build());
            }
            return regProdutoRevisaoAcessor.Execute(idProdutoRevisao).FirstOrDefault();
        }

        public List<Produto_RevisaoModel> GetAllProdutoRevisao(int idProduto)
        {
            DataAccessor<Produto_RevisaoModel> regProdRevisao = UndTrabalho.dbPrincipal.CreateSqlStringAccessor
               ("SELECT * FROM Produto_Revisao WHERE idProduto = @idProduto", new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idProduto"),
               MapBuilder<Produto_RevisaoModel>.MapAllProperties().DoNotMap(i => i.status).Build());

            return regProdRevisao.Execute(idProduto).ToList();
        }

    }
}
