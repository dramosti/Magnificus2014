using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HLP.Components.View.WPF.Converter
{
    public class decimalValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string nDecimalPlaces = "2";

            if (parameter != null)
                if (parameter.ToString() != "")
                {
                    nDecimalPlaces = parameter.ToString();
                }

            decimal dValue = decimal.Zero;

            if (value != null)
                decimal.TryParse(s: value.ToString(), result: out dValue);

            return string.Format(format: "{0:F" + nDecimalPlaces + "}", arg0: dValue);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                value = decimal.Zero;

            decimal d = decimal.Zero;

            decimal.TryParse(s: value.ToString(), result: out d);

            return d;
        }
    }
}
