using HLP.Comum.Resources.Util;
using HLP.Dependencies;
using HLP.Entries.Model.Repository.Interfaces.Fiscal;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serviceStCofins" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serviceStCofins.svc or serviceStCofins.svc.cs at the Solution Explorer and start debugging.
    public class serviceStCofins : IserviceStCofins
    {
        [Inject]
        public ISituacao_tributaria_cofinsRepository situacao_TributariaRepository { get; set; }

        public serviceStCofins()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }


        public int Save(HLP.Entries.Model.Models.Fiscal.Situacao_tributaria_cofinsModel Objeto)
        {

            try
            {
                situacao_TributariaRepository.Save(cofins: Objeto);
                return (int)Objeto.idCSTCofins;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public HLP.Entries.Model.Models.Fiscal.Situacao_tributaria_cofinsModel GetObjeto(int idObjeto)
        {

            try
            {
                return this.situacao_TributariaRepository.GetStCofins(idCSTCofins: idObjeto);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public bool Delete(HLP.Entries.Model.Models.Fiscal.Situacao_tributaria_cofinsModel Objeto)
        {

            try
            {
                this.situacao_TributariaRepository.Delete(idCSTCofins: (int)Objeto.idCSTCofins);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public int Copy(HLP.Entries.Model.Models.Fiscal.Situacao_tributaria_cofinsModel Objeto)
        {

            try
            {
                return this.situacao_TributariaRepository.Copy(idCSTCofins: (int)Objeto.idCSTCofins);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }
    }
}
