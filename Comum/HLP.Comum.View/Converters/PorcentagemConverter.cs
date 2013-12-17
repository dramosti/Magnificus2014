using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HLP.Comum.View.Converters
{
    public class PorcentagemConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double d;

            if (!double.TryParse(s: value.ToString(), result: out d))
            {
                d = double.MinValue;
            }

            return String.Format("{0:P1}", d/100);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            decimal valor;
            if (value != null)
            {
                value = value.ToString().Replace(".", ",");
                value = value.ToString().Replace(" ", "").Replace("%", "");

                if (decimal.TryParse(value.ToString(), out valor))
                    return valor;
            }
            return decimal.Zero;
        }
    }
}
