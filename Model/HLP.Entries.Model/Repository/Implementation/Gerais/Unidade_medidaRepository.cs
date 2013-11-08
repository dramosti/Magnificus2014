using HLP.Comum.Infrastructure;
using HLP.Comum.Infrastructure.Static;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.Model.Repository.Interfaces.Gerais;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Implementation.Gerais
{
    public class Unidade_medidaRepository : IUnidade_medidaRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Unidade_medidaModel> regUnidadeAccessor;

        public Unidade_medidaModel GetUnidade(int idUnidadeMedida)
        {
            if (regUnidadeAccessor == null)
            {
                regUnidadeAccessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("dbo.Proc_sel_unidade_medida",
                                    new Parameters(UndTrabalho.dbPrincipal)
                                    .AddParameter<int>("idUnidadeMedida"),
                                    MapBuilder<Unidade_medidaModel>.MapAllProperties().Build());
            }
            return regUnidadeAccessor.Execute(idUnidadeMedida).FirstOrDefault();
        }

        public void Save(Unidade_medidaModel unidade)
        {
            if (unidade.idUnidadeMedida == null)
            {
                int idUnidadeMedida = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                  "dbo.Proc_save_unidade_medida",
                 ParameterBase<Unidade_medidaModel>.SetParameterValue(unidade));

                unidade.idUnidadeMedida = idUnidadeMedida;
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar(
                  "dbo.Proc_save_unidade_medida",
                 ParameterBase<Unidade_medidaModel>.SetParameterValue(unidade));
            }
        }

        public void Delete(int idUnidadeMedida)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar(
                       "dbo.Proc_delete_unidade_medida",
                        UserData.idUser,
                        idUnidadeMedida);
        }

        public int Copy(int idUnidadeMedida)
        {
            return (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                       "dbo.Proc_copy_unidade_medida",
                        idUnidadeMedida);
        }


        public bool IsNew(string xSiglaPadrao)
        {
            DbCommand comand = UndTrabalho.dbPrincipal.GetSqlStringCommand
                             (
                             string.Format("SELECT COUNT(*) FROM Unidade_medida WHERE xSiglaPadrao = '{0}'", xSiglaPadrao)
                             );

            int i = (int)UndTrabalho.dbPrincipal.ExecuteScalar(comand);
            if (i == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public List<Unidade_medidaModel> GetUnidadeByConversaoProduto(int idParaUnidadeMedida, int idProduto)
        {
            DataAccessor<Unidade_medidaModel> reg = UndTrabalho.dbPrincipal.CreateSqlStringAccessor
            ("select u.* from Unidade_medida u " +
             "inner join Conversao c on c.idDeUnidadeMedida = u.idUnidadeMedida " +
             "where c.idParaUnidadeMedida = @idParaUnidadeMedida and c.idProduto = @idProduto",
            new Parameters(UndTrabalho.dbPrincipal).AddParameter<int>("idParaUnidadeMedida").AddParameter<int>("idProduto"),
            MapBuilder<Unidade_medidaModel>.MapAllProperties().Build());
            return reg.Execute(idParaUnidadeMedida, idProduto).ToList();
        }
    }
}
