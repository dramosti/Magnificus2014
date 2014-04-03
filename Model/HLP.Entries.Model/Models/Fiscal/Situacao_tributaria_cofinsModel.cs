using HLP.Base.ClassesBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.Fiscal
{
    public partial class Situacao_tributaria_cofinsModel : modelBase
    {
        public Situacao_tributaria_cofinsModel()
            : base(xTabela: "Situacao_tributaria_cofins")
        {
        }


        private int? _idCSTCofins;

        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idCSTCofins
        {
            get { return _idCSTCofins; }
            set
            {
                _idCSTCofins = value;
                base.NotifyPropertyChanged(propertyName: "idCSTCofins");
            }
        }

        [ParameterOrder(Order = 2)]
        public string cCSTCofins { get; set; }
        [ParameterOrder(Order = 3)]
        public string xCSTCofins { get; set; }
        [ParameterOrder(Order = 4)]
        public byte stSimplesNacional { get; set; }
    }

    public partial class Situacao_tributaria_cofinsModel
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
