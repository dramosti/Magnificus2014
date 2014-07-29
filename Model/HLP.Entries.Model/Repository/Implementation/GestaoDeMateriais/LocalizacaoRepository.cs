using HLP.Base.ClassesBases;
using HLP.Base.Static;
using HLP.Entries.Model.Models.GestaoDeMateriais;
using HLP.Entries.Model.Repository.Interfaces.GestaoDeMateriais;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Implementation.GestaoDeMateriais
{
    public class LocalizacaoRepository : ILocalizacaoRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<LocalizacaoModel> regLocalizacaoAccessor;
        private DataAccessor<LocalizacaoModel> regAllLocalizacaoAccessor;

        public void Save(LocalizacaoModel objLocalizacao)
        {
            objLocalizacao.idLocalizacao = (int)UndTrabalho.dbPrincipal.ExecuteScalar("dbo.Proc_save_Localizacao",
            ParameterBase<LocalizacaoModel>.SetParameterValue(objLocalizacao));
        }

        public void Delete(int idLocalizacao)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar("dbo.Proc_delete_Localizacao",
                 UserData.idUser,
                 idLocalizacao);
        }

        public int Copy(int idLocalizacao)
        {
            return (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                      "dbo.Proc_copy_Localizacao",
                       idLocalizacao);
        }

        public LocalizacaoModel GetLocalizacao(int idLocalizacao)
        {
            if (regLocalizacaoAccessor == null)
            {
                regLocalizacaoAccessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("dbo.Proc_sel_Localizacao",
                                 new Parameters(UndTrabalho.dbPrincipal)
                                 .AddParameter<int>("idLocalizacao"),
                                 MapBuilder<LocalizacaoModel>.MapAllProperties().Build());
            }

            return regLocalizacaoAccessor.Execute(idLocalizacao).FirstOrDefault();
        }

        public List<LocalizacaoModel> GetAllLocalizacao()
        {
            if (regAllLocalizacaoAccessor == null)
            {
                regAllLocalizacaoAccessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor("SELECT * FROM Localizacao",
                                MapBuilder<LocalizacaoModel>.MapAllProperties().Build());
            }
            return regAllLocalizacaoAccessor.Execute().ToList();
        }
    }
}
