using HLP.Base.ClassesBases;
using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.Comercial
{
    public partial class MultasModel : modelComum
    {
        public MultasModel()
            : base(xTabela: "Multas")
        {
        }
        private int? _idMultas;

        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idMultas
        {
            get { return _idMultas; }
            set
            {
                _idMultas = value;
                base.NotifyPropertyChanged(propertyName: "idMultas");
            }
        }

        [ParameterOrder(Order = 2)]
        public string xNome { get; set; }
        [ParameterOrder(Order = 3)]
        public string xDescricao { get; set; }
        [ParameterOrder(Order = 4)]
        public decimal pPercentual { get; set; }
        [ParameterOrder(Order = 5)]
        public int nDias { get; set; }

    }

    public partial class MultasModel
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
