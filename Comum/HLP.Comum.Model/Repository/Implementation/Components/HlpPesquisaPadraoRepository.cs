using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
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
                                                                    .DoNotMap(C => C.OwnerType)
                                                                    .DoNotMap(C=> C.bEnablePesquisa)
                                                                    .Build());
            }
            return new ObservableCollection<PesquisaPadraoModel>(regPesquisaPadraoAccessor.Execute(sViewName).ToList());
        }

        public DataTable GetData(string sSelect, bool addDefault = false, string sWhere = "", bool bOrdena = true)
        {
            try
            {
                if (sWhere != "")
                {
                    if (sSelect.ToUpper().Contains("WHERE"))
                    {
                        sSelect += " and " + sWhere;
                    }
                    else
                    {
                        sSelect += " where " + sWhere;
                    }
                }
                if (sSelect.Contains("DISPLAY") && bOrdena)
                {
                    sSelect += " ORDER BY DISPLAY";
                }
                DbCommand cmd = UndTrabalho.dbPrincipal.GetSqlStringCommand(sSelect);
              
                
                IDataReader reader = UndTrabalho.dbPrincipal.ExecuteReader(cmd);
              
                DataTable dt = new DataTable();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    dt.Columns.Add(reader.GetName(i), reader.GetFieldType(i));
                }
                if (addDefault)
                {
                    dt.Rows.Add(0, "...");
                }
                while (reader.Read())
                {
                    object[] array = new object[reader.FieldCount];

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        if (reader[i].ToString() != "")
                        {
                            array[i] = reader[i].ToString().ToUpper();
                        }
                        else
                        {
                            if (reader[i].GetType() == typeof(string) || reader[i].GetType() == typeof(char))
                            {
                                array[i] = reader[i].ToString().ToUpper();
                            }
                        }
                    }
                    dt.Rows.Add(array);
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
