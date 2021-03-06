﻿using HLP.Base.ClassesBases;
using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.Gerais
{
    public partial class Tipo_servicoModel : modelComum
    {
        public Tipo_servicoModel() : base("Tipo_servico") { }


        public int? _idTipoServico;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idTipoServico
        {
            get { return _idTipoServico; }
            set { _idTipoServico = value; base.NotifyPropertyChanged("idTipoServico"); }
        }
        [ParameterOrder(Order = 2)]
        public int cTipoServico { get; set; }
        [ParameterOrder(Order = 3)]
        public string xTipoServico { get; set; }
    }

    public partial class Tipo_servicoModel
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
