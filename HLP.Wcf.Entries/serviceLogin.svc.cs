using HLP.Comum.Model.Repository.Interfaces;
using HLP.Comum.Resources.Util;
using HLP.Dependencies;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serviceLogin" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serviceLogin.svc or serviceLogin.svc.cs at the Solution Explorer and start debugging.
    public class serviceLogin : IserviceLogin
    {
        [Inject]
        public ILoginRepository loginRepository { get; set; }

        public serviceLogin()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";

        }

        public int ValidaUsuario(string xId)
        {
            try
            {
                return loginRepository.ValidaUsuario(xId: xId);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public int ValidaAcesso(int idEmpresa, string xId)
        {
            try
            {
                return loginRepository.ValidaAcesso(idEmpresa: idEmpresa, xId: xId);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public int ValidaLogin(string xId, string xSenha)
        {
            try
            {
                return loginRepository.ValidaLogin(xID: xId, xSenha: 
                    HLP.Comum.Infrastructure.Static.Criptografia.Encripta(xSenha));
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }
}
