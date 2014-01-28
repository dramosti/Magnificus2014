using HLP.Comum.Infrastructure;
using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.Comercial
{
    public partial class JurosModel : modelBase
    {

        public JurosModel()
            : base(xTabela: "Juros")
        {
        }

        private int? _idJuros;

         [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idJuros
        {
            get { return _idJuros; }
            set
            {
                _idJuros = value;
                base.NotifyPropertyChanged(propertyName: "idJuros");
            }
        }

        [ParameterOrder(Order = 2)]
        public string xDescricao { get; set; }
        [ParameterOrder(Order = 3)]
        public decimal pJuros { get; set; }
        [ParameterOrder(Order = 4)]
        public int nQuantidadeDiasMes { get; set; }
        [ParameterOrder(Order = 5)]
        public byte stDiaMes { get; set; }
        [ParameterOrder(Order = 6)]
        public int nCarencia { get; set; }
        [ParameterOrder(Order = 7)]
        public string xNome { get; set; }
    }

    public partial class JurosModel
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
