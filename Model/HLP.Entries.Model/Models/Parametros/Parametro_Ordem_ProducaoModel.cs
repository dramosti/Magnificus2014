using HLP.Base.ClassesBases;
using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.Parametros
{
    public partial class Parametro_Ordem_ProducaoModel : modelComum
    {
        public Parametro_Ordem_ProducaoModel()
            : base(xTabela: "Parametro_Ordem_Producao")
        {
        }
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idParametroOrdemProducao { get; set; }
        [ParameterOrder(Order = 2)]
        public byte stProducaoGera { get; set; }
        [ParameterOrder(Order = 3)]
        public byte stGeraOPFilhas { get; set; }
        [ParameterOrder(Order = 4)]
        public byte stFechaOPSaldoAproduzir { get; set; }
        [ParameterOrder(Order = 5)]
        public int? idTipoOperacaoparaOPProduto { get; set; }
        [ParameterOrder(Order = 6)]
        public int? idTipoOperacaoparaOPServico { get; set; }
        [ParameterOrder(Order = 7)]
        public int? idTipoOperacaoparaOPBenificiamento { get; set; }
        [ParameterOrder(Order = 8)]
        public int idEmpresa { get; set; }
    }

    public partial class Parametro_Ordem_ProducaoModel
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
