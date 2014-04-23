using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.Model.Repository.Interfaces.Gerais;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;
using HLP.Base.ClassesBases;
using HLP.Base.Static;

namespace HLP.Entries.Model.Repository.Implementation.Gerais
{
    public class ContatoRepository : IContatoRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<ContatoModel> regContatoAccessor;
        private DataAccessor<ContatoModel> regContatoAcessorFk;

        public void Save(ContatoModel objContato)
        {
            if (objContato.idContato == null)
            {
                objContato.idContato = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                    UndTrabalho.dbTransaction,
                "[dbo].[Proc_save_Contato]",
                ParameterBase<ContatoModel>.SetParameterValue(objContato));
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar(
                    UndTrabalho.dbTransaction,
                "[dbo].[Proc_update_Contato]",
                ParameterBase<ContatoModel>.SetParameterValue(objContato));
            }
        }

        public void Delete(int idContato)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar(
            UndTrabalho.dbTransaction,
           "[dbo].[Proc_delete_Contato]",
            UserData.idUser,
            idContato);
        }

        public void Copy(ContatoModel objContato)
        {
            objContato.idContato = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
            UndTrabalho.dbTransaction,
           "dbo.Proc_copy_Contato",
            objContato.idContato);
        }

        public ContatoModel GetContato(int idContato)
        {

            if (regContatoAccessor == null)
            {
                regContatoAccessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("dbo.Proc_sel_Contato",
                                         new Parameters(UndTrabalho.dbPrincipal)
                                         .AddParameter<int>("idContato"),
                                         MapBuilder<ContatoModel>.MapAllProperties()
                                         .DoNotMap(c => c.status)
                                         .Build());
            }

            return regContatoAccessor.Execute(idContato).FirstOrDefault();
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
                arg0: tabela == "transportador" ? "idContatoTransportador" : "",
                arg1: id),
            new Parameters(UndTrabalho.dbPrincipal),
            MapBuilder<ContatoModel>.MapAllProperties()
            .DoNotMap(c => c.status).Build());

            return reg.Execute().ToList();
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
