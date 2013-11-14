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
        public ITipo_documentoRepository tipo_documentoRepository { get; set; }

        public serviceTipo_documento() 
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }
        public void DoWork()
        {
        }


        public Tipo_documentoModel GetDocumento(int idTipoDocumento)
        {

            try
            {
                return tipo_documentoRepository.GetDocumento(idTipoDocumento);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        
        }

        public void Save(Tipo_documentoModel documento)
        {
            try
            {
                tipo_documentoRepository.Save(documento);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public void Delete(int idTipoDocumento)
        {
            try
            {
                tipo_documentoRepository.Delete(idTipoDocumento);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public void Begin()
        {
            try
            {
                tipo_documentoRepository.Begin();
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public void Commit()
        {
            try
            {
                tipo_documentoRepository.Commit();
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public void RollBack()
        {
            try
            {
                tipo_documentoRepository.RollBack();
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public int Copy(int idTipoDocumento)
        {
            try
            {
               return tipo_documentoRepository.Copy(idTipoDocumento);
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
                return tipo_documentoRepository.GetTipo_documentoAll();
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }
}
