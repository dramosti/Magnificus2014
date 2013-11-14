using HLP.Comum.Infrastructure;
using HLP.Comum.Model.Models;
using HLP.Comum.Model.Repository.Implementation.ClassesBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.Gerais
{
    public partial class Unidade_medidaModel : modelBase
    {
        public Unidade_medidaModel()
        {
        }

        public Unidade_medidaModel(campoSqlModel[] lCampos)
            : base()
        {
            lcamposSqlNotNull = lCampos.ToList();
        }

        private int? _idUnidadeMedida;

        [ParameterOrder(Order = 1)]
        public int? idUnidadeMedida
        {
            get { return _idUnidadeMedida; }
            set
            {
                _idUnidadeMedida = value;
                base.NotifyPropertyChanged(propertyName: "idUnidadeMedida");
            }
        }
        [ParameterOrder(Order = 2)]
        public string xSiglaPadrao { get; set; }
        [ParameterOrder(Order = 3)]
        public string xUnidadeMedida { get; set; }
        [ParameterOrder(Order = 4)]
        public int nCasasDecimais { get; set; }
    }

    public partial class Unidade_medidaModel
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
