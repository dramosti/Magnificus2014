using HLP.Base.ClassesBases;
using HLP.Base.Static;
using HLP.Sales.Model.Models.Comercial;
using HLP.Sales.Model.Repository.Interfaces;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Sales.Model.Repository.Implementation
{
    public class Orcamento_retTranspRepository : IOrcamento_retTranspRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Orcamento_retTranspModel> regOrcamento_retTranspAccessor;
        private DataAccessor<Orcamento_retTranspModel> regAllOrcamento_retTranspAccessor;

        public void Save(Orcamento_retTranspModel objOrcamento_retTransp)
        {
            if (objOrcamento_retTransp.idRetTransp == null)
            {
                objOrcamento_retTransp.idRetTransp = (int)UndTrabalho.dbPrincipal.ExecuteScalar("dbo.Proc_save_Orcamento_retTransp",
                ParameterBase<Orcamento_retTranspModel>.SetParameterValue(objOrcamento_retTransp));
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar("[dbo].[Proc_update_Orcamento_retTransp]",
                ParameterBase<Orcamento_retTranspModel>.SetParameterValue(objOrcamento_retTransp));
            }
        }

        public void Delete(int idRetTransp)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar("dbo.Proc_delete_Orcamento_retTransp",
                 UserData.idUser,
                 idRetTransp);
        }

        public int Copy(int idRetTransp)
        {
            return (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                      "dbo.Proc_copy_Orcamento_retTransp",
                       idRetTransp);
        }

        public Orcamento_retTranspModel GetOrcamento_retTransp(int idRetTransp)
        {
            if (regOrcamento_retTranspAccessor == null)
            {
                regOrcamento_retTranspAccessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("dbo.Proc_sel_Orcamento_retTransp",
                                 new Parameters(UndTrabalho.dbPrincipal)
                                 .AddParameter<int>("idRetTransp"),
                                 Util.GetMap < Orcamento_retTranspModel>());
            }

            return regOrcamento_retTranspAccessor.Execute(idRetTransp).FirstOrDefault();
        }

        public List<Orcamento_retTranspModel> GetAllOrcamento_retTransp()
        {
            if (regAllOrcamento_retTranspAccessor == null)
            {
                regAllOrcamento_retTranspAccessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor("SELECT * FROM Orcamento_retTransp",
                                Util.GetMap<Orcamento_retTranspModel>());
            }
            return regAllOrcamento_retTranspAccessor.Execute().ToList();
        }

        public Orcamento_retTranspModel GetOrcamento_retTranspByIdOrcamento(int idOrcamento)
        {
            if (regOrcamento_retTranspAccessor == null)
            {
                regOrcamento_retTranspAccessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor("select * from Orcamento_retTransp" +
                " where idOrcamento = @idOrcamento",
                                 new Parameters(UndTrabalho.dbPrincipal)
                                 .AddParameter<int>("idOrcamento"),
                                 Util.GetMap<Orcamento_retTranspModel>());
            }
            return regOrcamento_retTranspAccessor.Execute(idOrcamento).FirstOrDefault();
        }
    }
}
