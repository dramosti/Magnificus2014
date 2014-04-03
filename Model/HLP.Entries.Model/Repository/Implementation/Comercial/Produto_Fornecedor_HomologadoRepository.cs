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
    public class Produto_Fornecedor_HomologadoRepository : IProduto_Fornecedor_HomologadoRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Produto_Fornecedor_HomologadoModel> regProdFornHomAcessor;

        public void Save(Produto_Fornecedor_HomologadoModel produtoFornHom)
        {
            if (produtoFornHom.idProdutoFornecedorHomologado == null)
            {
                produtoFornHom.idProdutoFornecedorHomologado = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                "[dbo].[Proc_save_Produto_Fornecedor_Homologado]",
                ParameterBase<Produto_Fornecedor_HomologadoModel>.SetParameterValue(produtoFornHom));
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar(
            "[dbo].[Proc_update_Produto_Fornecedor_Homologado]",
            ParameterBase<Produto_Fornecedor_HomologadoModel>.SetParameterValue(produtoFornHom));
            }
        }

        public void Delete(int idProdutoFornecedorHomologado)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar("[dbo].[Proc_delete_Produto_Fornecedor_Homologado]",
                    UserData.idUser,
                    idProdutoFornecedorHomologado);
        }

        /// <summary>
        /// Deleta todos os registros cujo id seja igual à idProduto
        /// </summary>
        /// <param name="idProduto">Id do registro Pai</param>
        public void DeletePorProduto(int idProduto)
        {
            UndTrabalho.dbPrincipal.ExecuteNonQuery(System.Data.CommandType.Text,
                "DELETE Produto_Fornecedor_Homologado WHERE idProduto = " + idProduto);
        }

        public void Copy(Produto_Fornecedor_HomologadoModel produtoFornHom)
        {
            produtoFornHom.idProdutoFornecedorHomologado = null;
            produtoFornHom.idProdutoFornecedorHomologado = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                                                           UndTrabalho.dbTransaction,
                                                           "[dbo].[Proc_save_produto_fornecedor_homologado]",
           ParameterBase<Produto_Fornecedor_HomologadoModel>.SetParameterValue(produtoFornHom));
        }

        public Produto_Fornecedor_HomologadoModel GetProdForncHom(int idProdutoFornecedorHomologado)
        {
            if (regProdFornHomAcessor == null)
            {
                regProdFornHomAcessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("[dbo].[Proc_sel_Produto_Fornecedor_Homologado]",
                    new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idProdutoFornecedorHomologado"),
                    MapBuilder<Produto_Fornecedor_HomologadoModel>.MapAllProperties().Build());
            }
            return regProdFornHomAcessor.Execute(idProdutoFornecedorHomologado).FirstOrDefault();
        }

        public List<Produto_Fornecedor_HomologadoModel> GetAllProdForncHom(int idProduto)
        {
            DataAccessor<Produto_Fornecedor_HomologadoModel> regProdFornHomAcessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor
               ("SELECT * FROM Produto_Fornecedor_Homologado WHERE idProduto = @idProduto", new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idProduto"),
               MapBuilder<Produto_Fornecedor_HomologadoModel>.MapAllProperties().Build());

            return regProdFornHomAcessor.Execute(idProduto).ToList();
        }
    }
}
