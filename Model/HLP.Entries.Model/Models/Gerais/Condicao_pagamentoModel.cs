﻿using HLP.Base.ClassesBases;
using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.Gerais
{
    public partial class Condicao_pagamentoModel : modelComum
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

        private byte _stMetodo;
        [ParameterOrder(Order = 4)]
        public byte stMetodo
        {
            get { return _stMetodo; }
            set
            {
                _stMetodo = value;

                switch (value)
                {
                    case 1:
                    case 3:
                        {
                            this.stCondicao = 0;
                        } break;
                    case 4:
                    case 5:
                    case 6:
                        {
                            this.stCondicao = 1;
                        } break;
                }

                base.NotifyPropertyChanged(propertyName: "stMetodo");
            }
        }

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


        private int? _idPlanoPagamento;
        [ParameterOrder(Order = 8)]
        public int? idPlanoPagamento
        {
            get { return _idPlanoPagamento; }
            set
            {
                _idPlanoPagamento = value;

                if (value != null &&
                    value != 0)
                {
                    this.nDias = this.nMeses = this.nSemanas = null;
                }

                base.NotifyPropertyChanged(propertyName: "idPlanoPagamento");
            }
        }

        [ParameterOrder(Order = 9)]
        public int? idDiaPagamento { get; set; }
        [ParameterOrder(Order = 10)]
        public byte? stDataVencimento { get; set; }

        private byte _stCondicao;
        [ParameterOrder(Order = 11)]
        public byte stCondicao
        {
            get { return _stCondicao; }
            set
            {
                _stCondicao = value;
                base.NotifyPropertyChanged(propertyName: "stCondicao");
            }
        }

        private byte? _stAlocacaoImposto;
        [ParameterOrder(Order = 12)]
        public byte? stAlocacaoImposto
        {
            get { return _stAlocacaoImposto; }
            set
            {
                _stAlocacaoImposto = value;
                base.NotifyPropertyChanged(propertyName: "stAlocacaoImposto");
            }
        }
        private byte _stPrimeiroPagamento;
        [ParameterOrder(Order = 13)]
        public byte stPrimeiroPagamento
        {
            get { return _stPrimeiroPagamento; }
            set
            {
                _stPrimeiroPagamento = value;
                base.NotifyPropertyChanged(propertyName: "stPrimeiroPagamento");
            }
        }
    }

    public partial class Condicao_pagamentoModel
    {
        public override string this[string columnName]
        {
            get
            {
                string xError = base[columnName];

                return xError;
            }
        }
    }
}
