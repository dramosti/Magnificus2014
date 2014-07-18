using HLP.Base.Static;
using HLP.Dependencies;
using HLP.Entries.Model.Models.GestaoDeMateriais;
using HLP.Entries.Model.Repository.Interfaces.GestaoDeMateriais;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_Localizacao" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_Localizacao.svc or wcf_Localizacao.svc.cs at the Solution Explorer and start debugging.

    public class wcf_Localizacao : Iwcf_Localizacao
    {
        [Inject]
        public ILocalizacaoRepository localizacaoRepository { get; set; }

        public wcf_Localizacao()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public LocalizacaoModel GetObject(int id)
        {
            try
            {
                return this.localizacaoRepository.GetLocalizacao(idLocalizacao: id);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public int SaveObject(LocalizacaoModel obj)
        {
            try
            {
                localizacaoRepository.Save(objLocalizacao: obj);
                return obj.idLocalizacao ?? 0;
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
                localizacaoRepository.Delete(idLocalizacao: id);
                return true;
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }

        public LocalizacaoModel CopyObject(int id)
        {
            try
            {
                return this.GetObject(id:
                    this.localizacaoRepository.Copy(idLocalizacao: id));
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        }
    }

}
