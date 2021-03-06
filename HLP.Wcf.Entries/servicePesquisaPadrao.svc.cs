﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HLP.Base.Static;
using HLP.Dependencies;
using Ninject;
using HLP.Entries.Model.Repository.Interfaces.Components;
using HLP.Base.ClassesBases;

namespace HLP.Wcf.Entries
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "servicePesquisaPadrao" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select servicePesquisaPadrao.svc or servicePesquisaPadrao.svc.cs at the Solution Explorer and start debugging.
    public class servicePesquisaPadrao : IservicePesquisaPadrao
    {
        [Inject]
        public IHlpPesquisaPadraoRepository iHlpPesquisaPadraoRepository { get; set; }

        public servicePesquisaPadrao() 
        {
            IKernel kernel = new StandardKernel(new MagnificusDependenciesModule());
            kernel.Settings.ActivationCacheDisabled = false;
            kernel.Inject(this);
            Log.xPath = @"C:\inetpub\wwwroot\log";
        }


        public PesquisaPadraoModelContract[] GetTableInformation(string sViewName)
        {
            try
            {
                var dados = iHlpPesquisaPadraoRepository.GetTableInformationContract(sViewName);
                return dados;
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        public DataSet GetData(string sSelect, bool addDefault = false, string sWhere = "", bool bOrdena = true)
        {
            object dados = iHlpPesquisaPadraoRepository.GetData(sSelect,
                addDefault,
                sWhere,
                bOrdena);
            DataSet dsReturn = new DataSet();
            dsReturn.Tables.Add((dados as DataTable));

            return dsReturn;
        }
    }
}
