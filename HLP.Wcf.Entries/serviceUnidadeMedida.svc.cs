using HLP.Comum.Resources.Util;
using HLP.Dependencies;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.Model.Repository.Interfaces.Gerais;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serviceUnidadeMedida" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serviceUnidadeMedida.svc or serviceUnidadeMedida.svc.cs at the Solution Explorer and start debugging.
    public class serviceUnidadeMedida : IserviceUnidadeMedida
    {
        [Inject]
        public IUnidade_medidaRepository unidade_medidaRepository { get; set; }

        public serviceUnidadeMedida()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public Unidade_medidaModel getUnidade_medida(int idUnidadeMedida)
        {
            try
            {
                return this.unidade_medidaRepository.GetUnidade(idUnidadeMedida: idUnidadeMedida);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw;
            }
        }

        public int saveUnidade_medida(Unidade_medidaModel objUnidadeMedida)
        {
            try
            {
                unidade_medidaRepository.Save(unidade: objUnidadeMedida);
                return (int)objUnidadeMedida.idUnidadeMedida;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw;
            }
        }

        public bool deleteUnidade_medida(int idUnidadeMedida)
        {
            try
            {
                unidade_medidaRepository.Delete(idUnidadeMedida: idUnidadeMedida);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                return false;
            }
        }
    }
}
