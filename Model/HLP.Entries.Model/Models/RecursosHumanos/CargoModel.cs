using HLP.Comum.Infrastructure;
using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.RecursosHumanos
{
    public partial class CargoModel : modelBase
    {
        public CargoModel()
            : base("Cargo")
        {
        }

        private int? _idCargo;
        [ParameterOrder(Order = 1)]
        public int? idCargo
        {
            get
            {
                return this._idCargo;
            }
            set
            {
                this._idCargo = value;
                base.NotifyPropertyChanged(propertyName: "idCargo");
            }
        }
        [ParameterOrder(Order = 2)]
        public string xCargo { get; set; }
        [ParameterOrder(Order = 3)]
        public string xDescricao { get; set; }
        [ParameterOrder(Order = 4)]
        public int idEmpresa { get; set; }
    }

    public partial class CargoModel
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
