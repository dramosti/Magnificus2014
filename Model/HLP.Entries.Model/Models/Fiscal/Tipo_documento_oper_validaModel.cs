using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Infrastructure;
using HLP.Comum.Model.Models;

namespace HLP.Entries.Model.Models.Fiscal
{
    public partial class Tipo_documento_oper_validaModel : modelBase
    {
        public Tipo_documento_oper_validaModel()
            : base(xTabela: "Tipo_documento_oper_valida")
        {
        }

        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idTipoDocumentoOperValida { get; set; }

        [ParameterOrder(Order = 2)]
        public int idTipoOperacao { get; set; }

        [ParameterOrder(Order = 3)]
        public int idTipoDocumento { get; set; }
    }

    public partial class Tipo_documento_oper_validaModel
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
