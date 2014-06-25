using HLP.Base.ClassesBases;
using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.Gerais
{
    public partial class DepositoModel : modelComum
    {
        public DepositoModel()
            : base(xTabela: "Deposito")
        {
            this.stGrupoIdentificacao = 1;
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

        private byte _stGrupoIdentificacao;
        [ParameterOrder(Order = 6)]
        public byte stGrupoIdentificacao
        {
            get { return _stGrupoIdentificacao; }
            set
            {
                _stGrupoIdentificacao = value;
                base.NotifyPropertyChanged(propertyName: "stGrupoIdentificacao");
            }
        }
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
