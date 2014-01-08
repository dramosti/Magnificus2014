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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serviceTipo_documento_Operacao_Valida" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serviceTipo_documento_Operacao_Valida.svc or serviceTipo_documento_Operacao_Valida.svc.cs at the Solution Explorer and start debugging.
    public class serviceTipo_documento_Operacao_Valida : IserviceTipo_documento_Operacao_Valida
    {
        [Inject]
        public ITipo_documento_oper_validaRepository tipo_Documento_Oper_validaRepository { get; set; }

        public serviceTipo_documento_Operacao_Valida()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public IEnumerable<HLP.Entries.Model.Fiscal.Tipo_documento_oper_validaModel> GetOperacoesValidas(int idTipoDocumento)
        {

            try
            {
                return this.tipo_Documento_Oper_validaRepository.GetAll(idTipoDocumento: idTipoDocumento);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public int Save(HLP.Entries.Model.Fiscal.Tipo_documento_oper_validaModel objModel)
        {
            throw new NotImplementedException();
        }

        public HLP.Entries.Model.Fiscal.Tipo_documento_oper_validaModel GetObjeto(int idObjeto)
        {
            throw new NotImplementedException();
        }

        public bool Delete(HLP.Entries.Model.Fiscal.Tipo_documento_oper_validaModel objModel)
        {
            throw new NotImplementedException();
        }

        public int Copy(HLP.Entries.Model.Fiscal.Tipo_documento_oper_validaModel objModel)
        {
            throw new NotImplementedException();
        }
    }
}
