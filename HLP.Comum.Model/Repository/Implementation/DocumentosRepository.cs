using HLP.Base.ClassesBases;
using HLP.Base.Static;
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
    public class DocumentosRepository : IDocumentosRepository
    {
        [Inject]
        public UnitOfWorkBase UndTrabalho { get; set; }

        private DataAccessor<DocumentosModel> regDocumentosAccessor;
        private DataAccessor<DocumentosModel> regAllDocumentosAccessor;

        public void Save(DocumentosModel objDocumentos)
        {
            if (objDocumentos.idDocumento == 0)
            {
                objDocumentos.idDocumento = (int)UndTrabalho.dbPrincipal.ExecuteScalar("dbo.Proc_save_Documentos",
                ParameterBase<DocumentosModel>.SetParameterValue(objDocumentos));
            }
            else
            {
                UndTrabalho.dbPrincipal.ExecuteScalar("dbo.Proc_update_Documentos",
                ParameterBase<DocumentosModel>.SetParameterValue(objDocumentos));
            }
        }

        public void Delete(int idDocumento)
        {
            UndTrabalho.dbPrincipal.ExecuteScalar("dbo.Proc_delete_Documentos",
                 UserData.idUser,
                 idDocumento);
        }

        public void DeleteByPk(string xNameTabela, int idPk)
        {
            DbCommand comm = UndTrabalho.dbPrincipal.GetSqlStringCommand(
                query: "delete from Documentos where xNameTable = '{0}' and idPk = {1}");

            try
            {
                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Copy(int idDocumento)
        {
            return (int)UndTrabalho.dbPrincipal.ExecuteScalar(
                      "dbo.Proc_copy_Documentos",
                       idDocumento);
        }

        public DocumentosModel GetDocumentos(int idDocumento)
        {
            if (regDocumentosAccessor == null)
            {
                regDocumentosAccessor = UndTrabalho.dbPrincipal.CreateSprocAccessor("dbo.Proc_sel_Documentos",
                                 new Parameters(UndTrabalho.dbPrincipal)
                                 .AddParameter<int>("idDocumento"),
                                 MapBuilder<DocumentosModel>.MapAllProperties()
                                 .DoNotMap(i => i.status)
                                 .Build());
            }

            return regDocumentosAccessor.Execute(idDocumento).FirstOrDefault();
        }

        public List<DocumentosModel> GetAllDocumentosByPk(string xTabela, int idPk)
        {
            regAllDocumentosAccessor = UndTrabalho.dbPrincipal.CreateSqlStringAccessor
                    (string.Format(format: "SELECT * FROM Documentos where xNameTable = '{0}' and idPk = {1}",
                    arg0: xTabela, arg1: idPk),
                                MapBuilder<DocumentosModel>.MapAllProperties()
                                .DoNotMap(i => i.status)
                                .Build());

            return regAllDocumentosAccessor.Execute().ToList();
        }
    }
}
