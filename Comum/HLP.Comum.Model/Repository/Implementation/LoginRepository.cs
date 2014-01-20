using HLP.Comum.Infrastructure;
using HLP.Comum.Model.Repository.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Comum.Model.Repository.Implementation
{
    public class LoginRepository : ILoginRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        public int ValidaUsuario(string xId)
        {

            DbCommand comand = UndTrabalho.dbPrincipal.GetSqlStringCommand
                              (
                              string.Format("SELECT COUNT(*) FROM FUNCIONARIO WHERE xId = '{0}'", xId)
                              );

            return (int)UndTrabalho.dbPrincipal.ExecuteScalar(comand);
        }

        public int GetIdFuncionarioByXid(string xId)
        {

            DbCommand comand = UndTrabalho.dbPrincipal.GetSqlStringCommand
                              (
                              string.Format("select idFuncionario from Funcionario where xID = '{0}'", xId)
                              );

            return (int)UndTrabalho.dbPrincipal.ExecuteScalar(comand);
        }

        public int ValidaLogin(string xID, string xSenha)
        {
            DbCommand comand = UndTrabalho.dbPrincipal.GetSqlStringCommand
                              (
                              string.Format("SELECT COUNT(*) FROM FUNCIONARIO WHERE xid = '{0}' and xSenha = '{1}'", xID, xSenha)
                              );

            return (int)UndTrabalho.dbPrincipal.ExecuteScalar(comand);
        }

        public int ValidaAcesso(string xId, int idEmpresa)
        {
            DbCommand comand = UndTrabalho.dbPrincipal.GetSqlStringCommand
                              (
                              string.Format("select count(*) from Acesso a" +
                                            " inner join Funcionario f" +
                                            " on f.idFuncionario = a.idFuncionario" +
                                            " where" +
                                            " f.xID = '{0}' AND a.idEmpresa = {1}", xId, idEmpresa)
                              );

            return (int)UndTrabalho.dbPrincipal.ExecuteScalar(comand);
        }
    }
}
