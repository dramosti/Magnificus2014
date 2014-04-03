using HLP.Base.ClassesBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.Parametros
{
    public partial class Parametro_FiscalModel : modelBase
    {
        public Parametro_FiscalModel()
            : base(xTabela: "Parametro_Fiscal")
        {
        }

        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idParametroFiscal { get; set; }
        [ParameterOrder(Order = 2)]
        public int idEmpresa { get; set; }
        [ParameterOrder(Order = 3)]
        public byte stSuperSimples { get; set; }
        [ParameterOrder(Order = 4)]
        public byte stCRT { get; set; }
        [ParameterOrder(Order = 5)]
        public byte stRegimeApuracaoIRPJ { get; set; }
        [ParameterOrder(Order = 6)]
        public byte stRegimeApuracaoIPI { get; set; }
        [ParameterOrder(Order = 7)]
        public byte stRegimeTributacaoPISCOFINS { get; set; }
        [ParameterOrder(Order = 8)]
        public byte stRegimeApuracaoPISCOFINS { get; set; }
        [ParameterOrder(Order = 9)]
        public decimal pPIS { get; set; }
        [ParameterOrder(Order = 10)]
        public decimal pCOFINS { get; set; }
        [ParameterOrder(Order = 11)]
        public byte stProdutorRural { get; set; }
        [ParameterOrder(Order = 12)]
        public byte stCooperativaAgricola { get; set; }
        [ParameterOrder(Order = 13)]
        public decimal pAliquotaCSLL { get; set; }
        [ParameterOrder(Order = 14)]
        public byte stDestacaISSnfServico { get; set; }
        [ParameterOrder(Order = 15)]
        public byte stDestacaCSLLnfServico { get; set; }
        [ParameterOrder(Order = 16)]
        public byte stDestacaIRRFnfServico { get; set; }
        [ParameterOrder(Order = 17)]
        public byte stDestacaPISCOFINSnfServico { get; set; }
        [ParameterOrder(Order = 18)]
        public byte stDestacaINSSnfServico { get; set; }
        [ParameterOrder(Order = 19)]
        public byte stImprimeMsgSuframaNf { get; set; }
        [ParameterOrder(Order = 20)]
        public byte stAmbienteNfeProdutos { get; set; }
        [ParameterOrder(Order = 21)]
        public byte stAmbienteNfeServicos { get; set; }
        [ParameterOrder(Order = 22)]
        public byte stImprimeCodigoNf { get; set; }
        [ParameterOrder(Order = 23)]
        public byte stImprimeMsgPadraoSs { get; set; }
        [ParameterOrder(Order = 24)]
        public byte stImprimeMsgCreditoIcmsSs { get; set; }
        [ParameterOrder(Order = 25)]
        public decimal? pICMSss { get; set; }
        [ParameterOrder(Order = 26)]
        public decimal? pISSss { get; set; }
        [ParameterOrder(Order = 27)]
        public decimal? pCSLLss { get; set; }
        [ParameterOrder(Order = 28)]
        public decimal? pIRRFss { get; set; }
        [ParameterOrder(Order = 29)]
        public decimal? pPISss { get; set; }
        [ParameterOrder(Order = 30)]
        public decimal? pCOFINSss { get; set; }
        [ParameterOrder(Order = 31)]
        public decimal? pINSSss { get; set; }
        [ParameterOrder(Order = 32)]
        public int nItensNfProduto { get; set; }
        [ParameterOrder(Order = 33)]
        public int nItensNfServico { get; set; }
        [ParameterOrder(Order = 34)]
        public byte stIcmsSubstDif { get; set; }
        [ParameterOrder(Order = 35)]
        public int? idObservacaoMsgSuperSimples { get; set; }
        [ParameterOrder(Order = 36)]
        public int? idObservacaoMsgCreditoSuperSimples { get; set; }
    }

    public partial class Parametro_FiscalModel
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
