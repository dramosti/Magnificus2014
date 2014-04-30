using HLP.Base.Static;
using HLP.Dependencies;
using HLP.Entries.Model.Models.Fiscal;
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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_StCofins" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_StCofins.svc or wcf_StCofins.svc.cs at the Solution Explorer and start debugging.

    public class wcf_StCofins : Iwcf_StCofins
    {
        [Inject]
        public ISituacao_tributaria_cofinsRepository situacao_Tributaria_CofinsRepository { get; set; }

        public wcf_StCofins()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public Situacao_tributaria_cofinsModel GetObject(int id)
        {
            try
            {
                return this.situacao_Tributaria_CofinsRepository.GetStCofins(
                    idCSTCofins: id);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public int SaveObject(Situacao_tributaria_cofinsModel obj)
        {
            try
            {
                situacao_Tributaria_CofinsRepository.Save(cofins: obj);
                return obj.idCSTCofins ?? 0;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public bool DeleteObject(int id)
        {
            try
            {
                situacao_Tributaria_CofinsRepository.Delete(idCSTCofins: id);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public Situacao_tributaria_cofinsModel CopyObject(int id)
        {
            try
            {
                //IMPLEMENTAR COPY
                return this.GetObject(id:
                    this.situacao_Tributaria_CofinsRepository.Copy(idCSTCofins: id));
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }

}
