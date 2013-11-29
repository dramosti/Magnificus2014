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
    public class Situacao_tributaria_cofinsRepository : ISituacao_tributaria_cofinsRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Situacao_tributaria_cofinsModel> regCofinsAccessor;


        public Situacao_tributaria_cofinsModel GetStCofins(int idCSTCofins)
        {

            if (regCofinsAccessor == null)
            {
                regCofinsAccessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("dbo.Proc_sel_situacao_tributaria_cofins",
                                  new Parameters(UndTrabalho.dbPrincipal)
                                    .AddParameter<int>("idCSTCofins"),
                                  MapBuilder<Situacao_tributaria_cofinsModel>.MapAllProperties().DoNotMap(i => i.status).Build());
            }


            return regCofinsAccessor.Execute(idCSTCofins).FirstOrDefault();
        }

        public void Save(Situacao_tributaria_cofinsModel cofins)
        {
            try
            {
                Convert.ToInt32(cofins.cCSTCofins);
            }
            catch (Exception)
            {
                throw new Exception("Situação tributária deve ser uma valor numérico válido!");
            }

            if (cofins.idCSTCofins == null)
            {
                int idCSTCofins = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
               "[dbo].[Proc_save_situacao_tributaria_cofins]",
              ParameterBase<Situacao_tributaria_cofinsModel>.SetParameterValue(cofins));
                cofins.idCSTCofins = idCSTCofins;
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar(
               "[dbo].[Proc_update_Situacao_tributaria_cofins]",
              ParameterBase<Situacao_tributaria_cofinsModel>.SetParameterValue(cofins));
            }

        }

        public void Delete(int idCSTCofins)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar(
                     "dbo.Proc_delete_situacao_tributaria_cofins",
                      UserData.idUser,
                      idCSTCofins);
        }


        public int Copy(int idCSTCofins)
        {
            return (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                        "dbo.Proc_copy_situacao_tributaria_cofins",
                         idCSTCofins);
        }
    }
}
