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
    public class Funcionario_CertificacaoRepository : IFuncionario_CertificacaoRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Funcionario_CertificacaoModel> regAcessor;

        public void Save(Funcionario_CertificacaoModel objFuncionario_Certificacao)
        {
            if (objFuncionario_Certificacao.idFuncionarioCertificacao == null)
            {
                objFuncionario_Certificacao.idFuncionarioCertificacao = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                    UndTrabalho.dbTransaction,
               "[dbo].[Proc_save_Funcionario_Certificacao]",
                ParameterBase<Funcionario_CertificacaoModel>.SetParameterValue(objFuncionario_Certificacao));
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar(
                UndTrabalho.dbTransaction,
            "[dbo].[Proc_update_Funcionario_Certificacao]",
            ParameterBase<Funcionario_CertificacaoModel>.SetParameterValue(objFuncionario_Certificacao)); ;
            }
        }

        public void Delete(Funcionario_CertificacaoModel objFuncionario_Certificacao)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar(
                UndTrabalho.dbTransaction,
                "[dbo].[Proc_delete_Funcionario_Certificacao]",
                  UserData.idUser,
                  objFuncionario_Certificacao.idFuncionarioCertificacao);
        }

        public void Delete(int idFuncionario)
        {
            UndTrabalho.dbPrincipal.ExecuteNonQuery(
                UndTrabalho.dbTransaction,
                System.Data.CommandType.Text,
              "DELETE Funcionario_Certificacao WHERE idFuncionario = " + idFuncionario);
        }

        public void Copy(Funcionario_CertificacaoModel objFuncionario_Certificacao)
        {
            objFuncionario_Certificacao.idFuncionarioCertificacao = null;
            objFuncionario_Certificacao.idFuncionarioCertificacao = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                                           UndTrabalho.dbTransaction,
                                           "[dbo].[Proc_save_Funcionario_Certificacao]",
        ParameterBase<Funcionario_CertificacaoModel>.SetParameterValue(objFuncionario_Certificacao));
        }

        public Funcionario_CertificacaoModel GetFuncionario_Certificacao(int idFuncionarioCertificacao)
        {
            if (regAcessor == null)
            {
                regAcessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("[dbo].[Proc_sel_Funcionario_Certificacao]",
                   new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idFuncionarioCertificacao"),
                   MapBuilder<Funcionario_CertificacaoModel>.MapAllProperties()
                   .DoNotMap(i => i.status)
                   .DoNotMap(i => i.enumTipoCertificacao)
                   .Build());
            }
            return regAcessor.Execute(idFuncionarioCertificacao).FirstOrDefault();
        }

        public List<Funcionario_CertificacaoModel> GetAllFuncionario_Certificacao(int idFuncionario)
        {
            DataAccessor<Funcionario_CertificacaoModel> reg = UndTrabalho.dbPrincipal.CreateSqlStringAccessor
            ("SELECT * FROM Funcionario_Certificacao WHERE idFuncionario = @idFuncionario", new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idFuncionario"),
            MapBuilder<Funcionario_CertificacaoModel>.MapAllProperties()
            .DoNotMap(i => i.status)
            .DoNotMap(i => i.enumTipoCertificacao)
            .Build());

            return reg.Execute(idFuncionario).ToList();
        }
    }
}
