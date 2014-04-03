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
    public class MultasRepository : IMultasRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<MultasModel> regMultaAccessor;


        public MultasModel GetMulta(int idMultas)
        {
            if (regMultaAccessor == null)
            {
                regMultaAccessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("dbo.Proc_sel_multas",
                                  new Parameters(UndTrabalho.dbPrincipal)
                                    .AddParameter<int>("idMultas"),
                                  MapBuilder<MultasModel>.MapAllProperties().DoNotMap(i => i.status).Build());
            }


            return regMultaAccessor.Execute(idMultas).FirstOrDefault();
        }

        public void Save(MultasModel multa)
        {
            if (multa.idMultas == null)
            {
                int idMultas = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                     "[dbo].[Proc_save_multas]",
                    ParameterBase<MultasModel>.SetParameterValue(multa));

                multa.idMultas = idMultas;
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar(
                     "[dbo].[Proc_update_Multas]",
                    ParameterBase<MultasModel>.SetParameterValue(multa));
            }
        }

        public void Delete(int idMultas)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar(
                    "dbo.Proc_delete_multas",
                     UserData.idUser,
                     idMultas);
        }


        public int Copy(int idMultas)
        {
            return (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                        "dbo.Proc_copy_multas",
                         idMultas);
        }
    }
}
