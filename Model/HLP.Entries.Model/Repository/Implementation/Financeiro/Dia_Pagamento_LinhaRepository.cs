using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Infrastructure;
using HLP.Comum.Infrastructure.Static;
using HLP.Entries.Model.Models.Financeiro;
using HLP.Entries.Model.Repository.Interfaces.Financeiro;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;

namespace HLP.Entries.Model.Repository.Implementation.Financeiro
{
    public class Dia_Pagamento_LinhaRepository : IDia_pagamento_linhasRepository
    {

        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Dia_pagamento_linhasModel> regAcessor;

        public void Save(Dia_pagamento_linhasModel objDia_pagamento_linhas)
        {
            if (objDia_pagamento_linhas.idDiaPagamentoLinhas == null)
            {
                objDia_pagamento_linhas.idDiaPagamentoLinhas = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                      UndTrabalho.dbTransaction,
               "[dbo].[Proc_save_Dia_pagamento_linhas]",
                ParameterBase<Dia_pagamento_linhasModel>.SetParameterValue(objDia_pagamento_linhas));
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar(
                    UndTrabalho.dbTransaction,
                    "[dbo].[Proc_update_Dia_pagamento_linhas]",
                    ParameterBase<Dia_pagamento_linhasModel>.SetParameterValue(objDia_pagamento_linhas));
            }
        }


        public void Delete(Dia_pagamento_linhasModel objDia_pagamento_linhas)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar("[dbo].[Proc_delete_Dia_pagamento_linhas]",
                UndTrabalho.dbTransaction,
                  UserData.idUser,
                  objDia_pagamento_linhas.idDiaPagamentoLinhas);
        }

        public void DeleteLinhasByDia(int idDiaPagamento)
        {
            UndTrabalho.dbPrincipal.ExecuteNonQuery(
                UndTrabalho.dbTransaction,
                System.Data.CommandType.Text,
              "DELETE Dia_pagamento_linhas WHERE idDiaPagamento = " + idDiaPagamento);
        }

        public void Copy(Dia_pagamento_linhasModel objDia_pagamento_linhas)
        {
            objDia_pagamento_linhas.idDiaPagamentoLinhas = null;
            objDia_pagamento_linhas.idDiaPagamentoLinhas = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                                           UndTrabalho.dbTransaction,
                                           "[dbo].[Proc_save_Dia_pagamento_linhas]",
        ParameterBase<Dia_pagamento_linhasModel>.SetParameterValue(objDia_pagamento_linhas));
        }

        public Dia_pagamento_linhasModel GetDia_pagamento_linhas(int idDiaPagamentoLinhas)
        {
            if (regAcessor == null)
            {
                regAcessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("[dbo].[Proc_sel_Dia_pagamento_linhas]",
                   new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idDiaPagamentoLinhas"),
                   MapBuilder<Dia_pagamento_linhasModel>.MapAllProperties()
                   .DoNotMap(c=>c.enumDiaUtil)
                   .DoNotMap(c=>c.enumSemanaOuMes)
                   .DoNotMap(c=>c.status).Build());
            }
            return regAcessor.Execute(idDiaPagamentoLinhas).FirstOrDefault();
        }

        public List<Dia_pagamento_linhasModel> GetAllDia_pagamento_linhas(int idDiaPagamento)
        {
            DataAccessor<Dia_pagamento_linhasModel> reg = UndTrabalho.dbPrincipal.CreateSqlStringAccessor
            ("SELECT * FROM Dia_pagamento_linhas WHERE idDiaPagamento = @idDiaPagamento", new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idDiaPagamento"),
            MapBuilder<Dia_pagamento_linhasModel>.MapAllProperties()
            .DoNotMap(c => c.enumDiaUtil)
            .DoNotMap(c => c.enumSemanaOuMes)
            .DoNotMap(c => c.status).Build());

            return reg.Execute(idDiaPagamento).ToList();
        }

    }
}
