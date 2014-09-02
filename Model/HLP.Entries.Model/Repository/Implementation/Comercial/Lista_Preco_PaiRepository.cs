using HLP.Base.ClassesBases;
using HLP.Base.Static;
using HLP.Entries.Model.Models.Comercial;
using HLP.Entries.Model.Repository.Interfaces.Comercial;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Implementation.Comercial
{
    public class Lista_Preco_PaiRepository : ILista_Preco_PaiRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Lista_Preco_PaiModel> regLista_Preco_PaiAccessor;

        private DataAccessor<Lista_Preco_PaiModel> regAllLista_Preco_ByOrigem;

        public void Save(Lista_Preco_PaiModel objLista_Preco_Pai)
        {

            if (objLista_Preco_Pai.idListaPrecoPai == null)
            {
                objLista_Preco_Pai.idListaPrecoPai = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                "[dbo].[Proc_save_Lista_Preco_Pai]",
                ParameterBase<Lista_Preco_PaiModel>.SetParameterValue(objLista_Preco_Pai));
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar(
                "[dbo].[Proc_update_Lista_Preco_Pai]",
                ParameterBase<Lista_Preco_PaiModel>.SetParameterValue(objLista_Preco_Pai));
            }
        }

        public void Delete(int idListaPrecoPai)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar(
            UndTrabalho.dbTransaction,
           "[dbo].[Proc_delete_Lista_Preco_Pai]",
            UserData.idUser,
            idListaPrecoPai);
        }

        public void Copy(Lista_Preco_PaiModel objLista_Preco_Pai)
        {
            objLista_Preco_Pai.idListaPrecoPai = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
            UndTrabalho.dbTransaction,
           "dbo.Proc_copy_Lista_Preco_Pai",
            objLista_Preco_Pai.idListaPrecoPai);
        }

        public Lista_Preco_PaiModel GetLista_Preco_Pai(int idListaPrecoPai)
        {

            if (regLista_Preco_PaiAccessor == null)
            {
                regLista_Preco_PaiAccessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("dbo.Proc_sel_Lista_Preco_Pai",
                                         new Parameters(UndTrabalho.dbPrincipal)
                                         .AddParameter<int>("idListaPrecoPai"),
                                         Util.GetMap<Lista_Preco_PaiModel>());
            }

            return regLista_Preco_PaiAccessor.Execute(idListaPrecoPai).FirstOrDefault();
        }

        public List<Lista_Preco_PaiModel> GetAllListaPrecoOrigem(int idListaPrecoOrigem)
        {
            regAllLista_Preco_ByOrigem = UndTrabalho.dbPrincipal.CreateSqlStringAccessor(
                "select * from Lista_Preco_Pai where idListaPrecoOrigem = " + idListaPrecoOrigem.ToString(),
                new Parameters(UndTrabalho.dbPrincipal),
                Util.GetMap<Lista_Preco_PaiModel>());

            return regAllLista_Preco_ByOrigem.Execute().ToList();
        }

        public List<int> GetAllIdListaPreco()
        {
            List<int> ids = new List<int>();
            SqlConnection connection = new SqlConnection(connectionString: UndTrabalho.dbPrincipal.ConnectionString);
            SqlCommand cmd = connection.CreateCommand();
            string res = string.Empty;
            connection.Open();
            cmd.CommandText = "select idListaPrecoPai from Lista_Preco_Pai"; // update select command accordingly
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                res = reader["idListaPrecoPai"].ToString();
                ids.Add(item:
                Convert.ToInt32(value: res));
            }
            return ids;
        }

        public int GetIdListaPreferencial()
        {
            DbCommand command = UndTrabalho.dbPrincipal.GetSqlStringCommand("select idListaPrecoPai from Lista_Preco_Pai where stPreferencial = 1");
            return UndTrabalho.dbPrincipal.ExecuteScalar(command).ToInt32();
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
