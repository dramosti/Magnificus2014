using HLP.Comum.Infrastructure;
using HLP.Comum.Infrastructure.Static;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.Model.Repository.Interfaces.Gerais;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Implementation.Gerais
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<FuncionarioModel> regFuncionarioAccessor;

        private DataAccessor<FuncionarioModel> getFuncionarioPaiAcessor;

        private DataAccessor<FuncionarioModel> GetListFuncionarioFilhoAcessor;

        public void Save(FuncionarioModel objFuncionario)
        {
            if (objFuncionario.idFuncionario == null)
            {
                objFuncionario.idFuncionario = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                    UndTrabalho.dbTransaction,
                "[dbo].[Proc_save_Funcionario]",
                ParameterBase<FuncionarioModel>.SetParameterValue(objFuncionario));
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar(
                    UndTrabalho.dbTransaction,
                "[dbo].[Proc_update_Funcionario]",
                ParameterBase<FuncionarioModel>.SetParameterValue(objFuncionario));
            }
        }

        public void Delete(int idFuncionario)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar(
            UndTrabalho.dbTransaction,
           "[dbo].[Proc_delete_Funcionario]",
            UserData.idUser,
            idFuncionario);
        }

        public void Copy(FuncionarioModel objFuncionario)
        {
            objFuncionario.idFuncionario = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
            UndTrabalho.dbTransaction,
           "dbo.Proc_copy_Funcionario",
            objFuncionario.idFuncionario);
        }

        public FuncionarioModel GetFuncionario(int idFuncionario)
        {

            if (regFuncionarioAccessor == null)
            {
                regFuncionarioAccessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("dbo.Proc_sel_Funcionario",
                                         new Parameters(UndTrabalho.dbPrincipal)
                                         .AddParameter<int>("idFuncionario"),
                                         MapBuilder<FuncionarioModel>.MapAllProperties()
                                         .DoNotMap(i => i.status)
                                         .DoNotMap(i => i.imgFoto)
                                         .Build());
            }

            FuncionarioModel func = regFuncionarioAccessor.Execute(idFuncionario).FirstOrDefault();

            object o = this.GetImageFuncionario(idFuncionario: idFuncionario);

            if (o != null)
                func.imgFoto = o as byte[];

            return func;
        }

        public FuncionarioModel GetFuncionarioPai(int idFuncionario)
        {

            getFuncionarioPaiAcessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor(
                    "select * from Funcionario where idFuncionario = " + idFuncionario,
                                         new Parameters(UndTrabalho.dbPrincipal),
                                         MapBuilder<FuncionarioModel>.MapAllProperties().DoNotMap(i => i.status)
                                         .Build());

            return getFuncionarioPaiAcessor.Execute().FirstOrDefault();
        }

        public List<FuncionarioModel> GetFuncionarioFilho(int idResponsavel)
        {

            GetListFuncionarioFilhoAcessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor(
                    "select * from Funcionario where idResponsavel = " + idResponsavel,
                                         new Parameters(UndTrabalho.dbPrincipal),
                                         MapBuilder<FuncionarioModel>.MapAllProperties().DoNotMap(i => i.status)
                                         .Build());

            return GetListFuncionarioFilhoAcessor.Execute().ToList();
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

        public List<FuncionarioModel> GetAllFuncionario()
        {
            List<FuncionarioModel> lFuncionarios = new List<FuncionarioModel>();

            return lFuncionarios = UndTrabalho.dbPrincipal.CreateSqlStringAccessor("SELECT * FROM FUNCIONARIO",
                                   new Parameters(UndTrabalho.dbPrincipal),
                                   MapBuilder<FuncionarioModel>.MapAllProperties().DoNotMap(i => i.status).Build()).Execute().ToList();
        }
        public string GetQueryFuncionarios()
        {
            return "Select (cast(c.idFuncionario as varchar) + ' - ' + c.xNome) as xNome, c.idFuncionario from Funcionario c";
        }

        public int ValidaNomeUsuario(string xId)
        {

            DbCommand comand = UndTrabalho.dbPrincipal.GetSqlStringCommand
                              (
                              string.Format("SELECT COUNT(*) FROM FUNCIONARIO WHERE xId = '{0}'", xId)
                              );

            return (int)UndTrabalho.dbPrincipal.ExecuteScalar(comand);
        }

        public int ValidaAcesso(int idEmpresa, int idUsuario)
        {
            DbCommand comand = UndTrabalho.dbPrincipal.GetSqlStringCommand
                              (
                              string.Format("SELECT COUNT(*) from Acesso WHERE idFuncionario = {0} and idEmpresa = {1}", idUsuario, idEmpresa)
                              );

            return (int)UndTrabalho.dbPrincipal.ExecuteScalar(comand);
        }

        public FuncionarioModel ValidaUsuario(string xID, string xSenha)
        {
            DataAccessor<FuncionarioModel> regUsuario = UndTrabalho.dbPrincipal.CreateSqlStringAccessor
                                  (
                                   string.Format("SELECT * FROM FUNCIONARIO WHERE xid = '{0}' and xSenha = '{1}'", xID, xSenha),
                                   MapBuilder<FuncionarioModel>.MapAllProperties().Build()
                                  );
            return regUsuario.Execute().FirstOrDefault();
        }

        public object GetImageFuncionario(int idFuncionario)
        {
            DbCommand command = UndTrabalho.dbPrincipal.GetSqlStringCommand(string.Format(
                format: "select imgFoto from Funcionario where idFuncionario = '{0}'", arg0: idFuncionario));

            return UndTrabalho.dbPrincipal.ExecuteScalar(command);
        }

        public int GetIdUserHLP()
        {
            DbCommand command = UndTrabalho.dbPrincipal.GetSqlStringCommand("select idFuncionario from Funcionario where stUsuario = 0");
            return UndTrabalho.dbPrincipal.ExecuteScalar(command).ToInt32();
        }
        public int GetIdUserDEFAULT()
        {
            DbCommand command = UndTrabalho.dbPrincipal.GetSqlStringCommand("select idFuncionario from Funcionario where stUsuario = 1");
            return UndTrabalho.dbPrincipal.ExecuteScalar(command).ToInt32();
        }

        public string GetQueryUserByEmpresaToComboBox()
        {
            return "SELECT ID as idUsuario,(CAST(ID AS varchar)+' - '+ xNome)xNome  FROM vwFuncionario Where idEmpresa = " + CompanyData.idEmpresa.ToString();
        }
    }

}
