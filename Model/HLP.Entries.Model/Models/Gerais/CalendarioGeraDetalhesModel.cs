using HLP.Base.ClassesBases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.Gerais
{
    public partial class CalendarioGeraDetalhesModel : modelBase
    {

        public CalendarioGeraDetalhesModel()
        {
            SextaInicial = new TimeSpan(7, 30, 0);
            SextaFinal = new TimeSpan(16, 30, 0);
            SegQuiInicial = new TimeSpan(7, 30, 0);
            SegQuiFinal = new TimeSpan(17, 30, 0);
            SabadoInicial = new TimeSpan();
            SabadoFinal = new TimeSpan();
            DomingoInicial = new TimeSpan();
            DomingoFinal = new TimeSpan();
            dtFinal = dtInicial = DateTime.Today;
            this.lDetalhes = new ObservableCollectionBaseCadastros<Detalhes>();
        }

        private DateTime _dtInicial;

        public DateTime dtInicial
        {
            get { return _dtInicial; }
            set { _dtInicial = value; }
        }

        private DateTime _dtFinal;

        public DateTime dtFinal
        {
            get { return _dtFinal; }
            set { _dtFinal = value; }
        }


        
        private TimeSpan _SegQuiInicial;

        public TimeSpan SegQuiInicial
        {
            get { return _SegQuiInicial; }
            set
            {
                _SegQuiInicial = value;
                base.NotifyPropertyChanged(propertyName: "SegQuiInicial");
            }
        }

        
        private TimeSpan _SegQuiFinal;

        public TimeSpan SegQuiFinal
        {
            get { return _SegQuiFinal; }
            set
            {
                _SegQuiFinal = value;
                base.NotifyPropertyChanged(propertyName: "SegQuiFinal");
            }
        }
        
        

        private TimeSpan _SextaInicial;
        public TimeSpan SextaInicial
        {
            get { return _SextaInicial; }
            set { _SextaInicial = value; }
        }

        private TimeSpan _SextaFinal;
        public TimeSpan SextaFinal
        {
            get { return _SextaFinal; }
            set { _SextaFinal = value; }
        }

        private TimeSpan _SabadoInicial;
        public TimeSpan SabadoInicial
        {
            get { return _SabadoInicial; }
            set { _SabadoInicial = value; }
        }

        private TimeSpan _SabadoFinal;
        public TimeSpan SabadoFinal
        {
            get { return _SabadoFinal; }
            set { _SabadoFinal = value; }
        }

        private TimeSpan _DomingoInicial;
        public TimeSpan DomingoInicial
        {
            get { return _DomingoInicial; }
            set { _DomingoInicial = value; }
        }

        private TimeSpan _DomingoFinal;
        public TimeSpan DomingoFinal
        {
            get { return _DomingoFinal; }
            set { _DomingoFinal = value; }
        }


        private DateTime? _diaSemProgramacao = null;
        public DateTime? diaSemProgramacao
        {
            get { return _diaSemProgramacao; }
            set
            {
                _diaSemProgramacao = value;
                base.NotifyPropertyChanged(propertyName: "diaSemProgramacao");

            }

        }


        private ObservableCollection<DateTime> _lDiasSemProgramacao = new ObservableCollection<DateTime>();

        public ObservableCollection<DateTime> lDiasSemProgramacao
        {
            get { return _lDiasSemProgramacao; }
            set
            {
                _lDiasSemProgramacao = value;
                base.NotifyPropertyChanged(propertyName: "lDiasSemProgramacao");
            }
        }





        private bool _bConsideraSabado;

        public bool bConsideraSabado
        {
            get { return _bConsideraSabado; }
            set { _bConsideraSabado = value; }
        }

        private bool _bConsideraDomingo;

        public bool bConsideraDomingo
        {
            get { return _bConsideraDomingo; }
            set { _bConsideraDomingo = value; }
        }

        private ObservableCollectionBaseCadastros<Detalhes> _lDetalhes;
        public ObservableCollectionBaseCadastros<Detalhes> lDetalhes
        {
            get { return _lDetalhes; }
            set
            {
                _lDetalhes = value;
                base.NotifyPropertyChanged(propertyName: "lDetalhes");
            }
        }
    }
    public partial class Detalhes : modelBase
    {
        public Detalhes()
        {
            horaInicial = new TimeSpan();
            horaFinal = new TimeSpan();
        }
        private TimeSpan _horaInicial;

        public TimeSpan horaInicial
        {
            get { return _horaInicial; }
            set
            {
                _horaInicial = value;
                base.NotifyPropertyChanged(propertyName: "horaInicial");
            }
        }


        private TimeSpan _horaFinal;

        public TimeSpan horaFinal
        {
            get { return _horaFinal; }
            set
            {
                _horaFinal = value;
                base.NotifyPropertyChanged(propertyName: "horaFinal");
            }
        }
    }


    public partial class CalendarioGeraDetalhesModel
    {
        private bool ValidaDia(string[] dia)
        {
            try
            {
                int dias = Convert.ToInt32(dia[0]);
                int mes = Convert.ToInt32(dia[1]);

                if (dias == 0 || dias > 31 || mes == 0 || mes > 12)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override string this[string columnName]
        {
            get
            {
                string sRet = base[columnName];
                return sRet;
            }
        }
    }



    public partial class Detalhes
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
