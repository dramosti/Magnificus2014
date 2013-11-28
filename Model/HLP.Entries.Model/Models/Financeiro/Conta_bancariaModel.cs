using HLP.Comum.Infrastructure;
using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.Financeiro
{
    public partial class Conta_bancariaModel : modelBase
    {
        public Conta_bancariaModel()
            : base(xTabela: "Conta_bancaria")
        {
        }


        private int? _idContaBancaria;
        [ParameterOrder(Order = 1)]
        public int? idContaBancaria
        {
            get { return _idContaBancaria; }
            set
            {
                _idContaBancaria = value;
                base.NotifyPropertyChanged(propertyName: "idContaBancaria");
            }
        }

        [ParameterOrder(Order = 2)]
        public int idEmpresa { get; set; }
        [ParameterOrder(Order = 3)]
        public string xNumeroConta { get; set; }
        [ParameterOrder(Order = 4)]
        public byte stConta { get; set; }
        [ParameterOrder(Order = 5)]
        public string xTitular { get; set; }
        [ParameterOrder(Order = 6)]
        public string xCNPJouCPFTitular { get; set; }
        [ParameterOrder(Order = 7)]
        public int idAgencia { get; set; }
        [ParameterOrder(Order = 8)]
        public string xNumeroContaHomeBanking { get; set; }
        [ParameterOrder(Order = 9)]
        public byte stBloquete { get; set; }
        [ParameterOrder(Order = 10)]
        public int nDiasProtesto { get; set; }
        [ParameterOrder(Order = 11)]
        public int nSequenciaNossoNumero { get; set; }
        [ParameterOrder(Order = 12)]
        public byte stZeraNossoNumero { get; set; }
        [ParameterOrder(Order = 13)]
        public int nCarteira { get; set; }
        [ParameterOrder(Order = 14)]
        public int nVariacaoCarteira { get; set; }
        [ParameterOrder(Order = 15)]
        public byte stAceite { get; set; }
        [ParameterOrder(Order = 16)]
        public int nConvenio { get; set; }
        [ParameterOrder(Order = 17)]
        public string xCodigoEmpresaHomeBanking { get; set; }
        [ParameterOrder(Order = 18)]
        public int nDigitosConvenio { get; set; }
        [ParameterOrder(Order = 19)]
        public string xEspecie { get; set; }
        [ParameterOrder(Order = 20)]
        public int nRemessaHomeBanking { get; set; }
        [ParameterOrder(Order = 21)]
        public string xDescricao { get; set; }
    }

    public partial class Conta_bancariaModel
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
