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
    public class Cliente_fornecedor_representanteRepository : ICliente_fornecedor_representanteRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Cliente_fornecedor_representanteModel> regAcessor;

        public void Save(Cliente_fornecedor_representanteModel objCliente_fornecedor_representante)
        {
            objCliente_fornecedor_representante.idClienteFornecedorRepresentante = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
           "[dbo].[Proc_save_Cliente_fornecedor_representante]",
            ParameterBase<Cliente_fornecedor_representanteModel>.SetParameterValue(objCliente_fornecedor_representante));
        }

        public void Update(Cliente_fornecedor_representanteModel objCliente_fornecedor_representante)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar(
            "[dbo].[Proc_update_Cliente_fornecedor_representante]",
            ParameterBase<Cliente_fornecedor_representanteModel>.SetParameterValue(objCliente_fornecedor_representante));
        }

        public void Delete(int idClienteFornecedorRepresentante)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar("[dbo].[Proc_delete_Cliente_fornecedor_representante]",
                  UserData.idUser,
                  idClienteFornecedorRepresentante);
        }

        public void DeletePorClienteFornecedor(int idClienteFornecedor)
        {
            UndTrabalho.dbPrincipal.ExecuteNonQuery(System.Data.CommandType.Text,
              "DELETE Cliente_fornecedor_representante WHERE idClienteFornecedor = " + idClienteFornecedor);
        }

        public void Copy(Cliente_fornecedor_representanteModel objCliente_fornecedor_representante)
        {
            objCliente_fornecedor_representante.idClienteFornecedorRepresentante = null;
            objCliente_fornecedor_representante.idClienteFornecedorRepresentante = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                                           UndTrabalho.dbTransaction,
                                           "[dbo].[Proc_save_Cliente_fornecedor_representante]",
        ParameterBase<Cliente_fornecedor_representanteModel>.SetParameterValue(objCliente_fornecedor_representante));
        }

        public Cliente_fornecedor_representanteModel GetCliente_fornecedor_representante(int idClienteFornecedorRepresentante)
        {
            if (regAcessor == null)
            {
                regAcessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("[dbo].[Proc_sel_Cliente_fornecedor_representante]",
                   new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idClienteFornecedorRepresentante"),
                   MapBuilder<Cliente_fornecedor_representanteModel>.MapAllProperties().DoNotMap(i => i.status).Build());
            }
            return regAcessor.Execute(idClienteFornecedorRepresentante).FirstOrDefault();
        }

        public List<Cliente_fornecedor_representanteModel> GetAllCliente_fornecedor_representante(int idClienteFornecedor)
        {
            DataAccessor<Cliente_fornecedor_representanteModel> reg = UndTrabalho.dbPrincipal.CreateSqlStringAccessor
            ("SELECT * FROM Cliente_fornecedor_representante WHERE idClienteFornecedor = @idClienteFornecedor", new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idClienteFornecedor"),
            MapBuilder<Cliente_fornecedor_representanteModel>.MapAllProperties().DoNotMap(i => i.status).Build());

            return reg.Execute(idClienteFornecedor).ToList();
        }
    }
}
