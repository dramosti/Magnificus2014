using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Infrastructure;
using HLP.Comum.Model.Models;

namespace HLP.Entries.Model.Models.Fiscal
{
    public partial class Classificacao_fiscalModel : modelBase
    {
        public Classificacao_fiscalModel() : base("Classificacao_fiscal") { }
        
        private int? _idClassificacaoFiscal;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idClassificacaoFiscal
        {
            get { return _idClassificacaoFiscal; }
            set
            {
                _idClassificacaoFiscal = value;
                base.NotifyPropertyChanged(propertyName: "idClassificacaoFiscal");
            }
        }
        
        [ParameterOrder(Order = 2)]
        public int idEmpresa { get; set; }
        [ParameterOrder(Order = 3)]
        public string xClassificacaoFiscal { get; set; }
        [ParameterOrder(Order = 4)]
        public string cNCM { get; set; }
        [ParameterOrder(Order = 5)]
        public string cClassifcacaoFiscal { get; set; }
        [ParameterOrder(Order = 6)]
        public string xFundamentoLegal { get; set; }
        [ParameterOrder(Order = 7)]
        public decimal pIPI { get; set; }
        [ParameterOrder(Order = 8)]
        public decimal pII { get; set; }
        [ParameterOrder(Order = 9)]
        public byte stCalculaPisCofins { get; set; }
        [ParameterOrder(Order = 10)]
        public byte stRegimeTributacaoPisCofins { get; set; }
        [ParameterOrder(Order = 11)]
        public decimal vCoeficienteSubstituicaoPis { get; set; }
        [ParameterOrder(Order = 12)]
        public decimal vCoeficienteSubstituicaoCofins { get; set; }
        [ParameterOrder(Order = 13)]
        public decimal pPis { get; set; }
        [ParameterOrder(Order = 14)]
        public decimal pCofins { get; set; }
        [ParameterOrder(Order = 15)]
        public byte stCompoeBaseNormalPisCofins { get; set; }
        [ParameterOrder(Order = 16)]
        public byte stCompoeBaseSubstPis { get; set; }
        [ParameterOrder(Order = 17)]
        public byte stCompoeBaseSubstCofins { get; set; }
        [ParameterOrder(Order = 18)]
        public bool Ativo { get; set; }

    }

    public partial class Classificacao_fiscalModel 
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
