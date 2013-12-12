using HLP.Comum.Infrastructure;
using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.Comercial
{
    public partial class Canal_vendaModel : modelBase
    {
        public Canal_vendaModel()
            : base(xTabela: "Canal_venda")
        {
        }


        private int? _idCanalVenda;
        [ParameterOrder(Order = 1)]
        public int? idCanalVenda
        {
            get { return _idCanalVenda; }
            set
            {
                _idCanalVenda = value;
                base.NotifyPropertyChanged(propertyName: "idCanalVenda");
            }
        }

        [ParameterOrder(Order = 2)]
        public string cCanalVenda { get; set; }
        [ParameterOrder(Order = 3)]
        public string xCanalVenda { get; set; }
    }

    public partial class Canal_vendaModel
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
