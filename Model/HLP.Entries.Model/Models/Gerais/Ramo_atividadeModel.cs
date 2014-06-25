using HLP.Base.ClassesBases;
using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.Gerais
{
    public partial class Ramo_atividadeModel : modelComum
    {
        public Ramo_atividadeModel()
            : base(xTabela: "Ramo_atividade")
        {

        }

        private int? _idRamoAtividade;

        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idRamoAtividade
        {
            get { return _idRamoAtividade; }
            set
            {
                _idRamoAtividade = value;
                base.NotifyPropertyChanged(propertyName: "idRamoAtividade");
            }
        }

        [ParameterOrder(Order = 2)]
        public string xRamo { get; set; }
        [ParameterOrder(Order = 3)]
        public string xDescricao { get; set; }
        [ParameterOrder(Order = 4)]
        public string xCnae { get; set; }
    }

    public partial class Ramo_atividadeModel
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
