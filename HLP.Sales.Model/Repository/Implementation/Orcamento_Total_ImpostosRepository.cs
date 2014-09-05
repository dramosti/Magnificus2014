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
    public class Orcamento_Total_ImpostosRepository : IOrcamento_Total_ImpostosRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Orcamento_Total_ImpostosModel> regOrcamento_Total_ImpostosAccessor;
        private DataAccessor<Orcamento_Total_ImpostosModel> regAllOrcamento_Total_ImpostosAccessor;

        public void Save(Orcamento_Total_ImpostosModel objOrcamento_Total_Impostos)
        {
            if (objOrcamento_Total_Impostos.idOrcamentoTotalImpostos == null)
            {
                objOrcamento_Total_Impostos.idOrcamentoTotalImpostos = (int)UndTrabalho.dbPrincipal.ExecuteScalar("dbo.Proc_save_Orcamento_Total_Impostos",
                ParameterBase<Orcamento_Total_ImpostosModel>.SetParameterValue(objOrcamento_Total_Impostos));
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar("[dbo].[Proc_update_Orcamento_Total_Impostos]",
                ParameterBase<Orcamento_Total_ImpostosModel>.SetParameterValue(objOrcamento_Total_Impostos));
            }
        }

        public void Delete(int idOrcamentoTotalImpostos)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar("dbo.Proc_delete_Orcamento_Total_Impostos",
                 UserData.idUser,
                 idOrcamentoTotalImpostos);
        }

        public int Copy(int idOrcamentoTotalImpostos)
        {
            return (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                      "dbo.Proc_copy_Orcamento_Total_Impostos",
                       idOrcamentoTotalImpostos);
        }

        public Orcamento_Total_ImpostosModel GetOrcamento_Total_Impostos(int idOrcamentoTotalImpostos)
        {
            if (regOrcamento_Total_ImpostosAccessor == null)
            {
                regOrcamento_Total_ImpostosAccessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("dbo.Proc_sel_Orcamento_Total_Impostos",
                                 new Parameters(UndTrabalho.dbPrincipal)
                                 .AddParameter<int>("idOrcamentoTotalImpostos"),
                                 Util.GetMap<Orcamento_Total_ImpostosModel>());
            }

            return regOrcamento_Total_ImpostosAccessor.Execute(idOrcamentoTotalImpostos).FirstOrDefault();
        }

        public List<Orcamento_Total_ImpostosModel> GetAllOrcamento_Total_Impostos()
        {
            if (regAllOrcamento_Total_ImpostosAccessor == null)
            {
                regAllOrcamento_Total_ImpostosAccessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor("SELECT * FROM Orcamento_Total_Impostos",
                                Util.GetMap<Orcamento_Total_ImpostosModel>());
            }
            return regAllOrcamento_Total_ImpostosAccessor.Execute().ToList();
        }

        public Orcamento_Total_ImpostosModel GetOrcamento_Total_ImpostosByIdOrcamento(int idOrcamento)
        {
            if (regOrcamento_Total_ImpostosAccessor == null)
            {
                regOrcamento_Total_ImpostosAccessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor("select * from Orcamento_Total_Impostos" +
                " where idOrcamento = @idOrcamento",
                                 new Parameters(UndTrabalho.dbPrincipal)
                                 .AddParameter<int>("idOrcamento"),
                                 Util.GetMap<Orcamento_Total_ImpostosModel>());
            }

            return regOrcamento_Total_ImpostosAccessor.Execute(idOrcamento).FirstOrDefault();
        }
    }
}
