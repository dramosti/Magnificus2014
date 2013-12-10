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
    public class ConversaoRepository : IConversaoRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<ConversaoModel> regConversaoAccessor;

        private DataAccessor<ConversaoModel> regAllConversaoAccessor;

        public ConversaoModel GetConversao(int idConversao)
        {
            if (regConversaoAccessor == null)
            {
                regConversaoAccessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("dbo.Proc_sel_conversao",
                                    new Parameters(UndTrabalho.dbPrincipal)
                                    .AddParameter<int>("idConversao"),
                                    MapBuilder<ConversaoModel>.MapAllProperties()
                                    .DoNotMap(i => i.enumTipoArredondamento)
                                    .DoNotMap(i => i.status).Build());
            }
            return regConversaoAccessor.Execute(idConversao).FirstOrDefault();
        }

        public List<ConversaoModel> GetAll(int idProduto)
        {
            if (regAllConversaoAccessor == null)
            {
                regAllConversaoAccessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor("SELECT * FROM Conversao WHERE idProduto = @idProduto",
                                  new Parameters(UndTrabalho.dbPrincipal)
                                    .AddParameter<int>("idProduto"),
                                  MapBuilder<ConversaoModel>.MapAllProperties()
                                  .DoNotMap(i => i.enumTipoArredondamento)
                                  .DoNotMap(i => i.status).Build());
            }


            return regAllConversaoAccessor.Execute(idProduto).ToList();
        }

        public void Save(ConversaoModel conversao)
        {
            try
            {
                UndTrabalho.BeginTransaction();

                if (conversao.idConversao == null)
                {
                    conversao.idConversao = (int)UndTrabalho.dbPrincipal.ExecuteScalar(UndTrabalho.dbTransaction,
                                        "[dbo].[Proc_save_Conversao]",
                                        ParameterBase<ConversaoModel>.SetParameterValue(conversao));
                }
                else
                {
                    UndTrabalho.dbPrincipal.ExecuteScalar(UndTrabalho.dbTransaction,
                                        "[dbo].[Proc_update_Conversao]",
                                        ParameterBase<ConversaoModel>.SetParameterValue(conversao));
                }

                UndTrabalho.CommitTransaction();
            }
            catch (Exception ex)
            {
                UndTrabalho.RollBackTransaction();
                throw ex;
            }
        }

        public void DeletePorProduto(int idProduto)
        {
            try
            {
                UndTrabalho.dbPrincipal.ExecuteNonQuery(System.Data.CommandType.Text,
                "DELETE Conversao WHERE idProduto = " + idProduto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int idConversao)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar("[dbo].[Proc_delete_Conversao]",
                  UserData.idUser,
                  idConversao);
        }

        public void Copy(ConversaoModel objConversao)
        {
            objConversao.idConversao = null;
            objConversao.idConversao = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                                           UndTrabalho.dbTransaction,
                                           "[dbo].[Proc_save_Conversao]",

            ParameterBase<ConversaoModel>.SetParameterValue(objConversao));
        }
    }
}
