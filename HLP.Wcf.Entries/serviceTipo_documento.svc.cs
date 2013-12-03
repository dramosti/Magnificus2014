using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HLP.Comum.Resources.Util;
using HLP.Dependencies;
using HLP.Entries.Model.Fiscal;
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

        public serviceTipo_documento() 
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public int Save(Tipo_documentoModel objModel)
        {
            try
            {
                itipo_documentoRepository.Save(objModel);
                return (int)objModel.idTipoDocumento;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }        
        }

        public Tipo_documentoModel GetObjeto(int idObjeto)
        {
            try
            {
                return itipo_documentoRepository.GetDocumento(idObjeto);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }        
        }

        public bool Delete(Tipo_documentoModel objModel)
        {
            try
            {
                itipo_documentoRepository.Delete((int)objModel.idTipoDocumento);
                return true;

            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }        
        }

        public int Copy(Tipo_documentoModel objModel)
        {
            try
            {
                return itipo_documentoRepository.Copy((int)objModel.idTipoDocumento);

            }
            catch (Exception ex)
            {
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
