using HLP.Base.ClassesBases;
using HLP.Base.Static;
using HLP.Entries.Model.Models.Comercial;
using HLP.Entries.Model.Repository.Interfaces.Comercial;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Implementation.Comercial
{
    public class Cliente_fornecedor_contatoRepository : ICliente_fornecedor_contatoRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Cliente_fornecedor_contatoModel> regAcessor;

        public void Save(Cliente_fornecedor_contatoModel objCliente_fornecedor_contato)
        {
            if (objCliente_fornecedor_contato.idClienteFornecedorContato == null)
            {
                objCliente_fornecedor_contato.idClienteFornecedorContato = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                    UndTrabalho.dbTransaction,
               "[dbo].[Proc_save_Cliente_fornecedor_contato]",
                ParameterBase<Cliente_fornecedor_contatoModel>.SetParameterValue(objCliente_fornecedor_contato));
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar(
                    UndTrabalho.dbTransaction,
                    "[dbo].[Proc_update_Cliente_fornecedor_contato]",
                    ParameterBase<Cliente_fornecedor_contatoModel>.SetParameterValue(objCliente_fornecedor_contato));
            }
        }


        public void Delete(int idClienteFornecedorContato)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar(UndTrabalho.dbTransaction, "[dbo].[Proc_delete_Cliente_fornecedor_contato]",
                  UserData.idUser,
                  idClienteFornecedorContato);
        }

        public void DeletePorClienteFornecedor(int idClienteFornecedor)
        {
            UndTrabalho.dbPrincipal.ExecuteNonQuery(UndTrabalho.dbTransaction, System.Data.CommandType.Text,
              "DELETE Cliente_fornecedor_contato WHERE idClienteFornecedor = " + idClienteFornecedor);
        }

        public void Copy(Cliente_fornecedor_contatoModel objCliente_fornecedor_contato)
        {
            objCliente_fornecedor_contato.idClienteFornecedorContato = null;
            objCliente_fornecedor_contato.idClienteFornecedorContato = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                                           UndTrabalho.dbTransaction,
                                           "[dbo].[Proc_save_Cliente_fornecedor_contato]",
        ParameterBase<Cliente_fornecedor_contatoModel>.SetParameterValue(objCliente_fornecedor_contato));
        }

        public Cliente_fornecedor_contatoModel GetCliente_fornecedor_contato(int idClienteFornecedorContato)
        {
            if (regAcessor == null)
            {
                regAcessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("[dbo].[Proc_sel_Cliente_fornecedor_contato]",
                   new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idClienteFornecedorContato"),
                   MapBuilder<Cliente_fornecedor_contatoModel>.MapAllProperties().DoNotMap(i => i.status).Build());
            }
            return regAcessor.Execute(idClienteFornecedorContato).FirstOrDefault();
        }

        public List<Cliente_fornecedor_contatoModel> GetAllCliente_fornecedor_contato(int idClienteFornecedor)
        {
            DataAccessor<Cliente_fornecedor_contatoModel> reg = UndTrabalho.dbPrincipal.CreateSqlStringAccessor
            ("SELECT * FROM Cliente_fornecedor_contato WHERE idClienteFornecedor = @idClienteFornecedor", new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idClienteFornecedor"),
            MapBuilder<Cliente_fornecedor_contatoModel>.MapAllProperties().DoNotMap(i => i.status).Build());

            return reg.Execute(idClienteFornecedor).ToList();
        }
    }
}
