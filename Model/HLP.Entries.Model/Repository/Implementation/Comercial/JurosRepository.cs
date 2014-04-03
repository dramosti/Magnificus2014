using HLP.Base.ClassesBases;
using HLP.Base.Static;
using HLP.Entries.Model.Models.Comercial;
using HLP.Entries.Model.Repository.Interfaces.Comercial;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Implementation.Comercial
{
    public class JurosRepository : IJurosRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<JurosModel> regJurosAccessor;

        public JurosModel GetJuros(int idJuros)
        {
            if (regJurosAccessor == null)
            {
                regJurosAccessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("dbo.Proc_sel_juros",
                                  new Parameters(UndTrabalho.dbPrincipal)
                                    .AddParameter<int>("idJuros"),
                                  MapBuilder<JurosModel>.MapAllProperties().DoNotMap(
                                  i => i.status).Build());
            }


            return regJurosAccessor.Execute(idJuros).FirstOrDefault();
        }

        public void Save(JurosModel juros)
        {
            if (juros.idJuros == null)
            {
                int idJuros = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                   "dbo.Proc_save_juros",
                  ParameterBase<JurosModel>.SetParameterValue(juros));

                juros.idJuros = idJuros;
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar(
                   "[dbo].[Proc_update_Juros]",
                  ParameterBase<JurosModel>.SetParameterValue(juros));
            }
        }

        public void Delete(int idJuros)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar(
                    "dbo.Proc_delete_juros",
                     UserData.idUser,
                     idJuros);
        }


        public int Copy(int idJuros)
        {
            return (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                       "dbo.Proc_copy_juros",
                        idJuros);
        }
    }
}
