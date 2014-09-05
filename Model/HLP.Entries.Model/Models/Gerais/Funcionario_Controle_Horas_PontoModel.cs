using HLP.Base.ClassesBases;
using HLP.Base.EnumsBases;
using HLP.Comum.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.Gerais
{
    public partial class Funcionario_Controle_Horas_PontoModel : INotifyPropertyChanged
    {
        #region NotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                if (this.status == statusModel.nenhum)
                    this.status = statusModel.alterado;
            }
        }

        #endregion

        public statusModel status { get; set; }

        public Funcionario_Controle_Horas_PontoModel()
        { }

        private int? _idFuncionarioControleHorasPonto;
        [ParameterOrder(Order = 1), PrimaryKey(isPrimary = true)]
        public int? idFuncionarioControleHorasPonto
        {
            get { return _idFuncionarioControleHorasPonto; }
            set
            {
                _idFuncionarioControleHorasPonto = value;
                this.NotifyPropertyChanged(propertyName: "idFuncionarioControleHorasPonto");
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
                this.NotifyPropertyChanged(propertyName: "idFuncionario");
            }
        }
        private TimeSpan _hRelogioPonto;
        [ParameterOrder(Order = 3)]
        public TimeSpan hRelogioPonto
        {
            get { return _hRelogioPonto; }
            set
            {
                _hRelogioPonto = value;
                this.NotifyPropertyChanged(propertyName: "hRelogioPonto");
            }
        }
        private DateTime _dRelogioPonto;
        [ParameterOrder(Order = 4)]
        public DateTime dRelogioPonto
        {
            get { return _dRelogioPonto; }
            set
            {
                _dRelogioPonto = value;
                this.NotifyPropertyChanged(propertyName: "dRelogioPonto");
            }
        }
        private TimeSpan? _hAlteradaUsuario = new TimeSpan();
        [ParameterOrder(Order = 5)]
        public TimeSpan? hAlteradaUsuario
        {
            get { return _hAlteradaUsuario; }
            set
            {
                _hAlteradaUsuario = value;
                this.NotifyPropertyChanged(propertyName: "hAlteradaUsuario");
            }
        }
        private DateTime? _dAlteradaUsuario;
        [ParameterOrder(Order = 6)]
        public DateTime? dAlteradaUsuario
        {
            get { return _dAlteradaUsuario; }
            set
            {
                _dAlteradaUsuario = value;
                this.NotifyPropertyChanged(propertyName: "dAlteradaUsuario");
            }
        }
        private string _xJustificativa;
        [ParameterOrder(Order = 7)]
        public string xJustificativa
        {
            get { return _xJustificativa; }
            set
            {
                _xJustificativa = value;
                this.NotifyPropertyChanged(propertyName: "xJustificativa");
            }
        }
        private int _idSequenciaInterna;
        [ParameterOrder(Order = 8)]
        public int idSequenciaInterna
        {
            get { return _idSequenciaInterna; }
            set
            {
                _idSequenciaInterna = value;
                this.NotifyPropertyChanged(propertyName: "idSequenciaInterna");
            }
        }
        private byte _stFeriasAbono;
        [ParameterOrder(Order = 9)]
        public byte stFeriasAbono
        {
            get { return _stFeriasAbono; }
            set
            {
                _stFeriasAbono = value;
                this.NotifyPropertyChanged(propertyName: "stFeriasAbono");
            }
        }
        private byte _stFalta;
        [ParameterOrder(Order = 10)]
        public byte stFalta
        {
            get { return _stFalta; }
            set
            {
                _stFalta = value;
                this.NotifyPropertyChanged(propertyName: "stFalta");
            }
        }

    }


    //public partial class Funcionario_Controle_Horas_PontoModel
    //{
    //    public override string this[string columnName]
    //    {
    //        get
    //        {
    //            return string.Empty;
    //        }
    //    }
    //}
}
