using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Infrastructure;
using HLP.Comum.Model.Models;

namespace HLP.Entries.Model.Models.Gerais
{
    public class CidadeModel : ModelBase
    {
        public int? _idCidade;

        [ParameterOrder(Order = 1)]
        public int? idCidade
        {
            get { return _idCidade; }
            set { _idCidade = value; base.NotifyPropertyChanged("idCidade"); }
        }

        public string _xCidade;

        [ParameterOrder(Order = 2)]
        public string xCidade
        {
            get { return _xCidade; }
            set { _xCidade = value; base.NotifyPropertyChanged("xCidade"); }
        }

        public int _cIbge;

        [ParameterOrder(Order = 3)]
        public int cIbge
        {
            get { return _cIbge; }
            set { _cIbge = value; base.NotifyPropertyChanged("cIbge"); }
        }

        public int _idUF;

        [ParameterOrder(Order = 4)]
        public int idUF
        {
            get { return _idUF; }
            set { _idUF = value; base.NotifyPropertyChanged("idUF"); }
        }
    }
}
