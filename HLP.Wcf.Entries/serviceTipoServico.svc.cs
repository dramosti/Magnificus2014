using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HLP.Comum.Resources.Util;
using HLP.Dependencies;
using HLP.Entries.Model.Repository.Interfaces.Gerais;
using Ninject;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serviceTipoServico" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serviceTipoServico.svc or serviceTipoServico.svc.cs at the Solution Explorer and start debugging.
    public class serviceTipoServico : IserviceTipoServico
    {
        [Inject]
        public ITipo_servicoRepository iTipo_servicoRepository { get; set; }

        public serviceTipoServico() 
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }


        public HLP.Entries.Model.Models.Gerais.Tipo_servicoModel GetTipo(int idTipoServico)
        {
            try
            {
                return iTipo_servicoRepository.GetTipo(idTipoServico);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public HLP.Entries.Model.Models.Gerais.Tipo_servicoModel Save(HLP.Entries.Model.Models.Gerais.Tipo_servicoModel tipo)
        {
            try
            {
                iTipo_servicoRepository.Save(tipo);
                return tipo;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public bool Delete(int idTipoServico)
        {
            try
            {
                iTipo_servicoRepository.Delete(idTipoServico);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public int Copy(int idTipoServico)
        {
            try
            {
                return iTipo_servicoRepository.Copy(idTipoServico);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }
    }
}
