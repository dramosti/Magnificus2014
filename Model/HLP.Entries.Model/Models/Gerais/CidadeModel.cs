using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Infrastructure;
using System.ComponentModel;

namespace HLP.Entries.Model.Models.Crm
{
    public partial class CidadeModel
    {
        public int? _idCidade;

        [ParameterOrder(Order = 1)]
        public int? idCidade
        {
            get { return _idCidade; }
            set
            {
                _idCidade = value;
            }
        }

        public string _xCidade;

        [ParameterOrder(Order = 2)]
        public string xCidade
        {
            get { return _xCidade; }
            set
            {
                _xCidade = value;
            }
        }

        public int _cIbge;

        [ParameterOrder(Order = 3)]
        public int cIbge
        {
            get { return _cIbge; }
            set
            {
                _cIbge = value;
            }
        }

        public int _idUF;

        [ParameterOrder(Order = 4)]
        public int idUF
        {
            get { return _idUF; }
            set
            {
                _idUF = value;
            }
        }
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
