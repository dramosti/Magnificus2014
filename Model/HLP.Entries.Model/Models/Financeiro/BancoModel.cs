﻿using HLP.Base.ClassesBases;
using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.Financeiro
{
    public partial class BancoModel : modelComum
    {
        public BancoModel()
            : base(xTabela: "Banco")
        {
        }


        private int? _idBanco;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idBanco
        {
            get { return _idBanco; }
            set
            {
                _idBanco = value;
                base.NotifyPropertyChanged(propertyName: "idBanco");
            }
        }

        [ParameterOrder(Order = 2)]
        public string cBanco { get; set; }
        [ParameterOrder(Order = 3)]
        public string xBancoResumido { get; set; }
        [ParameterOrder(Order = 4)]
        public string xBanco { get; set; }
        [ParameterOrder(Order = 5)]
        public string xLinkLogo { get; set; }
        [ParameterOrder(Order = 6)]
        public byte vDxMais { get; set; }
        [ParameterOrder(Order = 7)]
        public byte vDxMenos { get; set; }
    }

    public partial class BancoModel
    {
        public override string this[string columnName]
        {
            get
            {
                if (columnName.Equals("cBanco"))
                {
                    if (this.cBanco != "" && this.cBanco != "0")
                    {
                        int ivalida;
                        int.TryParse(this.cBanco, out ivalida);
                        if (ivalida == 0)
                            return "Somente número é aceito nesse campo.";
                    }
                }
                return base[columnName];
            }
        }
    }
}
