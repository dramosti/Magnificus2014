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
    public class Agencia_ContatoRepository : IAgencia_ContatoRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Agencia_ContatoModel> regAcessor;

        public void Save(Agencia_ContatoModel objAgencia_Contato)
        {
            if (objAgencia_Contato.idAgenciaContato == null)
            {
                objAgencia_Contato.idAgenciaContato = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                    UndTrabalho.dbTransaction,
               "[dbo].[Proc_save_Agencia_Contato]",
                ParameterBase<Agencia_ContatoModel>.SetParameterValue(objAgencia_Contato));
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar(
                    UndTrabalho.dbTransaction,
            "[dbo].[Proc_update_Agencia_Contato]",
            ParameterBase<Agencia_ContatoModel>.SetParameterValue(objAgencia_Contato));
            }
        }

        public void Delete(int idAgenciaContato)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar("[dbo].[Proc_delete_Agencia_Contato]",
                UndTrabalho.dbTransaction,
                  UserData.idUser,
                  idAgenciaContato);
        }

        public void DeletePorAgencia(int idAgencia)
        {
            UndTrabalho.dbPrincipal.ExecuteNonQuery(
                UndTrabalho.dbTransaction,
                System.Data.CommandType.Text,
              "DELETE Agencia_Contato WHERE idAgencia = " + idAgencia);
        }

        public void Copy(Agencia_ContatoModel objAgencia_Contato)
        {
            objAgencia_Contato.idAgenciaContato = null;
            objAgencia_Contato.idAgenciaContato = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                                           UndTrabalho.dbTransaction,
                                           "[dbo].[Proc_save_Agencia_Contato]",
        ParameterBase<Agencia_ContatoModel>.SetParameterValue(objAgencia_Contato));
        }

        public Agencia_ContatoModel GetAgencia_Contato(int idAgenciaContato)
        {
            if (regAcessor == null)
            {
                regAcessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("[dbo].[Proc_sel_Agencia_Contato]",
                   new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idAgenciaContato"),
                   MapBuilder<Agencia_ContatoModel>.MapAllProperties().DoNotMap(i => i.status).Build());
            }
            return regAcessor.Execute(idAgenciaContato).FirstOrDefault();
        }

        public List<Agencia_ContatoModel> GetAllAgencia_Contato(int idAgencia)
        {
            DataAccessor<Agencia_ContatoModel> reg = UndTrabalho.dbPrincipal.CreateSqlStringAccessor
            ("SELECT * FROM Agencia_Contato WHERE idAgencia = @idAgencia", new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idAgencia"),
            MapBuilder<Agencia_ContatoModel>.MapAllProperties().DoNotMap(i => i.status).Build());

            return reg.Execute(idAgencia).ToList();
        }
    }
}
