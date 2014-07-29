using HLP.Base.ClassesBases;
using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.Financeiro
{
    public partial class Descontos_AvistaModel : modelComum
    {
        public Descontos_AvistaModel() : base("Descontos_Avista") { }

        public int? _idDescontosAvista;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idDescontosAvista
        {
            get { return _idDescontosAvista; }
            set { _idDescontosAvista = value; base.NotifyPropertyChanged("idDescontosAvista"); }
        }
        [ParameterOrder(Order = 2)]
        public string xDescontos { get; set; }
        [ParameterOrder(Order = 3)]
        public string xDescricao { get; set; }
        [ParameterOrder(Order = 4)]
        public int? idProximoDesconto { get; set; }

        private byte _stLiquidoAtual;
        [ParameterOrder(Order = 5)]
        public byte stLiquidoAtual
        {
            get { return _stLiquidoAtual; }
            set
            {
                _stLiquidoAtual = value;

                if (this.GetOperationModel() == Base.EnumsBases.OperationModel.updating)
                {
                    switch (value)
                    {
                        case 0:
                            {
                                this.nMeses = null;
                            } break;
                        case 1:
                            {
                                this.nDias = null;
                            } break;
                        default:
                            break;
                    }
                }

                base.NotifyPropertyChanged(propertyName: "stLiquidoAtual");
            }
        }

        private int? _nMeses;
        [ParameterOrder(Order = 6)]
        public int? nMeses
        {
            get { return _nMeses; }
            set
            {
                _nMeses = value;
                base.NotifyPropertyChanged(propertyName: "nMeses");
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
        public decimal? pDesconto { get; set; }

    }

    public partial class Descontos_AvistaModel
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
