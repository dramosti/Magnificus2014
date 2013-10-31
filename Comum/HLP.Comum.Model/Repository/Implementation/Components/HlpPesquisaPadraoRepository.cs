using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Infrastructure;
using HLP.Comum.Model.Components;
using HLP.Comum.Model.Repository.Interfaces.Components;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;

namespace HLP.Comum.Model.Repository.Implementation.Components
{
    public class HlpPesquisaPadraoRepository : IHlpPesquisaPadraoRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<PesquisaPadraoModel> regPesquisaPadraoAccessor;

        public ObservableCollection<PesquisaPadraoModel> GetTableInformation(string sViewName)
        {
            if (regPesquisaPadraoAccessor == null)
            {
                regPesquisaPadraoAccessor = UndTrabalho.dbPrincipal
                  .CreateSqlStringAccessor(@"select COLUMN_NAME, DATA_TYPE from INFORMATION_SCHEMA.COLUMNS
                                           where TABLE_NAME = @sViewName",
                                 new Parameters(UndTrabalho.dbPrincipal)
                                 .AddParameter<string>("sViewName"),
                  MapBuilder<PesquisaPadraoModel>.MapAllProperties().DoNotMap(C => C.Operador)
                                                                    .DoNotMap(C => C.Valor)
                                                                    .DoNotMap(C => C.EOU)
                                                                    .DoNotMap(C => C.HeaderText)
                                                                    .Build());
            }
            return new ObservableCollection<PesquisaPadraoModel>(regPesquisaPadraoAccessor.Execute(sViewName).ToList());
        }
    }
}
