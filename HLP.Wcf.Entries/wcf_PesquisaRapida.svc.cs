using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HLP.Components.Model.Repository.Interfaces;
using HLP.Dependencies;
using HLP.Base.Static;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_PesquisaRapida" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_PesquisaRapida.svc or wcf_PesquisaRapida.svc.cs at the Solution Explorer and start debugging.
    public class wcf_PesquisaRapida : Iwcf_PesquisaRapida
    {
        public wcf_PesquisaRapida()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        [Inject]
        public IHlpPesquisaRapidaRepository iHlpPesquisaRapidaRepository { get; set; }

        public string GetValorDisplay(string _TableView, string[] _Items, string _FieldPesquisa, int idEmpresa, int? _iValorPesquisa)
        {
            try
            {
                return iHlpPesquisaRapidaRepository.GetValorDisplay(_TableView, _Items, _FieldPesquisa, idEmpresa, _iValorPesquisa);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }
}
