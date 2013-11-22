using HLP.Comum.Infrastructure;
using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.Transportes
{
    public partial class Condicoes_entregaModel : modelBase
    {
        private int? _idCondicaoEntrega;

        [ParameterOrder(Order = 1)]
        public int? idCondicaoEntrega
        {
            get
            {
                return this._idCondicaoEntrega;
            }
            set
            {
                this._idCondicaoEntrega = value;
                base.NotifyPropertyChanged(propertyName: "idCondicaoEntrega");
            }
        }
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

    public partial class Condicoes_entregaModel
    {
        public override string this[string columnName]
        {
            get
            {
                return base[columnName];
            }
        }
    }
}
