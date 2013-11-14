using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HLP.Comum.Model.Repository.Interfaces.Components;
using HLP.Comum.Resources.Util;
using HLP.Dependencies;
using Ninject;
using HLP.Comum.Model.Components;
using System.Collections;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "servicePesquisaRapida" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select servicePesquisaRapida.svc or servicePesquisaRapida.svc.cs at the Solution Explorer and start debugging.
    public class servicePesquisaRapida : IservicePesquisaRapida
    {

        public servicePesquisaRapida()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        [Inject]
        public IHlpPesquisaRapidaRepository iHlpPesquisaRapidaRepository { get; set; }

        public string GetValorDisplay(string _TableView, string[] _Items, string _FieldPesquisa, int? _iValorPesquisa)
        {
            try
            {
                Log.AddLog(_TableView);
                Log.AddLog(_Items.First());
                Log.AddLog(_FieldPesquisa);
                Log.AddLog(_iValorPesquisa.ToString());

               return iHlpPesquisaRapidaRepository.GetValorDisplay(_TableView, _Items, _FieldPesquisa, _iValorPesquisa);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }
}
