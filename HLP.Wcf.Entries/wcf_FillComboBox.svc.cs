using HLP.Components.Model.Models;
using HLP.Components.Model.Repository.Interfaces;
using HLP.Comum.Resources.Util;
using HLP.Dependencies;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_FillComboBox" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_FillComboBox.svc or wcf_FillComboBox.svc.cs at the Solution Explorer and start debugging.
    public class wcf_FillComboBox : Iwcf_FillComboBox
    {
        [Inject]
        public IFillComboBoxRepository iFillComboBoxRepository { get; set; }

        public wcf_FillComboBox()
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }

        public List<modelToComboBox> GetAllValuesToComboBox(string sNameView, string sParameter)
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
