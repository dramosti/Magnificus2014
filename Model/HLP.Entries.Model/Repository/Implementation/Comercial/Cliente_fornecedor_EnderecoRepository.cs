using HLP.Comum.Infrastructure;
using HLP.Comum.Infrastructure.Static;
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
    public class Cliente_fornecedor_EnderecoRepository : ICliente_fornecedor_EnderecoRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Cliente_fornecedor_EnderecoModel> regAcessor;

        public void Save(Cliente_fornecedor_EnderecoModel objCliente_Fornecedor_Endereco)
        {
            objCliente_Fornecedor_Endereco.idEndereco = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
           "[dbo].[Proc_save_Cliente_Fornecedor_Endereco]",
            ParameterBase<Cliente_fornecedor_EnderecoModel>.SetParameterValue(objCliente_Fornecedor_Endereco));
        }

        public void Update(Cliente_fornecedor_EnderecoModel objCliente_Fornecedor_Endereco)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar(
            "[dbo].[Proc_update_Cliente_Fornecedor_Endereco]",
            ParameterBase<Cliente_fornecedor_EnderecoModel>.SetParameterValue(objCliente_Fornecedor_Endereco));
        }

        public void Delete(int idEndereco_Cliente_Fornecedor)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar("[dbo].[Proc_delete_Cliente_Fornecedor_Endereco]",
                  UserData.idUser,
                  idEndereco_Cliente_Fornecedor);
        }

        public void DeletePorClienteFornecedor(int idClienteFornecedor)
        {
            UndTrabalho.dbPrincipal.ExecuteNonQuery(System.Data.CommandType.Text,
              "DELETE Cliente_Fornecedor_Endereco WHERE idClienteFornecedor = " + idClienteFornecedor);
        }

        public void Copy(Cliente_fornecedor_EnderecoModel objCliente_Fornecedor_Endereco)
        {
            objCliente_Fornecedor_Endereco.idEndereco = null;
            objCliente_Fornecedor_Endereco.idEndereco = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                                           UndTrabalho.dbTransaction,
                                           "[dbo].[Proc_save_Cliente_Fornecedor_Endereco]",
        ParameterBase<Cliente_fornecedor_EnderecoModel>.SetParameterValue(objCliente_Fornecedor_Endereco));
        }

        public Cliente_fornecedor_EnderecoModel GetCliente_Fornecedor_Endereco(int idEndereco)
        {
            if (regAcessor == null)
            {
                regAcessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("[dbo].[Proc_sel_Cliente_Fornecedor_Endereco]",
                   new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idEndereco"),
                   MapBuilder<Cliente_fornecedor_EnderecoModel>.MapAllProperties().DoNotMap(i => i.status).Build());
            }
            return regAcessor.Execute(idEndereco).FirstOrDefault();
        }

        public List<Cliente_fornecedor_EnderecoModel> GetAllCliente_Fornecedor_Endereco(int idClienteFornecedor)
        {
            DataAccessor<Cliente_fornecedor_EnderecoModel> reg = UndTrabalho.dbPrincipal.CreateSqlStringAccessor
            ("SELECT * FROM Cliente_Fornecedor_Endereco WHERE idClienteFornecedor = @idClienteFornecedor", new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idClienteFornecedor"),
            MapBuilder<Cliente_fornecedor_EnderecoModel>.MapAllProperties().DoNotMap(i => i.status).Build());

            return reg.Execute(idClienteFornecedor).ToList();
        }
    }
}
