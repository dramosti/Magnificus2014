﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Infrastructure;
using HLP.Comum.Infrastructure.Static;
using HLP.Entries.Model.Fiscal;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Ninject;

namespace HLP.Entries.Model.Repository.Implementation.Fiscal
{
    public class Tipo_documento_oper_validaRepository 
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<Tipo_documento_oper_validaModel> regdocumentoOperAccessor;



        public void Save(Tipo_documento_oper_validaModel documentoOper)
        {
            int idTipoDocumentoOperValida = Convert.ToInt32((UndTrabalho.dbPrincipal.ExecuteScalar(UndTrabalho.dbTransaction,
                 "dbo.Proc_save_tipo_documento_oper_valida",
                ParameterBase<Tipo_documento_oper_validaModel>.SetParameterValue(documentoOper))));

            documentoOper.idTipoDocumentoOperValida = idTipoDocumentoOperValida;
        }

        public void Delete(int idTipoDocumentoOperValida)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar(UndTrabalho.dbTransaction,
              "dbo.Proc_delete_tipo_documento_oper_valida",
               UserData.idUser,
               idTipoDocumentoOperValida);
        }

        public void Delete(int idTipoDocumento, List<int?> lidTipoDocumentoOperValida)
        {
            DbCommand cmd;
            string sql = "";
            if (lidTipoDocumentoOperValida.Count() > 0)
            {
                string notIn = String.Join(",", lidTipoDocumentoOperValida);
                sql = "DELETE FROM Tipo_documento_oper_valida WHERE  idTipoDocumento =" + idTipoDocumento + " AND idTipoDocumentoOperValida NOT IN (" + notIn + ")";
            }
            else
            {
                sql = "DELETE FROM Tipo_documento_oper_valida WHERE  idTipoDocumento =" + idTipoDocumento;
            }
            cmd = UndTrabalho.dbPrincipal.GetSqlStringCommand(sql);

            UndTrabalho.dbPrincipal.ExecuteScalar(UndTrabalho.dbTransaction, CommandType.Text, sql);
        }

        public List<Tipo_documento_oper_validaModel> GetAll(int idTipoDocumento)
        {
            if (regdocumentoOperAccessor == null)
            {
                regdocumentoOperAccessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor("SELECT * FROM Tipo_documento_oper_valida WHERE idTipoDocumento = @idTipoDocumento",
                                  new Parameters(UndTrabalho.dbPrincipal)
                                    .AddParameter<int>("idTipoDocumento"),
                                  MapBuilder<Tipo_documento_oper_validaModel>.MapAllProperties().Build());
            }


            return regdocumentoOperAccessor.Execute(idTipoDocumento).ToList();
        }
    }
}
