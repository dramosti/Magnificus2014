using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Entries.Model.Models.Crm;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.Model.Repository.Interfaces.Crm;
using HLP.Entries.Model.Repository.Interfaces.Gerais;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;
using HLP.Base.ClassesBases;
using HLP.Base.Static;

namespace HLP.Entries.Model.Repository.Implementation.Crm
{
    public class PersonalidadeRepository : IPersonalidadeRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<PersonalidadeModel> regPersonalidadeAccessor;

        public PersonalidadeModel GetPersonalidade(int idPersonalidade)
        {
            if (regPersonalidadeAccessor == null)
            {
                regPersonalidadeAccessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("dbo.Proc_sel_personalidade",
                                    new Parameters(UndTrabalho.dbPrincipal)
                                    .AddParameter<int>("idPersonalidade"),
                                    MapBuilder<PersonalidadeModel>.MapAllProperties().DoNotMap(c=>c.status).Build());
            }
            return regPersonalidadeAccessor.Execute(idPersonalidade).FirstOrDefault();
        }

        public void Save(PersonalidadeModel personalidade)
        {
            if (personalidade.idPersonalidade == null)
            {
                int idPersonalidade = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                 "dbo.Proc_save_personalidade",
                ParameterBase<PersonalidadeModel>.SetParameterValue(personalidade));

                personalidade.idPersonalidade = idPersonalidade;
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar(
                 "[dbo].[Proc_update_Personalidade]",
                ParameterBase<PersonalidadeModel>.SetParameterValue(personalidade));
            }
        }

        public void Delete(int idPersonalidade)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar(
                     "dbo.Proc_delete_personalidade",
                      UserData.idUser,
                      idPersonalidade);
        }

        public int Copy(int idPersonalidade)
        {
            return (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                      "dbo.Proc_copy_personalidade",
                       idPersonalidade);
        }
    }
}
