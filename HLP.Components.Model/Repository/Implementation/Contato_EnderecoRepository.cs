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
    public class Contato_EnderecoRepository : IContato_EnderecoRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Contato_EnderecoModel> regAcessor;

        public void Save(Contato_EnderecoModel objContato_Endereco)
        {
            if (objContato_Endereco.idEndereco == null)
            {
                objContato_Endereco.idEndereco = (int)UndTrabalho.dbPrincipal.ExecuteScalar(UndTrabalho.dbTransaction,
               "[dbo].[Proc_save_Contato_Endereco]",
                ParameterBase<Contato_EnderecoModel>.SetParameterValue(objContato_Endereco));
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar(UndTrabalho.dbTransaction,
                  "[dbo].[Proc_update_Contato_Endereco]",
                  ParameterBase<Contato_EnderecoModel>.SetParameterValue(objContato_Endereco));
            }
        }


        public void Delete(int idContato)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar(UndTrabalho.dbTransaction, "[dbo].[Proc_delete_Contato_Endereco]",
                  UserData.idUser,
                  idContato);
        }

        public void DeleteEnderecosByContato(int idContato)
        {
            UndTrabalho.dbPrincipal.ExecuteNonQuery(UndTrabalho.dbTransaction, System.Data.CommandType.Text,
              "DELETE Contato_Endereco WHERE idContato = " + idContato);
        }

        public void Copy(Contato_EnderecoModel objContato_Endereco)
        {
            objContato_Endereco.idEndereco = null;
            objContato_Endereco.idEndereco = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                                           UndTrabalho.dbTransaction,
                                           "[dbo].[Proc_save_Contato_Endereco]",
        ParameterBase<Contato_EnderecoModel>.SetParameterValue(objContato_Endereco));
        }

        public Contato_EnderecoModel GetContato_Endereco(int idEndereco)
        {
            if (regAcessor == null)
            {
                regAcessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("[dbo].[Proc_sel_Contato_Endereco]",
                   new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idEndereco"),
                   MapBuilder<Contato_EnderecoModel>.MapAllProperties()
                   .DoNotMap(c => c.status)
                   .Build());
            }
            return regAcessor.Execute(idEndereco).FirstOrDefault();
        }

        public List<Contato_EnderecoModel> GetAllContato_Endereco(int idContato)
        {
            DataAccessor<Contato_EnderecoModel> reg = UndTrabalho.dbPrincipal.CreateSqlStringAccessor
            ("SELECT * FROM Contato_Endereco WHERE idContato = @idContato", new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idContato"),
            MapBuilder<Contato_EnderecoModel>.MapAllProperties()
            .DoNotMap(c => c.status)
            .Build());

            return reg.Execute(idContato).ToList();
        }

    }

}
