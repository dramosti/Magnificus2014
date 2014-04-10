﻿using HLP.Base.ClassesBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.Gerais
{
    public partial class MoedaModel : modelBase
    {
        public MoedaModel()
            : base(xTabela: "Moeda")
        {

        }


        private int? _idMoeda;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idMoeda
        {
            get { return _idMoeda; }
            set
            {
                _idMoeda = value;
                base.NotifyPropertyChanged(propertyName: "idMoeda");
            }
        }
        [ParameterOrder(Order = 2)]
        public string xSiglaMoeda { get; set; }        
        
        private string _xMoeda;

        [ParameterOrder(Order = 3)]
        public string xMoeda
        {
            get { return _xMoeda; }
            set
            {
                _xMoeda = value;
                base.NotifyPropertyChanged(propertyName: "xMoeda");
            }
        }
        
        [ParameterOrder(Order = 4)]
        public string xSimbolo { get; set; }
    }

    public partial class MoedaModel
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
