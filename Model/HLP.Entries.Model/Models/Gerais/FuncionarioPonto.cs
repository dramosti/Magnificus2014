using HLP.Base.ClassesBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.Gerais
{
    public partial class FuncionarioPonto : modelBase
    {
        public FuncionarioPonto() : base() { }

        private int _idFuncionario;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int idFuncionario
        {
            get { return _idFuncionario; }
            set { _idFuncionario = value; base.NotifyPropertyChanged("idFuncionario"); }
        }

        private DateTime _data = DateTime.Today;
        public DateTime data
        {
            get { return _data; }
            set { _data = value; base.NotifyPropertyChanged("data"); }
        }

        private int _iDiasTrabalhados = 0;
        public int iDiasTrabalhados
        {
            get { return _iDiasTrabalhados; }
            set { _iDiasTrabalhados = value; base.NotifyPropertyChanged(propertyName: "iDiasTrabalhados"); }
        }

        private TimeSpan _tsHorasAtrabalhar = new TimeSpan();
        public TimeSpan tsHorasAtrabalhar
        {
            get { return _tsHorasAtrabalhar; }
            set { _tsHorasAtrabalhar = value; base.NotifyPropertyChanged(propertyName: "tsHorasAtrabalhar"); }
        }

        private TimeSpan _tsHorasTrabalhadas = new TimeSpan();
        public TimeSpan tsHorasTrabalhadas
        {
            get { return _tsHorasTrabalhadas; }
            set { _tsHorasTrabalhadas = value; base.NotifyPropertyChanged(propertyName: "tsHorasTrabalhadas"); }
        }

        private TimeSpan _tsHorasAcumuladasNoPeriodo = new TimeSpan();
        public TimeSpan tsHorasAcumuladasNoPeriodo
        {
            get { return _tsHorasAcumuladasNoPeriodo; }
            set { _tsHorasAcumuladasNoPeriodo = value; base.NotifyPropertyChanged(propertyName: "tsHorasAcumuladasNoPeriodo"); }
        }

        private TimeSpan _tsSaldoBancoHoras = new TimeSpan();
        public TimeSpan tsSaldoBancoHoras
        {
            get { return _tsSaldoBancoHoras; }
            set { _tsSaldoBancoHoras = value; base.NotifyPropertyChanged(propertyName: "tsSaldoBancoHoras"); }
        }

        private TimeSpan _tsSaldoAteMomento = new TimeSpan();
        public TimeSpan tsSaldoAteMomento
        {
            get { return _tsSaldoAteMomento; }
            set
            {
                _tsSaldoAteMomento = value;
                base.NotifyPropertyChanged(propertyName: "tsSaldoAteMomento");
            }
        }





    }


    public partial class FuncionarioPonto
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
