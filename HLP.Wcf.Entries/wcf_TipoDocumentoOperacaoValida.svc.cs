using HLP.Base.Static;
using HLP.Dependencies;
using HLP.Entries.Model.Fiscal;
using HLP.Entries.Model.Models.Fiscal;
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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_TipoDocumentoOperacaoValida" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_TipoDocumentoOperacaoValida.svc or wcf_TipoDocumentoOperacaoValida.svc.cs at the Solution Explorer and start debugging.
    public class wcf_TipoDocumentoOperacaoValida : Iwcf_TipoDocumentoOperacaoValida
    {
        [Inject]
        public ITipo_documento_oper_validaRepository tipo_Documento_Oper_validaRepository { get; set; }

        public wcf_TipoDocumentoOperacaoValida()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public List<Tipo_documento_oper_validaModel> GetOperacoesValidas(int idTipoDocumento)
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
    }
}
