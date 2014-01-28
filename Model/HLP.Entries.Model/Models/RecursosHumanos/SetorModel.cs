using HLP.Comum.Infrastructure;
using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.RecursosHumanos
{
    public partial class SetorModel : modelBase
    {
        public SetorModel()
            : base(xTabela: "Setor")
        { }

        [ParameterOrder(Order = 1)]
        public int idEmpresa { get; set; }

        private int? _idSetor;

        [ParameterOrder(Order = 2), PrimaryKey(isPrimary = true)]
        public int? idSetor
        {
            get
            {
                return this._idSetor;
            }
            set
            {
                this._idSetor = value;
                base.NotifyPropertyChanged(propertyName: "idSetor");
            }
        }

        [ParameterOrder(Order = 3)]
        public string xSetor { get; set; }

        [ParameterOrder(Order = 4)]
        public string xDescricao { get; set; }

        [ParameterOrder(Order = 5)]
        public string xEmail { get; set; }
    }

    public partial class SetorModel
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
