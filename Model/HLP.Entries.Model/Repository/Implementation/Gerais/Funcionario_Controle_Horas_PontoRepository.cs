using HLP.Comum.Infrastructure;
using HLP.Comum.Infrastructure.Static;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.Model.Repository.Interfaces.Gerais;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Implementation.Gerais
{
    public class Funcionario_Controle_Horas_PontoRepository : IFuncionario_Controle_Horas_PontoRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Funcionario_Controle_Horas_PontoModel> regFuncionario_Controle_Horas_PontoAccessor;
        private DataAccessor<Funcionario_Controle_Horas_PontoModel> regAllFuncionario_Controle_Horas_PontoAccessor;

        public void Save(Funcionario_Controle_Horas_PontoModel objFuncionario_Controle_Horas_Ponto)
        {
            if (objFuncionario_Controle_Horas_Ponto.idFuncionarioControleHorasPonto == null)
            {
                objFuncionario_Controle_Horas_Ponto.idFuncionarioControleHorasPonto = (int)UndTrabalho.dbPrincipal.ExecuteScalar("dbo.Proc_save_Funcionario_Controle_Horas_Ponto",
                ParameterBase<Funcionario_Controle_Horas_PontoModel>.SetParameterValue(objFuncionario_Controle_Horas_Ponto));
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar("dbo.Proc_update_Funcionario_Controle_Horas_Ponto",
                ParameterBase<Funcionario_Controle_Horas_PontoModel>.SetParameterValue(objFuncionario_Controle_Horas_Ponto));
            }
        }

        public void Delete(int idFuncionarioControleHorasPonto)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar("dbo.Proc_delete_Funcionario_Controle_Horas_Ponto",
                 UserData.idUser,
                 idFuncionarioControleHorasPonto);
        }

        public void DeleteByFuncionario(int idFuncionario)
        {
            UndTrabalho.dbPrincipal.ExecuteNonQuery(
                UndTrabalho.dbTransaction,
                System.Data.CommandType.Text,
              "DELETE Funcionario_Controle_Horas_Ponto WHERE idFuncionario = " + idFuncionario);
        }

        public Funcionario_Controle_Horas_PontoModel GetFuncionario_Controle_Horas_Ponto(int idFuncionarioControleHorasPonto)
        {
            if (regFuncionario_Controle_Horas_PontoAccessor == null)
            {
                regFuncionario_Controle_Horas_PontoAccessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("dbo.Proc_sel_Funcionario_Controle_Horas_Ponto",
                                 new Parameters(UndTrabalho.dbPrincipal)
                                 .AddParameter<int>("idFuncionarioControleHorasPonto"),
                                 MapBuilder<Funcionario_Controle_Horas_PontoModel>.MapAllProperties().DoNotMap(i => i.status).Build());
            }

            return regFuncionario_Controle_Horas_PontoAccessor.Execute(idFuncionarioControleHorasPonto).FirstOrDefault();
        }

        public List<Funcionario_Controle_Horas_PontoModel> GetAllFuncionario_Controle_Horas_Ponto(int idFuncionario, DateTime data)
        {
            if (regAllFuncionario_Controle_Horas_PontoAccessor == null)
            {
                regAllFuncionario_Controle_Horas_PontoAccessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor("SELECT * FROM Funcionario_Controle_Horas_Ponto "
                    + string.Format("where idFuncionario = {0} and concat(DATEPART(MM,dRelogioPonto),DATEPART(YY,dRelogioPonto)) = {1}", idFuncionario, data.Day.ToString() + data.Year.ToString()),
                                MapBuilder<Funcionario_Controle_Horas_PontoModel>.MapAllProperties().Build());
            }
            return regAllFuncionario_Controle_Horas_PontoAccessor.Execute().ToList();
        }



        public void BeginTransaction()
        {
            UndTrabalho.BeginTransaction();
        }

        public void CommitTransaction()
        {
            UndTrabalho.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            UndTrabalho.RollBackTransaction();
        }
    }
}
