using HLP.Comum.Infrastructure;
using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.Parametros
{
    public partial class Parametro_Cartao_PontoModel : modelBase
    {
        public Parametro_Cartao_PontoModel()
            : base(xTabela: "Parametro_Cartao_Ponto")
        {
        }

        private int? _idParametroCartaoPonto;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idParametroCartaoPonto
        {
            get { return _idParametroCartaoPonto; }
            set
            {
                _idParametroCartaoPonto = value;
                base.NotifyPropertyChanged(propertyName: "idParametroCartaoPonto");
            }
        }
        private byte _stCartaoPonto;
        [ParameterOrder(Order = 2)]
        public byte stCartaoPonto
        {
            get { return _stCartaoPonto; }
            set
            {
                _stCartaoPonto = value;
                base.NotifyPropertyChanged(propertyName: "stCartaoPonto");
            }
        }
        private TimeSpan? _tToleranciaEntradaAntes;
        [ParameterOrder(Order = 3)]
        public TimeSpan? tToleranciaEntradaAntes
        {
            get { return _tToleranciaEntradaAntes; }
            set
            {
                _tToleranciaEntradaAntes = value;
                base.NotifyPropertyChanged(propertyName: "tToleranciaEntradaAntes");
            }
        }
        private TimeSpan? _tToleranciaEntradaDepois;
        [ParameterOrder(Order = 4)]
        public TimeSpan? tToleranciaEntradaDepois
        {
            get { return _tToleranciaEntradaDepois; }
            set
            {
                _tToleranciaEntradaDepois = value;
                base.NotifyPropertyChanged(propertyName: "tToleranciaEntradaDepois");
            }
        }
        private TimeSpan? _tToleranciaSaidaAntes;
        [ParameterOrder(Order = 5)]
        public TimeSpan? tToleranciaSaidaAntes
        {
            get { return _tToleranciaSaidaAntes; }
            set
            {
                _tToleranciaSaidaAntes = value;
                base.NotifyPropertyChanged(propertyName: "tToleranciaSaidaAntes");
            }
        }
        private TimeSpan? _tToleranciaSaidaDepois;
        [ParameterOrder(Order = 6)]
        public TimeSpan? tToleranciaSaidaDepois
        {
            get { return _tToleranciaSaidaDepois; }
            set
            {
                _tToleranciaSaidaDepois = value;
                base.NotifyPropertyChanged(propertyName: "tToleranciaSaidaDepois");
            }
        }
        private byte? _stLiberacaoHoraExtra;
        [ParameterOrder(Order = 7)]
        public byte? stLiberacaoHoraExtra
        {
            get { return _stLiberacaoHoraExtra; }
            set
            {
                _stLiberacaoHoraExtra = value;
                base.NotifyPropertyChanged(propertyName: "stLiberacaoHoraExtra");
            }
        }
        private TimeSpan? _tToleranciaHoraExtra;
        [ParameterOrder(Order = 8)]
        public TimeSpan? tToleranciaHoraExtra
        {
            get { return _tToleranciaHoraExtra; }
            set
            {
                _tToleranciaHoraExtra = value;
                base.NotifyPropertyChanged(propertyName: "tToleranciaHoraExtra");
            }
        }

    }



    public partial class Parametro_Cartao_PontoModel 
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
