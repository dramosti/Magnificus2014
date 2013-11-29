using HLP.Comum.Infrastructure;
using HLP.Comum.Infrastructure.Static;
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
    public class Situacao_tributaria_ipiRepository : ISituacao_tributaria_ipiRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Situacao_tributaria_ipiModel> regIpiAccessor;


        public Situacao_tributaria_ipiModel GetStIpi(int idCSTIpi)
        {

            if (regIpiAccessor == null)
            {
                regIpiAccessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("dbo.Proc_sel_situacao_tributaria_ipi",
                                  new Parameters(UndTrabalho.dbPrincipal)
                                    .AddParameter<int>("idCSTIpi"),
                                  MapBuilder<Situacao_tributaria_ipiModel>.MapAllProperties().DoNotMap(i => i.status).Build());
            }


            return regIpiAccessor.Execute(idCSTIpi).FirstOrDefault();
        }

        public void Save(Situacao_tributaria_ipiModel ipi)
        {
            try
            {
                Convert.ToInt32(ipi.cCSTIpi);
            }
            catch (Exception)
            {
                throw new Exception("Situação tributária deve ser uma valor numérico válido!");
            }

            if (ipi.idCSTIpi == null)
            {
                int idCSTIpi = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
               "[dbo].[Proc_save_situacao_tributaria_ipi]",
              ParameterBase<Situacao_tributaria_ipiModel>.SetParameterValue(ipi));
                ipi.idCSTIpi = idCSTIpi;
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar(
               "[dbo].[Proc_update_Situacao_tributaria_ipi]",
              ParameterBase<Situacao_tributaria_ipiModel>.SetParameterValue(ipi));
            }
        }

        public void Delete(int idCSTIpi)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar(
                     "dbo.Proc_delete_situacao_tributaria_ipi",
                      UserData.idUser,
                      idCSTIpi);
        }


        public int Copy(int idCSTIpi)
        {
            return (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                      "dbo.Proc_copy_situacao_tributaria_ipi",
                       idCSTIpi);
        }
    }
}
