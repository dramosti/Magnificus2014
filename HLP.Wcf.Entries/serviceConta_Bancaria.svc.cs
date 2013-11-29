using HLP.Comum.Resources.Util;
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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serviceConta_Bancaria" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serviceConta_Bancaria.svc or serviceConta_Bancaria.svc.cs at the Solution Explorer and start debugging.
    public class serviceConta_Bancaria : IserviceConta_Bancaria
    {
        [Inject]
        public IConta_bancariaRepository conta_BancariaRepository { get; set; }

        public serviceConta_Bancaria()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }


        public int Save(HLP.Entries.Model.Models.Financeiro.Conta_bancariaModel Objeto)
        {

            try
            {
                this.conta_BancariaRepository.Save(conta: Objeto);
                return (int)Objeto.idContaBancaria;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public HLP.Entries.Model.Models.Financeiro.Conta_bancariaModel GetObjeto(int idObjeto)
        {

            try
            {
                return this.conta_BancariaRepository.GetConta(idContaBancaria: idObjeto);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public bool Delete(HLP.Entries.Model.Models.Financeiro.Conta_bancariaModel Objeto)
        {

            try
            {
                this.conta_BancariaRepository.Delete(idContaBancaria: (int)Objeto.idContaBancaria);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public int Copy(HLP.Entries.Model.Models.Financeiro.Conta_bancariaModel Objeto)
        {

            try
            {
                return this.conta_BancariaRepository.Copy(idContaBancaria: (int)Objeto.idContaBancaria);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }
    }
}
