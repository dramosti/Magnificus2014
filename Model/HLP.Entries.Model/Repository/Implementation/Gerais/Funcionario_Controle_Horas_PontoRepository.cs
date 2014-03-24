using HLP.Comum.Infrastructure;
using HLP.Comum.Infrastructure.Static;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.Model.Repository.Interfaces.Gerais;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
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

        public List<Funcionario_Controle_Horas_PontoModel> GetAllFuncionario_Controle_Horas_Ponto(int idFuncionario, DateTime dtMes)
        {
            if (regAllFuncionario_Controle_Horas_PontoAccessor == null)
            {
                regAllFuncionario_Controle_Horas_PontoAccessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor("SELECT * FROM Funcionario_Controle_Horas_Ponto "
                    + string.Format("where idFuncionario = {0} and concat(DATEPART(MM,dRelogioPonto),DATEPART(YY,dRelogioPonto)) = {1}", idFuncionario, dtMes.Month.ToString() + dtMes.Year.ToString()),
                                MapBuilder<Funcionario_Controle_Horas_PontoModel>.MapAllProperties().DoNotMap(i => i.status).Build());
            }
            return regAllFuncionario_Controle_Horas_PontoAccessor.Execute().ToList();
        }

        public List<Funcionario_Controle_Horas_PontoModel> GetAllFuncionario_Controle_Horas_PontoDia(int idFuncionario, DateTime dtDia)
        {
            if (regAllFuncionario_Controle_Horas_PontoAccessor == null)
            {
                regAllFuncionario_Controle_Horas_PontoAccessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor("SELECT * FROM Funcionario_Controle_Horas_Ponto "
                    + string.Format("where idFuncionario = {0} and dRelogioPonto = '{1}'", idFuncionario, dtDia.Date.ToString("yyyy-MM-dd")),
                                MapBuilder<Funcionario_Controle_Horas_PontoModel>.MapAllProperties().DoNotMap(i => i.status).Build());
            }
            return regAllFuncionario_Controle_Horas_PontoAccessor.Execute().ToList();
        }

        public List<EspelhoPontoModel> GetHorasAtrabalhadasDia(int idFuncionario, DateTime dRelogioPonto)
        {
            try
            {
                if (regAllFuncionario_Controle_Horas_PontoAccessor == null)
                {
                    regAllFuncionario_Controle_Horas_PontoAccessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor("SELECT * FROM Funcionario_Controle_Horas_Ponto where idFuncionario = @idFuncionario and dRelogioPonto = @dRelogioPonto",
                                    new Parameters(UndTrabalho.dbPrincipal)
                                    .AddParameter<int>("idFuncionario")
                                    .AddParameter<DateTime>("dRelogioPonto"),
                                    MapBuilder<Funcionario_Controle_Horas_PontoModel>.MapAllProperties().DoNotMap(c => c.status).Build());
                }
                var dados = regAllFuncionario_Controle_Horas_PontoAccessor.Execute(idFuncionario, dRelogioPonto).ToList();
                EspelhoPontoModel objEspelhoPontoModel;
                List<EspelhoPontoModel> lret = new List<EspelhoPontoModel>();
                if (dados.Count() > 1)
                    for (int i = 0; i+1 < dados.Count(); )
                    {
                        objEspelhoPontoModel = new EspelhoPontoModel();
                        objEspelhoPontoModel.tEntrada = dados[i].hRelogioPonto;
                        objEspelhoPontoModel.tSaida = dados[i + 1].hRelogioPonto;
                        lret.Add(objEspelhoPontoModel);
                        i = i + 2;
                    }
                if ((dados.Count() % 2) != 0)
                {
                    lret.Add(new EspelhoPontoModel
                    {
                        tEntrada = dados.LastOrDefault().hRelogioPonto
                    });
                }
                return lret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
