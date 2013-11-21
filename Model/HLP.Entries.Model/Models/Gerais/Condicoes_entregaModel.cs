using HLP.Comum.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.Gerais
{
    public class Condicoes_entregaModel
    {
        [ParameterOrder(Order = 1)]
        public int? idCondicaoEntrega { get; set; }
        [ParameterOrder(Order = 2)]
        public string xCondicaoEntrega { get; set; }
        [ParameterOrder(Order = 3)]
        public string xDescricao { get; set; }
        [ParameterOrder(Order = 4)]
        public byte stEnderecoImpostoSobreVendas { get; set; }
        [ParameterOrder(Order = 5)]
        public string nIntrastat { get; set; }
        [ParameterOrder(Order = 6)]
        public byte stAplicarMinGratis { get; set; }
        [ParameterOrder(Order = 7)]
        public decimal vMinimoGratis { get; set; }
    }
}
