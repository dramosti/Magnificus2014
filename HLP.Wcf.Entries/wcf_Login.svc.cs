﻿using HLP.Base.Static;
using HLP.ComumView.Model.Repository.Interface;
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
    public class wcf_Login : Iwcf_Login
    {
        [Inject]
        public ILoginRepository loginRepository { get; set; }

        public wcf_Login()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";

        }

        public int GetIdFuncionarioByXid(string xId)
        {
            try
            {
                return loginRepository.GetIdFuncionarioByXid(xId: xId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
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

        public int ValidaAdministrador(string xID, string xSenha, int idEmpresa)
        {
            try
            {
                return loginRepository.ValidaAdministrador(xID: xID, xSenha:
                    Criptografia.Encripta(xSenha), idEmpresa: idEmpresa);
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
                    Criptografia.Encripta(xSenha));
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }
}
