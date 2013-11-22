﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Infrastructure;
using HLP.Comum.Model.Models;

namespace HLP.Entries.Model.Comercial
{
    public partial class Tipo_produtoModel : modelBase
    {
        public Tipo_produtoModel()
            : base(xTabela: "Tipo_produto") { }
        
        [ParameterOrder(Order = 1)]
        public int? idTipoProduto { get; set; }
        [ParameterOrder(Order = 2)]
        public string xTipo { get; set; }
        [ParameterOrder(Order = 3)]
        public string xDescricao { get; set; }
        [ParameterOrder(Order = 4)]
        public byte stPatrimonio { get; set; }
        [ParameterOrder(Order = 5)]
        public byte stProducao { get; set; }
        [ParameterOrder(Order = 6)]
        public byte stEstoque { get; set; }
        [ParameterOrder(Order = 7)]
        public byte stCompras { get; set; }
        [ParameterOrder(Order = 8)]
        public byte stComercial { get; set; }
        [ParameterOrder(Order = 9)]
        public byte stTerceiros { get; set; }
        [ParameterOrder(Order = 10)]
        public byte stServicos { get; set; }
    }

    public partial class Tipo_produtoModel
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