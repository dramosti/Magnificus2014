using HLP.Base.ClassesBases;
using HLP.Base.EnumsBases;
using HLP.Base.Static;
using HLP.Dependencies;
using HLP.Entries.Model.Fiscal;
using HLP.Entries.Model.Repository.Interfaces.Fiscal;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_TipoDocumento" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_TipoDocumento.svc or wcf_TipoDocumento.svc.cs at the Solution Explorer and start debugging.

    public class wcf_TipoDocumento : Iwcf_TipoDocumento
    {
        [Inject]
        public ITipo_documentoRepository itipo_documentoRepository { get; set; }
        [Inject]
        public ITipo_documento_oper_validaRepository iTipo_documento_oper_validaRepository { get; set; }

        public wcf_TipoDocumento()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public Tipo_documentoModel GetObject(int id)
        {
            try
            {
                HLP.Entries.Model.Fiscal.Tipo_documentoModel objret = itipo_documentoRepository.GetDocumento(id);
                if (objret != null)
                {
                    objret.lTipo_documento_oper_validaModel = new ObservableCollectionBaseCadastros<HLP.Entries.Model.Fiscal.Tipo_documento_oper_validaModel>(iTipo_documento_oper_validaRepository.GetAll((int)objret.idTipoDocumento));
                }
                return objret;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public Tipo_documentoModel SaveObject(Tipo_documentoModel obj)
        {
            try
            {
                itipo_documentoRepository.Begin();
                itipo_documentoRepository.Save(obj);
                foreach (var item in obj.lTipo_documento_oper_validaModel)
                {
                    switch (item.status)
                    {
                        case statusModel.criado:
                        case statusModel.alterado:
                            item.idTipoDocumento = (int)obj.idTipoDocumento;
                            iTipo_documento_oper_validaRepository.Save(item);
                            break;
                        case statusModel.excluido:
                            iTipo_documento_oper_validaRepository.Delete((int)item.idTipoDocumento);
                            break;
                    }
                }
                itipo_documentoRepository.Commit();
                return obj;
            }
            catch (Exception ex)
            {
                itipo_documentoRepository.RollBack();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public bool DeleteObject(int id)
        {
            try
            {
                itipo_documentoRepository.Begin();
                iTipo_documento_oper_validaRepository.DeleteOperValidaByTipoDocumento(id);
                itipo_documentoRepository.Delete(id);
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

        public Tipo_documentoModel CopyObject(Tipo_documentoModel obj)
        {
            try
            {
                itipo_documentoRepository.Begin();
                obj.idTipoDocumento = itipo_documentoRepository.Copy((int)obj.idTipoDocumento);
                foreach (var item in obj.lTipo_documento_oper_validaModel)
                {
                    item.idTipoDocumento = (int)obj.idTipoDocumento;
                    item.idTipoDocumentoOperValida = null;
                    iTipo_documento_oper_validaRepository.Copy((int)item.idTipoDocumentoOperValida);
                }
                itipo_documentoRepository.Commit();
                return obj;
            }
            catch (Exception ex)
            {
                itipo_documentoRepository.RollBack();
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public List<Tipo_documentoModel> GetTipo_documentoAll()
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
