using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HLP.Base.Static;
using HLP.Dependencies;
using HLP.Entries.Model.Models.Gerais;
using HLP.Entries.Model.Repository.Interfaces.Gerais;
using Ninject;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serviceRegiao" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serviceRegiao.svc or serviceRegiao.svc.cs at the Solution Explorer and start debugging.
    public class serviceRegiao : IserviceRegiao
    {

        [Inject]
        public IRegiaoRepository iRegiaoRepository { get; set; }

        public serviceRegiao()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }
        public void DoWork()
        {
        }


        public ObservableCollection<RegiaoModel> GetAll()
        {

            try
            {
                return iRegiaoRepository.GetAll();
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }
        
        }
    }
}
