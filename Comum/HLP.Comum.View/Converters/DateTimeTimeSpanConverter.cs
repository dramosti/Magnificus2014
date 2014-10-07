using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HLP.Comum.View.Converters
{
    public class DateTimeTimeSpanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DateTime d = DateTime.Today;

            if (value == null)
                return null;

            TimeSpan t = (TimeSpan)value;

            if (value == null)
                return DateTime.MinValue;

            d = d.AddHours(value: t.Hours);
            d = d.AddMinutes(value: t.Minutes);

            if (DateTime.TryParse(s: value.ToString(), result: out d))
            {
                return d;
            }
            else
            {
                return DateTime.MinValue;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DateTime d = (DateTime)value;

            if (value == null)
                return TimeSpan.Zero;

            TimeSpan t = new TimeSpan(days: 0, hours: d.Hour, minutes: d.Minute, seconds: d.Second);

            return t;
        }
    }
}
