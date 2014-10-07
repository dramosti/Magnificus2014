using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HLP.Comum.View.Converters
{
    public class MoedaConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            decimal d;
            if (value == null)
            {
                d = decimal.Zero;
            }
            else if (!decimal.TryParse(s: value.ToString(), result: out d))
            {
                d = decimal.Zero;
            }

            return String.Format("{0:C}", d);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            decimal valor;

            if (value != null)
            {
                if (decimal.TryParse(value.ToString(), out valor))
                    return valor;
            }

            return decimal.Zero;
        }
    }
}
