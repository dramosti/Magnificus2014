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
    public class Condicoes_entregaRepository : ICondicoes_entregaRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Condicoes_entregaModel> regCondicaoAccessor;

        public Condicoes_entregaModel GetCondicao(int idCondicaoEntrega)
        {

            if (regCondicaoAccessor == null)
            {
                regCondicaoAccessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("dbo.Proc_sel_condicoes_entrega",
                                  new Parameters(UndTrabalho.dbPrincipal)
                                    .AddParameter<int>("idCondicaoEntrega"),
                                  MapBuilder<Condicoes_entregaModel>.MapAllProperties().Build());
            }
            return regCondicaoAccessor.Execute(idCondicaoEntrega).FirstOrDefault();
        }

        public void Save(Condicoes_entregaModel condicao)
        {
            if (condicao.idCondicaoEntrega == null)
            {
                int idCondicaoEntrega = Convert.ToInt32((UndTrabalho.dbPrincipal.ExecuteScalar("Proc_save_condicoes_entrega",
                   ParameterBase<Condicoes_entregaModel>.SetParameterValue(condicao))));

                condicao.idCondicaoEntrega = idCondicaoEntrega;
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar("Proc_update_Condicoes_entrega",
                   ParameterBase<Condicoes_entregaModel>.SetParameterValue(condicao));
            }
        }

        public void Delete(int idCondicaoEntrega)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar("dbo.Proc_delete_condicoes_entrega",
                  UserData.idUser,
                  idCondicaoEntrega);
        }


        public int Copy(int idCondicaoEntrega)
        {
            return (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                        "dbo.Proc_copy_condicoes_entrega",
                         idCondicaoEntrega);
        }
    }
}
