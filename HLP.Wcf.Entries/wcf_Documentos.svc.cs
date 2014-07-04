using HLP.Base.Static;
using HLP.Comum.Model.Models;
using HLP.Comum.Model.Repository.Interfaces;
using HLP.Dependencies;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_Documentos" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_Documentos.svc or wcf_Documentos.svc.cs at the Solution Explorer and start debugging.

    public class wcf_Documentos : Iwcf_Documentos
    {
        [Inject]
        public IDocumentosRepository documentosRepository { get; set; }

        public wcf_Documentos()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public List<DocumentosModel> GetListObject(string xTabela, int idPk)
        {
            try
            {
                //IMPLEMENTAR GET
                return this.documentosRepository.GetAllDocumentosByPk(xTabela: xTabela,
                    idPk: idPk);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public List<DocumentosModel> SaveObject(List<DocumentosModel> lDocumentos, string xNameTabela, int idPk)
        {
            try
            {
                //IMPLEMENTAR SAVE
                foreach (DocumentosModel doc in lDocumentos)
                {
                    switch (doc.status)
                    {
                        case HLP.Base.EnumsBases.statusModel.criado:
                        case HLP.Base.EnumsBases.statusModel.alterado:
                            {
                                doc.xNameTable = xNameTabela;
                                doc.idPk = idPk;
                                documentosRepository.Save(objDocumentos: doc);
                            }
                            break;
                        case HLP.Base.EnumsBases.statusModel.excluido:
                            {
                                documentosRepository.Delete(idDocumento: doc.idDocumento);
                            }
                            break;
                        default:
                            break;
                    }
                }

                return lDocumentos;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public bool DeleteObject(string xNameTabela, int idPk)
        {
            try
            {
                documentosRepository.DeleteByPk(xNameTabela: xNameTabela, idPk: idPk);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public List<DocumentosModel> CopyObject(List<DocumentosModel> lDocumentos)
        {
            try
            {
                foreach (DocumentosModel doc in lDocumentos)
                {
                    doc.idDocumento = this.documentosRepository.Copy(
                        idDocumento: doc.idDocumento);
                }

                return lDocumentos;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }

}
