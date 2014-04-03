using HLP.Base.ClassesBases;
using HLP.Base.Static;
using HLP.Entries.Model.Models.Fiscal;
using HLP.Entries.Model.Repository.Interfaces.Fiscal;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Implementation.Fiscal
{
    public class Operacao_reducao_baseRepository : IOperacao_reducao_baseRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Operacao_reducao_baseModel> regOperacaoReducaoAccessor;

        public List<Operacao_reducao_baseModel> GetAll(int idTipoOperacao)
        {
            if (regOperacaoReducaoAccessor == null)
            {
                regOperacaoReducaoAccessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor("SELECT * FROM Operacao_reducao_base WHERE idTipoOperacao = @idTipoOperacao",
                                  new Parameters(UndTrabalho.dbPrincipal)
                                    .AddParameter<int>("idTipoOperacao"),
                                  MapBuilder<Operacao_reducao_baseModel>.MapAllProperties()
                                  .DoNotMap(i => i.status)
                                  .Build());
            }


            return regOperacaoReducaoAccessor.Execute(idTipoOperacao).ToList();
        }

        public void Save(Operacao_reducao_baseModel operacaoReducao)
        {
            if (operacaoReducao.idOperacaoReducaoBase == null)
            {
                int idOperacaoReducaoBase = Convert.ToInt32((UndTrabalho.dbPrincipal.ExecuteScalar(
                    UndTrabalho.dbTransaction,
                   "dbo.Proc_save_operacao_reducao_base",
                  ParameterBase<Operacao_reducao_baseModel>.SetParameterValue(operacaoReducao))));

                operacaoReducao.idOperacaoReducaoBase = idOperacaoReducaoBase;
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar(
                    UndTrabalho.dbTransaction,
                   "dbo.Proc_update_Operacao_reducao_base",
                  ParameterBase<Operacao_reducao_baseModel>.SetParameterValue(operacaoReducao));
            }
        }

        public void Delete(int idOperacaoReducaoBase)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar(
                UndTrabalho.dbTransaction,
             "dbo.Proc_delete_operacao_reducao_base",
             UserData.idUser, idOperacaoReducaoBase);
        }

        public void Delete(int idTipoOperacao, List<int?> lidOperacaoReducaoBase)
        {
            DbCommand cmd;
            string sql = "";
            if (lidOperacaoReducaoBase.Count() > 0)
            {
                string notIn = String.Join(",", lidOperacaoReducaoBase);
                sql = "DELETE FROM Operacao_reducao_base WHERE  idTipoOperacao =" + idTipoOperacao + " AND idOperacaoReducaoBase NOT IN (" + notIn + ")";
            }
            else
            {
                sql = "DELETE FROM Operacao_reducao_base WHERE  idTipoOperacao =" + idTipoOperacao;
            }
            cmd = UndTrabalho.dbPrincipal.GetSqlStringCommand(sql);

            UndTrabalho.dbPrincipal.ExecuteScalar(UndTrabalho.dbTransaction, CommandType.Text, sql);
        }

        public void Copy(Operacao_reducao_baseModel operacaoReducaoBase)
        {
            operacaoReducaoBase.idOperacaoReducaoBase = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                                           UndTrabalho.dbTransaction,
                                           "[dbo].[Proc_save_operacao_reducao_base]",
        ParameterBase<Operacao_reducao_baseModel>.SetParameterValue(operacaoReducaoBase));
        }
    }
}
