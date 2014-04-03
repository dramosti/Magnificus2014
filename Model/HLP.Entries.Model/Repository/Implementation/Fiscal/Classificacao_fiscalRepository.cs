using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Entries.Model.Models.Fiscal;
using HLP.Entries.Model.Repository.Interfaces.Fiscal;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;
using HLP.Base.ClassesBases;
using HLP.Base.Static;

namespace HLP.Entries.Model.Repository.Implementation.Fiscal
{
    public class Classificacao_fiscalRepository : IClassificacao_fiscalRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Classificacao_fiscalModel> regClassificacaoAccessor;

        public Classificacao_fiscalModel GetClassificacao(int idClassificacaoFiscal)
        {
            if (regClassificacaoAccessor == null)
            {
                regClassificacaoAccessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("dbo.Proc_sel_classificacao_fiscal",
                                  new Parameters(UndTrabalho.dbPrincipal)
                                    .AddParameter<int>("idClassificacaoFiscal"),
                                  MapBuilder<Classificacao_fiscalModel>.MapAllProperties().DoNotMap(c=>c.status).Build());
            }


            return regClassificacaoAccessor.Execute(idClassificacaoFiscal).FirstOrDefault();
        }

        public void Save(Classificacao_fiscalModel classificacao)
        {
            if (classificacao.idClassificacaoFiscal == null)
            {
                int idClassificacaoFiscal = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                   "[dbo].[Proc_save_classificacao_fiscal]",
                  ParameterBase<Classificacao_fiscalModel>.SetParameterValue(classificacao));

                classificacao.idClassificacaoFiscal = idClassificacaoFiscal;
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar(
                   "[dbo].[Proc_update_Classificacao_fiscal]",
                  ParameterBase<Classificacao_fiscalModel>.SetParameterValue(classificacao));
            }
        }

        public void Delete(int idClassificacaoFiscal)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar(
                    "dbo.Proc_delete_classificacao_fiscal",
                     UserData.idUser,
                     idClassificacaoFiscal);
        }


        public int Copy(int idClassificacaoFiscal)
        {
            return (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                        "dbo.Proc_copy_classificacao_fiscal",
                         idClassificacaoFiscal);
        }
    }
}
