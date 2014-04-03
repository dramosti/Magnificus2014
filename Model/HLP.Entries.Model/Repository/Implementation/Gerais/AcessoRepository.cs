using HLP.Base.ClassesBases;
using HLP.Base.Static;
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
    public class AcessoRepository : IAcessoRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Funcionario_AcessoModel> regAcessoAccessor;
        private DataAccessor<Funcionario_AcessoModel> regAllAcessoAccessor;

        public void Save(Funcionario_AcessoModel objAcesso)
        {
            if (objAcesso.idAcesso == null)
            {
                objAcesso.idAcesso = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                    UndTrabalho.dbTransaction,
                    "dbo.Proc_save_Acesso",
                ParameterBase<Funcionario_AcessoModel>.SetParameterValue(objAcesso));
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar(
                UndTrabalho.dbTransaction,
            "[dbo].[Proc_update_Acesso]",
            ParameterBase<Funcionario_AcessoModel>.SetParameterValue(objAcesso));
            }
        }

        public void Delete(int idAcesso)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar(
                UndTrabalho.dbTransaction,
                "dbo.Proc_delete_Acesso",
                 UserData.idUser,
                 idAcesso);
        }

        public void Delete(Funcionario_AcessoModel objAcesso)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar(
                UndTrabalho.dbTransaction,
                "dbo.Proc_delete_Acesso",
                  UserData.idUser,
                  objAcesso.idAcesso, objAcesso.idEmpresa, objAcesso.idFuncionario);
        }

        public int Copy(Funcionario_AcessoModel objFuncionario_Acesso)
        {
            return (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                UndTrabalho.dbTransaction,
                      "dbo.Proc_copy_Acesso",
                       objFuncionario_Acesso, objFuncionario_Acesso.idFuncionario);
        }

        public Funcionario_AcessoModel GetAcesso(int idAcesso)
        {
            if (regAcessoAccessor == null)
            {
                regAcessoAccessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("dbo.Proc_sel_Acesso",
                                 new Parameters(UndTrabalho.dbPrincipal)
                                 .AddParameter<int>("idAcesso"),
                                 MapBuilder<Funcionario_AcessoModel>.MapAllProperties().DoNotMap(i => i.status).Build());
            }

            return regAcessoAccessor.Execute(idAcesso).FirstOrDefault();
        }

        public List<Funcionario_AcessoModel> GetAllAcesso()
        {
            if (regAllAcessoAccessor == null)
            {
                regAllAcessoAccessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor("SELECT * FROM Acesso",
                                MapBuilder<Funcionario_AcessoModel>.MapAllProperties().DoNotMap(i => i.status).Build());
            }
            return regAllAcessoAccessor.Execute().ToList();
        }

        public List<Funcionario_AcessoModel> GetAllAcesso_Funcionario(int idFuncionario)
        {
            DataAccessor<Funcionario_AcessoModel> reg = UndTrabalho.dbPrincipal.CreateSqlStringAccessor
            ("SELECT * FROM Acesso WHERE idFuncionario = @idFuncionario", new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idFuncionario"),
            MapBuilder<Funcionario_AcessoModel>.MapAllProperties().DoNotMap(i => i.status).Build());

            return reg.Execute(idFuncionario).ToList();
        }

        public int getCountLoginUsuario(string xLogin, string xSenha, int idFuncionario)
        {
            System.Data.Common.DbCommand comand = UndTrabalho.dbPrincipal.GetSqlStringCommand
                              (string.Format("select count(xID) from Funcionario where xID = '" + xLogin
                              + "' and xSenha = '" + xSenha + "' and idFuncionario <> "+idFuncionario+""));

            return (int)UndTrabalho.dbPrincipal.ExecuteScalar(comand);
        }
    }
}
