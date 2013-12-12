using HLP.Comum.Infrastructure;
using HLP.Comum.Infrastructure.Static;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.Model.Repository.Interfaces.Gerais;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Implementation.Gerais
{
    public class Site_enderecoRepository : ISite_enderecoRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Site_enderecoModel> regAcessor;

        public void Save(Site_enderecoModel objSite_Endereco)
        {
            if (objSite_Endereco.idEndereco == null)
            {
                objSite_Endereco.idEndereco = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                    UndTrabalho.dbTransaction,
               "[dbo].[Proc_save_Site_Endereco]",
                ParameterBase<Site_enderecoModel>.SetParameterValue(objSite_Endereco));
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar(
                    UndTrabalho.dbTransaction,
                    "[dbo].[Proc_update_Site_Endereco]",
                    ParameterBase<Site_enderecoModel>.SetParameterValue(objSite_Endereco));
            }
        }

        public void Delete(int site_idEndereco)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar(
                UndTrabalho.dbTransaction,
                "[dbo].[Proc_delete_Site_Endereco]",
                  UserData.idUser,
                  site_idEndereco);
        }

        public void DeletePorSite(int idSite)
        {
            UndTrabalho.dbPrincipal.ExecuteNonQuery(
                UndTrabalho.dbTransaction,
                System.Data.CommandType.Text,
              "DELETE Site_Endereco WHERE idSite = " + idSite);
        }

        public void Copy(Site_enderecoModel objSite_Endereco)
        {
            objSite_Endereco.idEndereco = null;
            objSite_Endereco.idEndereco = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                                           UndTrabalho.dbTransaction,
                                           "[dbo].[Proc_save_Site_Endereco]",
        ParameterBase<Site_enderecoModel>.SetParameterValue(objSite_Endereco));
        }

        public Site_enderecoModel GetSite_Endereco(int idEndereco)
        {
            if (regAcessor == null)
            {
                regAcessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("[dbo].[Proc_sel_Site_Endereco]",
                   new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idEndereco"),
                   MapBuilder<Site_enderecoModel>.MapAllProperties()
                   .DoNotMap(i => i.enumTipoEndereco)
                   .DoNotMap(i => i.enumTipoLogradouro)
                   .DoNotMap(i => i.status).Build());
            }
            return regAcessor.Execute(idEndereco).FirstOrDefault();
        }

        public List<Site_enderecoModel> GetAllSite_Endereco(int idSite)
        {
            DataAccessor<Site_enderecoModel> reg = UndTrabalho.dbPrincipal.CreateSqlStringAccessor
            ("SELECT * FROM Site_Endereco WHERE idSite = @idSite", new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idSite"),
            MapBuilder<Site_enderecoModel>.MapAllProperties()
            .DoNotMap(i => i.enumTipoEndereco)
            .DoNotMap(i => i.enumTipoLogradouro)
            .DoNotMap(i => i.status).Build());

            return reg.Execute(idSite).ToList();
        }
    }
}
