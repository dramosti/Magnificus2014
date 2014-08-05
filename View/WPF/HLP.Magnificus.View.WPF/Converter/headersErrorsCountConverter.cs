using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HLP.Magnificus.View.WPF.Converter
{
    public class headersErrorsCountConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return "Sem erros";

            int iValueParsed = 0;

            int.TryParse(s: value.ToString(), result: out iValueParsed);

            return string.Format(format: "Erros ({0})", arg0: iValueParsed.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
}
