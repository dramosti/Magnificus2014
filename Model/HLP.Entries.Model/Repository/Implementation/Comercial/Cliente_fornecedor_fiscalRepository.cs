using HLP.Base.ClassesBases;
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
    public class Cliente_fornecedor_fiscalRepository : ICliente_fornecedor_fiscalRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Cliente_fornecedor_fiscalModel> regAcessor;

        public Cliente_fornecedor_fiscalModel GetCliente_fornecedor_fiscal(int idClienteFornecedor)
        {
            if (regAcessor == null)
            {
                regAcessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor
                ("SELECT * FROM Cliente_fornecedor_fiscal WHERE idClienteFornecedor = @idClienteFornecedor",
                new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idClienteFornecedor"),
                MapBuilder<Cliente_fornecedor_fiscalModel>.MapAllProperties().DoNotMap(i => i.status)                
                .Build());
            }
            return regAcessor.Execute(idClienteFornecedor).FirstOrDefault();
        }

        public void Save(Cliente_fornecedor_fiscalModel objCliente_fornecedor_fiscal)
        {
            if (objCliente_fornecedor_fiscal.idClienteFornecedorFiscal == null)
            {
                objCliente_fornecedor_fiscal.idClienteFornecedorFiscal = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                    UndTrabalho.dbTransaction,
                "[dbo].[Proc_save_Cliente_fornecedor_fiscal]",
                ParameterBase<Cliente_fornecedor_fiscalModel>.SetParameterValue(objCliente_fornecedor_fiscal));
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar(
                    UndTrabalho.dbTransaction,
                "[dbo].[Proc_update_Cliente_fornecedor_fiscal]",
                ParameterBase<Cliente_fornecedor_fiscalModel>.SetParameterValue(objCliente_fornecedor_fiscal));
            }
        }

        public void Delete(int idClienteFornecedor)
        {
            UndTrabalho.dbPrincipal.ExecuteNonQuery(UndTrabalho.dbTransaction, System.Data.CommandType.Text,
              "DELETE Cliente_fornecedor_fiscal WHERE idClienteFornecedor = " + idClienteFornecedor);
        }

        public void Copy(Cliente_fornecedor_fiscalModel objCliente_fornecedor_fiscal)
        {
            objCliente_fornecedor_fiscal.idClienteFornecedorFiscal = null;
            objCliente_fornecedor_fiscal.idClienteFornecedorFiscal = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                                           UndTrabalho.dbTransaction,
                                           "[dbo].[Proc_save_Cliente_fornecedor_fiscal]",
        ParameterBase<Cliente_fornecedor_fiscalModel>.SetParameterValue(objCliente_fornecedor_fiscal));
        }
    }
}
