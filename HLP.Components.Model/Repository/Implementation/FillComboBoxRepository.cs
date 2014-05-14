using HLP.Base.ClassesBases;
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
    public class FillComboBoxRepository : IFillComboBoxRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<modelToComboBox> regComboboxAccessor;

        public List<modelToComboBox> GetAllCidadeToComboBox(string sNameView, string parameter)
        {
            List<modelToComboBox> lReturn = new List<Models.modelToComboBox>();
            if (UndTrabalho.ViewExistis(sNameView))
            {
                regComboboxAccessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor(string.Format("SELECT * FROM {0}", sNameView),
                                         MapBuilder<modelToComboBox>.MapAllProperties().Build());
                lReturn = regComboboxAccessor.Execute().ToList();
            }
            else
                if (UndTrabalho.FunctionExistis(nm_Function: sNameView))
                {
                    if (parameter != "" && parameter != null)
                    {
                        regComboboxAccessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor(string.Format("SELECT * FROM {0}({1})", sNameView, parameter),
                                         MapBuilder<modelToComboBox>.MapAllProperties().Build());
                        lReturn = regComboboxAccessor.Execute().ToList();
                    }
                }
                else
                {
                    throw new Exception(string.Format("View {0} não existe no banco de Dados", sNameView));
                }
            return lReturn;
        }

    }
}
