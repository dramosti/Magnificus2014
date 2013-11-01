using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using HLP.Comum.Infrastructure;
using HLP.Entries.Model.Models.Crm;
using HLP.Entries.Model.Repository.Interfaces.Crm;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;

namespace HLP.Entries.Model.Repository.Implementation.Crm
{
    public class RegiaoRepository : IRegiaoRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<RegiaoModel> regRegiaoGetAllAccessor;

        public ObservableCollection<RegiaoModel> GetAll()
        {
            if (regRegiaoGetAllAccessor == null)
            {
                regRegiaoGetAllAccessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor("SELECT * FROM REGIAO",
                                  MapBuilder<RegiaoModel>.MapAllProperties().Build());
            }
            IEnumerable<RegiaoModel> lret = regRegiaoGetAllAccessor.Execute().AsEnumerable();

            if (lret != null)
            {
                return new ObservableCollection<RegiaoModel>(lret);
            }
            else
            {
                return new ObservableCollection<RegiaoModel>();
            }
        }
    }
}
