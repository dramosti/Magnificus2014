using HLP.Base.ClassesBases;
using HLP.Base.Static;
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
    public class Condicao_pagamentoRepository : ICondicao_pagamentoRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Condicao_pagamentoModel> regCondicaoAccessor;

        public Condicao_pagamentoModel GetCondicao(int idCondicaoPagamento)
        {
            if (regCondicaoAccessor == null)
            {
                regCondicaoAccessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("dbo.Proc_sel_condicao_pagamento",
                                  new Parameters(UndTrabalho.dbPrincipal)
                                    .AddParameter<int>("idCondicaoPagamento"),
                                  MapBuilder<Condicao_pagamentoModel>.MapAllProperties().DoNotMap(
                                  i => i.status).Build());
            }


            return regCondicaoAccessor.Execute(idCondicaoPagamento).FirstOrDefault();
        }

        public void Save(Condicao_pagamentoModel condicao)
        {
            if (condicao.idCondicaoPagamento == null)
            {
                int idCondicaoPagamento = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
             "dbo.Proc_save_condicao_pagamento",
            ParameterBase<Condicao_pagamentoModel>.SetParameterValue(condicao));

                condicao.idCondicaoPagamento = idCondicaoPagamento;
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar(
             "dbo.Proc_update_Condicao_pagamento",
            ParameterBase<Condicao_pagamentoModel>.SetParameterValue(condicao));
            }

        }

        public void Delete(int idCondicaoPagamento)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar(
                      "dbo.Proc_delete_condicao_pagamento",
                       UserData.idUser,
                       idCondicaoPagamento);
        }


        public int Copy(int idCondicaoPagamento)
        {
            return (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                         "dbo.Proc_copy_condicao_pagamento",
                          idCondicaoPagamento);
        }
    }

}
