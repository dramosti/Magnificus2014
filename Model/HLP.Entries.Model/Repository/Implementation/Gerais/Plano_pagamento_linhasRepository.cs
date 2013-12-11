using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Infrastructure;
using HLP.Comum.Infrastructure.Static;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.Model.Repository.Interfaces.Gerais;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;

namespace HLP.Entries.Model.Repository.Implementation.Gerais
{
    public class Plano_pagamento_linhasRepository : IPlano_pagamento_linhasRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Plano_pagamento_linhasModel> regAcessor;

        public void Save(Plano_pagamento_linhasModel objPlano_pagamento_linhas)
        {
            objPlano_pagamento_linhas.idLinhasPagamento = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                UndTrabalho.dbTransaction,
           "[dbo].[Proc_save_Plano_pagamento_linhas]",
            ParameterBase<Plano_pagamento_linhasModel>.SetParameterValue(objPlano_pagamento_linhas));
        }

        public void Update(Plano_pagamento_linhasModel objPlano_pagamento_linhas)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar(
                UndTrabalho.dbTransaction,
            "[dbo].[Proc_update_Plano_pagamento_linhas]",
            ParameterBase<Plano_pagamento_linhasModel>.SetParameterValue(objPlano_pagamento_linhas));
        }

        public void Delete(int idLinhasPagamento)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar("[dbo].[Proc_delete_Plano_pagamento_linhas]",
                UndTrabalho.dbTransaction,
                  UserData.idUser,
                  idLinhasPagamento);
        }

        public void DeleteLinhasByPlano(int idPlanoPagamento)
        {
            UndTrabalho.dbPrincipal.ExecuteNonQuery(
                UndTrabalho.dbTransaction,
                System.Data.CommandType.Text,
              "DELETE Plano_pagamento_linhas WHERE idPlanoPagamento = " + idPlanoPagamento);
        }

        public void Copy(Plano_pagamento_linhasModel objPlano_pagamento_linhas)
        {
            objPlano_pagamento_linhas.idLinhasPagamento = null;
            objPlano_pagamento_linhas.idLinhasPagamento = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                                           UndTrabalho.dbTransaction,
                                           "[dbo].[Proc_save_Plano_pagamento_linhas]",
        ParameterBase<Plano_pagamento_linhasModel>.SetParameterValue(objPlano_pagamento_linhas));
        }

        public Plano_pagamento_linhasModel GetPlano_pagamento_linhas(int idLinhasPagamento)
        {
            if (regAcessor == null)
            {
                regAcessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("[dbo].[Proc_sel_Plano_pagamento_linhas]",
                   new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idLinhasPagamento"),
                   MapBuilder<Plano_pagamento_linhasModel>.MapAllProperties()
                   .DoNotMap(c=>c.enumValorOuPorcentagem)
                   .DoNotMap(c => c.status).Build());
            }
            return regAcessor.Execute(idLinhasPagamento).FirstOrDefault();
        }

        public List<Plano_pagamento_linhasModel> GetAllPlano_pagamento_linhas(int idPlanoPagamento)
        {
            DataAccessor<Plano_pagamento_linhasModel> reg = UndTrabalho.dbPrincipal.CreateSqlStringAccessor
            ("SELECT * FROM Plano_pagamento_linhas WHERE idPlanoPagamento = @idPlanoPagamento", new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idPlanoPagamento"),
            MapBuilder<Plano_pagamento_linhasModel>.MapAllProperties()
            .DoNotMap(c => c.enumValorOuPorcentagem)
            .DoNotMap(c => c.status).Build());

            return reg.Execute(idPlanoPagamento).ToList();
        }
    }
}
