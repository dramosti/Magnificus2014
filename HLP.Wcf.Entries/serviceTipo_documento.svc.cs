using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HLP.Comum.Resources.Util;
using HLP.Dependencies;
using HLP.Entries.Model.Repository.Interfaces.Fiscal;
using Ninject;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serviceTipo_documento" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serviceTipo_documento.svc or serviceTipo_documento.svc.cs at the Solution Explorer and start debugging.
    public class serviceTipo_documento : IserviceTipo_documento
    {

        [Inject]
        public ITipo_documentoRepository itipo_documentoRepository { get; set; }
        [Inject]
        public ITipo_documento_oper_validaRepository iTipo_documento_oper_validaRepository { get; set; }

        public serviceTipo_documento()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public HLP.Entries.Model.Fiscal.Tipo_documentoModel Save(HLP.Entries.Model.Fiscal.Tipo_documentoModel objModel)
        {
            try
            {               
                itipo_documentoRepository.Begin();
                itipo_documentoRepository.Save(objModel);
                foreach (var item in objModel.lTipo_documento_oper_validaModel)
                {
                    switch (item.status)
                    {
                        case HLP.Comum.Resources.RecursosBases.statusModel.criado:
                        case HLP.Comum.Resources.RecursosBases.statusModel.alterado:
                            item.idTipoDocumento = (int)objModel.idTipoDocumento;
                            iTipo_documento_oper_validaRepository.Save(item);
                            break;
                        case HLP.Comum.Resources.RecursosBases.statusModel.excluido:
                            iTipo_documento_oper_validaRepository.Delete((int)item.idTipoDocumento);
                            break;
                    }
                }
                itipo_documentoRepository.Commit();
                return objModel;
            }
            catch (Exception ex)
            {
                itipo_documentoRepository.RollBack();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public HLP.Entries.Model.Fiscal.Tipo_documentoModel GetObjeto(int idObjeto)
        {
            try
            {
                HLP.Entries.Model.Fiscal.Tipo_documentoModel objret = itipo_documentoRepository.GetDocumento(idObjeto);
                if (objret != null)
                {
                    objret.lTipo_documento_oper_validaModel = new Comum.Model.Models.ObservableCollectionBaseCadastros<HLP.Entries.Model.Fiscal.Tipo_documento_oper_validaModel>(iTipo_documento_oper_validaRepository.GetAll((int)objret.idTipoDocumento));
                }
                return objret;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public bool Delete(HLP.Entries.Model.Fiscal.Tipo_documentoModel objModel)
        {
            try
            {
                itipo_documentoRepository.Begin();
                iTipo_documento_oper_validaRepository.DeleteOperValidaByTipoDocumento((int)objModel.idTipoDocumento);
                itipo_documentoRepository.Delete((int)objModel.idTipoDocumento);
                itipo_documentoRepository.Commit();
                return true;

            }
            catch (Exception ex)
            {
                itipo_documentoRepository.RollBack();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public int Copy(HLP.Entries.Model.Fiscal.Tipo_documentoModel objModel)
        {
            try
            {
                itipo_documentoRepository.Begin();
                objModel.idTipoDocumento = itipo_documentoRepository.Copy((int)objModel.idTipoDocumento);
                foreach (var item in objModel.lTipo_documento_oper_validaModel)
                {
                    item.idTipoDocumento = (int)objModel.idTipoDocumento;
                    item.idTipoDocumentoOperValida = null;
                    iTipo_documento_oper_validaRepository.Copy((int)item.idTipoDocumentoOperValida);
                }
                itipo_documentoRepository.Commit();
                return (int)objModel.idTipoDocumento;

            }
            catch (Exception ex)
            {
                itipo_documentoRepository.RollBack();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public List<HLP.Entries.Model.Fiscal.Tipo_documentoModel> GetTipo_documentoAll()
        {
            try
            {
                return itipo_documentoRepository.GetTipo_documentoAll();
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }
}
