using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.Model.Repository.Interfaces.Gerais;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;
using HLP.Base.ClassesBases;
using HLP.Base.Static;

namespace HLP.Entries.Model.Repository.Implementation.Gerais
{
    public class UFRepository : IUFRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<UFModel> regUfGetAllAccessor;

        private DataAccessor<UFModel> regUfAccessor;

        public List<UFModel> GetAll()
        {
            if (regUfGetAllAccessor == null)
            {
                regUfGetAllAccessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor("SELECT * FROM UF",
                                  MapBuilder<UFModel>.MapAllProperties().Build());
            }
            return regUfGetAllAccessor.Execute().ToList();
        }

        public DataTable GetAlltoComboBox()
        {
            IDataReader dr = UndTrabalho.dbPrincipal.ExecuteReader(CommandType.Text, "select (xSiglaUf +' - '+ Regiao +' - '+ xPais)as xSiglaUf, ID from vwUF ");
            DataTable dt = new DataTable();
            dt.Load(dr);
            return dt;
        }

        public UFModel GetUF(int idUF)
        {

            if (regUfAccessor == null)
            {
                regUfAccessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("dbo.Proc_sel_uf",
                                  new Parameters(UndTrabalho.dbPrincipal)
                                    .AddParameter<int>("idUF"),
                                  MapBuilder<UFModel>.MapAllProperties().DoNotMap(i => i.status).Build());
            }


            return regUfAccessor.Execute(idUF).FirstOrDefault();
        }

        public void Save(UFModel uf)
        {
            if (uf.idUF == null)
            {
                int idUF = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
              "[dbo].[Proc_save_uf]",
             ParameterBase<UFModel>.SetParameterValue(uf));
                uf.idUF = idUF;
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar(
              "[dbo].[Proc_update_UF]",
             ParameterBase<UFModel>.SetParameterValue(uf));
            }


        }

        public void Delete(int idUF)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar(
                    "dbo.Proc_delete_uf",
                     UserData.idUser,
                     idUF);
        }

        public bool IsNew(string xSiglaUf)
        {
            DbCommand comand = UndTrabalho.dbPrincipal.GetSqlStringCommand
                             (
                             string.Format("SELECT COUNT(*) FROM UF WHERE xSiglaUf = '{0}'", xSiglaUf)
                             );

            int i = (int)UndTrabalho.dbPrincipal.ExecuteScalar(comand);
            if (i == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int Copy(int idUF)
        {
            return (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                        "dbo.Proc_copy_uf",
                         idUF);
        }
    }
}
