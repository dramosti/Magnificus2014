using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HLP.Entries.View.WPF.Comercial.Converter
{
    public class RowDateListaPrecoConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DateTime date;
            double dateAdd = 0;

            foreach (object o in values)
            {
                if (o == null)
                    return false;
            }

            if (DateTime.TryParse(s: values[0].ToString(), result: out date))
            {
                if (!double.TryParse(s: values[1].ToString(), result: out dateAdd))
                {
                    dateAdd = 0;
                }
                date = date.AddDays(value: dateAdd);
            }

            if (dateAdd == 0)
                return true;

            bool res = date < DateTime.Now ? false : true;

            return res;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
