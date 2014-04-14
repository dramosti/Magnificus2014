using HLP.Base.ClassesBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.Gerais
{
    public partial class Condicao_pagamentoModel : modelBase
    {

        public Condicao_pagamentoModel()
            : base(xTabela: "Condicao_pagamento")
        {
        }

        private int? _idCondicaoPagamento;

        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idCondicaoPagamento
        {
            get
            {
                return this._idCondicaoPagamento;
            }
            set
            {
                this._idCondicaoPagamento = value;
                base.NotifyPropertyChanged(propertyName: "idCondicaoPagamento");
            }
        }
        [ParameterOrder(Order = 2)]
        public string xCondicaoPagamento { get; set; }
        [ParameterOrder(Order = 3)]
        public string xDescricao { get; set; }
        [ParameterOrder(Order = 4)]
        public byte stMetodo { get; set; }       

        private int? _nMeses;
        [ParameterOrder(Order = 5)]
        public int? nMeses
        {
            get { return _nMeses; }
            set
            {
                _nMeses = value;
                base.NotifyPropertyChanged(propertyName: "nMeses");
            }
        }
        
        private int? _nSemanas;
        [ParameterOrder(Order = 6)]
        public int? nSemanas
        {
            get { return _nSemanas; }
            set
            {
                _nSemanas = value;
                base.NotifyPropertyChanged(propertyName: "nSemanas");
            }
        }

        
        private int? _nDias;
        [ParameterOrder(Order = 7)]
        public int? nDias
        {
            get { return _nDias; }
            set
            {
                _nDias = value;
                base.NotifyPropertyChanged(propertyName: "nDias");
            }
        }
                
        [ParameterOrder(Order = 8)]
        public int? idPlanoPagamento { get; set; }
        [ParameterOrder(Order = 9)]
        public int? idDiaPagamento { get; set; }
        [ParameterOrder(Order = 10)]
        public byte? stDataVencimento { get; set; }
        [ParameterOrder(Order = 11)]
        public byte stCondicao { get; set; }
    }

    public partial class Condicao_pagamentoModel
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
