using HLP.Base.ClassesBases;
using HLP.Base.Static;
using HLP.Components.Model.Models;
using HLP.Components.Model.Repository.Interfaces;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Components.Model.Repository.Implementation
{
    public class ContatoRepository : IContatoRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<ContatoModel> regContatoAccessor;
        private DataAccessor<ContatoModel> regAllContatoAccessor;

        public void Save(ContatoModel objContato)
        {
            if (objContato.idContato == null)
            {
                objContato.idContato = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                    storedProcedureName: "dbo.Proc_save_Contato",
                    transaction: UndTrabalho.dbTransaction,
                    parameterValues: ParameterBase<ContatoModel>.SetParameterValue(objContato));
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar(
                    transaction: UndTrabalho.dbTransaction, 
                    storedProcedureName: "dbo.Proc_update_Contato",
                    parameterValues: ParameterBase<ContatoModel>.SetParameterValue(classe: objContato));
            }
        }

        public void Delete(int idContato)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar("dbo.Proc_delete_Contato",
                 UserData.idUser,
                 idContato);
        }

        public int Copy(int idContato)
        {
            return (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                      "dbo.Proc_copy_Contato",
                       idContato);
        }

        public ContatoModel GetContato(int idContato)
        {
            if (regContatoAccessor == null)
            {
                regContatoAccessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("dbo.Proc_sel_Contato",
                                 new Parameters(UndTrabalho.dbPrincipal)
                                 .AddParameter<int>("idContato"),
                                 MapBuilder<ContatoModel>.MapAllProperties().Build());
            }

            return regContatoAccessor.Execute(idContato).FirstOrDefault();
        }

        public List<ContatoModel> GetAllContato()
        {
            if (regAllContatoAccessor == null)
            {
                regAllContatoAccessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor("SELECT * FROM Contato",
                                MapBuilder<ContatoModel>.MapAllProperties().Build());
            }
            return regAllContatoAccessor.Execute().ToList();
        }

        public List<ContatoModel> GetContato_ByClienteFornec(int idContato)
        {
            DataAccessor<ContatoModel> reg = UndTrabalho.dbPrincipal.CreateSqlStringAccessor
            ("select c.* from Contato c " +
             "inner join Cliente_fornecedor_contato cc " +
             "on c.idContato = cc.idContato and cc.idClienteFornecedor = @idContato",
            new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idContato"),
            MapBuilder<ContatoModel>.MapAllProperties().DoNotMap(c => c.status).Build());
            return reg.Execute(idContato).ToList();
        }

        public List<ContatoModel> GetContato_ByForeignKey(int id, string tabela)
        {
            DataAccessor<ContatoModel> reg = UndTrabalho.dbPrincipal.CreateSqlStringAccessor
                (string.Format(format: "select * from Contato where {0} = {1}",
                arg0: BuildPartialWhereContato(tabela: tabela),
                arg1: id),
            new Parameters(UndTrabalho.dbPrincipal),
            MapBuilder<ContatoModel>.MapAllProperties()
            .DoNotMap(c => c.status).Build());

            return reg.Execute().ToList();
        }

        public void DeleteContato_ByForeignKey(int id, string tabela)
        {
            UndTrabalho.dbPrincipal.ExecuteNonQuery(
                UndTrabalho.dbTransaction,
                System.Data.CommandType.Text,
              string.Format(format: "delete from Contato where {0} = {1}",
              arg0: BuildPartialWhereContato(tabela: tabela),
                arg1: id));
        }

        private string BuildPartialWhereContato(string tabela)
        {
            return tabela == "transportador" ? "idContatoTransportador" : "";
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
    }
}
