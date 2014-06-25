using HLP.Base.ClassesBases;
using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.Parametros
{
    public partial class Parametro_ComercialModel : modelComum
    {
        public Parametro_ComercialModel()
            : base(xTabela: "Parametro_Comercial")
        {
        }

        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idParametroComercial { get; set; }
        [ParameterOrder(Order = 2)]
        public int idEmpresa { get; set; }
        [ParameterOrder(Order = 3)]
        public string xMaskCentroCusto { get; set; }
        [ParameterOrder(Order = 4)]
        public byte stObrigaCreditoAprovado { get; set; }
        [ParameterOrder(Order = 5)]
        public byte stObrigaAnaliseFinanceiraOrcamento { get; set; }
        [ParameterOrder(Order = 6)]
        public byte stObrigaAnaliseFinanceiraPedidoVenda { get; set; }
        [ParameterOrder(Order = 7)]
        public byte stObrigaAnaliseFinanceiraFaturamento { get; set; }
        [ParameterOrder(Order = 8)]
        public byte stObrigaUsoListaPreco { get; set; }
        [ParameterOrder(Order = 9)]
        public byte stDescontoPor { get; set; }
        [ParameterOrder(Order = 10)]
        public byte stDesconto { get; set; }
        [ParameterOrder(Order = 11)]
        public byte stOrcamentoProjeto { get; set; }
        [ParameterOrder(Order = 12)]
        public byte stObrigaAprovacaoPedidoVenda { get; set; }
        [ParameterOrder(Order = 13)]
        public int idMoeda { get; set; }
        [ParameterOrder(Order = 14)]
        public byte stOrigemListaPreco { get; set; }
        [ParameterOrder(Order = 15)]
        public int nQuantidadeDiasOrcamento { get; set; }
        [ParameterOrder(Order = 16)]
        public byte stUtilizaVendaCasada { get; set; }
        [ParameterOrder(Order = 17)]
        public byte stUtilizaVendaKitMaterial { get; set; }
        [ParameterOrder(Order = 18)]
        public byte stRateioFrete { get; set; }
        private byte? _nCasasDecimaisItem;
        [ParameterOrder(Order = 19)]
        public byte? nCasasDecimaisItem
        {
            get { return _nCasasDecimaisItem; }
            set
            {
                _nCasasDecimaisItem = value;
                base.NotifyPropertyChanged(propertyName: "nCasasDecimaisItem");
            }
        }
        private byte? _nCasasDecimaisTotalItem;
        [ParameterOrder(Order = 20)]
        public byte? nCasasDecimaisTotalItem
        {
            get { return _nCasasDecimaisTotalItem; }
            set
            {
                _nCasasDecimaisTotalItem = value;
                base.NotifyPropertyChanged(propertyName: "nCasasDecimaisTotalItem");
            }
        }
        private byte? _nCasasDecimaisTotalNota;
        [ParameterOrder(Order = 21)]
        public byte? nCasasDecimaisTotalNota
        {
            get { return _nCasasDecimaisTotalNota; }
            set
            {
                _nCasasDecimaisTotalNota = value;
                base.NotifyPropertyChanged(propertyName: "nCasasDecimaisTotalNota");
            }
        }
    }

    public partial class Parametro_ComercialModel
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
