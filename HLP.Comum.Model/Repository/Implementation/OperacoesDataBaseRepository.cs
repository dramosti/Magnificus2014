﻿using HLP.Base.ClassesBases;
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

        public object GetRecord(string nameView, string xCampo, string xValue, int idEmpresa = 0)
        {
            string queryGetNameTable = string.Format("select TABLE_NAME from INFORMATION_SCHEMA.VIEW_TABLE_USAGE where VIEW_NAME = '{0}'",
                arg0: nameView);

            DbCommand comm = UndTrabalho.dbPrincipal.GetSqlStringCommand
                              (
                              query: queryGetNameTable
                              );

            object nameTable = UndTrabalho.dbPrincipal.ExecuteScalar(command: comm);

            if (nameTable == null)
                return null;

            string queryGetPkField = string.Format(format: "SELECT COLUMN_NAME FROM " +
            "INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE " +
            "where TABLE_NAME = '{0}' and (CONSTRAINT_NAME like '%PK' or CONSTRAINT_NAME like 'PK%')");

            return null;
        }
    }
}