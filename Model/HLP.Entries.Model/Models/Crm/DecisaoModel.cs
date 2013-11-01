using HLP.Comum.Infrastructure;
using HLP.Comum.Model.Models;
using HLP.Comum.Model.Repository.Implementation.ClassesBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.Crm
{
    public partial class DecisaoModel : modelBase
    {
        modelBaseRepository _modelBaseRepository;

        public DecisaoModel()
            : base()
        {
            this._modelBaseRepository = new modelBaseRepository();
            base.lcamposSqlNotNull = this._modelBaseRepository.getCamposSqlNotNull(xTabela: "Decisao");
        }

        private int? _idDecisao;
        [ParameterOrder(Order = 1)]
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
        [ParameterOrder(Order = 2)]
        public string xDecisao { get; set; }
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
