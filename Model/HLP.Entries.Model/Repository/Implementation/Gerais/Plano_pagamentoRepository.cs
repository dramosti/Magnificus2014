using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.Model.Repository.Interfaces.Gerais;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;
using HLP.Base.ClassesBases;
using HLP.Base.Static;

namespace HLP.Entries.Model.Repository.Implementation.Gerais
{
    public class Plano_pagamentoRepository : IPlano_pagamentoRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Plano_pagamentoModel> regPlano_pagamentoAccessor;

        public void Save(Plano_pagamentoModel objPlano_pagamento)
        {
            if (objPlano_pagamento.idPlanoPagamento == null)
            {
                objPlano_pagamento.idPlanoPagamento = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                    UndTrabalho.dbTransaction,
                "[dbo].[Proc_save_Plano_pagamento]",
                ParameterBase<Plano_pagamentoModel>.SetParameterValue(objPlano_pagamento));
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar(
                    UndTrabalho.dbTransaction,
                "[dbo].[Proc_update_Plano_pagamento]",
                ParameterBase<Plano_pagamentoModel>.SetParameterValue(objPlano_pagamento));
            }
        }

        public void Delete(Plano_pagamentoModel objPlano_pagamento)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar(
            UndTrabalho.dbTransaction,
           "[dbo].[Proc_delete_Plano_pagamento]",
            UserData.idUser,
            objPlano_pagamento.idPlanoPagamento);
        }

        public void Copy(Plano_pagamentoModel objPlano_pagamento)
        {
            objPlano_pagamento.idPlanoPagamento = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
            UndTrabalho.dbTransaction,
           "dbo.Proc_copy_Plano_pagamento",
            objPlano_pagamento.idPlanoPagamento);
        }

        public Plano_pagamentoModel GetPlano_pagamento(int idPlanoPagamento)
        {

            if (regPlano_pagamentoAccessor == null)
            {
                regPlano_pagamentoAccessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("dbo.Proc_sel_Plano_pagamento",
                                         new Parameters(UndTrabalho.dbPrincipal)
                                         .AddParameter<int>("idPlanoPagamento"),
                                         MapBuilder<Plano_pagamentoModel>.MapAllProperties()
                                         .DoNotMap(i => i.bCollTipo)
                                         .DoNotMap(c=>c.status).Build());
            }

            return regPlano_pagamentoAccessor.Execute(idPlanoPagamento).FirstOrDefault();
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
