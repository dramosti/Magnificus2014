using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Infrastructure;
using System.ComponentModel;
using HLP.Comum.Model.Models;

namespace HLP.Entries.Model.Models.Gerais
{
    public partial class CidadeModel : modelBase
    {
        private int? _idCidade;

        [ParameterOrder(Order = 1)]
        public int? idCidade
        {
            get { return _idCidade; }
            set
            {
                _idCidade = value;
                base.NotifyPropertyChanged(propertyName: "idCidade");
            }
        }

        [ParameterOrder(Order = 2)]
        public string xCidade { get; set; }

        [ParameterOrder(Order = 3)]
        public int cIbge { get; set; }

        [ParameterOrder(Order = 4)]
        public int idUF { get; set; }
    }

    public partial class CidadeModel : IDataErrorInfo
    {
        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get
            {
                return null;
            }
        }
    }
}
