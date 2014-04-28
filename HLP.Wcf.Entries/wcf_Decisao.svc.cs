using HLP.Base.Static;
using HLP.Dependencies;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.Model.Repository.Interfaces.Gerais;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_Decisao" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_Decisao.svc or wcf_Decisao.svc.cs at the Solution Explorer and start debugging.

    public class wcf_Decisao : Iwcf_Decisao
    {
        [Inject]
        public IDecisaoRepository decisaoRepository { get; set; }

        public wcf_Decisao()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public DecisaoModel GetObject(int id)
        {
            try
            {
                //IMPLEMENTAR GET
                return this.decisaoRepository.GetDecisao(idDecisao: id);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public int SaveObject(DecisaoModel obj)
        {
            try
            {
                //IMPLEMENTAR SAVE
                decisaoRepository.Save(decisao: obj);
                return obj.idDecisao ?? 0;
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
                decisaoRepository.Delete(idDecisao: id);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public DecisaoModel CopyObject(int id)
        {
            try
            {
                //IMPLEMENTAR COPY
                return this.GetObject(id:
                    this.decisaoRepository.Copy(idDecisao: id));
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }

}
