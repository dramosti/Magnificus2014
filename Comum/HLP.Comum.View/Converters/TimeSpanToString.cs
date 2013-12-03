using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HLP.Comum.View.Converters
{
    public class TimeSpanToString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string ret = "";
            if (value != null)
                ret = value.ToString();

            return ret;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            TimeSpan time = TimeSpan.Zero;

            if (value != null)
                time = TimeSpan.Parse(s: value.ToString());

            return time;
        }
    }
}
