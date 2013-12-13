using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLP.Comum.Model.Models;

namespace HLP.Entries.Model.Models.Gerais
{
    public partial class CalendarioDetalheModel : modelBase
    {

        public CalendarioDetalheModel()
        {
            SegSexInicial = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 0, 0);
            SegSexFinal = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 17, 0, 0);
            SabadoInicial = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 0, 0);
            SabadoFinal = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 17, 0, 0);
            DomingoInicial = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 0, 0);
            DomingoFinal = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 17, 0, 0);


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

    }


    public partial class CalendarioDetalheModel 
    {
        public override string this[string columnName]
        {
            get
            {
                return base[columnName];
            }
        }
    }


    public partial class Detalhes : modelBase
    {
        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }
        
    }

}
