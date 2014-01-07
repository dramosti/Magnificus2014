using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HLP.Comum.Model.Repository.Interfaces.Components;
using HLP.Comum.Resources.Util;
using HLP.Dependencies;
using Ninject;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serviceFillComboBox" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serviceFillComboBox.svc or serviceFillComboBox.svc.cs at the Solution Explorer and start debugging.
    public class serviceFillComboBox : IserviceFillComboBox
    {
        [Inject]
        public IFillComboBoxRepository iFillComboBoxRepository { get; set; }

        public serviceFillComboBox()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public IEnumerable<Comum.Model.Models.modelToComboBox> GetAllValuesToComboBox(string sNameView, string sParameter)
        {
            try
            {
                return iFillComboBoxRepository.GetAllCidadeToComboBox(sNameView, sParameter);
            }
            catch (Exception ex)
            {
                Log.AddLog(xLog: ex.Message);
                throw new FaultException(reason: ex.Message);
            }

        }
    }
}
