using HLP.Comum.Infrastructure;
using HLP.Comum.Infrastructure.Static;
using HLP.Entries.Model.Models.Transportes;
using HLP.Entries.Model.Repository.Interfaces.Transportes;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Implementation.Transportes
{
    public class Transportador_ContatoRepository : ITransportador_ContatoRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Transportador_ContatoModel> regAcessor;

        public void Save(Transportador_ContatoModel objTransportador_Contato)
        {
            objTransportador_Contato.idTransportdorContato = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
           "[dbo].[Proc_save_Transportador_Contato]",
            ParameterBase<Transportador_ContatoModel>.SetParameterValue(objTransportador_Contato));
        }

        public void Update(Transportador_ContatoModel objTransportador_Contato)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar(
            "[dbo].[Proc_update_Transportador_Contato]",
            ParameterBase<Transportador_ContatoModel>.SetParameterValue(objTransportador_Contato));
        }

        public void Delete(int idTransportadorContato)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar("[dbo].[Proc_delete_Transportador_Contato]",
                  UserData.idUser,
                  idTransportadorContato);
        }

        public void DeletePorTransportador(int idTransportador)
        {
            UndTrabalho.dbPrincipal.ExecuteNonQuery(System.Data.CommandType.Text,
              "DELETE Transportador_Contato WHERE idTransportador = " + idTransportador);
        }

        public void Copy(Transportador_ContatoModel objTransportador_Contato)
        {
            objTransportador_Contato.idTransportdorContato = null;
            objTransportador_Contato.idTransportdorContato = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                                           UndTrabalho.dbTransaction,
                                           "[dbo].[Proc_save_Transportador_Contato]",
        ParameterBase<Transportador_ContatoModel>.SetParameterValue(objTransportador_Contato));
        }

        public Transportador_ContatoModel GetTransportador_Contato(int idTransportdorContato)
        {
            if (regAcessor == null)
            {
                regAcessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("[dbo].[Proc_sel_Transportador_Contato]",
                   new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idTransportdorContato"),
                   MapBuilder<Transportador_ContatoModel>.MapAllProperties().DoNotMap(i => i.status).Build());
            }
            return regAcessor.Execute(idTransportdorContato).FirstOrDefault();
        }

        public List<Transportador_ContatoModel> GetAllTransportador_Contato(int idTransportador)
        {
            DataAccessor<Transportador_ContatoModel> reg = UndTrabalho.dbPrincipal.CreateSqlStringAccessor
            ("SELECT * FROM Transportador_Contato WHERE idTransportador = @idTransportador", new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idTransportador"),
            MapBuilder<Transportador_ContatoModel>.MapAllProperties().DoNotMap(i => i.status).Build());

            return reg.Execute(idTransportador).ToList();
        }
    }
}
