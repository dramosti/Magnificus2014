using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Infrastructure;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.Model.Repository.Interfaces.Gerais;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;
using HLP.Comum.Infrastructure.Static;

namespace HLP.Entries.Model.Repository.Implementation.Gerais
{
    public class CidadeRepository : ICidadeRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }
        private DataAccessor<CidadeModel> regCidadeByUfAccessor;
        private DataAccessor<CidadeModel> regCidadeAccessor;
        private DataAccessor<HLP.Entries.Model.Models.modelToComboBox> regCidadeToComboboxAccessor;


        public ObservableCollection<CidadeModel> GetCidadeByUf(int idUf)
        {
            if (regCidadeByUfAccessor == null)
            {
                regCidadeByUfAccessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor("SELECT * FROM Cidade WHERE idUf = @idUf",
                                  new Parameters(UndTrabalho.dbPrincipal)
                                    .AddParameter<int>("idUf"),
                                  MapBuilder<CidadeModel>.MapAllProperties().Build());
            }

            return new ObservableCollection<CidadeModel>(regCidadeByUfAccessor.Execute(idUf).ToList());
        }

        public int Copy(int idCidade)
        {
            return (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                          "dbo.Proc_copy_cidade",
                           idCidade);
        }

        public void Save(CidadeModel cidade)
        {
            if (cidade.idCidade == null)
            {
                int idCidade = (int)UndTrabalho.dbPrincipal.ExecuteScalar(
               "[dbo].[Proc_save_cidade]",
              ParameterBase<CidadeModel>.SetParameterValue(cidade));

                cidade.idCidade = idCidade;
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar(
               "[dbo].[Proc_update_Cidade]",
              ParameterBase<CidadeModel>.SetParameterValue(cidade));
            }

        }

        public void Delete(int idCidade)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar(
                    "dbo.Proc_delete_cidade",
                     UserData.idUser,
                     idCidade);
        }

        public CidadeModel GetCidade(int idCidade)
        {
            if (regCidadeAccessor == null)
            {
                regCidadeAccessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("dbo.Proc_sel_cidade",
                                  new Parameters(UndTrabalho.dbPrincipal)
                                    .AddParameter<int>("idCidade"),
                                  MapBuilder<CidadeModel>.MapAllProperties().DoNotMap(i => i.status).Build());
            }


            return regCidadeAccessor.Execute(idCidade).FirstOrDefault();
        }


        public IEnumerable<HLP.Entries.Model.Models.modelToComboBox> GetAllCidadeToComboBox()
        {
            List<HLP.Entries.Model.Models.modelToComboBox> lReturn;
            if (regCidadeToComboboxAccessor == null)
            {
                regCidadeToComboboxAccessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor("SELECT * FROM vwCidadeToComboBox",
                                 MapBuilder<HLP.Entries.Model.Models.modelToComboBox>.MapAllProperties().Build());
            }

            lReturn = regCidadeToComboboxAccessor.Execute().ToList();

            return lReturn;
        }
    }
}
