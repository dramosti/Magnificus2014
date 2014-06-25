using HLP.Base.ClassesBases;
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
        private byte? _stLiberacaoHoraExtra;
        [ParameterOrder(Order = 4)]
        public byte? stLiberacaoHoraExtra
        {
            get { return _stLiberacaoHoraExtra; }
            set
            {
                _stLiberacaoHoraExtra = value;
                base.NotifyPropertyChanged(propertyName: "stLiberacaoHoraExtra");
            }
        }
        private int _idEmpresa;
        [ParameterOrder(Order = 5)]
        public int idEmpresa
        {
            get { return _idEmpresa; }
            set
            {
                _idEmpresa = value;
                base.NotifyPropertyChanged(propertyName: "idEmpresa");
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
