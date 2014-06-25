using HLP.Base.ClassesBases;
using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.Gerais
{
    public partial class DecisaoModel : modelComum
    {
        public DecisaoModel()
            : base("Decisao")
        {
        }

        private int? _idDecisao;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idDecisao
        {
            get
            {
                return this._idDecisao;
            }
            set
            {
                this._idDecisao = value;
                base.NotifyPropertyChanged(propertyName: "idDecisao");
            }
        }

        private string _xDecisao;
        [ParameterOrder(Order = 2)]
        public string xDecisao
        {
            get { return _xDecisao; }
            set
            {
                _xDecisao = value;
            }
        }

        [ParameterOrder(Order = 3)]
        public string xDescricao { get; set; }
    }

    public partial class DecisaoModel
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
