using HLP.Comum.Infrastructure;
using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.Gerais
{
    public partial class DepositoModel : modelBase
    {
        public DepositoModel()
            : base(xTabela: "Deposito")
        {
        }

        private int? _idDeposito;

        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idDeposito
        {
            get { return _idDeposito; }
            set
            {
                _idDeposito = value;
                base.NotifyPropertyChanged(propertyName: "idDeposito");
            }
        }


        [ParameterOrder(Order = 2)]
        public int idSite { get; set; }
        [ParameterOrder(Order = 3)]
        public string xDeposito { get; set; }
        [ParameterOrder(Order = 4)]
        public string xDescricao { get; set; }
        [ParameterOrder(Order = 5)]
        public byte stTipo { get; set; }
        [ParameterOrder(Order = 6)]
        public byte stGrupoIdentificacao { get; set; }
    }

    public partial class DepositoModel
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
