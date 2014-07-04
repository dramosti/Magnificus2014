using HLP.Base.ClassesBases;
using HLP.Base.Static;
using HLP.Entries.Model.Models.Financeiro;
using HLP.Entries.Model.Repository.Interfaces.Financeiro;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Implementation.Financeiro
{
    public class Conta_bancariaRepository : IConta_bancariaRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Conta_bancariaModel> regContaAccessor;

        private DataAccessor<Conta_bancariaModel> regContaByAgenciaAccessor;

        public List<Conta_bancariaModel> GetByAgencia(int idAgencia)
        {
            if (regContaByAgenciaAccessor == null)
            {
                regContaByAgenciaAccessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor("SELECT * FROM Conta_bancaria WHERE idAgencia = @idAgencia",
                                  new Parameters(UndTrabalho.dbPrincipal)
                                    .AddParameter<int>("idAgencia"),
                                  MapBuilder<Conta_bancariaModel>.MapAllProperties()
                                  .DoNotMap(i => i.idBanco)
                                  .DoNotMap(i => i.status).Build());
            }


            return regContaByAgenciaAccessor.Execute(idAgencia).ToList();
        }

        public Conta_bancariaModel GetConta(int idContaBancaria)
        {
            if (regContaAccessor == null)
            {
                regContaAccessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("dbo.Proc_sel_conta_bancaria",
                                  new Parameters(UndTrabalho.dbPrincipal)
                                    .AddParameter<int>("idContaBancaria"),
                                  MapBuilder<Conta_bancariaModel>.MapAllProperties()
                                  .DoNotMap(i => i.idBanco)
                                  .DoNotMap(i => i.status).Build());
            }
            return regContaAccessor.Execute(idContaBancaria).FirstOrDefault();
        }

        public void Save(Conta_bancariaModel conta)
        {
            if (conta.idContaBancaria == null)
            {

                int idContaBancaria = Convert.ToInt32((UndTrabalho.dbPrincipal.ExecuteScalar("dbo.Proc_save_conta_bancaria",
                 ParameterBase<Conta_bancariaModel>.SetParameterValue(conta))));

                conta.idContaBancaria = idContaBancaria;
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar("[dbo].[Proc_update_Conta_bancaria]",
                 ParameterBase<Conta_bancariaModel>.SetParameterValue(conta));
            }
        }

        public void Delete(int idContaBancaria)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar("dbo.Proc_delete_conta_bancaria",
                  UserData.idUser,
                  idContaBancaria);
        }


        public int Copy(int idContaBancaria)
        {
            return (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                        "dbo.Proc_copy_conta_bancaria",
                         idContaBancaria);
        }


    }
}
