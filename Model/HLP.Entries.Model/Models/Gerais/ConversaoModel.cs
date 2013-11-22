using HLP.Comum.Infrastructure;
using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.Gerais
{
    public partial class ConversaoModel : modelBase
    {
        public ConversaoModel()
            : base(xTabela: "Conversao")
        {
        }

        [ParameterOrder(Order = 1)]
        public int? idConversao { get; set; }
        [ParameterOrder(Order = 2)]
        public int idEmpresa { get; set; }
        [ParameterOrder(Order = 3)]
        public int idProduto { get; set; }
        [ParameterOrder(Order = 4)]
        public decimal? nQuantidadeAdicional { get; set; }
        [ParameterOrder(Order = 5)]
        public decimal nFator { get; set; }
        [ParameterOrder(Order = 6)]
        public byte? stArredondar { get; set; }
        [ParameterOrder(Order = 7)]
        public int idDeUnidadeMedida { get; set; }
        [ParameterOrder(Order = 8)]
        public int idParaUnidadeMedida { get; set; }
    }

    public partial class ConversaoModel
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
