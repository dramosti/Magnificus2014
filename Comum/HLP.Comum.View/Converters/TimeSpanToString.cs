using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HLP.Comum.View.Converters
{
    [ValueConversion(sourceType: typeof(TimeSpan), targetType: typeof(string))]
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
            string[] estrTime = new string[3];
            int hours = 0;
            int minutes = 0;
            int seconds = 0;

            if (value != null)
            {
                estrTime = value.ToString().Split(':');

                if (estrTime.Count() > 0)
                    hours = int.Parse(s: estrTime[0].Trim(trimChars: ':'));

                if (estrTime.Count() > 1)
                    if (estrTime[1].ToString() != "")
                        minutes = int.Parse(s: estrTime[1].Trim(trimChars: ':'));

                if (estrTime.Count() > 2)
                    seconds = int.Parse(s: estrTime[2].Trim(trimChars: ':'));

                time = new TimeSpan(hours: hours, minutes: minutes, seconds: seconds);
            }

            return time;
        }
    }
}
