using HLP.Comum.Resources.Util;
using HLP.Dependencies;
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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serviceCidade" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serviceCidade.svc or serviceCidade.svc.cs at the Solution Explorer and start debugging.
    public class serviceCidade : IserviceCidade
    {
        [Inject]
        public ICidadeRepository cidadeRepository { get; set; }

        public serviceCidade()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public HLP.Entries.Model.Models.Gerais.CidadeModel getCidade(int idCidade)
        {
            try
            {
                return cidadeRepository.GetCidade(idCidade: idCidade);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public int saveCidade(HLP.Entries.Model.Models.Gerais.CidadeModel objCidade)
        {
            try
            {
                cidadeRepository.Save(cidade: objCidade);
                return (int)objCidade.idCidade;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public bool delCidade(int idCidade)
        {
            try
            {
                cidadeRepository.Delete(idCidade: idCidade);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public int copyCidade(int idCidade)
        {
            try
            {
                return cidadeRepository.Copy(idCidade: idCidade);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }
}
