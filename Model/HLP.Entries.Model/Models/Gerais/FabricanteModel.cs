using HLP.Base.ClassesBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.Gerais
{
    public partial class FabricanteModel : modelBase
    {
        public FabricanteModel()
            : base(xTabela: "Fabricante")
        {
        }

        private int? _idFabricante;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idFabricante
        {
            get { return _idFabricante; }
            set
            {
                _idFabricante = value;
                base.NotifyPropertyChanged(propertyName: "idFabricante");
            }
        }
        [ParameterOrder(Order = 2)]
        public string xFantasia { get; set; }
        [ParameterOrder(Order = 3)]
        public string xRazao { get; set; }

    }

    public partial class FabricanteModel
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
