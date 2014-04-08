using HLP.Base.ClassesBases;
using HLP.Base.Static;
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
        private DataAccessor<Funcionario_Controle_Horas_PontoModel> regAllFuncionario_Controle_Horas_PontoAccessorDia;
        private DataAccessor<Calendario_DetalheModel> regCalendario_DetalheModelAccessorDia;

        private DataAccessor<Funcionario_Controle_Horas_PontoModel> regHorasAtrabalhadasDiaAccessorDia;


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
            regAllFuncionario_Controle_Horas_PontoAccessorDia = UndTrabalho.dbPrincipal.CreateSqlStringAccessor("SELECT * FROM Funcionario_Controle_Horas_Ponto "
                + string.Format("where idFuncionario = {0} and dRelogioPonto = '{1}'", idFuncionario, dtDia.Date.ToString("yyyy-MM-dd")),
                            MapBuilder<Funcionario_Controle_Horas_PontoModel>.MapAllProperties().DoNotMap(i => i.status).Build());
            return regAllFuncionario_Controle_Horas_PontoAccessorDia.Execute().ToList();
        }

        public List<EspelhoPontoModel> GetHorasTrabalhadasDia(int idFuncionario, DateTime dRelogioPonto)
        {
            try
            {
                if (regHorasAtrabalhadasDiaAccessorDia == null)
                {
                    regHorasAtrabalhadasDiaAccessorDia = UndTrabalho.dbPrincipal.CreateSqlStringAccessor("SELECT * FROM Funcionario_Controle_Horas_Ponto where idFuncionario = @idFuncionario and dRelogioPonto = @dRelogioPonto",
                                    new Parameters(UndTrabalho.dbPrincipal)
                                    .AddParameter<int>("idFuncionario")
                                    .AddParameter<DateTime>("dRelogioPonto"),
                                    MapBuilder<Funcionario_Controle_Horas_PontoModel>.MapAllProperties().DoNotMap(c => c.status).Build());
                }
                var dados = regHorasAtrabalhadasDiaAccessorDia.Execute(idFuncionario, dRelogioPonto).ToList();
                EspelhoPontoModel objEspelhoPontoModel;
                List<EspelhoPontoModel> lret = new List<EspelhoPontoModel>();
                if (dados.Count() > 1)
                    for (int i = 0; i + 1 < dados.Count(); )
                    {
                        objEspelhoPontoModel = new EspelhoPontoModel();
                        //Entrada
                        objEspelhoPontoModel.tEntrada = dados[i].hRelogioPonto;
                        if (dados[i].hAlteradaUsuario != null)
                            if (dados[i].hAlteradaUsuario != new TimeSpan())
                                objEspelhoPontoModel.tEntrada = (TimeSpan)dados[i].hAlteradaUsuario;
                        //Saída
                        objEspelhoPontoModel.tSaida = dados[i + 1].hRelogioPonto;
                        if (dados[i + 1].hAlteradaUsuario != null)
                            if (dados[i + 1].hAlteradaUsuario != new TimeSpan())
                                objEspelhoPontoModel.tSaida = (TimeSpan)dados[i + 1].hAlteradaUsuario;

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

        public List<Calendario_DetalheModel> GetHorasAtrabalharDia(int idFuncionario, DateTime dtDia)
        {
            if (regCalendario_DetalheModelAccessorDia == null)
            {
                regCalendario_DetalheModelAccessorDia = UndTrabalho.dbPrincipal.CreateSqlStringAccessor(
                    string.Format("select * from Funcionario inner join Calendario "
                                    + "on Funcionario.idCalendario = Calendario.idCalendario inner join Calendario_Detalhe "
                                    + "on Calendario.idCalendario = Calendario_Detalhe.idCalendario "
                                    + "where Funcionario.idFuncionario = {0} and Calendario_Detalhe.dCalendario = '{1}' ", idFuncionario, dtDia.Date.ToString("yyyy-MM-dd")),
                                MapBuilder<Calendario_DetalheModel>.MapAllProperties()
                                .DoNotMap(i => i.idCalendarioDetalhe)
                                .DoNotMap(i => i.dCalendario)
                                .DoNotMap(i => i.idCalendario)
                                .DoNotMap(i => i.status).Build());
            }
            return regCalendario_DetalheModelAccessorDia.Execute().ToList();
        }
        private List<TimeSpan> GetListHorasAtrabalharDia(int idFuncionario, DateTime dtDia)
        {

            DbCommand command = UndTrabalho.dbPrincipal.GetSqlStringCommand
                (
                string.Format("select Calendario_Detalhe.tHoraInicio, Calendario_Detalhe.tHoraTermino from Funcionario inner join Calendario "
                + "on Funcionario.idCalendario = Calendario.idCalendario inner join Calendario_Detalhe "
                + "on Calendario.idCalendario = Calendario_Detalhe.idCalendario "
                + "where Funcionario.idFuncionario = {0} and Calendario_Detalhe.dCalendario = '{1}' ", idFuncionario, dtDia.Date.ToString("yyyy-MM-dd"))
                );

            IDataReader reader = UndTrabalho.dbPrincipal.ExecuteReader(command);

            List<TimeSpan> lReturn = new List<TimeSpan>();
            TimeSpan tInicio;
            TimeSpan tFinal;
            while (reader.Read())
            {
                tInicio = new TimeSpan();
                tFinal = new TimeSpan();
                if (reader["tHoraInicio"] != null && reader["tHoraTermino"] != null)
                {
                    tInicio = new TimeSpan(
                        Convert.ToInt32(reader["tHoraInicio"].ToString().Split(':')[0]),
                        Convert.ToInt32(reader["tHoraInicio"].ToString().Split(':')[1]),
                        Convert.ToInt32(reader["tHoraInicio"].ToString().Split(':')[2]));
                    tFinal = new TimeSpan(
                        Convert.ToInt32(reader["tHoraTermino"].ToString().Split(':')[0]),
                        Convert.ToInt32(reader["tHoraTermino"].ToString().Split(':')[1]),
                        Convert.ToInt32(reader["tHoraTermino"].ToString().Split(':')[2]));

                    lReturn.Add(tFinal.Subtract(tInicio));
                }
            }
            return lReturn;
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

        public int GetTotalDiasTrabalhadosMes(int idFuncionario, DateTime dtMes)
        {
            try
            {
                DbCommand command = UndTrabalho.dbPrincipal.GetSqlStringCommand
               (
                    string.Format("select  DISTINCT dRelogioPonto from Funcionario_Controle_Horas_Ponto " +
                    "where idFuncionario = {0} and concat(DATEPART(MM,dRelogioPonto),DATEPART(YY,dRelogioPonto)) = {1}",
                    idFuncionario, dtMes.Month.ToString() + dtMes.Year.ToString())
               );
                IDataReader reader = UndTrabalho.dbPrincipal.ExecuteReader(command);
                int icount = 0;
                while (reader.Read())
                {
                    icount++;
                }
                return icount;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TimeSpan GetHorasATrabalharMes(int idFuncionario, DateTime dtMes)
        {
            try
            {
                int iDias = DateTime.DaysInMonth(dtMes.Year, dtMes.Month);
                TimeSpan tsReturn = new TimeSpan();
                for (int i = 1; i < iDias; i++)
                {
                    foreach (TimeSpan ts in this.GetListHorasAtrabalharDia(idFuncionario, new DateTime(dtMes.Year, dtMes.Month, i)))
                    {
                        tsReturn = tsReturn.Add(ts);
                    }
                }
                return tsReturn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
