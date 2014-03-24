using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.Gerais
{
    public partial class EspelhoPontoModel : modelBase
    {
        public EspelhoPontoModel() : base() { }


        private TimeSpan _tEntrada = new TimeSpan();

        public TimeSpan tEntrada
        {
            get { return _tEntrada; }
            set { _tEntrada = value; base.NotifyPropertyChanged("tEntrada"); tTotal = tSaida - tEntrada; }
        }

        private TimeSpan _tSaida = new TimeSpan();

        public TimeSpan tSaida
        {
            get { return _tSaida; }
            set { _tSaida = value; base.NotifyPropertyChanged("tSaida"); tTotal = tSaida - tEntrada; }
        }

        private TimeSpan _tTotal = new TimeSpan();

        public TimeSpan tTotal
        {
            get { return ((tEntrada != new TimeSpan()) && tSaida != new TimeSpan()) ? _tTotal : new TimeSpan(); }
            set { _tTotal = value; base.NotifyPropertyChanged("tTotal"); }
        }

    }

    public partial class EspelhoPontoModel
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
