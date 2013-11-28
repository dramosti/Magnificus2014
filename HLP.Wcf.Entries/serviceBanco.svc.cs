﻿using HLP.Comum.Resources.Util;
using HLP.Dependencies;
using HLP.Entries.Model.Repository.Interfaces.Financeiro;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serviceBanco" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serviceBanco.svc or serviceBanco.svc.cs at the Solution Explorer and start debugging.
    public class serviceBanco : IserviceBanco
    {
        [Inject]
        public IBancoRepository bancoRepository { get; set; }

        public serviceBanco()
        {

            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";

        }

        public int Save(HLP.Entries.Model.Models.Financeiro.BancoModel Objeto)
        {

            try
            {
                bancoRepository.Save(banco: Objeto);
                return (int)Objeto.idBanco;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public HLP.Entries.Model.Models.Financeiro.BancoModel GetObjeto(int idObjeto)
        {

            try
            {
                return this.bancoRepository.GetBanco(idBanco: idObjeto);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public bool Delete(HLP.Entries.Model.Models.Financeiro.BancoModel Objeto)
        {

            try
            {
                this.bancoRepository.Delete(idBanco: (int)(Objeto.idBanco));
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public int Copy(HLP.Entries.Model.Models.Financeiro.BancoModel Objeto)
        {

            try
            {
                return this.bancoRepository.Copy(idBanco: (int)Objeto.idBanco);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }
    }
}
