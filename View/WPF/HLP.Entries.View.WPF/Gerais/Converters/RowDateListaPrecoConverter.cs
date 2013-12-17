using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HLP.Entries.View.WPF.Gerais.Converters
{
    public class RowDateListaPrecoConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DateTime date;
            double dateAdd;

            if (DateTime.TryParse(s: values[0].ToString(), result: out date))
            {
                if (!double.TryParse(s: values[1].ToString(), result: out dateAdd))
                {
                    dateAdd = 0;
                }
                date = date.AddDays(value: dateAdd);
            }

            bool res = date < DateTime.Now ? false : true;

            return res;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
