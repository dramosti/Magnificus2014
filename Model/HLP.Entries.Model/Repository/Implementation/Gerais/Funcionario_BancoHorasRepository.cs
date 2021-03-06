﻿using HLP.Base.ClassesBases;
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
using HLP.Base.Static;

namespace HLP.Entries.Model.Repository.Implementation.Gerais
{
    public class Funcionario_BancoHorasRepository : IFuncionario_BancoHorasRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Funcionario_BancoHorasModel> regBancoHorasMesAccessor;

        public TimeSpan GetTotalBancoHoras(int idFuncionario, DateTime dtMes)
        {

            DataAccessor<Funcionario_BancoHorasModel> regBancoHorasAccessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor(
                    string.Format("SELECT * FROM Funcionario_BancoHoras where idFuncionario = {0} " + "and CAST(xMesAno as int) < {1}", idFuncionario,
                    Convert.ToInt32(dtMes.Month.ToString() + dtMes.Year.ToString())), MapBuilder<Funcionario_BancoHorasModel>.MapAllProperties()
                     .DoNotMap(c => c.status)
                     .DoNotMap(c => c.tsSaldoAteMomento)
                     .Build());
            TimeSpan tsTotalRet = new TimeSpan();
            foreach (var item in regBancoHorasAccessor.Execute().ToList())
            {
                tsTotalRet = tsTotalRet.Add(item.tBancoHoras.ToTimeSpan());
            }
            return tsTotalRet;
        }


        public string GetJustificativaPontoDia(int idFuncionario, DateTime data) 
        {

            DbCommand command = UndTrabalho.dbPrincipal.GetSqlStringCommand
              (
                    string.Format("SELECT DISTINCT coalesce(xJustificativa,'')xJustificativa FROM Funcionario_Controle_Horas_Ponto"
                        + " where idFuncionario = {0} " + "and dRelogioPonto = '{1}'", idFuncionario,
                    data.ToString("yyyy-MM-dd"))
              );
            IDataReader reader = UndTrabalho.dbPrincipal.ExecuteReader(command);
            string xJustificativa = "";
            while (reader.Read())
            {
                xJustificativa += reader["xJustificativa"].ToString();
            }
            return xJustificativa;
        }


        public void Save(Funcionario_BancoHorasModel objFuncionario_BancoHoras)
        {
            if (objFuncionario_BancoHoras.idFuncionarioBancoHoras == null)
            {
                objFuncionario_BancoHoras.idFuncionarioBancoHoras = (int)UndTrabalho.dbPrincipal.ExecuteScalar("dbo.Proc_save_Funcionario_BancoHoras",
                ParameterBase<Funcionario_BancoHorasModel>.SetParameterValue(objFuncionario_BancoHoras));
            }
            else
            {
                objFuncionario_BancoHoras.idFuncionarioBancoHoras = (int)UndTrabalho.dbPrincipal.ExecuteScalar("dbo.Proc_update_Funcionario_BancoHoras",
                ParameterBase<Funcionario_BancoHorasModel>.SetParameterValue(objFuncionario_BancoHoras));
            }
        }

        public Funcionario_BancoHorasModel GetTotalBancoHorasMesAtual(int idFuncionario, DateTime dtMes)
        {
            regBancoHorasMesAccessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor(
                string.Format("SELECT * FROM Funcionario_BancoHoras where idFuncionario = {0} " + "and CAST(xMesAno as int) = {1}", idFuncionario,
                Convert.ToInt32(dtMes.Month.ToString() + dtMes.Year.ToString())), MapBuilder<Funcionario_BancoHorasModel>.MapAllProperties()
                .DoNotMap(c => c.status)
                .DoNotMap(c => c.tsSaldoAteMomento)
                .Build());
            //TimeSpan? tsTotalRet = null;
            //List<Funcionario_BancoHorasModel> lreturn = regBancoHorasMesAccessor.Execute().ToList();
            //if (lreturn.Count > 0)
            //{
            //    tsTotalRet = new TimeSpan();
            //    foreach (var item in lreturn)
            //    {
            //        tsTotalRet = tsTotalRet + item.tBancoHoras.ToTimeSpan();
            //    }
            //}
            //return tsTotalRet;

            return regBancoHorasMesAccessor.Execute().FirstOrDefault();
        }

        public void DeleteBancoHorasMes(int idFuncionario, DateTime dtMes)
        {
            try
            {
                DbCommand cmd;
                string sql = string.Format("Delete from Funcionario_BancoHoras Where idFuncionario = {0} and CAST(xMesAno as int) = {1} ", idFuncionario, Convert.ToInt32(dtMes.Month.ToString() + dtMes.Year.ToString()));
                cmd = UndTrabalho.dbPrincipal.GetSqlStringCommand(sql);
                UndTrabalho.dbPrincipal.ExecuteScalar(CommandType.Text, sql);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
