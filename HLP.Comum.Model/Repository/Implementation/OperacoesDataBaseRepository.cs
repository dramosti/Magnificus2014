﻿using HLP.Base.ClassesBases;
using HLP.Base.EnumsBases;
using HLP.Comum.Model.Models;
using HLP.Comum.Model.Repository.Interfaces;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Comum.Model.Repository.Implementation
{
    public class OperacoesDataBaseRepository : IOperacoesDataBaseRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<RecordsSqlModel> regFieldsSql;

        public bool FieldExist(string xTable, string xCampo = "")
        {
            string s = null;

            s += string.Format(format: "select count(COLUMN_NAME) from INFORMATION_SCHEMA.COLUMNS " +
                "where TABLE_NAME = '{0}'", arg0: xTable);

            if (!string.IsNullOrEmpty(value: xCampo))
            {
                s += string.Format(format: "and COLUMN_NAME = '{0}'", arg0: xCampo);
            }
            try
            {
                DbCommand comand = UndTrabalho.dbPrincipal.GetSqlStringCommand
                              (
                              query: s
                              );

                return (int)UndTrabalho.dbPrincipal.ExecuteScalar(comand) > 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<RecordsSqlModel> GetRegistros(string xQuery)
        {
            regFieldsSql = UndTrabalho.dbPrincipal.CreateSqlStringAccessor(sqlString: xQuery, rowMapper:
                MapBuilder<RecordsSqlModel>.MapAllProperties()
                .DoNotMap(i => i.status).DoNotMap(i => i.Error)
                .Build());

            try
            {
                return regFieldsSql.Execute().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetRecord(string xNameTable, string xCampo, string xValue, stFilterQuickSearch stFilterQS, int idEmpresa = 0)
        {

            string queryGetPkField = string.Format(format: "SELECT COLUMN_NAME FROM " +
            "INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE " +
            "where TABLE_NAME = '{0}' and (CONSTRAINT_NAME like '%PK' or CONSTRAINT_NAME like 'PK%')", arg0: xNameTable);

            DbCommand commGetPkField = UndTrabalho.dbPrincipal.GetSqlStringCommand
                              (
                              query: queryGetPkField
                              );

            object nameFieldPk = UndTrabalho.dbPrincipal.ExecuteScalar(command: commGetPkField);

            string sWhere = string.Empty;

            switch (stFilterQS)
            {
                case stFilterQuickSearch.equal:
                    {
                        sWhere = string.Format(format: "WHERE {0} = '{1}'", arg0: xCampo, arg1: xValue);
                    }
                    break;
                case stFilterQuickSearch.startWith:
                    {
                        sWhere = string.Format(format: "WHERE {0} LIKE'{1}%'", arg0: xCampo, arg1: xValue);
                    }
                    break;
                case stFilterQuickSearch.contains:
                    {
                        sWhere = string.Format(format: "WHERE {0} LIKE'%{1}%'", arg0: xCampo, arg1: xValue);
                    }
                    break;
                default:
                    break;
            }

            string query = string.Format(format: "SELECT {0} FROM {1} {2}",
                arg0: nameFieldPk, arg1: xNameTable, arg2: sWhere);

            if (idEmpresa > 0)
            {
                query = string.Format(format: "{0} and idEmpresa = {1}", arg0: query, arg1: idEmpresa);
            }

            DbCommand commGetValue = UndTrabalho.dbPrincipal.GetSqlStringCommand
                              (
                              query: query
                              );

            object record = UndTrabalho.dbPrincipal.ExecuteScalar(command: commGetValue);

            if (record != null)
                return (int)record;

            return 0;
        }
    }
}