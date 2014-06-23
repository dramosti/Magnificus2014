using HLP.Base.ClassesBases;
using HLP.Base.Static;
using HLP.Sales.Model.Models.Comercial;
using HLP.Sales.Model.Repository.Interfaces;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Sales.Model.Repository.Implementation
{
    public class Orcamento_ideRepository : IOrcamento_ideRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Orcamento_ideModel> regOrcamento_ideAccessor;
        private DataAccessor<Orcamento_ideModel> regAllOrcamento_ideAccessor;

        public void Save(Orcamento_ideModel objOrcamento_ide)
        {
            if (objOrcamento_ide.idOrcamento == null)
            {
                objOrcamento_ide.idOrcamento = (int)UndTrabalho.dbPrincipal.ExecuteScalar("dbo.Proc_save_Orcamento_ide",
                ParameterBase<Orcamento_ideModel>.SetParameterValue(objOrcamento_ide));
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar("[dbo].[Proc_update_Orcamento_ide]",
                ParameterBase<Orcamento_ideModel>.SetParameterValue(objOrcamento_ide));
            }
        }

        public void Delete(int idOrcamento)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar("dbo.Proc_delete_Orcamento_ide",
                 UserData.idUser,
                 idOrcamento);
        }

        public int Copy(int idOrcamento)
        {
            return (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                      "dbo.Proc_copy_Orcamento_ide",
                       idOrcamento);
        }

        public Orcamento_ideModel GetOrcamento_ide(int idOrcamento)
        {
            if (regOrcamento_ideAccessor == null)
            {
                regOrcamento_ideAccessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("dbo.Proc_sel_Orcamento_ide",
                                 new Parameters(UndTrabalho.dbPrincipal)
                                 .AddParameter<int>("idOrcamento"),
                                 MapBuilder<Orcamento_ideModel>.MapAllProperties()
                                 .DoNotMap(c => c.orcamento_Total_Impostos)
                                 .DoNotMap(i => i.orcamento_retTransp)
                                 .DoNotMap(i => i.status)
                                 .DoNotMap(i => i.xDepartamento)
                                 .DoNotMap(i => i.xCidade)
                                 .DoNotMap(i => i.xUf)
                                 .DoNotMap(i => i.xTelefone)
                                 .DoNotMap(i => i.idRamoAtividade)
                                 .DoNotMap(i => i.idCanalVenda)
                                .DoNotMap(i => i.bCriado)
                                .DoNotMap(i => i.bEnviado)
                                .DoNotMap(i => i.bCancelado)
                                .DoNotMap(i => i.bPerdido)
                                .DoNotMap(i => i.bConfirmado)
                                .DoNotMap(i => i.bTodos)
                                .DoNotMap(i => i.objCliente)
                                .DoNotMap(i => i.objFuncionario)
                                .DoNotMap(i => i.bIsEnabledClListaPreco)
                                .DoNotMap(i => i.objListaPreco)
                                .DoNotMap(i => i.idUfEnderecoCliente)
                                .DoNotMap(i => i.idUfEnderecoEmpresa)
                                .DoNotMap(i => i.objEmpresa)
                                .DoNotMap(i => i.objCondicaoPagamento)
                                .DoNotMap(i => i.objDesconto)
                                .DoNotMap(i => i.objFuncionarioRepresentante)
                                .DoNotMap(i => i.objTipoDocumento)
                                .DoNotMap(i => i.bCriadoTotais)
                                .DoNotMap(i => i.bConfirmadoTotais)
                                .DoNotMap(i => i.bEnviadoTotais)
                                .DoNotMap(i => i.bPerdidoTotais)
                                .DoNotMap(i => i.bCanceladoTotais)
                                .DoNotMap(i => i.bTodosTotais)
                                 .Build());
            }

            return regOrcamento_ideAccessor.Execute(idOrcamento).FirstOrDefault();
        }

        public Orcamento_ideModel GetOrcamentoByOrigem(int idOrcamento)
        {
            DataAccessor<Orcamento_ideModel> reg = UndTrabalho.dbPrincipal.CreateSqlStringAccessor
            ("select * from Orcamento_ide where idOrcamento = @idOrcamento",
            new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idOrcamento"),
            MapBuilder<Orcamento_ideModel>.MapAllProperties()
            .DoNotMap(c => c.orcamento_Total_Impostos)
            .DoNotMap(i => i.orcamento_retTransp)
            .DoNotMap(i => i.status)
            .DoNotMap(i => i.xDepartamento)
            .DoNotMap(i => i.xCidade)
            .DoNotMap(i => i.xUf)
            .DoNotMap(i => i.xTelefone)
            .DoNotMap(i => i.idRamoAtividade)
            .DoNotMap(i => i.idCanalVenda)
            .DoNotMap(i => i.bIsEnabledClListaPreco)
                                .DoNotMap(i => i.bCriado)
                                .DoNotMap(i => i.bEnviado)
                                .DoNotMap(i => i.bCancelado)
                                .DoNotMap(i => i.bPerdido)
                                .DoNotMap(i => i.bConfirmado)
                                .DoNotMap(i => i.bTodos)
                                .DoNotMap(i => i.objListaPreco)
                                .DoNotMap(i => i.objTipoDocumento)
                                .DoNotMap(i => i.bCriadoTotais)
                                .DoNotMap(i => i.bConfirmadoTotais)
                                .DoNotMap(i => i.bEnviadoTotais)
                                .DoNotMap(i => i.bPerdidoTotais)
                                .DoNotMap(i => i.bCanceladoTotais)
                                .DoNotMap(i => i.bTodosTotais)
            .Build());
            return reg.Execute(parameterValues: idOrcamento).FirstOrDefault();
        }

        public Orcamento_ideModel GetOrcamentoFilho(int idOrcamento)
        {
            DataAccessor<Orcamento_ideModel> reg = UndTrabalho.dbPrincipal.CreateSqlStringAccessor
            ("select * from Orcamento_ide where idOrcamentoOrigem = @idOrcamento",
            new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idOrcamento"),
            MapBuilder<Orcamento_ideModel>.MapAllProperties()
            .DoNotMap(c => c.orcamento_Total_Impostos)
            .DoNotMap(i => i.orcamento_retTransp)
            .DoNotMap(i => i.status)
            .DoNotMap(i => i.xDepartamento)
            .DoNotMap(i => i.xCidade)
            .DoNotMap(i => i.xUf)
            .DoNotMap(i => i.xTelefone)
            .DoNotMap(i => i.idRamoAtividade)
            .DoNotMap(i => i.idCanalVenda)
            .DoNotMap(i => i.bCriado)
            .DoNotMap(i => i.bIsEnabledClListaPreco)
                                .DoNotMap(i => i.bEnviado)
                                .DoNotMap(i => i.bCancelado)
                                .DoNotMap(i => i.bPerdido)
                                .DoNotMap(i => i.bConfirmado)
                                .DoNotMap(i => i.bTodos)
                                .DoNotMap(i => i.objListaPreco)
                                .DoNotMap(i => i.objTipoDocumento)
                                .DoNotMap(i => i.bCriadoTotais)
                                .DoNotMap(i => i.bConfirmadoTotais)
                                .DoNotMap(i => i.bEnviadoTotais)
                                .DoNotMap(i => i.bPerdidoTotais)
                                .DoNotMap(i => i.bCanceladoTotais)
                                .DoNotMap(i => i.bTodosTotais)
            .Build());
            return reg.Execute(parameterValues: idOrcamento).FirstOrDefault();
        }

        public List<Orcamento_ideModel> GetAllOrcamento_ide()
        {
            if (regAllOrcamento_ideAccessor == null)
            {
                regAllOrcamento_ideAccessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor("SELECT * FROM Orcamento_ide",
                                MapBuilder<Orcamento_ideModel>
                                .MapAllProperties()
                                .DoNotMap(i => i.status)
                                .DoNotMap(i => i.xDepartamento)
                                .DoNotMap(i => i.xCidade)
                                .DoNotMap(i => i.xUf)
                                .DoNotMap(i => i.xTelefone)
                                .DoNotMap(i => i.idRamoAtividade)
                                .DoNotMap(i => i.bCriado)
                                .DoNotMap(i => i.bEnviado)
                                .DoNotMap(i => i.bCancelado)
                                .DoNotMap(i => i.bPerdido)
                                .DoNotMap(i => i.bConfirmado)
                                .DoNotMap(i => i.bTodos)
                                .DoNotMap(i => i.bIsEnabledClListaPreco)
                                .DoNotMap(i => i.objListaPreco)
                                .DoNotMap(i => i.bCriadoTotais)
                                .DoNotMap(i => i.bConfirmadoTotais)
                                .DoNotMap(i => i.bEnviadoTotais)
                                .DoNotMap(i => i.bPerdidoTotais)
                                .DoNotMap(i => i.bCanceladoTotais)
                                .DoNotMap(i => i.bTodosTotais)
                                .Build());
            }
            return regAllOrcamento_ideAccessor.Execute().ToList();
        }

        public int GetIdOrcamentoFilho(int idOrcamentoOrigem)
        {
            DbCommand command = UndTrabalho.dbPrincipal.GetSqlStringCommand("select idOrcamento from Orcamento_ide where idOrcamentoOrigem = " + idOrcamentoOrigem);
            object o = UndTrabalho.dbPrincipal.ExecuteScalar(command);
            return o != null ? o.ToInt32() : 0;
        }

        public int GetIdOrcamentoPai(int idOrcamento)
        {
            DbCommand command = UndTrabalho.dbPrincipal.GetSqlStringCommand("select idOrcamentoOrigem from Orcamento_ide where idOrcamento = " + idOrcamento);
            object o = UndTrabalho.dbPrincipal.ExecuteScalar(command);
            return o != null ? o.ToInt32() : 0;
        }

        public void BeginTransaction()
        {
            UndTrabalho.BeginTransaction();
        }
        public void CommitTransaction()
        {
            UndTrabalho.CommitTransaction();
        }
        public void RollackTransaction()
        {
            UndTrabalho.RollBackTransaction();
        }
    }

}
