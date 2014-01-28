using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Infrastructure;
using HLP.Comum.Model.Models;

namespace HLP.Entries.Model.Models.Fiscal
{
    public partial class CfopModel : modelBase
    {
        public CfopModel() : base("Cfop") { }

        private int? _idCfop;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idCfop
        {
            get { return _idCfop; }
            set
            {
                _idCfop = value;
                base.NotifyPropertyChanged(propertyName: "idCfop");
            }
        }


        [ParameterOrder(Order = 2)]
        public int cCfop { get; set; }

        [ParameterOrder(Order = 3)]
        public string xCfop { get; set; }

        [ParameterOrder(Order = 4)]
        public string xCfopResumida { get; set; }

    }
    public partial class CfopModel
    {
        public override string this[string columnName]
        {
            get
            {
                string sValidacao = base[columnName];

                if (sValidacao == null)
                {
                    if (columnName == "cCfop")
                    {
                        if (cCfop.ToString().Length != 4)
                        {
                            sValidacao =  "CFOP deve conter 4 digitos";
                        }
                    }
                }
                return sValidacao;
            }
        }
    }
}
