using HLP.Comum.Infrastructure;
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
    public class Funcionario_BancoHorasRepository : IFuncionario_BancoHorasRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Funcionario_BancoHorasModel> regBancoHorasAccessor;
        private DataAccessor<Funcionario_BancoHorasModel> regBancoHorasMesAccessor;

        public TimeSpan GetTotalBancoHoras(int idFuncionario, DateTime dtMes)
        {
            if (regBancoHorasAccessor == null)
            {
                regBancoHorasAccessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor(
                    string.Format("SELECT * FROM Funcionario_BancoHoras where idFuncionario = {0} " + "and CAST(xMesAno as int) < {1}", idFuncionario,
                    Convert.ToInt32(dtMes.Month.ToString() + dtMes.Year.ToString())), MapBuilder<Funcionario_BancoHorasModel>.MapAllProperties()
                    .DoNotMap(c => c.status).Build());
            }
            TimeSpan tsTotalRet = new TimeSpan();
            foreach (var item in regBancoHorasAccessor.Execute().ToList())
            {
                tsTotalRet = tsTotalRet + item.tBancoHoras.TimeOfDay;
            }
            return tsTotalRet;
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

        public TimeSpan? GetTotalBancoHorasMesAtual(int idFuncionario, DateTime dtMes)
        {
            if (regBancoHorasMesAccessor == null)
            {
                regBancoHorasMesAccessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor(
                    string.Format("SELECT * FROM Funcionario_BancoHoras where idFuncionario = {0} " + "and CAST(xMesAno as int) = {1}", idFuncionario,
                    Convert.ToInt32(dtMes.Month.ToString() + dtMes.Year.ToString())), MapBuilder<Funcionario_BancoHorasModel>.MapAllProperties()
                    .DoNotMap(c => c.status).Build());
            }
            TimeSpan? tsTotalRet = null;

            List<Funcionario_BancoHorasModel> lreturn = regBancoHorasMesAccessor.Execute().ToList();
            if (lreturn.Count > 0)
            {
                tsTotalRet = new TimeSpan();
                foreach (var item in lreturn)
                {
                    tsTotalRet = tsTotalRet + item.tBancoHoras.TimeOfDay;
                }
            }
            return tsTotalRet;
        }

        public void DeleteBancoHorasMes(int idFuncionario, DateTime dtMes)
        {
            try
            {
                DbCommand cmd;
                string sql = string.Format("Delete from Funcionario_BancoHoras Where idFuncionario = {0} and CAST(xMesAno as int) = {1} ", idFuncionario, Convert.ToInt32(dtMes.Month.ToString() + dtMes.Year.ToString()));
                cmd = UndTrabalho.dbPrincipal.GetSqlStringCommand(sql);
                UndTrabalho.dbPrincipal.ExecuteScalar(UndTrabalho.dbTransaction, CommandType.Text, sql);
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}
