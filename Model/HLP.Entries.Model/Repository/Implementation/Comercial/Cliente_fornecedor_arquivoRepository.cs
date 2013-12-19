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
    public class Cliente_fornecedor_arquivoRepository : ICliente_fornecedor_arquivoRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Cliente_fornecedor_arquivoModel> regAcessor;

        public void Save(Cliente_fornecedor_arquivoModel objCliente_fornecedor_arquivo)
        {
            if (objCliente_fornecedor_arquivo.idClienteFornecedorArquivo == null)
            {
                objCliente_fornecedor_arquivo.idClienteFornecedorArquivo = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                    UndTrabalho.dbTransaction,
               "[dbo].[Proc_save_Cliente_fornecedor_arquivo]",
                ParameterBase<Cliente_fornecedor_arquivoModel>.SetParameterValue(objCliente_fornecedor_arquivo));
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar(UndTrabalho.dbTransaction,
                    "[dbo].[Proc_update_Cliente_fornecedor_arquivo]",
                    ParameterBase<Cliente_fornecedor_arquivoModel>.SetParameterValue(objCliente_fornecedor_arquivo));

            }
        }
        public void Delete(int idClienteFornecedorArquivo)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar(UndTrabalho.dbTransaction, "[dbo].[Proc_delete_Cliente_fornecedor_arquivo]",
                  UserData.idUser,
                  idClienteFornecedorArquivo);
        }

        public void DeletePorClienteFornecedor(int idClienteFornecedor)
        {
            UndTrabalho.dbPrincipal.ExecuteNonQuery(UndTrabalho.dbTransaction, System.Data.CommandType.Text,
              "DELETE Cliente_fornecedor_arquivo WHERE idClienteFornecedor = " + idClienteFornecedor);
        }

        public void Copy(Cliente_fornecedor_arquivoModel objCliente_fornecedor_arquivo)
        {
            objCliente_fornecedor_arquivo.idClienteFornecedorArquivo = null;
            objCliente_fornecedor_arquivo.idClienteFornecedorArquivo = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                                           UndTrabalho.dbTransaction,
                                           "[dbo].[Proc_save_Cliente_fornecedor_arquivo]",
        ParameterBase<Cliente_fornecedor_arquivoModel>.SetParameterValue(objCliente_fornecedor_arquivo));
        }

        public Cliente_fornecedor_arquivoModel GetCliente_fornecedor_arquivo(int idClienteFornecedorArquivo)
        {
            if (regAcessor == null)
            {
                regAcessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("[dbo].[Proc_sel_Cliente_fornecedor_arquivo]",
                   new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idClienteFornecedorArquivo"),
                   MapBuilder<Cliente_fornecedor_arquivoModel>.MapAllProperties().DoNotMap(i => i.status).Build());
            }
            return regAcessor.Execute(idClienteFornecedorArquivo).FirstOrDefault();
        }

        public List<Cliente_fornecedor_arquivoModel> GetAllCliente_fornecedor_arquivo(int idClienteFornecedor)
        {
            DataAccessor<Cliente_fornecedor_arquivoModel> reg = UndTrabalho.dbPrincipal.CreateSqlStringAccessor
            ("SELECT * FROM Cliente_fornecedor_arquivo WHERE idClienteFornecedor = @idClienteFornecedor", new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idClienteFornecedor"),
            MapBuilder<Cliente_fornecedor_arquivoModel>.MapAllProperties().DoNotMap(i => i.status).Build());

            return reg.Execute(idClienteFornecedor).ToList();
        }
    }
}
