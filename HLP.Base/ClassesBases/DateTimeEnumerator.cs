using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP.Base.ClassesBases
{
    public class DateTimeEnumerator : System.Collections.IEnumerable
    {
        private DateTime begin;
        private DateTime end;
        public DateTimeEnumerator(DateTime begin, DateTime end)
        {
            this.begin = begin;
            this.end = end;
        }
        public System.Collections.IEnumerator GetEnumerator()
        {
            for (DateTime date = begin; date <= end; date = date.AddDays(1))
            {
                yield return date;
            }
        }
    }
}
