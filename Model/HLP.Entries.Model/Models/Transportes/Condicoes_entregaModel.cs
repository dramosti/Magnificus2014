﻿using HLP.Base.ClassesBases;
using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.Transportes
{
    public partial class Condicoes_entregaModel : modelComum
    {
        public Condicoes_entregaModel()
            : base(xTabela: "Condicoes_entrega")
        {
        }

        private int? _idCondicaoEntrega;

        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idCondicaoEntrega
        {
            get
            {
                return this._idCondicaoEntrega;
            }
            set
            {
                this._idCondicaoEntrega = value;
                base.NotifyPropertyChanged(propertyName: "idCondicaoEntrega");
            }
        }
        [ParameterOrder(Order = 2)]
        public string xCondicaoEntrega { get; set; }
        [ParameterOrder(Order = 3)]
        public string xDescricao { get; set; }
        [ParameterOrder(Order = 4)]
        public byte stEnderecoImpostoSobreVendas { get; set; }
        [ParameterOrder(Order = 5)]
        public string nIntrastat { get; set; }

        private byte _stAplicarMinGratis;
        [ParameterOrder(Order = 6)]
        public byte stAplicarMinGratis
        {
            get { return _stAplicarMinGratis; }
            set
            {
                _stAplicarMinGratis = value;

                if (this.GetOperationModel() == Base.EnumsBases.OperationModel.updating &&
                    value == (byte)0)
                    this.vMinimoGratis = decimal.Zero;
                                
                base.NotifyPropertyChanged(propertyName: "stAplicarMinGratis");
                base.NotifyPropertyChanged(propertyName: "vMinimoGratis");
            }
        }
        
        private decimal _vMinimoGratis;
        [ParameterOrder(Order = 7)]
        public decimal vMinimoGratis
        {
            get { return _vMinimoGratis; }
            set
            {
                _vMinimoGratis = value;
                base.NotifyPropertyChanged(propertyName: "vMinimoGratis");
            }
        }
        
    }

    public partial class Condicoes_entregaModel
    {
        public override string this[string columnName]
        {
            get
            {
                string xError = base[columnName];
                
                if (string.IsNullOrEmpty(value: xError))
                    if (columnName == "vMinimoGratis")
                    {
                        if(this.stAplicarMinGratis == (byte)1 && 
                            this.vMinimoGratis <= 0)
                        {
                            xError = "Valor de mínimo grátis deve ser maior que 0";
                        }
                    }

                return xError;
            }
        }
    }
}
