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
    public class ContatoRepository: IContatoRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<ContatoModel> regContatoAccessor;
        private DataAccessor<ContatoModel> regAllContatoAccessor;

        public void Save(ContatoModel objContato)
        {
            objContato.idContato = (int)UndTrabalho.dbPrincipal.ExecuteScalar("dbo.Proc_save_Contato",
            ParameterBase<ContatoModel>.SetParameterValue(objContato));
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
