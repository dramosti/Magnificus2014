using HLP.Comum.Resources.Util;
using HLP.Dependencies;
using HLP.Entries.Model.Repository.Interfaces.Comercial;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serviceCanal_Venda" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serviceCanal_Venda.svc or serviceCanal_Venda.svc.cs at the Solution Explorer and start debugging.
    public class serviceCanal_Venda : IserviceCanal_Venda
    {
        [Inject]
        public ICanal_vendaRepository canal_VendaRepository { get; set; }

        public serviceCanal_Venda()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public HLP.Entries.Model.Models.Comercial.Canal_vendaModel getCanal_venda(int idCanal_venda)
        {

            try
            {
                return this.canal_VendaRepository.GetCanal(idCanalVenda: idCanal_venda);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public int saveCanal_venda(HLP.Entries.Model.Models.Comercial.Canal_vendaModel objCanal_venda)
        {

            try
            {
                this.canal_VendaRepository.Save(canal: objCanal_venda);
                return (int)objCanal_venda.idCanalVenda;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public bool deleteCanal_venda(int idCanal_venda)
        {

            try
            {
                this.canal_VendaRepository.Delete(idCanalVenda: idCanal_venda);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public int copyCanal_venda(int idCanal_venda)
        {

            try
            {
                return this.canal_VendaRepository.Copy(idCanalVenda: idCanal_venda);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }
    }
}
