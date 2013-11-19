using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HLP.Comum.Model.Components;
using HLP.Comum.Model.Repository.Interfaces.Components;
using Ninject;

namespace HLP.Wcf.Commum
{
       
    public class servicePesquisaPadrao : IservicePesquisaPadrao
    {

        [Inject]
        public IHlpPesquisaPadraoRepository iHlpPesquisaPadraoRepository { get; set; }


        public ResultPesquisaModelContract GetData(string sSelect, bool addDefault = false, string sWhere = "", bool bOrdena = true)
        {
            var dados = iHlpPesquisaPadraoRepository.GetData(sSelect,
                addDefault,
                sWhere,
                bOrdena);
            return dados;
        }
    }
}
