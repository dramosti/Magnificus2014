using HLP.Base.ClassesBases;
using HLP.Base.Static;
using HLP.Entries.Model.Models.Fiscal;
using HLP.Entries.Model.Repository.Interfaces.Fiscal;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Implementation.Fiscal
{
    public class Tipo_operacaoRepository : ITipo_operacaoRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Tipo_operacaoModel> regOperacaoAccessor;

        public Tipo_operacaoModel GetOperacao(int idTipoOperacao)
        {
            if (regOperacaoAccessor == null)
            {
                regOperacaoAccessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("dbo.Proc_sel_tipo_operacao",
                                  new Parameters(UndTrabalho.dbPrincipal)
                                    .AddParameter<int>("idTipoOperacao"),
                                  MapBuilder<Tipo_operacaoModel>.MapAllProperties().DoNotMap(i => i.status).Build());
            }


            return regOperacaoAccessor.Execute(idTipoOperacao).FirstOrDefault();
        }

        public void Save(Tipo_operacaoModel operacao)
        {
            if (operacao.idTipoOperacao == null)
            {
                int idTipoOperacao = Convert.ToInt32((UndTrabalho.dbPrincipal.ExecuteScalar(
                    UndTrabalho.dbTransaction,
                "dbo.Proc_save_tipo_operacao",
                 ParameterBase<Tipo_operacaoModel>.SetParameterValue(operacao))));

                operacao.idTipoOperacao = idTipoOperacao;
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar(
                    UndTrabalho.dbTransaction,
                "[dbo].[Proc_update_Tipo_operacao]",
                 ParameterBase<Tipo_operacaoModel>.SetParameterValue(operacao));
            }
        }

        public void Delete(int idTipoOperacao)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar(
                UndTrabalho.dbTransaction, "dbo.Proc_delete_tipo_operacao",
                UserData.idUser,
                idTipoOperacao);
        }


        public void Begin()
        {
            UndTrabalho.BeginTransaction();
        }

        public void Commit()
        {
            UndTrabalho.CommitTransaction();
        }

        public void RollBack()
        {
            UndTrabalho.RollBackTransaction();
        }


        public int Copy(int idTipoOperacao)
        {
            return (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                this.UndTrabalho.dbTransaction,
                         "dbo.Proc_copy_tipo_operacao",
                          idTipoOperacao);
        }

    }
}
