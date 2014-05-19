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
    public class HlpEnderecoRepository : IHlpEnderecoRepository
    {

        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<EnderecoModel> regAcessor;

        public void Save(EnderecoModel objEnderecoModel)
        {
            if (objEnderecoModel.idEndereco == null)
            {
                objEnderecoModel.idEndereco = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                    UndTrabalho.dbTransaction,
               "[dbo].[Proc_save_Enderecos]",
                ParameterBase<EnderecoModel>.SetParameterValue(objEnderecoModel));
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar(
                UndTrabalho.dbTransaction,
            "[dbo].[Proc_update_Enderecos]",
            ParameterBase<EnderecoModel>.SetParameterValue(objEnderecoModel));
            }
        }

        public void Delete(EnderecoModel objEnderecoModel)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar(
                UndTrabalho.dbTransaction,
                "[dbo].[Proc_delete_Enderecos]",
                  UserData.idUser,
                  objEnderecoModel.idEndereco);
        }

        public void Delete(int idFK, string sNameFK)
        {
            UndTrabalho.dbPrincipal.ExecuteNonQuery(
                UndTrabalho.dbTransaction,
                System.Data.CommandType.Text,
              string.Format("Delete Enderecos Where {0} = {1} ", sNameFK, idFK));
        }

        public void Copy(EnderecoModel objEnderecoModel)
        {
            objEnderecoModel.idEndereco = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                transaction: UndTrabalho.dbTransaction, storedProcedureName: "[dbo].[Proc_copy_Enderecos]",
                parameterValues: new object[] { objEnderecoModel.idEndereco, objEnderecoModel.idClienteFornecedor, objEnderecoModel.idContato,
                objEnderecoModel.idEmpresa, objEnderecoModel.idFuncionario, objEnderecoModel.idSite, objEnderecoModel.idTransportador, objEnderecoModel.idAgencia});
        }

        //     @idEndereco int, @idClienteFornecedo int = null, @idContato int = null,
        //@idEmpresa int = null, @idFuncionario int = null, @idSite int = null,
        //@idTransportador int = null, @idAgencia int = null

        public EnderecoModel GetObjeto(int idEndereco)
        {
            if (regAcessor == null)
            {
                regAcessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("[dbo].[Proc_sel_Funcionario_Endereco]",
                   new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idEndereco"),
                   MapBuilder<EnderecoModel>.MapAllProperties()
                   .DoNotMap(i => i.status)
                   .DoNotMap(i => i.bCanFindCep)
                   .Build());
            }
            return regAcessor.Execute(idEndereco).FirstOrDefault();
        }

        public List<EnderecoModel> GetAllObjetos(int idPK, string sPK)
        {
            DataAccessor<EnderecoModel> reg = UndTrabalho.dbPrincipal.CreateSqlStringAccessor
            ("SELECT * FROM ENDERECOS WHERE " + sPK + " = @" + sPK, new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>(sPK),
            MapBuilder<EnderecoModel>.MapAllProperties()
            .DoNotMap(i => i.status)
            .DoNotMap(i => i.bCanFindCep)
            .Build());

            return reg.Execute(idPK).ToList();
        }

    }

}
