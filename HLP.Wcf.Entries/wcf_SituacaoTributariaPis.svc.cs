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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_SituacaoTributariaPis" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_SituacaoTributariaPis.svc or wcf_SituacaoTributariaPis.svc.cs at the Solution Explorer and start debugging.

    public class wcf_SituacaoTributariaPis : Iwcf_SituacaoTributariaPis
    {
        [Inject]
        public ISituacao_tributaria_pisRepository situacao_Tributaria_PisRepository { get; set; }

        public wcf_SituacaoTributariaPis()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public Situacao_tributaria_pisModel GetObject(int id)
        {
            try
            {
                return this.situacao_Tributaria_PisRepository.GetStPis(idCSTPis: id);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public int SaveObject(Situacao_tributaria_pisModel obj)
        {
            try
            {
                situacao_Tributaria_PisRepository.Save(pis: obj);
                return obj.idCSTPis ?? 0;
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
                situacao_Tributaria_PisRepository.Delete(idCSTPis: id);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public Situacao_tributaria_pisModel CopyObject(int id)
        {
            try
            {
                return this.GetObject(id:
                    this.situacao_Tributaria_PisRepository.Copy(idCSTPis: id));
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }

}
