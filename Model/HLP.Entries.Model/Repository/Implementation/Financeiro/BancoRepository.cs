using HLP.Comum.Infrastructure;
using HLP.Comum.Infrastructure.Static;
using HLP.Entries.Model.Models.Financeiro;
using HLP.Entries.Model.Repository.Interfaces.Financeiro;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Implementation.Financeiro
{
    public class BancoRepository : IBancoRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<BancoModel> regBancoAccessor;
        private DataAccessor<BancoModel> regAllBancoAccessor;

        public List<BancoModel> GetAll()
        {
            if (regAllBancoAccessor == null)
            {
                regAllBancoAccessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor("SELECT * FROM Banco",
                                  MapBuilder<BancoModel>.MapAllProperties().Build());
            }
            return regAllBancoAccessor.Execute().ToList();
        }

        public BancoModel GetBanco(int idBanco)
        {
            if (regBancoAccessor == null)
            {
                regBancoAccessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("dbo.Proc_sel_banco",
                                  new Parameters(UndTrabalho.dbPrincipal)
                                    .AddParameter<int>("idBanco"),
                                  MapBuilder<BancoModel>.MapAllProperties().Build());
            }
            return regBancoAccessor.Execute(idBanco).FirstOrDefault();
        }

        public void Save(BancoModel banco)
        {
            if (banco.idBanco == null)
            {
                int idBanco = Convert.ToInt32((UndTrabalho.dbPrincipal.ExecuteScalar("dbo.Proc_save_banco",
                 ParameterBase<BancoModel>.SetParameterValue(banco))));

                banco.idBanco = idBanco;
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar("[dbo].[Proc_update_Banco]",
                 ParameterBase<BancoModel>.SetParameterValue(banco));
            }
        }

        public void Delete(int idBanco)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar("dbo.Proc_delete_banco",
                   UserData.idUser,
                   idBanco);
        }


        public int Copy(int idBanco)
        {
            return (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                        "dbo.Proc_copy_banco",
                         idBanco);
        }
    }
}
