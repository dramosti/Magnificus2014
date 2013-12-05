using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Infrastructure;
using HLP.Comum.Model.Repository.Interfaces.Components;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;

namespace HLP.Comum.Model.Repository.Implementation.Components
{
    public class FillComboBoxRepository : IFillComboBoxRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<HLP.Comum.Model.Models.modelToComboBox> regComboboxAccessor;

        public IEnumerable<HLP.Comum.Model.Models.modelToComboBox> GetAllCidadeToComboBox(string sNameView)
        {
            List<HLP.Comum.Model.Models.modelToComboBox> lReturn = new List<Models.modelToComboBox>();
            if (UndTrabalho.ViewExistis(sNameView))
            {
                if (regComboboxAccessor == null)
                {
                    regComboboxAccessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor(string.Format("SELECT * FROM {0}", sNameView),
                                     MapBuilder<HLP.Comum.Model.Models.modelToComboBox>.MapAllProperties().Build());

                }
                lReturn = regComboboxAccessor.Execute().ToList();
            }
            else
            {
                throw new Exception(string.Format("View {0} não existe no banco de Dados", sNameView));
            }
            return lReturn;
        }

    }
}
