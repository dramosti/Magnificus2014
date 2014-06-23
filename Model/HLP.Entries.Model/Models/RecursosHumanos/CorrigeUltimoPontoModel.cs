using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Base.ClassesBases;
using HLP.Entries.Model.Models.Gerais;

namespace HLP.Entries.Model.Models.RecursosHumanos
{
    public partial class CorrigeUltimoPontoModel : modelBase
    {
        public CorrigeUltimoPontoModel() : base("") { }

        private bool _bSeleciona = false;
        public bool bSeleciona
        {
            get { return _bSeleciona; }
            set { _bSeleciona = value; base.NotifyPropertyChanged("bSeleciona"); }
        }


        private DateTime _dia;
        public DateTime dia
        {
            get { return _dia; }
            set { _dia = value; base.NotifyPropertyChanged("dia"); }
        }


        private TimeSpan? _horaAlterada;
        public TimeSpan? horaAlterada
        {
            get { return _horaAlterada; }
            set { _horaAlterada = value; base.NotifyPropertyChanged("horaAlterada"); }
        }


        private Funcionario_Controle_Horas_PontoModel _ponto = new Funcionario_Controle_Horas_PontoModel();
        public Funcionario_Controle_Horas_PontoModel ponto
        {
            get { return _ponto; }
            set { _ponto = value; base.NotifyPropertyChanged("ponto"); }
        }


    }
}
