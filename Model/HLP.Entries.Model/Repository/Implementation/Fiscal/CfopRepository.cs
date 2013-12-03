using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Infrastructure;
using HLP.Comum.Infrastructure.Static;
using HLP.Entries.Model.Models.Fiscal;
using HLP.Entries.Model.Repository.Interfaces.Fiscal;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;

namespace HLP.Entries.Model.Repository.Implementation.Fiscal
{
    public class CfopRepository : ICfopRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<CfopModel> regCfopAccessor;

        public CfopModel GetCfop(int idCfop)
        {
            if (regCfopAccessor == null)
            {
                regCfopAccessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("dbo.Proc_sel_cfop",
                                  new Parameters(UndTrabalho.dbPrincipal)
                                    .AddParameter<int>("idCfop"),
                                  MapBuilder<CfopModel>.MapAllProperties().DoNotMap(c => c.status).Build());
            }


            return regCfopAccessor.Execute(idCfop).FirstOrDefault();
        }

        public void Save(CfopModel cfop)
        {
            if (cfop.idCfop == null)
            {
                int idCfop = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                    "[dbo].[Proc_save_cfop]",
                   ParameterBase<CfopModel>.SetParameterValue(cfop));

                cfop.idCfop = idCfop;
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar(
                    "[dbo].[Proc_update_Cfop]",
                   ParameterBase<CfopModel>.SetParameterValue(cfop));
            }


        }

        public void Delete(int idCfop)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar(
                    "dbo.Proc_delete_cfop",
                     UserData.idUser,
                     idCfop);
        }

        public int Copy(int idCfop)
        {
            return (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                         "dbo.Proc_copy_cfop",
                          idCfop);
        }
    }
}
