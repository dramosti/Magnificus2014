using HLP.Base.ClassesBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Entries.Model.Models.Gerais
{
    public partial class CalendarioGeraDetalhesModel : modelBase
    {

        public CalendarioGeraDetalhesModel()
        {
            SegSexInicial = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 0, 0);
            SegSexFinal = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 17, 0, 0);
            SabadoInicial = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 0, 0);
            SabadoFinal = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 17, 0, 0);
            DomingoInicial = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 0, 0);
            DomingoFinal = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 17, 0, 0);
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



        private DateTime _SegSexInicial;
        public DateTime SegSexInicial
        {
            get { return _SegSexInicial; }
            set { _SegSexInicial = value; }
        }

        private DateTime _SegSexFinal;
        public DateTime SegSexFinal
        {
            get { return _SegSexFinal; }
            set { _SegSexFinal = value; }
        }

        private DateTime _SabadoInicial;
        public DateTime SabadoInicial
        {
            get { return _SabadoInicial; }
            set { _SabadoInicial = value; }
        }

        private DateTime _SabadoFinal;
        public DateTime SabadoFinal
        {
            get { return _SabadoFinal; }
            set { _SabadoFinal = value; }
        }

        private DateTime _DomingoInicial;
        public DateTime DomingoInicial
        {
            get { return _DomingoInicial; }
            set { _DomingoInicial = value; }
        }

        private DateTime _DomingoFinal;
        public DateTime DomingoFinal
        {
            get { return _DomingoFinal; }
            set { _DomingoFinal = value; }
        }


        private string _diaSemProgramacao = "";
        public string diaSemProgramacao
        {
            get { return _diaSemProgramacao; }
            set
            {
                _diaSemProgramacao = value;
                base.NotifyPropertyChanged(propertyName: "diaSemProgramacao");
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

                if (sRet == null)
                {
                    if (columnName == "diaSemProgramacao")
                    {
                        if (this.diaSemProgramacao != "")
                        {
                            string[] intervalos = this.diaSemProgramacao.Split(',');
                            foreach (string dias in intervalos)
                            {
                                string[] dia = dias.Split('/');
                                if (dia.Count() == 2)
                                {
                                    if (!ValidaDia(dia))
                                    {
                                        sRet = "Dia sem programação inválido.";
                                    }
                                }
                                else
                                {
                                    sRet = "Dia sem programação inválido.";
                                }
                            }
                        }
                    }
                }
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
