using HLP.Comum.Infrastructure;
using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.Fiscal
{
    public partial class Tipo_operacaoModel : modelBase
    {
        public Tipo_operacaoModel()
            : base(xTabela: "Tipo_Operacao")
        {
            this.lOperacaoReducaoBase = new ObservableCollectionBaseCadastros<Operacao_reducao_baseModel>();
        }

        [ParameterOrder(Order = 1)]
        public int idClassificacaoFiscal { get; set; }
        [ParameterOrder(Order = 2)]
        public int idEmpresa { get; set; }


        private int? _idTipoOperacao;

        [ParameterOrder(Order = 3), PrimaryKey(isPrimary = true)]
        public int? idTipoOperacao
        {
            get { return _idTipoOperacao; }
            set
            {
                _idTipoOperacao = value;
                base.NotifyPropertyChanged(propertyName: "idTipoOperacao");
            }
        }

        [ParameterOrder(Order = 4)]
        public string xOperacao { get; set; }
        [ParameterOrder(Order = 5)]
        public byte tpOperacao { get; set; }
        [ParameterOrder(Order = 6)]
        public byte stRepresentaFaturamento { get; set; }
        [ParameterOrder(Order = 7)]
        public byte stGeraFinanceiro { get; set; }
        [ParameterOrder(Order = 8)]
        public byte stGeraComissao { get; set; }
        [ParameterOrder(Order = 9)]
        public byte stServico { get; set; }
        [ParameterOrder(Order = 10)]
        public byte stEstoque { get; set; }
        [ParameterOrder(Order = 11)]
        public byte stEstoqueClientes { get; set; }
        [ParameterOrder(Order = 12)]
        public byte stEstoqueFornecedores { get; set; }
        [ParameterOrder(Order = 13)]
        public byte stEntregaFutura { get; set; }
        [ParameterOrder(Order = 14)]
        public byte stTipoIndustrializacao { get; set; }
        [ParameterOrder(Order = 15)]
        public int cCfopNaUf { get; set; }
        [ParameterOrder(Order = 16)]
        public int cCfopOutraUf { get; set; }
        [ParameterOrder(Order = 17)]
        public int cCfopNaoContribuinte { get; set; }
        [ParameterOrder(Order = 18)]
        public byte stRelacaoRecebimentoInspecao { get; set; }
        [ParameterOrder(Order = 19)]
        public decimal pInsumoIndustrializacao { get; set; }
        [ParameterOrder(Order = 20)]
        public decimal pMaoObraIndustrializacao { get; set; }
        [ParameterOrder(Order = 21)]
        public byte stCalculaImportacao { get; set; }
        [ParameterOrder(Order = 22)]
        public byte stCalculaCreditoIcmsSuperSimples { get; set; }
        [ParameterOrder(Order = 23)]
        public byte stCalculaCreditoIcmsSubstituicaoTributariaSuperSimples { get; set; }
        [ParameterOrder(Order = 24)]
        public byte stReduzBase { get; set; }
        [ParameterOrder(Order = 25)]
        public byte stNaoReduzBase { get; set; }
        [ParameterOrder(Order = 26)]
        public byte stCalculaIcms { get; set; }
        [ParameterOrder(Order = 27)]
        public byte stCompoeBaseIcms { get; set; }
        [ParameterOrder(Order = 28)]
        public byte stCalculaIpi { get; set; }
        [ParameterOrder(Order = 29)]
        public decimal pIpi { get; set; }
        [ParameterOrder(Order = 30)]
        public byte stCompoeBaseIpi { get; set; }
        [ParameterOrder(Order = 31)]
        public byte stCalculaIcmsSubstituicaoTributaria { get; set; }
        [ParameterOrder(Order = 32)]
        public byte stCompoeBaseIcmsSubstituicaoTributaria { get; set; }
        [ParameterOrder(Order = 33)]
        public byte stCalculaIss { get; set; }
        [ParameterOrder(Order = 34)]
        public decimal pIss { get; set; }
        [ParameterOrder(Order = 35)]
        public byte stCalculaIrrf { get; set; }
        [ParameterOrder(Order = 36)]
        public decimal pReducaoBaseIrrf { get; set; }
        [ParameterOrder(Order = 37)]
        public decimal pIrrf { get; set; }
        [ParameterOrder(Order = 38)]
        public byte stCalculaCsll { get; set; }
        [ParameterOrder(Order = 39)]
        public byte stCalculaInss { get; set; }
        [ParameterOrder(Order = 40)]
        public decimal pReducaoBaseInss { get; set; }
        [ParameterOrder(Order = 41)]
        public decimal pInss { get; set; }
        [ParameterOrder(Order = 42)]
        public byte stCalculaPisCofins { get; set; }
        [ParameterOrder(Order = 43)]
        public byte stRegimeTributacaoPisCofins { get; set; }
        [ParameterOrder(Order = 44)]
        public decimal nCoeficienteSubstituicaoTributariaPis { get; set; }
        [ParameterOrder(Order = 45)]
        public decimal nCoeficienteSubstituicaoTributariaCofins { get; set; }
        [ParameterOrder(Order = 46)]
        public decimal pPis { get; set; }
        [ParameterOrder(Order = 47)]
        public decimal pCofins { get; set; }
        [ParameterOrder(Order = 48)]
        public byte stCompoeBaseNormalPiscofins { get; set; }
        [ParameterOrder(Order = 49)]
        public byte stCompoeBaseSubtTribPis { get; set; }
        [ParameterOrder(Order = 50)]
        public byte stCompoeBaseSubtTribCofins { get; set; }
        [ParameterOrder(Order = 51)]
        public byte stCalculaCustoEntrada { get; set; }
        [ParameterOrder(Order = 52)]
        public byte stDescontaCreditoIcmsCusto { get; set; }
        [ParameterOrder(Order = 53)]
        public byte stDescontaCreditoSubstituicaoTributariaCusto { get; set; }
        [ParameterOrder(Order = 54)]
        public byte stDescontaCreditoIpiCusto { get; set; }
        [ParameterOrder(Order = 55)]
        public byte stDescontaCreditoPiscofinsCusto { get; set; }
        [ParameterOrder(Order = 56)]
        public byte stDescontaDiferencialIcmsCusto { get; set; }
        [ParameterOrder(Order = 57)]
        public byte stBaixaMaterialOp { get; set; }
        [ParameterOrder(Order = 58)]
        public byte stObrigaOpNaCompra { get; set; }
        [ParameterOrder(Order = 59)]
        public bool Ativo { get; set; }
        [ParameterOrder(Order = 60)]
        public byte? stExplosaoMatOp { get; set; }
        [ParameterOrder(Order = 61)]
        public byte? stEstoqueProdFimOP { get; set; }
        [ParameterOrder(Order = 62)]
        public byte? stVinculaPedidoVenda { get; set; }
        [ParameterOrder(Order = 63)]
        public int idCSTIcms { get; set; }
        [ParameterOrder(Order = 64)]
        public byte stOrigemMercadoria { get; set; }
        [ParameterOrder(Order = 65)]
        public int idCSTCofins { get; set; }
        [ParameterOrder(Order = 66)]
        public int idCSTIpi { get; set; }
        [ParameterOrder(Order = 67)]
        public int idCSTPis { get; set; }
        [ParameterOrder(Order = 68)]
        public int idCodigoIcmsPai { get; set; }


        private ObservableCollectionBaseCadastros<Operacao_reducao_baseModel> _lOperacaoReducaoBase;

        public ObservableCollectionBaseCadastros<Operacao_reducao_baseModel> lOperacaoReducaoBase
        {
            get { return _lOperacaoReducaoBase; }
            set
            {
                _lOperacaoReducaoBase = value;
                base.NotifyPropertyChanged(propertyName: "lOperacaoReducaoBase");
            }
        }

    }

    public partial class Operacao_reducao_baseModel : modelBase
    {
        public Operacao_reducao_baseModel()
            : base(xTabela: "Operacao_reducao_base")
        {
        }

        [ParameterOrder(Order = 1)]
        public int idTipoOperacao { get; set; }
        [ParameterOrder(Order = 2)]
        public int? idOperacaoReducaoBase { get; set; }
        [ParameterOrder(Order = 3)]
        public decimal pReducaoIcms { get; set; }
        [ParameterOrder(Order = 4)]
        public decimal pReducaoIcmsSubstTributaria { get; set; }
        [ParameterOrder(Order = 5)]
        public int idUf { get; set; }

    }

    public partial class Tipo_operacaoModel
    {
        public override string this[string columnName]
        {
            get
            {
                return base[columnName];
            }
        }
    }

    public partial class Operacao_reducao_baseModel
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
