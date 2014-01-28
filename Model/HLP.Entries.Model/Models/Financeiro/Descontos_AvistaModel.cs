using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Infrastructure;
using HLP.Comum.Model.Models;

namespace HLP.Entries.Model.Models.Financeiro
{
    public partial class Descontos_AvistaModel : modelBase
    {
        public Descontos_AvistaModel() : base("Descontos_Avista") { }

        public int? _idDescontosAvista;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idDescontosAvista
        {
            get { return _idDescontosAvista; }
            set { _idDescontosAvista = value; base.NotifyPropertyChanged("idDescontosAvista"); }
        }
        [ParameterOrder(Order = 2)]
        public string xDescontos { get; set; }
        [ParameterOrder(Order = 3)]
        public string xDescricao { get; set; }
        [ParameterOrder(Order = 4)]
        public int? idProximoDesconto { get; set; }
        [ParameterOrder(Order = 5)]
        public byte stLiquidoAtual { get; set; }
        [ParameterOrder(Order = 6)]
        public int? nMeses { get; set; }
        [ParameterOrder(Order = 7)]
        public int? nDias { get; set; }
        [ParameterOrder(Order = 8)]
        public decimal? pDesconto { get; set; }

    }

    public partial class Descontos_AvistaModel 
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
