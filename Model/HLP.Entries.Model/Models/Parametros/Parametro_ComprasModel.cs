using HLP.Comum.Infrastructure;
using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.Parametros
{
    public partial class Parametro_ComprasModel : modelBase
    {
        public Parametro_ComprasModel()
            : base(xTabela: "Parametro_Compras")
        {
        }

        [ParameterOrder(Order = 1)]
        public int? idParametro_Compras { get; set; }
        [ParameterOrder(Order = 2)]
        public byte stAprovacaoRequisicao { get; set; }
        [ParameterOrder(Order = 3)]
        public byte stAprovacaoCotacaoCompras { get; set; }
        [ParameterOrder(Order = 4)]
        public byte stAprovacaoPedidoCompras { get; set; }
        [ParameterOrder(Order = 5)]
        public decimal vAprovacaoAutomaticaPedidoCompras { get; set; }
        [ParameterOrder(Order = 6)]
        public byte stIgnoraSaldoRequisicao { get; set; }
        [ParameterOrder(Order = 7)]
        public byte stLeadTimeCotacao { get; set; }
        [ParameterOrder(Order = 8)]
        public byte stLeadTimePedidoCompra { get; set; }
        [ParameterOrder(Order = 9)]
        public int idEmpresa { get; set; }
    }

    public partial class Parametro_ComprasModel
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
