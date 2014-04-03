using HLP.Base.ClassesBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.Parametros
{
    public partial class Parametro_FinanceiroModel : modelBase
    {
        public Parametro_FinanceiroModel()
            : base(xTabela: "Parametro_Financeiro")
        {
        }
        [ParameterOrder(Order = 1)]
        public int idEmpresa { get; set; }
        [ParameterOrder(Order = 2), PrimaryKey(isPrimary = true)]
        public int? idParametroFinanceiro { get; set; }
        [ParameterOrder(Order = 3)]
        public byte stPedidoCompraGeraPrevisao { get; set; }
        [ParameterOrder(Order = 4)]
        public byte stPedidoVendaGeraPrevisao { get; set; }
        [ParameterOrder(Order = 5)]
        public byte stPagaComissaoPor { get; set; }
        [ParameterOrder(Order = 6)]
        public byte stCreditoAprovado { get; set; }
        [ParameterOrder(Order = 7)]
        public byte stBloqueiaClientePosCartaCobranca { get; set; }
        [ParameterOrder(Order = 8)]
        public string xMaskClasseFinanceira { get; set; }
    }

    public partial class Parametro_FinanceiroModel
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
