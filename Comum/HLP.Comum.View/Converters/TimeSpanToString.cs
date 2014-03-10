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
            TimeSpan timeMax = new TimeSpan(hours: 23, minutes: 59, seconds: 59);
            int hours = 0;
            int minutes = 0;
            int seconds = 0;
            string[] estHoras = new string[3];

            if (value != null)
            {
                estHoras = value.ToString().Split(':');
                if (estHoras.Count() > 0)
                    if (estHoras[0] != "")
                        hours = int.Parse(s: estHoras[0].Trim(trimChars: ':'));

                if (estHoras.Count() > 1)
                    if (estHoras[0] != "")
                        minutes = int.Parse(s: estHoras[1].Trim(trimChars: ':'));

                if (estHoras.Count() > 2)
                    if (estHoras[0] != "")
                        seconds = int.Parse(s: estHoras[2].Trim(trimChars: ':'));

                time = new TimeSpan(hours: hours, minutes: minutes, seconds: seconds);

                if (time > timeMax)
                    time = timeMax;
            }
            return time;
        }
    }
}
