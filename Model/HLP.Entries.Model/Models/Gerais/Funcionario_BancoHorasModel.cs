using HLP.Base.ClassesBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.Gerais
{
    public partial class Funcionario_BancoHorasModel : modelBase
    {
        public Funcionario_BancoHorasModel() : base() { }

        private int? _idFuncionarioBancoHoras;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idFuncionarioBancoHoras
        {
            get { return _idFuncionarioBancoHoras; }
            set
            {
                _idFuncionarioBancoHoras = value;
                base.NotifyPropertyChanged(propertyName: "idFuncionarioBancoHoras");
            }
        }
        private int _idFuncionario;
        [ParameterOrder(Order = 2)]
        public int idFuncionario
        {
            get { return _idFuncionario; }
            set
            {
                _idFuncionario = value;
                base.NotifyPropertyChanged(propertyName: "idFuncionario");
            }
        }
        private string _xMesAno;
        [ParameterOrder(Order = 3)]
        public string xMesAno
        {
            get { return _xMesAno; }
            set
            {
                _xMesAno = value;
                base.NotifyPropertyChanged(propertyName: "xMesAno");
            }
        }
        private string _tBancoHoras = "00:00:00";
        [ParameterOrder(Order = 4)]
        public string tBancoHoras
        {
            get { return _tBancoHoras; }
            set
            {
                _tBancoHoras = value;
                base.NotifyPropertyChanged(propertyName: "tBancoHoras");
            }
        }
        private int _iDiasTrabalhados = 0;
        [ParameterOrder(Order = 5)]
        public int iDiasTrabalhados
        {
            get { return _iDiasTrabalhados; }
            set
            {
                _iDiasTrabalhados = value;
                base.NotifyPropertyChanged(propertyName: "iDiasTrabalhados");
            }
        }
        private string _tHorastrabalhadas = "00:00:00";
        [ParameterOrder(Order = 6)]
        public string tHorastrabalhadas
        {
            get { return _tHorastrabalhadas; }
            set
            {
                _tHorastrabalhadas = value;
                base.NotifyPropertyChanged(propertyName: "tHorastrabalhadas");
            }
        }
        private string _tHorasAtrabalhar = "00:00:00";
        [ParameterOrder(Order = 7)]
        public string tHorasAtrabalhar
        {
            get { return _tHorasAtrabalhar; }
            set
            {
                _tHorasAtrabalhar = value;
                base.NotifyPropertyChanged(propertyName: "tHorasAtrabalhar");
            }
        }
        private string _tSaldoTotalAnterior = "00:00:00";
        [ParameterOrder(Order = 8)]
        public string tSaldoTotalAnterior
        {
            get { return _tSaldoTotalAnterior; }
            set
            {
                _tSaldoTotalAnterior = value;
                base.NotifyPropertyChanged(propertyName: "tSaldoTotalAnterior");
            }
        }
        
        // NOT MAP
        private TimeSpan _tsSaldoAteMomento = new TimeSpan();
        /// <summary>
        /// Not Map
        /// </summary>
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


    public partial class Funcionario_BancoHorasModel
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
