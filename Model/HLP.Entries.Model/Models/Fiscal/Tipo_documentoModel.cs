using HLP.Comum.Infrastructure;
using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Fiscal
{
    public partial class Tipo_documentoModel : modelBase
    {
        public Tipo_documentoModel()
            : base("Tipo_documento")
        {

            this.lTipo_documento_oper_validaModel = new ObservableCollectionBaseCadastros<Tipo_documento_oper_validaModel>();
        }
        [ParameterOrder(Order = 1)]
        public int idEmpresa { get; set; }
        public int? _idTipoDocumento;
        [ParameterOrder(Order = 2), PrimaryKey(isPrimary = true)]
        public int? idTipoDocumento
        {
            get { return _idTipoDocumento; }
            set { _idTipoDocumento = value; base.NotifyPropertyChanged("idTipoDocumento"); }
        }
        [ParameterOrder(Order = 3)]
        public string xTpdoc { get; set; }
        [ParameterOrder(Order = 4)]
        public byte stDocumento { get; set; }
        [ParameterOrder(Order = 5)]
        public byte stRelacaoPedidoxorcamento { get; set; }
        [ParameterOrder(Order = 6)]
        public byte stRelacaoPedidoxnf { get; set; }
        [ParameterOrder(Order = 7)]
        public byte stRelacaoPedidoxproducao { get; set; }
        [ParameterOrder(Order = 8)]
        public byte stGrupoFaturamento { get; set; }
        [ParameterOrder(Order = 9)]
        public string xSerieNf { get; set; }
        [ParameterOrder(Order = 10)]
        public string xEspecieVolumeNf { get; set; }
        [ParameterOrder(Order = 11)]
        public string xMarcaVolumeNf { get; set; }
        [ParameterOrder(Order = 12)]
        public byte stSomaIpi1Dup { get; set; }
        [ParameterOrder(Order = 13)]
        public byte stSomaSt1Dup { get; set; }
        [ParameterOrder(Order = 14)]
        public string xObs { get; set; }
        [ParameterOrder(Order = 15)]
        public byte stNfComplementar { get; set; }
        [ParameterOrder(Order = 16)]
        public byte stNfImportacao { get; set; }
        [ParameterOrder(Order = 17)]
        public byte stNfExportacao { get; set; }
        [ParameterOrder(Order = 18)]
        public byte stNfIndustrializacao { get; set; }
        [ParameterOrder(Order = 19)]
        public byte stNfSuframa { get; set; }
        [ParameterOrder(Order = 20)]
        public byte stNfAtivo { get; set; }
        [ParameterOrder(Order = 21)]
        public byte stCompoeVlTotalProdutos { get; set; }
        [ParameterOrder(Order = 22)]
        public byte stSomaDevolucaoVlTotalNf { get; set; }
        [ParameterOrder(Order = 23)]
        public byte stImprimeIcmsProprioComNormal { get; set; }
        [ParameterOrder(Order = 24)]
        public byte stRelacaoRecebimentoPedidocpa { get; set; }
        [ParameterOrder(Order = 25)]
        public byte stRelacaoPedidocpaCotacao { get; set; }
        [ParameterOrder(Order = 26)]
        public bool Ativo { get; set; }
        [ParameterOrder(Order = 27)]
        public int idModeloDocFiscal { get; set; }
        [ParameterOrder(Order = 28)]
        public byte? stNFdevolucao { get; set; }

        
        private ObservableCollectionBaseCadastros<Tipo_documento_oper_validaModel> _lTipo_documento_oper_validaModel;

        public ObservableCollectionBaseCadastros<Tipo_documento_oper_validaModel> lTipo_documento_oper_validaModel
        {
            get { return _lTipo_documento_oper_validaModel; }
            set
            {
                _lTipo_documento_oper_validaModel = value;
                base.NotifyPropertyChanged(propertyName: "lTipo_documento_oper_validaModel");
            }
        }
        
    }

    public partial class Tipo_documento_oper_validaModel : modelBase
    {
        public Tipo_documento_oper_validaModel() : base("Tipo_documento_oper_valida") { }

        private int? _idTipoDocumentoOperValida;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idTipoDocumentoOperValida
        {
            get { return _idTipoDocumentoOperValida; }
            set
            {
                _idTipoDocumentoOperValida = value;
                base.NotifyPropertyChanged(propertyName: "idTipoDocumentoOperValida");
            }
        }
        private int _idTipoOperacao;
        [ParameterOrder(Order = 2)]
        public int idTipoOperacao
        {
            get { return _idTipoOperacao; }
            set
            {
                _idTipoOperacao = value;
                base.NotifyPropertyChanged(propertyName: "idTipoOperacao");
            }
        }
        private int _idTipoDocumento;
        [ParameterOrder(Order = 3)]
        public int idTipoDocumento
        {
            get { return _idTipoDocumento; }
            set
            {
                _idTipoDocumento = value;
                base.NotifyPropertyChanged(propertyName: "idTipoDocumento");
            }
        }

    }

    public partial class Tipo_documentoModel
    {
        public override string this[string columnName]
        {
            get
            {
                return base[columnName];
            }
        }
    }

    public partial class Tipo_documento_oper_validaModel
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
