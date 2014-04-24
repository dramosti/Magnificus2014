using HLP.Base.ClassesBases;
using HLP.Entries.Model.Models.Components;
using HLP.Entries.Model.Repository.Interfaces.Components;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Repository.Implementation.Components
{
    public class HlpPesquisaPadraoRepository : IHlpPesquisaPadraoRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<PesquisaPadraoModel> regPesquisaPadraoAccessor;

        private DataAccessor<PesquisaPadraoModelContract> regPesquisaPadraoContractAccessor;

        public PesquisaPadraoModel[] GetTableInformation(string sViewName)
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
                                                                    .DoNotMap(C => C.bEnablePesquisa)
                                                                    .DoNotMap(C => C.status)
                                                                    .Build());
            }
            return regPesquisaPadraoAccessor.Execute(sViewName).ToArray();
        }

        public PesquisaPadraoModelContract[] GetTableInformationContract(string sViewName)
        {
            if (regPesquisaPadraoAccessor == null)
            {
                regPesquisaPadraoContractAccessor = UndTrabalho.dbPrincipal
                  .CreateSqlStringAccessor(@"select COLUMN_NAME, DATA_TYPE from INFORMATION_SCHEMA.COLUMNS
                                           where TABLE_NAME = @sViewName",
                                 new Parameters(UndTrabalho.dbPrincipal)
                                 .AddParameter<string>("sViewName"),
                  MapBuilder<PesquisaPadraoModelContract>.MapAllProperties().DoNotMap(i => i.IS_NULLABLE).DoNotMap(i => i.CHARACTER_MAXIMUM_LENGTH)
                                                                    .Build());
            }
            return regPesquisaPadraoContractAccessor.Execute(sViewName).ToArray();
        }

        public List<PesquisaPadraoModelContract> getCamposSqlNotNull(string xTabela)
        {
            //regPesquisaPadraoContractAccessor = this.UndTrabalho.dbPrincipal.CreateSqlStringAccessor(
            //       sqlString: ("select c.COLUMN_NAME, c.IS_NULLABLE, c.CHARACTER_MAXIMUM_LENGTH,(select keyC.type from sys.all_objects keyC " +
            //                   "where keyC.name = (select const.CONSTRAINT_NAME from INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE const " +
            //                   "where const.TABLE_NAME = c.TABLE_NAME and const.COLUMN_NAME = c.COLUMN_NAME and const.CONSTRAINT_NAME not like 'PK_%')) as DATA_TYPE " +
            //                   "from INFORMATION_SCHEMA.COLUMNS c " +
            //                   "where c.TABLE_NAME = '" + xTabela + "'"),
            //                   rowMapper: MapBuilder<PesquisaPadraoModelContract>.MapAllProperties().Build());
            regPesquisaPadraoContractAccessor = this.UndTrabalho.dbPrincipal.CreateSqlStringAccessor(
                   sqlString: ("select c.COLUMN_NAME, c.IS_NULLABLE, c.CHARACTER_MAXIMUM_LENGTH,(select keyC.type from sys.all_objects keyC " +
                               "where keyC.name = (select const.CONSTRAINT_NAME from INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE const " +
                               "where const.TABLE_NAME = c.TABLE_NAME and const.COLUMN_NAME = c.COLUMN_NAME)) as DATA_TYPE " +
                               "from INFORMATION_SCHEMA.COLUMNS c " +
                               "where c.TABLE_NAME = '" + xTabela + "'"),
                               rowMapper: MapBuilder<PesquisaPadraoModelContract>.MapAllProperties().Build());
            return regPesquisaPadraoContractAccessor.Execute().ToList();
        }
        
        public object GetData(string sSelect, bool addDefault = false, string sWhere = "", bool bOrdena = true)
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
