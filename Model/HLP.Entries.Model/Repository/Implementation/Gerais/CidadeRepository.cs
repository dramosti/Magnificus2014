using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Infrastructure;
using HLP.Entries.Model.Models.Crm;
using HLP.Entries.Model.Repository.Interfaces.Crm;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;

namespace HLP.Entries.Model.Repository.Implementation.Crm
{
    public class CidadeRepository : ICidadeRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }
        private DataAccessor<CidadeModel> regCidadeByUfAccessor;


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
    }
}
