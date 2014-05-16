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
        public CalendarioModel() : base("Calendario") { this.lCalendario_DetalheModel = new ObservableCollectionBaseCadastros<Calendario_DetalheModel>(); }

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
                return base[columnName];
            }
        }
    }
}
