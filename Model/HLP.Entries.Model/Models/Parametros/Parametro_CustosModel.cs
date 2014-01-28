using HLP.Comum.Infrastructure;
using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.Parametros
{
    public partial class Parametro_CustosModel : modelBase
    {
        public Parametro_CustosModel()
            : base(xTabela: "Parametro_Custos")
        {
        }
        [ParameterOrder(Order = 1)]
        public int idEmpresa { get; set; }
        [ParameterOrder(Order = 2), PrimaryKey(isPrimary = true)]
        public int? idParametroCustos { get; set; }
        [ParameterOrder(Order = 3)]
        public string xHorasTrabalhadasDia { get; set; }
        [ParameterOrder(Order = 4)]
        public string xDiasTrabalhadasSemana { get; set; }
        [ParameterOrder(Order = 5)]
        public byte stCustoComposicao { get; set; }
        [ParameterOrder(Order = 6)]
        public byte stValorVenda { get; set; }
        [ParameterOrder(Order = 7)]
        public byte stAtualizaValorCusto { get; set; }
        [ParameterOrder(Order = 8)]
        public byte stAtualizaValorVenda { get; set; }
        [ParameterOrder(Order = 9)]
        public byte stCustoDefault { get; set; }
        [ParameterOrder(Order = 10)]
        public byte stCustoMedio { get; set; }
        [ParameterOrder(Order = 11)]
        public byte stCompoeBaseCalculoCustoOperacional { get; set; }
        [ParameterOrder(Order = 12)]
        public int? idTipoOperacao { get; set; }
        [ParameterOrder(Order = 13)]
        public byte st_Markup { get; set; }
    }

    public partial class Parametro_CustosModel
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
