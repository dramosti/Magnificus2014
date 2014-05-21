using HLP.Base.ClassesBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.Gerais
{
    public partial class CalendarioModel : modelBase
    {
        public CalendarioModel()
            : base("Calendario")
        {

            this.lCalendario_DetalheModel = new ObservableCollectionBaseCadastros<Calendario_DetalheModel>();
            this.lCalendario_IntervaloModel = new ObservableCollectionBaseCadastros<Calendario_IntervalosModel>();
        }

        private int? _idCalendario;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idCalendario
        {
            get { return _idCalendario; }
            set
            {
                _idCalendario = value;
                base.NotifyPropertyChanged(propertyName: "idCalendario");
            }
        }
        private string _xNome;
        [ParameterOrder(Order = 2)]
        public string xNome
        {
            get { return _xNome; }
            set
            {
                _xNome = value;
                base.NotifyPropertyChanged(propertyName: "xNome");
            }
        }
        private string _xDescricao;
        [ParameterOrder(Order = 3)]
        public string xDescricao
        {
            get { return _xDescricao; }
            set
            {
                _xDescricao = value;
                base.NotifyPropertyChanged(propertyName: "xDescricao");
            }
        }
        private int? _idCalendarioBase;
        [ParameterOrder(Order = 4)]
        public int? idCalendarioBase
        {
            get { return _idCalendarioBase; }
            set
            {
                _idCalendarioBase = value;
                base.NotifyPropertyChanged(propertyName: "idCalendarioBase");
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

        //NOVOS CAMPOS
        // novos campos 
        private DateTime _dtInicial = new DateTime();
        [ParameterOrder(Order = 6)]
        public DateTime dtInicial
        {
            get { return _dtInicial; }
            set
            {
                _dtInicial = value;
                base.NotifyPropertyChanged(propertyName: "dtInicial");
            }
        }
        private DateTime _dtFinal = new DateTime();
        [ParameterOrder(Order = 7)]
        public DateTime dtFinal
        {
            get { return _dtFinal; }
            set
            {
                _dtFinal = value;
                base.NotifyPropertyChanged(propertyName: "dtFinal");
            }
        }
        private byte? _stSabado = 0;
        [ParameterOrder(Order = 8)]
        public byte? stSabado
        {
            get { return _stSabado; }
            set
            {
                _stSabado = value;
                base.NotifyPropertyChanged(propertyName: "stSabado");
            }
        }
        private byte? _stDomingo = 0;
        [ParameterOrder(Order = 9)]
        public byte? stDomingo
        {
            get { return _stDomingo; }
            set
            {
                _stDomingo = value;
                base.NotifyPropertyChanged(propertyName: "stDomingo");
            }
        }
        private TimeSpan? _tHoraInicialSegQui = new TimeSpan(7, 30, 0);
        [ParameterOrder(Order = 10)]
        public TimeSpan? tHoraInicialSegQui
        {
            get { return _tHoraInicialSegQui; }
            set
            {
                _tHoraInicialSegQui = value;
                base.NotifyPropertyChanged(propertyName: "tHoraInicialSegQui");
            }
        }
        private TimeSpan? _tHoraFinalSegQui = new TimeSpan(17, 30, 0);
        [ParameterOrder(Order = 11)]
        public TimeSpan? tHoraFinalSegQui
        {
            get { return _tHoraFinalSegQui; }
            set
            {
                _tHoraFinalSegQui = value;
                base.NotifyPropertyChanged(propertyName: "tHoraFinalSegQui");
            }
        }
        private TimeSpan? _tHoraInicialSex = new TimeSpan(7, 30, 0);
        [ParameterOrder(Order = 12)]
        public TimeSpan? tHoraInicialSex
        {
            get { return _tHoraInicialSex; }
            set
            {
                _tHoraInicialSex = value;
                base.NotifyPropertyChanged(propertyName: "tHoraInicialSex");
            }
        }
        private TimeSpan? _tHoraFinalSex = new TimeSpan(16, 30, 0);
        [ParameterOrder(Order = 13)]
        public TimeSpan? tHoraFinalSex
        {
            get { return _tHoraFinalSex; }
            set
            {
                _tHoraFinalSex = value;
                base.NotifyPropertyChanged(propertyName: "tHoraFinalSex");
            }
        }
        private TimeSpan? _tHoraInicialSab = new TimeSpan(7, 30, 0);
        [ParameterOrder(Order = 14)]
        public TimeSpan? tHoraInicialSab
        {
            get { return _tHoraInicialSab; }
            set
            {
                _tHoraInicialSab = value;
                base.NotifyPropertyChanged(propertyName: "tHoraInicialSab");
            }
        }
        private TimeSpan? _tHoraFinalSab = new TimeSpan(17, 30, 0);
        [ParameterOrder(Order = 15)]
        public TimeSpan? tHoraFinalSab
        {
            get { return _tHoraFinalSab; }
            set
            {
                _tHoraFinalSab = value;
                base.NotifyPropertyChanged(propertyName: "tHoraFinalSab");
            }
        }
        private TimeSpan? _tHoraInicialDom = new TimeSpan(7, 30, 0);
        [ParameterOrder(Order = 16)]
        public TimeSpan? tHoraInicialDom
        {
            get { return _tHoraInicialDom; }
            set
            {
                _tHoraInicialDom = value;
                base.NotifyPropertyChanged(propertyName: "tHoraInicialDom");
            }
        }
        private TimeSpan? _tHoraFinalDom = new TimeSpan(17, 30, 0);
        [ParameterOrder(Order = 17)]
        public TimeSpan? tHoraFinalDom
        {
            get { return _tHoraFinalDom; }
            set
            {
                _tHoraFinalDom = value;
                base.NotifyPropertyChanged(propertyName: "tHoraFinalDom");
            }
        }
        private string _xDiasSemProgramacao = string.Empty;
        [ParameterOrder(Order = 18)]
        public string xDiasSemProgramacao
        {
            get { return _xDiasSemProgramacao; }
            set
            {
                _xDiasSemProgramacao = value;
                base.NotifyPropertyChanged(propertyName: "xDiasSemProgramacao");
            }
        }

        private ObservableCollectionBaseCadastros<Calendario_DetalheModel> _lCalendario_DetalheModel;
        public ObservableCollectionBaseCadastros<Calendario_DetalheModel> lCalendario_DetalheModel
        {
            get { return _lCalendario_DetalheModel; }
            set
            {
                _lCalendario_DetalheModel = value;
                base.NotifyPropertyChanged(propertyName: "lCalendario_DetalheModel");
            }
        }

        private ObservableCollectionBaseCadastros<Calendario_IntervalosModel> _lCalendario_IntervaloModel = new ObservableCollectionBaseCadastros<Calendario_IntervalosModel>();
        public ObservableCollectionBaseCadastros<Calendario_IntervalosModel> lCalendario_IntervaloModel
        {
            get { return _lCalendario_IntervaloModel; }
            set
            {
                _lCalendario_IntervaloModel = value;
                base.NotifyPropertyChanged(propertyName: "lCalendario_IntervaloModel");
            }
        }


    }
    public partial class Calendario_DetalheModel : modelBase
    {
        private int? _idCalendarioDetalhe;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idCalendarioDetalhe
        {
            get { return _idCalendarioDetalhe; }
            set
            {
                _idCalendarioDetalhe = value;
                base.NotifyPropertyChanged(propertyName: "idCalendarioDetalhe");
            }
        }
        private DateTime _dCalendario;
        [ParameterOrder(Order = 2)]
        public DateTime dCalendario
        {
            get { return _dCalendario; }
            set
            {
                _dCalendario = value;
                base.NotifyPropertyChanged(propertyName: "dCalendario");
            }
        }
        private TimeSpan _tHoraInicio;
        [ParameterOrder(Order = 3)]
        public TimeSpan tHoraInicio
        {
            get { return _tHoraInicio; }
            set
            {
                _tHoraInicio = value;
                base.NotifyPropertyChanged(propertyName: "dHoraInicio");
            }
        }
        private TimeSpan _tHoraTermino;
        [ParameterOrder(Order = 4)]
        public TimeSpan tHoraTermino
        {
            get { return _tHoraTermino; }
            set
            {
                _tHoraTermino = value;
                base.NotifyPropertyChanged(propertyName: "dHoraTermino");
            }
        }
        private int _idCalendario;
        [ParameterOrder(Order = 5)]
        public int idCalendario
        {
            get { return _idCalendario; }
            set
            {
                _idCalendario = value;
                base.NotifyPropertyChanged(propertyName: "idCalendario");
            }
        }
    }

    public partial class Calendario_IntervalosModel : modelBase
    {
        public Calendario_IntervalosModel()
            : base("Calendario_Intervalos")
        {
        }
        private int? _idCalendarioIntervalo;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idCalendarioIntervalo
        {
            get { return _idCalendarioIntervalo; }
            set
            {
                _idCalendarioIntervalo = value;
                base.NotifyPropertyChanged(propertyName: "idCalendarioIntervalo");
            }
        }
        private int _idCalendario;
        [ParameterOrder(Order = 2)]
        public int idCalendario
        {
            get { return _idCalendario; }
            set
            {
                _idCalendario = value;
                base.NotifyPropertyChanged(propertyName: "idCalendario");
            }
        }
        private TimeSpan _tInicio;
        [ParameterOrder(Order = 3)]
        public TimeSpan tInicio
        {
            get { return _tInicio; }
            set
            {
                _tInicio = value;
                base.NotifyPropertyChanged(propertyName: "tInicio");
            }
        }
        private TimeSpan _tFinal;
        [ParameterOrder(Order = 4)]
        public TimeSpan tFinal
        {
            get { return _tFinal; }
            set
            {
                _tFinal = value;
                base.NotifyPropertyChanged(propertyName: "tFinal");
            }
        }
        private byte? _stTipoIntervalo = 0;
        [ParameterOrder(Order = 5)]
        public byte? stTipoIntervalo
        {
            get { return _stTipoIntervalo; }
            set
            {
                _stTipoIntervalo = value;
                base.NotifyPropertyChanged(propertyName: "stTipoIntervalo");
            }
        }

        public string getTipoIntervalo()
        {
            string sReturn="";
            switch ((byte)this.stTipoIntervalo)
            {
                case 0:
                    sReturn = "OUTROS";
                    break;
                case 1:
                    sReturn = "ALMOÇO/JANTA";
                    break;
                case 2:
                    sReturn = "LANCHE";
                    break;
                case 3:
                    sReturn = "SETUP";
                    break;
            }
            return sReturn;
        }
    }



    public partial class Calendario_IntervalosModel
    {
        public override string this[string columnName]
        {
            get
            {
                return base[columnName];
            }
        }
    }

    public partial class Calendario_DetalheModel
    {
        public override string this[string columnName]
        {
            get
            {
                return base[columnName];
            }
        }
    }
    public partial class CalendarioModel
    {
        public override string this[string columnName]
        {
            get
            {
                string sReturn = base[columnName];
                if (columnName.Equals("dtFinal") || columnName.Equals("dtInicial"))
                {
                    if (sReturn == null)
                    {
                        if (this.dtFinal < this.dtInicial)
                        {
                            sReturn = "Data final deve ser maior que data inícial !";
                        }
                    }
                }
                return sReturn;
            }
        }
    }
}
