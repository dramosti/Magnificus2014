using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HLP.Comum.Resources.Util;
using HLP.Dependencies;
using HLP.Entries.Model.Repository.Interfaces.Crm;
using Ninject;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "servicePersonalidade" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select servicePersonalidade.svc or servicePersonalidade.svc.cs at the Solution Explorer and start debugging.
    public class servicePersonalidade : IservicePersonalidade
    {
        [Inject]
        public IPersonalidadeRepository iPersonalidadeRepository { get; set; }
        public servicePersonalidade()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }



        public int Save(HLP.Entries.Model.Models.Crm.PersonalidadeModel Objeto)
        {

            try
            {
                iPersonalidadeRepository.Save(Objeto);
                return (int)Objeto.idPersonalidade;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public HLP.Entries.Model.Models.Crm.PersonalidadeModel GetObjeto(int idObjeto)
        {

            try
            {
                return iPersonalidadeRepository.GetPersonalidade(idObjeto);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public bool Delete(HLP.Entries.Model.Models.Crm.PersonalidadeModel Objeto)
        {

            try
            {
                iPersonalidadeRepository.Delete((int)Objeto.idPersonalidade);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }

        public int Copy(HLP.Entries.Model.Models.Crm.PersonalidadeModel Objeto)
        {
            try
            {
                return iPersonalidadeRepository.Copy((int)Objeto.idPersonalidade);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }
    }
}
