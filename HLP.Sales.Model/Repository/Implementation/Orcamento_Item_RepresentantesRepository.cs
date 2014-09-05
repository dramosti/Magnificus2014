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
    public class Orcamento_Item_RepresentantesRepository : IOrcamento_Item_RepresentantesRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Orcamento_Item_RepresentantesModel> regOrcamento_Item_RepresentantesAccessor;
        private DataAccessor<Orcamento_Item_RepresentantesModel> regAllOrcamento_Item_RepresentantesAccessor;
        private DataAccessor<Orcamento_Item_RepresentantesModel> regOrcamento_Item_Representantes_ByIdOrcamentoItemAccessor;

        public void Save(Orcamento_Item_RepresentantesModel objOrcamento_Item_Representantes)
        {
            objOrcamento_Item_Representantes.idOrcamentoItemRepresentate = (int)UndTrabalho.dbPrincipal.ExecuteScalar("dbo.Proc_save_Orcamento_Item_Representantes",
            ParameterBase<Orcamento_Item_RepresentantesModel>.SetParameterValue(objOrcamento_Item_Representantes));
        }

        public void Delete(int idOrcamentoItemRepresentate)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar("dbo.Proc_delete_Orcamento_Item_Representantes",
                 UserData.idUser,
                 idOrcamentoItemRepresentate);
        }

        public int Copy(int idOrcamentoItemRepresentate)
        {
            return (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                      "dbo.Proc_copy_Orcamento_Item_Representantes",
                       idOrcamentoItemRepresentate);
        }

        public Orcamento_Item_RepresentantesModel GetOrcamento_Item_Representantes(int idOrcamentoItemRepresentate)
        {
            if (regOrcamento_Item_RepresentantesAccessor == null)
            {
                regOrcamento_Item_RepresentantesAccessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("dbo.Proc_sel_Orcamento_Item_Representantes",
                                 new Parameters(UndTrabalho.dbPrincipal)
                                 .AddParameter<int>("idOrcamentoItemRepresentate"),
                                 Util.GetMap<Orcamento_Item_RepresentantesModel>());
            }

            return regOrcamento_Item_RepresentantesAccessor.Execute(idOrcamentoItemRepresentate).FirstOrDefault();
        }

        public List<Orcamento_Item_RepresentantesModel> GetOrcamento_Item_Representantes_ByIdOrcamentoItem(int idOrcamentoItem)
        {
            this.regOrcamento_Item_Representantes_ByIdOrcamentoItemAccessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor("SELECT * FROM Orcamento_Item_Representantes " +
                "WHERE idOrcamentoItem = " + idOrcamentoItem,
                                Util.GetMap<Orcamento_Item_RepresentantesModel>());
            return regOrcamento_Item_Representantes_ByIdOrcamentoItemAccessor.Execute().ToList();
        }

        public List<Orcamento_Item_RepresentantesModel> GetAllOrcamento_Item_Representantes()
        {
            if (regAllOrcamento_Item_RepresentantesAccessor == null)
            {
                regAllOrcamento_Item_RepresentantesAccessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor("SELECT * FROM Orcamento_Item_Representantes",
                                Util.GetMap<Orcamento_Item_RepresentantesModel>());
            }
            return regAllOrcamento_Item_RepresentantesAccessor.Execute().ToList();
        }
    }
}
