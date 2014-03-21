using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Infrastructure;
using HLP.Comum.Model.Models;

namespace HLP.Entries.Model.Models.Transportes
{
    public partial class Modos_entregaModel : modelBase
    {
        public Modos_entregaModel()
            : base("Modos_entrega")
        {
            this.stServico = 2;
        }
        public int? _idModosEntrega;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idModosEntrega
        {
            get { return _idModosEntrega; }
            set { _idModosEntrega = value; base.NotifyPropertyChanged("idModosEntrega"); }
        }
        [ParameterOrder(Order = 2)]
        public string xModosEntrega { get; set; }
        [ParameterOrder(Order = 3)]
        public string xDescricao { get; set; }
        [ParameterOrder(Order = 4)]
        public byte stServico { get; set; }
        [ParameterOrder(Order = 5)]
        public int? idTransportador { get; set; }
    }

    public partial class Modos_entregaModel
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
