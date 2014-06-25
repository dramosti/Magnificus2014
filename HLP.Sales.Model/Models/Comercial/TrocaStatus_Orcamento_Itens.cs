using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Base.ClassesBases;
using HLP.Comum.Model.Models;

namespace HLP.Sales.Model.Models.Comercial
{
    public partial class TrocaStatus_Orcamento_Itens : modelComum
    {
        private int _codItem;

        public int codItem
        {
            get { return _codItem; }
            set
            {
                _codItem = value;
                base.NotifyPropertyChanged(propertyName: "codItem");
            }
        }

        private int _codProduto;

        public int codProduto
        {
            get { return _codProduto; }
            set
            {
                _codProduto = value;
                base.NotifyPropertyChanged(propertyName: "codProduto");
            }
        }

        private decimal _quantEnvPend;

        public decimal quantEnvPend
        {
            get { return _quantEnvPend; }
            set
            {
                _quantEnvPend = value;
                base.NotifyPropertyChanged(propertyName: "quantEnvPend");
            }
        }

        private DateTime? _dataPrevEntrega;

        public DateTime? dataPrevEntrega
        {
            get { return _dataPrevEntrega; }
            set
            {
                _dataPrevEntrega = value;
                base.NotifyPropertyChanged(propertyName: "dataPrevEntrega");
            }
        }

        private decimal _quantItens; //Essa propriedade será de acordo com a operação de mudança de status, podendo ser de quant. itens confirmados/perdidos/cancelados

        public decimal quantItens
        {
            get { return _quantItens; }
            set
            {
                _quantItens = value;
                base.NotifyPropertyChanged(propertyName: "quantItens");
            }
        }

        private DateTime _dataConf;

        public DateTime dataConf
        {
            get { return _dataConf; }
            set
            {
                _dataConf = value;
                base.NotifyPropertyChanged(propertyName: "dataConf");
            }
        }

        private int _numPedidoCompraCliente;

        public int numPedidoCompraCliente
        {
            get { return _numPedidoCompraCliente; }
            set
            {
                _numPedidoCompraCliente = value;
                base.NotifyPropertyChanged(propertyName: "numPedidoCompraCliente");
            }
        }

        private int? _idMotivoPercaCanc;

        public int? idMotivoPercaCanc
        {
            get { return _idMotivoPercaCanc; }
            set
            {
                _idMotivoPercaCanc = value;
                base.NotifyPropertyChanged(propertyName: "idMotivoPercaCanc");
            }
        }

        private string _xObservacao;

        public string xObservacao
        {
            get { return _xObservacao; }
            set
            {
                _xObservacao = value;
                base.NotifyPropertyChanged(propertyName: "xObservacao");
            }
        }
    }

    public partial class TrocaStatus_Orcamento_Itens : IDataErrorInfo
    {
        public override string this[string columnName]
        {
            get
            {
                if (columnName == "quantItens")
                {
                    if (this.quantItens > this.quantEnvPend)
                        return "Número de itens não pode ultrapassar quantidade de itens Enviados/Pendentes";
                }
                return null;
            }
        }
    }
}
