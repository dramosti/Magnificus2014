using HLP.Base.ClassesBases;
using HLP.Base.Static;
using HLP.Entries.Model.Models.Comercial;
using HLP.Entries.Model.Repository.Interfaces.Comercial;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Implementation.Comercial
{
    public class Lista_precoRepository : ILista_precoRepository
    {

        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Lista_precoModel> regAcessor;

        public void Save(Lista_precoModel objLista_preco)
        {
            if (objLista_preco.idListaPreco == null)
            {
                objLista_preco.idListaPreco = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                    UndTrabalho.dbTransaction,
               "[dbo].[Proc_save_Lista_preco]",
                ParameterBase<Lista_precoModel>.SetParameterValue(objLista_preco));
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar(
                    UndTrabalho.dbTransaction,
            "[dbo].[Proc_update_Lista_preco]",
            ParameterBase<Lista_precoModel>.SetParameterValue(objLista_preco));
            }
        }

        public void Delete(int idListaPreco)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar(
                UndTrabalho.dbTransaction,
                "[dbo].[Proc_delete_Lista_preco]",
                  UserData.idUser,
                  idListaPreco);
        }

        public void DeletePorListaPrecoPai(int idListaPrecoPai)
        {
            UndTrabalho.dbPrincipal.ExecuteNonQuery(System.Data.CommandType.Text,
              "DELETE Lista_preco WHERE idListaPrecoPai = " + idListaPrecoPai);
        }

        public void Copy(Lista_precoModel objLista_preco)
        {
            objLista_preco.idListaPreco = null;
            objLista_preco.idListaPreco = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                                           UndTrabalho.dbTransaction,
                                           "[dbo].[Proc_save_Lista_preco]",
        ParameterBase<Lista_precoModel>.SetParameterValue(objLista_preco));
        }

        public Lista_precoModel GetLista_preco(int idListaPreco)
        {
            if (regAcessor == null)
            {
                regAcessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("[dbo].[Proc_sel_Lista_preco]",
                   new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idListaPreco"),
                   MapBuilder<Lista_precoModel>.MapAllProperties()
                   .DoNotMap(i => i.status)
                   .DoNotMap(i => i.bChecked)
                   .DoNotMap(i => i.vlrEsperado)
                   .DoNotMap(i => i.stMarkupLista)
                   .DoNotMap(i => i.selectedIdFamiliaProduto)
                   .DoNotMap(i => i.selectedIdUnidadeVenda)
                   .DoNotMap(i => i.objProduto)
                   .Build());
            }
            return regAcessor.Execute(idListaPreco).FirstOrDefault();
        }

        public List<Lista_precoModel> GetAllLista_preco(int idListaPrecoPai)
        {
            DataAccessor<Lista_precoModel> reg = UndTrabalho.dbPrincipal.CreateSqlStringAccessor
            ("SELECT * FROM Lista_preco WHERE idListaPrecoPai = @idListaPrecoPai", new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idListaPrecoPai"),
            MapBuilder<Lista_precoModel>.MapAllProperties()
            .DoNotMap(i => i.status)
            .DoNotMap(i => i.status)
            .DoNotMap(i => i.bChecked)
            .DoNotMap(i => i.vlrEsperado)
            .DoNotMap(i => i.stMarkupLista)
            .DoNotMap(i => i.selectedIdFamiliaProduto)
                   .DoNotMap(i => i.selectedIdUnidadeVenda)
                   .DoNotMap(i => i.objProduto)
            .Build());

            try
            {
                return reg.Execute(idListaPrecoPai).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<int> ReturnProducts(List<int> lidProduto)
        {
            List<int> lRetorno = new List<int>();
            string sql = "";
            if (lidProduto.Count() > 0)
            {
                string notIn = String.Join(",", lidProduto);
                sql = "SELECT idProduto FROM Produto WHERE idProduto NOT IN (" + notIn + ")";
            }
            else
            {
                sql = "SELECT idProduto FROM Produto";
            }

            DbCommand cmd = UndTrabalho.dbPrincipal.GetSqlStringCommand(sql);
            IDataReader reader = UndTrabalho.dbPrincipal.ExecuteReader(cmd);

            while (reader.Read())
            {
                lRetorno.Add((int)reader.GetValue(0));
            }
            return lRetorno;


        }

    }
}
