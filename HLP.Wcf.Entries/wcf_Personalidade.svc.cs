using HLP.Base.Static;
using HLP.Dependencies;
using HLP.Entries.Model.Models.Crm;
using HLP.Entries.Model.Repository.Interfaces.Crm;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_Personalidade" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_Personalidade.svc or wcf_Personalidade.svc.cs at the Solution Explorer and start debugging.

    public class wcf_Personalidade : Iwcf_Personalidade
    {
        [Inject]
        public IPersonalidadeRepository personalidadeRepository { get; set; }

        public wcf_Personalidade()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public PersonalidadeModel GetObject(int id)
        {
            try
            {
                //IMPLEMENTAR GET
                return this.personalidadeRepository.GetPersonalidade(idPersonalidade: id);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public int SaveObject(PersonalidadeModel obj)
        {
            try
            {
                //IMPLEMENTAR SAVE
                personalidadeRepository.Save(personalidade: obj);
                return obj.idPersonalidade ?? 0;
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
                //IMPLEMENTAR DELETE
                personalidadeRepository.Delete(idPersonalidade: id);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public PersonalidadeModel CopyObject(int id)
        {
            try
            {
                //IMPLEMENTAR COPY
                return this.GetObject(id:
                    this.personalidadeRepository.Copy(idPersonalidade: id));
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }

}
